﻿// Decompiled with JetBrains decompiler
// Type: Story0092Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Story0092Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  private NGxScroll ScrollContainer;
  private PlayerStoryQuestS backQuest;

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
    Singleton<NGSceneManager>.GetInstance().changeScene("story009_1");
  }

  [DebuggerHidden]
  public IEnumerator InitChapterButton(PlayerStoryQuestS quest, PlayerStoryQuestS[] quests)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story0092Menu.\u003CInitChapterButton\u003Ec__Iterator510()
    {
      quests = quests,
      quest = quest,
      \u003C\u0024\u003Equests = quests,
      \u003C\u0024\u003Equest = quest,
      \u003C\u003Ef__this = this
    };
  }
}
