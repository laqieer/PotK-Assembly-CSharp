﻿// Decompiled with JetBrains decompiler
// Type: Story00922Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using SM;
using System.Collections;
using UnityEngine;

public class Story00922Scene : NGSceneBase
{
  public Story00922Menu menu;
  public UILabel TxtTitle;
  [SerializeField]
  private NGxScroll ScrollContainer;

  public IEnumerator onStartSceneAsync(PlayerStoryQuestS quest, int XL)
  {
    this.TxtTitle.SetTextLocalize(quest.quest_story_s.quest_m.short_name + " " + quest.quest_story_s.quest_m.name);
    PlayerStoryQuestS[] quests = SMManager.Get<PlayerStoryQuestS[]>().S(quest.quest_story_s.quest_xl.ID, quest.quest_story_s.quest_l.ID, quest.quest_story_s.quest_m.ID);
    this.ScrollContainer.Clear();
    IEnumerator e = this.menu.InitEpisodeButton(quests, quest, XL);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    this.ScrollContainer.ResolvePosition();
  }
}
