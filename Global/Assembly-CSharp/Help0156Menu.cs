// Decompiled with JetBrains decompiler
// Type: Help0156Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Help0156Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtHelp01;
  [SerializeField]
  protected UILabel TxtTitle;
  public NGxScroll scroll;
  public UIScrollView scrollview;

  public virtual void Foreground()
  {
  }

  public virtual void IbtnHelp()
  {
  }

  public virtual void VScrollBar()
  {
  }

  [DebuggerHidden]
  public IEnumerator InitBeginnerNaviTitle(List<BeginnerNaviTitle> bnTitles)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Help0156Menu.\u003CInitBeginnerNaviTitle\u003Ec__Iterator4DD()
    {
      bnTitles = bnTitles,
      \u003C\u0024\u003EbnTitles = bnTitles,
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();
}
