// Decompiled with JetBrains decompiler
// Type: Quest0529Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using Earth;
using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Quest0529Menu : UnitSelectMenuBase
{
  [SerializeField]
  private UILabel PossessionUnit;
  private EarthCharacter[] selectPlayerUnitsCache;
  private GameObject supplyIcon;
  [SerializeField]
  private Transform[] SuppleIconPositions;

  [DebuggerHidden]
  public IEnumerator LoadResources()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0529Menu.\u003CLoadResources\u003Ec__Iterator610()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void InitializeAllUnitInfosEx(EarthCharacter[] selectEarthPlayerUnits)
  {
    bool flag = this.selectedUnitIcons.Count<UnitIconInfo>() == 0;
    UnitIconInfo[] array = this.selectedUnitIcons.ToArray();
    this.selectedUnitIcons.Clear();
    foreach (UnitIconInfo allUnitInfo in this.allUnitInfos)
    {
      UnitIconInfo info = allUnitInfo;
      info.for_battle = false;
      if (flag)
      {
        info.select = -1;
        info.gray = false;
        EarthCharacter earthCharacter = ((IEnumerable<EarthCharacter>) selectEarthPlayerUnits).FirstOrDefault<EarthCharacter>((Func<EarthCharacter, bool>) (x => x.GetPlayerUnit().id == info.playerUnit.id));
        if (earthCharacter != null)
        {
          info.gray = true;
          info.select = earthCharacter.battleIndex;
          this.selectedUnitIcons.Add(info);
        }
      }
      else
      {
        info.select = -1;
        info.gray = false;
        UnitIconInfo unitIconInfo = ((IEnumerable<UnitIconInfo>) array).FirstOrDefault<UnitIconInfo>((Func<UnitIconInfo, bool>) (x => x.playerUnit.id == info.playerUnit.id));
        if (unitIconInfo != null)
        {
          info.gray = true;
          info.select = unitIconInfo.select;
          this.selectedUnitIcons.Add(info);
        }
      }
    }
    this.ReflectionSelectUnit();
    this.CreateSelectUnitList(false);
  }

  protected void CreateSelectUnitList(bool updateIndex = true)
  {
    this.selectedUnitIcons.Clear();
    this.selectedUnitIcons = this.allUnitInfos.Where<UnitIconInfo>((Func<UnitIconInfo, bool>) (x => x.select >= 0)).OrderBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (x => x.select)).ToList<UnitIconInfo>();
    this.selectedUnitIcons.ForEachIndex<UnitIconInfo>((Action<UnitIconInfo, int>) ((u, n) =>
    {
      if (updateIndex)
        u.select = n;
      this.UnitInfoUpdate(u, true, u.select);
    }));
  }

  private void UpdateSelectUnitText()
  {
    this.PossessionUnit.SetTextLocalize(Consts.Lookup("UNIT_054_6_8_Possession", (IDictionary) new Hashtable()
    {
      {
        (object) "select",
        (object) this.selectedUnitIcons.Count<UnitIconInfo>()
      },
      {
        (object) "possession",
        (object) this.SelectMax
      }
    }));
  }

  [DebuggerHidden]
  public IEnumerator Initialize(PlayerUnit[] playerUnits, EarthCharacter[] selectPlayerUnits)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0529Menu.\u003CInitialize\u003Ec__Iterator611()
    {
      selectPlayerUnits = selectPlayerUnits,
      playerUnits = playerUnits,
      \u003C\u0024\u003EselectPlayerUnits = selectPlayerUnits,
      \u003C\u0024\u003EplayerUnits = playerUnits,
      \u003C\u003Ef__this = this
    };
  }

  private void IconGraySetting(UnitIconBase unitIcon, UnitIconInfo info)
  {
    unitIcon.Gray = this.selectedUnitIcons.Count<UnitIconInfo>() < this.SelectMax ? info.gray : !info.gray;
    if (info.select != -1)
      return;
    unitIcon.HiddenEarthUnitNumberIcon(false);
  }

  protected override void CreateUnitIconAction(int info_index, int unit_index)
  {
    UnitIconBase allUnitIcon = this.allUnitIcons[unit_index];
    UnitIconInfo info = this.displayUnitInfos[info_index];
    info.gray = false;
    if (info.select >= 0)
    {
      info.gray = true;
      info.icon.HideCheckIcon();
      info.icon.DispEarthUnitNumberIcon(info.select, info.select == 1, false);
    }
    allUnitIcon.onClick = (Action<UnitIconBase>) (ui =>
    {
      if (info.select >= 1 && info.select <= Singleton<EarthDataManager>.GetInstance().questProgress.forcedSortieCharacterMaxPosition)
        return;
      this.Select(ui);
    });
    ((UnitIcon) allUnitIcon).SetEarthButtonDetalEvent(info.playerUnit, this.getUnits());
    if (info.button_enable)
    {
      ((Behaviour) allUnitIcon.button).enabled = true;
    }
    else
    {
      ((Behaviour) allUnitIcon.button).enabled = false;
      info.gray = true;
    }
    if (this.selectedUnitIcons.Count >= this.SelectMax)
      allUnitIcon.Gray = !info.gray;
    else
      this.IconGraySetting(allUnitIcon, info);
  }

  public override void UpdateSelectIcon()
  {
    this.selectedUnitIcons.ForEachIndex<UnitIconInfo>((Action<UnitIconInfo, int>) ((u, n) =>
    {
      UnitIconInfo unitInfoDisplay = this.GetUnitInfoDisplay(u.playerUnit);
      if (unitInfoDisplay == null || !Object.op_Inequality((Object) unitInfoDisplay.icon, (Object) null))
        return;
      unitInfoDisplay.gray = true;
      unitInfoDisplay.icon.Select(unitInfoDisplay.select);
      unitInfoDisplay.icon.HideCheckIcon();
      unitInfoDisplay.icon.DispEarthUnitNumberIcon(unitInfoDisplay.select, unitInfoDisplay.select == 1, false);
    }));
    foreach (UnitIconInfo displayUnitInfo in this.displayUnitInfos)
    {
      if (Object.op_Inequality((Object) displayUnitInfo.icon, (Object) null))
        this.IconGraySetting(displayUnitInfo.icon, displayUnitInfo);
    }
  }

  protected override void Select(UnitIconBase unitIcon)
  {
    if (unitIcon.Selected)
    {
      this.Deselect(unitIcon);
      unitIcon.HiddenEarthUnitNumberIcon(false);
      this.UpdateSelectIcon();
      this.UpdateSelectUnitText();
    }
    else
    {
      if (this.selectedUnitIcons.Count >= this.SelectMax)
        return;
      UnitIconInfo unitInfoDisplay = this.GetUnitInfoDisplay(unitIcon.PlayerUnit);
      if (unitInfoDisplay != null)
      {
        unitIcon.HideCheckIcon();
        unitIcon.DispEarthUnitNumberIcon(unitInfoDisplay.select, unitInfoDisplay.select == 1, false);
        unitIcon.Select(this.GetMinSelectIndex(Singleton<EarthDataManager>.GetInstance().questProgress.forcedSortieCharacterMaxPosition));
        this.UnitInfoUpdate(unitInfoDisplay, true, unitIcon.SelIndex);
      }
      UnitIconInfo unitInfoAll = this.GetUnitInfoAll(unitIcon.PlayerUnit);
      if (unitInfoAll != null)
      {
        this.UnitInfoUpdate(unitInfoAll, true, unitIcon.SelIndex);
        this.selectedUnitIcons.Add(unitInfoAll);
      }
      this.UpdateSelectIcon();
      this.UpdateSelectUnitText();
    }
  }

  protected override void CreateUnitIconCache(int info_index, int unit_index, PlayerUnit baseUnit = null)
  {
    base.CreateUnitIconCache(info_index, unit_index);
    this.CreateUnitIconAction(info_index, unit_index);
  }

  [DebuggerHidden]
  public IEnumerator DispSupplyDeck(PlayerItem[] supplys)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0529Menu.\u003CDispSupplyDeck\u003Ec__Iterator612()
    {
      supplys = supplys,
      \u003C\u0024\u003Esupplys = supplys,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CreateSupplyIcon(PlayerItem supply, int pos)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0529Menu.\u003CCreateSupplyIcon\u003Ec__Iterator613()
    {
      pos = pos,
      supply = supply,
      \u003C\u0024\u003Epos = pos,
      \u003C\u0024\u003Esupply = supply,
      \u003C\u003Ef__this = this
    };
  }

  public override void IbtnYes()
  {
    if (this.IsPush)
      return;
    EarthCharacter[] characters = Singleton<EarthDataManager>.GetInstance().characters;
    foreach (EarthCharacter earthCharacter in characters)
      earthCharacter.SetBattleIndex(0);
    foreach (UnitIconInfo selectedUnitIcon in this.selectedUnitIcons)
    {
      UnitIconInfo unit = selectedUnitIcon;
      ((IEnumerable<EarthCharacter>) characters).FirstOrDefault<EarthCharacter>((Func<EarthCharacter, bool>) (x => x.GetPlayerUnit().id == unit.playerUnit.id))?.SetBattleIndex(unit.select);
    }
    Singleton<EarthDataManager>.GetInstance().Save();
    this.backScene();
  }

  public void IbtnClear()
  {
    if (this.IsPush)
      return;
    this.selectedUnitIcons.Clear();
    this.InitializeAllUnitInfosEx(this.selectPlayerUnitsCache);
    this.UpdateSelectIcon();
    this.UpdateSelectUnitText();
  }

  public override void IbtnBack() => base.IbtnBack();

  public void IbtnChange()
  {
    if (this.IsPushAndSet())
      return;
    Quest00210Scene.changeScene(true);
  }
}
