// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Canvas.CanvasFacebookGameObject
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace Facebook.Unity.Canvas
{
  internal class CanvasFacebookGameObject : 
    FacebookGameObject,
    ICanvasFacebookCallbackHandler,
    IFacebookCallbackHandler
  {
    protected ICanvasFacebookImplementation CanvasFacebookImpl
    {
      get => (ICanvasFacebookImplementation) this.Facebook;
    }

    public void OnPayComplete(string result)
    {
      this.CanvasFacebookImpl.OnPayComplete(new ResultContainer(result));
    }

    public void OnFacebookAuthResponseChange(string message)
    {
      this.CanvasFacebookImpl.OnFacebookAuthResponseChange(new ResultContainer(message));
    }

    public void OnUrlResponse(string message) => this.CanvasFacebookImpl.OnUrlResponse(message);

    public void OnHideUnity(bool hide) => this.CanvasFacebookImpl.OnHideUnity(hide);

    protected override void OnAwake()
    {
      GameObject gameObject = new GameObject("FacebookJsBridge");
      gameObject.AddComponent<JsBridge>();
      gameObject.transform.parent = ((Component) this).gameObject.transform;
    }
  }
}
