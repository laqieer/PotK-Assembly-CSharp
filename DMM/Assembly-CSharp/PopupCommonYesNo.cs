﻿// Decompiled with JetBrains decompiler
// Type: PopupCommonYesNo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

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
    this.yes();
    Singleton<PopupManager>.GetInstance().dismiss();
  }

  public void IbtnNo()
  {
    this.no();
    Singleton<PopupManager>.GetInstance().dismiss();
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
