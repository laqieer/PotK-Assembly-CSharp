// Decompiled with JetBrains decompiler
// Type: Story0091ScrollParts
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using UnityEngine;

#nullable disable
public class Story0091ScrollParts : MonoBehaviour
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

  public void onClickPartButton()
  {
    if (this.menu.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("story009_2", false, (object) this.quest);
  }

  public void Init(PlayerStoryQuestS quest, NGMenuBase menu)
  {
    this.quest = quest;
    this.menu = menu;
    EventDelegate.Add(this.IbtnChapter.onClick, new EventDelegate.Callback(this.onClickPartButton));
    ((Component) this.SlcNew).gameObject.SetActive(false);
    this.TxtChapter.SetTextLocalize(quest.quest_story_s.quest_l.short_name + "　" + quest.quest_story_s.quest_l.name);
  }
}
