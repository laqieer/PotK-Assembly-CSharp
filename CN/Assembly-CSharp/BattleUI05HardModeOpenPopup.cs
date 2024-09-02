// Decompiled with JetBrains decompiler
// Type: BattleUI05HardModeOpenPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
