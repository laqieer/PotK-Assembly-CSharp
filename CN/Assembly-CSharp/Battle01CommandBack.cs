// Decompiled with JetBrains decompiler
// Type: Battle01CommandBack
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Battle01CommandBack : BattleBackButtonMenuBase
{
  private Battle01SelectNode selectNode;
  private PVPManager _pvpManager;

  private PVPManager pvpManager
  {
    get
    {
      if (Object.op_Equality((Object) this._pvpManager, (Object) null))
        this._pvpManager = Singleton<PVPManager>.GetInstance();
      return this._pvpManager;
    }
  }

  private void Awake()
  {
    EventDelegate.Set(((Component) this).GetComponent<UIButton>().onClick, new EventDelegate((MonoBehaviour) this, "onClick"));
  }

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01CommandBack.\u003CStart_Battle\u003Ec__Iterator842()
    {
      \u003C\u003Ef__this = this
    };
  }

  public override void onBackButton() => this.onClick();

  public void onClick()
  {
    if (!this.battleManager.isBattleEnable || this.battleManager.isPvp && this.pvpManager.isSending)
      return;
    if (this.env.core.phaseState.state == BL.Phase.pvp_disposition && this.env.core.unitCurrent.unit != null)
      this.env.core.currentUnitPosition.cancelMove(this.env);
    this.selectNode.onBack();
  }
}
