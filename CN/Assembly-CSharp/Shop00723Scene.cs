// Decompiled with JetBrains decompiler
// Type: Shop00723Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Shop00723Scene : NGSceneBase
{
  private Shop00723Menu menu_;
  private PlayerUnitTicketSummary ticket_;

  public bool isErrorTicketDateTime_ { get; private set; }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00723Scene.\u003ConStartSceneAsync\u003Ec__Iterator47A()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(int ticketID)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00723Scene.\u003ConStartSceneAsync\u003Ec__Iterator47B()
    {
      ticketID = ticketID,
      \u003C\u0024\u003EticketID = ticketID,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator coLateStartScene()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Shop00723Scene.\u003CcoLateStartScene\u003Ec__Iterator47C sceneCIterator47C = new Shop00723Scene.\u003CcoLateStartScene\u003Ec__Iterator47C();
    return (IEnumerator) sceneCIterator47C;
  }

  [DebuggerHidden]
  public IEnumerator coCheckTicketDateTime()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00723Scene.\u003CcoCheckTicketDateTime\u003Ec__Iterator47D()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator coEndSceneErrorTicketDateTime()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Shop00723Scene.\u003CcoEndSceneErrorTicketDateTime\u003Ec__Iterator47E timeCIterator47E = new Shop00723Scene.\u003CcoEndSceneErrorTicketDateTime\u003Ec__Iterator47E();
    return (IEnumerator) timeCIterator47E;
  }

  public void onStartScene()
  {
  }

  public void onStartScene(int ticketID)
  {
  }
}
