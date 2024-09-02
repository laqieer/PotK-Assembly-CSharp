// Decompiled with JetBrains decompiler
// Type: UnitIconInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using UnityEngine;

#nullable disable
public class UnitIconInfo
{
  public bool removeButton;
  public UnitIconBase icon;
  public bool gray;
  public bool for_battle;
  public bool pricessType;
  public bool equip;
  public bool button_enable = true;
  public bool selectMarker;
  private int m_selected = -1;
  public int count = 1;
  private int m_selectedCount;
  public int alignmentSequence;

  public PlayerUnit playerUnit { get; set; }

  public int select
  {
    get => this.m_selected;
    set
    {
      this.m_selected = value;
      if (this.m_selected < 0)
      {
        this.SelectedCount = 0;
      }
      else
      {
        if (this.m_selected <= -1 || this.m_selectedCount != 0)
          return;
        this.SelectedCount = 1;
      }
    }
  }

  public int SelectedCount
  {
    get => this.m_selectedCount;
    set
    {
      this.m_selectedCount = value;
      if (this.m_selectedCount > 0)
      {
        if (this.m_selected < 0)
          this.m_selected = 0;
      }
      else if (this.m_selected > -1)
        this.m_selected = -1;
      if (!Object.op_Inequality((Object) this.icon, (Object) null) || this.playerUnit.unit.IsNormalUnit)
        return;
      this.icon.SetSelectionCounter(this.m_selectedCount);
      this.icon.Gray = this.m_selectedCount > 0;
    }
  }

  public UnitIconInfo TempCopy()
  {
    UnitIconInfo unitIconInfo = (UnitIconInfo) this.MemberwiseClone();
    unitIconInfo.icon = (UnitIconBase) null;
    return unitIconInfo;
  }
}
