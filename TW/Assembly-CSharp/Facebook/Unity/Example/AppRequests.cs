// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Example.AppRequests
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#nullable disable
namespace Facebook.Unity.Example
{
  internal class AppRequests : MenuBase
  {
    private string requestMessage = string.Empty;
    private string requestTo = string.Empty;
    private string requestFilter = string.Empty;
    private string requestExcludes = string.Empty;
    private string requestMax = string.Empty;
    private string requestData = string.Empty;
    private string requestTitle = string.Empty;
    private string requestObjectID = string.Empty;
    private int selectedAction;
    private string[] actionTypeStrings = new string[4]
    {
      "NONE",
      OGActionType.SEND.ToString(),
      OGActionType.ASKFOR.ToString(),
      OGActionType.TURN.ToString()
    };

    protected override void GetGui()
    {
      if (this.Button("Select - Filter None"))
      {
        FacebookDelegate<IAppRequestResult> callback = new FacebookDelegate<IAppRequestResult>(((MenuBase) this).HandleResult);
        FB.AppRequest("Test Message", data: string.Empty, title: string.Empty, callback: callback);
      }
      if (this.Button("Select - Filter app_users"))
        FB.AppRequest("Test Message", filters: (IEnumerable<object>) new List<object>()
        {
          (object) "app_users"
        }, maxRecipients: new int?(0), data: string.Empty, title: string.Empty, callback: new FacebookDelegate<IAppRequestResult>(((MenuBase) this).HandleResult));
      if (this.Button("Select - Filter app_non_users"))
        FB.AppRequest("Test Message", filters: (IEnumerable<object>) new List<object>()
        {
          (object) "app_non_users"
        }, maxRecipients: new int?(0), data: string.Empty, title: string.Empty, callback: new FacebookDelegate<IAppRequestResult>(((MenuBase) this).HandleResult));
      this.LabelAndTextField("Message: ", ref this.requestMessage);
      this.LabelAndTextField("To (optional): ", ref this.requestTo);
      this.LabelAndTextField("Filter (optional): ", ref this.requestFilter);
      this.LabelAndTextField("Exclude Ids (optional): ", ref this.requestExcludes);
      this.LabelAndTextField("Filters: ", ref this.requestExcludes);
      this.LabelAndTextField("Max Recipients (optional): ", ref this.requestMax);
      this.LabelAndTextField("Data (optional): ", ref this.requestData);
      this.LabelAndTextField("Title (optional): ", ref this.requestTitle);
      GUILayout.BeginHorizontal(new GUILayoutOption[0]);
      GUILayout.Label("Request Action (optional): ", this.LabelStyle, new GUILayoutOption[1]
      {
        GUILayout.MaxWidth(200f * this.ScaleFactor)
      });
      this.selectedAction = GUILayout.Toolbar(this.selectedAction, this.actionTypeStrings, this.ButtonStyle, new GUILayoutOption[2]
      {
        GUILayout.MinHeight(60f * this.ScaleFactor),
        GUILayout.MaxWidth((float) (ConsoleBase.MainWindowWidth - 150))
      });
      GUILayout.EndHorizontal();
      this.LabelAndTextField("Request Object ID (optional): ", ref this.requestObjectID);
      if (!this.Button("Custom App Request"))
        return;
      OGActionType? selectedOgActionType = this.GetSelectedOGActionType();
      if (selectedOgActionType.HasValue)
      {
        string requestMessage = this.requestMessage;
        int actionType = (int) selectedOgActionType.Value;
        string requestObjectId = this.requestObjectID;
        string[] to;
        if (this.requestTo != null)
          to = this.requestTo.Split(',');
        else
          to = (string[]) null;
        string requestData = this.requestData;
        string requestTitle = this.requestTitle;
        FacebookDelegate<IAppRequestResult> callback = new FacebookDelegate<IAppRequestResult>(((MenuBase) this).HandleResult);
        FB.AppRequest(requestMessage, (OGActionType) actionType, requestObjectId, (IEnumerable<string>) to, requestData, requestTitle, callback);
      }
      else
      {
        string requestMessage = this.requestMessage;
        string[] to;
        if (string.IsNullOrEmpty(this.requestTo))
          to = (string[]) null;
        else
          to = this.requestTo.Split(',');
        List<object> filters;
        if (string.IsNullOrEmpty(this.requestFilter))
          filters = (List<object>) null;
        else
          filters = this.requestFilter.Split(',').OfType<object>().ToList<object>();
        string[] excludeIds;
        if (string.IsNullOrEmpty(this.requestExcludes))
          excludeIds = (string[]) null;
        else
          excludeIds = this.requestExcludes.Split(',');
        int? maxRecipients = new int?(!string.IsNullOrEmpty(this.requestMax) ? int.Parse(this.requestMax) : 0);
        string requestData = this.requestData;
        string requestTitle = this.requestTitle;
        FacebookDelegate<IAppRequestResult> callback = new FacebookDelegate<IAppRequestResult>(((MenuBase) this).HandleResult);
        FB.AppRequest(requestMessage, (IEnumerable<string>) to, (IEnumerable<object>) filters, (IEnumerable<string>) excludeIds, maxRecipients, requestData, requestTitle, callback);
      }
    }

    private OGActionType? GetSelectedOGActionType()
    {
      string actionTypeString = this.actionTypeStrings[this.selectedAction];
      if (actionTypeString == OGActionType.SEND.ToString())
        return new OGActionType?(OGActionType.SEND);
      if (actionTypeString == OGActionType.ASKFOR.ToString())
        return new OGActionType?(OGActionType.ASKFOR);
      return actionTypeString == OGActionType.TURN.ToString() ? new OGActionType?(OGActionType.TURN) : new OGActionType?();
    }
  }
}
