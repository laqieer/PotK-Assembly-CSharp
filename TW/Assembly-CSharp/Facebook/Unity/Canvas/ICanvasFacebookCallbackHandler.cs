// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

#nullable disable
namespace Facebook.Unity.Canvas
{
  internal interface ICanvasFacebookCallbackHandler : IFacebookCallbackHandler
  {
    void OnPayComplete(string message);

    void OnFacebookAuthResponseChange(string message);

    void OnUrlResponse(string message);

    void OnHideUnity(bool hide);
  }
}
