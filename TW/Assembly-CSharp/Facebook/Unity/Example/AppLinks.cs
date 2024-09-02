// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Example.AppLinks
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

#nullable disable
namespace Facebook.Unity.Example
{
  internal class AppLinks : MenuBase
  {
    protected override void GetGui()
    {
      if (this.Button("Get App Link"))
        FB.GetAppLink(new FacebookDelegate<IAppLinkResult>(((MenuBase) this).HandleResult));
      if (!Constants.IsMobile || !this.Button("Fetch Deferred App Link"))
        return;
      FB.Mobile.FetchDeferredAppLinkData(new FacebookDelegate<IAppLinkResult>(((MenuBase) this).HandleResult));
    }
  }
}
