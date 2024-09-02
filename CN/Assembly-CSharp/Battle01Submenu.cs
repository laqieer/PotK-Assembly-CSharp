// Decompiled with JetBrains decompiler
// Type: Battle01Submenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Battle01Submenu : BattleBackButtonMenuBase
{
  public SelectParts sight;
  public SelectParts area;
  public SelectParts type;
  public SelectParts skipDuel;
  public UILabel txtLvSkipDuel;
  private BL.BattleModified<BL.StructValue<bool>> isViewDengerAreaModified;
  private BL.BattleModified<BL.StructValue<int>> sightModified;
  private BL.BattleModified<BL.StructValue<bool>> isViewUnitTypeModified;
  private Battle01SelectNode selectNode;
  private GameObject menuPopupPrefab;
  private bool is_push;

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01Submenu.\u003CStart_Battle\u003Ec__Iterator864()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected override void LateUpdate_Battle()
  {
    if (this.isViewDengerAreaModified.isChangedOnce())
      this.area.setValue(!this.isViewDengerAreaModified.value.value ? 0 : 1);
    if (this.sightModified.isChangedOnce())
      this.sight.setValue(this.sightModified.value.value);
    if (this.isViewUnitTypeModified.isChangedOnce())
      this.type.setValue(!this.isViewUnitTypeModified.value.value ? 0 : 1);
    this.UpdateButtonSkip();
  }

  public void InitSkipButton()
  {
  }

  public void UpdateButtonSkip()
  {
    if (!Singleton<NGBattleManager>.GetInstance().bChangSkipDuelStatus)
      return;
    if (Object.op_Inequality((Object) this.txtLvSkipDuel, (Object) null))
      ((Component) this.txtLvSkipDuel).gameObject.SetActive(false);
    if (!SMManager.Get<Player>().IsSkipDuel())
    {
      this.skipDuel.setValue(2);
      if (Singleton<NGBattleManager>.GetInstance().GetIsFastBattel())
        Singleton<NGBattleManager>.GetInstance().SetFastBattle(false);
      int skipDuelOpenLevel = Singleton<NGBattleManager>.GetInstance().GetSkipDuelOpenLevel();
      if (Object.op_Inequality((Object) this.txtLvSkipDuel, (Object) null))
      {
        ((Component) this.txtLvSkipDuel).gameObject.SetActive(true);
        this.txtLvSkipDuel.text = "等级." + (object) skipDuelOpenLevel;
      }
    }
    else if (Singleton<NGBattleManager>.GetInstance().GetIsFastBattel())
      this.skipDuel.setValue(1);
    else
      this.skipDuel.setValue(0);
    Singleton<NGBattleManager>.GetInstance().bChangSkipDuelStatus = false;
  }

  public void onButtonArea()
  {
    if (this.env.core.phaseState.state == BL.Phase.pvp_disposition)
      return;
    this.isViewDengerAreaModified.value.value = this.area.inclementLoop() == 1;
  }

  public void onButtonSight() => this.sightModified.value.value = this.sight.inclementLoop();

  public void onButtonSkipDuel()
  {
    switch (this.skipDuel.getValue())
    {
      case 0:
        this.skipDuel.setValue(1);
        Singleton<NGBattleManager>.GetInstance().SetFastBattle(true);
        break;
      case 1:
        this.skipDuel.setValue(0);
        Singleton<NGBattleManager>.GetInstance().SetFastBattle(false);
        break;
    }
  }

  public void onButtonType()
  {
    this.isViewUnitTypeModified.value.value = this.type.inclementLoop() == 1;
  }

  public void onButtonMenu()
  {
    if (!this.battleManager.isBattleEnable || !this.battleManager.isPvp && this.env.core.phaseState.state != BL.Phase.player || Singleton<CommonRoot>.GetInstance().isActive3DUIMask || this.env.core.isAutoBattle.value || Singleton<TutorialRoot>.GetInstance().IsAdviced)
      return;
    this.selectNode.backToTop();
    this.battleManager.popupOpen(this.menuPopupPrefab);
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

  private bool IsPushCheck()
  {
    if (this.is_push)
      return true;
    this.is_push = true;
    this.StartCoroutine(this.pushCancel());
    return false;
  }

  [DebuggerHidden]
  private IEnumerator pushCancel()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01Submenu.\u003CpushCancel\u003Ec__Iterator865()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator AutoBattleStartPop()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01Submenu.\u003CAutoBattleStartPop\u003Ec__Iterator866()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator TurnEndPop()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01Submenu.\u003CTurnEndPop\u003Ec__Iterator867()
    {
      \u003C\u003Ef__this = this
    };
  }

  public override void onBackButton()
  {
    if (!this.selectNode.canOpenMenu())
      return;
    this.onButtonMenu();
  }
}
