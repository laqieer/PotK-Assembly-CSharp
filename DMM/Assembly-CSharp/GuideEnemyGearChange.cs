﻿// Decompiled with JetBrains decompiler
// Type: GuideEnemyGearChange
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using MasterDataTable;
using UnityEngine;

public class GuideEnemyGearChange : MonoBehaviour
{
  public GearKindButtonIcon gearIcon;
  public PressSpriteChangeButton button;
  public UnitUnit unitData;
  public Guide01132Menu menu;

  public void pressButton() => this.menu.IbtnGearChange(this);

  public void Set(UnitUnit unit, bool select, bool hatena)
  {
    this.unitData = unit;
    this.button.enabled = false;
    this.SetSelect(select);
    this.SetHatena(unit, hatena);
    this.button.enabled = true;
  }

  public void SetSelect(bool flag)
  {
    if (!flag || !(bool) (Object) this.button)
      return;
    this.button.enabled = false;
  }

  public void SetHatena(UnitUnit unit, bool flag)
  {
    this.button.GetComponent<UI2DSprite>().sprite2D = this.gearIcon.GetIdle(unit.initial_gear.kind);
    if (flag)
    {
      this.button.GetComponent<Collider>().enabled = false;
    }
    else
    {
      this.button.idle = this.gearIcon.GetIdle(unit.initial_gear.kind);
      this.button.press = this.gearIcon.GetPress(unit.initial_gear.kind);
    }
  }
}
