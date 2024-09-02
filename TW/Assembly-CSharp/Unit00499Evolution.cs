// Decompiled with JetBrains decompiler
// Type: Unit00499Evolution
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Unit00499Evolution : NGMenuBase
{
  private const int SINGLE_PATTERN_EVOLUTION = 1;
  public Unit00499Menu menu;
  public NGHorizontalScrollParts indicator;
  public GameObject unitIconPrefab;
  protected GameObject indicatorPrefab;
  private bool fromEarth;
  public int selectIndicator;
  private float positionIndicator;
  private bool realityEvolutionButton;
  private List<int> orderList;
  protected Dictionary<int, UnitUnit[]> evolutionMaterialDict;
  protected Dictionary<int, GameObject[]> linkEvolutionUnitsDict;
  public PlayerUnit basePlayUnit;
  public PlayerUnit[] afterPlayerUnits;

  public bool isMovingIndicator { get; private set; }

  private bool isEvolutionButtonEnabled => this.realityEvolutionButton && !this.isMovingIndicator;

  [DebuggerHidden]
  private IEnumerator WaitScrollSe()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00499Evolution.\u003CWaitScrollSe\u003Ec__Iterator39D()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void Update()
  {
    this.isMovingIndicator = false;
    int selected = this.indicator.selected;
    if (this.orderList == null || selected >= this.orderList.Count || selected < 0)
      return;
    if (this.orderList.Count > 1 && (double) this.positionIndicator != (double) this.indicator.scrollView.transform.localPosition.x)
    {
      this.isMovingIndicator = true;
      this.positionIndicator = this.indicator.scrollView.transform.localPosition.x;
    }
    if (this.orderList[selected] != this.selectIndicator)
    {
      this.selectIndicator = this.orderList[selected];
      this.menu.HideMaterialQuestInfo();
      this.StopCoroutine("processByswipeIndicator");
      this.standbyEvolutionButton();
      this.StartCoroutine("processByswipeIndicator", (object) selected);
    }
    else if (this.menu.evolutionBtn.isEnabled != this.isEvolutionButtonEnabled)
      this.menu.evolutionBtn.isEnabled = this.isEvolutionButtonEnabled;
    bool flag1 = Object.op_Inequality((Object) Singleton<PopupManager>.GetInstanceOrNull(), (Object) null) && Singleton<PopupManager>.GetInstance().isOpen;
    bool flag2 = Object.op_Inequality((Object) Singleton<CommonRoot>.GetInstanceOrNull(), (Object) null) && Singleton<CommonRoot>.GetInstance().isInputBlock;
    if (!Singleton<NGSceneManager>.GetInstance().isSceneInitialized || Singleton<TutorialRoot>.GetInstance().IsAdviced || !Input.GetKeyUp((KeyCode) 27) || flag1 || flag2 || Singleton<NGSceneManager>.GetInstance().changeSceneQueueCount != 0)
      return;
    this.menu.IbtnBack();
  }

  [DebuggerHidden]
  private IEnumerator processByswipeIndicator(int selectedIdx)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00499Evolution.\u003CprocessByswipeIndicator\u003Ec__Iterator39E()
    {
      selectedIdx = selectedIdx,
      \u003C\u0024\u003EselectedIdx = selectedIdx,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Init(PlayerUnit basePlayUnit, PlayerUnit[] afterPlayerUnits, bool fromEarth = false)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00499Evolution.\u003CInit\u003Ec__Iterator39F()
    {
      basePlayUnit = basePlayUnit,
      afterPlayerUnits = afterPlayerUnits,
      fromEarth = fromEarth,
      \u003C\u0024\u003EbasePlayUnit = basePlayUnit,
      \u003C\u0024\u003EafterPlayerUnits = afterPlayerUnits,
      \u003C\u0024\u003EfromEarth = fromEarth,
      \u003C\u003Ef__this = this
    };
  }

  private void standbyEvolutionButton()
  {
    this.menu.evolutionBtn.isEnabled = false;
    this.realityEvolutionButton = false;
  }

  private List<int> SetMaterialUnitList()
  {
    List<int> intList = new List<int>();
    foreach (int key in this.basePlayUnit.unit.EvolutionUnits.Keys)
      intList.Add(key);
    return intList;
  }

  [DebuggerHidden]
  private IEnumerator createPrefab()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00499Evolution.\u003CcreatePrefab\u003Ec__Iterator3A0()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected virtual IEnumerator CreateIndicator(
    int evolutionPatternId,
    PlayerUnit[] playerUnits,
    PlayerMaterialUnit[] playerMaterialUnits)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00499Evolution.\u003CCreateIndicator\u003Ec__Iterator3A1()
    {
      evolutionPatternId = evolutionPatternId,
      playerUnits = playerUnits,
      playerMaterialUnits = playerMaterialUnits,
      \u003C\u0024\u003EevolutionPatternId = evolutionPatternId,
      \u003C\u0024\u003EplayerUnits = playerUnits,
      \u003C\u0024\u003EplayerMaterialUnits = playerMaterialUnits,
      \u003C\u003Ef__this = this
    };
  }

  private void CheckEvolutionPossible()
  {
    UnitEvolutionPattern evolutionPattern = ((IEnumerable<UnitEvolutionPattern>) this.basePlayUnit.unit.EvolutionPattern).First<UnitEvolutionPattern>((Func<UnitEvolutionPattern, bool>) (p => p.ID == this.selectIndicator));
    if (this.basePlayUnit.level < evolutionPattern.threshold_level && this.basePlayUnit.unit.IsNormalUnit)
      this.menu.isLevel = false;
    this.menu.updateCheckEnableButton(this.selectIndicator);
    this.realityEvolutionButton = this.menu.CheckEnabledButton(evolutionPattern.money);
    this.menu.evolutionBtn.isEnabled = this.isEvolutionButtonEnabled;
  }
}
