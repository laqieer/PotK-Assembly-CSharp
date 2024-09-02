// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Mobile.Android.AndroidFacebook
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace Facebook.Unity.Mobile.Android
{
  internal sealed class AndroidFacebook : MobileFacebook
  {
    private bool limitEventUsage;
    private IAndroidJavaClass facebookJava;

    public AndroidFacebook()
      : this((IAndroidJavaClass) new FBJavaClass(), new CallbackManager())
    {
    }

    public AndroidFacebook(IAndroidJavaClass facebookJavaClass, CallbackManager callbackManager)
      : base(callbackManager)
    {
      this.KeyHash = string.Empty;
      this.facebookJava = facebookJavaClass;
    }

    public string KeyHash { get; private set; }

    public override bool LimitEventUsage
    {
      get => this.limitEventUsage;
      set
      {
        this.limitEventUsage = value;
        this.CallFB("SetLimitEventUsage", value.ToString());
      }
    }

    public override string FacebookSdkVersion
    {
      get
      {
        return string.Format("Facebook.Android.SDK.{0}", (object) this.facebookJava.CallStatic<string>("GetSdkVersion"));
      }
    }

    public override void Init(
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
      base.Init(appId, cookie, logging, status, xfbml, channelUrl, authResponse, frictionlessRequests, hideUnityDelegate, onInitComplete);
      MethodArguments args = new MethodArguments();
      args.AddString(nameof (appId), appId);
      args.AddPrimative<bool>(nameof (cookie), cookie);
      args.AddPrimative<bool>(nameof (logging), logging);
      args.AddPrimative<bool>(nameof (status), status);
      args.AddPrimative<bool>(nameof (xfbml), xfbml);
      args.AddString(nameof (channelUrl), channelUrl);
      args.AddString(nameof (authResponse), authResponse);
      args.AddPrimative<bool>(nameof (frictionlessRequests), frictionlessRequests);
      new AndroidFacebook.JavaMethodCall<IResult>(this, nameof (Init)).Call(args);
      this.CallFB("SetUserAgentSuffix", string.Format("Unity.{0}", (object) Facebook.Unity.FacebookSdkVersion.Build));
    }

    public override void LogInWithReadPermissions(
      IEnumerable<string> permissions,
      FacebookDelegate<ILoginResult> callback)
    {
      MethodArguments args = new MethodArguments();
      args.AddCommaSeparatedList("scope", permissions);
      AndroidFacebook.JavaMethodCall<ILoginResult> javaMethodCall = new AndroidFacebook.JavaMethodCall<ILoginResult>(this, "LoginWithReadPermissions");
      javaMethodCall.Callback = callback;
      javaMethodCall.Call(args);
    }

    public override void LogInWithPublishPermissions(
      IEnumerable<string> permissions,
      FacebookDelegate<ILoginResult> callback)
    {
      MethodArguments args = new MethodArguments();
      args.AddCommaSeparatedList("scope", permissions);
      AndroidFacebook.JavaMethodCall<ILoginResult> javaMethodCall = new AndroidFacebook.JavaMethodCall<ILoginResult>(this, "LoginWithPublishPermissions");
      javaMethodCall.Callback = callback;
      javaMethodCall.Call(args);
    }

    public override void LogOut()
    {
      new AndroidFacebook.JavaMethodCall<IResult>(this, "Logout").Call((MethodArguments) null);
    }

    public override void AppRequest(
      string message,
      OGActionType? actionType,
      string objectId,
      IEnumerable<string> to,
      IEnumerable<object> filters,
      IEnumerable<string> excludeIds,
      int? maxRecipients,
      string data,
      string title,
      FacebookDelegate<IAppRequestResult> callback)
    {
      this.ValidateAppRequestArgs(message, actionType, objectId, to, filters, excludeIds, maxRecipients, data, title, callback);
      MethodArguments args = new MethodArguments();
      args.AddString(nameof (message), message);
      args.AddNullablePrimitive<OGActionType>("action_type", actionType);
      args.AddString("object_id", objectId);
      args.AddCommaSeparatedList(nameof (to), to);
      if (filters != null && filters.Any<object>() && filters.First<object>() is string str)
        args.AddString(nameof (filters), str);
      args.AddNullablePrimitive<int>("max_recipients", maxRecipients);
      args.AddString(nameof (data), data);
      args.AddString(nameof (title), title);
      AndroidFacebook.JavaMethodCall<IAppRequestResult> javaMethodCall = new AndroidFacebook.JavaMethodCall<IAppRequestResult>(this, nameof (AppRequest));
      javaMethodCall.Callback = callback;
      javaMethodCall.Call(args);
    }

    public override void AppInvite(
      Uri appLinkUrl,
      Uri previewImageUrl,
      FacebookDelegate<IAppInviteResult> callback)
    {
      MethodArguments args = new MethodArguments();
      args.AddUri(nameof (appLinkUrl), appLinkUrl);
      args.AddUri(nameof (previewImageUrl), previewImageUrl);
      AndroidFacebook.JavaMethodCall<IAppInviteResult> javaMethodCall = new AndroidFacebook.JavaMethodCall<IAppInviteResult>(this, nameof (AppInvite));
      javaMethodCall.Callback = callback;
      javaMethodCall.Call(args);
    }

    public override void ShareLink(
      Uri contentURL,
      string contentTitle,
      string contentDescription,
      Uri photoURL,
      FacebookDelegate<IShareResult> callback)
    {
      MethodArguments args = new MethodArguments();
      args.AddUri("content_url", contentURL);
      args.AddString("content_title", contentTitle);
      args.AddString("content_description", contentDescription);
      args.AddUri("photo_url", photoURL);
      AndroidFacebook.JavaMethodCall<IShareResult> javaMethodCall = new AndroidFacebook.JavaMethodCall<IShareResult>(this, nameof (ShareLink));
      javaMethodCall.Callback = callback;
      javaMethodCall.Call(args);
    }

    public override void FeedShare(
      string toId,
      Uri link,
      string linkName,
      string linkCaption,
      string linkDescription,
      Uri picture,
      string mediaSource,
      FacebookDelegate<IShareResult> callback)
    {
      MethodArguments args = new MethodArguments();
      args.AddString(nameof (toId), toId);
      args.AddUri(nameof (link), link);
      args.AddString(nameof (linkName), linkName);
      args.AddString(nameof (linkCaption), linkCaption);
      args.AddString(nameof (linkDescription), linkDescription);
      args.AddUri(nameof (picture), picture);
      args.AddString(nameof (mediaSource), mediaSource);
      AndroidFacebook.JavaMethodCall<IShareResult> javaMethodCall = new AndroidFacebook.JavaMethodCall<IShareResult>(this, nameof (FeedShare));
      javaMethodCall.Callback = callback;
      javaMethodCall.Call(args);
    }

    public override void GameGroupCreate(
      string name,
      string description,
      string privacy,
      FacebookDelegate<IGroupCreateResult> callback)
    {
      MethodArguments args = new MethodArguments();
      args.AddString(nameof (name), name);
      args.AddString(nameof (description), description);
      args.AddString(nameof (privacy), privacy);
      AndroidFacebook.JavaMethodCall<IGroupCreateResult> javaMethodCall = new AndroidFacebook.JavaMethodCall<IGroupCreateResult>(this, nameof (GameGroupCreate));
      javaMethodCall.Callback = callback;
      javaMethodCall.Call(args);
    }

    public override void GameGroupJoin(string id, FacebookDelegate<IGroupJoinResult> callback)
    {
      MethodArguments args = new MethodArguments();
      args.AddString(nameof (id), id);
      AndroidFacebook.JavaMethodCall<IGroupJoinResult> javaMethodCall = new AndroidFacebook.JavaMethodCall<IGroupJoinResult>(this, nameof (GameGroupJoin));
      javaMethodCall.Callback = callback;
      javaMethodCall.Call(args);
    }

    public override void GetAppLink(FacebookDelegate<IAppLinkResult> callback)
    {
      AndroidFacebook.JavaMethodCall<IAppLinkResult> javaMethodCall = new AndroidFacebook.JavaMethodCall<IAppLinkResult>(this, nameof (GetAppLink));
      javaMethodCall.Callback = callback;
      javaMethodCall.Call((MethodArguments) null);
    }

    public override void AppEventsLogEvent(
      string logEvent,
      float? valueToSum,
      Dictionary<string, object> parameters)
    {
      MethodArguments args = new MethodArguments();
      args.AddString(nameof (logEvent), logEvent);
      args.AddNullablePrimitive<float>(nameof (valueToSum), valueToSum);
      args.AddDictionary(nameof (parameters), (IDictionary<string, object>) parameters);
      new AndroidFacebook.JavaMethodCall<IResult>(this, "AppEvents").Call(args);
    }

    public override void AppEventsLogPurchase(
      float logPurchase,
      string currency,
      Dictionary<string, object> parameters)
    {
      MethodArguments args = new MethodArguments();
      args.AddPrimative<float>(nameof (logPurchase), logPurchase);
      args.AddString(nameof (currency), currency);
      args.AddDictionary(nameof (parameters), (IDictionary<string, object>) parameters);
      new AndroidFacebook.JavaMethodCall<IResult>(this, "AppEvents").Call(args);
    }

    public override void ActivateApp(string appId)
    {
      MethodArguments args = new MethodArguments();
      args.AddString("app_id", appId);
      new AndroidFacebook.JavaMethodCall<IResult>(this, nameof (ActivateApp)).Call(args);
    }

    public override void FetchDeferredAppLink(FacebookDelegate<IAppLinkResult> callback)
    {
      MethodArguments args = new MethodArguments();
      AndroidFacebook.JavaMethodCall<IAppLinkResult> javaMethodCall = new AndroidFacebook.JavaMethodCall<IAppLinkResult>(this, "FetchDeferredAppLinkData");
      javaMethodCall.Callback = callback;
      javaMethodCall.Call(args);
    }

    protected override void SetShareDialogMode(ShareDialogMode mode)
    {
      this.CallFB(nameof (SetShareDialogMode), mode.ToString());
    }

    private void CallFB(string method, string args)
    {
      this.facebookJava.CallStatic(method, (object) args);
    }

    private class JavaMethodCall<T> : MethodCall<T> where T : IResult
    {
      private AndroidFacebook androidImpl;

      public JavaMethodCall(AndroidFacebook androidImpl, string methodName)
        : base((FacebookBase) androidImpl, methodName)
      {
        this.androidImpl = androidImpl;
      }

      public override void Call(MethodArguments args = null)
      {
        MethodArguments methodArguments = args != null ? new MethodArguments(args) : new MethodArguments();
        if (this.Callback != null)
          methodArguments.AddString("callback_id", this.androidImpl.CallbackManager.AddFacebookDelegate<T>(this.Callback));
        this.androidImpl.CallFB(this.MethodName, methodArguments.ToJsonString());
      }
    }
  }
}
