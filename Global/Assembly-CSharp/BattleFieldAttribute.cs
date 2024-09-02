// Decompiled with JetBrains decompiler
// Type: BattleFieldAttribute
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;

#nullable disable
public class BattleFieldAttribute : BattleMonoBehaviour
{
  private BL.BattleModified<BL.CurrentUnit> currentModified;
  private BL.BattleModified<BL.UnitPosition> positionModified;
  private BL.PanelAttribute lastAttribute;
  private List<BL.Panel> lastRoute;
  private HashSet<BL.Panel> lastMovePanels;
  private HashSet<BL.Panel> lastAttackTargetPanels;
  private HashSet<BL.Panel> lastAttackPanels;
  private HashSet<BL.Panel> lastHealTargetPanels;
  private HashSet<BL.Panel> lastHealPanels;
  private NGBattle3DObjectManager objectManager;
  private BattleInputObserver inputObserver;

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleFieldAttribute.\u003CStart_Battle\u003Ec__Iterator842()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected override void LateUpdate_Battle()
  {
    bool flag = this.currentModified.isChangedOnce();
    if (!flag && !this.positionModified.isChangedOnce())
      return;
    if (flag)
      this.positionModified = BL.Observe<BL.UnitPosition>(this.env.core.currentUnitPosition);
    if (this.lastRoute != null)
      BattleFuncs.setAttributePanels((IEnumerable<BL.Panel>) this.lastRoute, BL.PanelAttribute.moving, true);
    if (this.lastMovePanels != null)
      BattleFuncs.setAttributePanels((IEnumerable<BL.Panel>) this.lastMovePanels, this.lastAttribute, true);
    if (this.lastAttackPanels != null)
      BattleFuncs.setAttributePanels((IEnumerable<BL.Panel>) this.lastAttackPanels, BL.PanelAttribute.attack_range, true);
    if (this.lastAttackTargetPanels != null)
    {
      BattleFuncs.setAttributePanels((IEnumerable<BL.Panel>) this.lastAttackTargetPanels, BL.PanelAttribute.target_attack, true);
      foreach (BL.Panel attackTargetPanel in this.lastAttackTargetPanels)
      {
        if (this.inputObserver.isTargetSelectMode)
        {
          BL.UnitPosition fieldUnit = this.env.core.getFieldUnit(attackTargetPanel);
          if (fieldUnit == null || !this.inputObserver.containsTargetSelect(fieldUnit.unit))
            this.objectManager.hideButton(attackTargetPanel);
        }
        else
          this.objectManager.hideButton(attackTargetPanel);
      }
    }
    if (this.lastHealPanels != null)
      BattleFuncs.setAttributePanels((IEnumerable<BL.Panel>) this.lastHealPanels, BL.PanelAttribute.heal_range, true);
    if (this.lastHealTargetPanels != null)
    {
      BattleFuncs.setAttributePanels((IEnumerable<BL.Panel>) this.lastHealTargetPanels, BL.PanelAttribute.target_heal, true);
      foreach (BL.Panel lastHealTargetPanel in this.lastHealTargetPanels)
      {
        if (this.inputObserver.isTargetSelectMode)
        {
          BL.UnitPosition fieldUnit = this.env.core.getFieldUnit(lastHealTargetPanel);
          if (fieldUnit == null || !this.inputObserver.containsTargetSelect(fieldUnit.unit))
            this.objectManager.hideButton(lastHealTargetPanel);
        }
        else
          this.objectManager.hideButton(lastHealTargetPanel);
      }
    }
    BL.Unit unit = this.currentModified.value.unit;
    if (unit != null && !unit.isDead)
    {
      BL.UnitPosition up = this.positionModified.value;
      BL.Panel fieldPanel = this.env.core.getFieldPanel(up);
      if (!up.isCompleted)
      {
        if (this.env.core.currentPhaseUnitp(up))
        {
          List<BL.Panel> routeNonCache = this.env.core.getRouteNonCache(up, this.env.core.getFieldPanel(up, true), this.env.core.getFieldPanel(up), this.inputObserver.getMovePanels(up));
          BattleFuncs.setAttributePanels((IEnumerable<BL.Panel>) routeNonCache, BL.PanelAttribute.moving, false);
          this.lastRoute = routeNonCache;
        }
        if (this.isDispositionMode)
          return;
        BL.PanelAttribute attribute;
        switch (this.env.core.getForceID(unit))
        {
          case BL.ForceID.player:
            attribute = BL.PanelAttribute.playermove;
            break;
          case BL.ForceID.neutral:
            attribute = BL.PanelAttribute.neutralmove;
            break;
          case BL.ForceID.enemy:
            attribute = BL.PanelAttribute.enemymove;
            break;
          default:
            attribute = BL.PanelAttribute.clear;
            break;
        }
        BattleFuncs.setAttributePanels((IEnumerable<BL.Panel>) up.movePanels, attribute, false);
        this.lastMovePanels = up.movePanels;
        this.lastAttribute = attribute;
        if (up.isActionComleted)
          return;
        this.lastAttackPanels = new HashSet<BL.Panel>((IEnumerable<BL.Panel>) up.allMoveActionRangePanels);
        this.lastAttackPanels.ExceptWith((IEnumerable<BL.Panel>) up.movePanels);
        BattleFuncs.setAttributePanels((IEnumerable<BL.Panel>) this.lastAttackPanels, BL.PanelAttribute.attack_range, false);
        if (up.unit.healRange.Length > 0)
        {
          this.lastHealPanels = new HashSet<BL.Panel>(up.allMoveHealRangePanels.Where<BL.Panel>((Func<BL.Panel, bool>) (n =>
          {
            BL.UnitPosition fieldUnit = this.env.core.getFieldUnit(n, true);
            if (fieldUnit == null)
              return !up.movePanels.Contains(n);
            if (up.unit == fieldUnit.unit)
              return false;
            BL.ForceID forceId = this.env.core.getForceID(fieldUnit.unit);
            return forceId == BL.ForceID.player || !((IEnumerable<BL.ForceID>) this.env.core.getTargetForce(up.unit)).Contains<BL.ForceID>(forceId);
          })));
          BattleFuncs.setAttributePanels((IEnumerable<BL.Panel>) this.lastHealPanels, BL.PanelAttribute.heal_range, false);
        }
        if (this.inputObserver.isTargetSelectMode)
          return;
        this.lastAttackTargetPanels = BattleFuncs.getAttackTargetPanels(up);
        BattleFuncs.setAttributePanels((IEnumerable<BL.Panel>) this.lastAttackTargetPanels, BL.PanelAttribute.target_attack, false);
        if (this.env.core.currentPhaseUnitp(up) && !up.isCompleted)
        {
          foreach (BL.Panel attackTargetPanel in this.lastAttackTargetPanels)
            this.objectManager.setButton(attackTargetPanel, false);
        }
        this.lastHealTargetPanels = BattleFuncs.getHealTargetPanels(up);
        BattleFuncs.setAttributePanels((IEnumerable<BL.Panel>) this.lastHealTargetPanels, BL.PanelAttribute.target_heal, false);
        if (!this.env.core.currentPhaseUnitp(up) || up.isCompleted)
          return;
        foreach (BL.Panel lastHealTargetPanel in this.lastHealTargetPanels)
          this.objectManager.setButton(lastHealTargetPanel, true);
      }
      else
        fieldPanel.unsetAttribute(BL.PanelAttribute.moving);
    }
    else
    {
      this.lastRoute = (List<BL.Panel>) null;
      this.lastMovePanels = this.lastAttackTargetPanels = this.lastAttackPanels = this.lastHealTargetPanels = this.lastHealPanels = (HashSet<BL.Panel>) null;
    }
  }

  private bool isDispositionMode => this.inputObserver.isDispositionMode;
}
