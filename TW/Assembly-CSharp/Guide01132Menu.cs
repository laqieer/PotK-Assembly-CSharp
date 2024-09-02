// Decompiled with JetBrains decompiler
// Type: Guide01132Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Guide01132Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtIntroduction;
  [SerializeField]
  protected UILabel TxtJobname;
  [SerializeField]
  protected UILabel TxtNumber;
  [SerializeField]
  protected UILabel TxtSubjugate;
  [SerializeField]
  protected UILabel TxtSubjugateNum;
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  protected UI2DSprite DynCharacter;
  [SerializeField]
  protected UI3DModel ui3DModel;
  [SerializeField]
  public UI2DSprite rarityStarsIcon;
  [SerializeField]
  private UnitUnit unit_;
  public List<GuideEnemyGearChange> enemyGearChangeList = new List<GuideEnemyGearChange>();

  public override void onBackButton() => this.IbtnBack();

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public virtual void IbtnZoom()
  {
    if (this.IsPushAndSet())
      return;
    Unit0043Scene.changeScene(true, this.unit_, true);
  }

  public void IbtnGearChange(GuideEnemyGearChange GuideEnemyGearChange)
  {
    this.StartCoroutine(this.onStartSceneAsync(GuideEnemyGearChange.unitData, false));
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(UnitUnit unit, bool voiceFlag)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guide01132Menu.\u003ConStartSceneAsync\u003Ec__Iterator5B2()
    {
      unit = unit,
      voiceFlag = voiceFlag,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u0024\u003EvoiceFlag = voiceFlag,
      \u003C\u003Ef__this = this
    };
  }

  public void SetDefeat(UnitUnit unit, UnitUnit[] commonUnitList, PlayerEnemyHistory[] historyList)
  {
    int defeat = 0;
    ((IEnumerable<PlayerEnemyHistory>) historyList).ForEach<PlayerEnemyHistory>((Action<PlayerEnemyHistory>) (obj =>
    {
      if (obj.unit_id != unit.ID)
        return;
      defeat += obj.defeat;
    }));
    if (defeat > 99999)
      defeat = 99999;
    this.TxtSubjugateNum.SetTextLocalize(defeat);
  }

  public void SetNumber(UnitUnit unit)
  {
    this.TxtNumber.SetTextLocalize("NO." + (unit.history_group_number % 1000).ToString().PadLeft(3, '0'));
  }

  public void SetUnitRarity(UnitUnit unit)
  {
    RarityIcon.SetRarity(unit, this.rarityStarsIcon, true, true);
  }

  [DebuggerHidden]
  public IEnumerator SetUnitImg(UnitUnit unit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guide01132Menu.\u003CSetUnitImg\u003Ec__Iterator5B3()
    {
      unit = unit,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetModel(UnitUnit unit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guide01132Menu.\u003CSetModel\u003Ec__Iterator5B4()
    {
      unit = unit,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u003Ef__this = this
    };
  }

  public void SetGearChange(UnitUnit unit, UnitUnit[] commonUnitList, PlayerEnemyHistory[] history)
  {
    int sabun = this.enemyGearChangeList.Count - ((IEnumerable<UnitUnit>) MasterData.UnitUnitList).Where<UnitUnit>((Func<UnitUnit, bool>) (x => x.character.category == UnitCategory.enemy)).Where<UnitUnit>((Func<UnitUnit, bool>) (x => x.history_group_number == unit.history_group_number)).ToList<UnitUnit>().OrderBy<UnitUnit, int>((Func<UnitUnit, int>) (x => x.ID)).ToList<UnitUnit>().Count;
    for (int i = 0; i < this.enemyGearChangeList.Count; ++i)
    {
      if (sabun > i)
        ((Component) this.enemyGearChangeList[i]).gameObject.SetActive(false);
      else if (!((IEnumerable<PlayerEnemyHistory>) history).FirstIndexOrNull<PlayerEnemyHistory>((Func<PlayerEnemyHistory, bool>) (x => x.unit_id == commonUnitList[i - sabun].ID)).HasValue)
        this.enemyGearChangeList[i].Set(commonUnitList[i - sabun], false, true);
      else if (unit.ID == commonUnitList[i - sabun].ID)
        this.enemyGearChangeList[i].Set(commonUnitList[i - sabun], true, false);
      else
        this.enemyGearChangeList[i].Set(commonUnitList[i - sabun], false, false);
    }
  }
}
