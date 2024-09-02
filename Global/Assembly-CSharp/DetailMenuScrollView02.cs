// Decompiled with JetBrains decompiler
// Type: DetailMenuScrollView02
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class DetailMenuScrollView02 : DetailMenuScrollViewBase
{
  [SerializeField]
  protected GameObject[] gearRankObjects;
  [SerializeField]
  protected UILabel txt_Agility;
  [SerializeField]
  protected UILabel txt_Luck;
  [SerializeField]
  protected UILabel txt_Magic;
  [SerializeField]
  protected UILabel txt_Power;
  [SerializeField]
  protected UILabel txt_Protct;
  [SerializeField]
  protected UILabel txt_Spirit;
  [SerializeField]
  protected UILabel txt_Technique;
  [SerializeField]
  protected GameObject scl_AgilityMaxStar;
  [SerializeField]
  protected GameObject scl_LuckMaxStar;
  [SerializeField]
  protected GameObject scl_MagicMaxStar;
  [SerializeField]
  protected GameObject scl_PowerMaxStar;
  [SerializeField]
  protected GameObject scl_ProtctMaxStar;
  [SerializeField]
  protected GameObject scl_SpiritMaxStar;
  [SerializeField]
  protected GameObject scl_TechniqueMaxStar;
  [SerializeField]
  protected UILabel txt_Skillname;
  [SerializeField]
  protected UILabel txt_SkillDescription;
  [SerializeField]
  protected UI2DSprite[] dyn_UnitTypes;
  [SerializeField]
  protected UIButton[] dyn_UnitSkill;
  [SerializeField]
  protected UIWidget[] dyn_WeaponTypes;
  [SerializeField]
  protected UIButton[] dyn_WeaponSkills;
  [SerializeField]
  protected UI2DSprite[] dyn_Weapon;
  [SerializeField]
  protected UI2DSprite[] dyn_IconRank;
  [SerializeField]
  private GameObject floatingSkillDialog;
  private Action<BattleskillSkill> showSkillDialog;
  private Action<int, int> showSkillLevel;
  [SerializeField]
  private DetailMenu menu;
  private Battle0171111Event floatingSkillDialogObject;
  private GameObject gearPro;
  private GameObject[] weapon;
  private GearProfiencyIcon[] gearProfiencyIcon;
  private BattleSkillIcon[] unitSkillIcon;
  private BattleSkillIcon[] battleSkillIcon;

  private void Awake()
  {
    this.weapon = new GameObject[this.dyn_Weapon.Length];
    this.gearProfiencyIcon = new GearProfiencyIcon[this.dyn_IconRank.Length];
    this.unitSkillIcon = new BattleSkillIcon[this.dyn_UnitTypes.Length];
    this.battleSkillIcon = new BattleSkillIcon[this.dyn_WeaponTypes.Length];
  }

  public override bool Init(PlayerUnit playerUnit)
  {
    ((Component) this).gameObject.SetActive(true);
    Judgement.NonBattleParameter nonBattleParameter = Judgement.NonBattleParameter.FromPlayerUnit(playerUnit);
    this.setText(this.txt_Power, nonBattleParameter.Strength);
    this.setText(this.txt_Magic, nonBattleParameter.Intelligence);
    this.setText(this.txt_Protct, nonBattleParameter.Vitality);
    this.setText(this.txt_Spirit, nonBattleParameter.Mind);
    this.setText(this.txt_Agility, nonBattleParameter.Agility);
    this.setText(this.txt_Technique, nonBattleParameter.Dexterity);
    this.setText(this.txt_Luck, nonBattleParameter.Luck);
    this.scl_AgilityMaxStar.SetActive(playerUnit.agility.is_max);
    this.scl_LuckMaxStar.SetActive(playerUnit.lucky.is_max);
    this.scl_MagicMaxStar.SetActive(playerUnit.intelligence.is_max);
    this.scl_PowerMaxStar.SetActive(playerUnit.strength.is_max);
    this.scl_ProtctMaxStar.SetActive(playerUnit.vitality.is_max);
    this.scl_SpiritMaxStar.SetActive(playerUnit.mind.is_max);
    this.scl_TechniqueMaxStar.SetActive(playerUnit.dexterity.is_max);
    return true;
  }

  [DebuggerHidden]
  public override IEnumerator initAsync(PlayerUnit playerUnit, GameObject[] prefabs)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DetailMenuScrollView02.\u003CinitAsync\u003Ec__Iterator8B8()
    {
      prefabs = prefabs,
      playerUnit = playerUnit,
      \u003C\u0024\u003Eprefabs = prefabs,
      \u003C\u0024\u003EplayerUnit = playerUnit,
      \u003C\u003Ef__this = this
    };
  }

  private void setShowSkillDialog(UIButton button, BattleskillSkill weaponSkill, int level)
  {
    EventDelegate.Add(button.onClick, (EventDelegate.Callback) (() =>
    {
      if (this.showSkillDialog == null)
        return;
      this.showSkillDialog(weaponSkill);
      this.showSkillLevel(level, weaponSkill.upper_level);
    }));
  }

  [DebuggerHidden]
  private IEnumerator CreateSkillIcon(
    BattleskillSkill sk,
    int idx,
    int unitSkillLv,
    int needLv,
    GameObject skillTypeIconPrefab)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DetailMenuScrollView02.\u003CCreateSkillIcon\u003Ec__Iterator8B9()
    {
      idx = idx,
      skillTypeIconPrefab = skillTypeIconPrefab,
      unitSkillLv = unitSkillLv,
      needLv = needLv,
      sk = sk,
      \u003C\u0024\u003Eidx = idx,
      \u003C\u0024\u003EskillTypeIconPrefab = skillTypeIconPrefab,
      \u003C\u0024\u003EunitSkillLv = unitSkillLv,
      \u003C\u0024\u003EneedLv = needLv,
      \u003C\u0024\u003Esk = sk,
      \u003C\u003Ef__this = this
    };
  }

  public override void EndScene()
  {
    foreach (UIButton dynWeaponSkill in this.dyn_WeaponSkills)
    {
      if (((Component) dynWeaponSkill).gameObject.activeSelf)
      {
        if (Object.op_Inequality((Object) dynWeaponSkill, (Object) null))
          dynWeaponSkill.onClick.Clear();
        BattleSkillIcon componentInChildren = ((Component) dynWeaponSkill).GetComponentInChildren<BattleSkillIcon>();
        if (Object.op_Inequality((Object) componentInChildren, (Object) null))
          Object.Destroy((Object) ((Component) componentInChildren).gameObject);
      }
    }
    foreach (UIButton uiButton in this.dyn_UnitSkill)
    {
      if (((Component) uiButton).gameObject.activeSelf)
      {
        BattleSkillIcon componentInChildren = ((Component) uiButton).GetComponentInChildren<BattleSkillIcon>();
        if (Object.op_Inequality((Object) componentInChildren, (Object) null))
          Object.Destroy((Object) ((Component) componentInChildren).gameObject);
        if (Object.op_Inequality((Object) uiButton, (Object) null))
          uiButton.onClick.Clear();
      }
    }
  }
}
