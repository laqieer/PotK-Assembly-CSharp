// Decompiled with JetBrains decompiler
// Type: WebRequest
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections;

#nullable disable
public class WebRequest
{
  public const int DEFAULT_RETRY_COUNT = 1;
  public readonly string Path;
  public readonly string PostData;
  public readonly string GumiTransactionId;
  public readonly WebRequest.RequestMethod Method;
  public readonly Action<WebResponse> SuccessCallback;
  public readonly Func<WebError, IEnumerator> FailCallbackOrNull;
  public readonly bool IsAuthAccessToken;
  public readonly bool IsAuthDeviceInfo;
  public bool isDone;
  public WebResponse Result;
  public int RestRetryCount;
  public int LoadingType;
  private bool enableCallback;

  public WebRequest(
    string path,
    WebRequest.RequestMethod method,
    string postData,
    Action<WebResponse> successCallback,
    Func<WebError, IEnumerator> failCallback = null,
    int retryCount = 1,
    bool isAuthAccessToken = false,
    bool isAuthDeviceInfo = false)
  {
    this.Path = path;
    this.PostData = postData;
    this.Method = method;
    this.SuccessCallback = successCallback;
    this.FailCallbackOrNull = failCallback;
    this.PostData = postData = method != WebRequest.RequestMethod.POST ? string.Empty : postData;
    this.RestRetryCount = retryCount;
    this.IsAuthAccessToken = isAuthAccessToken;
    this.IsAuthDeviceInfo = isAuthDeviceInfo;
    this.enableCallback = true;
    this.GumiTransactionId = Guid.NewGuid().ToString();
  }

  public string GetURL() => WebRequest.BaseURL + this.Path;

  public void DropPacketAndIgnoreCallback()
  {
    this.RestRetryCount = 0;
    this.enableCallback = false;
  }

  public bool EnableCallback() => this.enableCallback;

  public static string BaseURL => ServerSelector.ApiUrl;

  public enum RequestMethod
  {
    POST,
    GET,
  }
}
