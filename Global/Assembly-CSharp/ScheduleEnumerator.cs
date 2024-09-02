// Decompiled with JetBrains decompiler
// Type: ScheduleEnumerator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
    return (IEnumerator) new ScheduleEnumerator.\u003CdoBody\u003Ec__Iterator827()
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
