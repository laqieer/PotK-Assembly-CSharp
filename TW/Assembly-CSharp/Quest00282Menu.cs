// Decompiled with JetBrains decompiler
// Type: Quest00282Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Quest00282Menu : BackButtonMenuBase
{
  public NGxScroll scroll;

  [DebuggerHidden]
  public IEnumerator InitPlayerDecks(
    PlayerHelper[] helpers,
    PlayerStoryQuestS story_quest,
    PlayerExtraQuestS extra_quest,
    PlayerCharacterQuestS char_quest,
    PlayerQuestSConverter harmony_quest)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00282Menu.\u003CInitPlayerDecks\u003Ec__Iterator2C7()
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

  private bool existGuildMember(Dictionary<PlayerHelper, int> dic)
  {
    return !dic.Where<KeyValuePair<PlayerHelper, int>>((Func<KeyValuePair<PlayerHelper, int>, bool>) (x => x.Key.is_guild_member)).FirstOrDefault<KeyValuePair<PlayerHelper, int>>().Equals((object) new KeyValuePair<PlayerHelper, int>());
  }

  public virtual void Foreground() => Debug.Log((object) "click default event Foreground");

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void IbtnDecide() => Debug.Log((object) "click default event IbtnDecide");

  public virtual void VScrollBar() => Debug.Log((object) "click default event VScrollBar");

  [DebuggerHidden]
  public IEnumerator onEndScene()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Quest00282Menu.\u003ConEndScene\u003Ec__Iterator2C8 sceneCIterator2C8 = new Quest00282Menu.\u003ConEndScene\u003Ec__Iterator2C8();
    return (IEnumerator) sceneCIterator2C8;
  }
}
