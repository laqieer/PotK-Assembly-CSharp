// Decompiled with JetBrains decompiler
// Type: Help0152Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Help0152Menu : BackButtonMenuBase
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
  public IEnumerator InitSubCatecory(List<HelpHelp> helps)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Help0152Menu.\u003CInitSubCatecory\u003Ec__Iterator57A()
    {
      helps = helps,
      \u003C\u0024\u003Ehelps = helps,
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
