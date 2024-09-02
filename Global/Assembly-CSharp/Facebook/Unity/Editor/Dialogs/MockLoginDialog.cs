// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Editor.Dialogs.MockLoginDialog
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
      GUILayout.Space(10f);
      if (GUILayout.Button("Find Access Token", new GUILayoutOption[0]))
        Application.OpenURL(string.Format("https://developers.facebook.com/tools/accesstoken/?app_id={0}", (object) FB.AppId));
      GUILayout.Space(20f);
    }

    protected override void SendSuccessResult()
    {
      if (string.IsNullOrEmpty(this.accessToken))
        this.SendErrorResult("Empty Access token string");
      else
        FB.API("/me?fields=id&access_token=" + this.accessToken, HttpMethod.GET, (FacebookDelegate<IGraphResult>) (graphResult =>
        {
          if (!string.IsNullOrEmpty(graphResult.Error))
          {
            this.SendErrorResult("Graph API error: " + graphResult.Error);
          }
          else
          {
            string facebookID = graphResult.ResultDictionary["id"] as string;
            FB.API("/me/permissions?access_token=" + this.accessToken, HttpMethod.GET, (FacebookDelegate<IGraphResult>) (permResult =>
            {
              if (!string.IsNullOrEmpty(permResult.Error))
              {
                this.SendErrorResult("Graph API error: " + permResult.Error);
              }
              else
              {
                List<string> permissions = new List<string>();
                List<string> stringList = new List<string>();
                foreach (Dictionary<string, object> dictionary in permResult.ResultDictionary["data"] as List<object>)
                {
                  if (dictionary["status"] as string == "granted")
                    permissions.Add(dictionary["permission"] as string);
                  else
                    stringList.Add(dictionary["permission"] as string);
                }
                IDictionary<string, object> dictionary2 = (IDictionary<string, object>) Json.Deserialize(new AccessToken(this.accessToken, facebookID, DateTime.UtcNow.AddDays(60.0), (IEnumerable<string>) permissions, new DateTime?(DateTime.UtcNow)).ToJson());
                dictionary2.Add("granted_permissions", (object) permissions);
                dictionary2.Add("declined_permissions", (object) stringList);
                if (!string.IsNullOrEmpty(this.CallbackID))
                  dictionary2["callback_id"] = (object) this.CallbackID;
                if (this.Callback == null)
                  return;
                this.Callback(new ResultContainer(dictionary2));
              }
            }));
          }
        }));
    }
  }
}
