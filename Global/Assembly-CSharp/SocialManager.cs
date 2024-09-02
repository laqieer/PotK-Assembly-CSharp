// Decompiled with JetBrains decompiler
// Type: SocialManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GooglePlayGames;
using gu3.Device;
using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;
using UnityEngine.SocialPlatforms;

#nullable disable
public class SocialManager : Singleton<SocialManager>
{
  private List<IAchievementDescription> _achieveDescriptions;
  private List<IScore> _scores;

  [SerializeField]
  public bool isLogin
  {
    get
    {
      if (Social.localUser != null)
        return Social.localUser.authenticated;
      Debug.LogWarning((object) "ログインしてません！");
      return false;
    }
  }

  protected override void Initialize()
  {
    if (!Persist.firstPGSSignIn.Exists)
    {
      Persist.firstPGSSignIn.Data.SetFlag(false);
      Persist.firstPGSSignIn.Flush();
      this.Auth((Action<bool>) null);
    }
    else
    {
      if (!Persist.firstPGSSignIn.Data.Flag())
        return;
      this.Auth((Action<bool>) null);
    }
  }

  public void Auth(Action<bool> callback)
  {
    if (this.isLogin)
      return;
    Debug.Log((object) ("端末モデル = {" + SystemInfo.deviceModel + "}"));
    Debug.Log((object) ("端末名 = {" + SystemInfo.deviceName + "}"));
    Debug.Log((object) ("端末型 = {" + (object) SystemInfo.deviceType + "}"));
    Debug.Log((object) ("OSVersion = {" + (object) DeviceManager.GetOSVersion() + "}"));
    if (SystemInfo.deviceModel == "samsung SC-03E" && (double) DeviceManager.GetOSVersion() == 18.0)
      return;
    PlayGamesPlatform.Activate();
    callback += new Action<bool>(this.HandleAuthentication);
    Social.localUser.Authenticate(callback);
  }

  private void HandleAuthentication(bool success)
  {
    if (success)
    {
      this.LoadAchievementDescriptions();
      Persist.firstPGSSignIn.Data.SetFlag();
    }
    else
      Persist.firstPGSSignIn.Data.SetFlag(false);
    Persist.firstPGSSignIn.Flush();
    Debug.Log((object) ("User is autehnticated '" + (object) success + "'"));
  }

  public void LoadAchievementDescriptions(Action<IAchievementDescription[]> callback)
  {
    if (!this.isLogin)
      return;
    Social.LoadAchievementDescriptions(callback);
  }

  public void LoadAchievementDescriptions()
  {
    if (!this.isLogin)
      return;
    Social.LoadAchievementDescriptions((Action<IAchievementDescription[]>) (achieveDescriptions =>
    {
      if (this._achieveDescriptions != null)
        this._achieveDescriptions.Clear();
      this._achieveDescriptions = (List<IAchievementDescription>) null;
      this._achieveDescriptions = ((IEnumerable<IAchievementDescription>) achieveDescriptions).ToList<IAchievementDescription>();
    }));
  }

  public void LoadScores(string board, Action<IScore[]> callback)
  {
    if (!this.isLogin)
      return;
    Social.LoadScores(board, callback);
  }

  public void LoadScores(string board)
  {
    if (!this.isLogin)
      return;
    Social.LoadScores(board, (Action<IScore[]>) (score =>
    {
      if (this._scores != null)
        this._scores.Clear();
      this._scores = (List<IScore>) null;
      this._scores = ((IEnumerable<IScore>) score).ToList<IScore>();
    }));
  }

  public void ReportProgress(string achievementID, double progress, Action<bool> callback)
  {
    if (!this.isLogin)
      return;
    Social.ReportProgress(achievementID, progress, callback);
  }

  public void ReportProgress(string achievementID, double progress)
  {
    if (!this.isLogin)
      return;
    Social.ReportProgress(achievementID, progress, (Action<bool>) (success => this.LoadAchievementDescriptions()));
  }

  public void ShowAchievementsUI()
  {
    if (this.isLogin)
      Social.ShowAchievementsUI();
    else
      this.Auth((Action<bool>) (success =>
      {
        if (!success)
          return;
        this.ShowAchievementsUI();
      }));
  }

  public void ReportScore(long score, string board, Action<bool> callback)
  {
    if (!this.isLogin)
      return;
    Social.ReportScore(score, board, callback);
  }

  public void ReportScore(long score, string board)
  {
    if (!this.isLogin)
      return;
    Social.ReportScore(score, board, (Action<bool>) (success => this.LoadScores(board)));
  }

  public void ShowLeaderboardUI()
  {
    if (this.isLogin)
      Social.ShowLeaderboardUI();
    else
      this.Auth((Action<bool>) (success =>
      {
        if (!success)
          return;
        this.ShowLeaderboardUI();
      }));
  }
}
