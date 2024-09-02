// Decompiled with JetBrains decompiler
// Type: DetailMenuBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class DetailMenuBase : NGMenuBase
{
  protected Unit0042Menu menu;
  protected int index;

  public int Index => this.index;

  [DebuggerHidden]
  public virtual IEnumerator Init(
    Unit0042Menu menu,
    int index,
    PlayerUnit playerUnit,
    int infoIndex,
    bool isLimit,
    bool isUpdate = true)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    DetailMenuBase.\u003CInit\u003Ec__IteratorA20 initCIteratorA20 = new DetailMenuBase.\u003CInit\u003Ec__IteratorA20();
    return (IEnumerator) initCIteratorA20;
  }

  [DebuggerHidden]
  public virtual IEnumerator SetInformationPanelIndex(int index)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    DetailMenuBase.\u003CSetInformationPanelIndex\u003Ec__IteratorA21 indexCIteratorA21 = new DetailMenuBase.\u003CSetInformationPanelIndex\u003Ec__IteratorA21();
    return (IEnumerator) indexCIteratorA21;
  }
}
