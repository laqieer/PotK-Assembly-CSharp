// Decompiled with JetBrains decompiler
// Type: WebError
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class WebError
{
  public readonly WebResponse Response;
  public readonly WebRequest Request;
  public readonly int Status;

  public WebError(WebRequest request, WebResponse response)
  {
    this.Request = request;
    this.Response = response;
    this.Status = response.Status;
  }

  private WebError(WebRequest request, string message)
  {
    this.Request = request;
    this.Response = WebResponse.Zero();
    this.Response.Body = message;
    this.Status = this.Response.Status;
  }

  private WebError(WebRequest request, string message, int status)
  {
    this.Request = request;
    this.Response = WebResponse.Zero();
    this.Response.Body = message;
    this.Status = status;
  }

  public bool HasResponse() => this.Status > 0;

  public bool IsClientError() => this.Status >= 400 && this.Status < 500;

  public bool IsServerError() => this.Status >= 500 && this.Status < 600;

  public string Show()
  {
    return string.Format("{0} {1} {2}", (object) this.Status, (object) this.Request.Path, (object) this.Response.Body);
  }

  public static WebError ClientError4xx(WebRequest request, WebResponse response)
  {
    return new WebError(request, response);
  }

  public static WebError ServerError5xx(WebRequest request, WebResponse response)
  {
    return new WebError(request, response);
  }

  public static WebError Timeout(WebRequest request)
  {
    return new WebError(request, nameof (Timeout), 7000);
  }

  public static WebError RetryOut(WebRequest request)
  {
    return new WebError(request, nameof (RetryOut), 7001);
  }

  public static WebError ResponseError(WebRequest request)
  {
    return new WebError(request, nameof (ResponseError), 7002);
  }

  public static WebError ResponseException(WebRequest request, Exception exception)
  {
    if (exception != null)
      Debug.LogException(exception);
    return new WebError(request, "InternalError", 7003);
  }
}
