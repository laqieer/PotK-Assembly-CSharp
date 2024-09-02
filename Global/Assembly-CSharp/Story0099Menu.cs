// Decompiled with JetBrains decompiler
// Type: Story0099Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Story0099Menu : BackButtonMenuBase
{
  [SerializeField]
  private NGxScroll ScrollContainer;
  [SerializeField]
  private MovieLibraryPlayer movieObj;

  public virtual void Foreground()
  {
  }

  public virtual void VScrollBar()
  {
  }

  public bool onStartMovie()
  {
    if (this.IsPushAndSet())
      return false;
    Singleton<CommonRoot>.GetInstance().isTouchBlock = true;
    this.movieObj.endAction = (System.Action) (() =>
    {
      Singleton<CommonRoot>.GetInstance().isTouchBlock = false;
      this.IsPush = false;
    });
    return true;
  }

  [DebuggerHidden]
  public IEnumerator PlayOpeningMovie()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story0099Menu.\u003CPlayOpeningMovie\u003Ec__Iterator498()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator PlayTutorialMovie1()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story0099Menu.\u003CPlayTutorialMovie1\u003Ec__Iterator499()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator PlayTutorialMovie2()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story0099Menu.\u003CPlayTutorialMovie2\u003Ec__Iterator49A()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator PlayStoryQuestMovie(int id)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story0099Menu.\u003CPlayStoryQuestMovie\u003Ec__Iterator49B()
    {
      id = id,
      \u003C\u0024\u003Eid = id,
      \u003C\u003Ef__this = this
    };
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("story009_0");
  }

  [DebuggerHidden]
  public IEnumerator InitScene()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story0099Menu.\u003CInitScene\u003Ec__Iterator49C()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void ScrollInit(
    Story0099Menu menu,
    string title,
    Story0099Scroll.MovieType type,
    GameObject prefab)
  {
    GameObject gameObject = Object.Instantiate<GameObject>(prefab);
    gameObject.GetComponent<Story0099Scroll>().Init(menu, title, type);
    this.ScrollContainer.Add(gameObject);
  }

  public void ScrollInit(
    Story0099Menu menu,
    PlayerStoryQuestS quest,
    string title,
    GameObject prefab)
  {
    GameObject gameObject = Object.Instantiate<GameObject>(prefab);
    gameObject.GetComponent<Story0099Scroll>().Init(menu, title, Story0099Scroll.MovieType.STORY, quest);
    this.ScrollContainer.Add(gameObject);
  }
}
