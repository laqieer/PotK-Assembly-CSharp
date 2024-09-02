// Decompiled with JetBrains decompiler
// Type: Guide01122bMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
