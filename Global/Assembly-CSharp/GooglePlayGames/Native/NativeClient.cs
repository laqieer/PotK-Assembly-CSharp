// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.NativeClient
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.Events;
using GooglePlayGames.BasicApi.Multiplayer;
using GooglePlayGames.BasicApi.Quests;
using GooglePlayGames.BasicApi.SavedGame;
using GooglePlayGames.Native.Cwrapper;
using GooglePlayGames.Native.PInvoke;
using GooglePlayGames.OurUtils;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

#nullable disable
namespace GooglePlayGames.Native
{
  public class NativeClient : IPlayGamesClient
  {
    private readonly IClientImpl clientImpl;
    private readonly object GameServicesLock = new object();
    private readonly object AuthStateLock = new object();
    private readonly PlayGamesClientConfiguration mConfiguration;
    private GooglePlayGames.Native.PInvoke.GameServices mServices;
    private volatile NativeTurnBasedMultiplayerClient mTurnBasedClient;
    private volatile NativeRealtimeMultiplayerClient mRealTimeClient;
    private volatile ISavedGameClient mSavedGameClient;
    private volatile IEventsClient mEventsClient;
    private volatile IQuestsClient mQuestsClient;
    private volatile TokenClient mTokenClient;
    private volatile Action<Invitation, bool> mInvitationDelegate;
    private volatile Dictionary<string, GooglePlayGames.BasicApi.Achievement> mAchievements;
    private volatile GooglePlayGames.BasicApi.Multiplayer.Player mUser;
    private volatile List<GooglePlayGames.BasicApi.Multiplayer.Player> mFriends;
    private volatile Action<bool, string> mPendingAuthCallbacks;
    private volatile Action<bool, string> mSilentAuthCallbacks;
    private volatile NativeClient.AuthState mAuthState;
    private volatile uint mAuthGeneration;
    private volatile bool mSilentAuthFailed;
    private volatile bool friendsLoading;
    private string rationale;
    private int webclientWarningFreq = 100000;
    private int noWebClientIdWarningCount;

    internal NativeClient(PlayGamesClientConfiguration configuration, IClientImpl clientImpl)
    {
      PlayGamesHelperObject.CreateObject();
      this.mConfiguration = Misc.CheckNotNull<PlayGamesClientConfiguration>(configuration);
      this.clientImpl = clientImpl;
      this.rationale = configuration.PermissionRationale;
      if (!string.IsNullOrEmpty(this.rationale))
        return;
      this.rationale = "Select email address to send to this game or hit cancel to not share.";
    }

    private GooglePlayGames.Native.PInvoke.GameServices GameServices()
    {
      lock (this.GameServicesLock)
        return this.mServices;
    }

    public void Authenticate(Action<bool, string> callback, bool silent)
    {
      lock (this.AuthStateLock)
      {
        if (this.mAuthState == NativeClient.AuthState.Authenticated)
        {
          NativeClient.InvokeCallbackOnGameThread<bool, string>(callback, true, (string) null);
          return;
        }
        if (this.mSilentAuthFailed && silent)
        {
          NativeClient.InvokeCallbackOnGameThread<bool, string>(callback, false, "silent auth failed");
          return;
        }
        if (callback != null)
        {
          if (silent)
            this.mSilentAuthCallbacks += callback;
          else
            this.mPendingAuthCallbacks += callback;
        }
      }
      this.InitializeGameServices();
      this.friendsLoading = false;
      if (silent)
        return;
      this.GameServices().StartAuthorizationUI();
    }

    private static Action<T> AsOnGameThreadCallback<T>(Action<T> callback)
    {
      return callback == null ? (Action<T>) (_param0 => { }) : (Action<T>) (result => NativeClient.InvokeCallbackOnGameThread<T>(callback, result));
    }

    private static void InvokeCallbackOnGameThread<T, S>(Action<T, S> callback, T data, S msg)
    {
      if (callback == null)
        return;
      PlayGamesHelperObject.RunOnGameThread((Action) (() =>
      {
        Logger.d("Invoking user callback on game thread");
        callback(data, msg);
      }));
    }

    private static void InvokeCallbackOnGameThread<T>(Action<T> callback, T data)
    {
      if (callback == null)
        return;
      PlayGamesHelperObject.RunOnGameThread((Action) (() =>
      {
        Logger.d("Invoking user callback on game thread");
        callback(data);
      }));
    }

    private void InitializeGameServices()
    {
      lock (this.GameServicesLock)
      {
        if (this.mServices != null)
          return;
        using (GameServicesBuilder gameServicesBuilder = GameServicesBuilder.Create())
        {
          using (PlatformConfiguration platformConfiguration = this.clientImpl.CreatePlatformConfiguration())
          {
            this.RegisterInvitationDelegate(this.mConfiguration.InvitationDelegate);
            gameServicesBuilder.SetOnAuthFinishedCallback(new GameServicesBuilder.AuthFinishedCallback(this.HandleAuthTransition));
            gameServicesBuilder.SetOnTurnBasedMatchEventCallback((Action<Types.MultiplayerEvent, string, NativeTurnBasedMatch>) ((eventType, matchId, match) => this.mTurnBasedClient.HandleMatchEvent(eventType, matchId, match)));
            gameServicesBuilder.SetOnMultiplayerInvitationEventCallback(new Action<Types.MultiplayerEvent, string, GooglePlayGames.Native.PInvoke.MultiplayerInvitation>(this.HandleInvitation));
            if (this.mConfiguration.EnableSavedGames)
              gameServicesBuilder.EnableSnapshots();
            if (this.mConfiguration.RequireGooglePlus)
              gameServicesBuilder.RequireGooglePlus();
            foreach (string scope in this.mConfiguration.Scopes)
              gameServicesBuilder.AddOauthScope(scope);
            Debug.Log((object) "Building GPG services, implicitly attempts silent auth");
            this.mAuthState = NativeClient.AuthState.SilentPending;
            this.mServices = gameServicesBuilder.Build(platformConfiguration);
            this.mEventsClient = (IEventsClient) new NativeEventClient(new GooglePlayGames.Native.PInvoke.EventManager(this.mServices));
            this.mQuestsClient = (IQuestsClient) new NativeQuestClient(new GooglePlayGames.Native.PInvoke.QuestManager(this.mServices));
            this.mTurnBasedClient = new NativeTurnBasedMultiplayerClient(this, new TurnBasedManager(this.mServices));
            this.mTurnBasedClient.RegisterMatchDelegate(this.mConfiguration.MatchDelegate);
            this.mRealTimeClient = new NativeRealtimeMultiplayerClient(this, new RealtimeManager(this.mServices));
            this.mSavedGameClient = !this.mConfiguration.EnableSavedGames ? (ISavedGameClient) new UnsupportedSavedGamesClient("You must enable saved games before it can be used. See PlayGamesClientConfiguration.Builder.EnableSavedGames.") : (ISavedGameClient) new NativeSavedGameClient(new GooglePlayGames.Native.PInvoke.SnapshotManager(this.mServices));
            this.mAuthState = NativeClient.AuthState.SilentPending;
            this.mTokenClient = this.clientImpl.CreateTokenClient(this.mUser != null ? this.mUser.id : (string) null, false);
          }
        }
      }
    }

    internal void HandleInvitation(
      Types.MultiplayerEvent eventType,
      string invitationId,
      GooglePlayGames.Native.PInvoke.MultiplayerInvitation invitation)
    {
      Action<Invitation, bool> currentHandler = this.mInvitationDelegate;
      if (currentHandler == null)
        Logger.d("Received " + (object) eventType + " for invitation " + invitationId + " but no handler was registered.");
      else if (eventType == Types.MultiplayerEvent.REMOVED)
      {
        Logger.d("Ignoring REMOVED for invitation " + invitationId);
      }
      else
      {
        bool shouldAutolaunch = eventType == Types.MultiplayerEvent.UPDATED_FROM_APP_LAUNCH;
        Invitation invite = invitation.AsInvitation();
        PlayGamesHelperObject.RunOnGameThread((Action) (() => currentHandler(invite, shouldAutolaunch)));
      }
    }

    public string GetUserEmail()
    {
      if (!this.IsAuthenticated())
      {
        Debug.Log((object) "Cannot get API client - not authenticated");
        return (string) null;
      }
      this.mTokenClient.SetRationale(this.rationale);
      return this.mTokenClient.GetEmail();
    }

    public void GetUserEmail(Action<CommonStatusCodes, string> callback)
    {
      if (!this.IsAuthenticated())
      {
        Debug.Log((object) "Cannot get API client - not authenticated");
        if (callback != null)
        {
          PlayGamesHelperObject.RunOnGameThread((Action) (() => callback(CommonStatusCodes.SignInRequired, (string) null)));
          return;
        }
      }
      this.mTokenClient.SetRationale(this.rationale);
      this.mTokenClient.GetEmail((Action<CommonStatusCodes, string>) ((status, email) => PlayGamesHelperObject.RunOnGameThread((Action) (() => callback(status, email)))));
    }

    [Obsolete("Use GetServerAuthCode() then exchange it for a token")]
    public string GetAccessToken()
    {
      if (!this.IsAuthenticated())
      {
        Debug.Log((object) "Cannot get API client - not authenticated");
        return (string) null;
      }
      if (!GameInfo.WebClientIdInitialized())
      {
        if (this.noWebClientIdWarningCount++ % this.webclientWarningFreq == 0)
        {
          Debug.LogError((object) "Web client ID has not been set, cannot request access token.");
          this.noWebClientIdWarningCount = this.noWebClientIdWarningCount / this.webclientWarningFreq + 1;
        }
        return (string) null;
      }
      this.mTokenClient.SetRationale(this.rationale);
      return this.mTokenClient.GetAccessToken();
    }

    [Obsolete("Use GetServerAuthCode() then exchange it for a token")]
    public void GetIdToken(Action<string> idTokenCallback)
    {
      if (!this.IsAuthenticated())
      {
        Debug.Log((object) "Cannot get API client - not authenticated");
        PlayGamesHelperObject.RunOnGameThread((Action) (() => idTokenCallback((string) null)));
      }
      if (!GameInfo.WebClientIdInitialized())
      {
        if (this.noWebClientIdWarningCount++ % this.webclientWarningFreq == 0)
        {
          Debug.LogError((object) "Web client ID has not been set, cannot request id token.");
          this.noWebClientIdWarningCount = this.noWebClientIdWarningCount / this.webclientWarningFreq + 1;
        }
        PlayGamesHelperObject.RunOnGameThread((Action) (() => idTokenCallback((string) null)));
      }
      this.mTokenClient.SetRationale(this.rationale);
      this.mTokenClient.GetIdToken(string.Empty, NativeClient.AsOnGameThreadCallback<string>(idTokenCallback));
    }

    public void GetServerAuthCode(string serverClientId, Action<CommonStatusCodes, string> callback)
    {
      this.mServices.FetchServerAuthCode(serverClientId, (Action<GooglePlayGames.Native.PInvoke.GameServices.FetchServerAuthCodeResponse>) (serverAuthCodeResponse =>
      {
        CommonStatusCodes responseCode = ConversionUtils.ConvertResponseStatusToCommonStatus(serverAuthCodeResponse.Status());
        if (responseCode != CommonStatusCodes.Success && responseCode != CommonStatusCodes.SuccessCached)
          Logger.e("Error loading server auth code: " + serverAuthCodeResponse.Status().ToString());
        if (callback == null)
          return;
        string authCode = serverAuthCodeResponse.Code();
        PlayGamesHelperObject.RunOnGameThread((Action) (() => callback(responseCode, authCode)));
      }));
    }

    public bool IsAuthenticated()
    {
      lock (this.AuthStateLock)
        return this.mAuthState == NativeClient.AuthState.Authenticated;
    }

    public void LoadFriends(Action<bool> callback)
    {
      if (!this.IsAuthenticated())
      {
        Logger.d("Cannot loadFriends when not authenticated");
        PlayGamesHelperObject.RunOnGameThread((Action) (() => callback(false)));
      }
      else if (this.mFriends != null)
        PlayGamesHelperObject.RunOnGameThread((Action) (() => callback(true)));
      else
        this.mServices.PlayerManager().FetchFriends((Action<GooglePlayGames.BasicApi.ResponseStatus, List<GooglePlayGames.BasicApi.Multiplayer.Player>>) ((status, players) =>
        {
          if (status == GooglePlayGames.BasicApi.ResponseStatus.Success || status == GooglePlayGames.BasicApi.ResponseStatus.SuccessWithStale)
          {
            this.mFriends = players;
            PlayGamesHelperObject.RunOnGameThread((Action) (() => callback(true)));
          }
          else
          {
            this.mFriends = new List<GooglePlayGames.BasicApi.Multiplayer.Player>();
            Logger.e("Got " + (object) status + " loading friends");
            PlayGamesHelperObject.RunOnGameThread((Action) (() => callback(false)));
          }
        }));
    }

    public IUserProfile[] GetFriends()
    {
      if (this.mFriends == null && !this.friendsLoading)
      {
        Logger.w("Getting friends before they are loaded!!!");
        this.friendsLoading = true;
        this.LoadFriends((Action<bool>) (ok =>
        {
          Logger.d("loading: " + (object) ok + " mFriends = " + (object) this.mFriends);
          if (!ok)
            Logger.e("Friends list did not load successfully.  Disabling loading until re-authenticated");
          this.friendsLoading = !ok;
        }));
      }
      return this.mFriends == null ? new IUserProfile[0] : (IUserProfile[]) this.mFriends.ToArray();
    }

    private void PopulateAchievements(
      uint authGeneration,
      GooglePlayGames.Native.PInvoke.AchievementManager.FetchAllResponse response)
    {
      if ((int) authGeneration != (int) this.mAuthGeneration)
      {
        Logger.d("Received achievement callback after signout occurred, ignoring");
      }
      else
      {
        Logger.d("Populating Achievements, status = " + (object) response.Status());
        lock (this.AuthStateLock)
        {
          if (response.Status() != CommonErrorStatus.ResponseStatus.VALID && response.Status() != CommonErrorStatus.ResponseStatus.VALID_BUT_STALE)
          {
            Logger.e("Error retrieving achievements - check the log for more information. Failing signin.");
            Action<bool, string> pendingAuthCallbacks = this.mPendingAuthCallbacks;
            this.mPendingAuthCallbacks = (Action<bool, string>) null;
            if (pendingAuthCallbacks != null)
              NativeClient.InvokeCallbackOnGameThread<bool, string>(pendingAuthCallbacks, false, "Cannot load achievements, Authenication failing");
            this.SignOut();
            return;
          }
          Dictionary<string, GooglePlayGames.BasicApi.Achievement> dictionary = new Dictionary<string, GooglePlayGames.BasicApi.Achievement>();
          foreach (NativeAchievement nativeAchievement in response)
          {
            using (nativeAchievement)
              dictionary[nativeAchievement.Id()] = nativeAchievement.AsAchievement();
          }
          Logger.d("Found " + (object) dictionary.Count + " Achievements");
          this.mAchievements = dictionary;
        }
        Logger.d("Maybe finish for Achievements");
        this.MaybeFinishAuthentication();
      }
    }

    private void MaybeFinishAuthentication()
    {
      Action<bool, string> callback = (Action<bool, string>) null;
      lock (this.AuthStateLock)
      {
        if (this.mUser == null || this.mAchievements == null)
        {
          Logger.d("Auth not finished. User=" + (object) this.mUser + " achievements=" + (object) this.mAchievements);
          return;
        }
        Logger.d("Auth finished. Proceeding.");
        callback = this.mPendingAuthCallbacks;
        this.mPendingAuthCallbacks = (Action<bool, string>) null;
        this.mAuthState = NativeClient.AuthState.Authenticated;
      }
      if (callback == null)
        return;
      Logger.d("Invoking Callbacks: " + (object) callback);
      NativeClient.InvokeCallbackOnGameThread<bool, string>(callback, true, (string) null);
    }

    private void PopulateUser(uint authGeneration, GooglePlayGames.Native.PInvoke.PlayerManager.FetchSelfResponse response)
    {
      Logger.d("Populating User");
      if ((int) authGeneration != (int) this.mAuthGeneration)
      {
        Logger.d("Received user callback after signout occurred, ignoring");
      }
      else
      {
        lock (this.AuthStateLock)
        {
          if (response.Status() != CommonErrorStatus.ResponseStatus.VALID && response.Status() != CommonErrorStatus.ResponseStatus.VALID_BUT_STALE)
          {
            Logger.e("Error retrieving user, signing out");
            Action<bool, string> pendingAuthCallbacks = this.mPendingAuthCallbacks;
            this.mPendingAuthCallbacks = (Action<bool, string>) null;
            if (pendingAuthCallbacks != null)
              NativeClient.InvokeCallbackOnGameThread<bool, string>(pendingAuthCallbacks, false, "Cannot load user profile");
            this.SignOut();
            return;
          }
          this.mUser = response.Self().AsPlayer();
          this.mFriends = (List<GooglePlayGames.BasicApi.Multiplayer.Player>) null;
          this.mTokenClient = this.clientImpl.CreateTokenClient(this.mUser.id, true);
        }
        Logger.d("Found User: " + (object) this.mUser);
        Logger.d("Maybe finish for User");
        this.MaybeFinishAuthentication();
      }
    }

    private void HandleAuthTransition(
      Types.AuthOperation operation,
      CommonErrorStatus.AuthStatus status)
    {
      Logger.d("Starting Auth Transition. Op: " + (object) operation + " status: " + (object) status);
      lock (this.AuthStateLock)
      {
        switch (operation)
        {
          case Types.AuthOperation.SIGN_IN:
            if (status == CommonErrorStatus.AuthStatus.VALID)
            {
              if (this.mSilentAuthCallbacks != null)
              {
                this.mPendingAuthCallbacks += this.mSilentAuthCallbacks;
                this.mSilentAuthCallbacks = (Action<bool, string>) null;
              }
              uint currentAuthGeneration = this.mAuthGeneration;
              this.mServices.AchievementManager().FetchAll((Action<GooglePlayGames.Native.PInvoke.AchievementManager.FetchAllResponse>) (results => this.PopulateAchievements(currentAuthGeneration, results)));
              this.mServices.PlayerManager().FetchSelf((Action<GooglePlayGames.Native.PInvoke.PlayerManager.FetchSelfResponse>) (results => this.PopulateUser(currentAuthGeneration, results)));
              break;
            }
            if (this.mAuthState == NativeClient.AuthState.SilentPending)
            {
              this.mSilentAuthFailed = true;
              this.mAuthState = NativeClient.AuthState.Unauthenticated;
              Action<bool, string> silentAuthCallbacks = this.mSilentAuthCallbacks;
              this.mSilentAuthCallbacks = (Action<bool, string>) null;
              Logger.d("Invoking callbacks, AuthState changed from silentPending to Unauthenticated.");
              NativeClient.InvokeCallbackOnGameThread<bool, string>(silentAuthCallbacks, false, "silent auth failed");
              if (this.mPendingAuthCallbacks == null)
                break;
              Logger.d("there are pending auth callbacks - starting AuthUI");
              this.GameServices().StartAuthorizationUI();
              break;
            }
            Logger.d("AuthState == " + (object) this.mAuthState + " calling auth callbacks with failure");
            this.UnpauseUnityPlayer();
            Action<bool, string> pendingAuthCallbacks = this.mPendingAuthCallbacks;
            this.mPendingAuthCallbacks = (Action<bool, string>) null;
            NativeClient.InvokeCallbackOnGameThread<bool, string>(pendingAuthCallbacks, false, "Authentication failed");
            break;
          case Types.AuthOperation.SIGN_OUT:
            this.ToUnauthenticated();
            break;
          default:
            Logger.e("Unknown AuthOperation " + (object) operation);
            break;
        }
      }
    }

    private void UnpauseUnityPlayer()
    {
    }

    private void ToUnauthenticated()
    {
      lock (this.AuthStateLock)
      {
        this.mUser = (GooglePlayGames.BasicApi.Multiplayer.Player) null;
        this.mFriends = (List<GooglePlayGames.BasicApi.Multiplayer.Player>) null;
        this.mAchievements = (Dictionary<string, GooglePlayGames.BasicApi.Achievement>) null;
        this.mAuthState = NativeClient.AuthState.Unauthenticated;
        this.mTokenClient = this.clientImpl.CreateTokenClient((string) null, true);
        ++this.mAuthGeneration;
      }
    }

    public void SignOut()
    {
      this.ToUnauthenticated();
      if (this.GameServices() == null)
        return;
      this.GameServices().SignOut();
    }

    public string GetUserId() => this.mUser == null ? (string) null : this.mUser.id;

    public string GetUserDisplayName() => this.mUser == null ? (string) null : this.mUser.userName;

    public string GetUserImageUrl() => this.mUser == null ? (string) null : this.mUser.AvatarURL;

    public void GetPlayerStats(Action<CommonStatusCodes, GooglePlayGames.BasicApi.PlayerStats> callback)
    {
      PlayGamesHelperObject.RunOnGameThread((Action) (() => this.clientImpl.GetPlayerStats(this.GetApiClient(), callback)));
    }

    public void LoadUsers(string[] userIds, Action<IUserProfile[]> callback)
    {
      this.mServices.PlayerManager().FetchList(userIds, (Action<NativePlayer[]>) (nativeUsers =>
      {
        IUserProfile[] users = new IUserProfile[nativeUsers.Length];
        for (int index = 0; index < users.Length; ++index)
          users[index] = (IUserProfile) nativeUsers[index].AsPlayer();
        PlayGamesHelperObject.RunOnGameThread((Action) (() => callback(users)));
      }));
    }

    public GooglePlayGames.BasicApi.Achievement GetAchievement(string achId)
    {
      return this.mAchievements == null || !this.mAchievements.ContainsKey(achId) ? (GooglePlayGames.BasicApi.Achievement) null : this.mAchievements[achId];
    }

    public void LoadAchievements(Action<GooglePlayGames.BasicApi.Achievement[]> callback)
    {
      GooglePlayGames.BasicApi.Achievement[] data = new GooglePlayGames.BasicApi.Achievement[this.mAchievements.Count];
      this.mAchievements.Values.CopyTo(data, 0);
      PlayGamesHelperObject.RunOnGameThread((Action) (() => callback(data)));
    }

    public void UnlockAchievement(string achId, Action<bool> callback)
    {
      this.UpdateAchievement("Unlock", achId, callback, (Predicate<GooglePlayGames.BasicApi.Achievement>) (a => a.IsUnlocked), (Action<GooglePlayGames.BasicApi.Achievement>) (a =>
      {
        a.IsUnlocked = true;
        this.GameServices().AchievementManager().Unlock(achId);
      }));
    }

    public void RevealAchievement(string achId, Action<bool> callback)
    {
      this.UpdateAchievement("Reveal", achId, callback, (Predicate<GooglePlayGames.BasicApi.Achievement>) (a => a.IsRevealed), (Action<GooglePlayGames.BasicApi.Achievement>) (a =>
      {
        a.IsRevealed = true;
        this.GameServices().AchievementManager().Reveal(achId);
      }));
    }

    private void UpdateAchievement(
      string updateType,
      string achId,
      Action<bool> callback,
      Predicate<GooglePlayGames.BasicApi.Achievement> alreadyDone,
      Action<GooglePlayGames.BasicApi.Achievement> updateAchievment)
    {
      callback = NativeClient.AsOnGameThreadCallback<bool>(callback);
      Misc.CheckNotNull<string>(achId);
      this.InitializeGameServices();
      GooglePlayGames.BasicApi.Achievement achievement = this.GetAchievement(achId);
      if (achievement == null)
      {
        Logger.d("Could not " + updateType + ", no achievement with ID " + achId);
        callback(false);
      }
      else if (alreadyDone(achievement))
      {
        Logger.d("Did not need to perform " + updateType + ": on achievement " + achId);
        callback(true);
      }
      else
      {
        Logger.d("Performing " + updateType + " on " + achId);
        updateAchievment(achievement);
        this.GameServices().AchievementManager().Fetch(achId, (Action<GooglePlayGames.Native.PInvoke.AchievementManager.FetchResponse>) (rsp =>
        {
          if (rsp.Status() == CommonErrorStatus.ResponseStatus.VALID)
          {
            this.mAchievements.Remove(achId);
            this.mAchievements.Add(achId, rsp.Achievement().AsAchievement());
            callback(true);
          }
          else
          {
            Logger.e("Cannot refresh achievement " + achId + ": " + (object) rsp.Status());
            callback(false);
          }
        }));
      }
    }

    public void IncrementAchievement(string achId, int steps, Action<bool> callback)
    {
      Misc.CheckNotNull<string>(achId);
      callback = NativeClient.AsOnGameThreadCallback<bool>(callback);
      this.InitializeGameServices();
      GooglePlayGames.BasicApi.Achievement achievement = this.GetAchievement(achId);
      if (achievement == null)
      {
        Logger.e("Could not increment, no achievement with ID " + achId);
        callback(false);
      }
      else if (!achievement.IsIncremental)
      {
        Logger.e("Could not increment, achievement with ID " + achId + " was not incremental");
        callback(false);
      }
      else if (steps < 0)
      {
        Logger.e("Attempted to increment by negative steps");
        callback(false);
      }
      else
      {
        this.GameServices().AchievementManager().Increment(achId, Convert.ToUInt32(steps));
        this.GameServices().AchievementManager().Fetch(achId, (Action<GooglePlayGames.Native.PInvoke.AchievementManager.FetchResponse>) (rsp =>
        {
          if (rsp.Status() == CommonErrorStatus.ResponseStatus.VALID)
          {
            this.mAchievements.Remove(achId);
            this.mAchievements.Add(achId, rsp.Achievement().AsAchievement());
            callback(true);
          }
          else
          {
            Logger.e("Cannot refresh achievement " + achId + ": " + (object) rsp.Status());
            callback(false);
          }
        }));
      }
    }

    public void SetStepsAtLeast(string achId, int steps, Action<bool> callback)
    {
      Misc.CheckNotNull<string>(achId);
      callback = NativeClient.AsOnGameThreadCallback<bool>(callback);
      this.InitializeGameServices();
      GooglePlayGames.BasicApi.Achievement achievement = this.GetAchievement(achId);
      if (achievement == null)
      {
        Logger.e("Could not increment, no achievement with ID " + achId);
        callback(false);
      }
      else if (!achievement.IsIncremental)
      {
        Logger.e("Could not increment, achievement with ID " + achId + " is not incremental");
        callback(false);
      }
      else if (steps < 0)
      {
        Logger.e("Attempted to increment by negative steps");
        callback(false);
      }
      else
      {
        this.GameServices().AchievementManager().SetStepsAtLeast(achId, Convert.ToUInt32(steps));
        this.GameServices().AchievementManager().Fetch(achId, (Action<GooglePlayGames.Native.PInvoke.AchievementManager.FetchResponse>) (rsp =>
        {
          if (rsp.Status() == CommonErrorStatus.ResponseStatus.VALID)
          {
            this.mAchievements.Remove(achId);
            this.mAchievements.Add(achId, rsp.Achievement().AsAchievement());
            callback(true);
          }
          else
          {
            Logger.e("Cannot refresh achievement " + achId + ": " + (object) rsp.Status());
            callback(false);
          }
        }));
      }
    }

    public void ShowAchievementsUI(Action<GooglePlayGames.BasicApi.UIStatus> cb)
    {
      if (!this.IsAuthenticated())
        return;
      Action<CommonErrorStatus.UIStatus> callback1 = Callbacks.NoopUICallback;
      if (cb != null)
        callback1 = (Action<CommonErrorStatus.UIStatus>) (result => cb((GooglePlayGames.BasicApi.UIStatus) result));
      Action<CommonErrorStatus.UIStatus> callback2 = NativeClient.AsOnGameThreadCallback<CommonErrorStatus.UIStatus>(callback1);
      this.GameServices().AchievementManager().ShowAllUI(callback2);
    }

    public int LeaderboardMaxResults()
    {
      return this.GameServices().LeaderboardManager().LeaderboardMaxResults;
    }

    public void ShowLeaderboardUI(
      string leaderboardId,
      GooglePlayGames.BasicApi.LeaderboardTimeSpan span,
      Action<GooglePlayGames.BasicApi.UIStatus> cb)
    {
      if (!this.IsAuthenticated())
        return;
      Action<CommonErrorStatus.UIStatus> callback1 = Callbacks.NoopUICallback;
      if (cb != null)
        callback1 = (Action<CommonErrorStatus.UIStatus>) (result => cb((GooglePlayGames.BasicApi.UIStatus) result));
      Action<CommonErrorStatus.UIStatus> callback2 = NativeClient.AsOnGameThreadCallback<CommonErrorStatus.UIStatus>(callback1);
      if (leaderboardId == null)
        this.GameServices().LeaderboardManager().ShowAllUI(callback2);
      else
        this.GameServices().LeaderboardManager().ShowUI(leaderboardId, span, callback2);
    }

    public void LoadScores(
      string leaderboardId,
      GooglePlayGames.BasicApi.LeaderboardStart start,
      int rowCount,
      GooglePlayGames.BasicApi.LeaderboardCollection collection,
      GooglePlayGames.BasicApi.LeaderboardTimeSpan timeSpan,
      Action<LeaderboardScoreData> callback)
    {
      callback = NativeClient.AsOnGameThreadCallback<LeaderboardScoreData>(callback);
      this.GameServices().LeaderboardManager().LoadLeaderboardData(leaderboardId, start, rowCount, collection, timeSpan, this.mUser.id, callback);
    }

    public void LoadMoreScores(
      ScorePageToken token,
      int rowCount,
      Action<LeaderboardScoreData> callback)
    {
      callback = NativeClient.AsOnGameThreadCallback<LeaderboardScoreData>(callback);
      this.GameServices().LeaderboardManager().LoadScorePage((LeaderboardScoreData) null, rowCount, token, callback);
    }

    public void SubmitScore(string leaderboardId, long score, Action<bool> callback)
    {
      callback = NativeClient.AsOnGameThreadCallback<bool>(callback);
      if (!this.IsAuthenticated())
        callback(false);
      this.InitializeGameServices();
      if (leaderboardId == null)
        throw new ArgumentNullException(nameof (leaderboardId));
      this.GameServices().LeaderboardManager().SubmitScore(leaderboardId, score, (string) null);
      callback(true);
    }

    public void SubmitScore(
      string leaderboardId,
      long score,
      string metadata,
      Action<bool> callback)
    {
      callback = NativeClient.AsOnGameThreadCallback<bool>(callback);
      if (!this.IsAuthenticated())
        callback(false);
      this.InitializeGameServices();
      if (leaderboardId == null)
        throw new ArgumentNullException(nameof (leaderboardId));
      this.GameServices().LeaderboardManager().SubmitScore(leaderboardId, score, metadata);
      callback(true);
    }

    public IRealTimeMultiplayerClient GetRtmpClient()
    {
      if (!this.IsAuthenticated())
        return (IRealTimeMultiplayerClient) null;
      lock (this.GameServicesLock)
        return (IRealTimeMultiplayerClient) this.mRealTimeClient;
    }

    public ITurnBasedMultiplayerClient GetTbmpClient()
    {
      lock (this.GameServicesLock)
        return (ITurnBasedMultiplayerClient) this.mTurnBasedClient;
    }

    public ISavedGameClient GetSavedGameClient()
    {
      lock (this.GameServicesLock)
        return this.mSavedGameClient;
    }

    public IEventsClient GetEventsClient()
    {
      lock (this.GameServicesLock)
        return this.mEventsClient;
    }

    public IQuestsClient GetQuestsClient()
    {
      lock (this.GameServicesLock)
        return this.mQuestsClient;
    }

    public void RegisterInvitationDelegate(InvitationReceivedDelegate invitationDelegate)
    {
      if (invitationDelegate == null)
        this.mInvitationDelegate = (Action<Invitation, bool>) null;
      else
        this.mInvitationDelegate = Callbacks.AsOnGameThreadCallback<Invitation, bool>((Action<Invitation, bool>) ((invitation, autoAccept) => invitationDelegate(invitation, autoAccept)));
    }

    public string GetToken()
    {
      return this.mTokenClient != null ? this.mTokenClient.GetAccessToken() : (string) null;
    }

    public IntPtr GetApiClient()
    {
      return InternalHooks.InternalHooks_GetApiClient(this.mServices.AsHandle());
    }

    private enum AuthState
    {
      Unauthenticated,
      Authenticated,
      SilentPending,
    }
  }
}
