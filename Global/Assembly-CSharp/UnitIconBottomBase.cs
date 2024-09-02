// Decompiled with JetBrains decompiler
// Type: UnitIconBottomBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class UnitIconBottomBase : MonoBehaviour
{
  private const int USUAL = 0;
  private const int FRIENDLY = 1;
  public GameObject[] GearRarity;
  public UI2DSprite rarityStar;
  public GameObject textParent;
  public UILabel[] textLevels;
  public GameObject gearIcon;

  public void Set(PlayerUnit playerUnit)
  {
    this.SetText(playerUnit.level.ToLocalizeNumberText());
    RarityIcon.SetRarity(playerUnit.unit, this.rarityStar, false);
    this.StartCoroutine(this.SetGearSprite(playerUnit.unit.kind_GearKind, playerUnit.GetElement()));
  }

  public void SetText(string level)
  {
    this.textParent.SetActive(true);
    ((Component) this.textLevels[0]).gameObject.SetActive(true);
    this.textLevels[0].SetTextLocalize(level);
  }

  public void Set(int rarity, int kind, CommonElement element)
  {
    ((IEnumerable<GameObject>) this.GearRarity).ToggleOnce(rarity - 1);
    this.StartCoroutine(this.SetGearSprite(kind, element));
  }

  public void Set(UnitUnit unit)
  {
    this.StartCoroutine(this.SetGearSprite(unit.kind_GearKind, unit.GetElement()));
  }

  [DebuggerHidden]
  private IEnumerator SetGearSprite(int kind, CommonElement element)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UnitIconBottomBase.\u003CSetGearSprite\u003Ec__Iterator93D()
    {
      kind = kind,
      element = element,
      \u003C\u0024\u003Ekind = kind,
      \u003C\u0024\u003Eelement = element,
      \u003C\u003Ef__this = this
    };
  }
}
