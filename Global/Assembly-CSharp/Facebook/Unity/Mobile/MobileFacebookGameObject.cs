// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Mobile.MobileFacebookGameObject
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
      this.MobileFacebook.OnAppInviteComplete(new ResultContainer(message));
    }

    public void OnFetchDeferredAppLinkComplete(string message)
    {
      this.MobileFacebook.OnFetchDeferredAppLinkComplete(new ResultContainer(message));
    }

    public void OnRefreshCurrentAccessTokenComplete(string message)
    {
      this.MobileFacebook.OnRefreshCurrentAccessTokenComplete(new ResultContainer(message));
    }
  }
}
