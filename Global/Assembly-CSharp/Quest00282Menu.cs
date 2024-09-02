// Decompiled with JetBrains decompiler
// Type: Quest00282Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Quest00282Menu : BackButtonMenuBase
{
  public NGxScroll scroll;
  private PlayerFriend[] friends;

  [DebuggerHidden]
  public IEnumerator InitPlayerDecks(
    PlayerHelper[] helpers,
    PlayerStoryQuestS story_quest,
    PlayerExtraQuestS extra_quest,
    PlayerCharacterQuestS char_quest,
    PlayerQuestSConverter harmony_quest)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00282Menu.\u003CInitPlayerDecks\u003Ec__Iterator23E()
    {
      helpers = helpers,
      story_quest = story_quest,
      extra_quest = extra_quest,
      char_quest = char_quest,
      harmony_quest = harmony_quest,
      \u003C\u0024\u003Ehelpers = helpers,
      \u003C\u0024\u003Estory_quest = story_quest,
      \u003C\u0024\u003Eextra_quest = extra_quest,
      \u003C\u0024\u003Echar_quest = char_quest,
      \u003C\u0024\u003Eharmony_quest = harmony_quest,
      \u003C\u003Ef__this = this
    };
  }

  private bool isFavorite(PlayerHelper helper)
  {
    foreach (PlayerFriend friend in this.friends)
    {
      if (friend.target_player_id == helper.target_player_id && friend.is_favorite)
        return true;
    }
    return false;
  }

  public virtual void Foreground()
  {
  }

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void IbtnDecide()
  {
  }

  public virtual void VScrollBar()
  {
  }

  [DebuggerHidden]
  public IEnumerator onEndScene()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Quest00282Menu.\u003ConEndScene\u003Ec__Iterator23F sceneCIterator23F = new Quest00282Menu.\u003ConEndScene\u003Ec__Iterator23F();
    return (IEnumerator) sceneCIterator23F;
  }
}
