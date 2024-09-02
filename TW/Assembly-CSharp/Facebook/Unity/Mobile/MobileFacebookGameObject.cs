// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Mobile.MobileFacebookGameObject
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

#nullable disable
namespace Facebook.Unity.Mobile
{
  internal abstract class MobileFacebookGameObject : 
    FacebookGameObject,
    IFacebookCallbackHandler,
    IMobileFacebookCallbackHandler
  {
    private IMobileFacebookImplementation MobileFacebook
    {
      get => (IMobileFacebookImplementation) this.Facebook;
    }

    public void OnAppInviteComplete(string message)
    {
      this.MobileFacebook.OnAppInviteComplete(message);
    }

    public void OnFetchDeferredAppLinkComplete(string message)
    {
      this.MobileFacebook.OnFetchDeferredAppLinkComplete(message);
    }
  }
}
