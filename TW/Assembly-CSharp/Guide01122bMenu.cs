// Decompiled with JetBrains decompiler
// Type: Guide01122bMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;

#nullable disable
public class Guide01122bMenu : Unit00493Menu
{
  public void SetNumber(UnitUnit unit)
  {
    this.TxtOwnednumber.SetTextLocalize("NO." + (unit.history_group_number % 1000).ToString().PadLeft(3, '0'));
  }

  public override void IbtnBack() => this.backScene();
}
