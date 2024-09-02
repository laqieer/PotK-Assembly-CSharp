// Decompiled with JetBrains decompiler
// Type: Popup02641Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

#nullable disable
public class Popup02641Menu : BackButtonMonoBehaiviour
{
  [SerializeField]
  private UILabel txt_Title;
  [SerializeField]
  private UILabel txt_Description;
  private System.Action ok;
  private System.Action no;

  public void Initialize(System.Action ok, System.Action no)
  {
    this.SetText(Consts.Lookup("VERSUS_002641POPUP_TITLE"), Consts.Lookup("VERSUS_002641POPUP_DESCRIPTION"));
    this.ok = ok;
    this.no = no;
  }

  private void SetText(string t, string d)
  {
    this.txt_Title.SetText(t);
    this.txt_Description.SetText(d);
  }

  public void IbtnOk()
  {
    Singleton<PopupManager>.GetInstance().onDismiss(true);
    if (this.ok == null)
      return;
    this.ok();
  }

  public void IbtnNo()
  {
    if (this.no == null)
      return;
    this.no();
  }

  public override void onBackButton() => this.IbtnNo();
}
