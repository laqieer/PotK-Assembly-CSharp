// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Editor.EditorFacebookMockDialog
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using Facebook.MiniJSON;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Facebook.Unity.Editor
{
  internal abstract class EditorFacebookMockDialog : MonoBehaviour
  {
    private float windowHeight = 200f;
    private GUIStyle greyButton;

    public EditorFacebookMockDialog.OnComplete Callback { protected get; set; }

    public string CallbackID { protected get; set; }

    protected abstract float WindowHeight { get; }

    protected abstract string DialogTitle { get; }

    public void OnGUI()
    {
      float num1 = (float) (Screen.height / 2) - this.WindowHeight / 2f;
      float num2 = (float) (Screen.width / 2) - this.WindowHeight / 2f;
      this.greyButton = GUI.skin.button;
      // ISSUE: method pointer
      GUI.ModalWindow(((Object) this).GetHashCode(), new Rect(num2, num1, this.WindowHeight, this.windowHeight), new GUI.WindowFunction((object) this, __methodptr(OnGUIDialog)), this.DialogTitle);
    }

    protected abstract void DoGui();

    protected abstract void SendSuccessResult();

    protected void SendCancelResult()
    {
      Dictionary<string, object> dictionary = new Dictionary<string, object>();
      dictionary["cancelled"] = (object) true;
      if (!string.IsNullOrEmpty(this.CallbackID))
        dictionary["callback_id"] = (object) this.CallbackID;
      this.Callback(Json.Serialize((object) dictionary));
    }

    protected void SendErrorResult(string errorMessage)
    {
      Dictionary<string, object> dictionary = new Dictionary<string, object>();
      dictionary["error"] = (object) errorMessage;
      if (!string.IsNullOrEmpty(this.CallbackID))
        dictionary["callback_id"] = (object) this.CallbackID;
      this.Callback(Json.Serialize((object) dictionary));
    }

    private void OnGUIDialog(int windowId)
    {
      GUILayout.Space(10f);
      GUILayout.BeginVertical(new GUILayoutOption[0]);
      GUILayout.Label("Warning! Mock dialog responses will NOT match production dialogs", new GUILayoutOption[0]);
      GUILayout.Label("Test your app on one of the supported platforms", new GUILayoutOption[0]);
      this.DoGui();
      GUILayout.EndVertical();
      GUILayout.BeginHorizontal(new GUILayoutOption[0]);
      GUILayout.FlexibleSpace();
      GUIContent guiContent1 = new GUIContent("Send Success");
      if (GUI.Button(GUILayoutUtility.GetRect(guiContent1, GUI.skin.button), guiContent1))
      {
        this.SendSuccessResult();
        Object.Destroy((Object) this);
      }
      GUIContent guiContent2 = new GUIContent("Send Cancel");
      Rect rect = GUILayoutUtility.GetRect(guiContent2, this.greyButton);
      if (GUI.Button(rect, guiContent2, this.greyButton))
      {
        this.SendCancelResult();
        Object.Destroy((Object) this);
      }
      GUIContent guiContent3 = new GUIContent("Send Error");
      if (GUI.Button(GUILayoutUtility.GetRect(guiContent2, this.greyButton), guiContent3, this.greyButton))
      {
        this.SendErrorResult("Error: Error button pressed");
        Object.Destroy((Object) this);
      }
      GUILayout.EndHorizontal();
      if (Event.current.type != 7)
        return;
      this.windowHeight = ((Rect) ref rect).y + ((Rect) ref rect).height + (float) GUI.skin.window.padding.bottom;
    }

    public delegate void OnComplete(string result);
  }
}
