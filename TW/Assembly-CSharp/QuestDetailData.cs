// Decompiled with JetBrains decompiler
// Type: QuestDetailData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;

#nullable disable
public class QuestDetailData
{
  private bool isWait_;

  public QuestDetailData(CommonQuestType questType, int id, bool bwave)
  {
    this.isWave = bwave;
    this.type = questType;
    this.ID = id;
    this.isValidate = false;
    this.isWait_ = false;
  }

  public bool isWave { get; private set; }

  public CommonQuestType type { get; private set; }

  public int ID { get; private set; }

  public string name { get; private set; }

  public string recommend_strength { get; private set; }

  public GearKindEnum[] kinds { get; private set; }

  public CommonElement[] elements { get; private set; }

  public BattleskillSkill[] ailments { get; private set; }

  public bool isDisplayDrops { get; private set; }

  public QuestDetailData.Drop[] drops { get; private set; }

  public bool isValidate { get; private set; }

  [DebuggerHidden]
  public IEnumerator Wait(Action<WebAPI.Response.UserError> eventError)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new QuestDetailData.\u003CWait\u003Ec__Iterator298()
    {
      eventError = eventError,
      \u003C\u0024\u003EeventError = eventError,
      \u003C\u003Ef__this = this
    };
  }

  private void onWebAPIError(
    Action<WebAPI.Response.UserError> eventError,
    WebAPI.Response.UserError errState)
  {
    this.isWait_ = false;
    if (eventError == null)
      return;
    eventError(errState);
  }

  private void initialize(WebAPI.Response.BattleStoryQuestDetail data)
  {
    this.name = data.quest_name;
    this.recommend_strength = data.recommend_strength;
    this.isDisplayDrops = data.drop_info_display_flag;
    this.kinds = ((IEnumerable<int>) data.enemy_info_list.kind_ids).OrderBy<int, int>((Func<int, int>) (n => n)).Select<int, GearKindEnum>((Func<int, GearKindEnum>) (i => (GearKindEnum) i)).ToArray<GearKindEnum>();
    List<CommonElement> source = new List<CommonElement>();
    List<BattleskillSkill> skills = new List<BattleskillSkill>();
    foreach (WebAPI.Response.BattleStoryQuestDetailEnemy_info_listUnit_list unit in data.enemy_info_list.unit_list)
    {
      WebAPI.Response.BattleStoryQuestDetailEnemy_info_listUnit_list u = unit;
      List<BattleskillSkill> list = ((IEnumerable<int>) u.skill_ids).Select<int, BattleskillSkill>((Func<int, BattleskillSkill>) (i => MasterData.BattleskillSkill[i])).ToList<BattleskillSkill>();
      list.AddRange((IEnumerable<BattleskillSkill>) ((IEnumerable<GearGearSkill>) MasterData.GearGear[u.gear.gear_id].skills).Where<GearGearSkill>((Func<GearGearSkill, bool>) (s => s.release_rank <= u.gear.rank)).Select<GearGearSkill, BattleskillSkill>((Func<GearGearSkill, BattleskillSkill>) (ss => ss.skill)).ToList<BattleskillSkill>());
      source.AddRange((IEnumerable<CommonElement>) this.getElements(list));
      skills.AddRange((IEnumerable<BattleskillSkill>) list);
      skills.AddRange((IEnumerable<BattleskillSkill>) ((IEnumerable<GearGearSkill>) MasterData.GearGear[u.gear.gear_id].skills).Where<GearGearSkill>((Func<GearGearSkill, bool>) (s => s.release_rank <= u.gear.rank)).Select<GearGearSkill, BattleskillSkill>((Func<GearGearSkill, BattleskillSkill>) (ss => ss.skill)).ToList<BattleskillSkill>());
    }
    this.elements = source.Distinct<CommonElement>().OrderBy<CommonElement, int>((Func<CommonElement, int>) (e => (int) e)).ToArray<CommonElement>();
    this.ailments = this.getAilments(skills);
    this.drops = ((IEnumerable<WebAPI.Response.BattleStoryQuestDetailDrop_items>) data.drop_items).Select<WebAPI.Response.BattleStoryQuestDetailDrop_items, QuestDetailData.Drop>((Func<WebAPI.Response.BattleStoryQuestDetailDrop_items, QuestDetailData.Drop>) (di => new QuestDetailData.Drop(di.reward_id, di.reward_type_id, di.reward_quantity))).ToArray<QuestDetailData.Drop>();
  }

  private void initialize(WebAPI.Response.BattleWaveQuestDetail data)
  {
    this.name = data.quest_name;
    this.recommend_strength = data.recommend_strength;
    this.isDisplayDrops = data.drop_info_display_flag;
    this.kinds = ((IEnumerable<int>) data.enemy_info_list.kind_ids).OrderBy<int, int>((Func<int, int>) (n => n)).Select<int, GearKindEnum>((Func<int, GearKindEnum>) (i => (GearKindEnum) i)).ToArray<GearKindEnum>();
    List<CommonElement> source = new List<CommonElement>();
    List<BattleskillSkill> skills = new List<BattleskillSkill>();
    foreach (WebAPI.Response.BattleWaveQuestDetailEnemy_info_listUnit_list unit in data.enemy_info_list.unit_list)
    {
      WebAPI.Response.BattleWaveQuestDetailEnemy_info_listUnit_list u = unit;
      List<BattleskillSkill> list = ((IEnumerable<int>) u.skill_ids).Select<int, BattleskillSkill>((Func<int, BattleskillSkill>) (i => MasterData.BattleskillSkill[i])).ToList<BattleskillSkill>();
      list.AddRange((IEnumerable<BattleskillSkill>) ((IEnumerable<GearGearSkill>) MasterData.GearGear[u.gear.gear_id].skills).Where<GearGearSkill>((Func<GearGearSkill, bool>) (s => s.release_rank <= u.gear.rank)).Select<GearGearSkill, BattleskillSkill>((Func<GearGearSkill, BattleskillSkill>) (ss => ss.skill)).ToList<BattleskillSkill>());
      source.AddRange((IEnumerable<CommonElement>) this.getElements(list));
      skills.AddRange((IEnumerable<BattleskillSkill>) list);
      skills.AddRange((IEnumerable<BattleskillSkill>) ((IEnumerable<GearGearSkill>) MasterData.GearGear[u.gear.gear_id].skills).Where<GearGearSkill>((Func<GearGearSkill, bool>) (s => s.release_rank <= u.gear.rank)).Select<GearGearSkill, BattleskillSkill>((Func<GearGearSkill, BattleskillSkill>) (ss => ss.skill)).ToList<BattleskillSkill>());
    }
    this.elements = source.Distinct<CommonElement>().OrderBy<CommonElement, int>((Func<CommonElement, int>) (e => (int) e)).ToArray<CommonElement>();
    this.ailments = this.getAilments(skills);
    this.drops = ((IEnumerable<WebAPI.Response.BattleWaveQuestDetailDrop_items>) data.drop_items).Select<WebAPI.Response.BattleWaveQuestDetailDrop_items, QuestDetailData.Drop>((Func<WebAPI.Response.BattleWaveQuestDetailDrop_items, QuestDetailData.Drop>) (di => new QuestDetailData.Drop(di.reward_id, di.reward_type_id, di.reward_quantity))).ToArray<QuestDetailData.Drop>();
  }

  private void initialize(WebAPI.Response.BattleExtraQuestDetail data)
  {
    this.name = data.quest_name;
    this.recommend_strength = data.recommend_strength;
    this.isDisplayDrops = data.drop_info_display_flag;
    this.kinds = ((IEnumerable<int>) data.enemy_info_list.kind_ids).OrderBy<int, int>((Func<int, int>) (n => n)).Select<int, GearKindEnum>((Func<int, GearKindEnum>) (i => (GearKindEnum) i)).ToArray<GearKindEnum>();
    List<CommonElement> source = new List<CommonElement>();
    List<BattleskillSkill> skills = new List<BattleskillSkill>();
    foreach (WebAPI.Response.BattleExtraQuestDetailEnemy_info_listUnit_list unit in data.enemy_info_list.unit_list)
    {
      WebAPI.Response.BattleExtraQuestDetailEnemy_info_listUnit_list u = unit;
      List<BattleskillSkill> list = ((IEnumerable<int>) u.skill_ids).Select<int, BattleskillSkill>((Func<int, BattleskillSkill>) (i => MasterData.BattleskillSkill[i])).ToList<BattleskillSkill>();
      list.AddRange((IEnumerable<BattleskillSkill>) ((IEnumerable<GearGearSkill>) MasterData.GearGear[u.gear.gear_id].skills).Where<GearGearSkill>((Func<GearGearSkill, bool>) (s => s.release_rank <= u.gear.rank)).Select<GearGearSkill, BattleskillSkill>((Func<GearGearSkill, BattleskillSkill>) (ss => ss.skill)).ToList<BattleskillSkill>());
      source.AddRange((IEnumerable<CommonElement>) this.getElements(list));
      skills.AddRange((IEnumerable<BattleskillSkill>) list);
      skills.AddRange((IEnumerable<BattleskillSkill>) ((IEnumerable<GearGearSkill>) MasterData.GearGear[u.gear.gear_id].skills).Where<GearGearSkill>((Func<GearGearSkill, bool>) (s => s.release_rank <= u.gear.rank)).Select<GearGearSkill, BattleskillSkill>((Func<GearGearSkill, BattleskillSkill>) (ss => ss.skill)).ToList<BattleskillSkill>());
    }
    this.elements = source.Distinct<CommonElement>().OrderBy<CommonElement, int>((Func<CommonElement, int>) (e => (int) e)).ToArray<CommonElement>();
    this.ailments = this.getAilments(skills);
    this.drops = ((IEnumerable<WebAPI.Response.BattleExtraQuestDetailDrop_items>) data.drop_items).Select<WebAPI.Response.BattleExtraQuestDetailDrop_items, QuestDetailData.Drop>((Func<WebAPI.Response.BattleExtraQuestDetailDrop_items, QuestDetailData.Drop>) (di => new QuestDetailData.Drop(di.reward_id, di.reward_type_id, di.reward_quantity))).ToArray<QuestDetailData.Drop>();
  }

  private void initialize(WebAPI.Response.BattleCharacterQuestDetail data)
  {
    this.name = data.quest_name;
    this.recommend_strength = data.recommend_strength;
    this.isDisplayDrops = data.drop_info_display_flag;
    this.kinds = ((IEnumerable<int>) data.enemy_info_list.kind_ids).OrderBy<int, int>((Func<int, int>) (n => n)).Select<int, GearKindEnum>((Func<int, GearKindEnum>) (i => (GearKindEnum) i)).ToArray<GearKindEnum>();
    List<CommonElement> source = new List<CommonElement>();
    List<BattleskillSkill> skills = new List<BattleskillSkill>();
    foreach (WebAPI.Response.BattleCharacterQuestDetailEnemy_info_listUnit_list unit in data.enemy_info_list.unit_list)
    {
      WebAPI.Response.BattleCharacterQuestDetailEnemy_info_listUnit_list u = unit;
      List<BattleskillSkill> list = ((IEnumerable<int>) u.skill_ids).Select<int, BattleskillSkill>((Func<int, BattleskillSkill>) (i => MasterData.BattleskillSkill[i])).ToList<BattleskillSkill>();
      list.AddRange((IEnumerable<BattleskillSkill>) ((IEnumerable<GearGearSkill>) MasterData.GearGear[u.gear.gear_id].skills).Where<GearGearSkill>((Func<GearGearSkill, bool>) (s => s.release_rank <= u.gear.rank)).Select<GearGearSkill, BattleskillSkill>((Func<GearGearSkill, BattleskillSkill>) (ss => ss.skill)).ToList<BattleskillSkill>());
      source.AddRange((IEnumerable<CommonElement>) this.getElements(list));
      skills.AddRange((IEnumerable<BattleskillSkill>) list);
      skills.AddRange((IEnumerable<BattleskillSkill>) ((IEnumerable<GearGearSkill>) MasterData.GearGear[u.gear.gear_id].skills).Where<GearGearSkill>((Func<GearGearSkill, bool>) (s => s.release_rank <= u.gear.rank)).Select<GearGearSkill, BattleskillSkill>((Func<GearGearSkill, BattleskillSkill>) (ss => ss.skill)).ToList<BattleskillSkill>());
    }
    this.elements = source.Distinct<CommonElement>().OrderBy<CommonElement, int>((Func<CommonElement, int>) (e => (int) e)).ToArray<CommonElement>();
    this.ailments = this.getAilments(skills);
    this.drops = ((IEnumerable<WebAPI.Response.BattleCharacterQuestDetailDrop_items>) data.drop_items).Select<WebAPI.Response.BattleCharacterQuestDetailDrop_items, QuestDetailData.Drop>((Func<WebAPI.Response.BattleCharacterQuestDetailDrop_items, QuestDetailData.Drop>) (di => new QuestDetailData.Drop(di.reward_id, di.reward_type_id, di.reward_quantity))).ToArray<QuestDetailData.Drop>();
  }

  private void initialize(WebAPI.Response.BattleHarmonyQuestDetail data)
  {
    this.name = data.quest_name;
    this.recommend_strength = data.recommend_strength;
    this.isDisplayDrops = data.drop_info_display_flag;
    this.kinds = ((IEnumerable<int>) data.enemy_info_list.kind_ids).OrderBy<int, int>((Func<int, int>) (n => n)).Select<int, GearKindEnum>((Func<int, GearKindEnum>) (i => (GearKindEnum) i)).ToArray<GearKindEnum>();
    List<CommonElement> source = new List<CommonElement>();
    List<BattleskillSkill> skills = new List<BattleskillSkill>();
    foreach (WebAPI.Response.BattleHarmonyQuestDetailEnemy_info_listUnit_list unit in data.enemy_info_list.unit_list)
    {
      WebAPI.Response.BattleHarmonyQuestDetailEnemy_info_listUnit_list u = unit;
      List<BattleskillSkill> list = ((IEnumerable<int>) u.skill_ids).Select<int, BattleskillSkill>((Func<int, BattleskillSkill>) (i => MasterData.BattleskillSkill[i])).ToList<BattleskillSkill>();
      list.AddRange((IEnumerable<BattleskillSkill>) ((IEnumerable<GearGearSkill>) MasterData.GearGear[u.gear.gear_id].skills).Where<GearGearSkill>((Func<GearGearSkill, bool>) (s => s.release_rank <= u.gear.rank)).Select<GearGearSkill, BattleskillSkill>((Func<GearGearSkill, BattleskillSkill>) (ss => ss.skill)).ToList<BattleskillSkill>());
      source.AddRange((IEnumerable<CommonElement>) this.getElements(list));
      skills.AddRange((IEnumerable<BattleskillSkill>) list);
      skills.AddRange((IEnumerable<BattleskillSkill>) ((IEnumerable<GearGearSkill>) MasterData.GearGear[u.gear.gear_id].skills).Where<GearGearSkill>((Func<GearGearSkill, bool>) (s => s.release_rank <= u.gear.rank)).Select<GearGearSkill, BattleskillSkill>((Func<GearGearSkill, BattleskillSkill>) (ss => ss.skill)).ToList<BattleskillSkill>());
    }
    this.elements = source.Distinct<CommonElement>().OrderBy<CommonElement, int>((Func<CommonElement, int>) (e => (int) e)).ToArray<CommonElement>();
    this.ailments = this.getAilments(skills);
    this.drops = ((IEnumerable<WebAPI.Response.BattleHarmonyQuestDetailDrop_items>) data.drop_items).Select<WebAPI.Response.BattleHarmonyQuestDetailDrop_items, QuestDetailData.Drop>((Func<WebAPI.Response.BattleHarmonyQuestDetailDrop_items, QuestDetailData.Drop>) (di => new QuestDetailData.Drop(di.reward_id, di.reward_type_id, di.reward_quantity))).ToArray<QuestDetailData.Drop>();
  }

  private List<CommonElement> getElements(List<BattleskillSkill> skills)
  {
    List<CommonElement> list = skills.Where<BattleskillSkill>((Func<BattleskillSkill, bool>) (s => ((IEnumerable<BattleskillEffect>) s.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (ef => ef.effect_logic.Enum == BattleskillEffectLogicEnum.invest_element)))).Select<BattleskillSkill, CommonElement>((Func<BattleskillSkill, CommonElement>) (ss => ss.element)).Distinct<CommonElement>().ToList<CommonElement>();
    if (!list.Any<CommonElement>())
      list.Add(CommonElement.none);
    return list;
  }

  private BattleskillSkill[] getAilments(List<BattleskillSkill> skills)
  {
    List<BattleskillSkill> list = skills.Distinct<BattleskillSkill>((IEqualityComparer<BattleskillSkill>) new LambdaEqualityComparer<BattleskillSkill>((Func<BattleskillSkill, BattleskillSkill, bool>) ((a, b) => a.ID == b.ID))).ToList<BattleskillSkill>();
    List<BattleskillSkill> source = new List<BattleskillSkill>();
    foreach (BattleskillSkill battleskillSkill in list)
    {
      if (((IEnumerable<int>) battleskillSkill.InvestSkillIds()).Where<int>((Func<int, bool>) (i => MasterData.BattleskillSkill.ContainsKey(i))).Select<int, BattleskillSkill>((Func<int, BattleskillSkill>) (i => MasterData.BattleskillSkill[i])).Where<BattleskillSkill>((Func<BattleskillSkill, bool>) (s => s.skill_type == BattleskillSkillType.ailment)).Any<BattleskillSkill>())
        source.Add(battleskillSkill);
    }
    return source.OrderBy<BattleskillSkill, int>((Func<BattleskillSkill, int>) (s => s.ID)).ToArray<BattleskillSkill>();
  }

  public class Drop
  {
    public Drop(int id, int type, int num)
    {
      this.rewardId = id;
      this.rewardType = (MasterDataTable.CommonRewardType) type;
      this.quantity = num;
    }

    public int rewardId { get; private set; }

    public MasterDataTable.CommonRewardType rewardType { get; private set; }

    public int quantity { get; private set; }
  }
}
