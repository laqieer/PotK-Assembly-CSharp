// Decompiled with JetBrains decompiler
// Type: DetailMenuScrollViewSkill
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using UnitDetails;
using UnitStatusInformation;
using UnityEngine;

public class DetailMenuScrollViewSkill : DetailMenuScrollViewBase
{
  [SerializeField]
  protected UISprite slc_Leader_Skill_none;
  [SerializeField]
  protected GameObject dir_Leader_Skill_have;
  [SerializeField]
  protected UISprite slc_Attribute_Skill_none;
  [SerializeField]
  protected GameObject dir_Attribute_Skill_have;
  [SerializeField]
  protected UISprite slc_Increase_Skill_none;
  [SerializeField]
  protected GameObject dir_Increase_Skill_have;
  [SerializeField]
  protected UISprite slc_Multi_Skill_none;
  [SerializeField]
  protected GameObject dir_Multi_Skill_have;
  [SerializeField]
  protected UISprite[] slc_Unit_Skill_none;
  [SerializeField]
  protected GameObject[] dir_Unit_Skill_have;
  [SerializeField]
  protected UISprite[] slc_Command_Skill_none;
  [SerializeField]
  protected GameObject[] dir_Command_Skill_have;
  [SerializeField]
  protected UISprite[] slc_Prencess_Skill_none;
  [SerializeField]
  protected GameObject[] dir_Prencess_Skill_have;
  [SerializeField]
  protected UISprite[] slc_Grant_Skill_none;
  [SerializeField]
  protected GameObject[] dir_Grant_Skill_have;
  [SerializeField]
  protected UISprite[] slc_Duel_Skill_none;
  [SerializeField]
  protected GameObject[] dir_Duel_Skill_have;
  [SerializeField]
  protected UISprite[] slc_Armor_Skill_none;
  [SerializeField]
  protected GameObject[] dir_Armor_Skill_have;
  [SerializeField]
  protected GameObject dir_Armor_Skill1;
  [SerializeField]
  protected GameObject dir_Armor_Skill2;
  [SerializeField]
  protected UIButton dir_Armor_Change_Button;
  [SerializeField]
  protected UISprite slc_Extra_Skill_locked;
  [SerializeField]
  protected UISprite slc_Extra_Skill_none;
  [SerializeField]
  protected UISprite slc_Extra_SkillNone_base;
  [SerializeField]
  protected UILabel txt_ExtraSkill;
  [SerializeField]
  protected GameObject dir_Extra_Skill_have;
  protected UnitSkill[] allSkills;
  protected List<int> prencessSkillIDs = new List<int>();
  protected PlayerUnit playerUnit;
  protected List<int> setSkills = new List<int>();
  private GameObject skillDialogPrefab;
  private GameObject skillTypeIconPrefab;
  private GameObject skillLockIconPrefab;
  private List<Tuple<BattleskillSkill, bool, GameObject>> lstSkillIcon;
  private bool limitMode;
  private int sIdx;
  private const int sNonIdx = 4;
  private PopupSkillDetails.Param[] skillParams_;
  private bool? isEnabledArmorSkills_;

  private bool isEnabledArmorSkills
  {
    get
    {
      if (this.isEnabledArmorSkills_.HasValue)
        return this.isEnabledArmorSkills_.Value;
      this.isEnabledArmorSkills_ = new bool?(((IEnumerable<GameObject>) new GameObject[2]
      {
        this.dir_Armor_Skill1,
        this.dir_Armor_Skill2
      }).All<GameObject>((Func<GameObject, bool>) (x => (UnityEngine.Object) x != (UnityEngine.Object) null)));
      return this.isEnabledArmorSkills_.Value;
    }
  }

  public override IEnumerator initAsync(
    PlayerUnit playerUnit,
    bool limitMode,
    bool isMaterial,
    GameObject[] prefabs)
  {
    this.playerUnit = playerUnit;
    this.limitMode = limitMode;
    this.prencessSkillIDs.Clear();
    foreach (UnitSkill unitSkill in ((IEnumerable<UnitSkill>) playerUnit.unit.RememberUnitAllSkills()).Where<UnitSkill>((Func<UnitSkill, bool>) (x => x.unit_type == playerUnit._unit_type)))
      this.prencessSkillIDs.Add(unitSkill.skill_BattleskillSkill);
    this.allSkills = new UnitSkill[0];
    List<int> intList = new List<int>();
    int num = 0;
    if (playerUnit.skills.Length != 0)
    {
      for (int index = 0; index < playerUnit.skills.Length; ++index)
      {
        UnitSkill unitSkill = new UnitSkill();
        unitSkill.ID = 0;
        unitSkill.unit_UnitUnit = playerUnit._unit;
        unitSkill.level = playerUnit.skills[index].level;
        unitSkill.skill_BattleskillSkill = playerUnit.skills[index].skill_id;
        unitSkill.unit_type = playerUnit._unit_type;
        Array.Resize<UnitSkill>(ref this.allSkills, num + 1);
        this.allSkills[num++] = unitSkill;
        intList.Add(playerUnit.skills[index].skill_id);
      }
    }
    UnitSkill[] skills = ((IEnumerable<UnitSkill>) playerUnit.unit.RememberUnitSkills(playerUnit._unit_type)).Where<UnitSkill>((Func<UnitSkill, bool>) (x => x.skill.DispSkillList)).ToArray<UnitSkill>();
    if (skills.Length != 0 && !playerUnit.is_enemy && !playerUnit.is_guest)
    {
      UnitSkillCharacterQuest[] array = ((IEnumerable<UnitSkillCharacterQuest>) MasterData.UnitSkillCharacterQuestList).Where<UnitSkillCharacterQuest>((Func<UnitSkillCharacterQuest, bool>) (x => x.unit.ID == playerUnit.unit.ID && x.skill.skill_type != BattleskillSkillType.leader)).ToArray<UnitSkillCharacterQuest>();
      for (int i = 0; i < skills.Length; i++)
      {
        if (!intList.Contains(skills[i].skill.ID) && !((IEnumerable<UnitSkill>) this.allSkills).Contains<UnitSkill>(skills[i]))
        {
          UnitSkillCharacterQuest skillCharacterQuest = Array.Find<UnitSkillCharacterQuest>(array, (Predicate<UnitSkillCharacterQuest>) (x => x.skill.ID == skills[i].skill.ID));
          if (skillCharacterQuest == null || !intList.Contains(skillCharacterQuest.skill_after_evolution))
          {
            Array.Resize<UnitSkill>(ref this.allSkills, num + 1);
            this.allSkills[num++] = skills[i];
            intList.Add(skills[i].skill.ID);
          }
        }
      }
    }
    this.allSkills = ((IEnumerable<UnitSkill>) this.allSkills).Where<UnitSkill>((Func<UnitSkill, bool>) (x => x.skill.DispSkillList)).ToArray<UnitSkill>();
    if (this.allSkills.Length != 0)
      this.allSkills = ((IEnumerable<UnitSkill>) this.allSkills).OrderBy<UnitSkill, int>((Func<UnitSkill, int>) (x => x.skill_BattleskillSkill)).ToArray<UnitSkill>();
    this.skillDialogPrefab = prefabs[0];
    this.skillTypeIconPrefab = prefabs[1];
    this.skillLockIconPrefab = prefabs[2];
    this.setSkillIcons();
    yield break;
  }

  private void setSkillIcons()
  {
    this.setSkills.Clear();
    this.lstSkillIcon = new List<Tuple<BattleskillSkill, bool, GameObject>>(10);
    List<PopupSkillDetails.Param> first = this.setLSSkill();
    List<PopupSkillDetails.Param> objList1 = this.setPrencessSkill();
    List<PopupSkillDetails.Param> objList2 = this.setElementSkill();
    List<PopupSkillDetails.Param> objList3 = this.setGrowthSkill();
    List<PopupSkillDetails.Param> objList4 = this.setMultiSkill();
    List<PopupSkillDetails.Param> objList5 = this.setOverkillersSkill();
    List<PopupSkillDetails.Param> objList6 = this.setCommandSkill();
    List<PopupSkillDetails.Param> objList7 = this.setGrantSkill();
    List<PopupSkillDetails.Param> objList8 = this.setDuelSkill();
    List<PopupSkillDetails.Param> objList9 = this.setArmorSkill();
    List<PopupSkillDetails.Param> objList10 = this.controlFlags.IsOff(Control.Pickup) ? this.setExtraSkill() : this.setPickupExtraSkill();
    this.skillParams_ = first.Concat<PopupSkillDetails.Param>((IEnumerable<PopupSkillDetails.Param>) objList2).Concat<PopupSkillDetails.Param>((IEnumerable<PopupSkillDetails.Param>) objList3).Concat<PopupSkillDetails.Param>((IEnumerable<PopupSkillDetails.Param>) objList7).Concat<PopupSkillDetails.Param>((IEnumerable<PopupSkillDetails.Param>) objList10).Concat<PopupSkillDetails.Param>((IEnumerable<PopupSkillDetails.Param>) objList1).Concat<PopupSkillDetails.Param>((IEnumerable<PopupSkillDetails.Param>) objList4).Concat<PopupSkillDetails.Param>((IEnumerable<PopupSkillDetails.Param>) objList6).Concat<PopupSkillDetails.Param>((IEnumerable<PopupSkillDetails.Param>) objList8).Concat<PopupSkillDetails.Param>((IEnumerable<PopupSkillDetails.Param>) objList9).Concat<PopupSkillDetails.Param>((IEnumerable<PopupSkillDetails.Param>) objList5).ToArray<PopupSkillDetails.Param>();
    bool unlockedSeaSkill = this.playerUnit.isUnlockedSEASkill;
    PlayerUnitSkills playerUnitSkills = (!unlockedSeaSkill || !this.controlFlags.IsOff(Control.SelfAbility) ? 0 : this.playerUnit.countEquippedOverkillers) == 0 ? this.playerUnit.getSEASkill(bCheckUnlocked: false) : (PlayerUnitSkills) null;
    foreach (Tuple<BattleskillSkill, bool, GameObject> tuple in this.lstSkillIcon)
    {
      int? skillId = playerUnitSkills?.skill_id;
      int id = tuple.Item1.ID;
      if (skillId.GetValueOrDefault() == id & skillId.HasValue)
      {
        if (!unlockedSeaSkill)
        {
          UI2DSprite iconSprite = tuple.Item3.GetComponentInChildren<BattleSkillIcon>().iconSprite;
          if ((UnityEngine.Object) iconSprite != (UnityEngine.Object) null)
            iconSprite.color = Color.gray;
        }
        else
          this.skillLockIconPrefab.Clone(tuple.Item3.transform.parent);
      }
      else
      {
        int? transformationGroupId = tuple.Item1.transformationGroupId;
        if (transformationGroupId.HasValue && transformationGroupId.Value != 0)
        {
          GameObject gameObject = this.skillLockIconPrefab.Clone(tuple.Item3.transform.parent);
          if (tuple.Item2)
          {
            UI2DSprite iconSprite = tuple.Item3.GetComponentInChildren<BattleSkillIcon>().iconSprite;
            if ((UnityEngine.Object) iconSprite != (UnityEngine.Object) null)
              iconSprite.color = Color.gray;
          }
          else
            gameObject.GetComponentInChildren<UISprite>().color = Color.gray;
        }
      }
    }
    this.lstSkillIcon = (List<Tuple<BattleskillSkill, bool, GameObject>>) null;
  }

  public override bool Init(PlayerUnit playerUnit, PlayerUnit baseUnit)
  {
    this.gameObject.SetActive(true);
    return true;
  }

  private List<PopupSkillDetails.Param> setLSSkill()
  {
    List<PopupSkillDetails.Param> source = new List<PopupSkillDetails.Param>(1);
    PlayerUnitLeader_skills in_skill = (PlayerUnitLeader_skills) null;
    if (this.playerUnit.is_enemy && this.playerUnit.is_enemy_leader)
    {
      if (this.playerUnit.leader_skill != null)
      {
        in_skill = this.playerUnit.leader_skill;
        source.Add(new PopupSkillDetails.Param(this.playerUnit.leader_skill));
      }
    }
    else if (!this.playerUnit.is_enemy && this.playerUnit.leader_skill != null)
    {
      in_skill = this.playerUnit.leader_skill;
      source.Add(new PopupSkillDetails.Param(this.playerUnit.leader_skill));
    }
    if (source.Any<PopupSkillDetails.Param>())
    {
      this.StartCoroutine(this.LoadLSSkillIcon(this.dir_Leader_Skill_have, in_skill));
      this.slc_Leader_Skill_none.gameObject.SetActive(false);
      this.dir_Leader_Skill_have.gameObject.SetActive(true);
    }
    else
    {
      this.slc_Leader_Skill_none.gameObject.SetActive(true);
      this.dir_Leader_Skill_have.gameObject.SetActive(false);
    }
    return source;
  }

  private List<PopupSkillDetails.Param> setElementSkill()
  {
    List<PopupSkillDetails.Param> source = new List<PopupSkillDetails.Param>(1);
    for (int index = 0; index < this.allSkills.Length; ++index)
    {
      if (!this.setSkills.Contains(this.allSkills[index].skill.ID) && BattleskillSkill.InvestElementSkillIds.Contains(this.allSkills[index].skill_BattleskillSkill))
      {
        BattleskillSkill skill = this.playerUnit.evolutionSkill(this.allSkills[index].skill);
        PlayerUnitSkills playerUnitSkills = ((IEnumerable<PlayerUnitSkills>) this.playerUnit.skills).FirstOrDefault<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (x => x.skill_id == skill.ID));
        if (playerUnitSkills != null)
          this.createBattleSkillIcon(this.dir_Attribute_Skill_have, playerUnitSkills);
        else
          this.createBattleSkillIcon(this.dir_Attribute_Skill_have, this.allSkills[index], false);
        source.Add(new PopupSkillDetails.Param(playerUnitSkills, UnitParameter.SkillGroup.Element));
        break;
      }
    }
    if (!source.Any<PopupSkillDetails.Param>())
    {
      this.slc_Attribute_Skill_none.gameObject.SetActive(true);
      this.dir_Attribute_Skill_have.gameObject.SetActive(false);
    }
    else
    {
      this.slc_Attribute_Skill_none.gameObject.SetActive(false);
      this.dir_Attribute_Skill_have.gameObject.SetActive(true);
    }
    return source;
  }

  private List<PopupSkillDetails.Param> setGrowthSkill()
  {
    List<PopupSkillDetails.Param> source = new List<PopupSkillDetails.Param>(1);
    UnitSkill skill1 = ((IEnumerable<UnitSkill>) this.allSkills).FirstOrDefault<UnitSkill>((Func<UnitSkill, bool>) (x => x.skill.skill_type == BattleskillSkillType.growth));
    if (skill1 != null && !this.setSkills.Contains(skill1.skill.ID))
    {
      BattleskillSkill skill = this.playerUnit.evolutionSkill(skill1.skill);
      PlayerUnitSkills playerUnitSkills = ((IEnumerable<PlayerUnitSkills>) this.playerUnit.skills).FirstOrDefault<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (x => x.skill_id == skill.ID));
      if (playerUnitSkills != null)
      {
        this.createBattleSkillIcon(this.dir_Increase_Skill_have, playerUnitSkills);
        source.Add(new PopupSkillDetails.Param(playerUnitSkills, UnitParameter.SkillGroup.Growth));
      }
      else
      {
        this.createBattleSkillIcon(this.dir_Increase_Skill_have, skill1, false);
        source.Add(new PopupSkillDetails.Param(skill1.skill, UnitParameter.SkillGroup.Growth));
      }
    }
    if (!source.Any<PopupSkillDetails.Param>())
    {
      this.slc_Increase_Skill_none.gameObject.SetActive(true);
      this.dir_Increase_Skill_have.gameObject.SetActive(false);
    }
    else
    {
      this.slc_Increase_Skill_none.gameObject.SetActive(false);
      this.dir_Increase_Skill_have.gameObject.SetActive(true);
    }
    return source;
  }

  private List<PopupSkillDetails.Param> setMultiSkill()
  {
    List<PopupSkillDetails.Param> source = new List<PopupSkillDetails.Param>(1);
    PlayerUnitSkills playerUnitSkills1 = (PlayerUnitSkills) null;
    Dictionary<int, UnitSkillEvolution> unitSkillEvolutionDict = ((IEnumerable<UnitSkillEvolution>) MasterData.UnitSkillEvolutionList).Where<UnitSkillEvolution>((Func<UnitSkillEvolution, bool>) (x => x.unit.ID == this.playerUnit.unit.ID)).ToDictionary<UnitSkillEvolution, int>((Func<UnitSkillEvolution, int>) (x => x.after_skill.ID));
    UnitSkillHarmonyQuest[] array1 = ((IEnumerable<UnitSkillHarmonyQuest>) MasterData.UnitSkillHarmonyQuestList).Where<UnitSkillHarmonyQuest>((Func<UnitSkillHarmonyQuest, bool>) (x => x.character.ID == this.playerUnit.unit.character.ID && x.skill.skill_type != BattleskillSkillType.leader)).ToArray<UnitSkillHarmonyQuest>();
    if (array1.Length != 0)
    {
      List<PlayerUnitSkills> list = ((IEnumerable<UnitSkillHarmonyQuest>) array1).Select<UnitSkillHarmonyQuest, PlayerUnitSkills>((Func<UnitSkillHarmonyQuest, PlayerUnitSkills>) (s => ((IEnumerable<PlayerUnitSkills>) this.playerUnit.skills).FirstOrDefault<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (fd =>
      {
        if (s.skill == fd.skill)
          return true;
        return unitSkillEvolutionDict.ContainsKey(fd.skill.ID) && s.skill == unitSkillEvolutionDict[fd.skill.ID].before_skill;
      })))).Where<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (w => w != null)).Distinct<PlayerUnitSkills>().ToList<PlayerUnitSkills>();
      if (list.Any<PlayerUnitSkills>())
      {
        PlayerUnitSkills playerUnitSkills2 = list[0];
        if (!this.setSkills.Contains(playerUnitSkills2.skill.ID))
          playerUnitSkills1 = playerUnitSkills2;
      }
    }
    if (playerUnitSkills1 == null)
    {
      UnitSkillIntimate[] array2 = ((IEnumerable<UnitSkillIntimate>) MasterData.UnitSkillIntimateList).Where<UnitSkillIntimate>((Func<UnitSkillIntimate, bool>) (x => x.unit.ID == this.playerUnit.unit.ID && x.skill.DispSkillList)).ToArray<UnitSkillIntimate>();
      if (array2.Length != 0)
      {
        List<PlayerUnitSkills> list = ((IEnumerable<UnitSkillIntimate>) array2).Select<UnitSkillIntimate, PlayerUnitSkills>((Func<UnitSkillIntimate, PlayerUnitSkills>) (s => ((IEnumerable<PlayerUnitSkills>) this.playerUnit.skills).FirstOrDefault<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (fd =>
        {
          if (s.skill == fd.skill)
            return true;
          return unitSkillEvolutionDict.ContainsKey(fd.skill.ID) && s.skill == unitSkillEvolutionDict[fd.skill.ID].before_skill;
        })))).Where<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (w => w != null)).Distinct<PlayerUnitSkills>().ToList<PlayerUnitSkills>();
        if (list.Any<PlayerUnitSkills>())
        {
          PlayerUnitSkills playerUnitSkills2 = list[0];
          if (!this.setSkills.Contains(playerUnitSkills2.skill.ID))
            playerUnitSkills1 = playerUnitSkills2;
        }
      }
    }
    if (playerUnitSkills1 != null)
    {
      this.createBattleSkillIcon(this.dir_Multi_Skill_have, playerUnitSkills1);
      source.Add(new PopupSkillDetails.Param(playerUnitSkills1, UnitParameter.SkillGroup.Multi));
    }
    if (source.Any<PopupSkillDetails.Param>())
    {
      this.slc_Multi_Skill_none.gameObject.SetActive(false);
      this.dir_Multi_Skill_have.gameObject.SetActive(true);
    }
    else
    {
      this.slc_Multi_Skill_none.gameObject.SetActive(true);
      this.dir_Multi_Skill_have.gameObject.SetActive(false);
    }
    return source;
  }

  private List<PopupSkillDetails.Param> setOverkillersSkill()
  {
    List<PopupSkillDetails.Param> objList = new List<PopupSkillDetails.Param>(OverkillersSlotRelease.MaxSlot);
    int index = 0;
    if (this.controlFlags.IsOff(Control.SelfAbility) && this.playerUnit.isAnyCacheOverkillersUnits)
    {
      for (; index < this.playerUnit.cache_overkillers_units.Length; ++index)
      {
        PlayerUnit cacheOverkillersUnit = this.playerUnit.cache_overkillers_units[index];
        OverkillersSkillRelease overkillersSkillRelease = cacheOverkillersUnit != (PlayerUnit) null ? cacheOverkillersUnit.overkillersSkill : (OverkillersSkillRelease) null;
        int num = cacheOverkillersUnit != (PlayerUnit) null ? (int) cacheOverkillersUnit.unityTotal : -1;
        if (overkillersSkillRelease != null && num >= overkillersSkillRelease.unity_value)
        {
          this.createBattleSkillIcon(this.dir_Unit_Skill_have[index], overkillersSkillRelease);
          objList.Add(new PopupSkillDetails.Param(overkillersSkillRelease, new int?(num)));
          this.slc_Unit_Skill_none[index].gameObject.SetActive(false);
          this.dir_Unit_Skill_have[index].gameObject.SetActive(true);
        }
        else
        {
          this.slc_Unit_Skill_none[index].gameObject.SetActive(true);
          this.dir_Unit_Skill_have[index].gameObject.SetActive(false);
        }
      }
    }
    for (; index < this.slc_Unit_Skill_none.Length; ++index)
    {
      this.slc_Unit_Skill_none[index].gameObject.SetActive(true);
      this.dir_Unit_Skill_have[index].gameObject.SetActive(false);
    }
    return objList;
  }

  private List<PopupSkillDetails.Param> setCommandSkill()
  {
    List<PopupSkillDetails.Param> objList = new List<PopupSkillDetails.Param>(5);
    int num1 = 0;
    ((IEnumerable<UISprite>) this.slc_Command_Skill_none).ForEach<UISprite>((System.Action<UISprite>) (x => x.gameObject.SetActive(true)));
    ((IEnumerable<GameObject>) this.dir_Command_Skill_have).ForEach<GameObject>((System.Action<GameObject>) (x => x.gameObject.SetActive(false)));
    UnitSkill[] array1 = ((IEnumerable<UnitSkill>) this.allSkills).Where<UnitSkill>((Func<UnitSkill, bool>) (x => x.skill.skill_type == BattleskillSkillType.release)).ToArray<UnitSkill>();
    for (int index = 0; num1 < this.dir_Command_Skill_have.Length && index < array1.Length; ++index)
    {
      if (!this.setSkills.Contains(array1[index].skill.ID))
      {
        BattleskillSkill skill = this.playerUnit.evolutionSkill(array1[index].skill);
        PlayerUnitSkills playerUnitSkills = ((IEnumerable<PlayerUnitSkills>) this.playerUnit.skills).FirstOrDefault<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (x => x.skill_id == skill.ID));
        if (playerUnitSkills != null)
        {
          this.createBattleSkillIcon(this.dir_Command_Skill_have[num1++], playerUnitSkills);
          objList.Add(new PopupSkillDetails.Param(playerUnitSkills, UnitParameter.SkillGroup.Release));
        }
        else
        {
          this.createBattleSkillIcon(this.dir_Command_Skill_have[num1++], array1[index], false);
          objList.Add(new PopupSkillDetails.Param(array1[index].skill, UnitParameter.SkillGroup.Release));
        }
      }
    }
    UnitSkill[] array2 = ((IEnumerable<UnitSkill>) this.allSkills).Where<UnitSkill>((Func<UnitSkill, bool>) (x => x.skill.skill_type == BattleskillSkillType.command)).ToArray<UnitSkill>();
    for (int index = 0; num1 < this.dir_Command_Skill_have.Length && index < array2.Length; ++index)
    {
      if (!this.setSkills.Contains(array2[index].skill.ID))
      {
        BattleskillSkill skill = this.playerUnit.evolutionSkill(array2[index].skill);
        PlayerUnitSkills playerUnitSkills = ((IEnumerable<PlayerUnitSkills>) this.playerUnit.skills).FirstOrDefault<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (x => x.skill_id == skill.ID));
        if (playerUnitSkills != null)
        {
          this.createBattleSkillIcon(this.dir_Command_Skill_have[num1++], playerUnitSkills);
          objList.Add(new PopupSkillDetails.Param(playerUnitSkills, UnitParameter.SkillGroup.Command));
        }
        else
        {
          this.createBattleSkillIcon(this.dir_Command_Skill_have[num1++], array2[index], false);
          objList.Add(new PopupSkillDetails.Param(array2[index].skill, UnitParameter.SkillGroup.Command));
        }
      }
    }
    if (num1 < this.dir_Command_Skill_have.Length && this.playerUnit.hasSEASkills)
    {
      bool unlockedSeaSkill = this.playerUnit.isUnlockedSEASkill;
      int num2 = !unlockedSeaSkill || !this.controlFlags.IsOff(Control.SelfAbility) ? 0 : this.playerUnit.countEquippedOverkillers;
      PlayerUnitSkills seaSkill = this.playerUnit.getSEASkill(num2, false);
      this.createBattleSkillIcon(this.dir_Command_Skill_have[num1++], seaSkill);
      objList.Add(PopupSkillDetails.Param.createBySEASkillView(seaSkill, unlockedSeaSkill, num2));
    }
    for (int index = 0; index < num1; ++index)
    {
      this.slc_Command_Skill_none[index].gameObject.SetActive(false);
      this.dir_Command_Skill_have[index].gameObject.SetActive(true);
    }
    return objList;
  }

  private List<PopupSkillDetails.Param> setPrencessSkill()
  {
    List<PopupSkillDetails.Param> objList = new List<PopupSkillDetails.Param>(1);
    int num = 0;
    ((IEnumerable<UISprite>) this.slc_Prencess_Skill_none).ForEach<UISprite>((System.Action<UISprite>) (x => x.gameObject.SetActive(true)));
    ((IEnumerable<GameObject>) this.dir_Prencess_Skill_have).ForEach<GameObject>((System.Action<GameObject>) (x => x.gameObject.SetActive(false)));
    if (!this.prencessSkillIDs.Any<int>())
      return objList;
    UnitSkill[] skills = ((IEnumerable<UnitSkill>) this.allSkills).ToArray<UnitSkill>();
    for (int i = 0; num < this.dir_Prencess_Skill_have.Length && i < skills.Length; i++)
    {
      if (!this.setSkills.Contains(skills[i].skill.ID) && this.prencessSkillIDs.Any<int>((Func<int, bool>) (x => x == skills[i].skill_BattleskillSkill)))
      {
        BattleskillSkill skill = this.playerUnit.evolutionSkill(skills[i].skill);
        PlayerUnitSkills playerUnitSkills = ((IEnumerable<PlayerUnitSkills>) this.playerUnit.skills).FirstOrDefault<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (x => x.skill_id == skill.ID));
        if (playerUnitSkills != null)
        {
          this.createBattleSkillIcon(this.dir_Prencess_Skill_have[num++], playerUnitSkills);
          objList.Add(new PopupSkillDetails.Param(playerUnitSkills, UnitParameter.SkillGroup.Princess));
        }
        else
        {
          this.createBattleSkillIcon(this.dir_Prencess_Skill_have[num++], skills[i], false);
          objList.Add(new PopupSkillDetails.Param(skills[i].skill, UnitParameter.SkillGroup.Princess));
        }
      }
    }
    for (int index = 0; index < num; ++index)
    {
      this.slc_Prencess_Skill_none[index].gameObject.SetActive(false);
      this.dir_Prencess_Skill_have[index].gameObject.SetActive(true);
    }
    return objList;
  }

  private List<PopupSkillDetails.Param> setGrantSkill()
  {
    List<PopupSkillDetails.Param> objList = new List<PopupSkillDetails.Param>(8);
    int num = 0;
    ((IEnumerable<UISprite>) this.slc_Grant_Skill_none).ForEach<UISprite>((System.Action<UISprite>) (x => x.gameObject.SetActive(true)));
    ((IEnumerable<GameObject>) this.dir_Grant_Skill_have).ForEach<GameObject>((System.Action<GameObject>) (x => x.gameObject.SetActive(false)));
    UnitSkill[] skills = ((IEnumerable<UnitSkill>) this.allSkills).Where<UnitSkill>((Func<UnitSkill, bool>) (x => x.skill.skill_type == BattleskillSkillType.passive)).ToArray<UnitSkill>();
    for (int i = 0; num < this.dir_Grant_Skill_have.Length && i < skills.Length; i++)
    {
      if (!this.setSkills.Contains(skills[i].skill.ID) && !this.prencessSkillIDs.Any<int>((Func<int, bool>) (x => x == skills[i].skill_BattleskillSkill)))
      {
        BattleskillSkill skill = this.playerUnit.evolutionSkill(skills[i].skill);
        PlayerUnitSkills playerUnitSkills = ((IEnumerable<PlayerUnitSkills>) this.playerUnit.skills).FirstOrDefault<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (x => x.skill_id == skill.ID));
        if (playerUnitSkills != null)
        {
          this.createBattleSkillIcon(this.dir_Grant_Skill_have[num++], playerUnitSkills);
          objList.Add(new PopupSkillDetails.Param(playerUnitSkills, UnitParameter.SkillGroup.Grant));
        }
        else
        {
          this.createBattleSkillIcon(this.dir_Grant_Skill_have[num++], skills[i], false);
          objList.Add(new PopupSkillDetails.Param(skills[i].skill, UnitParameter.SkillGroup.Grant));
        }
      }
    }
    for (int index = 0; index < num; ++index)
    {
      this.slc_Grant_Skill_none[index].gameObject.SetActive(false);
      this.dir_Grant_Skill_have[index].gameObject.SetActive(true);
    }
    return objList;
  }

  private List<PopupSkillDetails.Param> setDuelSkill()
  {
    List<PopupSkillDetails.Param> objList = new List<PopupSkillDetails.Param>(4);
    int num = 0;
    ((IEnumerable<UISprite>) this.slc_Duel_Skill_none).ForEach<UISprite>((System.Action<UISprite>) (x => x.gameObject.SetActive(true)));
    ((IEnumerable<GameObject>) this.dir_Duel_Skill_have).ForEach<GameObject>((System.Action<GameObject>) (x => x.gameObject.SetActive(false)));
    UnitSkill[] array = ((IEnumerable<UnitSkill>) this.allSkills).Where<UnitSkill>((Func<UnitSkill, bool>) (x => x.skill.skill_type == BattleskillSkillType.duel)).ToArray<UnitSkill>();
    for (int index = 0; num < this.dir_Duel_Skill_have.Length && index < array.Length; ++index)
    {
      if (!this.setSkills.Contains(array[index].skill.ID))
      {
        BattleskillSkill skill = this.playerUnit.evolutionSkill(array[index].skill);
        PlayerUnitSkills playerUnitSkills = ((IEnumerable<PlayerUnitSkills>) this.playerUnit.skills).FirstOrDefault<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (x => x.skill_id == skill.ID));
        if (playerUnitSkills != null)
        {
          this.createBattleSkillIcon(this.dir_Duel_Skill_have[num++], playerUnitSkills);
          objList.Add(new PopupSkillDetails.Param(playerUnitSkills, UnitParameter.SkillGroup.Duel));
        }
        else
        {
          this.createBattleSkillIcon(this.dir_Duel_Skill_have[num++], array[index], false);
          objList.Add(new PopupSkillDetails.Param(array[index].skill, UnitParameter.SkillGroup.Duel));
        }
      }
    }
    for (int index = 0; index < num; ++index)
    {
      this.slc_Duel_Skill_none[index].gameObject.SetActive(false);
      this.dir_Duel_Skill_have[index].gameObject.SetActive(true);
    }
    return objList;
  }

  private List<PopupSkillDetails.Param> setArmorSkill()
  {
    List<PopupSkillDetails.Param> objList = new List<PopupSkillDetails.Param>(4);
    this.sIdx = 0;
    int num = 8;
    ((IEnumerable<UISprite>) this.slc_Armor_Skill_none).ForEach<UISprite>((System.Action<UISprite>) (x => x.gameObject.SetActive(true)));
    ((IEnumerable<GameObject>) this.dir_Armor_Skill_have).ForEach<GameObject>((System.Action<GameObject>) (x => x.gameObject.SetActive(false)));
    PlayerItem equippedGear = this.playerUnit.equippedGear;
    if (equippedGear != (PlayerItem) null)
    {
      for (int index = 0; index < equippedGear.skills.Length && this.sIdx < num; ++index)
      {
        GearGearSkill skill = equippedGear.skills[index];
        if (!this.setSkills.Contains(skill.skill_BattleskillSkill))
        {
          this.createBattleSkillIcon(this.dir_Armor_Skill_have[this.sIdx], skill);
          ++this.sIdx;
          objList.Add(new PopupSkillDetails.Param(skill.skill, UnitParameter.SkillGroup.Equip, new int?(skill.skill_level)));
        }
      }
    }
    PlayerItem equippedGear2 = this.playerUnit.equippedGear2;
    if (equippedGear2 != (PlayerItem) null)
    {
      for (int index = 0; index < equippedGear2.skills.Length && this.sIdx < num; ++index)
      {
        GearGearSkill skill = equippedGear2.skills[index];
        if (!this.setSkills.Contains(skill.skill_BattleskillSkill))
        {
          this.createBattleSkillIcon(this.dir_Armor_Skill_have[this.sIdx], skill);
          ++this.sIdx;
          objList.Add(new PopupSkillDetails.Param(skill.skill, UnitParameter.SkillGroup.Equip, new int?(skill.skill_level)));
        }
      }
    }
    PlayerItem equippedGear3 = this.playerUnit.equippedGear3;
    if (equippedGear3 != (PlayerItem) null)
    {
      for (int index = 0; index < equippedGear3.skills.Length && this.sIdx < num; ++index)
      {
        GearGearSkill skill = equippedGear3.skills[index];
        if (!this.setSkills.Contains(skill.skill_BattleskillSkill))
        {
          this.createBattleSkillIcon(this.dir_Armor_Skill_have[this.sIdx], skill);
          ++this.sIdx;
          objList.Add(new PopupSkillDetails.Param(skill.skill, UnitParameter.SkillGroup.Equip, new int?(skill.skill_level)));
        }
      }
    }
    for (int index = 0; index < this.sIdx && index < 4; ++index)
    {
      this.slc_Armor_Skill_none[index].gameObject.SetActive(false);
      this.dir_Armor_Skill_have[index].gameObject.SetActive(true);
    }
    if (this.isEnabledArmorSkills)
    {
      this.dir_Armor_Skill2.SetActive(false);
      if (this.sIdx <= 4)
        this.dir_Armor_Change_Button.isEnabled = false;
      else
        this.dir_Armor_Change_Button.isEnabled = true;
    }
    return objList;
  }

  public void ChangeArmorSkillButton()
  {
    if (!this.isEnabledArmorSkills)
      return;
    this.dir_Armor_Skill1.SetActive(!this.dir_Armor_Skill1.activeSelf);
    this.dir_Armor_Skill2.SetActive(!this.dir_Armor_Skill2.activeSelf);
    ((IEnumerable<UISprite>) this.slc_Armor_Skill_none).ForEach<UISprite>((System.Action<UISprite>) (x => x.gameObject.SetActive(true)));
    ((IEnumerable<GameObject>) this.dir_Armor_Skill_have).ForEach<GameObject>((System.Action<GameObject>) (x => x.gameObject.SetActive(false)));
    if (this.dir_Armor_Skill2.activeSelf)
    {
      for (int index = 0; index < this.sIdx - 4; ++index)
      {
        this.slc_Armor_Skill_none[index].gameObject.SetActive(false);
        this.dir_Armor_Skill_have[index + 4].gameObject.SetActive(true);
      }
    }
    else
    {
      for (int index = 0; index < this.slc_Armor_Skill_none.Length; ++index)
      {
        this.slc_Armor_Skill_none[index].gameObject.SetActive(false);
        this.dir_Armor_Skill_have[index].gameObject.SetActive(true);
      }
    }
  }

  public void ResetArmorSkillIcon()
  {
    if (this.sIdx <= 4 || !this.isEnabledArmorSkills)
      return;
    this.dir_Armor_Skill1.SetActive(true);
    this.dir_Armor_Skill2.SetActive(false);
    ((IEnumerable<UISprite>) this.slc_Armor_Skill_none).ForEach<UISprite>((System.Action<UISprite>) (x => x.gameObject.SetActive(true)));
    ((IEnumerable<GameObject>) this.dir_Armor_Skill_have).ForEach<GameObject>((System.Action<GameObject>) (x => x.gameObject.SetActive(false)));
    for (int index = 0; index < this.slc_Armor_Skill_none.Length; ++index)
    {
      this.slc_Armor_Skill_none[index].gameObject.SetActive(false);
      this.dir_Armor_Skill_have[index].gameObject.SetActive(true);
    }
  }

  private List<PopupSkillDetails.Param> setExtraSkill()
  {
    if (!(bool) (UnityEngine.Object) this.slc_Extra_Skill_locked)
      return new List<PopupSkillDetails.Param>();
    List<PopupSkillDetails.Param> objList = new List<PopupSkillDetails.Param>(1);
    if (this.playerUnit.unit.trust_target_flag)
    {
      this.slc_Extra_Skill_locked.gameObject.SetActive(false);
      this.slc_Extra_Skill_none.gameObject.SetActive(true);
      this.dir_Extra_Skill_have.gameObject.SetActive(false);
      this.slc_Extra_SkillNone_base.gameObject.SetActive(false);
      this.txt_ExtraSkill.gameObject.SetActive(true);
      if (!this.playerUnit.is_storage && !this.playerUnit.is_guest && !this.playerUnit.is_enemy)
      {
        PlayerAwakeSkill equippedExtraSkill = this.playerUnit.equippedExtraSkill;
        if (equippedExtraSkill != null)
        {
          this.StartCoroutine(this.LoadExtraSkillIcon(this.dir_Extra_Skill_have, equippedExtraSkill));
          this.slc_Extra_Skill_none.gameObject.SetActive(false);
          this.dir_Extra_Skill_have.gameObject.SetActive(true);
          if (this.limitMode || this.playerUnit.is_storage || this.controlFlags.IsOn(Control.CustomDeck))
            objList.Add(PopupSkillDetails.Param.createBySkillView(equippedExtraSkill));
          else
            objList.Add(PopupSkillDetails.Param.createBySkillView(equippedExtraSkill, (System.Action) (() =>
            {
              Singleton<PopupManager>.GetInstance().dismiss();
              this.changeEquipListScene();
            })));
        }
        else if (this.playerUnit.can_equip_awake_skill)
        {
          this.SetExtraSkillIconNoneSprite(this.slc_Extra_Skill_none);
        }
        else
        {
          this.slc_Extra_Skill_locked.gameObject.SetActive(true);
          this.slc_Extra_Skill_none.gameObject.SetActive(false);
          this.dir_Extra_Skill_have.gameObject.SetActive(false);
        }
      }
      else
      {
        PlayerUnitSkills playerUnitSkills = ((IEnumerable<PlayerUnitSkills>) this.playerUnit.skills).FirstOrDefault<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (x => x.skill.awake_skill_category_id != 1));
        if (playerUnitSkills != null && !this.setSkills.Contains(playerUnitSkills.skill_id))
        {
          this.createBattleSkillIcon(this.dir_Extra_Skill_have, playerUnitSkills);
          this.slc_Extra_Skill_none.gameObject.SetActive(false);
          this.dir_Extra_Skill_have.gameObject.SetActive(true);
          objList.Add(new PopupSkillDetails.Param(playerUnitSkills, UnitParameter.SkillGroup.Extra));
        }
      }
    }
    else
    {
      this.slc_Extra_Skill_locked.gameObject.SetActive(false);
      this.slc_Extra_Skill_none.gameObject.SetActive(false);
      this.dir_Extra_Skill_have.gameObject.SetActive(false);
      this.slc_Extra_SkillNone_base.gameObject.SetActive(true);
      this.txt_ExtraSkill.gameObject.SetActive(false);
    }
    return objList;
  }

  private List<PopupSkillDetails.Param> setPickupExtraSkill()
  {
    List<PopupSkillDetails.Param> objList = new List<PopupSkillDetails.Param>(1);
    UnitUnit u = this.playerUnit.unit;
    if (u.trust_target_flag)
    {
      this.txt_ExtraSkill.gameObject.SetActive(true);
      UnitSkillAwake s = Array.Find<UnitSkillAwake>(MasterData.UnitSkillAwakeList, (Predicate<UnitSkillAwake>) (x => x.character_id == u.same_character_id));
      if (s != null && !this.setSkills.Contains(s.skill_BattleskillSkill))
      {
        this.createBattleSkillIcon(this.dir_Extra_Skill_have, s.skill);
        this.slc_Extra_Skill_none.gameObject.SetActive(false);
        this.dir_Extra_Skill_have.gameObject.SetActive(true);
        objList.Add(PopupSkillDetails.Param.createByUnitView(s, this.playerUnit, bDisabledStatus: true));
      }
      else
      {
        this.slc_Extra_Skill_none.gameObject.SetActive(true);
        this.dir_Extra_Skill_have.gameObject.SetActive(false);
      }
    }
    else
    {
      this.slc_Extra_Skill_none.gameObject.SetActive(false);
      this.dir_Extra_Skill_have.gameObject.SetActive(false);
      this.txt_ExtraSkill.gameObject.SetActive(false);
    }
    return objList;
  }

  private void createSkillIconObject(GameObject parent, BattleskillSkill skill)
  {
    this.clearChildren(parent.transform);
    GameObject gameObject = this.skillTypeIconPrefab.Clone(parent.transform);
    gameObject.GetComponentInChildren<UI2DSprite>().depth = parent.GetComponent<UIWidget>().depth;
    this.StartCoroutine(gameObject.GetComponentInChildren<BattleSkillIcon>().Init(skill));
    this.setSkills.Add(skill.ID);
    this.lstSkillIcon.Add(Tuple.Create<BattleskillSkill, bool, GameObject>(skill, true, gameObject));
  }

  private void clearChildren(Transform trs)
  {
    foreach (Transform child in trs.GetChildren())
    {
      child.gameObject.SetActive(false);
      UnityEngine.Object.Destroy((UnityEngine.Object) child.gameObject);
    }
    trs.DetachChildren();
  }

  private void createBattleSkillIcon(GameObject parent, OverkillersSkillRelease skill)
  {
    BattleskillSkill skill1 = skill.skill;
    this.createSkillIconObject(parent, skill1);
    this.setIconEvent(parent, skill1);
  }

  private void createBattleSkillIcon(GameObject parent, PlayerUnitSkills skill)
  {
    BattleskillSkill skill1 = skill.skill;
    this.createSkillIconObject(parent, skill1);
    this.setIconEvent(parent, skill1);
  }

  private void createBattleSkillIcon(GameObject parent, GearGearSkill skill)
  {
    BattleskillSkill skill1 = skill.skill;
    this.createSkillIconObject(parent, skill1);
    this.setIconEvent(parent, skill1);
  }

  private void createBattleSkillIcon(GameObject parent, BattleskillSkill skill)
  {
    this.createSkillIconObject(parent, skill);
    this.setIconEvent(parent, skill);
  }

  private void createBattleSkillIcon(GameObject parent, UnitSkill skill, bool isLearn)
  {
    BattleskillSkill skill1 = skill.skill;
    if (isLearn)
      this.createSkillIconObject(parent, skill1);
    else
      this.createSkillIconNL(parent, skill1, skill.level);
    this.setIconEvent(parent, skill1);
  }

  private void createSkillIconNL(GameObject parent, BattleskillSkill skill, int level)
  {
    this.clearChildren(parent.transform);
    GameObject gameObject = this.skillTypeIconPrefab.Clone(parent.transform);
    gameObject.GetComponentInChildren<UI2DSprite>().depth = parent.GetComponent<UIWidget>().depth;
    gameObject.GetComponentInChildren<BattleSkillIcon>().EnableNeedLvIcon(level);
    this.StartCoroutine(gameObject.GetComponentInChildren<BattleSkillIcon>().Init(skill));
    this.setSkills.Add(skill.ID);
    this.lstSkillIcon.Add(Tuple.Create<BattleskillSkill, bool, GameObject>(skill, false, gameObject));
  }

  private IEnumerator LoadExtraSkillIcon(GameObject parent, PlayerAwakeSkill awakeSkill)
  {
    UI2DSprite extraSKill = parent.transform.GetComponentInChildren<UI2DSprite>();
    Future<UnityEngine.Sprite> spriteF = awakeSkill.masterData.LoadBattleSkillIcon();
    IEnumerator e = spriteF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    extraSKill.sprite2D = spriteF.Result;
    this.setSkills.Add(awakeSkill.skill_id);
    this.setIconEvent(parent, awakeSkill.masterData);
  }

  private void SetExtraSkillIconNoneSprite(UISprite spr)
  {
    UIButton componentInChildren = spr.gameObject.GetComponentInChildren<UIButton>();
    if (!Singleton<NGGameDataManager>.GetInstance().IsSea)
    {
      string str = this.playerUnit.unit.canUseAllGearHackSkill ? "slc_skill_icon_base_unit_special-unit_60_62.png__GUI__common__common_prefab" : "slc_extraskill_icon_base_60_62.png__GUI__common__common_prefab";
      spr.GetComponent<UISprite>().spriteName = str;
      componentInChildren.normalSprite = componentInChildren.hoverSprite = componentInChildren.pressedSprite = componentInChildren.disabledSprite = str;
    }
    if (this.limitMode || !this.controlFlags.IsOff(Control.CustomDeck))
      return;
    EventDelegate.Set(componentInChildren.onClick, (EventDelegate.Callback) (() => this.changeEquipListScene()));
  }

  private IEnumerator LoadLSSkillIcon(GameObject parent, BattleskillSkill in_skill)
  {
    BattleFuncs.InvestSkill skill = new BattleFuncs.InvestSkill();
    skill.skill = in_skill;
    skill.isEnemyIcon = this.playerUnit.is_enemy;
    UI2DSprite LSSKill = parent.GetComponent<UI2DSprite>();
    Future<UnityEngine.Sprite> spriteF = skill.skill.LoadBattleSkillIcon(skill);
    IEnumerator e = spriteF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    LSSKill.sprite2D = spriteF.Result;
    this.setSkills.Add(skill.skill.ID);
  }

  private IEnumerator LoadLSSkillIcon(
    GameObject parent,
    PlayerUnitLeader_skills in_skill)
  {
    // ISSUE: reference to a compiler-generated field
    int num = this.\u003C\u003E1__state;
    DetailMenuScrollViewSkill menuScrollViewSkill = this;
    BattleskillSkill s;
    if (num != 0)
    {
      if (num != 1)
        return false;
      // ISSUE: reference to a compiler-generated field
      this.\u003C\u003E1__state = -1;
      menuScrollViewSkill.setIconEvent(parent, s);
      return false;
    }
    // ISSUE: reference to a compiler-generated field
    this.\u003C\u003E1__state = -1;
    s = in_skill.skill;
    // ISSUE: reference to a compiler-generated field
    this.\u003C\u003E2__current = (object) menuScrollViewSkill.StartCoroutine(menuScrollViewSkill.LoadLSSkillIcon(parent, s));
    // ISSUE: reference to a compiler-generated field
    this.\u003C\u003E1__state = 1;
    return true;
  }

  private void setIconEvent(GameObject obj, BattleskillSkill skill) => EventDelegate.Set(obj.GetComponentInChildren<UIButton>().onClick, (EventDelegate.Callback) (() => this.onButtonIcon(skill)));

  private void onButtonIcon(BattleskillSkill skill)
  {
    if (this.skillParams_ == null)
      return;
    PopupSkillDetails.show(this.skillDialogPrefab, this.skillParams_, ((IEnumerable<PopupSkillDetails.Param>) this.skillParams_).FirstIndexOrNull<PopupSkillDetails.Param>((Func<PopupSkillDetails.Param, bool>) (x => x.skill == skill)).Value, this.playerUnit.is_enemy);
  }

  private void changeEquipListScene()
  {
    if (Singleton<NGGameDataManager>.GetInstance().IsSea)
      Singleton<CommonRoot>.GetInstance().headerType = CommonRoot.HeaderType.Normal;
    Unit004ExtraskillEquipListScene.changeScene(true, this.playerUnit);
  }

  public override IEnumerator initAsyncDiffMode(
    PlayerUnit playerUnit,
    PlayerUnit prevUnit,
    IDetailMenuContainer menuContainer)
  {
    this.playerUnit = playerUnit;
    this.limitMode = true;
    this.skillDialogPrefab = menuContainer.skillDetailDialogPrefab;
    this.skillTypeIconPrefab = menuContainer.skillTypeIconPrefab;
    this.skillLockIconPrefab = menuContainer.skillLockIconPrefab;
    this.prencessSkillIDs.Clear();
    foreach (UnitSkill unitSkill in ((IEnumerable<UnitSkill>) playerUnit.unit.RememberUnitAllSkills()).Where<UnitSkill>((Func<UnitSkill, bool>) (x => x.unit_type == playerUnit._unit_type)))
      this.prencessSkillIDs.Add(unitSkill.skill_BattleskillSkill);
    this.allSkills = new UnitSkill[0];
    List<int> intList = new List<int>();
    int num = 0;
    if (playerUnit.skills.Length != 0)
    {
      for (int index = 0; index < playerUnit.skills.Length; ++index)
      {
        UnitSkill unitSkill = new UnitSkill();
        unitSkill.ID = 0;
        unitSkill.unit_UnitUnit = playerUnit._unit;
        unitSkill.level = playerUnit.skills[index].level;
        unitSkill.skill_BattleskillSkill = playerUnit.skills[index].skill_id;
        unitSkill.unit_type = playerUnit._unit_type;
        Array.Resize<UnitSkill>(ref this.allSkills, num + 1);
        this.allSkills[num++] = unitSkill;
        intList.Add(playerUnit.skills[index].skill_id);
      }
    }
    UnitSkill[] array = ((IEnumerable<UnitSkill>) playerUnit.unit.RememberUnitSkills(playerUnit._unit_type)).Where<UnitSkill>((Func<UnitSkill, bool>) (x => x.skill.DispSkillList)).ToArray<UnitSkill>();
    if (array.Length != 0 && !playerUnit.is_enemy && !playerUnit.is_guest)
    {
      for (int index = 0; index < array.Length; ++index)
      {
        if (!intList.Contains(array[index].skill.ID) && !((IEnumerable<UnitSkill>) this.allSkills).Contains<UnitSkill>(array[index]))
        {
          Array.Resize<UnitSkill>(ref this.allSkills, num + 1);
          this.allSkills[num++] = array[index];
          intList.Add(array[index].skill.ID);
        }
      }
    }
    this.allSkills = ((IEnumerable<UnitSkill>) this.allSkills).Where<UnitSkill>((Func<UnitSkill, bool>) (x => x.skill.DispSkillList)).ToArray<UnitSkill>();
    if (this.allSkills.Length != 0)
      this.allSkills = ((IEnumerable<UnitSkill>) this.allSkills).OrderBy<UnitSkill, int>((Func<UnitSkill, int>) (x => x.skill_BattleskillSkill)).ToArray<UnitSkill>();
    this.setSkillIcons();
    yield break;
  }
}
