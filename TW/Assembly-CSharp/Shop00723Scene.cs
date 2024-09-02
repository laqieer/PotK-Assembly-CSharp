// Decompiled with JetBrains decompiler
// Type: Shop00723Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Shop00723Scene : NGSceneBase
{
  private bool isInitialized_;
  private Shop00723Menu menu_;
  private PlayerUnitTicketSummary ticket_;
  private static readonly string DEFAULT_NAME = "shop007_23";

  public bool isErrorTicketDateTime_ { get; private set; }

  public static void changeScene(int id, bool isStack = true)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene(Shop00723Scene.DEFAULT_NAME, (isStack ? 1 : 0) != 0, (object) id);
  }

  public static void changeScene(PlayerUnitTicketSummary ticket, bool isStack = true)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene(Shop00723Scene.DEFAULT_NAME, (isStack ? 1 : 0) != 0, (object) ticket);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00723Scene.\u003ConStartSceneAsync\u003Ec__Iterator4C2()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(int ticketID)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00723Scene.\u003ConStartSceneAsync\u003Ec__Iterator4C3()
    {
      ticketID = ticketID,
      \u003C\u0024\u003EticketID = ticketID,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(PlayerUnitTicketSummary ticket)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00723Scene.\u003ConStartSceneAsync\u003Ec__Iterator4C4()
    {
      ticket = ticket,
      \u003C\u0024\u003Eticket = ticket,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator coLateStartScene()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Shop00723Scene.\u003CcoLateStartScene\u003Ec__Iterator4C5 sceneCIterator4C5 = new Shop00723Scene.\u003CcoLateStartScene\u003Ec__Iterator4C5();
    return (IEnumerator) sceneCIterator4C5;
  }

  public void shopFinish() => this.isInitialized_ = false;

  [DebuggerHidden]
  public IEnumerator coCheckTicketDateTime()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00723Scene.\u003CcoCheckTicketDateTime\u003Ec__Iterator4C6()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator coEndSceneErrorTicketDateTime()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Shop00723Scene.\u003CcoEndSceneErrorTicketDateTime\u003Ec__Iterator4C7 timeCIterator4C7 = new Shop00723Scene.\u003CcoEndSceneErrorTicketDateTime\u003Ec__Iterator4C7();
    return (IEnumerator) timeCIterator4C7;
  }

  [DebuggerHidden]
  public IEnumerator coEndSceneErrorTicketShortage()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Shop00723Scene.\u003CcoEndSceneErrorTicketShortage\u003Ec__Iterator4C8 shortageCIterator4C8 = new Shop00723Scene.\u003CcoEndSceneErrorTicketShortage\u003Ec__Iterator4C8();
    return (IEnumerator) shortageCIterator4C8;
  }
}
