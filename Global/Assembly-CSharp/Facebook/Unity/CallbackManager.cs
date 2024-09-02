// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.CallbackManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace Facebook.Unity
{
  internal class CallbackManager
  {
    private IDictionary<string, object> facebookDelegates = (IDictionary<string, object>) new Dictionary<string, object>();
    private int nextAsyncId;

    public string AddFacebookDelegate<T>(FacebookDelegate<T> callback) where T : IResult
    {
      if (callback == null)
        return (string) null;
      ++this.nextAsyncId;
      this.facebookDelegates.Add(this.nextAsyncId.ToString(), (object) callback);
      return this.nextAsyncId.ToString();
    }

    public void OnFacebookResponse(IInternalResult result)
    {
      object callback;
      if (result == null || result.CallbackId == null || !this.facebookDelegates.TryGetValue(result.CallbackId, out callback))
        return;
      CallbackManager.CallCallback(callback, (IResult) result);
      this.facebookDelegates.Remove(result.CallbackId);
    }

    private static void CallCallback(object callback, IResult result)
    {
      if (callback != null && result != null && !CallbackManager.TryCallCallback<IAppRequestResult>(callback, result) && !CallbackManager.TryCallCallback<IShareResult>(callback, result) && !CallbackManager.TryCallCallback<IGroupCreateResult>(callback, result) && !CallbackManager.TryCallCallback<IGroupJoinResult>(callback, result) && !CallbackManager.TryCallCallback<IPayResult>(callback, result) && !CallbackManager.TryCallCallback<IAppInviteResult>(callback, result) && !CallbackManager.TryCallCallback<IAppLinkResult>(callback, result) && !CallbackManager.TryCallCallback<ILoginResult>(callback, result) && !CallbackManager.TryCallCallback<IAccessTokenRefreshResult>(callback, result))
        throw new NotSupportedException("Unexpected result type: " + callback.GetType().FullName);
    }

    private static bool TryCallCallback<T>(object callback, IResult result) where T : IResult
    {
      if (!(callback is FacebookDelegate<T> facebookDelegate))
        return false;
      facebookDelegate((T) result);
      return true;
    }
  }
}
