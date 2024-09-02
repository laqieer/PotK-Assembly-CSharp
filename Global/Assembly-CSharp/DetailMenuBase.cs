// Decompiled with JetBrains decompiler
// Type: DetailMenuBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
    DetailMenuBase.\u003CInit\u003Ec__Iterator8A8 initCIterator8A8 = new DetailMenuBase.\u003CInit\u003Ec__Iterator8A8();
    return (IEnumerator) initCIterator8A8;
  }

  [DebuggerHidden]
  public virtual IEnumerator SetInformationPanelIndex(int index)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    DetailMenuBase.\u003CSetInformationPanelIndex\u003Ec__Iterator8A9 indexCIterator8A9 = new DetailMenuBase.\u003CSetInformationPanelIndex\u003Ec__Iterator8A9();
    return (IEnumerator) indexCIterator8A9;
  }
}
