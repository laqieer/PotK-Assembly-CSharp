// Decompiled with JetBrains decompiler
// Type: Battle01718Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Battle01718Menu : BattleBackButtonMenuBase
{
  [SerializeField]
  private UILabel lose_condition_txt;
  [SerializeField]
  private UILabel victory_condition_txt;
  [SerializeField]
  private UILabel player_nb_unit_txt;
  [SerializeField]
  private UILabel enemy_nb_unit_txt;
  [SerializeField]
  private UILabel passed_turn_txt;
  [SerializeField]
  private GameObject auto_button;
  [SerializeField]
  private GameObject retreat_button;
  [SerializeField]
  private GameObject mission_button;
  [SerializeField]
  private GameObject map_grid;
  [SerializeField]
  private GameObject waveDir;
  [SerializeField]
  private UILabel waveNum;
  [SerializeField]
  private GameObject duel_skip_button;
  [SerializeField]
  private List<GameObject> duel_skip_onoroff;
  private bool is_push;
  private static string chipExt = ".png__GUI__battle_mapchip__battle_mapchip_prefab";

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01718Menu.\u003CStart_Battle\u003Ec__Iterator7C1()
    {
      \u003C\u003Ef__this = this
    };
  }

  private int countActiveUnits(List<BL.Unit> units)
  {
    int num = 0;
    foreach (BL.Unit unit in units)
    {
      if (unit.isEnable && !unit.isDead)
        ++num;
    }
    return num;
  }

  private void setButtonEnabled(UIButton button, bool v)
  {
    if (Object.op_Equality((Object) button, (Object) null))
      return;
    button.isEnabled = v;
  }

  [DebuggerHidden]
  private IEnumerator AutoBattleStartPop()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01718Menu.\u003CAutoBattleStartPop\u003Ec__Iterator7C2()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator TurnEndPop()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01718Menu.\u003CTurnEndPop\u003Ec__Iterator7C3()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnAutoBattle()
  {
    if (this.IsPushCheck())
      return;
    this.StartCoroutine(this.AutoBattleStartPop());
  }

  public void IbtnTurnEnd()
  {
    if (this.IsPushCheck())
      return;
    this.StartCoroutine(this.TurnEndPop());
  }

  public void IbtnClose()
  {
    if (this.IsPushCheck())
      return;
    this.battleManager.popupDismiss();
  }

  public override void onBackButton() => this.IbtnClose();

  public void IbtnMission()
  {
    if (this.IsPushCheck())
      return;
    this.StartCoroutine(this.missionPop());
  }

  public void IbtnForceList()
  {
    if (this.IsPushCheck())
      return;
    this.StartCoroutine(this.ForcePop());
  }

  public void IbtnRetreat()
  {
    if (this.IsPushCheck())
      return;
    this.StartCoroutine(this.RetreatPop());
  }

  public void IbtnSuspend()
  {
    if (this.IsPushCheck())
      return;
    this.StartCoroutine(this.SuspendPop());
  }

  public void IbtnDuelSkip()
  {
    this.battleManager.noDuelScene = !this.battleManager.noDuelScene;
    if (this.duel_skip_onoroff == null || this.duel_skip_onoroff.Count <= 0)
      return;
    this.duel_skip_onoroff.ToggleOnce(!this.battleManager.noDuelScene ? 0 : 1);
  }

  [DebuggerHidden]
  private IEnumerator RetreatPop()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01718Menu.\u003CRetreatPop\u003Ec__Iterator7C4()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ForcePop()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01718Menu.\u003CForcePop\u003Ec__Iterator7C5()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator missionPop()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01718Menu.\u003CmissionPop\u003Ec__Iterator7C6()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SuspendPop()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01718Menu.\u003CSuspendPop\u003Ec__Iterator7C7()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator setupMapChips()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01718Menu.\u003CsetupMapChips\u003Ec__Iterator7C8()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void cloneMapChip(string name, int size, GameObject prefab)
  {
    UISprite component = prefab.CloneAndGetComponent<UISprite>(this.map_grid);
    component.spriteName = name + Battle01718Menu.chipExt;
    component.width = size;
    component.height = size;
  }

  private bool IsPushCheck()
  {
    if (this.battleManager.environment.core.phaseState.state == BL.Phase.gameover || this.is_push)
      return true;
    this.is_push = true;
    this.StartCoroutine(this.pushCancel());
    return false;
  }

  [DebuggerHidden]
  private IEnumerator pushCancel()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01718Menu.\u003CpushCancel\u003Ec__Iterator7C9()
    {
      \u003C\u003Ef__this = this
    };
  }
}
