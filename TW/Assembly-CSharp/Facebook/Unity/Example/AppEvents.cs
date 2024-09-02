// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Example.AppEvents
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
namespace Facebook.Unity.Example
{
  internal class AppEvents : MenuBase
  {
    protected override void GetGui()
    {
      if (!this.Button("Log FB App Event"))
        return;
      this.Status = "Logged FB.AppEvent";
      FB.LogAppEvent("fb_mobile_achievement_unlocked", parameters: new Dictionary<string, object>()
      {
        {
          "fb_description",
          (object) "Clicked 'Log AppEvent' button"
        }
      });
      LogView.AddLog("You may see results showing up at https://www.facebook.com/analytics/" + FB.AppId);
    }
  }
}
