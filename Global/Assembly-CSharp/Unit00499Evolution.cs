// Decompiled with JetBrains decompiler
// Type: Unit00499Evolution
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
  public Unit00499Menu menu;
  public NGHorizontalScrollParts indicator;
  public GameObject unitIconPrefab;
  protected GameObject indicatorPrefab;
  private bool fromEarth;
  public int selectIndicator;
  private List<int> orderList;
  private Dictionary<int, List<int>> materialUnitIdDict;
  protected Dictionary<int, UnitUnit[]> evolutionMaterialDict;
  protected Dictionary<int, GameObject[]> linkEvolutionUnitsDict;
  public PlayerUnit basePlayUnit;
  public PlayerUnit[] afterPlayerUnits;

  [DebuggerHidden]
  private IEnumerator WaitScrollSe()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00499Evolution.\u003CWaitScrollSe\u003Ec__Iterator2F0()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void Update()
  {
    int selected = this.indicator.selected;
    if (this.orderList == null || selected >= this.orderList.Count || selected < 0)
      return;
    if (this.orderList[selected] != this.selectIndicator)
    {
      this.selectIndicator = this.orderList[selected];
      this.StopCoroutine("processByswipeIndicator");
      this.StartCoroutine("processByswipeIndicator", (object) selected);
    }
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
    return (IEnumerator) new Unit00499Evolution.\u003CprocessByswipeIndicator\u003Ec__Iterator2F1()
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
    return (IEnumerator) new Unit00499Evolution.\u003CInit\u003Ec__Iterator2F2()
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

  private List<int> SetMaterialUnitList()
  {
    this.materialUnitIdDict = new Dictionary<int, List<int>>();
    List<int> intList = new List<int>();
    PlayerUnit[] units = SMManager.Get<PlayerUnit[]>();
    Dictionary<int, UnitUnit[]> evolutionUnits = this.basePlayUnit.unit.EvolutionUnits;
    foreach (int key in evolutionUnits.Keys)
    {
      List<int> materialUnitIds = this.menu.GetMaterialUnitIDS(this.basePlayUnit, units, evolutionUnits[key]);
      this.materialUnitIdDict[key] = materialUnitIds;
      intList.Add(key);
    }
    return intList;
  }

  [DebuggerHidden]
  private IEnumerator createPrefab()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00499Evolution.\u003CcreatePrefab\u003Ec__Iterator2F3()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected virtual IEnumerator CreateIndicator(int evolutionPatturnId, PlayerUnit[] playerUnits)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00499Evolution.\u003CCreateIndicator\u003Ec__Iterator2F4()
    {
      evolutionPatturnId = evolutionPatturnId,
      playerUnits = playerUnits,
      \u003C\u0024\u003EevolutionPatturnId = evolutionPatturnId,
      \u003C\u0024\u003EplayerUnits = playerUnits,
      \u003C\u003Ef__this = this
    };
  }

  private void CheckEvolutionPossible()
  {
    UnitEvolutionPattern evolutionPattern = ((IEnumerable<UnitEvolutionPattern>) this.basePlayUnit.unit.EvolutionPattern).First<UnitEvolutionPattern>((Func<UnitEvolutionPattern, bool>) (p => p.ID == this.selectIndicator));
    if (this.basePlayUnit.level < evolutionPattern.threshold_level)
      this.menu.isLevel = false;
    this.menu.evolutionBtn.isEnabled = this.menu.CheckEnabledButton(evolutionPattern.money);
  }
}
