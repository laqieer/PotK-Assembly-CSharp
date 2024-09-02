// Decompiled with JetBrains decompiler
// Type: Story0092ScrollParts
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using UnityEngine;

#nullable disable
public class Story0092ScrollParts : MonoBehaviour
{
  [SerializeField]
  private UISprite IbtnChapterSprite;
  [SerializeField]
  private UIButton IbtnChapter;
  [SerializeField]
  private UISprite SlcNew;
  [SerializeField]
  private UILabel TxtChapter;
  private PlayerStoryQuestS quest;
  private NGMenuBase menu;

  public void onClickChapterButton()
  {
    if (this.menu.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().destroyLoadedScenes();
    Singleton<NGSceneManager>.GetInstance().changeScene("story009_2_2", false, (object) this.quest);
  }

  public void Init(Story0092Menu menu, PlayerStoryQuestS quest, PlayerStoryQuestS backQuest)
  {
    this.quest = quest;
    this.menu = (NGMenuBase) menu;
    EventDelegate.Add(this.IbtnChapter.onClick, new EventDelegate.Callback(this.onClickChapterButton));
    ((Component) this.SlcNew).gameObject.SetActive(false);
    this.TxtChapter.SetTextLocalize(quest.quest_story_s.quest_l.short_name + " " + quest.quest_story_s.quest_m.short_name + " " + quest.quest_story_s.quest_m.name);
  }
}
