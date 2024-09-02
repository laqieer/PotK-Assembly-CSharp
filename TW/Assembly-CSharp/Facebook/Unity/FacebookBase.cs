// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.FacebookBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Facebook.Unity
{
  internal abstract class FacebookBase : IFacebook, IFacebookCallbackHandler, IFacebookImplementation
  {
    private InitDelegate onInitCompleteDelegate;
    private HideUnityDelegate onHideUnityDelegate;

    protected FacebookBase(CallbackManager callbackManager)
    {
      this.CallbackManager = callbackManager;
    }

    public abstract bool LimitEventUsage { get; set; }

    public abstract string FacebookSdkVersion { get; }

    public bool LoggedIn => AccessToken.CurrentAccessToken != null;

    protected CallbackManager CallbackManager { get; private set; }

    public virtual void Init(
      string appId,
      bool cookie,
      bool logging,
      bool status,
      bool xfbml,
      string channelUrl,
      string authResponse,
      bool frictionlessRequests,
      HideUnityDelegate hideUnityDelegate,
      InitDelegate onInitComplete)
    {
      this.onHideUnityDelegate = hideUnityDelegate;
      this.onInitCompleteDelegate = onInitComplete;
    }

    public abstract void LogInWithPublishPermissions(
      IEnumerable<string> scope,
      FacebookDelegate<ILoginResult> callback);

    public abstract void LogInWithReadPermissions(
      IEnumerable<string> scope,
      FacebookDelegate<ILoginResult> callback);

    public virtual void LogOut() => AccessToken.CurrentAccessToken = (AccessToken) null;

    public void AppRequest(
      string message,
      IEnumerable<string> to = null,
      IEnumerable<object> filters = null,
      IEnumerable<string> excludeIds = null,
      int? maxRecipients = null,
      string data = "",
      string title = "",
      FacebookDelegate<IAppRequestResult> callback = null)
    {
      this.AppRequest(message, new OGActionType?(), (string) null, to, filters, excludeIds, maxRecipients, data, title, callback);
    }

    public abstract void AppRequest(
      string message,
      OGActionType? actionType,
      string objectId,
      IEnumerable<string> to,
      IEnumerable<object> filters,
      IEnumerable<string> excludeIds,
      int? maxRecipients,
      string data,
      string title,
      FacebookDelegate<IAppRequestResult> callback);

    public abstract void ShareLink(
      Uri contentURL,
      string contentTitle,
      string contentDescription,
      Uri photoURL,
      FacebookDelegate<IShareResult> callback);

    public abstract void FeedShare(
      string toId,
      Uri link,
      string linkName,
      string linkCaption,
      string linkDescription,
      Uri picture,
      string mediaSource,
      FacebookDelegate<IShareResult> callback);

    public void API(
      string query,
      HttpMethod method,
      IDictionary<string, string> formData,
      FacebookDelegate<IGraphResult> callback)
    {
      IDictionary<string, string> formData1 = formData == null ? (IDictionary<string, string>) new Dictionary<string, string>() : this.CopyByValue(formData);
      if (!formData1.ContainsKey("access_token") && !query.Contains("access_token="))
        formData1["access_token"] = !FB.IsLoggedIn ? string.Empty : AccessToken.CurrentAccessToken.TokenString;
      AsyncRequestString.Request(this.GetGraphUrl(query), method, formData1, callback);
    }

    public void API(
      string query,
      HttpMethod method,
      WWWForm formData,
      FacebookDelegate<IGraphResult> callback)
    {
      if (formData == null)
        formData = new WWWForm();
      string str = AccessToken.CurrentAccessToken == null ? string.Empty : AccessToken.CurrentAccessToken.TokenString;
      formData.AddField("access_token", str);
      AsyncRequestString.Request(this.GetGraphUrl(query), method, formData, callback);
    }

    public abstract void GameGroupCreate(
      string name,
      string description,
      string privacy,
      FacebookDelegate<IGroupCreateResult> callback);

    public abstract void GameGroupJoin(string id, FacebookDelegate<IGroupJoinResult> callback);

    public abstract void ActivateApp(string appId = null);

    public abstract void GetAppLink(FacebookDelegate<IAppLinkResult> callback);

    public abstract void AppEventsLogEvent(
      string logEvent,
      float? valueToSum,
      Dictionary<string, object> parameters);

    public abstract void AppEventsLogPurchase(
      float logPurchase,
      string currency,
      Dictionary<string, object> parameters);

    public virtual void OnHideUnity(bool isGameShown)
    {
      if (this.onHideUnityDelegate == null)
        return;
      this.onHideUnityDelegate(isGameShown);
    }

    public virtual void OnInitComplete(string message)
    {
      this.OnLoginComplete(message);
      if (this.onInitCompleteDelegate == null)
        return;
      this.onInitCompleteDelegate();
    }

    public abstract void OnLoginComplete(string message);

    public void OnLogoutComplete(string message)
    {
      AccessToken.CurrentAccessToken = (AccessToken) null;
    }

    public abstract void OnGetAppLinkComplete(string message);

    public abstract void OnGroupCreateComplete(string message);

    public abstract void OnGroupJoinComplete(string message);

    public abstract void OnAppRequestsComplete(string message);

    public abstract void OnShareLinkComplete(string message);

    protected void ValidateAppRequestArgs(
      string message,
      OGActionType? actionType,
      string objectId,
      IEnumerable<string> to = null,
      IEnumerable<object> filters = null,
      IEnumerable<string> excludeIds = null,
      int? maxRecipients = null,
      string data = "",
      string title = "",
      FacebookDelegate<IAppRequestResult> callback = null)
    {
      if (string.IsNullOrEmpty(message))
        throw new ArgumentNullException(nameof (message), "message cannot be null or empty!");
      if (!string.IsNullOrEmpty(objectId) && (actionType.GetValueOrDefault() != OGActionType.ASKFOR ? 0 : (actionType.HasValue ? 1 : 0)) == 0 && (actionType.GetValueOrDefault() != OGActionType.SEND ? 0 : (actionType.HasValue ? 1 : 0)) == 0)
        throw new ArgumentNullException(nameof (objectId), "Object ID must be set if and only if action type is SEND or ASKFOR");
      if (!actionType.HasValue && !string.IsNullOrEmpty(objectId))
        throw new ArgumentNullException(nameof (actionType), "You cannot provide an objectId without an actionType");
    }

    protected void OnAuthResponse(LoginResult result)
    {
      if (result.AccessToken != null)
        AccessToken.CurrentAccessToken = result.AccessToken;
      this.CallbackManager.OnFacebookResponse((IInternalResult) result);
    }

    private IDictionary<string, string> CopyByValue(IDictionary<string, string> data)
    {
      Dictionary<string, string> dictionary = new Dictionary<string, string>(data.Count);
      foreach (KeyValuePair<string, string> keyValuePair in (IEnumerable<KeyValuePair<string, string>>) data)
        dictionary[keyValuePair.Key] = string.Copy(keyValuePair.Value);
      return (IDictionary<string, string>) dictionary;
    }

    private string GetGraphUrl(string query)
    {
      if (!query.StartsWith("/"))
        query = "/" + query;
      return "https://graph.facebook.com" + query;
    }
  }
}
