// Decompiled with JetBrains decompiler
// Type: Battle01CommandOugi
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Battle01CommandOugi : NGBattleMenuBase, IButtonEnableBeheviour
{
  [SerializeField]
  private SelectParts selectParts;
  [SerializeField]
  private UILabel turnLabel;
  private Battle01SelectNode selectNode;
  private BL.BattleModified<BL.CurrentUnit> currentModified;
  private BL.BattleModified<BL.PhaseState> phaseModified;
  private BL.BattleModified<BL.UnitPosition> unitPositionModified;
  private UIButton[] buttons;

  public bool buttonEnable
  {
    set
    {
      foreach (UIButton button in this.buttons)
        button.isEnabled = value;
    }
  }

  [DebuggerHidden]
  public override IEnumerator onInitAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01CommandOugi.\u003ConInitAsync\u003Ec__Iterator6FE()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01CommandOugi.\u003CStart_Battle\u003Ec__Iterator6FF()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected override void Update_Battle()
  {
    bool flag1 = this.currentModified.isChangedOnce();
    bool flag2 = this.phaseModified.isChangedOnce();
    bool flag3 = this.unitPositionModified.isChangedOnce();
    if (!flag1 && !flag2 && !flag3)
      return;
    BL.Unit unit = this.currentModified.value.unit;
    if (unit == null || unit.ougi == null)
      return;
    int v = unit.ougi.useTurn - this.phaseModified.value.absoluteTurnCount;
    if (v <= 0)
    {
      if (this.env.core.currentUnitPosition.isActionComleted)
        this.selectParts.setValue(1);
      else
        this.selectParts.setValue(0);
    }
    else
    {
      this.selectParts.setValue(1);
      this.setText(this.turnLabel, v);
    }
  }

  public void onClick()
  {
    if (!this.battleManager.isBattleEnable)
      return;
    BL.Unit unit = this.currentModified.value.unit;
    if (unit == null || unit.ougi == null || !Object.op_Inequality((Object) this.selectNode, (Object) null) || this.env.core.getUnitPosition(unit).isCompleted || unit.ougi.useTurn - this.phaseModified.value.absoluteTurnCount > 0)
      return;
    this.selectNode.useOugi(unit, unit.ougi);
  }
}
