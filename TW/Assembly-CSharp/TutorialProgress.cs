// Decompiled with JetBrains decompiler
// Type: TutorialProgress
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
[Serializable]
public class TutorialProgress
{
  public System.Action OnNextPageCallback = (System.Action) (() => { });
  public System.Action OnFinishCallback = (System.Action) (() => { });
  public int CurrentPageIndex;
  public GameObject root;
  [SerializeField]
  private TutorialPageBase[] allPages = new TutorialPageBase[0];

  public TutorialProgress(TutorialPageBase[] allPages_, TutorialAdvice advice, GameObject root_)
  {
    TutorialProgress progress_ = this;
    this.root = root_;
    this.allPages = ((IEnumerable<TutorialPageBase>) allPages_).OrderBy<TutorialPageBase, string>((Func<TutorialPageBase, string>) (x => ((Object) x).name)).ToArray<TutorialPageBase>();
    ((IEnumerable<TutorialPageBase>) this.allPages).ForEach<TutorialPageBase>((Action<TutorialPageBase>) (x => x.Init(progress_, advice, progress_.root)));
  }

  private TutorialPageBase currentOrNull()
  {
    return this.IsFinish() ? (TutorialPageBase) null : this.allPages[this.CurrentPageIndex];
  }

  public string CurrentName()
  {
    TutorialPageBase tutorialPageBase = this.currentOrNull();
    return Object.op_Equality((Object) tutorialPageBase, (Object) null) ? "finish(" + (object) this.CurrentPageIndex + ")" : ((Object) tutorialPageBase).name;
  }

  public TutorialGachaPage GachaPage() => this.currentOrNull() as TutorialGachaPage;

  public TutorialBattlePage BattlePage() => this.currentOrNull() as TutorialBattlePage;

  public void ReleaseResources()
  {
    ((IEnumerable<TutorialPageBase>) this.allPages).ForEach<TutorialPageBase>((Action<TutorialPageBase>) (x => x.ReleaseResources()));
  }

  [DebuggerHidden]
  public IEnumerator Render()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new TutorialProgress.\u003CRender\u003Ec__Iterator87F()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void OnNextPage()
  {
    if (this.IsFinish())
    {
      Debug.LogWarning((object) "call OnNextPage() but tutorial is finished");
    }
    else
    {
      this.allPages[this.CurrentPageIndex].Hide();
      ++this.CurrentPageIndex;
      if (this.IsFinish())
      {
        Debug.Log((object) "tutorial OnFinishPageCallback");
        this.OnFinishCallback();
      }
      else
      {
        Debug.Log((object) "tutorial OnNextPageCallback");
        Singleton<TutorialRoot>.GetInstance().StartCoroutine(this.allPages[this.CurrentPageIndex].Show());
        this.OnNextPageCallback();
      }
    }
  }

  public bool IsFinish() => this.CurrentPageIndex >= this.allPages.Length;
}
