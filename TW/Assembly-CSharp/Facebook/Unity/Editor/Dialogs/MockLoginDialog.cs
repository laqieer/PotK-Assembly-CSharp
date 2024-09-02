// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Editor.Dialogs.MockLoginDialog
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using Facebook.MiniJSON;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Facebook.Unity.Editor.Dialogs
{
  internal class MockLoginDialog : EditorFacebookMockDialog
  {
    private string accessToken = string.Empty;

    public IEnumerable<string> Permissions { private get; set; }

    protected override float WindowHeight => 592f;

    protected override string DialogTitle => "Mock Login Dialog";

    protected override void DoGui()
    {
      GUILayout.BeginHorizontal(new GUILayoutOption[0]);
      GUILayout.Label("User Access Token:", new GUILayoutOption[0]);
      this.accessToken = GUILayout.TextField(this.accessToken, GUI.skin.textArea, new GUILayoutOption[1]
      {
        GUILayout.MinWidth(400f)
      });
      GUILayout.EndHorizontal();
      GUILayout.Space(20f);
      if (!GUILayout.Button("Find Access Token", new GUILayoutOption[0]))
        return;
      Application.OpenURL(string.Format("https://developers.facebook.com/tools/accesstoken/?app_id={0}", (object) FB.AppId));
    }

    protected override void SendSuccessResult()
    {
      if (string.IsNullOrEmpty(this.accessToken))
      {
        this.SendErrorResult("Empty Access token string");
      }
      else
      {
        IDictionary<string, object> dictionary = (IDictionary<string, object>) Json.Deserialize(new AccessToken(this.accessToken, "MockUserId", DateTime.Now.AddDays(60.0), this.Permissions).ToJson());
        if (!string.IsNullOrEmpty(this.CallbackID))
          dictionary["callback_id"] = (object) this.CallbackID;
        if (this.Callback == null)
          return;
        this.Callback(Json.Serialize((object) dictionary));
      }
    }
  }
}
