// Decompiled with JetBrains decompiler
// Type: GuideUnitUnit
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System;
using UnityEngine;

#nullable disable
[Serializable]
public class GuideUnitUnit
{
  [SerializeField]
  private bool isMaterial;
  private UnitUnit unit;
  private GearGear gear;
  public DateTime history;

  public GuideUnitUnit()
  {
  }

  public GuideUnitUnit(UnitUnit unit_)
  {
    this.unit = unit_;
    this.history = new DateTime();
  }

  public GuideUnitUnit(GearGear gear_)
  {
    this.gear = gear_;
    this.history = new DateTime();
  }

  public bool IsMaterial
  {
    get => this.isMaterial;
    set => this.isMaterial = value;
  }

  public UnitUnit Unit
  {
    get => this.unit;
    set
    {
      this.unit = value;
      this.isMaterial = this.unit.IsMaterialUnit;
    }
  }

  public GearGear Gear
  {
    get => this.gear;
    set => this.gear = value;
  }

  public DateTime History
  {
    get => this.history;
    set => this.history = value;
  }
}
