// Decompiled with JetBrains decompiler
// Type: TutorialPageBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class TutorialPageBase : MonoBehaviour
{
  public bool IsTouchBlock = true;
  private GameObject root;
  protected TutorialAdvice advice;
  protected TutorialProgress progress;

  public virtual void Init(TutorialProgress progress_, TutorialAdvice advice_, GameObject root_)
  {
    this.progress = progress_;
    this.advice = advice_;
    this.root = root_;
    ((Component) this).gameObject.SetActive(false);
  }

  public virtual void ReleaseResources()
  {
  }

  public virtual void NextPage() => this.progress.OnNextPage();

  [DebuggerHidden]
  public virtual IEnumerator Show()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new TutorialPageBase.\u003CShow\u003Ec__Iterator65B()
    {
      \u003C\u003Ef__this = this
    };
  }

  public virtual void Hide()
  {
    this.root.SetActive(false);
    ((Component) this).gameObject.SetActive(false);
    this.hideCommon();
    this.touchUnlock();
  }

  protected void showCommon()
  {
    Singleton<CommonRoot>.GetInstance().isActiveHeader = true;
    Singleton<CommonRoot>.GetInstance().isActiveFooter = true;
    Singleton<CommonRoot>.GetInstance().setDisableFooterColor(true);
  }

  protected void hideCommon()
  {
    Singleton<CommonRoot>.GetInstance().isActiveHeader = false;
    Singleton<CommonRoot>.GetInstance().isActiveFooter = false;
    Singleton<CommonRoot>.GetInstance().setDisableFooterColor(false);
  }

  private void touchLock()
  {
    CommonRoot instance = Singleton<CommonRoot>.GetInstance();
    if (!Object.op_Inequality((Object) instance, (Object) null))
      return;
    instance.isTouchBlock = true;
  }

  private void touchUnlock()
  {
    CommonRoot instance = Singleton<CommonRoot>.GetInstance();
    if (!Object.op_Inequality((Object) instance, (Object) null))
      return;
    instance.isTouchBlock = false;
  }

  public Coroutine StartCoroutine(IEnumerator e)
  {
    return Singleton<TutorialRoot>.GetInstance().StartCoroutine(e);
  }
}
