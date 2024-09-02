// Decompiled with JetBrains decompiler
// Type: Popup0228Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
    ++this.env.core.continueCount;
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
    return (IEnumerator) new Popup0228Menu.\u003COpenItemList\u003Ec__Iterator7D5()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnNo()
  {
    this.battleManager.getManager<BattleTimeManager>().setPhaseState(BL.Phase.gameover);
    this.battleManager.popupDismiss();
  }
}
