// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Example.AppInvites
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace Facebook.Unity.Example
{
  internal class AppInvites : MenuBase
  {
    protected override void GetGui()
    {
      if (this.Button("Android Invite"))
      {
        this.Status = "Logged FB.AppEvent";
        FB.Mobile.AppInvite(new Uri("https://fb.me/892708710750483"), callback: new FacebookDelegate<IAppInviteResult>(((MenuBase) this).HandleResult));
      }
      if (this.Button("Android Invite With Custom Image"))
      {
        this.Status = "Logged FB.AppEvent";
        FB.Mobile.AppInvite(new Uri("https://fb.me/892708710750483"), new Uri("http://i.imgur.com/zkYlB.jpg"), new FacebookDelegate<IAppInviteResult>(((MenuBase) this).HandleResult));
      }
      if (this.Button("iOS Invite"))
      {
        this.Status = "Logged FB.AppEvent";
        FB.Mobile.AppInvite(new Uri("https://fb.me/810530068992919"), callback: new FacebookDelegate<IAppInviteResult>(((MenuBase) this).HandleResult));
      }
      if (!this.Button("iOS Invite With Custom Image"))
        return;
      this.Status = "Logged FB.AppEvent";
      FB.Mobile.AppInvite(new Uri("https://fb.me/810530068992919"), new Uri("http://i.imgur.com/zkYlB.jpg"), new FacebookDelegate<IAppInviteResult>(((MenuBase) this).HandleResult));
    }
  }
}
