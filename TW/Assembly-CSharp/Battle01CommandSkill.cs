// Decompiled with JetBrains decompiler
// Type: Battle01CommandSkill
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Battle01CommandSkill : BattleMonoBehaviour, IButtonEnableBeheviour
{
  private Battle01SelectNode selectNode;
  private BL.BattleModified<BL.CurrentUnit> currentModified;
  private BL.BattleModified<BL.UnitPosition> unitPositionModified;
  private UIButton button;
  private bool mButtonEnable;

  public bool buttonEnable
  {
    set
    {
      this.mButtonEnable = value;
      this.button.isEnabled = this.mButtonEnable && !this.env.core.currentUnitPosition.isActionComleted;
    }
  }

  [DebuggerHidden]
  public override IEnumerator onInitAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01CommandSkill.\u003ConInitAsync\u003Ec__Iterator911()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01CommandSkill.\u003CStart_Battle\u003Ec__Iterator912()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected override void Update_Battle()
  {
    if (!this.battleManager.isBattleEnable)
      return;
    bool flag1 = this.currentModified.isChangedOnce();
    bool flag2 = this.unitPositionModified.isChangedOnce();
    if (!flag1 && !flag2 || !Object.op_Inequality((Object) this.button, (Object) null))
      return;
    this.button.isEnabled = this.mButtonEnable && !this.env.core.currentUnitPosition.isActionComleted;
  }

  public void onClick()
  {
    if (!this.battleManager.isBattleEnable)
      return;
    BL.Unit unit = this.env.core.unitCurrent.unit;
    if (unit == null || this.env.core.getUnitPosition(unit).isCompleted)
      return;
    this.selectNode.useSkill();
  }
}
