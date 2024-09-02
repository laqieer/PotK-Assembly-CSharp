// Decompiled with JetBrains decompiler
// Type: Battle01Submenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Battle01Submenu : BattleBackButtonMenuBase
{
  public SelectParts sight;
  public SelectParts area;
  public SelectParts type;
  private BL.BattleModified<BL.StructValue<bool>> isViewDengerAreaModified;
  private BL.BattleModified<BL.StructValue<int>> sightModified;
  private BL.BattleModified<BL.StructValue<bool>> isViewUnitTypeModified;
  private Battle01SelectNode selectNode;
  private GameObject menuPopupPrefab;

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01Submenu.\u003CStart_Battle\u003Ec__Iterator71D()
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
    if (!this.isViewUnitTypeModified.isChangedOnce())
      return;
    this.type.setValue(!this.isViewUnitTypeModified.value.value ? 0 : 1);
  }

  public void onButtonArea()
  {
    if (this.env.core.phaseState.state == BL.Phase.pvp_disposition)
      return;
    this.isViewDengerAreaModified.value.value = this.area.inclementLoop() == 1;
  }

  public void onButtonSight() => this.sightModified.value.value = this.sight.inclementLoop();

  public void onButtonType()
  {
    this.isViewUnitTypeModified.value.value = this.type.inclementLoop() == 1;
  }

  private void Update()
  {
    if (Singleton<CommonRoot>.GetInstance().isInputBlock || !Input.GetKeyUp((KeyCode) 27))
      return;
    this.onButtonMenu();
  }

  public void onButtonMenu()
  {
    if (!this.battleManager.isBattleEnable || !this.battleManager.isPvp && this.env.core.phaseState.state != BL.Phase.player || Singleton<CommonRoot>.GetInstance().isActive3DUIMask || this.env.core.isAutoBattle.value || Singleton<TutorialRoot>.GetInstance().IsAdviced)
      return;
    this.selectNode.backToTop();
    this.battleManager.popupOpen(this.menuPopupPrefab);
  }

  public override void onBackButton()
  {
    if (!this.selectNode.canOpenMenu())
      return;
    this.onButtonMenu();
  }
}
