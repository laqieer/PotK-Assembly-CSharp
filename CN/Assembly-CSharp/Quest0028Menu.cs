// Decompiled with JetBrains decompiler
// Type: Quest0028Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
public class Quest0028Menu : BackButtonMenuBase
{
  private const int SUPPLY_DECK_MAX = 5;
  protected const float LINK_HEIGHT = 100f;
  protected const float LINK_DEFHEIGHT = 136f;
  protected const float scale = 0.7352941f;
  public NGHorizontalScrollParts indicator;
  [SerializeField]
  private GameObject[] Btns;
  private BattleStageGuest[] guest;
  private bool isLimitation;
  private bool isUserDeckStage;
  private bool friendPositionEnable;
  private PlayerDeck[] regulationDeck;
  [SerializeField]
  private UIButton btnUnit;
  private PlayerDeck[] playerDecks;
  private Dictionary<int, Quest0028Indicator> indicators = new Dictionary<int, Quest0028Indicator>();
  private Dictionary<int, int> deckIndexs = new Dictionary<int, int>();
  private Dictionary<int, int> deckIndexsBack = new Dictionary<int, int>();
  private PlayerHelper friend;
  private PlayerStoryQuestS story_quest;
  private PlayerExtraQuestS extra_quest;
  private PlayerCharacterQuestS char_quest;
  private PlayerQuestSConverter convert_quest;
  private GameObject apPopup;
  private int selectDeck;
  private int[] DeckNums;
  private Quest0028Menu.LimitedQuestData regulation = new Quest0028Menu.LimitedQuestData();
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  protected GameObject[] dir_Items;
  [SerializeField]
  private QuestMoviePlayer movieObj;

  private string quest_name
  {
    get
    {
      if (this.story_quest != null)
        return this.story_quest.quest_story_s.name;
      if (this.extra_quest != null)
        return this.extra_quest.quest_extra_s.name;
      if (this.char_quest != null)
        return this.char_quest.quest_character_s.name;
      return this.convert_quest != null ? this.convert_quest.questS.name : string.Empty;
    }
  }

  private int qusetID
  {
    get
    {
      if (this.story_quest != null)
        return this.story_quest._quest_story_s;
      if (this.extra_quest != null)
        return this.extra_quest._quest_extra_s;
      if (this.char_quest != null)
        return this.char_quest._quest_character_s;
      return this.convert_quest != null ? this.convert_quest._quest_s_id : 0;
    }
  }

  private int lost_ap
  {
    get
    {
      if (this.story_quest != null)
        return this.story_quest.consumed_ap;
      if (this.extra_quest != null)
        return this.extra_quest.consumed_ap;
      if (this.char_quest != null)
        return this.char_quest.consumed_ap;
      return this.convert_quest != null ? this.convert_quest.consumed_ap : -1;
    }
  }

  private UnitGender gender_restriction
  {
    get
    {
      if (this.story_quest != null)
        return this.story_quest.quest_story_s.gender_restriction;
      if (this.extra_quest != null)
        return this.extra_quest.quest_extra_s.gender_restriction;
      if (this.char_quest != null)
        return this.char_quest.quest_character_s.gender_restriction;
      return this.convert_quest != null ? this.convert_quest.questS.gender_restriction : UnitGender.none;
    }
  }

  protected Quest0028Menu.LimitedQuestData Regulation => this.regulation;

  [DebuggerHidden]
  protected IEnumerator CallExtarDeckData(int id)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0028Menu.\u003CCallExtarDeckData\u003Ec__Iterator279()
    {
      id = id,
      \u003C\u0024\u003Eid = id,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected IEnumerator CallStoryDeckData(int id)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0028Menu.\u003CCallStoryDeckData\u003Ec__Iterator27A()
    {
      id = id,
      \u003C\u0024\u003Eid = id,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected IEnumerator CallCharaDeckData(int id)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0028Menu.\u003CCallCharaDeckData\u003Ec__Iterator27B()
    {
      id = id,
      \u003C\u0024\u003Eid = id,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected IEnumerator CallConvertDeckData(PlayerQuestSConverter data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0028Menu.\u003CCallConvertDeckData\u003Ec__Iterator27C()
    {
      data = data,
      \u003C\u0024\u003Edata = data,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator InitPlayerDecks(
    PlayerDeck[] playerDecks,
    List<PlayerItem> SupplyList,
    PlayerHelper friend,
    PlayerStoryQuestS story_quest,
    PlayerExtraQuestS extra_quest,
    PlayerCharacterQuestS char_quest,
    PlayerQuestSConverter convert_quest)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0028Menu.\u003CInitPlayerDecks\u003Ec__Iterator27D()
    {
      extra_quest = extra_quest,
      story_quest = story_quest,
      char_quest = char_quest,
      convert_quest = convert_quest,
      friend = friend,
      playerDecks = playerDecks,
      SupplyList = SupplyList,
      \u003C\u0024\u003Eextra_quest = extra_quest,
      \u003C\u0024\u003Estory_quest = story_quest,
      \u003C\u0024\u003Echar_quest = char_quest,
      \u003C\u0024\u003Econvert_quest = convert_quest,
      \u003C\u0024\u003Efriend = friend,
      \u003C\u0024\u003EplayerDecks = playerDecks,
      \u003C\u0024\u003ESupplyList = SupplyList,
      \u003C\u003Ef__this = this
    };
  }

  protected override void Update()
  {
    base.Update();
    if (this.playerDecks == null || this.selectDeck == this.DeckNums[this.indicator.selected])
      return;
    this.selectDeck = this.DeckNums[this.indicator.selected];
    if (((IEnumerable<PlayerUnit>) this.playerDecks[this.selectDeck].player_units).Where<PlayerUnit>((Func<PlayerUnit, bool>) (x => x != (PlayerUnit) null)).Where<PlayerUnit>((Func<PlayerUnit, bool>) (x => x.equippedGear != (PlayerItem) null)).Count<PlayerUnit>((Func<PlayerUnit, bool>) (x => x.equippedGear.broken)) > 0)
    {
      ((IEnumerable<GameObject>) this.Btns).ToggleOnce(1);
    }
    else
    {
      ((IEnumerable<GameObject>) this.Btns).ToggleOnce(0);
      if (this.isLimitation && this.regulationDeck != null)
      {
        int[] array = ((IEnumerable<PlayerUnit>) this.indicators[this.selectDeck].deckUnitData).Where<PlayerUnit>((Func<PlayerUnit, bool>) (x => x != (PlayerUnit) null && !x.is_gesut)).Select<PlayerUnit, int>((Func<PlayerUnit, int>) (x => x.id)).ToArray<int>();
        int?[] checkedDeckIds = ((IEnumerable<int?>) this.regulationDeck[this.selectDeck].player_unit_ids).Where<int?>((Func<int?, bool>) (n => n.HasValue)).ToArray<int?>();
        if (((IEnumerable<int>) array).All<int>((Func<int, bool>) (id => ((IEnumerable<int?>) checkedDeckIds).Any<int?>((Func<int?, bool>) (id_c => id_c.GetValueOrDefault() == id && id_c.HasValue)))))
          return;
        ((IEnumerable<GameObject>) this.Btns).ToggleOnce(2);
      }
      else if (this.isLimitation && this.regulationDeck == null)
      {
        ((IEnumerable<GameObject>) this.Btns).ToggleOnce(2);
      }
      else
      {
        if (this.gender_restriction == UnitGender.none || ((IEnumerable<PlayerUnit>) this.playerDecks[this.selectDeck].player_units).All<PlayerUnit>((Func<PlayerUnit, bool>) (x => x == (PlayerUnit) null || x.unit.character.gender == this.gender_restriction)))
          return;
        ((IEnumerable<GameObject>) this.Btns).ToggleOnce(2);
      }
    }
  }

  [DebuggerHidden]
  private IEnumerator AddDeck(
    PlayerDeck playerDeck,
    PlayerHelper friend,
    GameObject prefab,
    QuestScoreBonusTimetable[] tables,
    BattleStageGuest[] guests,
    int battleStageID)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0028Menu.\u003CAddDeck\u003Ec__Iterator27E()
    {
      prefab = prefab,
      playerDeck = playerDeck,
      friend = friend,
      tables = tables,
      guests = guests,
      battleStageID = battleStageID,
      \u003C\u0024\u003Eprefab = prefab,
      \u003C\u0024\u003EplayerDeck = playerDeck,
      \u003C\u0024\u003Efriend = friend,
      \u003C\u0024\u003Etables = tables,
      \u003C\u0024\u003Eguests = guests,
      \u003C\u0024\u003EbattleStageID = battleStageID,
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnItemedit() => Quest00210Scene.changeScene(true);

  private void QuestStart()
  {
    Singleton<CommonRoot>.GetInstance().isLoading = true;
    int ap = SMManager.Get<Player>().ap;
    int apOverflow = SMManager.Get<Player>().ap_overflow;
    if (this.playerDecks[this.selectDeck].cost <= this.playerDecks[this.selectDeck].cost_limit)
    {
      if (this.extra_quest != null)
        this.StartCoroutine(this.checkExtra());
      else if (ap + apOverflow < this.lost_ap)
      {
        Singleton<CommonRoot>.GetInstance().isLoading = false;
        Singleton<PopupManager>.GetInstance().open(this.apPopup);
      }
      else if (this.story_quest != null)
        this.StartCoroutine(this.StoryMovie(this.story_quest.quest_story_s.ID, this.story_quest.is_new, new System.Action(this.StoryStartApi)));
      else if (this.char_quest != null)
        this.StartCoroutine(this.StoryMovie(this.char_quest.quest_character_s.ID, this.char_quest.is_new, new System.Action(this.CharacterStartApi)));
      else if (this.convert_quest != null)
      {
        System.Action act = (System.Action) null;
        if (this.convert_quest.questS.data_type == QuestSConverter.DataType.Character)
          act = new System.Action(this.CharacterStartApi2);
        else if (this.convert_quest.questS.data_type == QuestSConverter.DataType.Harmony)
          act = new System.Action(this.HarmonyStartApi);
        this.StartCoroutine(this.StoryMovie(this.convert_quest.questS.ID, this.convert_quest.is_new, act));
      }
      else
        Debug.LogError((object) "!!! BUG !!!");
    }
    else
    {
      this.StartCoroutine(PopupCommon.Show(Consts.GetInstance().QUEST_0028_SORTIE_TITLE, Consts.GetInstance().QUEST_0028_COST_OVER_DESCRIPTION));
      Singleton<CommonRoot>.GetInstance().isLoading = false;
    }
  }

  public virtual void IbtnSortie()
  {
    if (this.IsPush)
      return;
    this.QuestStart();
  }

  private void StartBattle(GameCore.BattleInfo info)
  {
    this.indicator.SeEnable = false;
    NGBattleManager instance = Singleton<NGBattleManager>.GetInstance();
    instance.deleteSavedEnvironment();
    instance.startBattle(info);
  }

  [DebuggerHidden]
  private IEnumerator StoryMovie(int id, bool is_new, System.Action act)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0028Menu.\u003CStoryMovie\u003Ec__Iterator27F()
    {
      is_new = is_new,
      act = act,
      id = id,
      \u003C\u0024\u003Eis_new = is_new,
      \u003C\u0024\u003Eact = act,
      \u003C\u0024\u003Eid = id,
      \u003C\u003Ef__this = this
    };
  }

  private void StoryStartApi()
  {
    PlayerDeck playerDeck = this.playerDecks[this.selectDeck];
    WebAPI.BattleStoryStart(playerDeck.deck_number, playerDeck.deck_type_id, this.story_quest.quest_story_s.ID, this.friend != null ? this.friend.target_player_id : string.Empty, (Action<WebAPI.Response.UserError>) (error =>
    {
      Singleton<CommonRoot>.GetInstance().isLoading = false;
      WebAPI.DefaultUserErrorCallback(error);
      Singleton<NGSceneManager>.GetInstance().changeScene("mypage");
    })).RunOn<WebAPI.Response.BattleStoryStart>((MonoBehaviour) this, (Action<WebAPI.Response.BattleStoryStart>) (battle =>
    {
      if (battle == null)
        return;
      ((IEnumerable<PlayerHelper>) battle.helpers).ForEach<PlayerHelper, PlayerItem>((IEnumerable<PlayerItem>) battle.helper_player_gears, (Action<PlayerHelper, PlayerItem>) ((a, b) => a.leader_unit.primary_equipped_gear = b));
      int[] guestsId = GuestUnit.GetGuestsID(battle.quest_s_id);
      this.StartBattle(GameCore.BattleInfo.MakeBattleInfo(battle.battle_uuid, (CommonQuestType) battle.quest_type, battle.quest_s_id, battle.deck_type_id, battle.quest_loop_count, battle.deck_number, ((IEnumerable<PlayerHelper>) battle.helpers).FirstOrDefault<PlayerHelper>(), battle.enemy, ((IEnumerable<WebAPI.Response.BattleStoryStartEnemy_item>) battle.enemy_item).Select<WebAPI.Response.BattleStoryStartEnemy_item, Tuple<int, int, int, int>>((Func<WebAPI.Response.BattleStoryStartEnemy_item, Tuple<int, int, int, int>>) (x => Tuple.Create<int, int, int, int>(x.id, x.reward_type_id, x.reward_id, x.reward_quantity))).ToArray<Tuple<int, int, int, int>>(), battle.user_deck_units, battle.user_deck_gears, battle.user_deck_enemy, ((IEnumerable<WebAPI.Response.BattleStoryStartUser_deck_enemy_item>) battle.user_deck_enemy_item).Select<WebAPI.Response.BattleStoryStartUser_deck_enemy_item, Tuple<int, int, int, int>>((Func<WebAPI.Response.BattleStoryStartUser_deck_enemy_item, Tuple<int, int, int, int>>) (x => Tuple.Create<int, int, int, int>(x.id, x.reward_type_id, x.reward_id, x.reward_quantity))).ToArray<Tuple<int, int, int, int>>(), battle.panel, ((IEnumerable<WebAPI.Response.BattleStoryStartPanel_item>) battle.panel_item).Select<WebAPI.Response.BattleStoryStartPanel_item, Tuple<int, int, int, int>>((Func<WebAPI.Response.BattleStoryStartPanel_item, Tuple<int, int, int, int>>) (x => Tuple.Create<int, int, int, int>(x.id, x.reward_type_id, x.reward_id, x.reward_quantity))).ToArray<Tuple<int, int, int, int>>(), guestsId));
    }));
    Persist.lastsortie.Data.SaveLastSortie(this.story_quest.quest_story_s.ID, this.story_quest.quest_story_s.quest_m_QuestStoryM, this.story_quest.quest_story_s.quest_l_QuestStoryL);
    Persist.lastsortie.Flush();
  }

  [DebuggerHidden]
  private IEnumerator checkExtra()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0028Menu.\u003CcheckExtra\u003Ec__Iterator280()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void ExtraStartApi()
  {
    PlayerDeck playerDeck = this.playerDecks[this.selectDeck];
    if (this.extra_quest.quest_extra_s.wave != null)
      WebAPI.BattleWaveStart(playerDeck.deck_number, playerDeck.deck_type_id, this.extra_quest.quest_extra_s.ID, this.friend != null ? this.friend.target_player_id : string.Empty, (Action<WebAPI.Response.UserError>) (error =>
      {
        Singleton<CommonRoot>.GetInstance().isLoading = false;
        WebAPI.DefaultUserErrorCallback(error);
        Singleton<NGSceneManager>.GetInstance().changeScene("mypage");
      })).RunOn<WebAPI.Response.BattleWaveStart>((MonoBehaviour) this, (Action<WebAPI.Response.BattleWaveStart>) (battle =>
      {
        if (battle == null)
          return;
        ((IEnumerable<PlayerHelper>) battle.helpers).ForEach<PlayerHelper, PlayerItem>((IEnumerable<PlayerItem>) battle.helper_player_gears, (Action<PlayerHelper, PlayerItem>) ((a, b) => a.leader_unit.primary_equipped_gear = b));
        int[] guests = battle.wave_stage == null || battle.wave_stage.Length <= 0 ? GuestUnit.GetGuestsID(battle.quest_s_id) : GuestUnit.GetGuestsID(battle.wave_stage[0].stage_id);
        List<GameCore.BattleInfo.Wave> wave = new List<GameCore.BattleInfo.Wave>();
        foreach (BattleWaveStageInfo battleWaveStageInfo in battle.wave_stage)
          wave.Add(new GameCore.BattleInfo.Wave()
          {
            stage_id = battleWaveStageInfo.stage_id,
            enemies = battleWaveStageInfo.enemy,
            enemy_items = ((IEnumerable<BattleWaveStageInfoEnemy_item>) battleWaveStageInfo.enemy_item).Select<BattleWaveStageInfoEnemy_item, Tuple<int, int, int, int>>((Func<BattleWaveStageInfoEnemy_item, Tuple<int, int, int, int>>) (x => Tuple.Create<int, int, int, int>(x.id, x.reward_type_id, x.reward_id, x.reward_quantity))).ToArray<Tuple<int, int, int, int>>(),
            user_enemies = battleWaveStageInfo.user_deck_enemy,
            user_enemy_items = ((IEnumerable<BattleWaveStageInfoUser_deck_enemy_item>) battleWaveStageInfo.user_deck_enemy_item).Select<BattleWaveStageInfoUser_deck_enemy_item, Tuple<int, int, int, int>>((Func<BattleWaveStageInfoUser_deck_enemy_item, Tuple<int, int, int, int>>) (x => Tuple.Create<int, int, int, int>(x.id, x.reward_type_id, x.reward_id, x.reward_quantity))).ToArray<Tuple<int, int, int, int>>(),
            panels = battleWaveStageInfo.panel,
            panel_items = ((IEnumerable<BattleWaveStageInfoPanel_item>) battleWaveStageInfo.panel_item).Select<BattleWaveStageInfoPanel_item, Tuple<int, int, int, int>>((Func<BattleWaveStageInfoPanel_item, Tuple<int, int, int, int>>) (x => Tuple.Create<int, int, int, int>(x.id, x.reward_type_id, x.reward_id, x.reward_quantity))).ToArray<Tuple<int, int, int, int>>(),
            user_units = battleWaveStageInfo.user_deck_units,
            user_items = battleWaveStageInfo.user_deck_gears
          });
        this.StartBattle(GameCore.BattleInfo.MakeBattleInfo(battle.battle_uuid, (CommonQuestType) battle.quest_type, battle.quest_s_id, battle.deck_type_id, battle.quest_loop_count, battle.deck_number, ((IEnumerable<PlayerHelper>) battle.helpers).FirstOrDefault<PlayerHelper>(), guests, (IEnumerable<GameCore.BattleInfo.Wave>) wave));
      }));
    else
      WebAPI.BattleExtraStart(playerDeck.deck_number, playerDeck.deck_type_id, this.extra_quest.quest_extra_s.ID, this.friend != null ? this.friend.target_player_id : string.Empty, (Action<WebAPI.Response.UserError>) (error =>
      {
        Singleton<CommonRoot>.GetInstance().isLoading = false;
        WebAPI.DefaultUserErrorCallback(error);
        Singleton<NGSceneManager>.GetInstance().changeScene("mypage");
      })).RunOn<WebAPI.Response.BattleExtraStart>((MonoBehaviour) this, (Action<WebAPI.Response.BattleExtraStart>) (battle =>
      {
        if (battle == null)
          return;
        ((IEnumerable<PlayerHelper>) battle.helpers).ForEach<PlayerHelper, PlayerItem>((IEnumerable<PlayerItem>) battle.helper_player_gears, (Action<PlayerHelper, PlayerItem>) ((a, b) => a.leader_unit.primary_equipped_gear = b));
        int[] guestsId = GuestUnit.GetGuestsID(battle.quest_s_id);
        this.StartBattle(GameCore.BattleInfo.MakeBattleInfo(battle.battle_uuid, (CommonQuestType) battle.quest_type, battle.quest_s_id, battle.deck_type_id, battle.quest_loop_count, battle.deck_number, ((IEnumerable<PlayerHelper>) battle.helpers).FirstOrDefault<PlayerHelper>(), battle.enemy, ((IEnumerable<WebAPI.Response.BattleExtraStartEnemy_item>) battle.enemy_item).Select<WebAPI.Response.BattleExtraStartEnemy_item, Tuple<int, int, int, int>>((Func<WebAPI.Response.BattleExtraStartEnemy_item, Tuple<int, int, int, int>>) (x => Tuple.Create<int, int, int, int>(x.id, x.reward_type_id, x.reward_id, x.reward_quantity))).ToArray<Tuple<int, int, int, int>>(), battle.user_deck_units, battle.user_deck_gears, battle.user_deck_enemy, ((IEnumerable<WebAPI.Response.BattleExtraStartUser_deck_enemy_item>) battle.user_deck_enemy_item).Select<WebAPI.Response.BattleExtraStartUser_deck_enemy_item, Tuple<int, int, int, int>>((Func<WebAPI.Response.BattleExtraStartUser_deck_enemy_item, Tuple<int, int, int, int>>) (x => Tuple.Create<int, int, int, int>(x.id, x.reward_type_id, x.reward_id, x.reward_quantity))).ToArray<Tuple<int, int, int, int>>(), battle.panel, ((IEnumerable<WebAPI.Response.BattleExtraStartPanel_item>) battle.panel_item).Select<WebAPI.Response.BattleExtraStartPanel_item, Tuple<int, int, int, int>>((Func<WebAPI.Response.BattleExtraStartPanel_item, Tuple<int, int, int, int>>) (x => Tuple.Create<int, int, int, int>(x.id, x.reward_type_id, x.reward_id, x.reward_quantity))).ToArray<Tuple<int, int, int, int>>(), guestsId));
      }));
  }

  private void CharacterStartApi()
  {
    PlayerDeck playerDeck = this.playerDecks[this.selectDeck];
    WebAPI.BattleCharacterStart(playerDeck.deck_number, playerDeck.deck_type_id, this.char_quest.quest_character_s.ID, this.friend != null ? this.friend.target_player_id : string.Empty, (Action<WebAPI.Response.UserError>) (error =>
    {
      Singleton<CommonRoot>.GetInstance().isLoading = false;
      WebAPI.DefaultUserErrorCallback(error);
      Singleton<NGSceneManager>.GetInstance().changeScene("mypage");
    })).RunOn<WebAPI.Response.BattleCharacterStart>((MonoBehaviour) this, (Action<WebAPI.Response.BattleCharacterStart>) (battle =>
    {
      if (battle == null)
        return;
      ((IEnumerable<PlayerHelper>) battle.helpers).ForEach<PlayerHelper, PlayerItem>((IEnumerable<PlayerItem>) battle.helper_player_gears, (Action<PlayerHelper, PlayerItem>) ((a, b) => a.leader_unit.primary_equipped_gear = b));
      int[] guestsId = GuestUnit.GetGuestsID(battle.quest_s_id);
      this.StartBattle(GameCore.BattleInfo.MakeBattleInfo(battle.battle_uuid, (CommonQuestType) battle.quest_type, battle.quest_s_id, battle.deck_type_id, battle.quest_loop_count, battle.deck_number, ((IEnumerable<PlayerHelper>) battle.helpers).FirstOrDefault<PlayerHelper>(), battle.enemy, ((IEnumerable<WebAPI.Response.BattleCharacterStartEnemy_item>) battle.enemy_item).Select<WebAPI.Response.BattleCharacterStartEnemy_item, Tuple<int, int, int, int>>((Func<WebAPI.Response.BattleCharacterStartEnemy_item, Tuple<int, int, int, int>>) (x => Tuple.Create<int, int, int, int>(x.id, x.reward_type_id, x.reward_id, x.reward_quantity))).ToArray<Tuple<int, int, int, int>>(), battle.user_deck_units, battle.user_deck_gears, battle.user_deck_enemy, ((IEnumerable<WebAPI.Response.BattleCharacterStartUser_deck_enemy_item>) battle.user_deck_enemy_item).Select<WebAPI.Response.BattleCharacterStartUser_deck_enemy_item, Tuple<int, int, int, int>>((Func<WebAPI.Response.BattleCharacterStartUser_deck_enemy_item, Tuple<int, int, int, int>>) (x => Tuple.Create<int, int, int, int>(x.id, x.reward_type_id, x.reward_id, x.reward_quantity))).ToArray<Tuple<int, int, int, int>>(), battle.panel, ((IEnumerable<WebAPI.Response.BattleCharacterStartPanel_item>) battle.panel_item).Select<WebAPI.Response.BattleCharacterStartPanel_item, Tuple<int, int, int, int>>((Func<WebAPI.Response.BattleCharacterStartPanel_item, Tuple<int, int, int, int>>) (x => Tuple.Create<int, int, int, int>(x.id, x.reward_type_id, x.reward_id, x.reward_quantity))).ToArray<Tuple<int, int, int, int>>(), guestsId));
    }));
  }

  private void CharacterStartApi2()
  {
    PlayerDeck playerDeck = this.playerDecks[this.selectDeck];
    WebAPI.BattleCharacterStart(playerDeck.deck_number, playerDeck.deck_type_id, this.convert_quest.questS.ID, this.friend != null ? this.friend.target_player_id : string.Empty, (Action<WebAPI.Response.UserError>) (error =>
    {
      Singleton<CommonRoot>.GetInstance().isLoading = false;
      WebAPI.DefaultUserErrorCallback(error);
      Singleton<NGSceneManager>.GetInstance().changeScene("mypage");
    })).RunOn<WebAPI.Response.BattleCharacterStart>((MonoBehaviour) this, (Action<WebAPI.Response.BattleCharacterStart>) (battle =>
    {
      if (battle == null)
        return;
      ((IEnumerable<PlayerHelper>) battle.helpers).ForEach<PlayerHelper, PlayerItem>((IEnumerable<PlayerItem>) battle.helper_player_gears, (Action<PlayerHelper, PlayerItem>) ((a, b) => a.leader_unit.primary_equipped_gear = b));
      int[] guestsId = GuestUnit.GetGuestsID(battle.quest_s_id);
      this.StartBattle(GameCore.BattleInfo.MakeBattleInfo(battle.battle_uuid, (CommonQuestType) battle.quest_type, battle.quest_s_id, battle.deck_type_id, battle.quest_loop_count, battle.deck_number, ((IEnumerable<PlayerHelper>) battle.helpers).FirstOrDefault<PlayerHelper>(), battle.enemy, ((IEnumerable<WebAPI.Response.BattleCharacterStartEnemy_item>) battle.enemy_item).Select<WebAPI.Response.BattleCharacterStartEnemy_item, Tuple<int, int, int, int>>((Func<WebAPI.Response.BattleCharacterStartEnemy_item, Tuple<int, int, int, int>>) (x => Tuple.Create<int, int, int, int>(x.id, x.reward_type_id, x.reward_id, x.reward_quantity))).ToArray<Tuple<int, int, int, int>>(), battle.user_deck_units, battle.user_deck_gears, battle.user_deck_enemy, ((IEnumerable<WebAPI.Response.BattleCharacterStartUser_deck_enemy_item>) battle.user_deck_enemy_item).Select<WebAPI.Response.BattleCharacterStartUser_deck_enemy_item, Tuple<int, int, int, int>>((Func<WebAPI.Response.BattleCharacterStartUser_deck_enemy_item, Tuple<int, int, int, int>>) (x => Tuple.Create<int, int, int, int>(x.id, x.reward_type_id, x.reward_id, x.reward_quantity))).ToArray<Tuple<int, int, int, int>>(), battle.panel, ((IEnumerable<WebAPI.Response.BattleCharacterStartPanel_item>) battle.panel_item).Select<WebAPI.Response.BattleCharacterStartPanel_item, Tuple<int, int, int, int>>((Func<WebAPI.Response.BattleCharacterStartPanel_item, Tuple<int, int, int, int>>) (x => Tuple.Create<int, int, int, int>(x.id, x.reward_type_id, x.reward_id, x.reward_quantity))).ToArray<Tuple<int, int, int, int>>(), guestsId));
    }));
  }

  private void HarmonyStartApi()
  {
    PlayerDeck playerDeck = this.playerDecks[this.selectDeck];
    WebAPI.BattleHarmonyStart(playerDeck.deck_number, playerDeck.deck_type_id, this.convert_quest.questS.ID, this.friend != null ? this.friend.target_player_id : string.Empty, (Action<WebAPI.Response.UserError>) (error =>
    {
      Singleton<CommonRoot>.GetInstance().isLoading = false;
      WebAPI.DefaultUserErrorCallback(error);
      Singleton<NGSceneManager>.GetInstance().changeScene("mypage");
    })).RunOn<WebAPI.Response.BattleHarmonyStart>((MonoBehaviour) this, (Action<WebAPI.Response.BattleHarmonyStart>) (battle =>
    {
      if (battle == null)
        return;
      ((IEnumerable<PlayerHelper>) battle.helpers).ForEach<PlayerHelper, PlayerItem>((IEnumerable<PlayerItem>) battle.helper_player_gears, (Action<PlayerHelper, PlayerItem>) ((a, b) => a.leader_unit.primary_equipped_gear = b));
      int[] guestsId = GuestUnit.GetGuestsID(battle.quest_s_id);
      this.StartBattle(GameCore.BattleInfo.MakeBattleInfo(battle.battle_uuid, (CommonQuestType) battle.quest_type, battle.quest_s_id, battle.deck_type_id, battle.quest_loop_count, battle.deck_number, ((IEnumerable<PlayerHelper>) battle.helpers).FirstOrDefault<PlayerHelper>(), battle.enemy, ((IEnumerable<WebAPI.Response.BattleHarmonyStartEnemy_item>) battle.enemy_item).Select<WebAPI.Response.BattleHarmonyStartEnemy_item, Tuple<int, int, int, int>>((Func<WebAPI.Response.BattleHarmonyStartEnemy_item, Tuple<int, int, int, int>>) (x => Tuple.Create<int, int, int, int>(x.id, x.reward_type_id, x.reward_id, x.reward_quantity))).ToArray<Tuple<int, int, int, int>>(), battle.user_deck_units, battle.user_deck_gears, battle.user_deck_enemy, ((IEnumerable<WebAPI.Response.BattleHarmonyStartUser_deck_enemy_item>) battle.user_deck_enemy_item).Select<WebAPI.Response.BattleHarmonyStartUser_deck_enemy_item, Tuple<int, int, int, int>>((Func<WebAPI.Response.BattleHarmonyStartUser_deck_enemy_item, Tuple<int, int, int, int>>) (x => Tuple.Create<int, int, int, int>(x.id, x.reward_type_id, x.reward_id, x.reward_quantity))).ToArray<Tuple<int, int, int, int>>(), battle.panel, ((IEnumerable<WebAPI.Response.BattleHarmonyStartPanel_item>) battle.panel_item).Select<WebAPI.Response.BattleHarmonyStartPanel_item, Tuple<int, int, int, int>>((Func<WebAPI.Response.BattleHarmonyStartPanel_item, Tuple<int, int, int, int>>) (x => Tuple.Create<int, int, int, int>(x.id, x.reward_type_id, x.reward_id, x.reward_quantity))).ToArray<Tuple<int, int, int, int>>(), guestsId));
    }));
  }

  [DebuggerHidden]
  private IEnumerator SetSupplyIcons(List<PlayerItem> SupplyList)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0028Menu.\u003CSetSupplyIcons\u003Ec__Iterator281()
    {
      SupplyList = SupplyList,
      \u003C\u0024\u003ESupplyList = SupplyList,
      \u003C\u003Ef__this = this
    };
  }

  public void EndScene()
  {
    for (int index = 0; index < 5; ++index)
    {
      foreach (Component componentsInChild in this.dir_Items[index].GetComponentsInChildren<ItemIcon>())
        Object.Destroy((Object) componentsInChild.gameObject);
    }
    foreach (Quest0028Indicator quest0028Indicator in this.indicators.Values)
      quest0028Indicator.DestroyObject();
    this.indicators.Clear();
    Persist.deckOrganized.Data.number = this.deckIndexs[Mathf.Clamp(this.indicator.selected, 0, this.playerDecks.Length - 1)];
    Persist.deckOrganized.Flush();
  }

  [DebuggerHidden]
  private IEnumerator WaitScrollSe()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0028Menu.\u003CWaitScrollSe\u003Ec__Iterator282()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void BtnRepair()
  {
    if (this.IsPushAndSet())
      return;
    Bugu0052Scene.changeSceneRepair(true);
  }

  public void BtnOrganization()
  {
    if (this.IsPushAndSet())
      return;
    Unit0046Scene.changeScene(true);
  }

  public void BtnWeaponChange()
  {
    if (this.IsPushAndSet())
      return;
    Unit00468Scene.changeScene00412(true);
  }

  public void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();

  public static bool IsExtraLimitation(PlayerExtraQuestS extraQuest)
  {
    return ((IEnumerable<QuestExtraLimitation>) MasterData.QuestExtraLimitationList).Any<QuestExtraLimitation>((Func<QuestExtraLimitation, bool>) (n => n.quest_s_id_QuestExtraS == extraQuest.quest_extra_s.ID));
  }

  public static bool IsStoryLimitation(PlayerStoryQuestS storyQuest)
  {
    return ((IEnumerable<QuestStoryLimitation>) MasterData.QuestStoryLimitationList).Any<QuestStoryLimitation>((Func<QuestStoryLimitation, bool>) (n => n.quest_s_id_QuestStoryS == storyQuest.quest_story_s.ID));
  }

  public static bool IsCharaLimitation(PlayerCharacterQuestS charaQuest)
  {
    return ((IEnumerable<QuestCharacterLimitation>) MasterData.QuestCharacterLimitationList).Any<QuestCharacterLimitation>((Func<QuestCharacterLimitation, bool>) (n => n.quest_s_id_QuestCharacterS == charaQuest.quest_character_s.ID));
  }

  public static bool IsConvertLimitation(PlayerQuestSConverter convertQuest)
  {
    if (convertQuest.questS.data_type == QuestSConverter.DataType.Character)
      return ((IEnumerable<QuestCharacterLimitation>) MasterData.QuestCharacterLimitationList).Any<QuestCharacterLimitation>((Func<QuestCharacterLimitation, bool>) (n => n.quest_s_id_QuestCharacterS == convertQuest.questS.ID));
    return convertQuest.questS.data_type == QuestSConverter.DataType.Harmony && ((IEnumerable<QuestHarmonyLimitation>) MasterData.QuestHarmonyLimitationList).Any<QuestHarmonyLimitation>((Func<QuestHarmonyLimitation, bool>) (n => n.quest_s_id_QuestHarmonyS == convertQuest.questS.ID));
  }

  public static bool GetFriendPositionEnable(int stageID)
  {
    BattleStageGuest[] array = ((IEnumerable<BattleStageGuest>) MasterData.BattleStageGuestList).Where<BattleStageGuest>((Func<BattleStageGuest, bool>) (x => x.stage_BattleStage == stageID)).ToArray<BattleStageGuest>();
    return MasterData.BattleStagePlayer.Any<KeyValuePair<int, BattleStagePlayer>>((Func<KeyValuePair<int, BattleStagePlayer>, bool>) (x => x.Value.stage_BattleStage == stageID && x.Value.deck_position == Consts.GetInstance().DECK_POSITION_FRIEND)) && !((IEnumerable<BattleStageGuest>) array).Any<BattleStageGuest>((Func<BattleStageGuest, bool>) (x => x.deck_position == Consts.GetInstance().DECK_POSITION_FRIEND));
  }

  private enum BtnType
  {
    BATTLE,
    REPAIR,
    EDIT,
  }

  protected class LimitedQuestData
  {
    private PlayerDeck[] deck;

    public PlayerDeck[] Deck => this.deck;

    public void SetInfo(PlayerDeck[] tmp) => this.deck = tmp;
  }
}
