// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Canvas.CanvasFacebookGameObject
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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

    public void OnPayComplete(string result) => this.CanvasFacebookImpl.OnPayComplete(result);

    public void OnFacebookAuthResponseChange(string message)
    {
      this.CanvasFacebookImpl.OnFacebookAuthResponseChange(message);
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
