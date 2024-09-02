// Decompiled with JetBrains decompiler
// Type: Battle01SelectNode
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Battle01SelectNode : BattleMonoBehaviour
{
  public const string coin_path = "Prefabs/BattleCommon/coin/coin_prefab";
  public float dead_effect_time = 5f;
  public float pvp_dead_effect_time = 5f;
  private string effect_retreat = "Retreat";
  private string popupUnitDeadPlayerPrefab_path = "Prefabs/popup/Battle_Breakout";
  private string popupUnitDeadEnemyPrefab_path = "Prefabs/popup/Battle_Defeat";
  [SerializeField]
  private NGTweenParts autoBattle;
  [SerializeField]
  private NGTweenParts character_Act;
  [SerializeField]
  private NGTweenParts character_choosen;
  [SerializeField]
  private NGTweenParts character_choosen_enemy;
  [SerializeField]
  private NGTweenParts item_select;
  [SerializeField]
  private NGTweenParts item_subject;
  [SerializeField]
  private NGTweenParts skill_select;
  [SerializeField]
  private NGTweenParts skill_subject;
  [SerializeField]
  private NGTweenParts skill_use;
  [SerializeField]
  private NGTweenParts menu;
  [SerializeField]
  private NGTweenParts submenu;
  [SerializeField]
  private NGTweenParts item_button;
  [SerializeField]
  private NGTweenParts back;
  [SerializeField]
  private NGTweenParts back_up;
  [SerializeField]
  private NGTweenParts grandstatus_left;
  [SerializeField]
  private NGTweenParts grandstatus_right;
  [SerializeField]
  private Battle01TipEventWindow tipevent;
  [SerializeField]
  private NGTweenParts withdraw;
  [SerializeField]
  private GameObject talkButtonPoint;
  [SerializeField]
  private GameObject uiMaskPanel;
  [SerializeField]
  private GameObject remain_turn;
  [SerializeField]
  private NGTweenParts pvp_position_arrange;
  [SerializeField]
  private NGTweenParts pvp_ready;
  [SerializeField]
  private GameObject autoButton;
  [SerializeField]
  private GameObject DenaAutoAndEndMenu;
  private BL.BattleModified<BL.CurrentUnit> currentUnitModified;
  private BL.BattleModified<BL.PhaseState> phaseStateModified;
  private BL.BattleModified<BL.StructValue<bool>> isAutoBattleModified;
  private BL.BattleModified<BL.ClassValue<List<BL.Item>>> itemModified;
  private List<BL.BattleModified<BL.UnitPosition>> playerUnitPositionModifiedList;
  private List<BL.BattleModified<BL.Unit>> unitModifiedList;
  private NGTweenParts current;
  private Stack<NGTweenParts> stack = new Stack<NGTweenParts>();
  private TreasureBoxManager tbManager;
  private BattleTimeManager btm;
  private GameObject coinPrefab;
  private GameObject popupUnitDeadPlayerPrefab;
  private GameObject popupUnitDeadEnemyPrefab;
  [SerializeField]
  private Battle01UIPlayerStatus enemyStatus;
  private BattleInputObserver inputObserver;
  private bool backup3DUIMask;
  private bool backupUIMask;
  private bool is_push;

  [DebuggerHidden]
  public override IEnumerator onInitAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01SelectNode.\u003ConInitAsync\u003Ec__Iterator857()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void initializeStage()
  {
    this.playerUnitPositionModifiedList = new List<BL.BattleModified<BL.UnitPosition>>();
    foreach (BL.Unit unit in this.env.core.playerUnits.value)
      this.playerUnitPositionModifiedList.Add(BL.Observe<BL.UnitPosition>(this.env.core.getUnitPosition(unit)));
    this.unitModifiedList = new List<BL.BattleModified<BL.Unit>>();
    foreach (BL.UnitPosition unitPosition in this.env.core.unitPositions.value)
      this.unitModifiedList.Add(BL.Observe<BL.Unit>(unitPosition.unit));
    this.setEnemyUnit(this.env.core.enemyUnits.value[0]);
    this.remain_turn.SetActive(this.env.core.condition.isTurn || this.env.core.condition.isElapsedTurn);
  }

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01SelectNode.\u003CStart_Battle\u003Ec__Iterator858()
    {
      \u003C\u003Ef__this = this
    };
  }

  private bool phasePlayerp()
  {
    return this.env.core.phaseState.state == BL.Phase.player || this.env.core.phaseState.state == BL.Phase.pvp_player_start;
  }

  private bool nodeDefaultp()
  {
    return Object.op_Equality((Object) this.current, (Object) this.autoBattle) || Object.op_Equality((Object) this.current, (Object) this.character_Act) || Object.op_Equality((Object) this.current, (Object) this.character_choosen) || Object.op_Equality((Object) this.current, (Object) this.character_choosen_enemy) || Object.op_Equality((Object) this.current, (Object) this.pvp_ready);
  }

  private bool isDisposition => this.env.core.phaseState.state == BL.Phase.pvp_disposition;

  private bool menuActivep()
  {
    BL.Unit unit = this.env.core.unitCurrent.unit;
    return !this.isDisposition && unit != null && unit.isPlayerControl && this.env.core.currentPhaseUnitp(unit);
  }

  private bool itemActivep()
  {
    return !this.env.core.firstCompleted.value && this.env.core.itemListInBattle.value.Count != 0 && !this.menuActivep();
  }

  private void setCurrent(NGTweenParts node, bool isStack = false, bool popStack = false)
  {
    if (Object.op_Equality((Object) node, (Object) null) && popStack)
      node = this.stack.Pop();
    if (Object.op_Inequality((Object) this.current, (Object) node))
    {
      if (Object.op_Inequality((Object) this.current, (Object) null))
      {
        this.setScrollSeEnable(this.current, false);
        this.current.isActive = false;
        if (Object.op_Equality((Object) this.current, (Object) this.character_Act) && Object.op_Inequality((Object) this.DenaAutoAndEndMenu, (Object) null))
          this.DenaAutoAndEndMenu.SetActive(false);
        if (isStack)
          this.stack.Push(this.current);
        else if (!popStack)
          this.stack.Clear();
      }
      node.isActive = true;
      this.current = node;
      if (Object.op_Equality((Object) this.current, (Object) this.character_Act) && Object.op_Inequality((Object) this.DenaAutoAndEndMenu, (Object) null))
        this.DenaAutoAndEndMenu.SetActive(true);
    }
    this.setScrollSeEnable(this.current, true);
    if (this.nodeDefaultp())
    {
      if (Object.op_Equality((Object) this.current, (Object) this.character_choosen) || Object.op_Equality((Object) this.current, (Object) this.character_choosen_enemy))
      {
        this.menu.isActive = this.menuActivep();
        this.item_button.isActive = false;
        if (this.isDisposition)
          this.pvp_position_arrange.isActive = true;
        else
          this.back_up.isActive = this.phasePlayerp();
      }
      else if (Object.op_Equality((Object) this.current, (Object) this.character_Act))
      {
        this.menu.isActive = false;
        this.item_button.isActive = this.itemActivep();
        this.back_up.isActive = false;
      }
      else if (Object.op_Equality((Object) this.current, (Object) this.pvp_ready))
      {
        this.menu.isActive = false;
        this.pvp_position_arrange.isActive = false;
      }
      else
      {
        this.menu.isActive = false;
        this.item_button.isActive = false;
        this.back_up.isActive = false;
      }
      this.back.isActive = false;
    }
    else
    {
      this.menu.isActive = false;
      this.item_button.isActive = false;
      this.back_up.isActive = true;
      this.back.isActive = false;
    }
  }

  private void selectPhaseDefault(BL.PhaseState phase)
  {
    if (this.env.core.isAutoBattle.value)
    {
      this.setCurrent(this.autoBattle);
      if (phase.state != BL.Phase.player && phase.state != BL.Phase.enemy && phase.state != BL.Phase.neutral)
        return;
      this.uiMaskPanel.SetActive(false);
    }
    else
    {
      BL.Phase state = phase.state;
      switch (state)
      {
        case BL.Phase.turn_initialize:
        case BL.Phase.player_start_post:
label_8:
          if (this.env.core.unitCurrent.unit == null)
          {
            this.setCharacterAct();
            break;
          }
          if (this.env.core.getForceID(this.env.core.unitCurrent.unit) != BL.ForceID.player)
          {
            this.setCharacterChoosenEnemy();
            break;
          }
          this.setupUICantChangeCurrent(this.env.core.currentUnitPosition.cantChangeCurrent);
          this.setCharacterChoosen();
          break;
        case BL.Phase.finalize:
        case BL.Phase.suspend:
        case BL.Phase.all_dead_enemy:
label_16:
          this.uiMaskPanel.SetActive(true);
          break;
        case BL.Phase.all_dead_player:
          break;
        case BL.Phase.all_dead_neutral:
          break;
        default:
          switch (state + 1)
          {
            case BL.Phase.player_start:
              return;
            case BL.Phase.neutral_start:
            case BL.Phase.neutral:
              goto label_8;
            default:
              switch (state)
              {
                case BL.Phase.pvp_move_unit_waiting:
                case BL.Phase.pvp_player_start:
                  goto label_8;
                case BL.Phase.pvp_disposition:
                  if (this.env.core.unitCurrent.unit == null)
                  {
                    this.setPvpReady();
                    return;
                  }
                  this.setCharacterChoosen();
                  return;
                default:
                  if (state != BL.Phase.stageclear && state != BL.Phase.gameover)
                  {
                    if (state != BL.Phase.battle_start && state != BL.Phase.battle_start_init)
                    {
                      if (this.env.core.unitCurrent.unit == null)
                      {
                        this.setCharacterChoosen();
                        return;
                      }
                      this.setCharacterChoosenEnemy();
                      return;
                    }
                    goto label_8;
                  }
                  else
                    goto label_16;
              }
          }
      }
    }
  }

  private Vector3 createTargetVector(BL.DropData drop)
  {
    Transform labelTransform = ((Component) this.grandstatus_right).GetComponent<Battle01GrandStatusRight>().getLabelTransform(drop);
    return Object.op_Equality((Object) labelTransform, (Object) null) ? Vector3.zero : Singleton<CommonRoot>.GetInstance().getCamera().WorldToScreenPoint(labelTransform.position);
  }

  private void deadComplete(BL.Unit u)
  {
    u.setIsDead(true, this.env.core);
    this.env.core.getUnitPosition(u).completeActionUnit(this.env.core, true);
    if (this.battleManager.isPvp)
    {
      this.battleManager.pvpManager.deadReserveToPoint(u.playerUnit.is_enemy);
    }
    else
    {
      if (!this.battleManager.isGvg)
        return;
      this.battleManager.gvgManager.deadReserveToPoint(u.playerUnit.is_enemy);
    }
  }

  public void setMaskActive(bool v, bool forcibly = false)
  {
    this.btm.setScheduleAction((System.Action) (() =>
    {
      CommonRoot instance = Singleton<CommonRoot>.GetInstance();
      if (forcibly)
      {
        instance.isActive3DUIMask = this.backup3DUIMask = v;
        this.uiMaskPanel.SetActive(this.backupUIMask = !this.env.core.isAutoBattle.value && v);
      }
      else if (v)
      {
        this.backup3DUIMask = instance.isActive3DUIMask;
        this.backupUIMask = this.uiMaskPanel.activeSelf;
        instance.isActive3DUIMask = v;
        this.uiMaskPanel.SetActive(v);
      }
      else
      {
        instance.isActive3DUIMask = this.backup3DUIMask;
        this.uiMaskPanel.SetActive(this.backupUIMask);
      }
    }));
  }

  private void doEnemyDead(BL.Unit u)
  {
    BL.Panel fieldPanel = this.env.core.getFieldPanel(this.env.core.getUnitPosition(u));
    BE.PanelResource panelR = this.env.panelResource[fieldPanel];
    GameObject coin = (GameObject) null;
    if (u.dropMoney > 0)
    {
      this.setMaskActive(true);
      this.btm.setScheduleAction((System.Action) (() =>
      {
        coin = this.coinPrefab.Clone(panelR.gameObject.transform);
        coin.transform.localPosition = panelR.gameObject.GetComponent<BattlePanelParts>().getLocalPosition();
      }), 1.5f, (System.Action) (() => Object.Destroy((Object) coin)), isInsertMode: true);
      this.btm.setScheduleAction((System.Action) (() => this.env.core.dropMoney.value += u.dropMoney));
    }
    bool flag = u.hasDrop && !u.drop.isCompleted;
    BL.Unit cunit = this.env.core.unitCurrent.unit;
    if (flag)
    {
      if (u.dropMoney <= 0)
        this.setMaskActive(true);
      this.tbManager.execute(u.drop, fieldPanel, this.createTargetVector(u.drop), (Action<BL.DropData>) (drop => this.tipevent.open(drop, cunit)), (Action<BL.DropData>) (drop =>
      {
        drop.execute(cunit, this.env.core);
        this.tipevent.dismiss();
        this.deadComplete(u);
      }), 2f);
      this.setMaskActive(false);
    }
    else
    {
      this.btm.setScheduleAction((System.Action) (() => this.deadComplete(u)), isInsertMode: true);
      this.setMaskActive(false);
    }
    List<BL.Story> sdl = this.env.core.getStoryDefeat(u.specificId);
    if (sdl == null || sdl.Count <= 0)
      return;
    this.btm.setScheduleAction((System.Action) (() => sdl.ForEach((Action<BL.Story>) (story => this.battleManager.startStory(story)))), isInsertMode: true);
  }

  public bool hpCheckWithDeadEffects(BL.Unit unit)
  {
    if (unit.isDead || unit.hp > 0)
      return false;
    BE.UnitResource unitResource = this.env.unitResource[unit];
    this.btm.setTargetUnit(this.env.core.getUnitPosition(unit), 0.1f);
    BattleUnitParts up = unitResource.gameObject.GetComponent<BattleUnitParts>();
    if (Object.op_Inequality((Object) up, (Object) null))
    {
      this.btm.setScheduleAction((System.Action) (() => up.dead()));
      this.btm.setEnableWait(1f);
    }
    BL.ForceID forceId = this.env.core.getForceID(unit);
    if (this.battleManager.isOvo)
      this.battleManager.battleEffects.startEffect(this.effect_retreat, this.pvp_dead_effect_time, (System.Action) (() => this.deadComplete(unit)), popupPrefab: forceId != BL.ForceID.player ? this.popupUnitDeadEnemyPrefab : this.popupUnitDeadPlayerPrefab, alert: true, cloneAction: (Action<GameObject>) (po => po.GetComponentInChildren<Battle01712aMenu>().setUnit(unit)));
    else if (forceId == BL.ForceID.player)
      this.battleManager.battleEffects.startEffect(this.effect_retreat, this.dead_effect_time, (System.Action) (() => this.deadComplete(unit)), popupPrefab: this.popupUnitDeadPlayerPrefab, alert: true, cloneAction: (Action<GameObject>) (po => po.GetComponentInChildren<Battle01712aMenu>().setUnit(unit)));
    else
      this.doEnemyDead(unit);
    return true;
  }

  private void panelEventCheckWithEffects(BL.UnitPosition up)
  {
    if (!up.isCompleted || up.unit.isDead)
      return;
    BL.Panel panel = this.env.core.getFieldPanel(up);
    if (!panel.hasEvent)
      return;
    this.setMaskActive(true);
    this.btm.setTargetPanel(panel, 0.0f, (System.Action) (() => { }), isWaitCameraMove: true);
    this.tbManager.execute(panel.fieldEvent, panel, this.createTargetVector(panel.fieldEvent), (Action<BL.DropData>) (drop => this.tipevent.open(drop, up.unit)), (Action<BL.DropData>) (drop =>
    {
      panel.executeEvent(up.unit, this.env.core);
      this.tipevent.dismiss();
      this.setMaskActive(false);
    }), 2f);
  }

  protected override void Update_Battle()
  {
    if (!this.battleManager.isBattleEnable)
    {
      if (!Object.op_Equality((Object) this.current, (Object) this.skill_select))
        return;
      this.setCurrent(this.character_choosen);
    }
    else
    {
      foreach (BL.BattleModified<BL.Unit> unitModified in this.unitModifiedList)
      {
        if (unitModified.isChangedOnce())
        {
          BL.Unit unit = unitModified.value;
          this.btm.setScheduleAction((System.Action) (() => this.hpCheckWithDeadEffects(unit)), isInsertMode: true);
        }
      }
      bool flag = false;
      BL.UnitPosition unitPosition = (BL.UnitPosition) null;
      foreach (BL.BattleModified<BL.UnitPosition> positionModified in this.playerUnitPositionModifiedList)
      {
        BL.UnitPosition up = positionModified.value;
        if (positionModified.isChangedOnce())
        {
          if (this.env.core.unitCurrent.unit == up.unit)
          {
            flag = true;
            unitPosition = up;
          }
          this.btm.setScheduleAction((System.Action) (() => this.panelEventCheckWithEffects(up)), isInsertMode: true);
        }
      }
      if (flag && unitPosition != null)
        this.setupUICantChangeCurrent(unitPosition.cantChangeCurrent);
      if (this.currentUnitModified.isChangedOnce())
      {
        if (this.stack.Count > 0)
          this.backToTop();
        else
          this.selectPhaseDefault(this.env.core.phaseState);
      }
      if (this.phaseStateModified.isChangedOnce())
      {
        BL.PhaseState phase = this.phaseStateModified.value;
        if (this.battleManager.isOvo)
          this.setMaskActive((phase.state == BL.Phase.player || phase.state == BL.Phase.enemy ? 1 : (phase.state == BL.Phase.pvp_disposition ? 1 : 0)) == 0, true);
        else
          this.setMaskActive(phase.state != BL.Phase.player, true);
        if (this.nodeDefaultp())
          this.selectPhaseDefault(phase);
      }
      if (this.isAutoBattleModified.isChangedOnce())
      {
        this.selectPhaseDefault(this.env.core.phaseState);
        this.uiMaskPanel.SetActive(this.isAutoBattleModified.value.value);
      }
      if (!this.itemModified.isChangedOnce() || !this.item_button.isActive)
        return;
      this.item_button.isActive = this.itemActivep();
    }
  }

  private void setCharacterAct()
  {
    if (this.battleManager.isOvo && !this.battleManager.gameEngine.isDisposition && Object.op_Inequality((Object) ((Component) this).GetComponent<Battle01PVPNode>(), (Object) null))
      this.setPvpReady();
    else
      this.setCurrent(this.character_Act);
  }

  private void setPvpReady() => this.setCurrent(this.pvp_ready);

  private void setEnemyUnit(BL.Unit unit)
  {
    if (Object.op_Equality((Object) this.enemyStatus, (Object) null))
      this.enemyStatus = ((Component) this.character_choosen_enemy).gameObject.GetComponentsInChildren<Battle01UIPlayerStatus>(true)[0];
    this.enemyStatus.setUnit(unit);
  }

  private void setCharacterChoosenEnemy()
  {
    if (this.env.core.unitCurrent.unit != null && (this.battleManager.isOvo || this.env.core.getForceID(this.env.core.unitCurrent.unit) != BL.ForceID.player))
      this.setEnemyUnit(this.env.core.unitCurrent.unit);
    this.setCurrent(this.character_choosen_enemy);
  }

  private void setCharacterChoosen()
  {
    this.resetScrollPosition(this.character_choosen, this.env.core.unitCurrent.unit);
    this.setCurrent(this.character_choosen);
  }

  public void useOugi(BL.Unit unit, BL.Skill ougi) => this.useSkillSubject(unit, ougi);

  public void useSkill()
  {
    if (!this.phasePlayerp())
      return;
    Battle01SkillSelect[] componentsInChildren = ((Component) this).GetComponentsInChildren<Battle01SkillSelect>(true);
    if (componentsInChildren.Length == 0)
      return;
    List<BL.Skill> list = this.env.core.getFieldSkills(this.env.core.unitCurrent.unit).OrderBy<BL.Skill, int>((Func<BL.Skill, int>) (x => x.remain.HasValue && x.remain.Value > 0 ? 0 : 1)).ToList<BL.Skill>();
    componentsInChildren[0].setList(list);
    this.setCurrent(this.skill_select, true);
  }

  public void useSkillUse(BL.Skill skill, List<BL.Unit> targets)
  {
    if (!this.phasePlayerp())
      return;
    Battle01SkillUse[] componentsInChildren = ((Component) this).GetComponentsInChildren<Battle01SkillUse>(true);
    if (componentsInChildren.Length == 0)
      return;
    componentsInChildren[0].setSkillTargets(this.env.core.unitCurrent.unit, skill, targets);
    this.setCurrent(this.skill_use, true);
  }

  public void useSkillSubject(BL.Unit unit, BL.Skill skill)
  {
    if (!this.phasePlayerp())
      return;
    List<BL.Unit> skillTargetUnits = this.env.core.getSkillTargetUnits(this.env.core.currentUnitPosition, skill);
    if (skill.isNonSelect)
    {
      this.useSkillUse(skill, skillTargetUnits);
    }
    else
    {
      Battle01SkillSubject[] componentsInChildren = ((Component) this).GetComponentsInChildren<Battle01SkillSubject>(true);
      if (componentsInChildren.Length == 0)
        return;
      componentsInChildren[0].setSkillTargets(unit, skill, skillTargetUnits);
      this.setCurrent(this.skill_subject, true);
    }
  }

  public void useItem()
  {
    if (!this.phasePlayerp())
      return;
    this.setCurrent(this.item_select, true);
  }

  public void useItemSubject(BL.Item item)
  {
    if (!this.phasePlayerp())
      return;
    Battle01ItemSubject[] componentsInChildren = ((Component) this).GetComponentsInChildren<Battle01ItemSubject>(true);
    if (componentsInChildren.Length == 0)
      return;
    List<BL.Unit> itemTargetUnits = this.env.core.getItemTargetUnits(item);
    componentsInChildren[0].setItemTargets(item, itemTargetUnits);
    this.setCurrent(this.item_subject, true);
  }

  public void backToTop()
  {
    this.stack.Clear();
    this.inputObserver.cancelTargetSelect();
    this.selectPhaseDefault(this.env.core.phaseState);
  }

  public void onBack()
  {
    if (Object.op_Equality((Object) this.current, (Object) this.skill_subject) || Object.op_Equality((Object) this.current, (Object) this.item_subject) || Object.op_Equality((Object) this.current, (Object) this.skill_use))
      this.inputObserver.cancelTargetSelect();
    if (this.stack.Count > 0)
    {
      this.setCurrent((NGTweenParts) null, popStack: true);
    }
    else
    {
      this.btm.setCurrentUnit((BL.Unit) null);
      this.selectPhaseDefault(this.env.core.phaseState);
    }
  }

  public bool canOpenMenu()
  {
    return !Object.op_Equality((Object) this.current, (Object) null) && Object.op_Equality((Object) this.current, (Object) this.character_Act);
  }

  private void setScrollSeEnable(NGTweenParts parts, bool enable)
  {
    foreach (NGHorizontalScrollParts componentsInChild in ((Component) parts).GetComponentsInChildren<NGHorizontalScrollParts>(true))
    {
      if (enable)
        this.StartCoroutine(this.WaitScrollSe(componentsInChild));
      else
        componentsInChild.SeEnable = false;
    }
  }

  [DebuggerHidden]
  private IEnumerator WaitScrollSe(NGHorizontalScrollParts obj)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01SelectNode.\u003CWaitScrollSe\u003Ec__Iterator859()
    {
      obj = obj,
      \u003C\u0024\u003Eobj = obj
    };
  }

  private void setupUICantChangeCurrent(bool cantchange)
  {
    this.setEnableScroll(this.character_choosen, !cantchange);
    this.setEnableBackUp(!cantchange);
    this.setEnableSubMenu(!cantchange);
  }

  private void setEnableScroll(NGTweenParts parts, bool enable)
  {
    NGHorizontalScrollParts componentInChildren = !Object.op_Inequality((Object) parts, (Object) null) ? (NGHorizontalScrollParts) null : ((Component) parts).GetComponentInChildren<NGHorizontalScrollParts>();
    if (!Object.op_Inequality((Object) componentInChildren, (Object) null))
      return;
    UIScrollView component = !Object.op_Inequality((Object) componentInChildren.scrollView, (Object) null) ? (UIScrollView) null : componentInChildren.scrollView.GetComponent<UIScrollView>();
    if (Object.op_Inequality((Object) component, (Object) null))
      ((Behaviour) component).enabled = enable;
    if (Object.op_Inequality((Object) componentInChildren.leftArrow, (Object) null))
      componentInChildren.leftArrow.SetActive(enable);
    if (!Object.op_Inequality((Object) componentInChildren.rightArrow, (Object) null))
      return;
    componentInChildren.rightArrow.SetActive(enable);
  }

  private void setEnableBackUp(bool enable)
  {
    UIButton component = !Object.op_Inequality((Object) this.back_up, (Object) null) ? (UIButton) null : ((Component) this.back_up).GetComponent<UIButton>();
    if (!Object.op_Inequality((Object) component, (Object) null))
      return;
    component.isEnabled = enable;
  }

  private void setEnableSubMenu(bool enable)
  {
    GameObject btnSubMenu = this.getBtnSubMenu();
    UIButton component = !Object.op_Inequality((Object) btnSubMenu, (Object) null) ? (UIButton) null : btnSubMenu.GetComponent<UIButton>();
    if (!Object.op_Inequality((Object) component, (Object) null))
      return;
    component.isEnabled = enable;
  }

  private GameObject getBtnSubMenu()
  {
    if (Object.op_Equality((Object) this.submenu, (Object) null))
      return (GameObject) null;
    Transform child = ((Component) this.submenu).transform.FindChild("ibtn_menu");
    return Object.op_Inequality((Object) child, (Object) null) ? ((Component) child).gameObject : (GameObject) null;
  }

  private void resetScrollPosition(NGTweenParts parts, BL.Unit unit)
  {
    if (Object.op_Equality((Object) parts, (Object) null) || unit == null)
      return;
    Battle01StatusScrollParts componentInChildren = ((Component) parts).GetComponentInChildren<Battle01StatusScrollParts>();
    if (Object.op_Equality((Object) componentInChildren, (Object) null))
      return;
    componentInChildren.resetScrollPosition(unit);
  }

  [DebuggerHidden]
  private IEnumerator AutoBattleStartPop()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01SelectNode.\u003CAutoBattleStartPop\u003Ec__Iterator85A()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator TurnEndPop()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01SelectNode.\u003CTurnEndPop\u003Ec__Iterator85B()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnAutoBattle()
  {
    if (this.IsPushCheck())
      return;
    this.StartCoroutine(this.AutoBattleStartPop());
  }

  public void IbtnTurnEnd()
  {
    if (this.IsPushCheck())
      return;
    this.StartCoroutine(this.TurnEndPop());
  }

  private bool IsPushCheck()
  {
    if (this.battleManager.environment.core.phaseState.state == BL.Phase.gameover || this.is_push)
      return true;
    this.is_push = true;
    this.StartCoroutine(this.pushCancel());
    return false;
  }

  [DebuggerHidden]
  private IEnumerator pushCancel()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01SelectNode.\u003CpushCancel\u003Ec__Iterator85C()
    {
      \u003C\u003Ef__this = this
    };
  }
}
