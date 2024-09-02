// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Example.GameGroups
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Facebook.Unity.Example
{
  internal class GameGroups : MenuBase
  {
    private string gamerGroupName = "Test group";
    private string gamerGroupDesc = "Test group for testing.";
    private string gamerGroupPrivacy = "closed";
    private string gamerGroupCurrentGroup = string.Empty;

    protected override void GetGui()
    {
      if (this.Button("Game Group Create - Closed"))
        FB.GameGroupCreate("Test game group", "Test description", callback: new FacebookDelegate<IGroupCreateResult>(((MenuBase) this).HandleResult));
      if (this.Button("Game Group Create - Open"))
        FB.GameGroupCreate("Test game group", "Test description", "OPEN", new FacebookDelegate<IGroupCreateResult>(((MenuBase) this).HandleResult));
      this.LabelAndTextField("Group Name", ref this.gamerGroupName);
      this.LabelAndTextField("Group Description", ref this.gamerGroupDesc);
      this.LabelAndTextField("Group Privacy", ref this.gamerGroupPrivacy);
      if (this.Button("Call Create Group Dialog"))
        this.CallCreateGroupDialog();
      this.LabelAndTextField("Group To Join", ref this.gamerGroupCurrentGroup);
      bool enabled = GUI.enabled;
      GUI.enabled = enabled && !string.IsNullOrEmpty(this.gamerGroupCurrentGroup);
      if (this.Button("Call Join Group Dialog"))
        this.CallJoinGroupDialog();
      GUI.enabled = enabled && FB.IsLoggedIn;
      if (this.Button("Get All App Managed Groups"))
        this.CallFbGetAllOwnedGroups();
      if (this.Button("Get Gamer Groups Logged in User Belongs to"))
        this.CallFbGetUserGroups();
      if (this.Button("Make Group Post As User"))
        this.CallFbPostToGamerGroup();
      GUI.enabled = enabled;
    }

    private void GroupCreateCB(IGroupCreateResult result)
    {
      this.HandleResult((IResult) result);
      if (result.GroupId == null)
        return;
      this.gamerGroupCurrentGroup = result.GroupId;
    }

    private void GetAllGroupsCB(IGraphResult result)
    {
      if (!string.IsNullOrEmpty(result.RawResult))
      {
        this.LastResponse = result.RawResult;
        IDictionary<string, object> resultDictionary = result.ResultDictionary;
        if (resultDictionary.ContainsKey("data"))
        {
          List<object> objectList = (List<object>) resultDictionary["data"];
          if (objectList.Count > 0)
            this.gamerGroupCurrentGroup = (string) ((Dictionary<string, object>) objectList[0])["id"];
        }
      }
      if (string.IsNullOrEmpty(result.Error))
        return;
      this.LastResponse = result.Error;
    }

    private void CallFbGetAllOwnedGroups()
    {
      FB.API(FB.AppId + "/groups", HttpMethod.GET, new FacebookDelegate<IGraphResult>(this.GetAllGroupsCB));
    }

    private void CallFbGetUserGroups()
    {
      FB.API("/me/groups?parent=" + FB.AppId, HttpMethod.GET, new FacebookDelegate<IGraphResult>(((MenuBase) this).HandleResult));
    }

    private void CallCreateGroupDialog()
    {
      FB.GameGroupCreate(this.gamerGroupName, this.gamerGroupDesc, this.gamerGroupPrivacy, new FacebookDelegate<IGroupCreateResult>(this.GroupCreateCB));
    }

    private void CallJoinGroupDialog()
    {
      FB.GameGroupJoin(this.gamerGroupCurrentGroup, new FacebookDelegate<IGroupJoinResult>(((MenuBase) this).HandleResult));
    }

    private void CallFbPostToGamerGroup()
    {
      FB.API(this.gamerGroupCurrentGroup + "/feed", HttpMethod.POST, new FacebookDelegate<IGraphResult>(((MenuBase) this).HandleResult), (IDictionary<string, string>) new Dictionary<string, string>()
      {
        ["message"] = "herp derp a post"
      });
    }
  }
}
