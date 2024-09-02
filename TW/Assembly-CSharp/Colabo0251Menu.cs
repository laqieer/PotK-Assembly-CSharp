// Decompiled with JetBrains decompiler
// Type: Colabo0251Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Colabo0251Menu : NGMenuBase
{
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  private UIGrid grid;
  [SerializeField]
  private UIScrollView scrollview;

  public virtual void Foreground()
  {
  }

  public virtual void IbtnColaboDammy()
  {
  }

  public virtual void VScrollBar()
  {
  }

  [DebuggerHidden]
  public IEnumerator Init()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colabo0251Menu.\u003CInit\u003Ec__Iterator648()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ScrollCreate(GameObject prefab, CrossFestaCampaign data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colabo0251Menu.\u003CScrollCreate\u003Ec__Iterator649()
    {
      prefab = prefab,
      data = data,
      \u003C\u0024\u003Eprefab = prefab,
      \u003C\u0024\u003Edata = data,
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnBack() => this.backScene();
}
