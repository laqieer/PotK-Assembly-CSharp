// Decompiled with JetBrains decompiler
// Type: Battle03UIPlayerStatus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
  private const int WEAPON_SKILL_ICON_ID = 10;
  private const int WEAPON_ELEMENT_ICON_ID = 0;
  private const string MAGIC_BULLET_NONE_NAME = "-";
  private const int DIR_FORCEHEADER_PLAYER = 0;
  private const int SLC_STATUS_BASE_OWN_ICON_PLAYER = 0;
  private const int SLC_STATUS_BASE_OWN_ICON_GUEST = 1;
  public NGTweenGaugeScale hpGauge;
  [SerializeField]
  protected SelectParts statusBase;
  [SerializeField]
  protected UI2DSprite character;
  [SerializeField]
  protected UI2DSprite weapon;
  [SerializeField]
  protected GameObject[] dir_ForceHeader;
  [SerializeField]
  private GameObject[] slcStatus1BaseOwnIcons;
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
  protected Transform weaponEquipKindIconParent;
  private GameObject weaponEquipIcon;
  [SerializeField]
  private UISprite princessTypeSprite;
  [SerializeField]
  protected UISprite[] SkillIconBase;
  [SerializeField]
  protected Transform[] skillTypeIconParent;
  protected GameObject skillTypeIconPrefab;
  private GameObject[] skillTypeIcon = new GameObject[12];
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
    string name = !Singleton<NGBattleManager>.GetInstance().isEarth ? "slc_skill_icon_base_unit_60_62.png__GUI__common__common_prefab" : "slc_skill_icon_base_unit_zero_60_62.png__GUI__common__common_prefab";
    ((IEnumerable<UISprite>) this.SkillIconBase).ForEach<UISprite>((Action<UISprite>) (f => f.spriteName = name));
  }

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle03UIPlayerStatus.\u003CStart_Battle\u003Ec__Iterator959()
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
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Battle03UIPlayerStatus.\u003CLateUpdate_Battle\u003Ec__AnonStorey1100 battleCAnonStorey1100_1 = new Battle03UIPlayerStatus.\u003CLateUpdate_Battle\u003Ec__AnonStorey1100();
    // ISSUE: reference to a compiler-generated field
    battleCAnonStorey1100_1.v = this.modified.value;
    foreach (GameObject gameObject in this.dir_ForceHeader)
      gameObject.SetActive(false);
    // ISSUE: reference to a compiler-generated field
    this.dir_ForceHeader[(int) this.env.core.getForceID(battleCAnonStorey1100_1.v)].SetActive(true);
    // ISSUE: reference to a compiler-generated field
    if (this.env.core.getForceID(battleCAnonStorey1100_1.v) == BL.ForceID.player)
    {
      // ISSUE: reference to a compiler-generated field
      ((IEnumerable<GameObject>) this.slcStatus1BaseOwnIcons).ToggleOnce(!battleCAnonStorey1100_1.v.playerUnit.is_gesut ? 0 : 1);
    }
    // ISSUE: reference to a compiler-generated field
    Judgement.BattleParameter battleParameter = Judgement.BattleParameter.FromBeUnit(battleCAnonStorey1100_1.v);
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
    // ISSUE: reference to a compiler-generated field
    CommonElement element = battleCAnonStorey1100_1.v.playerUnit.equippedGearOrInitial.GetElement();
    // ISSUE: reference to a compiler-generated field
    if (battleCAnonStorey1100_1.v.playerUnit.equippedGear != (PlayerItem) null)
    {
      // ISSUE: reference to a compiler-generated field
      element = battleCAnonStorey1100_1.v.playerUnit.equippedGear.GetElement();
    }
    // ISSUE: reference to a compiler-generated field
    this.weaponEquipIcon.GetComponentInChildren<GearKindIcon>().Init(battleCAnonStorey1100_1.v.playerUnit.equippedGearOrInitial.kind, element);
    // ISSUE: reference to a compiler-generated field
    this.hpGauge.setValue(battleCAnonStorey1100_1.v.hp, battleParameter.Hp, false);
    // ISSUE: reference to a compiler-generated field
    this.setText(this.txt_CharacterName, battleCAnonStorey1100_1.v.unit.name);
    // ISSUE: reference to a compiler-generated field
    this.setText(this.txt_Lv, battleCAnonStorey1100_1.v.lv);
    this.setColordText(this.txt_Fighting, battleParameter.Combat, battleParameter.CombatIncr);
    // ISSUE: reference to a compiler-generated field
    this.setText(this.txt_Hp, battleCAnonStorey1100_1.v.hp);
    this.setText(this.txt_Hpmax, "/" + (object) battleParameter.Hp);
    // ISSUE: reference to a compiler-generated field
    this.setText(this.txt_Jobname, battleCAnonStorey1100_1.v.job.name);
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
    // ISSUE: reference to a compiler-generated field
    this.SetPrincessType(battleCAnonStorey1100_1.v);
    // ISSUE: reference to a compiler-generated field
    if (battleCAnonStorey1100_1.v.playerUnit.skills != null)
    {
      Dictionary<int, UnitSkillEvolution> unitSkillEvolutionDict = ((IEnumerable<UnitSkillEvolution>) MasterData.UnitSkillEvolutionList).Where<UnitSkillEvolution>((Func<UnitSkillEvolution, bool>) (x => x.unit.ID == v.playerUnit.unit.ID)).ToDictionary<UnitSkillEvolution, int>((Func<UnitSkillEvolution, int>) (x => x.after_skill.ID));
      // ISSUE: reference to a compiler-generated field
      IEnumerable<PlayerUnitSkills> playerUnitSkillses = ((IEnumerable<UnitSkill>) battleCAnonStorey1100_1.v.unit.RememberUnitSkills).Where<UnitSkill>((Func<UnitSkill, bool>) (w => w.skill.DispSkillList)).Select<UnitSkill, PlayerUnitSkills>((Func<UnitSkill, PlayerUnitSkills>) (f =>
      {
        // ISSUE: variable of a compiler-generated type
        Battle03UIPlayerStatus.\u003CLateUpdate_Battle\u003Ec__AnonStorey1100 battleCAnonStorey1100 = battleCAnonStorey1100_1;
        // ISSUE: variable of a compiler-generated type
        Battle03UIPlayerStatus.\u003CLateUpdate_Battle\u003Ec__AnonStorey1102 battleCAnonStorey1102 = this;
        UnitSkill f1 = f;
        return ((IEnumerable<PlayerUnitSkills>) v.playerUnit.skills).FirstOrDefault<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (fd =>
        {
          if (f1.skill == fd.skill)
            return true;
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          return battleCAnonStorey1102.unitSkillEvolutionDict.ContainsKey(fd.skill.ID) && f1.skill == battleCAnonStorey1102.unitSkillEvolutionDict[fd.skill.ID].before_skill;
        }));
      })).Where<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (w => w != null));
      if (!Singleton<NGBattleManager>.GetInstance().isEarth)
      {
        IEnumerable<PlayerUnitSkills> second1 = ((IEnumerable<UnitSkillCharacterQuest>) MasterData.UnitSkillCharacterQuestList).Where<UnitSkillCharacterQuest>((Func<UnitSkillCharacterQuest, bool>) (x => x.unit.ID == v.playerUnit.unit.ID && x.skill.DispSkillList)).Select<UnitSkillCharacterQuest, PlayerUnitSkills>((Func<UnitSkillCharacterQuest, PlayerUnitSkills>) (s =>
        {
          // ISSUE: variable of a compiler-generated type
          Battle03UIPlayerStatus.\u003CLateUpdate_Battle\u003Ec__AnonStorey1100 battleCAnonStorey1100 = battleCAnonStorey1100_1;
          // ISSUE: variable of a compiler-generated type
          Battle03UIPlayerStatus.\u003CLateUpdate_Battle\u003Ec__AnonStorey1102 battleCAnonStorey1102 = this;
          UnitSkillCharacterQuest s1 = s;
          return ((IEnumerable<PlayerUnitSkills>) v.playerUnit.skills).FirstOrDefault<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (fd =>
          {
            if (s1.skill == fd.skill || s1.skillOfEvolution == fd.skill)
              return true;
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            return battleCAnonStorey1102.unitSkillEvolutionDict.ContainsKey(fd.skill.ID) && s1.skill == battleCAnonStorey1102.unitSkillEvolutionDict[fd.skill.ID].before_skill;
          }));
        })).Where<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (w => w != null));
        IEnumerable<PlayerUnitSkills> second2 = ((IEnumerable<UnitSkillHarmonyQuest>) MasterData.UnitSkillHarmonyQuestList).Where<UnitSkillHarmonyQuest>((Func<UnitSkillHarmonyQuest, bool>) (x => x.character.ID == v.playerUnit.unit.character.ID && x.skill.DispSkillList)).Select<UnitSkillHarmonyQuest, PlayerUnitSkills>((Func<UnitSkillHarmonyQuest, PlayerUnitSkills>) (s =>
        {
          // ISSUE: variable of a compiler-generated type
          Battle03UIPlayerStatus.\u003CLateUpdate_Battle\u003Ec__AnonStorey1100 battleCAnonStorey1100 = battleCAnonStorey1100_1;
          // ISSUE: variable of a compiler-generated type
          Battle03UIPlayerStatus.\u003CLateUpdate_Battle\u003Ec__AnonStorey1102 battleCAnonStorey1102 = this;
          UnitSkillHarmonyQuest s2 = s;
          return ((IEnumerable<PlayerUnitSkills>) v.playerUnit.skills).FirstOrDefault<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (fd =>
          {
            if (s2.skill == fd.skill)
              return true;
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            return battleCAnonStorey1102.unitSkillEvolutionDict.ContainsKey(fd.skill.ID) && s2.skill == battleCAnonStorey1102.unitSkillEvolutionDict[fd.skill.ID].before_skill;
          }));
        })).Where<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (w => w != null));
        IEnumerable<PlayerUnitSkills> second3 = ((IEnumerable<UnitSkillIntimate>) MasterData.UnitSkillIntimateList).Where<UnitSkillIntimate>((Func<UnitSkillIntimate, bool>) (x => x.unit.ID == v.playerUnit.unit.ID && x.skill.DispSkillList)).Select<UnitSkillIntimate, PlayerUnitSkills>((Func<UnitSkillIntimate, PlayerUnitSkills>) (s =>
        {
          // ISSUE: variable of a compiler-generated type
          Battle03UIPlayerStatus.\u003CLateUpdate_Battle\u003Ec__AnonStorey1100 battleCAnonStorey1100 = battleCAnonStorey1100_1;
          // ISSUE: variable of a compiler-generated type
          Battle03UIPlayerStatus.\u003CLateUpdate_Battle\u003Ec__AnonStorey1102 battleCAnonStorey1102 = this;
          UnitSkillIntimate s3 = s;
          return ((IEnumerable<PlayerUnitSkills>) v.playerUnit.skills).FirstOrDefault<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (fd =>
          {
            if (s3.skill == fd.skill)
              return true;
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            return battleCAnonStorey1102.unitSkillEvolutionDict.ContainsKey(fd.skill.ID) && s3.skill == battleCAnonStorey1102.unitSkillEvolutionDict[fd.skill.ID].before_skill;
          }));
        })).Where<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (w => w != null));
        playerUnitSkillses = playerUnitSkillses.Concat<PlayerUnitSkills>(second1).Concat<PlayerUnitSkills>(second2).Concat<PlayerUnitSkills>(second3);
      }
      // ISSUE: reference to a compiler-generated field
      IEnumerable<PlayerUnitSkills> second = ((IEnumerable<PlayerUnitSkills>) battleCAnonStorey1100_1.v.playerUnit.skills).Where<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (w => w.skill.DispSkillList)).Except<PlayerUnitSkills>(playerUnitSkillses);
      List<PlayerUnitSkills> list = playerUnitSkillses.Concat<PlayerUnitSkills>(second).ToList<PlayerUnitSkills>();
      int val2 = this.skillTypeIcon.Length - 1;
      int num = Math.Min(list.Count, val2);
      for (int index = 0; index < num; ++index)
      {
        PlayerUnitSkills playerUnitSkills = list[index];
        this.dispSkills.Add(playerUnitSkills);
        this.skillTypeIcon[index] = this.createIcon(this.skillTypeIconPrefab, this.skillTypeIconParent[index]);
        this.StartCoroutine(this.skillTypeIcon[index].GetComponentInChildren<BattleSkillIcon>().Init(playerUnitSkills.skill));
      }
    }
    // ISSUE: reference to a compiler-generated field
    if (battleCAnonStorey1100_1.v.playerUnit.equippedGear != (PlayerItem) null)
    {
      // ISSUE: reference to a compiler-generated field
      for (int index = 0; index < battleCAnonStorey1100_1.v.playerUnit.equippedGear.skills.Length; ++index)
      {
        this.skillTypeIcon[10 + index] = this.createIcon(this.skillTypeIconPrefab, this.skillTypeIconParent[10 + index]);
        // ISSUE: reference to a compiler-generated field
        this.StartCoroutine(this.skillTypeIcon[10 + index].GetComponentInChildren<BattleSkillIcon>().Init(battleCAnonStorey1100_1.v.playerUnit.equippedGear.skills[index].skill));
        // ISSUE: reference to a compiler-generated field
        this.dispWeapon = battleCAnonStorey1100_1.v.playerUnit.equippedGear;
      }
    }
    // ISSUE: reference to a compiler-generated field
    if (battleCAnonStorey1100_1.v.weapon.gear != null)
    {
      this.elementTypeIcon[0] = this.createIcon(this.elementTypeIconPrefab, this.elementTypeIconParent[0]);
      // ISSUE: reference to a compiler-generated field
      if (battleCAnonStorey1100_1.v.weapon.gear.elements.Length != 0)
      {
        // ISSUE: reference to a compiler-generated field
        this.elementTypeIcon[0].GetComponentInChildren<CommonElementIcon>().Init(battleCAnonStorey1100_1.v.weapon.gear.elements[0].element);
      }
      else
        this.elementTypeIcon[0].GetComponentInChildren<CommonElementIcon>().Init(CommonElement.none);
      // ISSUE: reference to a compiler-generated field
      this.setText(this.txt_Magic_name[0], battleCAnonStorey1100_1.v.playerUnit.equippedGearName);
      // ISSUE: reference to a compiler-generated field
      BL.Unit.GearRange gearRange = battleCAnonStorey1100_1.v.gearRange();
      this.setText(this.txt_Magic_range[0], string.Format("{0} - {1}", (object) gearRange.Min, (object) gearRange.Max));
      // ISSUE: reference to a compiler-generated field
      UnitFamily[] specialAttackTargets = battleCAnonStorey1100_1.v.playerUnit.equippedWeaponGearOrInitial.SpecialAttackTargets;
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
    // ISSUE: reference to a compiler-generated field
    if (battleCAnonStorey1100_1.v.playerUnit.skills != null)
    {
      this.dispMagicBullets = new List<PlayerUnitSkills>();
      for (int index = 0; index < 4; ++index)
      {
        this.setText(this.txt_Magic_name[index + 1], "-");
        this.setText(this.txt_Magic_range[index + 1], "-");
      }
      int num = 0;
      // ISSUE: reference to a compiler-generated field
      foreach (PlayerUnitSkills skill in battleCAnonStorey1100_1.v.playerUnit.skills)
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
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    if (battleCAnonStorey1100_1.v.playerUnit.gear_proficiencies != null && battleCAnonStorey1100_1.v.playerUnit.gear_proficiencies.Length >= 1)
    {
      // ISSUE: reference to a compiler-generated field
      this.gearKindIcon01.GetComponent<GearKindIcon>().Init(battleCAnonStorey1100_1.v.playerUnit.gear_proficiencies[0].gear_kind_id);
      this.gearProfiencyIconW = this.createIcon(this.gearProfiencyIconPrefab, this.gearProfiencyIconParentW);
      // ISSUE: reference to a compiler-generated field
      this.gearProfiencyIconW.GetComponentInChildren<GearProfiencyIcon>().Init(battleCAnonStorey1100_1.v.playerUnit.gear_proficiencies[0].level);
    }
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    if (battleCAnonStorey1100_1.v.playerUnit.gear_proficiencies != null && battleCAnonStorey1100_1.v.playerUnit.gear_proficiencies.Length >= 2)
    {
      // ISSUE: reference to a compiler-generated field
      this.gearKindIcon02.GetComponent<GearKindIcon>().Init(battleCAnonStorey1100_1.v.playerUnit.gear_proficiencies[1].gear_kind_id);
      this.gearProfiencyIconS = this.createIcon(this.gearProfiencyIconPrefab, this.gearProfiencyIconParentS);
      // ISSUE: reference to a compiler-generated field
      this.gearProfiencyIconS.GetComponentInChildren<GearProfiencyIcon>().Init(battleCAnonStorey1100_1.v.playerUnit.gear_proficiencies[1].level);
    }
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    if (battleCAnonStorey1100_1.v.playerUnit.is_enemy && battleCAnonStorey1100_1.v.playerUnit.is_enemy_leader && battleCAnonStorey1100_1.v.playerUnit.leader_skill != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.dispLeaderSkill = battleCAnonStorey1100_1.v.playerUnit.leader_skill;
      this.LeaderSkillBtn.SetActive(true);
    }
    else
      this.LeaderSkillBtn.SetActive(false);
    // ISSUE: reference to a compiler-generated field
    this.StartCoroutine(this.createMaskdCharacter(battleCAnonStorey1100_1.v));
  }

  private void SetPrincessType(BL.Unit blUnit)
  {
    if (Singleton<NGBattleManager>.GetInstance().isEarth)
      ((Component) this.princessTypeSprite).gameObject.SetActive(false);
    else if (blUnit.playerUnit.unit_type == null || blUnit.playerUnit.is_enemy)
    {
      ((Component) this.princessTypeSprite).gameObject.SetActive(false);
    }
    else
    {
      string str1 = "slc_Princess_";
      string str2;
      switch (blUnit.playerUnit.unit_type.Enum)
      {
        case UnitTypeEnum.ouki:
          str2 = str1 + "King";
          break;
        case UnitTypeEnum.meiki:
          str2 = str1 + "Life";
          break;
        case UnitTypeEnum.kouki:
          str2 = str1 + "Attack";
          break;
        case UnitTypeEnum.maki:
          str2 = str1 + "Magic";
          break;
        case UnitTypeEnum.syuki:
          str2 = str1 + "Defense";
          break;
        case UnitTypeEnum.syouki:
          str2 = str1 + "Technical";
          break;
        default:
          Debug.LogWarning((object) "タイプ不一致");
          return;
      }
      ((Component) this.princessTypeSprite).gameObject.SetActive(true);
      this.princessTypeSprite.spriteName = str2 + ".png__GUI__princess_type__princess_type_prefab";
      this.princessTypeSprite.width = this.princessTypeSprite.GetAtlasSprite().width;
      this.princessTypeSprite.height = this.princessTypeSprite.GetAtlasSprite().height;
    }
  }

  public new void setUnit(BL.Unit unit)
  {
    Debug.Log((object) ("03 player status/initCurrent fid = " + unit.unit.name));
    this.modified = BL.Observe<BL.Unit>(unit);
  }

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
    Debug.Log((object) string.Format("=== Battl03UnitStatus onButtonSkill{0} ===", (object) (idx + 1)));
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
    Debug.Log((object) "=== Battle03UnitStatus onButtonSkillLeader ===");
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
    Debug.Log((object) "=== Battle03UnitStatus onButtonSkillw ===");
    if (Object.op_Equality((Object) this.skillTypeIcon[10 + id], (Object) null) || Object.op_Equality((Object) this.skillDialog, (Object) null))
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
    return (IEnumerator) new Battle03UIPlayerStatus.\u003CcreateMaskdCharacter\u003Ec__Iterator95A()
    {
      v = v,
      \u003C\u0024\u003Ev = v,
      \u003C\u003Ef__this = this
    };
  }

  private ResourceObject maskResource() => Res.GUI.battleUI_04.mask_Character_Own;

  public void onClose() => this.battleManager.popupDismiss();

  public override void onBackButton() => this.onClose();

  public void onButtonMB1()
  {
    Debug.Log((object) "=== Battle03UnitStatus onButtonMB1 ===");
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
    Debug.Log((object) "=== Battle03UnitStatus onButtonMB2 ===");
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
    Debug.Log((object) "=== Battle03UnitStatus onButtonMB3 ===");
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
    Debug.Log((object) "=== Battle03UnitStatus onButtonMB4 ===");
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

  public void onButtonWP() => Debug.Log((object) "=== Battle03UnitStatus onButtonWP ===");
}
