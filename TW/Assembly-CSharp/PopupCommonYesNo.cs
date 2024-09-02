// Decompiled with JetBrains decompiler
// Type: PopupCommonYesNo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class PopupCommonYesNo : BackButtonMonoBehaiviour
{
  [SerializeField]
  private UILabel title;
  [SerializeField]
  private UILabel message;
  private System.Action yes;
  private System.Action no;
  private static string prefab_path = "Prefabs/popup_common_yes_no";

  public void OnYes()
  {
    Singleton<PopupManager>.GetInstance().dismiss();
    this.yes();
  }

  public void IbtnNo()
  {
    Singleton<PopupManager>.GetInstance().dismiss();
    this.no();
  }

  public override void onBackButton() => this.IbtnNo();

  public static void Show(string title, string message, System.Action yes = null, System.Action no = null)
  {
    GameObject prefab = Resources.Load<GameObject>(PopupCommonYesNo.prefab_path);
    PopupCommonYesNo component = Singleton<PopupManager>.GetInstance().open(prefab).GetComponent<PopupCommonYesNo>();
    component.title.SetText(title);
    component.message.SetText(message);
    component.yes = yes ?? new System.Action(PopupCommonYesNo.defaultCallback);
    component.no = no ?? new System.Action(PopupCommonYesNo.defaultCallback);
  }

  public static void defaultCallback() => Debug.Log((object) "popup close");
}
