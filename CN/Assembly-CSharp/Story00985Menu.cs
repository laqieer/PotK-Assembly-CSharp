// Decompiled with JetBrains decompiler
// Type: Story00985Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Story00985Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtChapter;
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  private NGxScroll ScrollContainer;
  private bool listBack;
  private int quest_id;

  public virtual void Foreground()
  {
  }

  public virtual void IbtnChapter05()
  {
  }

  public virtual void VScrollBar()
  {
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    if (this.listBack)
      Singleton<NGSceneManager>.GetInstance().changeScene("story009_8_3", false, (object) this.quest_id);
    else
      Singleton<NGSceneManager>.GetInstance().changeScene("story009_8", false, (object) false);
  }

  [DebuggerHidden]
  public IEnumerator InitScene(QuestExtraS extra_m, bool listBack, int id)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story00985Menu.\u003CInitScene\u003Ec__Iterator538()
    {
      listBack = listBack,
      id = id,
      extra_m = extra_m,
      \u003C\u0024\u003ElistBack = listBack,
      \u003C\u0024\u003Eid = id,
      \u003C\u0024\u003Eextra_m = extra_m,
      \u003C\u003Ef__this = this
    };
  }

  public void ScrollInit(StoryPlaybackExtraDetail extra, GameObject prefab)
  {
    GameObject gameObject = Object.Instantiate<GameObject>(prefab);
    gameObject.GetComponent<Story00985Scroll>().Init(extra, extra.script_id, (NGMenuBase) this);
    this.ScrollContainer.Add(gameObject);
  }
}
