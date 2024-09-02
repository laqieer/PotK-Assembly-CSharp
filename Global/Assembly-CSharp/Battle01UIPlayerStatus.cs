// Decompiled with JetBrains decompiler
// Type: Battle01UIPlayerStatus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Battle01UIPlayerStatus : NGBattleMenuBase
{
  public NGTweenGaugeScale hpGauge;
  [SerializeField]
  protected SelectParts statusBase;
  [SerializeField]
  protected UI2DSprite character;
  [SerializeField]
  protected UI2DSprite weapon;
  [SerializeField]
  protected UILabel txt_CharacterName;
  [SerializeField]
  protected UILabel txt_Lv;
  [SerializeField]
  protected UILabel txt_Fighting;
  [SerializeField]
  protected UILabel txt_Hp;
  [SerializeField]
  protected UILabel txt_Hpmax;
  [SerializeField]
  protected UILabel txt_Jobname;
  [SerializeField]
  protected UILabel txt_Movement;
  [SerializeField]
  protected UILabel txt_Attack;
  [SerializeField]
  protected UILabel txt_Critical;
  [SerializeField]
  protected UILabel txt_Defense;
  [SerializeField]
  protected UILabel txt_Dexterity;
  [SerializeField]
  protected UILabel txt_Evasion;
  [SerializeField]
  protected UILabel txt_Matk;
  [SerializeField]
  protected UILabel txt_Mdef;
  private BL.BattleModified<BL.Unit> modified;
  [SerializeField]
  protected UIWidget[] dyn_Ailments;
  [SerializeField]
  protected UIButton[] btn_Ailments;
  private UnitIcon unitIcon;
  private GearKindIcon gearIcon;
  private List<BattleSkillIcon> skillIcons;
  private GameObject popupInfoPrefab;
  private GameObject skillDialogPrefab;
  private bool isSetHp;
  private Color mGreen = new Color(0.0f, 0.863f, 0.118f);
  private Color mRed = new Color(0.98f, 0.0f, 0.0f);
  private Color mOrigin = new Color(1f, 1f, 1f);

  private void Awake()
  {
    ((Behaviour) this.character).enabled = false;
    ((Behaviour) this.weapon).enabled = false;
    foreach (UIWidget componentsInChild in ((Component) this).gameObject.GetComponentsInChildren<UIWidget>(true))
    {
      if (Object.op_Equality((Object) ((Component) componentsInChild).GetComponent<UIButton>(), (Object) null))
        componentsInChild.alpha = 0.0f;
    }
  }

  [DebuggerHidden]
  public override IEnumerator onInitAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01UIPlayerStatus.\u003ConInitAsync\u003Ec__Iterator727()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator doSetIcon(BL.Unit unit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01UIPlayerStatus.\u003CdoSetIcon\u003Ec__Iterator728()
    {
      unit = unit,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator doSetAilmentIcon(int index, BattleskillSkill skill, int? remainTurn)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01UIPlayerStatus.\u003CdoSetAilmentIcon\u003Ec__Iterator729()
    {
      skill = skill,
      index = index,
      remainTurn = remainTurn,
      \u003C\u0024\u003Eskill = skill,
      \u003C\u0024\u003Eindex = index,
      \u003C\u0024\u003EremainTurn = remainTurn,
      \u003C\u003Ef__this = this
    };
  }

  protected override void LateUpdate_Battle()
  {
    if (this.modified == null)
      return;
    bool flag = this.modified.isChangedOnce();
    if (flag)
    {
      BL.Unit unit = this.modified.value;
      Judgement.BattleParameter battleParameter = Judgement.BattleParameter.FromBeUnit(unit);
      this.statusBase.setValueNonTween((int) this.env.core.getForceID(unit));
      this.StartCoroutine(this.doSetIcon(unit));
      this.gearIcon.Init(unit.unit.kind, unit.playerUnit.GetElement());
      this.setText(this.txt_CharacterName, unit.unit.name);
      this.setText(this.txt_Lv, unit.lv);
      this.setColordText(this.txt_Fighting, battleParameter.Combat, battleParameter.CombatIncr, string.Empty);
      this.setColordText_BeforeStringNoColorChange(this.txt_Hpmax, battleParameter.Hp, battleParameter.HpIncr, "/");
      this.setText(this.txt_Jobname, unit.job.name);
      this.setColordText(this.txt_Movement, battleParameter.Move, battleParameter.MoveIncr, string.Empty);
      this.setColordText(this.txt_Attack, battleParameter.PhysicalAttack, battleParameter.PhysicalAttackIncr, string.Empty);
      this.setColordText(this.txt_Defense, battleParameter.PhysicalDefense, battleParameter.PhysicalDefenseIncr, string.Empty);
      this.setColordText(this.txt_Matk, battleParameter.MagicAttack, battleParameter.MagicAttackIncr, string.Empty);
      this.setColordText(this.txt_Mdef, battleParameter.MagicDefense, battleParameter.MagicDefenseIncr, string.Empty);
      this.setColordText(this.txt_Dexterity, battleParameter.Hit, battleParameter.HitIncr, string.Empty);
      this.setColordText(this.txt_Evasion, battleParameter.Evasion, battleParameter.EvasionIncr, string.Empty);
      this.setColordText(this.txt_Critical, battleParameter.Critical, battleParameter.CriticalIncr, string.Empty);
      foreach (UIWidget componentsInChild in ((Component) this).gameObject.GetComponentsInChildren<UIWidget>(true))
      {
        if ((double) componentsInChild.alpha == 0.0 && Object.op_Equality((Object) ((Component) componentsInChild).GetComponent<UIButton>(), (Object) null))
          componentsInChild.alpha = 1f;
      }
    }
    if (this.battleManager.isBattleEnable)
    {
      if (!flag && !this.isSetHp)
        return;
      BL.Unit beUnit = this.modified.value;
      Judgement.BattleParameter battleParameter = Judgement.BattleParameter.FromBeUnit(beUnit);
      this.hpGauge.setValue(beUnit.hp, battleParameter.Hp);
      this.setText(this.txt_Hp, beUnit.hp);
      List<Tuple<BattleskillSkill, int?>> ailmentData = beUnit.skillEffects.GetAilmentData();
      for (int index = 0; index < this.skillIcons.Count; ++index)
      {
        if (ailmentData.Count > index)
        {
          this.StartCoroutine(this.doSetAilmentIcon(index, ailmentData[index].Item1, ailmentData[index].Item2));
        }
        else
        {
          ((Component) this.skillIcons[index]).gameObject.SetActive(false);
          this.btn_Ailments[index].onClick.Clear();
        }
      }
      this.isSetHp = false;
    }
    else
    {
      if (!flag)
        return;
      this.isSetHp = true;
    }
  }

  public void setUnit(BL.Unit unit)
  {
    this.setText(this.txt_Hp, unit.hp);
    this.hpGauge.setValue(unit.hp, unit.parameter.Hp, false);
    this.modified = BL.Observe<BL.Unit>(unit);
  }

  public BL.Unit getUnit() => this.modified.value;

  public void onButtonInfo()
  {
    if (!this.battleManager.isBattleEnable || this.env.core.unitCurrent.unit == null)
      return;
    this.battleManager.popupOpen(this.popupInfoPrefab);
  }

  public void onButtonSkillDetailDialog(BattleskillSkill skill, int? remainTurn)
  {
    Battle0171111Event componentInChildren = this.battleManager.popupOpen(this.skillDialogPrefab, true).GetComponentInChildren<Battle0171111Event>();
    if (!Object.op_Inequality((Object) null, (Object) componentInChildren))
      return;
    componentInChildren.setData(skill);
    componentInChildren.enableSkillLv(false);
    componentInChildren.setSkillProperty(false);
    if (remainTurn.HasValue && remainTurn.HasValue)
      componentInChildren.setRemainTurn(remainTurn.Value);
    else
      componentInChildren.disableRemainTurn();
    componentInChildren.isPopupManaged = true;
    componentInChildren.Show();
  }

  private void setColordText(UILabel label, int v, int bd, string before_string = "")
  {
    label.SetTextLocalize(before_string + (object) v);
    if (bd > 0)
      label.color = this.mGreen;
    else if (bd < 0)
      label.color = this.mRed;
    else
      label.color = this.mOrigin;
  }

  private void setColordText_BeforeStringNoColorChange(
    UILabel label,
    int v,
    int bd,
    string before_string = "")
  {
    label.color = this.mOrigin;
    string str = v.ToString();
    string text = bd <= 0 ? (bd >= 0 ? before_string + str : before_string + "[fa0000]" + str + "[-]") : before_string + "[00dc1e]" + str + "[-]";
    label.SetTextLocalize(text);
  }
}
