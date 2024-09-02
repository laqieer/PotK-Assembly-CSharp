// Decompiled with JetBrains decompiler
// Type: Story00922ScrollParts
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using UnityEngine;

#nullable disable
public class Story00922ScrollParts : MonoBehaviour
{
  [SerializeField]
  private UISprite IbtnChapterSprite;
  [SerializeField]
  private UIButton IbtnChapter;
  [SerializeField]
  private UISprite SlcNew;
  [SerializeField]
  private UISprite SlcClear;
  [SerializeField]
  private UILabel TxtChapter;
  private PlayerStoryQuestS quest;
  private NGMenuBase menu;

  public void onClickEpisodeButton()
  {
    if (this.menu.IsPushAndSet())
      return;
    Story0093Scene.changeScene009_3(true, this.quest.quest_story_s.StoryDetails()[0].script_ScriptScript);
  }

  public void Init(Story00922Menu menu, PlayerStoryQuestS quest)
  {
    this.menu = (NGMenuBase) menu;
    this.quest = quest;
    EventDelegate.Add(this.IbtnChapter.onClick, new EventDelegate.Callback(this.onClickEpisodeButton));
    ((Component) this.SlcNew).gameObject.SetActive(false);
    ((Component) this.SlcClear).gameObject.SetActive(false);
    this.TxtChapter.SetTextLocalize("ＳＴＡＧＥ　" + (object) quest.quest_story_s.priority);
  }
}
