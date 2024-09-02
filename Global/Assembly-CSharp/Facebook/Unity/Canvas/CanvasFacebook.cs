// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Canvas.CanvasFacebook
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using Facebook.MiniJSON;
using System;
using System.Collections.Generic;
using System.Globalization;

#nullable disable
namespace Facebook.Unity.Canvas
{
  internal sealed class CanvasFacebook : 
    FacebookBase,
    ICanvasFacebook,
    ICanvasFacebookImplementation,
    ICanvasFacebookResultHandler,
    IFacebook,
    IFacebookResultHandler,
    IPayFacebook
  {
    internal const string MethodAppRequests = "apprequests";
    internal const string MethodFeed = "feed";
    internal const string MethodPay = "pay";
    internal const string MethodGameGroupCreate = "game_group_create";
    internal const string MethodGameGroupJoin = "game_group_join";
    internal const string CancelledResponse = "{\"cancelled\":true}";
    internal const string FacebookConnectURL = "https://connect.facebook.net";
    private const string AuthResponseKey = "authResponse";
    private string appId;
    private string appLinkUrl;
    private ICanvasJSWrapper canvasJSWrapper;

    public CanvasFacebook()
      : this((ICanvasJSWrapper) new CanvasJSWrapper(), new CallbackManager())
    {
    }

    public CanvasFacebook(ICanvasJSWrapper canvasJSWrapper, CallbackManager callbackManager)
      : base(callbackManager)
    {
      this.canvasJSWrapper = canvasJSWrapper;
    }

    public override bool LimitEventUsage { get; set; }

    public override string SDKName => "FBJSSDK";

    public override string SDKVersion => this.canvasJSWrapper.GetSDKVersion();

    public override string SDKUserAgent
    {
      get
      {
        string productName;
        switch (Constants.CurrentPlatform)
        {
          case FacebookUnityPlatform.WebGL:
          case FacebookUnityPlatform.WebPlayer:
            productName = string.Format((IFormatProvider) CultureInfo.InvariantCulture, "FBUnity{0}", new object[1]
            {
              (object) Constants.CurrentPlatform.ToString()
            });
            break;
          default:
            FacebookLogger.Warn("Currently running on uknown web platform");
            productName = "FBUnityWebUnknown";
            break;
        }
        return string.Format((IFormatProvider) CultureInfo.InvariantCulture, "{0} {1}", new object[2]
        {
          (object) base.SDKUserAgent,
          (object) Utilities.GetUserAgent(productName, FacebookSdkVersion.Build)
        });
      }
    }

    public void Init(
      string appId,
      bool cookie,
      bool logging,
      bool status,
      bool xfbml,
      string channelUrl,
      string authResponse,
      bool frictionlessRequests,
      string javascriptSDKLocale,
      HideUnityDelegate hideUnityDelegate,
      InitDelegate onInitComplete)
    {
      if (this.canvasJSWrapper.IntegrationMethodJs == null)
        throw new Exception("Cannot initialize facebook javascript");
      this.Init(hideUnityDelegate, onInitComplete);
      this.canvasJSWrapper.ExternalEval(this.canvasJSWrapper.IntegrationMethodJs);
      this.appId = appId;
      bool flag = true;
      MethodArguments methodArguments = new MethodArguments();
      methodArguments.AddString(nameof (appId), appId);
      methodArguments.AddPrimative<bool>(nameof (cookie), cookie);
      methodArguments.AddPrimative<bool>(nameof (logging), logging);
      methodArguments.AddPrimative<bool>(nameof (status), status);
      methodArguments.AddPrimative<bool>(nameof (xfbml), xfbml);
      methodArguments.AddString(nameof (channelUrl), channelUrl);
      methodArguments.AddString(nameof (authResponse), authResponse);
      methodArguments.AddPrimative<bool>(nameof (frictionlessRequests), frictionlessRequests);
      methodArguments.AddString("version", FB.GraphApiVersion);
      this.canvasJSWrapper.ExternalCall("FBUnity.init", (object) (!flag ? 0 : 1), (object) "https://connect.facebook.net", (object) javascriptSDKLocale, (object) (!Constants.DebugMode ? 0 : 1), (object) methodArguments.ToJsonString(), (object) (!status ? 0 : 1));
    }

    public override void LogInWithPublishPermissions(
      IEnumerable<string> permissions,
      FacebookDelegate<ILoginResult> callback)
    {
      this.canvasJSWrapper.DisableFullScreen();
      this.canvasJSWrapper.ExternalCall("FBUnity.login", (object) permissions, (object) this.CallbackManager.AddFacebookDelegate<ILoginResult>(callback));
    }

    public override void LogInWithReadPermissions(
      IEnumerable<string> permissions,
      FacebookDelegate<ILoginResult> callback)
    {
      this.canvasJSWrapper.DisableFullScreen();
      this.canvasJSWrapper.ExternalCall("FBUnity.login", (object) permissions, (object) this.CallbackManager.AddFacebookDelegate<ILoginResult>(callback));
    }

    public override void LogOut()
    {
      base.LogOut();
      this.canvasJSWrapper.ExternalCall("FBUnity.logout");
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
      args.AddCommaSeparatedList(nameof (to), to);
      args.AddString("action_type", !actionType.HasValue ? (string) null : actionType.ToString());
      args.AddString("object_id", objectId);
      args.AddList<object>(nameof (filters), filters);
      args.AddList<string>("exclude_ids", excludeIds);
      args.AddNullablePrimitive<int>("max_recipients", maxRecipients);
      args.AddString(nameof (data), data);
      args.AddString(nameof (title), title);
      CanvasFacebook.CanvasUIMethodCall<IAppRequestResult> canvasUiMethodCall = new CanvasFacebook.CanvasUIMethodCall<IAppRequestResult>(this, "apprequests", "OnAppRequestsComplete");
      canvasUiMethodCall.Callback = callback;
      canvasUiMethodCall.Call(args);
    }

    public override void ActivateApp(string appId)
    {
      this.canvasJSWrapper.ExternalCall("FBUnity.activateApp");
    }

    public override void ShareLink(
      Uri contentURL,
      string contentTitle,
      string contentDescription,
      Uri photoURL,
      FacebookDelegate<IShareResult> callback)
    {
      MethodArguments args = new MethodArguments();
      args.AddUri("link", contentURL);
      args.AddString("name", contentTitle);
      args.AddString("description", contentDescription);
      args.AddUri("picture", photoURL);
      CanvasFacebook.CanvasUIMethodCall<IShareResult> canvasUiMethodCall = new CanvasFacebook.CanvasUIMethodCall<IShareResult>(this, "feed", "OnShareLinkComplete");
      canvasUiMethodCall.Callback = callback;
      canvasUiMethodCall.Call(args);
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
      args.AddString("to", toId);
      args.AddUri(nameof (link), link);
      args.AddString("name", linkName);
      args.AddString("caption", linkCaption);
      args.AddString("description", linkDescription);
      args.AddUri(nameof (picture), picture);
      args.AddString("source", mediaSource);
      CanvasFacebook.CanvasUIMethodCall<IShareResult> canvasUiMethodCall = new CanvasFacebook.CanvasUIMethodCall<IShareResult>(this, "feed", "OnShareLinkComplete");
      canvasUiMethodCall.Callback = callback;
      canvasUiMethodCall.Call(args);
    }

    public void Pay(
      string product,
      string action,
      int quantity,
      int? quantityMin,
      int? quantityMax,
      string requestId,
      string pricepointId,
      string testCurrency,
      FacebookDelegate<IPayResult> callback)
    {
      this.PayImpl(product, action, quantity, quantityMin, quantityMax, requestId, pricepointId, testCurrency, callback);
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
      args.AddString("display", "async");
      CanvasFacebook.CanvasUIMethodCall<IGroupCreateResult> canvasUiMethodCall = new CanvasFacebook.CanvasUIMethodCall<IGroupCreateResult>(this, "game_group_create", "OnGroupCreateComplete");
      canvasUiMethodCall.Callback = callback;
      canvasUiMethodCall.Call(args);
    }

    public override void GameGroupJoin(string id, FacebookDelegate<IGroupJoinResult> callback)
    {
      MethodArguments args = new MethodArguments();
      args.AddString(nameof (id), id);
      args.AddString("display", "async");
      CanvasFacebook.CanvasUIMethodCall<IGroupJoinResult> canvasUiMethodCall = new CanvasFacebook.CanvasUIMethodCall<IGroupJoinResult>(this, "game_group_join", "OnJoinGroupComplete");
      canvasUiMethodCall.Callback = callback;
      canvasUiMethodCall.Call(args);
    }

    public override void GetAppLink(FacebookDelegate<IAppLinkResult> callback)
    {
      Dictionary<string, object> dictionary = new Dictionary<string, object>()
      {
        {
          "url",
          (object) this.appLinkUrl
        }
      };
      callback((IAppLinkResult) new AppLinkResult(new ResultContainer((IDictionary<string, object>) dictionary)));
      this.appLinkUrl = string.Empty;
    }

    public override void AppEventsLogEvent(
      string logEvent,
      float? valueToSum,
      Dictionary<string, object> parameters)
    {
      this.canvasJSWrapper.ExternalCall("FBUnity.logAppEvent", (object) logEvent, (object) valueToSum, (object) Json.Serialize((object) parameters));
    }

    public override void AppEventsLogPurchase(
      float logPurchase,
      string currency,
      Dictionary<string, object> parameters)
    {
      this.canvasJSWrapper.ExternalCall("FBUnity.logPurchase", (object) logPurchase, (object) currency, (object) Json.Serialize((object) parameters));
    }

    public override void OnLoginComplete(ResultContainer result)
    {
      CanvasFacebook.FormatAuthResponse(result, (Utilities.Callback<ResultContainer>) (formattedResponse => this.OnAuthResponse(new LoginResult(formattedResponse))));
    }

    public override void OnGetAppLinkComplete(ResultContainer message)
    {
      throw new NotImplementedException();
    }

    public void OnFacebookAuthResponseChange(string responseJsonData)
    {
      this.OnFacebookAuthResponseChange(new ResultContainer(responseJsonData));
    }

    public void OnFacebookAuthResponseChange(ResultContainer resultContainer)
    {
      CanvasFacebook.FormatAuthResponse(resultContainer, (Utilities.Callback<ResultContainer>) (formattedResponse => AccessToken.CurrentAccessToken = new LoginResult(formattedResponse).AccessToken));
    }

    public void OnPayComplete(string responseJsonData)
    {
      this.OnPayComplete(new ResultContainer(responseJsonData));
    }

    public void OnPayComplete(ResultContainer resultContainer)
    {
      this.CallbackManager.OnFacebookResponse((IInternalResult) new PayResult(resultContainer));
    }

    public override void OnAppRequestsComplete(ResultContainer resultContainer)
    {
      this.CallbackManager.OnFacebookResponse((IInternalResult) new AppRequestResult(resultContainer));
    }

    public override void OnShareLinkComplete(ResultContainer resultContainer)
    {
      this.CallbackManager.OnFacebookResponse((IInternalResult) new ShareResult(resultContainer));
    }

    public override void OnGroupCreateComplete(ResultContainer resultContainer)
    {
      this.CallbackManager.OnFacebookResponse((IInternalResult) new GroupCreateResult(resultContainer));
    }

    public override void OnGroupJoinComplete(ResultContainer resultContainer)
    {
      this.CallbackManager.OnFacebookResponse((IInternalResult) new GroupJoinResult(resultContainer));
    }

    public void OnUrlResponse(string url) => this.appLinkUrl = url;

    private static void FormatAuthResponse(
      ResultContainer result,
      Utilities.Callback<ResultContainer> callback)
    {
      if (result.ResultDictionary == null)
      {
        callback(result);
      }
      else
      {
        IDictionary<string, object> dictionary1;
        if (result.ResultDictionary.TryGetValue<IDictionary<string, object>>("authResponse", out dictionary1))
        {
          result.ResultDictionary.Remove("authResponse");
          foreach (KeyValuePair<string, object> keyValuePair in (IEnumerable<KeyValuePair<string, object>>) dictionary1)
            result.ResultDictionary[keyValuePair.Key] = keyValuePair.Value;
        }
        if (result.ResultDictionary.ContainsKey(LoginResult.AccessTokenKey) && !result.ResultDictionary.ContainsKey(LoginResult.PermissionsKey))
          FB.API("me", HttpMethod.GET, (FacebookDelegate<IGraphResult>) (r =>
          {
            IDictionary<string, object> dictionary3;
            if (r.ResultDictionary != null && r.ResultDictionary.TryGetValue<IDictionary<string, object>>("permissions", out dictionary3))
            {
              IList<string> list = (IList<string>) new List<string>();
              IList<object> objectList;
              if (dictionary3.TryGetValue<IList<object>>("data", out objectList))
              {
                foreach (object obj in (IEnumerable<object>) objectList)
                {
                  if (obj is IDictionary<string, object> dictionary4)
                  {
                    string str1;
                    if (dictionary4.TryGetValue<string>("status", out str1) && str1.Equals("granted", StringComparison.InvariantCultureIgnoreCase))
                    {
                      string str2;
                      if (dictionary4.TryGetValue<string>("permission", out str2))
                        list.Add(str2);
                      else
                        FacebookLogger.Warn("Didn't find permission name");
                    }
                    else
                      FacebookLogger.Warn("Didn't find status in permissions result");
                  }
                  else
                    FacebookLogger.Warn("Failed to case permission dictionary");
                }
              }
              else
                FacebookLogger.Warn("Failed to extract data from permissions");
              result.ResultDictionary[LoginResult.PermissionsKey] = (object) list.ToCommaSeparateList();
            }
            else
              FacebookLogger.Warn("Failed to load permissions for access token");
            callback(result);
          }), (IDictionary<string, string>) new Dictionary<string, string>()
          {
            {
              "fields",
              "permissions"
            },
            {
              "access_token",
              (string) result.ResultDictionary[LoginResult.AccessTokenKey]
            }
          });
        else
          callback(result);
      }
    }

    private void PayImpl(
      string product,
      string action,
      int quantity,
      int? quantityMin,
      int? quantityMax,
      string requestId,
      string pricepointId,
      string testCurrency,
      FacebookDelegate<IPayResult> callback)
    {
      MethodArguments args = new MethodArguments();
      args.AddString(nameof (product), product);
      args.AddString(nameof (action), action);
      args.AddPrimative<int>(nameof (quantity), quantity);
      args.AddNullablePrimitive<int>("quantity_min", quantityMin);
      args.AddNullablePrimitive<int>("quantity_max", quantityMax);
      args.AddString("request_id", requestId);
      args.AddString("pricepoint_id", pricepointId);
      args.AddString("test_currency", testCurrency);
      CanvasFacebook.CanvasUIMethodCall<IPayResult> canvasUiMethodCall = new CanvasFacebook.CanvasUIMethodCall<IPayResult>(this, "pay", "OnPayComplete");
      canvasUiMethodCall.Callback = callback;
      canvasUiMethodCall.Call(args);
    }

    private class CanvasUIMethodCall<T> : MethodCall<T> where T : IResult
    {
      private CanvasFacebook canvasImpl;
      private string callbackMethod;

      public CanvasUIMethodCall(
        CanvasFacebook canvasImpl,
        string methodName,
        string callbackMethod)
        : base((FacebookBase) canvasImpl, methodName)
      {
        this.canvasImpl = canvasImpl;
        this.callbackMethod = callbackMethod;
      }

      public override void Call(MethodArguments args)
      {
        this.UI(this.MethodName, args, this.Callback);
      }

      private void UI(string method, MethodArguments args, FacebookDelegate<T> callback = null)
      {
        this.canvasImpl.canvasJSWrapper.DisableFullScreen();
        MethodArguments methodArguments = new MethodArguments(args);
        methodArguments.AddString("app_id", this.canvasImpl.appId);
        methodArguments.AddString(nameof (method), method);
        string str = this.canvasImpl.CallbackManager.AddFacebookDelegate<T>(callback);
        this.canvasImpl.canvasJSWrapper.ExternalCall("FBUnity.ui", (object) methodArguments.ToJsonString(), (object) str, (object) this.callbackMethod);
      }
    }
  }
}
