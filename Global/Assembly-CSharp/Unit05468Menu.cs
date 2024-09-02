// Decompiled with JetBrains decompiler
// Type: Unit05468Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using Earth;
using SM;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Unit05468Menu : Unit00411Menu
{
  private readonly int MARKER_FLASH_TWEEN = 50;
  [SerializeField]
  private UILabel PossessionUnit;
  private int beforeInfoIndex;
  private int beforeIconIndex;
  private int afterInfoIndex;
  private int afterIconIndex;
  private GameObject supplyIcon;
  [SerializeField]
  private Transform[] SuppleIconPositions;
  private PlayerUnit[] cacheUnits;
  private Unit05468Menu.state selectState;

  private void ChangeState(Unit05468Menu.state state) => this.selectState = state;

  protected override void Update()
  {
    base.Update();
    if (this.selectState == Unit05468Menu.state.WAIT)
      return;
    switch (this.selectState)
    {
      case Unit05468Menu.state.INIT:
        Singleton<CommonRoot>.GetInstance().isTouchBlock = false;
        this.InitSelectIndex();
        break;
      case Unit05468Menu.state.SELECT_ANIMATION:
        Singleton<CommonRoot>.GetInstance().isTouchBlock = true;
        this.SelectAnimation();
        break;
      case Unit05468Menu.state.SELECT:
        Singleton<CommonRoot>.GetInstance().isTouchBlock = false;
        this.Select();
        break;
      case Unit05468Menu.state.SWAP_ANIMATION:
        Singleton<CommonRoot>.GetInstance().isTouchBlock = true;
        this.PlaySwapAnimation();
        break;
      case Unit05468Menu.state.SWAP:
        this.StartCoroutine(this.Swap());
        break;
    }
  }

  [DebuggerHidden]
  public IEnumerator Initialize(PlayerUnit[] playerUnits)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit05468Menu.\u003CInitialize\u003Ec__Iterator62C()
    {
      playerUnits = playerUnits,
      \u003C\u0024\u003EplayerUnits = playerUnits,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator LoadResources()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit05468Menu.\u003CLoadResources\u003Ec__Iterator62D()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected override IEnumerator CreateUnitIcon(
    int info_index,
    int unit_index,
    PlayerUnit baseUnit = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit05468Menu.\u003CCreateUnitIcon\u003Ec__Iterator62E()
    {
      info_index = info_index,
      unit_index = unit_index,
      \u003C\u0024\u003Einfo_index = info_index,
      \u003C\u0024\u003Eunit_index = unit_index,
      \u003C\u003Ef__this = this
    };
  }

  protected override void CreateUnitIconCache(int info_index, int unit_index, PlayerUnit baseUnit = null)
  {
    base.CreateUnitIconCache(info_index, unit_index);
    this.displayUnitInfos[info_index].alignmentSequence = info_index;
    this.DispIndex(this.allUnitIcons[unit_index], this.displayUnitInfos[info_index].alignmentSequence + 1);
  }

  protected override void CreateUnitIconAction(int info_index, int unit_index)
  {
    UnitIconBase allUnitIcon = this.allUnitIcons[unit_index];
    allUnitIcon.ShowBottomInfo(UnitSortAndFilter.SORT_TYPES.Level);
    ((UnitIcon) allUnitIcon).SetEarthButtonDetalEvent(this.allUnitInfos[info_index].playerUnit, this.getUnits());
    allUnitIcon.onClick = (Action<UnitIconBase>) (ui =>
    {
      if (this.IsPush)
        return;
      if (this.beforeInfoIndex == 0)
      {
        if (info_index == 0)
          return;
        this.beforeInfoIndex = info_index;
        this.beforeIconIndex = unit_index;
        this.ChangeState(Unit05468Menu.state.SELECT_ANIMATION);
      }
      else
      {
        if (info_index == 0)
          return;
        if (this.beforeInfoIndex == info_index)
        {
          this.ChangeState(Unit05468Menu.state.INIT);
        }
        else
        {
          this.afterInfoIndex = info_index;
          this.afterIconIndex = unit_index;
          this.ChangeState(Unit05468Menu.state.SELECT_ANIMATION);
        }
      }
    });
    allUnitIcon.markerDisplayFinished = (System.Action) (() => this.ChangeState(Unit05468Menu.state.SELECT));
  }

  public void IbtnOk()
  {
    if (this.IsPushAndSet())
      return;
    this.ApplyIndex();
    Singleton<EarthDataManager>.GetInstance().ClearCharacterBattleIndex();
    Singleton<EarthDataManager>.GetInstance().Save();
    this.backScene();
  }

  public void IbtnClear()
  {
    if (this.IsPush)
      return;
    this.StartCoroutine(this.UpdateInfoAndScroll(this.cacheUnits));
    this.ChangeState(Unit05468Menu.state.INIT);
  }

  public void IbtnChange()
  {
    if (this.IsPushAndSet())
      return;
    Quest00210Scene.changeScene(true);
  }

  private void DispMarker(int info_index, int unit_index, bool disp)
  {
    if (this.displayUnitInfos.Count > 0)
      this.displayUnitInfos[info_index].selectMarker = disp;
    if (this.allUnitInfos.Count > 0)
      this.allUnitInfos[info_index].selectMarker = disp;
    if (this.allUnitIcons.Count <= 0)
      return;
    this.allUnitIcons[unit_index].SelectMarker = disp;
  }

  private void SelectAnimation()
  {
    this.ChangeState(Unit05468Menu.state.WAIT);
    if (this.afterIconIndex == 0)
      this.DispMarker(this.beforeInfoIndex, this.beforeIconIndex, true);
    else
      this.DispMarker(this.afterInfoIndex, this.afterIconIndex, true);
  }

  private void Select()
  {
    if (this.afterIconIndex == 0)
      this.ChangeState(Unit05468Menu.state.WAIT);
    else
      this.ChangeState(Unit05468Menu.state.SWAP_ANIMATION);
  }

  private void PlaySwapAnimation()
  {
    this.ChangeState(Unit05468Menu.state.WAIT);
    UITweener[] iconTweens1 = this.GetIconTweens(this.beforeIconIndex, this.MARKER_FLASH_TWEEN);
    UITweener[] iconTweens2 = this.GetIconTweens(this.afterIconIndex, this.MARKER_FLASH_TWEEN);
    if (iconTweens1.Length <= 0 || iconTweens2.Length <= 0)
    {
      this.ChangeState(Unit05468Menu.state.SWAP);
    }
    else
    {
      iconTweens1[0].SetOnFinished((EventDelegate.Callback) (() => this.ChangeState(Unit05468Menu.state.SWAP)));
      foreach (UITweener uiTweener in iconTweens1)
      {
        uiTweener.ResetToBeginning();
        uiTweener.PlayForward();
      }
      foreach (UITweener uiTweener in iconTweens2)
      {
        uiTweener.ResetToBeginning();
        uiTweener.PlayForward();
      }
    }
  }

  private UITweener[] GetIconTweens(int iconIndex, int groupId)
  {
    return NGTween.findTweenersGroup(this.allUnitIcons[iconIndex].selectMarker, groupId, false);
  }

  [DebuggerHidden]
  private IEnumerator Swap()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit05468Menu.\u003CSwap\u003Ec__Iterator62F()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void InitSelectIndex()
  {
    this.ChangeState(Unit05468Menu.state.WAIT);
    this.DispMarker(this.beforeInfoIndex, this.beforeIconIndex, false);
    this.DispMarker(this.afterInfoIndex, this.afterIconIndex, false);
    this.beforeInfoIndex = 0;
    this.beforeIconIndex = 0;
    this.afterInfoIndex = 0;
    this.afterIconIndex = 0;
  }

  protected void DispIndex(UnitIconBase iconBase, int index)
  {
    bool isGorgeous = index == 1;
    iconBase.DispEarthUnitNumberIcon(index, isGorgeous, false);
  }

  protected void HiddenIndex(UnitIconBase iconBase) => iconBase.HiddenEarthUnitNumberIcon(false);

  private void ApplyIndex()
  {
    foreach (UnitIconInfo allUnitInfo in this.allUnitInfos)
    {
      int index = allUnitInfo.alignmentSequence + 1;
      Singleton<EarthDataManager>.GetInstance().SetCharacterIndex(allUnitInfo.playerUnit.id, index);
    }
  }

  [DebuggerHidden]
  public IEnumerator DispSupplyDeck(PlayerItem[] supplys)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit05468Menu.\u003CDispSupplyDeck\u003Ec__Iterator630()
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
    return (IEnumerator) new Unit05468Menu.\u003CCreateSupplyIcon\u003Ec__Iterator631()
    {
      pos = pos,
      supply = supply,
      \u003C\u0024\u003Epos = pos,
      \u003C\u0024\u003Esupply = supply,
      \u003C\u003Ef__this = this
    };
  }

  private enum state
  {
    INIT,
    SELECT_ANIMATION,
    SELECT,
    SWAP_ANIMATION,
    SWAP,
    WAIT,
  }
}
