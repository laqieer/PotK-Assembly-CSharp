// Decompiled with JetBrains decompiler
// Type: Guide01122bMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
