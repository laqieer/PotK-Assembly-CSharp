// Decompiled with JetBrains decompiler
// Type: Popup017181Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

#nullable disable
public class Popup017181Menu : BattleBackButtonMenuBase
{
  [SerializeField]
  private UILabel label;

  public void Awake()
  {
    if (Singleton<NGBattleManager>.GetInstance().isPvp)
      this.label.SetTextLocalize(Consts.GetInstance().BATTLE_ESCAPE_POPUP_PVP);
    else
      this.label.SetTextLocalize(Consts.GetInstance().BATTLE_ESCAPE_POPUP);
  }

  public void IbtnYes()
  {
    this.battleManager.getController<BattleAIController>().stopAIAction();
    this.battleManager.getManager<BattleTimeManager>().setPhaseState(BL.Phase.gameover, true);
    this.battleManager.popupCloseAll();
  }

  public override void onBackButton() => this.IbtnNo();

  public void IbtnNo() => this.battleManager.popupDismiss();
}
