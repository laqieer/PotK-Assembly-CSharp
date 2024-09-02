// Decompiled with JetBrains decompiler
// Type: Popup02642SerchMatching
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    Consts instance = Consts.GetInstance();
    this.txtTitle.SetText(instance.VERSUS_002642POPUP_TITLE);
    this.txtDescription.SetText(instance.VERSUS_002642POPUP_DESCRIPTION);
  }

  public void IbtnNo() => this.action();

  public override void onBackButton() => this.IbtnNo();

  public void DisableButton() => this.btnNo.GetComponent<UIButton>().isEnabled = false;
}
