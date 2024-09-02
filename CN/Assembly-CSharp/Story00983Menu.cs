﻿// Decompiled with JetBrains decompiler
// Type: Story00983Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Story00983Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtChapter;
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  private NGxScroll ScrollContainer;

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
    Singleton<NGSceneManager>.GetInstance().changeScene("story009_8", false, (object) false);
  }

  [DebuggerHidden]
  public IEnumerator InitScene(QuestExtraS extra)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story00983Menu.\u003CInitScene\u003Ec__Iterator536()
    {
      extra = extra,
      \u003C\u0024\u003Eextra = extra,
      \u003C\u003Ef__this = this
    };
  }

  public void ScrollInit(QuestExtraS extra, GameObject prefab)
  {
    GameObject gameObject = Object.Instantiate<GameObject>(prefab);
    gameObject.GetComponent<Story00983Scroll>().Init(extra, (NGMenuBase) this);
    this.ScrollContainer.Add(gameObject);
  }
}
