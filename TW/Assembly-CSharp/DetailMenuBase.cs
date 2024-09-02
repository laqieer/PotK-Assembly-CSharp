// Decompiled with JetBrains decompiler
// Type: DetailMenuBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
    QuestScoreBonusTimetable[] tables,
    UnitBonus[] unitBonus,
    bool isUpdate = true)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    DetailMenuBase.\u003CInit\u003Ec__IteratorAFB initCIteratorAfb = new DetailMenuBase.\u003CInit\u003Ec__IteratorAFB();
    return (IEnumerator) initCIteratorAfb;
  }

  [DebuggerHidden]
  public virtual IEnumerator SetInformationPanelIndex(int index)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    DetailMenuBase.\u003CSetInformationPanelIndex\u003Ec__IteratorAFC indexCIteratorAfc = new DetailMenuBase.\u003CSetInformationPanelIndex\u003Ec__IteratorAFC();
    return (IEnumerator) indexCIteratorAfc;
  }
}
