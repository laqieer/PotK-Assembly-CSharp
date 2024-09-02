// Decompiled with JetBrains decompiler
// Type: Popup02642SerchMatching
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

#nullable disable
public class Popup02642SerchMatching : BackButtonMonoBehaiviour
{
  [SerializeField]
  private UILabel txtTitle;
  [SerializeField]
  private UILabel txtDescription;
  [SerializeField]
  private GameObject btnNo;
  private System.Action action;

  public void Init(System.Action noAction)
  {
    this.action = noAction;
    this.txtTitle.SetText(Consts.Lookup("VERSUS_002642POPUP_TITLE"));
    this.txtDescription.SetText(Consts.Lookup("VERSUS_002642POPUP_DESCRIPTION"));
  }

  public void IbtnNo() => this.action();

  public override void onBackButton() => this.IbtnNo();

  public void DisableButton() => this.btnNo.GetComponent<UIButton>().isEnabled = false;
}
