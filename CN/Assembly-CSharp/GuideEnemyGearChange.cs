﻿// Decompiled with JetBrains decompiler
// Type: GuideEnemyGearChange
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using UnityEngine;

#nullable disable
public class GuideEnemyGearChange : MonoBehaviour
{
  public GearKindButtonIcon gearIcon;
  public GameObject selectObj;
  public PressSpriteChangeButton button;
  public UnitUnit unitData;
  public Guide01132Menu menu;

  public void pressButton() => this.menu.IbtnGearChange(this);

  public void Set(UnitUnit unit, bool select, bool hatena)
  {
    this.unitData = unit;
    ((Behaviour) this.button).enabled = false;
    this.SetSelect(select);
    this.SetHatena(unit, hatena);
    ((Behaviour) this.button).enabled = true;
  }

  public void SetSelect(bool flag)
  {
    if (flag)
    {
      this.selectObj.SetActive(true);
      ((Behaviour) this.button).enabled = false;
    }
    else
      this.selectObj.SetActive(false);
  }

  public void SetHatena(UnitUnit unit, bool flag)
  {
    ((Component) this.button).GetComponent<UI2DSprite>().sprite2D = this.gearIcon.GetIdle(unit.initial_gear.kind);
    if (flag)
    {
      ((Component) this.button).GetComponent<Collider>().enabled = false;
    }
    else
    {
      this.button.idle = this.gearIcon.GetIdle(unit.initial_gear.kind);
      this.button.press = this.gearIcon.GetPress(unit.initial_gear.kind);
    }
  }
}
