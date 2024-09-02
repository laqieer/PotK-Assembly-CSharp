// Decompiled with JetBrains decompiler
// Type: BattleUI05HardModeOpenPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

#nullable disable
public class BattleUI05HardModeOpenPopup : NGMenuBase
{
  public UILabel TxtTitle;
  public UILabel TxtDescription;
  private BattleUI05HardModeOpenMenu menu;

  public void IbtnPopupOk() => this.menu.ToNext = true;

  public void Init(BattleUI05HardModeOpenMenu menu, string title, string message)
  {
    this.menu = menu;
    this.TxtTitle.SetText(title);
    this.TxtDescription.SetText(message);
  }
}
