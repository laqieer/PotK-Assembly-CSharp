// Decompiled with JetBrains decompiler
// Type: Story0090Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using UnityEngine;

#nullable disable
public class Story0090Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  private UIButton ibtnMainStory;
  [SerializeField]
  private UIButton ibtnCharaStory;
  [SerializeField]
  private UIButton ibtnEventStory;
  [SerializeField]
  private UIButton ibtnCombiStory;
  [SerializeField]
  private UIScrollView scroll;
  [SerializeField]
  private UIGrid grid;

  public virtual void Foreground()
  {
  }

  public virtual void VScrollBar()
  {
  }

  public void Init()
  {
    ((Component) ((Component) this.ibtnCombiStory).transform.parent).gameObject.SetActive(Player.Current.IsCombiQuest());
    this.grid.Reposition();
    if (!Player.Current.IsCombiQuest())
      return;
    this.scroll.ResetPosition();
    this.scroll.UpdateScrollbars(true);
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("story001_9_1_FAQ");
  }

  public virtual void IbtnMainstory()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("story009_1");
  }

  public void IbtnCharacterstory()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("story009_5", false, (object) true);
  }

  public void IbtnEventstory()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("story009_8", false, (object) true);
  }

  public void IbtnMovieLibrary()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("story009_9");
  }

  public void IbtnCombi()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("story009_10");
  }
}
