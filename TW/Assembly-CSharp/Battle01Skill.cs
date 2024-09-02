// Decompiled with JetBrains decompiler
// Type: Battle01Skill
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Battle01Skill : NGBattleMenuBase
{
  [SerializeField]
  protected UI2DSprite skill;
  [SerializeField]
  protected UI2DSprite property01;
  [SerializeField]
  protected UI2DSprite property02;
  [SerializeField]
  protected UI2DSprite property03;
  [SerializeField]
  protected UILabel txt_name;
  [SerializeField]
  protected UILabel txt_remain;
  [SerializeField]
  private GameObject dir_Disable;
  private BL.BattleModified<BL.Skill> modified;
  private BL.BattleModified<BL.Unit> modifiedUnit;
  private GameObject typeIconPrefab;
  private GameObject targetIconPrefab;
  private BattleSkillIcon skillIcon;
  private SkillGenreIcon property01Icon;
  private SkillGenreIcon property02Icon;
  private SkillGenreIcon property03Icon;

  private T clonePrefab<T>(GameObject prefab, UI2DSprite parent) where T : IconPrefabBase
  {
    ((Behaviour) parent).enabled = false;
    T component = prefab.CloneAndGetComponent<T>(((Component) parent).transform);
    if (Object.op_Equality((Object) (object) component, (Object) null))
      return (T) null;
    NGUITools.AdjustDepth(component.gameObject, parent.depth);
    return component;
  }

  private void Awake()
  {
  }

  [DebuggerHidden]
  protected override IEnumerator Start_Original()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01Skill.\u003CStart_Original\u003Ec__Iterator928()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected override void LateUpdate_Battle()
  {
    if (this.modified == null || this.modifiedUnit == null || !(this.modified.isChangedOnce() | this.modifiedUnit.isChangedOnce()))
      return;
    BL.Skill skill = this.modified.value;
    this.StartCoroutine(this.skillIcon.Init(skill.skill));
    this.property01Icon.Init(skill.genre1);
    this.property02Icon.Init(skill.genre2);
    this.setText(this.txt_name, skill.name);
    this.setText(this.txt_remain, "×" + (object) skill.remain);
    bool flag = false;
    if (skill.remain.HasValue)
    {
      int? remain = skill.remain;
      flag = remain.HasValue && remain.Value <= 0;
    }
    if (!flag && skill.skill.target_type == BattleskillTargetType.myself)
      flag = this.modifiedUnit.value.skillEffects.CanUseSkill(skill.skill, (BL.ISkillEffectListUnit) this.modifiedUnit.value) == 1;
    this.dir_Disable.SetActive(flag);
  }

  public void setSkill(BL.Skill skill, BL.Unit unit)
  {
    this.modified = BL.Observe<BL.Skill>(skill);
    this.modifiedUnit = BL.Observe<BL.Unit>(unit);
  }

  public BL.Skill getSkill() => this.modified.value;

  public BL.Unit getUnit() => this.modifiedUnit.value;
}
