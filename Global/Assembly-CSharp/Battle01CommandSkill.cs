// Decompiled with JetBrains decompiler
// Type: Battle01CommandSkill
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Battle01CommandSkill : BattleMonoBehaviour
{
  private Battle01SelectNode selectNode;
  private BL.BattleModified<BL.CurrentUnit> currentModified;
  private BL.BattleModified<BL.UnitPosition> unitPositionModified;

  private void Awake()
  {
    EventDelegate.Set(((Component) this).GetComponent<UIButton>().onClick, new EventDelegate((MonoBehaviour) this, "onClick"));
  }

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01CommandSkill.\u003CStart_Battle\u003Ec__Iterator700()
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
    if (!flag1 && !flag2)
      return;
    UIButton component = ((Component) this).GetComponent<UIButton>();
    if (!Object.op_Inequality((Object) component, (Object) null))
      return;
    component.isEnabled = !this.env.core.currentUnitPosition.isActionComleted;
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
