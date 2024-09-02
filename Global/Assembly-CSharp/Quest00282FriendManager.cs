// Decompiled with JetBrains decompiler
// Type: Quest00282FriendManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest00282FriendManager : MonoBehaviour
{
  [SerializeField]
  protected UILabel txt_Listdescription01;
  [SerializeField]
  protected UILabel txt_Listdescription02;
  [SerializeField]
  protected UILabel txt_Listdescription04;
  [SerializeField]
  protected GameObject Friend;
  [SerializeField]
  protected GameObject Master;
  [SerializeField]
  protected Transform linkFriend;
  [SerializeField]
  protected GameObject FriendList;
  [SerializeField]
  protected GameObject FriendNoneList;
  [SerializeField]
  private UI2DSprite Emblem;
  private PlayerHelper friend;
  private PlayerStoryQuestS story_quest;
  private PlayerExtraQuestS extra_quest;
  private PlayerCharacterQuestS char_quest;
  private PlayerQuestSConverter harmonyQuest;
  private bool favorite;

  [DebuggerHidden]
  public IEnumerator InitFriendList(
    PlayerHelper friend,
    PlayerStoryQuestS story_quest,
    PlayerExtraQuestS extra_quest,
    PlayerCharacterQuestS char_quest,
    PlayerQuestSConverter harmony_quest,
    DateTime now)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00282FriendManager.\u003CInitFriendList\u003Ec__Iterator23C()
    {
      friend = friend,
      story_quest = story_quest,
      extra_quest = extra_quest,
      char_quest = char_quest,
      harmony_quest = harmony_quest,
      now = now,
      \u003C\u0024\u003Efriend = friend,
      \u003C\u0024\u003Estory_quest = story_quest,
      \u003C\u0024\u003Eextra_quest = extra_quest,
      \u003C\u0024\u003Echar_quest = char_quest,
      \u003C\u0024\u003Eharmony_quest = harmony_quest,
      \u003C\u0024\u003Enow = now,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator ChangeFriendIcon(PlayerHelper friend)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00282FriendManager.\u003CChangeFriendIcon\u003Ec__Iterator23D()
    {
      friend = friend,
      \u003C\u0024\u003Efriend = friend,
      \u003C\u003Ef__this = this
    };
  }

  public void FriendDetailScene()
  {
    Unit0042Scene.changeSceneFriendUnit(true, this.friend.target_player_id);
  }

  public void FriendNone(
    PlayerStoryQuestS story_quest,
    PlayerExtraQuestS extra_quest,
    PlayerCharacterQuestS char_quest,
    PlayerQuestSConverter harmony_quest)
  {
    this.story_quest = story_quest;
    this.extra_quest = extra_quest;
    this.char_quest = char_quest;
    this.harmonyQuest = harmony_quest;
    this.friend = (PlayerHelper) null;
    this.FriendList.SetActive(false);
    this.FriendNoneList.SetActive(true);
  }

  public void FriendSelect()
  {
    if (this.story_quest != null)
      Quest0028Scene.changeScene(true, this.friend, this.story_quest);
    else if (this.extra_quest != null)
      Quest0028Scene.changeScene(true, this.friend, this.extra_quest);
    else if (this.char_quest != null)
    {
      Quest0028Scene.changeScene(true, this.friend, this.char_quest);
    }
    else
    {
      if (this.harmonyQuest == null)
        return;
      Quest0028Scene.changeScene(true, this.friend, this.harmonyQuest);
    }
  }
}
