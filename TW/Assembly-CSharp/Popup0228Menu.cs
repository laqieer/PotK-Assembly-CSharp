// Decompiled with JetBrains decompiler
// Type: Popup0228Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Popup0228Menu : NGBattleMenuBase
{
  private void rebirth()
  {
    BattleTimeManager manager = this.battleManager.getManager<BattleTimeManager>();
    this.env.rebirthUnits(this.env.core.playerUnits.value, manager);
    manager.setPhaseState(BL.Phase.turn_initialize);
    manager.setScheduleAction((System.Action) (() =>
    {
      ++this.env.core.continueCount;
      this.battleManager.saveEnvironment();
      this.battleManager.StartCoroutine(this.SendContinueCount(this.env.core.continueCount));
    }));
  }

  public void IbtnYes()
  {
    if (this.env.core.continueCount < this.env.core.battleInfo.Coin)
    {
      this.rebirth();
      this.battleManager.popupDismiss();
    }
    else
    {
      if (this.IsPushAndSet())
        return;
      this.StartCoroutine(this.OpenItemList());
    }
  }

  [DebuggerHidden]
  private IEnumerator OpenItemList()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup0228Menu.\u003COpenItemList\u003Ec__IteratorA19()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnNo()
  {
    this.battleManager.getManager<BattleTimeManager>().setPhaseState(BL.Phase.gameover, true);
    this.battleManager.popupDismiss();
  }

  [DebuggerHidden]
  private IEnumerator SendContinueCount(int count)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup0228Menu.\u003CSendContinueCount\u003Ec__IteratorA1A()
    {
      count = count,
      \u003C\u0024\u003Ecount = count
    };
  }
}
