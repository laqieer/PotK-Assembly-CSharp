// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Example.MainMenu_Original
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#nullable disable
namespace Facebook.Unity.Example
{
  internal sealed class MainMenu_Original : MenuBase
  {
    protected override bool ShowBackButton() => false;

    protected override void GetGui()
    {
      bool enabled1 = GUI.enabled;
      if (this.Button("FB.Init"))
      {
        FB.Init(new InitDelegate(this.OnInitComplete), new HideUnityDelegate(this.OnHideUnity));
        this.Status = "FB.Init() called with " + FB.AppId;
      }
      GUILayout.BeginHorizontal(new GUILayoutOption[0]);
      GUI.enabled = enabled1 && FB.IsInitialized;
      if (this.Button("Login"))
      {
        this.CallFBLogin();
        this.Status = "Login called";
      }
      GUI.enabled = FB.IsLoggedIn;
      if (this.Button("Get publish_actions"))
      {
        this.CallFBLoginForPublish();
        this.Status = "Login (for publish_actions) called";
      }
      if (this.Button("Logout"))
      {
        this.CallFBLogout();
        this.Status = "Logout called";
      }
      GUILayout.EndHorizontal();
      GUI.enabled = enabled1 && FB.IsInitialized;
      if (this.Button("Share Dialog"))
        this.SwitchMenu(typeof (DialogShare));
      bool enabled2 = GUI.enabled;
      GUI.enabled = enabled1 && AccessToken.CurrentAccessToken != null && AccessToken.CurrentAccessToken.Permissions.Contains<string>("publish_actions");
      if (this.Button("Game Groups"))
        this.SwitchMenu(typeof (GameGroups));
      GUI.enabled = enabled2;
      if (this.Button("App Requests"))
        this.SwitchMenu(typeof (AppRequests));
      if (this.Button("Graph Request"))
        this.SwitchMenu(typeof (GraphRequest));
      if (Constants.IsWeb && this.Button("Pay"))
        this.SwitchMenu(typeof (Pay));
      if (this.Button("App Events"))
        this.SwitchMenu(typeof (AppEvents));
      if (this.Button("App Links"))
        this.SwitchMenu(typeof (AppLinks));
      if (Constants.IsMobile && this.Button("App Invites"))
        this.SwitchMenu(typeof (AppInvites));
      GUI.enabled = enabled1;
    }

    private void CallFBLogin()
    {
      FB.LogInWithReadPermissions((IEnumerable<string>) new List<string>()
      {
        "public_profile",
        "email",
        "user_friends"
      }, new FacebookDelegate<ILoginResult>(((MenuBase) this).HandleResult));
    }

    private void CallFBLoginForPublish()
    {
      FB.LogInWithPublishPermissions((IEnumerable<string>) new List<string>()
      {
        "publish_actions"
      }, new FacebookDelegate<ILoginResult>(((MenuBase) this).HandleResult));
    }

    private void CallFBLogout() => FB.LogOut();

    private void OnInitComplete()
    {
      this.Status = "Success - Check logk for details";
      this.LastResponse = "Success Response: OnInitComplete Called\n";
      LogView.AddLog("OnInitComplete Called");
    }

    private void OnHideUnity(bool isGameShown)
    {
      this.Status = "Success - Check logk for details";
      this.LastResponse = string.Format("Success Response: OnHideUnity Called {0}\n", (object) isGameShown);
      LogView.AddLog("Is game shown: " + (object) isGameShown);
    }
  }
}
