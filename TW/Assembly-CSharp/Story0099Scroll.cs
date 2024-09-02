// Decompiled with JetBrains decompiler
// Type: Story0099Scroll
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using UnityEngine;

#nullable disable
public class Story0099Scroll : MonoBehaviour
{
  public Story0099Scroll.MovieType movieType;
  public Story0099Menu menu;
  [SerializeField]
  private UILabel TxtChapter;
  private int questID;

  public void IbtnMoviePlay()
  {
    switch (this.movieType)
    {
      case Story0099Scroll.MovieType.OPENING:
        this.StartCoroutine(this.menu.PlayOpeningMovie());
        break;
      case Story0099Scroll.MovieType.TUTORIAL1:
        this.StartCoroutine(this.menu.PlayTutorialMovie1());
        break;
      case Story0099Scroll.MovieType.TUTORIAL2:
        this.StartCoroutine(this.menu.PlayTutorialMovie2());
        break;
      case Story0099Scroll.MovieType.STORY:
        this.StartCoroutine(this.menu.PlayStoryQuestMovie(this.questID));
        break;
    }
  }

  public void Init(
    Story0099Menu menu,
    string title,
    Story0099Scroll.MovieType type,
    PlayerStoryQuestS quest = null)
  {
    this.menu = menu;
    if (quest != null)
      this.questID = quest.quest_story_s.ID;
    this.movieType = type;
    this.TxtChapter.SetTextLocalize(title);
  }

  public enum MovieType
  {
    OPENING,
    TUTORIAL1,
    TUTORIAL2,
    STORY,
  }
}
