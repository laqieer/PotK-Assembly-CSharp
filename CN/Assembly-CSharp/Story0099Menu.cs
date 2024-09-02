// Decompiled with JetBrains decompiler
// Type: Story0099Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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

  [DebuggerHidden]
  public IEnumerator PlayOpeningMovie()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story0099Menu.\u003CPlayOpeningMovie\u003Ec__Iterator53B()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator PlayTutorialMovie1()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story0099Menu.\u003CPlayTutorialMovie1\u003Ec__Iterator53C()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator PlayTutorialMovie2()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story0099Menu.\u003CPlayTutorialMovie2\u003Ec__Iterator53D()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator PlayStoryQuestMovie(int id)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story0099Menu.\u003CPlayStoryQuestMovie\u003Ec__Iterator53E()
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
    return (IEnumerator) new Story0099Menu.\u003CInitScene\u003Ec__Iterator53F()
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
