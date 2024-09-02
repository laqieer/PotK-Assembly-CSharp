// Decompiled with JetBrains decompiler
// Type: Help0151Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
    return (IEnumerator) new Help0151Menu.\u003CInitHelp\u003Ec__Iterator5C7()
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
