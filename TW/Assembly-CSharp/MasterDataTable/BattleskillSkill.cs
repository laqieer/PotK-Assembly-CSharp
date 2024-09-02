// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleskillSkill
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class BattleskillSkill
  {
    public int ID;
    public string name;
    public string description;
    public int skill_type_BattleskillSkillType;
    public int element_CommonElement;
    public int? genre1_BattleskillGenre;
    public int? genre2_BattleskillGenre;
    public int target_type_BattleskillTargetType;
    public int min_range;
    public int max_range;
    public int consume_hp;
    public int weight;
    public int power;
    public int use_count;
    public int charge_turn;
    public string duel_magic_bullet_name;
    public string field_effect_name;
    public string field_target_effect_name;
    public int upper_level;
    public int? field_effect_BattleskillFieldEffect;
    public int? duel_effect_BattleskillDuelEffect;
    public int? passive_effect_BattleskillFieldEffect;
    public bool time_of_death_skill_disable;
    public int? ailment_effect_BattleskillAilmentEffect;
    public bool range_effect_passive_skill;
    public int max_use_count;

    public BattleskillEffect[] Effects => MasterData.WhereBattleskillEffectBy(this);

    public bool PassiveSkill
    {
      get
      {
        return this.skill_type == BattleskillSkillType.leader || this.skill_type == BattleskillSkillType.duel || this.skill_type == BattleskillSkillType.passive;
      }
    }

    public bool DispSkillList
    {
      get
      {
        return this.skill_type != BattleskillSkillType.leader && this.skill_type != BattleskillSkillType.magic;
      }
    }

    public bool haveKoyuDuelEffect => this.duel_effect != null && this.duel_effect.isKoyuDuelEffect;

    public int[] InvestSkillIds()
    {
      if (((IEnumerable<BattleskillEffect>) this.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (x => x.HasKey("gda_percentage_invocation") || x.HasKey("gdd_percentage_invocation"))))
      {
        List<int> intList = new List<int>();
        int idx = 1;
        while (true)
        {
          IEnumerable<int> ints = ((IEnumerable<BattleskillEffect>) this.Effects).Where<BattleskillEffect>((Func<BattleskillEffect, bool>) (x => x.HasKey("skill_id" + (object) idx))).Select<BattleskillEffect, int>((Func<BattleskillEffect, int>) (x =>
          {
            int num = x.GetInt("skill_id" + (object) idx);
            if (num < 0)
              num = -num;
            return num;
          })).Where<int>((Func<int, bool>) (x => x != 0 && MasterData.BattleskillSkill.ContainsKey(x)));
          if (ints.Count<int>() != 0)
          {
            intList.AddRange(ints);
            ++idx;
          }
          else
            break;
        }
        return intList.ToArray();
      }
      BattleskillEffectLogicEnum[] Logics = new BattleskillEffectLogicEnum[7]
      {
        BattleskillEffectLogicEnum.mdmg_combi,
        BattleskillEffectLogicEnum.invest_skilleffect,
        BattleskillEffectLogicEnum.invest_passive,
        BattleskillEffectLogicEnum.anohana_trio,
        BattleskillEffectLogicEnum.combi_attack,
        BattleskillEffectLogicEnum.invest_skilleffect_im,
        BattleskillEffectLogicEnum.passive_invest_passive
      };
      return ((IEnumerable<BattleskillEffect>) this.Effects).Where<BattleskillEffect>((Func<BattleskillEffect, bool>) (x => ((IEnumerable<BattleskillEffectLogicEnum>) Logics).Contains<BattleskillEffectLogicEnum>(x.effect_logic.Enum))).Select<BattleskillEffect, int>((Func<BattleskillEffect, int>) (x =>
      {
        int num = x.GetInt("skill_id");
        if (num < 0)
          num = -num;
        return num;
      })).Where<int>((Func<int, bool>) (x => x != 0 && MasterData.BattleskillSkill.ContainsKey(x))).ToArray<int>();
    }

    public static BattleskillSkill Parse(MasterDataReader reader)
    {
      return new BattleskillSkill()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        description = reader.ReadString(true),
        skill_type_BattleskillSkillType = reader.ReadInt(),
        element_CommonElement = reader.ReadInt(),
        genre1_BattleskillGenre = reader.ReadIntOrNull(),
        genre2_BattleskillGenre = reader.ReadIntOrNull(),
        target_type_BattleskillTargetType = reader.ReadInt(),
        min_range = reader.ReadInt(),
        max_range = reader.ReadInt(),
        consume_hp = reader.ReadInt(),
        weight = reader.ReadInt(),
        power = reader.ReadInt(),
        use_count = reader.ReadInt(),
        charge_turn = reader.ReadInt(),
        duel_magic_bullet_name = reader.ReadString(true),
        field_effect_name = reader.ReadString(true),
        field_target_effect_name = reader.ReadString(true),
        upper_level = reader.ReadInt(),
        field_effect_BattleskillFieldEffect = reader.ReadIntOrNull(),
        duel_effect_BattleskillDuelEffect = reader.ReadIntOrNull(),
        passive_effect_BattleskillFieldEffect = reader.ReadIntOrNull(),
        time_of_death_skill_disable = reader.ReadBool(),
        ailment_effect_BattleskillAilmentEffect = reader.ReadIntOrNull(),
        range_effect_passive_skill = reader.ReadBool(),
        max_use_count = reader.ReadInt()
      };
    }

    public BattleskillSkillType skill_type
    {
      get => (BattleskillSkillType) this.skill_type_BattleskillSkillType;
    }

    public CommonElement element => (CommonElement) this.element_CommonElement;

    public BattleskillGenre? genre1
    {
      get
      {
        int? battleskillGenre = this.genre1_BattleskillGenre;
        return battleskillGenre.HasValue ? new BattleskillGenre?((BattleskillGenre) battleskillGenre.Value) : new BattleskillGenre?();
      }
    }

    public BattleskillGenre? genre2
    {
      get
      {
        int? battleskillGenre = this.genre2_BattleskillGenre;
        return battleskillGenre.HasValue ? new BattleskillGenre?((BattleskillGenre) battleskillGenre.Value) : new BattleskillGenre?();
      }
    }

    public BattleskillTargetType target_type
    {
      get => (BattleskillTargetType) this.target_type_BattleskillTargetType;
    }

    public BattleskillFieldEffect field_effect
    {
      get
      {
        if (!this.field_effect_BattleskillFieldEffect.HasValue)
          return (BattleskillFieldEffect) null;
        BattleskillFieldEffect fieldEffect;
        if (!MasterData.BattleskillFieldEffect.TryGetValue(this.field_effect_BattleskillFieldEffect.Value, out fieldEffect))
          Debug.LogError((object) ("Key not Found: MasterData.BattleskillFieldEffect[" + (object) this.field_effect_BattleskillFieldEffect.Value + "]"));
        return fieldEffect;
      }
    }

    public BattleskillDuelEffect duel_effect
    {
      get
      {
        if (!this.duel_effect_BattleskillDuelEffect.HasValue)
          return (BattleskillDuelEffect) null;
        BattleskillDuelEffect duelEffect;
        if (!MasterData.BattleskillDuelEffect.TryGetValue(this.duel_effect_BattleskillDuelEffect.Value, out duelEffect))
          Debug.LogError((object) ("Key not Found: MasterData.BattleskillDuelEffect[" + (object) this.duel_effect_BattleskillDuelEffect.Value + "]"));
        return duelEffect;
      }
    }

    public BattleskillFieldEffect passive_effect
    {
      get
      {
        if (!this.passive_effect_BattleskillFieldEffect.HasValue)
          return (BattleskillFieldEffect) null;
        BattleskillFieldEffect passiveEffect;
        if (!MasterData.BattleskillFieldEffect.TryGetValue(this.passive_effect_BattleskillFieldEffect.Value, out passiveEffect))
          Debug.LogError((object) ("Key not Found: MasterData.BattleskillFieldEffect[" + (object) this.passive_effect_BattleskillFieldEffect.Value + "]"));
        return passiveEffect;
      }
    }

    public BattleskillAilmentEffect ailment_effect
    {
      get
      {
        if (!this.ailment_effect_BattleskillAilmentEffect.HasValue)
          return (BattleskillAilmentEffect) null;
        BattleskillAilmentEffect ailmentEffect;
        if (!MasterData.BattleskillAilmentEffect.TryGetValue(this.ailment_effect_BattleskillAilmentEffect.Value, out ailmentEffect))
          Debug.LogError((object) ("Key not Found: MasterData.BattleskillAilmentEffect[" + (object) this.ailment_effect_BattleskillAilmentEffect.Value + "]"));
        return ailmentEffect;
      }
    }

    public Future<GameObject> LoadDuelMagicBulletPrefab()
    {
      string path = string.Format("BattleEffects/duel/MagicBullets/{0}", (object) this.duel_magic_bullet_name);
      return Singleton<ResourceManager>.GetInstance().LoadOrNull<GameObject>(path);
    }

    public Future<GameObject> LoadFieldEffectPrefab()
    {
      string path = string.Format("BattleEffects/field/{0}", (object) this.field_effect_name);
      return Singleton<ResourceManager>.GetInstance().LoadOrNull<GameObject>(path);
    }

    public Future<GameObject> LoadFieldTargetEffectPrefab()
    {
      string path = string.Format("BattleEffects/field/{0}", (object) this.field_target_effect_name);
      return Singleton<ResourceManager>.GetInstance().LoadOrNull<GameObject>(path);
    }

    public Future<Sprite> LoadBattleSkillIcon()
    {
      string path = string.Format("BattleSkills/{0}/skill_icon", (object) this.ID);
      return Singleton<ResourceManager>.GetInstance().LoadOrNull<Sprite>(path);
    }
  }
}
