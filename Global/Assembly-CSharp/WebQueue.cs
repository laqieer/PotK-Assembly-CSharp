// Decompiled with JetBrains decompiler
// Type: WebQueue
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using Facebook.Unity;
using gu3;
using gu3.Device;
using MiniJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public static class WebQueue
{
  private const float PACKET_SEND_INTERVAL = 0.5f;
  private const float REQUEST_TIMEOUT = 120f;
  public const string rpcPath = "api/v2/";
  private static readonly string LOG_CATEGORY = "<color=#7887ab><b>[API] </b></color>";
  public static Func<WebError, IEnumerator> FailCallback = new Func<WebError, IEnumerator>(WebQueue.defaultFailCallback);
  public static Func<WebError, IEnumerator> FailAuthTokenCallback = new Func<WebError, IEnumerator>(WebQueue.defaultFailCallback);
  public static Action<object> Logger = (Action<object>) (_ => { });
  public static int DEFAULT_RETRY_COUNT = 1;
  private static bool isClearRequestQueue = false;
  private static bool isLock = false;
  private static string authToken = string.Empty;
  private static List<WebRequest> requestQueue = new List<WebRequest>();
  private static List<WebRequest> authQueue = new List<WebRequest>();

  public static string AuthToken => WebQueue.authToken;

  public static bool IsAuthToken() => WebQueue.authToken != string.Empty;

  public static void ResetAuthToken() => WebQueue.authToken = string.Empty;

  public static void Lock()
  {
    WebQueue.isLock = true;
    WebQueue.Logger((object) (WebQueue.LOG_CATEGORY + "web queue locked"));
  }

  public static void UnLock()
  {
    WebQueue.isLock = false;
    WebQueue.Logger((object) (WebQueue.LOG_CATEGORY + "web queue unlocked"));
  }

  public static void ClearRequestQueue()
  {
    WebQueue.isClearRequestQueue = true;
    WebQueue.Logger((object) ("ClearRequestQueue count=" + (object) WebQueue.requestQueue.Count));
  }

  private static void addQueue(List<WebRequest> queue, WebRequest request)
  {
    queue.Add(request);
    if (!request.Loading || !Object.op_Inequality((Object) Singleton<CommonRoot>.GetInstanceOrNull(), (Object) null))
      return;
    Singleton<CommonRoot>.GetInstance().isWebRunnig = true;
  }

  private static void removeQueue(List<WebRequest> queue, WebRequest request)
  {
    queue.Remove(request);
    request.isDone = true;
    if (!request.Loading || WebQueue.requestQueue.Count + WebQueue.authQueue.Count > 0 || !Object.op_Inequality((Object) Singleton<CommonRoot>.GetInstanceOrNull(), (Object) null))
      return;
    Singleton<CommonRoot>.GetInstance().isWebRunnig = false;
  }

  public static void Add(WebRequest request) => WebQueue.addQueue(WebQueue.requestQueue, request);

  public static void Get(string path, Action<WebResponse> callback)
  {
    WebQueue.Add(new WebRequest("api/v2/" + path, WebRequest.RequestMethod.GET, string.Empty, callback));
  }

  public static void Post(string path, Action<WebResponse> callback)
  {
    string path1 = !"api/v2/".EndsWith("/") || !path.StartsWith("/") ? "api/v2/" + path : "api/v2/" + path.Substring(1);
    WebQueue.Logger((object) (WebQueue.LOG_CATEGORY + "Post path : " + path1));
    WebQueue.Add(new WebRequest(path1, WebRequest.RequestMethod.POST, string.Empty, callback));
  }

  public static void Post(
    string path,
    Dictionary<string, object> post,
    Action<WebResponse> callback)
  {
    WebQueue.RawPost(!"api/v2/".EndsWith("/") || !path.StartsWith("/") ? "api/v2/" + path : "api/v2/" + path.Substring(1), post, callback);
  }

  public static void RawPost(
    string path,
    Dictionary<string, object> post,
    Action<WebResponse> callback)
  {
    WebQueue.Logger((object) (WebQueue.LOG_CATEGORY + "Post path : " + path));
    WebQueue.Add(new WebRequest(path, WebRequest.RequestMethod.POST, Json.Serialize((object) post), callback));
  }

  public static void SilentPost(
    string path,
    Dictionary<string, object> post,
    Action<WebResponse> callback)
  {
    WebQueue.Add(new WebRequest(!"api/v2/".EndsWith("/") || !path.StartsWith("/") ? "api/v2/" + path : "api/v2/" + path.Substring(1), WebRequest.RequestMethod.POST, Json.Serialize((object) post), callback, (Func<WebError, IEnumerator>) (_ => (IEnumerator) null))
    {
      Loading = false
    });
  }

  public static int RequestQueueCount() => WebQueue.requestQueue.Count;

  public static int AuthQueueCount() => WebQueue.authQueue.Count;

  [DebuggerHidden]
  public static IEnumerator RunWorker()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    WebQueue.\u003CRunWorker\u003Ec__Iterator979 workerCIterator979 = new WebQueue.\u003CRunWorker\u003Ec__Iterator979();
    return (IEnumerator) workerCIterator979;
  }

  private static void authPost(
    string path,
    Dictionary<string, string> posts,
    Action<WebResponse> successCallback,
    Func<WebError, IEnumerator> failCallback = null)
  {
    WebQueue.Logger((object) (WebQueue.LOG_CATEGORY + "authPost path : " + path));
    WebRequest request = new WebRequest(path, WebRequest.RequestMethod.POST, Json.Serialize((object) posts), successCallback, failCallback);
    WebQueue.addQueue(WebQueue.authQueue, request);
  }

  private static void authAccessToken(
    Dictionary<string, string> posts,
    Action<WebResponse> successCallback,
    Func<WebError, IEnumerator> failCallback = null)
  {
    string path = "auth/accesstoken";
    WebQueue.Logger((object) (WebQueue.LOG_CATEGORY + "authPost path : " + path));
    WebRequest request = new WebRequest(path, WebRequest.RequestMethod.POST, Json.Serialize((object) posts), successCallback, failCallback, isAuthAccessToken: true);
    WebQueue.addQueue(WebQueue.authQueue, request);
  }

  private static void authDeviceInfo(
    Dictionary<string, string> posts,
    Action<WebResponse> successCallback,
    Func<WebError, IEnumerator> failCallback = null)
  {
    string path = "auth/deviceinfo";
    WebQueue.Logger((object) (WebQueue.LOG_CATEGORY + "authPost path : " + path));
    WebRequest request = new WebRequest(path, WebRequest.RequestMethod.POST, Json.Serialize((object) posts), successCallback, failCallback, isAuthDeviceInfo: true);
    WebQueue.addQueue(WebQueue.authQueue, request);
  }

  [DebuggerHidden]
  private static IEnumerator processQueue(List<WebRequest> queue)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebQueue.\u003CprocessQueue\u003Ec__Iterator97A()
    {
      queue = queue,
      \u003C\u0024\u003Equeue = queue
    };
  }

  public static void EnqueueAuthPasscode(
    Action<string, int> successCallback,
    Func<WebError, IEnumerator> failCallback)
  {
    WebQueue.authPost("auth/passcode", new Dictionary<string, string>()
    {
      ["device_id"] = Persist.auth.Data.DeviceID,
      ["secret_key"] = Persist.auth.Data.SecretKey
    }, (Action<WebResponse>) (r =>
    {
      object s = r.Json["expires_in"];
      int num2 = !(s is long num3) ? int.Parse((string) s) : (int) num3;
      successCallback((string) r.Json["passcode"], num2);
    }), (Func<WebError, IEnumerator>) (e => e.HasResponse() ? failCallback(e) : new object[0].GetEnumerator()));
  }

  public static void EnqueueAuthMigrate(
    string passcode,
    System.Action successCallback,
    Func<WebError, IEnumerator> failCallback)
  {
    WebQueue.enqueueAuth((System.Action) (() => WebQueue.authPost("auth/migrate", new Dictionary<string, string>()
    {
      [nameof (passcode)] = passcode,
      ["secret_key"] = Persist.auth.Data.SecretKey,
      ["device_id"] = Persist.auth.Data.DeviceID
    }, (Action<WebResponse>) (r =>
    {
      Persist.auth.Data.DeviceID = (string) r.Json["old_device_id"];
      Persist.auth.Flush();
      successCallback();
    }), (Func<WebError, IEnumerator>) (e => e.HasResponse() ? failCallback(e) : new object[0].GetEnumerator()))));
  }

  public static void EnqueueAuthDeviceInfo(
    System.Action successCallback,
    Func<WebError, IEnumerator> failCallback)
  {
    WebQueue.authDeviceInfo(new Dictionary<string, string>()
    {
      ["udid"] = Persist.auth.Data.UUID
    }, (Action<WebResponse>) (r =>
    {
      WebQueue.isLock = true;
      Singleton<NGWeb>.GetInstance().ShowTranferModalWindow((System.Action) (() =>
      {
        Persist.auth.Data.SecretKey = (string) r.Json["secret_key"];
        Persist.auth.Data.DeviceID = (string) r.Json["device_id"];
        successCallback();
        WebQueue.isLock = false;
      }), (System.Action) (() =>
      {
        successCallback();
        WebQueue.isLock = false;
      }));
    }), (Func<WebError, IEnumerator>) (e => failCallback(e)));
  }

  public static void EnqueueAuthFacebookSSORelateAccount(
    System.Action successCallback,
    Func<WebError, IEnumerator> failCallback)
  {
    WebQueue.enqueueAuth((System.Action) (() => WebQueue.authPost("auth/facebook/sso/relate_account", new Dictionary<string, string>()
    {
      ["device_id"] = Persist.auth.Data.DeviceID,
      ["secret_key"] = Persist.auth.Data.SecretKey,
      ["access_token"] = AccessToken.CurrentAccessToken.TokenString
    }, (Action<WebResponse>) (r => successCallback()), (Func<WebError, IEnumerator>) (e => e.HasResponse() ? failCallback(e) : new object[0].GetEnumerator()))));
  }

  public static void EnqueueAuthFacebookSSOMigrate(
    System.Action successCallback,
    Func<WebError, IEnumerator> failCallback)
  {
    WebQueue.enqueueAuth((System.Action) (() => WebQueue.authPost("auth/facebook/sso/migrate", new Dictionary<string, string>()
    {
      ["device_id"] = Persist.auth.Data.DeviceID,
      ["secret_key"] = Persist.auth.Data.SecretKey,
      ["access_token"] = AccessToken.CurrentAccessToken.TokenString
    }, (Action<WebResponse>) (r =>
    {
      Persist.auth.Data.DeviceID = (string) r.Json["old_device_id"];
      Persist.auth.Flush();
      successCallback();
    }), (Func<WebError, IEnumerator>) (e => e.HasResponse() ? failCallback(e) : new object[0].GetEnumerator()))));
  }

  public static void EnqueueAuthFacebookSSODevice(
    Action<string, string> successCallback,
    Func<WebError, IEnumerator> failCallback)
  {
    WebQueue.authPost("auth/facebook/sso/device", new Dictionary<string, string>()
    {
      ["access_token"] = AccessToken.CurrentAccessToken.TokenString
    }, (Action<WebResponse>) (r => successCallback((string) r.Json["device_id"], (string) r.Json["secret_key"])), (Func<WebError, IEnumerator>) (e => e.HasResponse() ? failCallback(e) : new object[0].GetEnumerator()));
  }

  public static void EnqueueAuthFacebookSSOIsRelated(
    Action<bool> successCallback,
    Func<WebError, IEnumerator> failCallback)
  {
    WebQueue.authPost("auth/facebook/sso/is_related", new Dictionary<string, string>()
    {
      ["device_id"] = Persist.auth.Data.DeviceID,
      ["secret_key"] = Persist.auth.Data.SecretKey
    }, (Action<WebResponse>) (r => successCallback((bool) r.Json["is_related"])), (Func<WebError, IEnumerator>) (e => e.HasResponse() ? failCallback(e) : new object[0].GetEnumerator()));
  }

  private static void enqueueDeviceInfo()
  {
    if (Persist.auth.Exists)
      return;
    WebAPI.AuthDeviceInfo((System.Action) (() => Persist.auth.Flush()));
  }

  private static void enqueueAuth(System.Action callback = null)
  {
    if (callback == null)
      callback = (System.Action) (() => { });
    WebQueue.authToken = string.Empty;
    Dictionary<string, string> posts = new Dictionary<string, string>();
    if (Persist.auth.Data.IsNeedAuthRegister())
    {
      posts["secret_key"] = Persist.auth.Data.SecretKey;
      posts["udid"] = Persist.auth.Data.UUID;
      posts["idfa"] = AdSupport.getAdvertisingIdentifier();
      posts["idfv"] = AdSupport.getIdentifierForVender();
      WebQueue.authPost("auth/register", posts, (Action<WebResponse>) (r1 => WebQueue.authAccessToken(new Dictionary<string, string>()
      {
        ["device_id"] = (string) r1.Json["device_id"],
        ["secret_key"] = Persist.auth.Data.SecretKey,
        ["idfa"] = AdSupport.getAdvertisingIdentifier(),
        ["idfv"] = AdSupport.getIdentifierForVender()
      }, (Action<WebResponse>) (r2 =>
      {
        WebQueue.authToken = (string) r2.Json["access_token"];
        Persist.auth.Data.DeviceID = (string) r1.Json["device_id"];
        Persist.auth.Flush();
        callback();
      }))));
    }
    else
    {
      posts["device_id"] = Persist.auth.Data.DeviceID;
      posts["secret_key"] = Persist.auth.Data.SecretKey;
      posts["idfa"] = AdSupport.getAdvertisingIdentifier();
      posts["idfv"] = AdSupport.getIdentifierForVender();
      WebQueue.authAccessToken(posts, (Action<WebResponse>) (r1 =>
      {
        WebQueue.authToken = (string) r1.Json["access_token"];
        callback();
      }));
    }
  }

  private static HTTP.Request makeRawRequest(WebRequest request)
  {
    HTTP.Request request1;
    if (request.Method == WebRequest.RequestMethod.POST)
    {
      request1 = new HTTP.Request("POST", request.GetURL());
      request1.Text = request.PostData;
    }
    else
      request1 = new HTTP.Request("GET", request.GetURL());
    request1.headers.Set("Content-Type", "application/json; charset=utf-8");
    if (WebQueue.authToken != string.Empty)
      request1.headers.Set("Authorization", "gumi " + WebQueue.authToken);
    request1.headers.Set("User-Agent", DeviceManager.GetUserAgent());
    request1.headers.Set("X-Device-API-Version", "2");
    request1.headers.Set("X-Device-Version", DeviceManager.GetBundleVersion());
    request1.headers.Set("X-Device-ApplicationVersion", Revision.ApplicationVersion);
    request1.headers.Set("X-Device-DLCVersion", Revision.DLCVersion);
    request1.headers.Set("X-Device-Language-Locale", DeviceManager.GetLanguageLocale());
    request1.headers.Set("X-Device-TimeZone", DeviceManager.GetTimeZone());
    request1.headers.Set("X-GUMI-TRANSACTION", request.GumiTransactionId);
    request1.headers.Set("X-Device-Platform", "android");
    request1.headers.Set("X-Device-IDFA", AdSupport.getAdvertisingIdentifier());
    request1.headers.Set("X-Device-IDFV", AdSupport.getIdentifierForVender());
    request1.headers.Set("X-Device-Platform-Special", "1");
    return request1;
  }

  private static bool isSuccessResponse(HTTP.Request rawRequest, HTTP.Response rawResponse)
  {
    if (rawRequest == null)
    {
      WebQueue.Logger((object) (WebQueue.LOG_CATEGORY + "Queue checkError < rawRequest > is Null!"));
      return false;
    }
    if (rawResponse == null)
    {
      WebQueue.Logger((object) (WebQueue.LOG_CATEGORY + "Queue checkError < rawResponse > is Null!"));
      return false;
    }
    if (rawRequest.exception != null || rawResponse.status != 200)
      return false;
    string str = rawResponse.headers.Get("Content-Type");
    return !string.IsNullOrEmpty(str) && str.StartsWith("application/json");
  }

  [DebuggerHidden]
  private static IEnumerator callFailCallback(WebError error)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebQueue.\u003CcallFailCallback\u003Ec__Iterator97B()
    {
      error = error,
      \u003C\u0024\u003Eerror = error
    };
  }

  private static int activeAllRequestCount()
  {
    return WebQueue.requestQueue.Where<WebRequest>((Func<WebRequest, bool>) (x => x.RestRetryCount > 0)).Count<WebRequest>() + WebQueue.authQueue.Where<WebRequest>((Func<WebRequest, bool>) (x => x.RestRetryCount > 0)).Count<WebRequest>();
  }

  [DebuggerHidden]
  private static IEnumerator defaultFailCallback(WebError error)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebQueue.\u003CdefaultFailCallback\u003Ec__Iterator97C()
    {
      error = error,
      \u003C\u0024\u003Eerror = error
    };
  }
}
