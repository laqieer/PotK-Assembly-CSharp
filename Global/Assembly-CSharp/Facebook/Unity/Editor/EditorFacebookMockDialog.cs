// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Editor.EditorFacebookMockDialog
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Facebook.Unity.Editor
{
  internal abstract class EditorFacebookMockDialog : MonoBehaviour
  {
    private Rect modalRect;
    private GUIStyle modalStyle;

    public Utilities.Callback<ResultContainer> Callback { protected get; set; }

    public string CallbackID { protected get; set; }

    protected abstract string DialogTitle { get; }

    public void Start()
    {
      this.modalRect = new Rect(10f, 10f, (float) (Screen.width - 20), (float) (Screen.height - 20));
      Texture2D texture2D = new Texture2D(1, 1);
      texture2D.SetPixel(0, 0, new Color(0.2f, 0.2f, 0.2f, 1f));
      texture2D.Apply();
      this.modalStyle = new GUIStyle();
      this.modalStyle.normal.background = texture2D;
    }

    public void OnGUI()
    {
      // ISSUE: method pointer
      GUI.ModalWindow(((Object) this).GetHashCode(), this.modalRect, new GUI.WindowFunction((object) this, __methodptr(OnGUIDialog)), this.DialogTitle, this.modalStyle);
    }

    protected abstract void DoGui();

    protected abstract void SendSuccessResult();

    protected virtual void SendCancelResult()
    {
      Dictionary<string, object> dictionary = new Dictionary<string, object>();
      dictionary["cancelled"] = (object) true;
      if (!string.IsNullOrEmpty(this.CallbackID))
        dictionary["callback_id"] = (object) this.CallbackID;
      this.Callback(new ResultContainer(dictionary.ToJson()));
    }

    protected virtual void SendErrorResult(string errorMessage)
    {
      Dictionary<string, object> dictionary = new Dictionary<string, object>();
      dictionary["error"] = (object) errorMessage;
      if (!string.IsNullOrEmpty(this.CallbackID))
        dictionary["callback_id"] = (object) this.CallbackID;
      this.Callback(new ResultContainer(dictionary.ToJson()));
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
      if (GUI.Button(GUILayoutUtility.GetRect(guiContent2, GUI.skin.button), guiContent2, GUI.skin.button))
      {
        this.SendCancelResult();
        Object.Destroy((Object) this);
      }
      GUIContent guiContent3 = new GUIContent("Send Error");
      if (GUI.Button(GUILayoutUtility.GetRect(guiContent2, GUI.skin.button), guiContent3, GUI.skin.button))
      {
        this.SendErrorResult("Error: Error button pressed");
        Object.Destroy((Object) this);
      }
      GUILayout.EndHorizontal();
    }
  }
}
