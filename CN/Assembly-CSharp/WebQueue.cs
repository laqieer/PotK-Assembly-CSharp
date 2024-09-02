// Decompiled with JetBrains decompiler
// Type: WebQueue
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
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
  private const float REQUEST_TIMEOUT = 60f;
  public const string rpcPath = "api/v2/";
  public static Func<WebError, IEnumerator> FailCallback = new Func<WebError, IEnumerator>(WebQueue.defaultFailCallback);
  public static Func<WebError, IEnumerator> FailAuthTokenCallback = new Func<WebError, IEnumerator>(WebQueue.defaultFailCallback);
  public static Action<object> Logger = (Action<object>) (_ => { });
  public static int DEFAULT_RETRY_COUNT = 1;
  private static bool isClearRequestQueue = false;
  private static bool isLock = false;
  private static string authToken = string.Empty;
  private static string accountID = string.Empty;
  private static List<WebRequest> requestQueue = new List<WebRequest>();
  private static List<WebRequest> authQueue = new List<WebRequest>();

  public static string AuthToken => WebQueue.authToken;

  public static bool IsAuthToken() => WebQueue.authToken != string.Empty;

  public static void setAuthToken(string newToken) => WebQueue.authToken = newToken;

  public static void ResetAuthToken() => WebQueue.authToken = string.Empty;

  public static void Lock()
  {
    WebQueue.isLock = true;
    WebQueue.Logger((object) "web queue locked");
  }

  public static void UnLock()
  {
    WebQueue.isLock = false;
    WebQueue.Logger((object) "web queue unlocked");
  }

  public static void ClearRequestQueue()
  {
    WebQueue.isClearRequestQueue = true;
    WebQueue.Logger((object) ("call ClearRequestQueue() count=" + (object) WebQueue.requestQueue.Count));
  }

  private static void addQueue(List<WebRequest> queue, WebRequest request)
  {
    queue.Add(request);
    if (request.LoadingType < 0 || !Object.op_Inequality((Object) Singleton<CommonRoot>.GetInstanceOrNull(), (Object) null))
      return;
    Singleton<CommonRoot>.GetInstance().loadingMode = request.LoadingType != 1 ? 0 : 1;
    Singleton<CommonRoot>.GetInstance().isWebRunning = true;
  }

  private static void removeQueue(List<WebRequest> queue, WebRequest request)
  {
    queue.Remove(request);
    request.isDone = true;
    if (request.LoadingType < 0 || WebQueue.requestQueue.Count + WebQueue.authQueue.Count > 0 || !Object.op_Inequality((Object) Singleton<CommonRoot>.GetInstanceOrNull(), (Object) null))
      return;
    Singleton<CommonRoot>.GetInstance().isWebRunning = false;
  }

  public static void Add(WebRequest request) => WebQueue.addQueue(WebQueue.requestQueue, request);

  public static int getQueueCount() => WebQueue.requestQueue.Count;

  public static void Get(string path, Action<WebResponse> callback, int loadingType = 0)
  {
    WebQueue.Add(new WebRequest("api/v2/" + path, WebRequest.RequestMethod.GET, string.Empty, callback)
    {
      LoadingType = loadingType
    });
  }

  public static void Post(string path, Action<WebResponse> callback, int loadingType = 0)
  {
    string path1 = !"api/v2/".EndsWith("/") || !path.StartsWith("/") ? "api/v2/" + path : "api/v2/" + path.Substring(1);
    WebQueue.Logger((object) ("Post path : " + path1));
    WebQueue.Add(new WebRequest(path1, WebRequest.RequestMethod.POST, string.Empty, callback)
    {
      LoadingType = loadingType
    });
  }

  public static void Post(
    string path,
    Dictionary<string, object> post,
    Action<WebResponse> callback,
    int loadingType = 0)
  {
    WebQueue.RawPost(!"api/v2/".EndsWith("/") || !path.StartsWith("/") ? "api/v2/" + path : "api/v2/" + path.Substring(1), post, callback, loadingType);
  }

  public static void RawPost(
    string path,
    Dictionary<string, object> post,
    Action<WebResponse> callback,
    int loadingType = 0)
  {
    WebQueue.Logger((object) ("Post path : " + path));
    WebQueue.Add(new WebRequest(path, WebRequest.RequestMethod.POST, Json.Serialize((object) post), callback)
    {
      LoadingType = loadingType
    });
  }

  public static void SilentPost(
    string path,
    Dictionary<string, object> post,
    Action<WebResponse> callback)
  {
    WebQueue.Add(new WebRequest(!"api/v2/".EndsWith("/") || !path.StartsWith("/") ? "api/v2/" + path : "api/v2/" + path.Substring(1), WebRequest.RequestMethod.POST, Json.Serialize((object) post), callback, (Func<WebError, IEnumerator>) (_ => (IEnumerator) null))
    {
      LoadingType = -1
    });
  }

  public static int RequestQueueCount() => WebQueue.requestQueue.Count;

  public static int AuthQueueCount() => WebQueue.authQueue.Count;

  public static void reLogin()
  {
    DDebug.Log("reLogin enqueueAuthMobage");
    WebQueue.enqueueAuthMobage();
  }

  [DebuggerHidden]
  public static IEnumerator RunWorkerMobage()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    WebQueue.\u003CRunWorkerMobage\u003Ec__IteratorB16 mobageCIteratorB16 = new WebQueue.\u003CRunWorkerMobage\u003Ec__IteratorB16();
    return (IEnumerator) mobageCIteratorB16;
  }

  private static void authPost(
    string path,
    Dictionary<string, string> posts,
    Action<WebResponse> successCallback,
    Func<WebError, IEnumerator> failCallback = null)
  {
    WebQueue.Logger((object) ("authPost path : " + path));
    WebRequest request = new WebRequest(path, WebRequest.RequestMethod.POST, Json.Serialize((object) posts), successCallback, failCallback);
    WebQueue.addQueue(WebQueue.authQueue, request);
  }

  private static void authAccessToken(
    Dictionary<string, string> posts,
    Action<WebResponse> successCallback,
    Func<WebError, IEnumerator> failCallback = null)
  {
    string path = "auth/accesstoken";
    WebQueue.Logger((object) ("authPost path : " + path));
    WebRequest request = new WebRequest(path, WebRequest.RequestMethod.POST, Json.Serialize((object) posts), successCallback, failCallback, isAuthAccessToken: true);
    WebQueue.addQueue(WebQueue.authQueue, request);
  }

  public static void testtest2(
    Dictionary<string, string> posts,
    Action<WebResponse> successCallback,
    Func<WebError, IEnumerator> failCallback = null)
  {
    WebRequest request = new WebRequest("test/test2", WebRequest.RequestMethod.POST, Json.Serialize((object) posts), successCallback, failCallback, isAuthDeviceInfo: true);
    WebQueue.addQueue(WebQueue.authQueue, request);
  }

  private static void authDeviceInfo(
    Dictionary<string, string> posts,
    Action<WebResponse> successCallback,
    Func<WebError, IEnumerator> failCallback = null)
  {
    string path = "auth/deviceinfo";
    WebQueue.Logger((object) ("authPost path : " + path));
    WebRequest request = new WebRequest(path, WebRequest.RequestMethod.POST, Json.Serialize((object) posts), successCallback, failCallback, isAuthDeviceInfo: true);
    WebQueue.addQueue(WebQueue.authQueue, request);
  }

  private static void rpcSubmitEnv(
    Dictionary<string, string> posts,
    Action<WebResponse> successCallback,
    Func<WebError, IEnumerator> failCallback = null)
  {
    string path = "rpc/submit/env";
    WebQueue.Logger((object) ("authPost path : " + path));
    WebRequest request = new WebRequest(path, WebRequest.RequestMethod.POST, Json.Serialize((object) posts), successCallback, failCallback, isAuthDeviceInfo: true);
    WebQueue.addQueue(WebQueue.authQueue, request);
  }

  [DebuggerHidden]
  private static IEnumerator processQueueMobage(List<WebRequest> queue)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebQueue.\u003CprocessQueueMobage\u003Ec__IteratorB17()
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
    DDebug.Log(nameof (EnqueueAuthMigrate));
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

  public static void EnqueueRpcSubmitEnv(
    Action<bool> successCallback,
    Func<WebError, IEnumerator> failCallback)
  {
    WebQueue.rpcSubmitEnv(new Dictionary<string, string>()
    {
      ["application_version"] = Revision.ApplicationVersion,
      ["platform"] = "android"
    }, (Action<WebResponse>) (r => successCallback((bool) r.Json["is_submit_env"])), (Func<WebError, IEnumerator>) (e => failCallback(e)));
  }

  private static void enqueueRpcSubmitEnv()
  {
    WebAPI.RpcSubmitEnv((Action<bool>) (is_submit => ServerSelector.SetSubmitEnv(is_submit)));
  }

  private static void enqueueDeviceInfo()
  {
    if (Persist.auth.Exists)
      return;
    WebAPI.AuthDeviceInfo((System.Action) (() => Persist.auth.Flush()));
  }

  private static void enqueueAuthMobage(System.Action callback = null)
  {
    if (!SDK.instance.IsLogined())
    {
      DDebug.Log("enqueueAuthMobage  isLoginFinish = false");
    }
    else
    {
      WebQueue.authToken = SDK.instance.GetToken();
      WebQueue.accountID = SDK.instance.GetPlayID();
      DDebug.Log("enqueueAuthMobage  authToken:" + WebQueue.authToken);
      DDebug.Log("enqueueAuthMobage  accountID:" + WebQueue.accountID);
      if (WebQueue.authToken != string.Empty)
        WebQueue.Logger((object) ("change token before=" + WebQueue.authToken));
      if (callback == null)
        callback = (System.Action) (() => { });
      Dictionary<string, string> posts = new Dictionary<string, string>();
      posts["device_id"] = WebQueue.accountID;
      posts["secret_key"] = WebQueue.authToken;
      DDebug.Log(nameof (enqueueAuthMobage));
      DDebug.Log("device_id:" + WebQueue.accountID);
      DDebug.Log("secret_key:" + WebQueue.authToken);
      WebQueue.authAccessToken(posts, (Action<WebResponse>) (r1 =>
      {
        callback();
        WebQueue.Logger((object) ("change token after=" + WebQueue.authToken));
      }));
    }
  }

  private static void enqueueAuth(System.Action callback = null)
  {
    if (!Persist.auth.Exists)
      return;
    if (WebQueue.authToken != string.Empty)
      WebQueue.Logger((object) ("change token before=" + WebQueue.authToken));
    if (callback == null)
      callback = (System.Action) (() => { });
    WebQueue.authToken = string.Empty;
    Dictionary<string, string> posts = new Dictionary<string, string>();
    if (Persist.auth.Data.IsNeedAuthRegister())
    {
      posts["secret_key"] = Persist.auth.Data.SecretKey;
      posts["udid"] = Persist.auth.Data.UUID;
      WebQueue.authPost("auth/register", posts, (Action<WebResponse>) (r1 => WebQueue.authAccessToken(new Dictionary<string, string>()
      {
        ["device_id"] = (string) r1.Json["device_id"],
        ["secret_key"] = Persist.auth.Data.SecretKey
      }, (Action<WebResponse>) (r2 =>
      {
        WebQueue.authToken = (string) r2.Json["access_token"];
        Persist.auth.Data.DeviceID = (string) r1.Json["device_id"];
        Persist.auth.Flush();
        callback();
        WebQueue.Logger((object) ("regist token after=" + WebQueue.authToken));
      }))));
    }
    else
    {
      posts["device_id"] = Persist.auth.Data.DeviceID;
      posts["secret_key"] = Persist.auth.Data.SecretKey;
      WebQueue.authAccessToken(posts, (Action<WebResponse>) (r1 =>
      {
        WebQueue.authToken = (string) r1.Json["access_token"];
        callback();
        WebQueue.Logger((object) ("change token after=" + WebQueue.authToken));
      }));
    }
  }

  public static HTTP.Request makeRawRequest(WebRequest request)
  {
    WebQueue.authToken = SDK.instance.GetToken();
    string url = request.GetURL();
    DDebug.Log("request.GetURL() : " + url);
    HTTP.Request request1;
    if (request.Method == WebRequest.RequestMethod.POST)
    {
      request1 = new HTTP.Request("POST", url);
      request1.Text = request.PostData;
    }
    else
      request1 = new HTTP.Request("GET", url);
    request1.headers.Set("Content-Type", "application/json; charset=utf-8");
    if (WebQueue.authToken != string.Empty)
    {
      DDebug.Log("Authorization: dumi: " + WebQueue.authToken);
      request1.headers.Set("Authorization", "gumi " + WebQueue.authToken);
    }
    request1.headers.Set("User-Agent", DeviceManager.GetUserAgent());
    request1.headers.Set("X-Device-API-Version", "2");
    request1.headers.Set("X-Device-Version", DeviceManager.GetBundleVersion());
    request1.headers.Set("X-Device-ApplicationVersion", Revision.ApplicationVersion);
    request1.headers.Set("X-Device-DLCVersion", Revision.DLCVersion);
    request1.headers.Set("X-Device-Language-Locale", DeviceManager.GetLanguageLocale());
    request1.headers.Set("X-Device-TimeZone", DeviceManager.GetTimeZone());
    request1.headers.Set("X-GUMI-TRANSACTION", request.GumiTransactionId);
    request1.headers.Set("X-Device-Platform", "android");
    return request1;
  }

  private static bool isSuccessResponse(HTTP.Request rawRequest, HTTP.Response rawResponse)
  {
    if (rawRequest == null)
    {
      WebQueue.Logger((object) "Queue checkError < rawRequest > is Null!");
      return false;
    }
    if (rawResponse == null)
    {
      WebQueue.Logger((object) "Queue checkError < rawResponse > is Null!");
      return false;
    }
    if (rawRequest.exception != null || rawResponse.status != 200)
      return false;
    string str = rawResponse.headers.Get("Content-Type");
    return !string.IsNullOrEmpty(str) && str.StartsWith("application/json");
  }

  private static void reloginBySessionInvalid()
  {
    WebQueue.ClearRequestQueue();
    ModalWindow.Show(Consts.GetInstance().prompt, Consts.GetInstance().login_failure_back, (System.Action) (() => SDK.instance.Exit()));
  }

  [DebuggerHidden]
  private static IEnumerator callFailCallback(WebError error)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebQueue.\u003CcallFailCallback\u003Ec__IteratorB18()
    {
      error = error,
      \u003C\u0024\u003Eerror = error
    };
  }

  private static bool IsWebRunning()
  {
    return WebQueue.requestQueue.Where<WebRequest>((Func<WebRequest, bool>) (x => x.RestRetryCount > 0 && x.LoadingType >= 0)).Count<WebRequest>() + WebQueue.authQueue.Where<WebRequest>((Func<WebRequest, bool>) (x => x.RestRetryCount > 0)).Count<WebRequest>() > 0;
  }

  private static int activeAllRequestCount()
  {
    return WebQueue.requestQueue.Where<WebRequest>((Func<WebRequest, bool>) (x => x.RestRetryCount > 0)).Count<WebRequest>() + WebQueue.authQueue.Where<WebRequest>((Func<WebRequest, bool>) (x => x.RestRetryCount > 0)).Count<WebRequest>();
  }

  [DebuggerHidden]
  private static IEnumerator defaultFailCallback(WebError error)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WebQueue.\u003CdefaultFailCallback\u003Ec__IteratorB19()
    {
      error = error,
      \u003C\u0024\u003Eerror = error
    };
  }
}
