// Decompiled with JetBrains decompiler
// Type: Popup00743Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Popup00743Menu : BackButtonMenuBase
{
  [SerializeField]
  private GameObject baseSheet;
  [SerializeField]
  private UIScrollView scrollView;
  [SerializeField]
  private UILabel txtPrice;
  [SerializeField]
  private UILabel txtCaption;
  private bool bResetScrollView;
  private bool bLockScroll;

  private void Awake()
  {
    this.baseSheet.SetActive(false);
    this.bResetScrollView = false;
    this.bLockScroll = false;
  }

  private void Start()
  {
  }

  [DebuggerHidden]
  public IEnumerator Init(List<Shop00743Menu.Medal> medals)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup00743Menu.\u003CInit\u003Ec__Iterator4ED()
    {
      medals = medals,
      \u003C\u0024\u003Emedals = medals,
      \u003C\u003Ef__this = this
    };
  }

  private void resetScrollView()
  {
    this.scrollView.ResetPosition();
    this.scrollView.RestrictWithinBounds(false, false, true);
    ((Component) this.scrollView).GetComponentInChildren<UIGrid>().Reposition();
    this.scrollView.UpdateScrollbars(true);
  }

  protected override void Update()
  {
    base.Update();
    if (!this.bResetScrollView)
      return;
    this.bResetScrollView = false;
    this.resetScrollView();
    if (!this.bLockScroll)
      return;
    ((Behaviour) this.scrollView).enabled = false;
  }

  public void onClosePressed() => Singleton<PopupManager>.GetInstance().onDismiss();

  public override void onBackButton() => this.onClosePressed();
}
