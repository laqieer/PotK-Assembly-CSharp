﻿// Decompiled with JetBrains decompiler
// Type: Mypage00176Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Mypage00176Menu : BackButtonMenuBase
{
  [SerializeField]
  protected GameObject[] BtnProtected;
  [SerializeField]
  public UIButton BtnDelete;
  [SerializeField]
  protected UILabel TxtDescription;
  [SerializeField]
  protected UILabel TxtPopuptitle;
  private Mypage0017Menu menu0017;
  private PlayerPresent present;

  [DebuggerHidden]
  public IEnumerator Init(PlayerPresent presents, Mypage0017Menu menu)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Mypage00176Menu.\u003CInit\u003Ec__Iterator16C()
    {
      menu = menu,
      presents = presents,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u0024\u003Epresents = presents,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator DeleteDialog()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Mypage00176Menu.\u003CDeleteDialog\u003Ec__Iterator16D()
    {
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnPopupDelete() => this.StartCoroutine(this.DeleteDialog());

  public virtual void IbtnPopupOk()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnPopupOk();
}
