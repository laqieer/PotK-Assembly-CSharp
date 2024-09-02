// Decompiled with JetBrains decompiler
// Type: Help0151Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Help0151Menu : BackButtonMenuBase
{
  [SerializeField]
  protected GameObject ScrollGrid;
  public NGxScroll scroll;
  public UIScrollView scrollview;
  private GameObject barPrefab;

  public virtual void Foreground()
  {
  }

  public virtual void IbtnHelp()
  {
  }

  public virtual void IbtnHelp2()
  {
  }

  public virtual void IbtnHelp3()
  {
  }

  public virtual void IbtnHelp4()
  {
  }

  public virtual void IbtnHelp5()
  {
  }

  public virtual void IbtnHelp6()
  {
  }

  public virtual void VScrollBar()
  {
  }

  [DebuggerHidden]
  public IEnumerator InitHelp()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Help0151Menu.\u003CInitHelp\u003Ec__Iterator576()
    {
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
