// Decompiled with JetBrains decompiler
// Type: Guide01142bMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using UnityEngine;

#nullable disable
public class Guide01142bMenu : Bugu00561Menu
{
  [SerializeField]
  protected UILabel TxtNumber;

  public void SetNumber(GearGear gear)
  {
    this.TxtNumber.SetTextLocalize("NO." + (gear.history_group_number % 1000).ToString().PadLeft(3, '0'));
  }
}
