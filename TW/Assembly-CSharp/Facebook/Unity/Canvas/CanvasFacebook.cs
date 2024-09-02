// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Canvas.CanvasFacebook
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using Facebook.MiniJSON;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Facebook.Unity.Canvas
{
  internal sealed class CanvasFacebook : 
    FacebookBase,
    ICanvasFacebook,
    ICanvasFacebookCallbackHandler,
    ICanvasFacebookImplementation,
    IFacebook,
    IFacebookCallbackHandler
  {
    internal const string MethodAppRequests = "apprequests";
    internal const string MethodFeed = "feed";
    internal const string MethodPay = "pay";
    internal const string MethodGameGroupCreate = "game_group_create";
    internal const string MethodGameGroupJoin = "game_group_join";
    internal const string CancelledResponse = "{\"cancelled\":true}";
    internal const string FacebookConnectURL = "https://connect.facebook.net";
    internal const string SDKVersion = "v2.4";
    private const string AuthResponseKey = "authResponse";
    private const string ResponseKey = "response";
    private const string JSSDKBindingFileName = "JSSDKBindings";
    private const string SDKLocale = "en_US";
    private string appId;
    private bool sdkDebug;
    private string appLinkUrl;

    public CanvasFacebook()
      : this(new CallbackManager())
    {
    }

    public CanvasFacebook(CallbackManager callbackManager)
      : base(callbackManager)
    {
    }

    public override bool LimitEventUsage { get; set; }

    public override string FacebookSdkVersion
    {
      get => string.Format("Facebook.JS.SDK.{0}", (object) "v2.4");
    }

    private static string IntegrationMethodJs
    {
      get
      {
        TextAsset textAsset = Resources.Load("JSSDKBindings") as TextAsset;
        return Object.op_Implicit((Object) textAsset) ? textAsset.text : (string) null;
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
      if (CanvasFacebook.IntegrationMethodJs == null)
        throw new Exception("Cannot initialize facebook javascript");
      base.Init(appId, cookie, logging, status, xfbml, channelUrl, authResponse, frictionlessRequests, hideUnityDelegate, onInitComplete);
      Application.ExternalEval(CanvasFacebook.IntegrationMethodJs);
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
      methodArguments.AddString("version", "v2.4");
      Application.ExternalCall("FBUnity.init", new object[6]
      {
        (object) (!flag ? 0 : 1),
        (object) "https://connect.facebook.net",
        (object) "en_US",
        (object) (!this.sdkDebug ? 0 : 1),
        (object) methodArguments.ToJsonString(),
        (object) (!status ? 0 : 1)
      });
    }

    public override void LogInWithPublishPermissions(
      IEnumerable<string> permissions,
      FacebookDelegate<ILoginResult> callback)
    {
      if (Screen.fullScreen)
        Screen.fullScreen = false;
      Application.ExternalCall("FBUnity.login", new object[2]
      {
        (object) permissions,
        (object) this.CallbackManager.AddFacebookDelegate<ILoginResult>(callback)
      });
    }

    public override void LogInWithReadPermissions(
      IEnumerable<string> permissions,
      FacebookDelegate<ILoginResult> callback)
    {
      if (Screen.fullScreen)
        Screen.fullScreen = false;
      Application.ExternalCall("FBUnity.login", new object[2]
      {
        (object) permissions,
        (object) this.CallbackManager.AddFacebookDelegate<ILoginResult>(callback)
      });
    }

    public override void LogOut()
    {
      base.LogOut();
      Application.ExternalCall("FBUnity.logout", new object[0]);
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
      Application.ExternalCall("FBUnity.activateApp", new object[0]);
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
      callback((IAppLinkResult) new AppLinkResult(Json.Serialize((object) dictionary)));
      this.appLinkUrl = string.Empty;
    }

    public override void AppEventsLogEvent(
      string logEvent,
      float? valueToSum,
      Dictionary<string, object> parameters)
    {
      Application.ExternalCall("FBUnity.logAppEvent", new object[3]
      {
        (object) logEvent,
        (object) valueToSum,
        (object) Json.Serialize((object) parameters)
      });
    }

    public override void AppEventsLogPurchase(
      float logPurchase,
      string currency,
      Dictionary<string, object> parameters)
    {
      Application.ExternalCall("FBUnity.logPurchase", new object[3]
      {
        (object) logPurchase,
        (object) currency,
        (object) Json.Serialize((object) parameters)
      });
    }

    public override void OnLoginComplete(string responseJsonData)
    {
      this.OnAuthResponse(new LoginResult(CanvasFacebook.FormatAuthResponse(responseJsonData)));
    }

    public override void OnGetAppLinkComplete(string message)
    {
      throw new NotImplementedException();
    }

    public void OnFacebookAuthResponseChange(string responseJsonData)
    {
      AccessToken.CurrentAccessToken = new LoginResult(CanvasFacebook.FormatAuthResponse(responseJsonData)).AccessToken;
    }

    public void OnPayComplete(string responseJsonData)
    {
      this.CallbackManager.OnFacebookResponse((IInternalResult) new PayResult(CanvasFacebook.FormatResult(responseJsonData)));
    }

    public override void OnAppRequestsComplete(string responseJsonData)
    {
      this.CallbackManager.OnFacebookResponse((IInternalResult) new AppRequestResult(CanvasFacebook.FormatResult(responseJsonData)));
    }

    public override void OnShareLinkComplete(string responseJsonData)
    {
      this.CallbackManager.OnFacebookResponse((IInternalResult) new ShareResult(CanvasFacebook.FormatResult(responseJsonData)));
    }

    public override void OnGroupCreateComplete(string responseJsonData)
    {
      this.CallbackManager.OnFacebookResponse((IInternalResult) new GroupCreateResult(CanvasFacebook.FormatResult(responseJsonData)));
    }

    public override void OnGroupJoinComplete(string responseJsonData)
    {
      this.CallbackManager.OnFacebookResponse((IInternalResult) new GroupJoinResult(CanvasFacebook.FormatResult(responseJsonData)));
    }

    public void OnUrlResponse(string url) => this.appLinkUrl = url;

    private static string FormatAuthResponse(string result)
    {
      if (string.IsNullOrEmpty(result))
        return result;
      IDictionary<string, object> responseDictionary = CanvasFacebook.GetFormattedResponseDictionary(result);
      IDictionary<string, object> dictionary;
      if (responseDictionary.TryGetValue<IDictionary<string, object>>("authResponse", out dictionary))
      {
        responseDictionary.Remove("authResponse");
        foreach (KeyValuePair<string, object> keyValuePair in (IEnumerable<KeyValuePair<string, object>>) dictionary)
          responseDictionary[keyValuePair.Key] = keyValuePair.Value;
      }
      return Json.Serialize((object) responseDictionary);
    }

    private static string FormatResult(string result)
    {
      return string.IsNullOrEmpty(result) ? result : Json.Serialize((object) CanvasFacebook.GetFormattedResponseDictionary(result));
    }

    private static IDictionary<string, object> GetFormattedResponseDictionary(string result)
    {
      IDictionary<string, object> dictionary = (IDictionary<string, object>) Json.Deserialize(result);
      IDictionary<string, object> responseDictionary;
      if (!dictionary.TryGetValue<IDictionary<string, object>>("response", out responseDictionary))
        return dictionary;
      object obj;
      if (dictionary.TryGetValue("callback_id", out obj))
        responseDictionary["callback_id"] = obj;
      return responseDictionary;
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
        if (Screen.fullScreen)
          Screen.fullScreen = false;
        MethodArguments methodArguments = new MethodArguments(args);
        methodArguments.AddString("app_id", this.canvasImpl.appId);
        methodArguments.AddString(nameof (method), method);
        string str = this.canvasImpl.CallbackManager.AddFacebookDelegate<T>(callback);
        Application.ExternalCall("FBUnity.ui", new object[3]
        {
          (object) methodArguments.ToJsonString(),
          (object) str,
          (object) this.callbackMethod
        });
      }
    }
  }
}
