﻿// Decompiled with JetBrains decompiler
// Type: Story00922Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Story00922Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  private NGxScroll ScrollContainer;
  private PlayerStoryQuestS quest;

  public virtual void Foreground()
  {
  }

  public virtual void VScrollBar()
  {
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("story009_2", false, (object) this.quest);
  }

  [DebuggerHidden]
  public IEnumerator InitEpisodeButton(PlayerStoryQuestS[] quests, PlayerStoryQuestS quest)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story00922Menu.\u003CInitEpisodeButton\u003Ec__Iterator46F()
    {
      quest = quest,
      quests = quests,
      \u003C\u0024\u003Equest = quest,
      \u003C\u0024\u003Equests = quests,
      \u003C\u003Ef__this = this
    };
  }
}
