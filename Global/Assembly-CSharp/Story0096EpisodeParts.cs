// Decompiled with JetBrains decompiler
// Type: Story0096EpisodeParts
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class Story0096EpisodeParts : MonoBehaviour
{
  [SerializeField]
  private UIButton IbtnEpisode;
  [SerializeField]
  private UILabel TxtEpisodetitle;
  [SerializeField]
  private List<UILabel> TxtEpisodeNumbers;
  [SerializeField]
  private GameObject SlcClear;
  [SerializeField]
  private GameObject SlcNew;

  public void setData(
    PlayerCharacterQuestS quest,
    StoryPlaybackCharacterDetail playbackStory,
    NGMenuBase menu)
  {
    foreach (UILabel txtEpisodeNumber in this.TxtEpisodeNumbers)
      txtEpisodeNumber.SetText(quest.quest_character_s.priority.ToString());
    EventDelegate.Set(this.IbtnEpisode.onClick, (EventDelegate.Callback) (() =>
    {
      if (menu.IsPushAndSet())
        return;
      Story0093Scene.changeScene009_3(true, playbackStory.script.ID);
    }));
    this.TxtEpisodetitle.SetTextLocalize(playbackStory.name);
    this.SlcClear.SetActive(false);
    this.SlcNew.SetActive(false);
  }

  public void setData(
    PlayerHarmonyQuestS quest,
    StoryPlaybackHarmonyDetail playbackStory,
    NGMenuBase menu)
  {
    foreach (UILabel txtEpisodeNumber in this.TxtEpisodeNumbers)
      txtEpisodeNumber.SetText(quest.quest_harmony_s.priority.ToString());
    EventDelegate.Set(this.IbtnEpisode.onClick, (EventDelegate.Callback) (() =>
    {
      if (menu.IsPushAndSet())
        return;
      Story0093Scene.changeScene009_3(true, playbackStory.script.ID);
    }));
    this.TxtEpisodetitle.SetTextLocalize(playbackStory.name);
    this.SlcClear.SetActive(false);
    this.SlcNew.SetActive(false);
  }
}
