// Decompiled with JetBrains decompiler
// Type: Battle01SkillUse
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Battle01SkillUse : NGBattleMenuBase
{
  [SerializeField]
  private UI2DSprite icon;
  [SerializeField]
  private UI2DSprite property1;
  [SerializeField]
  private UI2DSprite property2;
  [SerializeField]
  private UILabel txt_name;
  [SerializeField]
  private UILabel txt_description;
  [SerializeField]
  private UILabel txt_consume_hp;
  [SerializeField]
  private Battle01CommandSkillUse button;
  [SerializeField]
  private GameObject title_skill;
  [SerializeField]
  private GameObject title_secrets;
  [SerializeField]
  private GameObject notAvailable;
  [SerializeField]
  private UILabel notAvailableTxt;
  public GameObject typeIconPrefab;
  public GameObject targetIconPrefab;
  private BattleSkillIcon skillIcon;
  private SkillGenreIcon property1Icon;
  private SkillGenreIcon property2Icon;
  private BL.BattleModified<BL.Skill> modified;
  private BL.Unit unit;
  private int targetsCount;

  private T clonePrefab<T>(GameObject prefab, UI2DSprite parent) where T : IconPrefabBase
  {
    ((Behaviour) parent).enabled = false;
    T component = prefab.CloneAndGetComponent<T>(((Component) parent).transform);
    if (Object.op_Equality((Object) (object) component, (Object) null))
      return (T) null;
    NGUITools.AdjustDepth(component.gameObject, parent.depth);
    component.SetBasedOnHeight(parent.height);
    return component;
  }

  [DebuggerHidden]
  protected override IEnumerator Start_Original()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01SkillUse.\u003CStart_Original\u003Ec__Iterator92A()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected override void Update_Battle()
  {
    if (this.modified == null || !this.modified.isChangedOnce())
      return;
    BL.Skill skill = this.modified.value;
    this.StartCoroutine(this.skillIcon.Init(skill.skill));
    this.property1Icon.Init(skill.genre1);
    this.property2Icon.Init(skill.genre2);
    this.setText(this.txt_name, skill.name);
    this.setText(this.txt_description, skill.description);
    int hpCost = skill.getHpCost(this.unit);
    if (Object.op_Inequality((Object) this.txt_consume_hp, (Object) null))
    {
      if (hpCost > 0)
      {
        ((Component) this.txt_consume_hp).gameObject.SetActive(true);
        string v = Consts.Format(Consts.GetInstance().BATTLE_UI_CONSUME_HP, (IDictionary) new Hashtable()
        {
          {
            (object) "hp",
            (object) hpCost
          }
        });
        if (hpCost < this.unit.hp)
          this.setText(this.txt_consume_hp, v);
        else
          this.setText(this.txt_consume_hp, "[ff0000]" + v);
      }
      else
        ((Component) this.txt_consume_hp).gameObject.SetActive(false);
    }
    if (!Object.op_Inequality((Object) this.notAvailable, (Object) null))
      return;
    bool flag1 = hpCost < this.unit.hp;
    bool flag2 = this.targetsCount > 0;
    if (flag1 && flag2)
    {
      this.notAvailable.SetActive(false);
      this.button.setEnable(true);
    }
    else
    {
      this.notAvailable.SetActive(true);
      this.button.setEnable(false);
      if (!flag2)
        this.notAvailableTxt.SetTextLocalize(Consts.GetInstance().BATTLE_UI_NOT_ENOUGH_TARGET);
      else if (!flag1)
        this.notAvailableTxt.SetTextLocalize(Consts.GetInstance().BATTLE_UI_NOT_ENOUGH_HP);
      else
        this.notAvailableTxt.SetTextLocalize(string.Empty);
    }
  }

  public void setSkillTargets(BL.Unit unit, BL.Skill skill, List<BL.Unit> targets)
  {
    this.modified = BL.Observe<BL.Skill>(skill);
    this.unit = unit;
    if (skill.isOugi)
    {
      this.title_skill.SetActive(false);
      this.title_secrets.SetActive(true);
    }
    else
    {
      this.title_skill.SetActive(true);
      this.title_secrets.SetActive(false);
    }
    List<BL.Unit> list1 = targets.Where<BL.Unit>((Func<BL.Unit, bool>) (x => x.skillEffects.CanUseSkill(skill.skill, (BL.ISkillEffectListUnit) x) == 0)).ToList<BL.Unit>();
    this.targetsCount = list1.Count;
    List<BL.Unit> list2 = targets.Where<BL.Unit>((Func<BL.Unit, bool>) (x => x.skillEffects.CanUseSkill(skill.skill, (BL.ISkillEffectListUnit) x) == 1)).ToList<BL.Unit>();
    this.button.setData(unit, skill, list1);
    Singleton<NGBattleManager>.GetInstance().getController<BattleInputObserver>().setTargetSelectMode(list1, skill.isOwn, list2, (Action<BL.Unit>) (u =>
    {
      Battle01CommandSkillUse[] componentsInChildren = ((Component) this).GetComponentsInChildren<Battle01CommandSkillUse>();
      if (componentsInChildren.Length == 0)
        return;
      componentsInChildren[0].onClick();
    }));
  }
}
