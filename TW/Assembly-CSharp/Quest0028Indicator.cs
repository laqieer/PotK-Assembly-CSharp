// Decompiled with JetBrains decompiler
// Type: Quest0028Indicator
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
public class Quest0028Indicator : MonoBehaviour
{
  private const float LINK_WIDTH = 92f;
  private const float LINK_DEFWIDTH = 114f;
  private const float scale = 0.807017565f;
  private const int FRIEND_NUM = 5;
  private const int DECK_UNIT_MAX = 5;
  [SerializeField]
  private GameObject[] slcTextGuests;
  [SerializeField]
  protected UILabel TxtFriendskillDescription;
  [SerializeField]
  protected UILabel TxtFriendskillName;
  [SerializeField]
  protected UILabel TxtLeaderskillDescription;
  [SerializeField]
  protected UILabel TxtLeaderskillName;
  [SerializeField]
  protected GameObject[] linkCharacters;
  [SerializeField]
  protected UISprite slc_NotFriend_Skill;
  [SerializeField]
  private UILabel txtNote;
  [HideInInspector]
  public UIButton friendSelect;
  private PlayerHelper friend;
  private GameObject normalPrefab;
  private PlayerUnit[] DeckUnitData;
  private PlayerDeck[] regulationDeck;
  private bool isLimitation;
  private bool isUserDeckStage;
  private UnitGender genderRestriction;

  public PlayerUnit[] deckUnitData => this.DeckUnitData;

  [DebuggerHidden]
  public IEnumerator InitPlayerDeck(
    PlayerDeck playerDeck,
    PlayerHelper friend,
    PlayerExtraQuestS extraQuest,
    PlayerStoryQuestS storyQuest,
    PlayerCharacterQuestS charQuest,
    PlayerQuestSConverter convertQuest,
    PlayerDeck[] regulationDeck,
    QuestScoreBonusTimetable[] tables,
    UnitBonus[] unitBonus,
    BattleStageGuest[] guest,
    int battleStageID)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0028Indicator.\u003CInitPlayerDeck\u003Ec__Iterator2B3()
    {
      storyQuest = storyQuest,
      extraQuest = extraQuest,
      charQuest = charQuest,
      convertQuest = convertQuest,
      regulationDeck = regulationDeck,
      friend = friend,
      battleStageID = battleStageID,
      playerDeck = playerDeck,
      guest = guest,
      tables = tables,
      unitBonus = unitBonus,
      \u003C\u0024\u003EstoryQuest = storyQuest,
      \u003C\u0024\u003EextraQuest = extraQuest,
      \u003C\u0024\u003EcharQuest = charQuest,
      \u003C\u0024\u003EconvertQuest = convertQuest,
      \u003C\u0024\u003EregulationDeck = regulationDeck,
      \u003C\u0024\u003Efriend = friend,
      \u003C\u0024\u003EbattleStageID = battleStageID,
      \u003C\u0024\u003EplayerDeck = playerDeck,
      \u003C\u0024\u003Eguest = guest,
      \u003C\u0024\u003Etables = tables,
      \u003C\u0024\u003EunitBonus = unitBonus,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator LoadUnitPrefab(
    int index,
    PlayerUnit unit,
    bool isFriend,
    QuestScoreBonusTimetable[] tables,
    UnitBonus[] unitBonus,
    bool sortieNot = false)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0028Indicator.\u003CLoadUnitPrefab\u003Ec__Iterator2B4()
    {
      index = index,
      unit = unit,
      sortieNot = sortieNot,
      isFriend = isFriend,
      tables = tables,
      unitBonus = unitBonus,
      \u003C\u0024\u003Eindex = index,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u0024\u003EsortieNot = sortieNot,
      \u003C\u0024\u003EisFriend = isFriend,
      \u003C\u0024\u003Etables = tables,
      \u003C\u0024\u003EunitBonus = unitBonus,
      \u003C\u003Ef__this = this
    };
  }

  private void ChangeDetailScene(PlayerUnit unit, bool isFriend, int index)
  {
    if (!isFriend && !unit.is_gesut)
      Unit0042Scene.changeScene(true, unit, ((IEnumerable<PlayerUnit>) this.DeckUnitData).Where<PlayerUnit>((Func<PlayerUnit, bool>) (x => x != (PlayerUnit) null && !x.is_gesut)).ToArray<PlayerUnit>());
    else if (isFriend)
      Unit0042Scene.changeSceneFriendUnit(true, this.friend.target_player_id);
    else if (index == Consts.GetInstance().DECK_POSITION_FRIEND - 1)
      Unit0042Scene.changeSceneGuestUnit(true, unit, new PlayerUnit[1]
      {
        unit
      });
    else
      Unit0042Scene.changeSceneGuestUnit(true, unit, ((IEnumerable<PlayerUnit>) this.DeckUnitData).Where<PlayerUnit>((Func<PlayerUnit, bool>) (x => x != (PlayerUnit) null && x.is_gesut)).ToArray<PlayerUnit>());
    this.DestroyObject();
  }

  public void DestroyObject()
  {
    foreach (GameObject linkCharacter in this.linkCharacters)
    {
      UnitIcon componentInChildren = linkCharacter.GetComponentInChildren<UnitIcon>();
      if (Object.op_Inequality((Object) componentInChildren, (Object) null))
        Object.Destroy((Object) ((Component) componentInChildren).gameObject);
    }
  }

  private void SetRegulation(PlayerUnit unit, UnitIcon unitScript, int count)
  {
    bool flag1 = true;
    bool flag2 = true;
    if (unit != (PlayerUnit) null && !unit.is_gesut)
    {
      if (this.regulationDeck != null)
        flag1 = ((IEnumerable<PlayerDeck>) this.regulationDeck).Any<PlayerDeck>((Func<PlayerDeck, bool>) (d => ((IEnumerable<int?>) d.player_unit_ids).Any<int?>((Func<int?, bool>) (u => u.HasValue && u.Value == unit.id))));
      if (this.genderRestriction != UnitGender.none)
        flag2 = unit.unit.character.gender == this.genderRestriction;
    }
    if (count != 5 && (!flag1 || !flag2))
    {
      if (unitScript.BreakWeapon)
        unitScript.SetRegulation(UnitIcon.Regulation.WithBroken);
      else
        unitScript.SetRegulation(UnitIcon.Regulation.Default);
    }
    else
      unitScript.SetRegulation(UnitIcon.Regulation.None);
  }
}
