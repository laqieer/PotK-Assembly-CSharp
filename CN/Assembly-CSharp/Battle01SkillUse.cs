// Decompiled with JetBrains decompiler
// Type: Battle01SkillUse
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
  public GameObject typeIconPrefab;
  public GameObject targetIconPrefab;
  private BattleSkillIcon skillIcon;
  private SkillGenreIcon property1Icon;
  private SkillGenreIcon property2Icon;
  private BL.BattleModified<BL.Skill> modified;
  private BL.Unit unit;

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
    return (IEnumerator) new Battle01SkillUse.\u003CStart_Original\u003Ec__Iterator85F()
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
    if (hpCost < this.unit.hp)
    {
      this.notAvailable.SetActive(false);
      this.button.setEnable(true);
    }
    else
    {
      this.notAvailable.SetActive(true);
      this.button.setEnable(false);
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
    this.button.setData(unit, skill, targets);
    Singleton<NGBattleManager>.GetInstance().getController<BattleInputObserver>().setTargetSelectMode(targets, skill.isOwn, (Action<BL.Unit>) (u =>
    {
      Battle01CommandSkillUse[] componentsInChildren = ((Component) this).GetComponentsInChildren<Battle01CommandSkillUse>();
      if (componentsInChildren.Length == 0)
        return;
      componentsInChildren[0].onClick();
    }));
  }
}
