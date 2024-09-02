// Decompiled with JetBrains decompiler
// Type: ScheduleEnumerator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new ScheduleEnumerator.\u003CdoBody\u003Ec__Iterator996()
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
