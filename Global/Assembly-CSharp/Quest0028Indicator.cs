// Decompiled with JetBrains decompiler
// Type: Quest0028Indicator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
  private List<string> noteUnit;
  [SerializeField]
  private UILabel txtNote;
  [HideInInspector]
  public UIButton friendSelect;
  private PlayerHelper friend;
  private PlayerUnit[] DeckUnitData;
  private PlayerDeck[] regulationDeck;
  private bool isLimitation;
  private bool isUserDeckStage;

  [DebuggerHidden]
  public IEnumerator InitPlayerDeck(
    PlayerDeck playerDeck,
    PlayerHelper friend,
    PlayerExtraQuestS extraQuest,
    PlayerStoryQuestS storyQuest,
    PlayerDeck[] regulationDeck)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0028Indicator.\u003CInitPlayerDeck\u003Ec__Iterator22B()
    {
      storyQuest = storyQuest,
      extraQuest = extraQuest,
      regulationDeck = regulationDeck,
      playerDeck = playerDeck,
      friend = friend,
      \u003C\u0024\u003EstoryQuest = storyQuest,
      \u003C\u0024\u003EextraQuest = extraQuest,
      \u003C\u0024\u003EregulationDeck = regulationDeck,
      \u003C\u0024\u003EplayerDeck = playerDeck,
      \u003C\u0024\u003Efriend = friend,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator LoadUnitPrefab(int count, PlayerUnit unit, bool isFriend)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0028Indicator.\u003CLoadUnitPrefab\u003Ec__Iterator22C()
    {
      count = count,
      unit = unit,
      isFriend = isFriend,
      \u003C\u0024\u003Ecount = count,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u0024\u003EisFriend = isFriend,
      \u003C\u003Ef__this = this
    };
  }

  private void ChangeDetailScene(PlayerUnit unit, bool isFriend)
  {
    this.DestroyObject();
    if (!isFriend)
      Unit0042Scene.changeScene(true, unit, this.DeckUnitData);
    else
      Unit0042Scene.changeSceneFriendUnit(true, this.friend.target_player_id);
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
    bool flag = unit == (PlayerUnit) null || ((IEnumerable<PlayerDeck>) this.regulationDeck).Any<PlayerDeck>((Func<PlayerDeck, bool>) (d => ((IEnumerable<int?>) d.player_unit_ids).Any<int?>((Func<int?, bool>) (u => u.HasValue && u.Value == unit.id))));
    if (count != 5 && !flag)
    {
      if (unitScript.BreakWeapon)
        unitScript.SetRegulation(UnitIcon.Regulation.WithBroken);
      else
        unitScript.SetRegulation(UnitIcon.Regulation.Default);
    }
    else
      unitScript.SetRegulation(UnitIcon.Regulation.None);
  }

  private enum noteIndex
  {
    NOT_RENTAL,
    NOT_FRIEND,
    CAN_NOT_RENTAL,
  }
}
