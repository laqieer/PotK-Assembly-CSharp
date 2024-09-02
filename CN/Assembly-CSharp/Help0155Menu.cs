// Decompiled with JetBrains decompiler
// Type: Help0155Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Help0155Menu : BackButtonMenuBase
{
  [SerializeField]
  protected GameObject ScrollGrid;
  public NGxScroll scroll;
  public UIScrollView scrollview;
  private GameObject barPrefab;

  public virtual void Foreground()
  {
  }

  public virtual void VScrollBar()
  {
  }

  [DebuggerHidden]
  public IEnumerator InitBeginnerNavi()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Help0155Menu.\u003CInitBeginnerNavi\u003Ec__Iterator57D()
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
