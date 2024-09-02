// Decompiled with JetBrains decompiler
// Type: ScheduleEnumerator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class ScheduleEnumerator : Schedule
{
  protected bool isCompleted;

  [DebuggerHidden]
  public virtual IEnumerator doBody()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ScheduleEnumerator.\u003CdoBody\u003Ec__IteratorA6B()
    {
      \u003C\u003Ef__this = this
    };
  }

  public override bool body()
  {
    Singleton<NGBattleManager>.GetInstance().getManager<BattleTimeManager>().StartCoroutine(this.doBody());
    return true;
  }

  public override bool completedp() => this.isCompleted;
}
