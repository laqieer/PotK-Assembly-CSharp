// Decompiled with JetBrains decompiler
// Type: Battle03UIPlayerStatus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Battle03UIPlayerStatus : Battle02MenuBase
{
  private const int WEAPON_SKILL_ICON_ID = 8;
  private const int WEAPON_ELEMENT_ICON_ID = 0;
  private const string MAGIC_BULLET_NONE_NAME = "-";
  public NGTweenGaugeScale hpGauge;
  [SerializeField]
  protected SelectParts statusBase;
  [SerializeField]
  protected UI2DSprite character;
  [SerializeField]
  protected UI2DSprite weapon;
  [SerializeField]
  protected GameObject[] dir_ForceHeader;
  private GameObject gearKindIcon01;
  private GameObject gearKindIcon02;
  [SerializeField]
  protected NGxMaskSprite link_CharacterMask;
  [SerializeField]
  private Transform characterTransform;
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
  protected UILabel txt_Fighting;
  [SerializeField]
  protected UILabel txt_Matk;
  [SerializeField]
  protected UILabel txt_Mdef;
  [SerializeField]
  protected UILabel txt_Movement;
  [SerializeField]
  protected UILabel txt_AttackBD;
  [SerializeField]
  protected UILabel txt_CriticalBD;
  [SerializeField]
  protected UILabel txt_DefenseBD;
  [SerializeField]
  protected UILabel txt_DexterityBD;
  [SerializeField]
  protected UILabel txt_EvasionBD;
  [SerializeField]
  protected UILabel txt_MatkBD;
  [SerializeField]
  protected UILabel txt_MdefBD;
  [SerializeField]
  protected UILabel txt_Agility;
  [SerializeField]
  protected UILabel txt_Luck;
  [SerializeField]
  protected UILabel txt_Magic;
  [SerializeField]
  protected UILabel txt_Power;
  [SerializeField]
  protected UILabel txt_Stability;
  [SerializeField]
  protected UILabel txt_Spirit;
  [SerializeField]
  protected UILabel txt_Technique;
  [SerializeField]
  protected UILabel txt_AgilityBD;
  [SerializeField]
  protected UILabel txt_LuckBD;
  [SerializeField]
  protected UILabel txt_MagicBD;
  [SerializeField]
  protected UILabel txt_PowerBD;
  [SerializeField]
  protected UILabel txt_StabilityBD;
  [SerializeField]
  protected UILabel txt_SpiritBD;
  [SerializeField]
  protected UILabel txt_TechniqueBD;
  [SerializeField]
  protected UILabel txt_CharacterName;
  [SerializeField]
  protected UILabel txt_Lv;
  [SerializeField]
  protected UILabel txt_Hp;
  [SerializeField]
  protected UILabel txt_Hpmax;
  [SerializeField]
  protected UILabel txt_Jobname;
  [SerializeField]
  protected Transform weaponGearKindIconParent;
  [SerializeField]
  protected Transform shieldGearKindIconParent;
  protected GameObject gearKindIconPrefab;
  [SerializeField]
  protected Transform[] weaponSkillKindIconParent;
  [SerializeField]
  protected Transform weaponEquipKindIconParent;
  private GameObject weaponEquipIcon;
  [SerializeField]
  private UILabel princessTypeLabel;
  [SerializeField]
  protected UISprite[] SkillIconBase;
  [SerializeField]
  protected Transform[] skillTypeIconParent;
  protected GameObject skillTypeIconPrefab;
  private GameObject[] skillTypeIcon = new GameObject[10];
  private GameObject weaponSkillIcon;
  private List<PlayerUnitSkills> dispSkills;
  private PlayerItem dispWeapon;
  private List<PlayerUnitSkills> dispMagicBullets;
  private PlayerUnitLeader_skills dispLeaderSkill;
  [SerializeField]
  protected Transform[] elementTypeIconParent;
  protected GameObject elementTypeIconPrefab;
  private GameObject[] elementTypeIcon = new GameObject[5];
  [SerializeField]
  protected UILabel[] txt_Magic_name;
  [SerializeField]
  protected UILabel[] txt_Magic_range;
  [SerializeField]
  protected Transform[] spaTypeIconParent1;
  [SerializeField]
  protected Transform[] spaTypeIconParent2;
  protected GameObject spaTypeIconPrefab;
  private GameObject[] spaTypeIcon1 = new GameObject[5];
  private GameObject[] spaTypeIcon2 = new GameObject[5];
  [SerializeField]
  protected Transform gearProfiencyIconParentW;
  [SerializeField]
  protected Transform gearProfiencyIconParentS;
  protected GameObject gearProfiencyIconPrefab;
  private GameObject gearProfiencyIconW;
  private GameObject gearProfiencyIconS;
  [SerializeField]
  protected Transform skillDialogParent;
  protected GameObject skillDialogPrefab;
  private GameObject skillDialog;
  [SerializeField]
  protected GameObject backGround;
  [SerializeField]
  protected GameObject LeaderSkillBtn;
  [SerializeField]
  protected GameObject SkillDialogRoot;
  private new BL.BattleModified<BL.Unit> modified;

  private void SetSkillIconBaseSprite()
  {
    string str = "slc_skill_icon_base_unit_60_62.png__GUI__common__common_prefab";
    if (Singleton<NGBattleManager>.GetInstance().isEarth)
      str = "slc_skill_icon_base_unit_zero_60_62.png__GUI__common__common_prefab";
    foreach (UISprite uiSprite in this.SkillIconBase)
      uiSprite.spriteName = str;
  }

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle03UIPlayerStatus.\u003CStart_Battle\u003Ec__Iterator742()
    {
      \u003C\u003Ef__this = this
    };
  }

  private GameObject createIcon(GameObject prefab, Transform trans)
  {
    GameObject icon = prefab.Clone(trans);
    UI2DSprite componentInChildren1 = icon.GetComponentInChildren<UI2DSprite>();
    UI2DSprite componentInChildren2 = ((Component) trans).GetComponentInChildren<UI2DSprite>();
    componentInChildren1.SetDimensions(componentInChildren2.width, componentInChildren2.height);
    componentInChildren1.depth = this.backGround.GetComponentInChildren<UISprite>().depth + 100;
    return icon;
  }

  protected override void LateUpdate_Battle()
  {
    if (this.modified == null || !this.modified.isChangedOnce())
      return;
    BL.Unit unit = this.modified.value;
    foreach (GameObject gameObject in this.dir_ForceHeader)
      gameObject.SetActive(false);
    this.dir_ForceHeader[(int) this.env.core.getForceID(unit)].SetActive(true);
    Judgement.BattleParameter battleParameter = Judgement.BattleParameter.FromBeUnit(unit);
    this.setText(this.txt_Agility, battleParameter.Agility);
    this.setText(this.txt_Luck, battleParameter.Luck);
    this.setText(this.txt_Magic, battleParameter.Intelligence);
    this.setText(this.txt_Power, battleParameter.Strength);
    this.setText(this.txt_Stability, battleParameter.Vitality);
    this.setText(this.txt_Spirit, battleParameter.Mind);
    this.setText(this.txt_Technique, battleParameter.Dexterity);
    this.setBDTextWrraper(this.txt_AgilityBD, battleParameter.AgilityIncr);
    this.setBDTextWrraper(this.txt_LuckBD, battleParameter.LuckIncr);
    this.setBDTextWrraper(this.txt_MagicBD, battleParameter.IntelligenceIncr);
    this.setBDTextWrraper(this.txt_PowerBD, battleParameter.StrengthIncr);
    this.setBDTextWrraper(this.txt_StabilityBD, battleParameter.VitalityIncr);
    this.setBDTextWrraper(this.txt_SpiritBD, battleParameter.MindIncr);
    this.setBDTextWrraper(this.txt_TechniqueBD, battleParameter.DexterityIncr);
    CommonElement element = unit.playerUnit.equippedGearOrInitial.GetElement();
    if (unit.playerUnit.equippedGear != (PlayerItem) null)
      element = unit.playerUnit.equippedGear.GetElement();
    this.weaponEquipIcon.GetComponentInChildren<GearKindIcon>().Init(unit.playerUnit.equippedGearOrInitial.kind, element);
    this.hpGauge.setValue(unit.hp, battleParameter.Hp, false);
    this.setText(this.txt_CharacterName, unit.unit.name);
    this.setText(this.txt_Lv, unit.lv);
    this.setColordText(this.txt_Fighting, battleParameter.Combat, battleParameter.CombatIncr);
    this.setText(this.txt_Hp, unit.hp);
    this.setText(this.txt_Hpmax, "/" + (object) battleParameter.Hp);
    this.setText(this.txt_Jobname, unit.job.name);
    this.setColordText(this.txt_Movement, battleParameter.Move, battleParameter.MoveIncr);
    this.setText(this.txt_Attack, battleParameter.PhysicalAttack);
    this.setText(this.txt_Critical, battleParameter.Critical);
    this.setText(this.txt_Defense, battleParameter.PhysicalDefense);
    this.setText(this.txt_Dexterity, battleParameter.Hit);
    this.setText(this.txt_Evasion, battleParameter.Evasion);
    this.setText(this.txt_Matk, battleParameter.MagicAttack);
    this.setText(this.txt_Mdef, battleParameter.MagicDefense);
    this.setBDTextWrraper(this.txt_AttackBD, battleParameter.PhysicalAttackIncr);
    this.setBDTextWrraper(this.txt_CriticalBD, battleParameter.CriticalIncr);
    this.setBDTextWrraper(this.txt_DefenseBD, battleParameter.PhysicalDefenseIncr);
    this.setBDTextWrraper(this.txt_DexterityBD, battleParameter.HitIncr);
    this.setBDTextWrraper(this.txt_EvasionBD, battleParameter.EvasionIncr);
    this.setBDTextWrraper(this.txt_MatkBD, battleParameter.MagicAttackIncr);
    this.setBDTextWrraper(this.txt_MdefBD, battleParameter.MagicDefenseIncr);
    this.SetPrincessType(unit);
    if (unit.playerUnit.skills != null)
    {
      PlayerUnitSkills[] array = ((IEnumerable<PlayerUnitSkills>) unit.playerUnit.skills).Where<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (x => x.skill.skill_type != BattleskillSkillType.magic & x.skill.skill_type != BattleskillSkillType.leader)).ToArray<PlayerUnitSkills>();
      int num1 = this.skillTypeIcon.Length - 1;
      int num2 = array.Length >= num1 ? num1 : array.Length;
      for (int index = 0; index < num2; ++index)
      {
        PlayerUnitSkills playerUnitSkills = array[index];
        this.dispSkills.Add(playerUnitSkills);
        this.skillTypeIcon[index] = this.createIcon(this.skillTypeIconPrefab, this.skillTypeIconParent[index]);
        this.StartCoroutine(this.skillTypeIcon[index].GetComponentInChildren<BattleSkillIcon>().Init(playerUnitSkills.skill));
      }
    }
    if (unit.playerUnit.equippedGear != (PlayerItem) null)
    {
      for (int index = 0; index < unit.playerUnit.equippedGear.skills.Length; ++index)
      {
        this.skillTypeIcon[8 + index] = this.createIcon(this.skillTypeIconPrefab, this.skillTypeIconParent[8 + index]);
        this.StartCoroutine(this.skillTypeIcon[8 + index].GetComponentInChildren<BattleSkillIcon>().Init(unit.playerUnit.equippedGear.skills[index].skill));
        this.dispWeapon = unit.playerUnit.equippedGear;
      }
    }
    if (unit.weapon.gear != null)
    {
      this.elementTypeIcon[0] = this.createIcon(this.elementTypeIconPrefab, this.elementTypeIconParent[0]);
      if (unit.weapon.gear.elements.Length != 0)
        this.elementTypeIcon[0].GetComponentInChildren<CommonElementIcon>().Init(unit.weapon.gear.elements[0].element);
      else
        this.elementTypeIcon[0].GetComponentInChildren<CommonElementIcon>().Init(CommonElement.none);
      this.setText(this.txt_Magic_name[0], unit.playerUnit.equippedGearName);
      BL.Unit.GearRange gearRange = unit.gearRange();
      this.setText(this.txt_Magic_range[0], string.Format("{0} - {1}", (object) gearRange.Min, (object) gearRange.Max));
      UnitFamily[] specialAttackTargets = unit.playerUnit.equippedWeaponGearOrInitial.SpecialAttackTargets;
      Transform[] transformArray = new Transform[2]
      {
        this.spaTypeIconParent1[0],
        this.spaTypeIconParent2[0]
      };
      GameObject[] gameObjectArray = new GameObject[2]
      {
        this.spaTypeIcon1[0],
        this.spaTypeIcon2[0]
      };
      for (int index = 0; index < specialAttackTargets.Length && transformArray.Length > index; ++index)
      {
        gameObjectArray[index] = this.createIcon(this.spaTypeIconPrefab, transformArray[index]);
        gameObjectArray[index].GetComponentInChildren<SPAtkTypeIcon>().InitKindId(specialAttackTargets[index]);
      }
    }
    if (unit.playerUnit.skills != null)
    {
      this.dispMagicBullets = new List<PlayerUnitSkills>();
      for (int index = 0; index < 4; ++index)
      {
        this.setText(this.txt_Magic_name[index + 1], "-");
        this.setText(this.txt_Magic_range[index + 1], "-");
      }
      int num = 0;
      foreach (PlayerUnitSkills skill in unit.playerUnit.skills)
      {
        if (skill.skill.skill_type == BattleskillSkillType.magic)
        {
          this.dispMagicBullets.Add(skill);
          this.elementTypeIcon[num + 1] = this.createIcon(this.elementTypeIconPrefab, this.elementTypeIconParent[num + 1]);
          this.elementTypeIcon[num + 1].GetComponentInChildren<CommonElementIcon>().Init(skill.skill.element);
          this.setText(this.txt_Magic_name[num + 1], skill.skill.name);
          this.setText(this.txt_Magic_range[num + 1], string.Format("{0} - {1}", (object) skill.skill.min_range, (object) skill.skill.max_range));
          this.spaTypeIcon1[num + 1] = this.createIcon(this.spaTypeIconPrefab, this.spaTypeIconParent1[num + 1]);
          ++num;
        }
      }
    }
    if (unit.playerUnit.gear_proficiencies != null && unit.playerUnit.gear_proficiencies.Length >= 1)
    {
      this.gearKindIcon01.GetComponent<GearKindIcon>().Init(unit.playerUnit.gear_proficiencies[0].gear_kind_id);
      this.gearProfiencyIconW = this.createIcon(this.gearProfiencyIconPrefab, this.gearProfiencyIconParentW);
      this.gearProfiencyIconW.GetComponentInChildren<GearProfiencyIcon>().Init(unit.playerUnit.gear_proficiencies[0].level);
    }
    if (unit.playerUnit.gear_proficiencies != null && unit.playerUnit.gear_proficiencies.Length >= 2)
    {
      this.gearKindIcon02.GetComponent<GearKindIcon>().Init(unit.playerUnit.gear_proficiencies[1].gear_kind_id);
      this.gearProfiencyIconS = this.createIcon(this.gearProfiencyIconPrefab, this.gearProfiencyIconParentS);
      this.gearProfiencyIconS.GetComponentInChildren<GearProfiencyIcon>().Init(unit.playerUnit.gear_proficiencies[1].level);
    }
    if (unit.playerUnit.is_enemy && unit.playerUnit.is_enemy_leader && unit.playerUnit.leader_skill != null)
    {
      this.dispLeaderSkill = unit.playerUnit.leader_skill;
      this.LeaderSkillBtn.SetActive(true);
    }
    else
      this.LeaderSkillBtn.SetActive(false);
    this.StartCoroutine(this.createMaskdCharacter(unit));
  }

  private void SetPrincessType(BL.Unit blUnit)
  {
    if (Singleton<NGBattleManager>.GetInstance().isEarth)
      ((Component) this.princessTypeLabel).gameObject.SetActive(false);
    else if (blUnit.playerUnit.unit_type == null || blUnit.playerUnit.is_enemy)
    {
      ((Component) this.princessTypeLabel).gameObject.SetActive(false);
    }
    else
    {
      ((Component) this.princessTypeLabel).gameObject.SetActive(true);
      this.princessTypeLabel.SetText(Consts.Lookup(blUnit.playerUnit.unit_type.Enum.TypeNameKey()));
    }
  }

  public new void setUnit(BL.Unit unit) => this.modified = BL.Observe<BL.Unit>(unit);

  public new BL.Unit getUnit() => this.modified.value;

  public void onButtonSkill1() => this.OnButtonSkillProc(0);

  public void onButtonSkill2() => this.OnButtonSkillProc(1);

  public void onButtonSkill3() => this.OnButtonSkillProc(2);

  public void onButtonSkill4() => this.OnButtonSkillProc(3);

  public void onButtonSkill5() => this.OnButtonSkillProc(4);

  public void onButtonSkill6() => this.OnButtonSkillProc(5);

  public void onButtonSkill7() => this.OnButtonSkillProc(6);

  public void onButtonSkill8() => this.OnButtonSkillProc(7);

  public void OnButtonSkillProc(int idx)
  {
    if (Object.op_Equality((Object) this.skillTypeIcon[idx], (Object) null) || Object.op_Equality((Object) this.skillDialog, (Object) null))
      return;
    this.skillDialog.SetActive(true);
    Battle0171111Event componentInChildren = this.skillDialog.GetComponentInChildren<Battle0171111Event>();
    if (!Object.op_Inequality((Object) null, (Object) componentInChildren))
      return;
    componentInChildren.setSkillProperty(true);
    componentInChildren.setData(this.dispSkills[idx].skill);
    componentInChildren.setSkillLv(this.dispSkills[idx].level, this.dispSkills[idx].skill.upper_level);
    componentInChildren.Show();
  }

  public void onButtonSkillLeader()
  {
    if (this.dispLeaderSkill == null || Object.op_Equality((Object) this.skillDialog, (Object) null))
      return;
    this.skillDialog.SetActive(true);
    Battle0171111Event componentInChildren = this.skillDialog.GetComponentInChildren<Battle0171111Event>();
    if (!Object.op_Inequality((Object) null, (Object) componentInChildren))
      return;
    componentInChildren.setSkillProperty(false);
    componentInChildren.setData(this.dispLeaderSkill.skill);
    componentInChildren.setSkillLv(this.dispLeaderSkill.level, this.dispLeaderSkill.skill.upper_level);
    componentInChildren.Show();
  }

  public void onButtonSkillw1() => this.onButtonSkillw(0);

  public void onButtonSkillw2() => this.onButtonSkillw(1);

  public void onButtonSkillw(int id)
  {
    if (Object.op_Equality((Object) this.skillTypeIcon[8 + id], (Object) null) || Object.op_Equality((Object) this.skillDialog, (Object) null))
      return;
    this.skillDialog.SetActive(true);
    Battle0171111Event componentInChildren = this.skillDialog.GetComponentInChildren<Battle0171111Event>();
    if (!Object.op_Inequality((Object) null, (Object) componentInChildren))
      return;
    componentInChildren.setSkillProperty(true);
    componentInChildren.setData(this.dispWeapon.skills[id].skill);
    componentInChildren.setSkillLv(this.dispWeapon.skills[id].skill_level, this.dispWeapon.skills[id].skill.upper_level);
    componentInChildren.Show();
  }

  [DebuggerHidden]
  private IEnumerator createMaskdCharacter(BL.Unit v)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle03UIPlayerStatus.\u003CcreateMaskdCharacter\u003Ec__Iterator743()
    {
      v = v,
      \u003C\u0024\u003Ev = v,
      \u003C\u003Ef__this = this
    };
  }

  private ResourceObject maskResource() => new ResourceObject("GUI/battleUI_04/mask_Character_Own");

  public void onClose() => this.battleManager.popupDismiss();

  public override void onBackButton() => this.onClose();

  public void onButtonMB1()
  {
    if (this.dispMagicBullets.Count < 1 || Object.op_Equality((Object) this.skillDialog, (Object) null))
      return;
    this.skillDialog.SetActive(true);
    Battle0171111Event componentInChildren = this.skillDialog.GetComponentInChildren<Battle0171111Event>();
    if (!Object.op_Inequality((Object) null, (Object) componentInChildren))
      return;
    componentInChildren.setData(this.dispMagicBullets[0].skill);
    componentInChildren.setSkillLv(this.dispMagicBullets[0].level, this.dispMagicBullets[0].skill.upper_level);
    componentInChildren.Show();
  }

  public void onButtonMB2()
  {
    if (this.dispMagicBullets.Count < 2 || Object.op_Equality((Object) this.skillDialog, (Object) null))
      return;
    this.skillDialog.SetActive(true);
    Battle0171111Event componentInChildren = this.skillDialog.GetComponentInChildren<Battle0171111Event>();
    if (!Object.op_Inequality((Object) null, (Object) componentInChildren))
      return;
    componentInChildren.setData(this.dispMagicBullets[1].skill);
    componentInChildren.setSkillLv(this.dispMagicBullets[1].level, this.dispMagicBullets[1].skill.upper_level);
    componentInChildren.Show();
  }

  public void onButtonMB3()
  {
    if (this.dispMagicBullets.Count < 3 || Object.op_Equality((Object) this.skillDialog, (Object) null))
      return;
    this.skillDialog.SetActive(true);
    Battle0171111Event componentInChildren = this.skillDialog.GetComponentInChildren<Battle0171111Event>();
    if (!Object.op_Inequality((Object) null, (Object) componentInChildren))
      return;
    componentInChildren.setData(this.dispMagicBullets[2].skill);
    componentInChildren.setSkillLv(this.dispMagicBullets[2].level, this.dispMagicBullets[2].skill.upper_level);
    componentInChildren.Show();
  }

  public void onButtonMB4()
  {
    if (this.dispMagicBullets.Count < 4 || Object.op_Equality((Object) this.skillDialog, (Object) null))
      return;
    this.skillDialog.SetActive(true);
    Battle0171111Event componentInChildren = this.skillDialog.GetComponentInChildren<Battle0171111Event>();
    if (!Object.op_Inequality((Object) null, (Object) componentInChildren))
      return;
    componentInChildren.setData(this.dispMagicBullets[3].skill);
    componentInChildren.setSkillLv(this.dispMagicBullets[3].level, this.dispMagicBullets[3].skill.upper_level);
    componentInChildren.Show();
  }

  public void onButtonWP()
  {
  }
}
