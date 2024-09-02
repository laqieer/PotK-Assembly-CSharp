// Decompiled with JetBrains decompiler
// Type: Story00922ScrollParts
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
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
  private StoryPlaybackStoryDetail story;
  private NGMenuBase menu;

  public void onClickEpisodeButton()
  {
    if (this.menu.IsPushAndSet())
      return;
    Story0093Scene.changeScene009_3(true, this.story.script_id);
  }

  public void Init(Story00922Menu menu, StoryPlaybackStoryDetail story)
  {
    this.menu = (NGMenuBase) menu;
    this.story = story;
    EventDelegate.Add(this.IbtnChapter.onClick, new EventDelegate.Callback(this.onClickEpisodeButton));
    ((Component) this.SlcNew).gameObject.SetActive(false);
    ((Component) this.SlcClear).gameObject.SetActive(false);
    this.TxtChapter.SetTextLocalize(story.name);
  }
}
