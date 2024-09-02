// Decompiled with JetBrains decompiler
// Type: PopupCommonOkTitle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class PopupCommonOkTitle : MonoBehaviour
{
  [SerializeField]
  private UILabel title;
  [SerializeField]
  private UILabel message;
  [SerializeField]
  private UIButton btnYes;
  [SerializeField]
  private UIButton btnNo;
  private System.Action yes;
  private System.Action no;
  private System.Action type;
  private static string prefab_path = "Prefabs/popup_common_ok_title";

  public void OnYes()
  {
    Singleton<PopupManager>.GetInstance().dismiss();
    this.yes();
  }

  public void OnNo()
  {
    Singleton<PopupManager>.GetInstance().dismiss();
    this.no();
  }

  public static void Show(string title, string message, System.Action yes = null, System.Action no = null, string type = null)
  {
    GameObject prefab = Resources.Load<GameObject>(PopupCommonOkTitle.prefab_path);
    PopupCommonOkTitle component = Singleton<PopupManager>.GetInstance().open(prefab).GetComponent<PopupCommonOkTitle>();
    component.title.SetText(title);
    component.message.SetText(message);
    component.yes = yes ?? new System.Action(PopupCommonOkTitle.defaultCallback);
    component.no = no ?? new System.Action(PopupCommonOkTitle.defaultCallback);
  }

  public static void defaultCallback() => Debug.Log((object) "popup close");
}
