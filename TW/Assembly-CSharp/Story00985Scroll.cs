// Decompiled with JetBrains decompiler
// Type: Story00985Scroll
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using UnityEngine;

#nullable disable
public class Story00985Scroll : MonoBehaviour
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
  private int script_id;
  private NGMenuBase menu;

  public void onClickEpisodeButton()
  {
    if (this.menu.IsPushAndSet())
      return;
    Story0093Scene.changeScene009_3(true, this.script_id);
  }

  public void Init(StoryPlaybackExtraDetail quest, int script_id, NGMenuBase menu)
  {
    this.script_id = script_id;
    this.menu = menu;
    EventDelegate.Add(this.IbtnChapter.onClick, new EventDelegate.Callback(this.onClickEpisodeButton));
    this.TxtChapter.SetTextLocalize(quest.name);
  }
}
