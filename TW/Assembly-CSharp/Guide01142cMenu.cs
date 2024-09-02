// Decompiled with JetBrains decompiler
// Type: Guide01142cMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using UnityEngine;

#nullable disable
public class Guide01142cMenu : Bugu00561Menu
{
  [SerializeField]
  protected UILabel TxtNumber;
  [SerializeField]
  protected GameObject dirNumber;

  public void SetNumber(GearGear gear, bool isDispNumber)
  {
    this.dirNumber.SetActive(isDispNumber);
    this.TxtNumber.SetTextLocalize("NO." + (gear.history_group_number % 1000).ToString().PadLeft(3, '0'));
  }
}
