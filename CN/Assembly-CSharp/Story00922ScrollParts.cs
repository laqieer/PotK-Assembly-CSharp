// Decompiled with JetBrains decompiler
// Type: Story00922ScrollParts
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
