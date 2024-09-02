// Decompiled with JetBrains decompiler
// Type: Battle01SkillSubject
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Battle01SkillSubject : NGBattleMenuBase
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
  private GameObject notAvailable;
  [SerializeField]
  private List<GameObject> notAvailableReason;
  public GameObject typeIconPrefab;
  public GameObject targetIconPrefab;
  private BattleSkillIcon skillIcon;
  private SkillGenreIcon property1Icon;
  private SkillGenreIcon property2Icon;
  private BL.Unit unit;
  private BL.BattleModified<BL.Skill> modified;
  private List<BL.Unit> skillTargets;

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

  private void Awake()
  {
    this.skillIcon = this.clonePrefab<BattleSkillIcon>(this.typeIconPrefab, this.icon);
    this.property1Icon = this.clonePrefab<SkillGenreIcon>(this.targetIconPrefab, this.property1);
    this.property2Icon = this.clonePrefab<SkillGenreIcon>(this.targetIconPrefab, this.property2);
  }

  private void OnEnable()
  {
    if (this.modified == null || this.skillTargets == null)
      return;
    BL.Skill skill = this.modified.value;
    Battle01SkillUseSelect[] componentsInChildren = ((Component) this).GetComponentsInChildren<Battle01SkillUseSelect>(true);
    if (componentsInChildren.Length <= 0)
      return;
    componentsInChildren[0].setTargets(this.skillTargets, skill.isOwn);
  }

  [DebuggerHidden]
  protected override IEnumerator Start_Original()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Battle01SkillSubject.\u003CStart_Original\u003Ec__Iterator85E originalCIterator85E = new Battle01SkillSubject.\u003CStart_Original\u003Ec__Iterator85E();
    return (IEnumerator) originalCIterator85E;
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
    if (!Object.op_Inequality((Object) this.notAvailable, (Object) null) || this.notAvailableReason == null || this.notAvailableReason.Count <= 0)
      return;
    if (hpCost > 0 && hpCost >= this.unit.hp)
    {
      this.notAvailable.SetActive(true);
      this.notAvailableReason.ToggleOnce(0);
    }
    else if (this.skillTargets.Count <= 0)
    {
      this.notAvailable.SetActive(true);
      this.notAvailableReason.ToggleOnce(1);
    }
    else
      this.notAvailable.SetActive(false);
  }

  public void setSkillTargets(BL.Unit unit, BL.Skill skill, List<BL.Unit> targets)
  {
    this.unit = unit;
    this.modified = BL.Observe<BL.Skill>(skill);
    this.skillTargets = targets;
    Battle01SkillUseSelect[] componentsInChildren1 = ((Component) this).GetComponentsInChildren<Battle01SkillUseSelect>(true);
    if (componentsInChildren1.Length > 0)
      componentsInChildren1[0].setTargets(targets, skill.isOwn);
    Battle01SkillTitle[] componentsInChildren2 = ((Component) this).GetComponentsInChildren<Battle01SkillTitle>(true);
    if (componentsInChildren2.Length <= 0)
      return;
    componentsInChildren2[0].setSkill(skill);
  }

  public void useUnit(BL.Unit unit)
  {
    if (this.modified == null)
      return;
    NGUITools.FindInParents<Battle01SelectNode>(((Component) this).transform).useSkillUse(this.modified.value, new List<BL.Unit>()
    {
      unit
    });
  }
}
