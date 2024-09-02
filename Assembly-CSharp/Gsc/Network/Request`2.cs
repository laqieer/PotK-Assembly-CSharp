// Decompiled with JetBrains decompiler
// Type: Gsc.Network.Request`2
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using MiniJSON;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gsc.Network
{
  public abstract class Request<TRequest, TResponse> : IRequest
    where TRequest : Request<TRequest, TResponse>
    where TResponse : Response<TResponse>
  {
    public readonly CustomHeaders CustomHeaders;
    private readonly string ___request_id;
    protected WebTask<TRequest, TResponse> ___task;

    public bool isDone => this.___task != null && this.___task.isDone;

    public Request()
    {
      this.___request_id = Guid.NewGuid().ToString("N");
      this.CustomHeaders = new CustomHeaders(this.___request_id);
    }

    public string GetRequestID() => this.___request_id;

    public virtual string GetHost() => SDK.Configuration.Env.ServerUrl;

    public virtual string GetUrl() => this.GetHost() + this.GetPath();

    public abstract string GetPath();

    public abstract string GetMethod();

    protected virtual Dictionary<string, object> GetParameters() => (Dictionary<string, object>) null;

    public virtual byte[] GetPayload()
    {
      Dictionary<string, object> parameters = this.GetParameters();
      return parameters != null ? Encoding.UTF8.GetBytes(Json.Serialize((object) parameters)) : (byte[]) null;
    }

    public virtual Type GetErrorResponseType() => typeof (ErrorResponse);

    public virtual WebTaskResult InquireResult(
      WebTaskResult result,
      WebInternalResponse response)
    {
      return result;
    }

    public void OnTask(WebTask<TRequest, TResponse> task)
    {
      if (this.___task != null)
        return;
      this.___task = task;
    }

    IWebTask IRequest.Cast() => (IWebTask) this.Cast();

    IWebTask IRequest.Send() => (IWebTask) this.Send();

    public void Retry()
    {
      if (this.___task == null)
        return;
      this.___task.Retry();
    }

    public WebTask<TRequest, TResponse> Cast() => this.GetTask(WebTaskAttribute.Silent | WebTaskAttribute.Parallel);

    public WebTask<TRequest, TResponse> Send() => this.GetTask(WebTaskAttribute.Reliable | WebTaskAttribute.Parallel);

    public WebTask<TRequest, TResponse> SerialSend() => this.GetTask(WebTaskAttribute.Reliable);

    public WebTask<TRequest, TResponse> GetTask(WebTaskAttribute attributes) => WebTask<TRequest, TResponse>.Send((TRequest) this, attributes);

    public TResponse GetResponse()
    {
      if (!this.isDone)
        throw new RequestException("Still processing this request.");
      return this.___task.Response;
    }

    public IErrorResponse GetError()
    {
      if (!this.isDone)
        throw new RequestException("Still processing this request.");
      return this.___task.error;
    }

    public WebTaskResult GetResult()
    {
      if (!this.isDone)
        throw new RequestException("Still processing this request.");
      return this.___task.Result;
    }
  }
}
