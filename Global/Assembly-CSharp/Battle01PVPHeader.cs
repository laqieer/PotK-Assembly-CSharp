// Decompiled with JetBrains decompiler
// Type: Battle01PVPHeader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Battle01PVPHeader : BattleMonoBehaviour
{
  [SerializeField]
  private SpriteNumber remainTurn;
  [SerializeField]
  private SpriteNumber remainTime;
  [SerializeField]
  private Battle01PVPSetPointGauge playerGauge;
  [SerializeField]
  private Battle01PVPSetPointGauge enemyGauge;
  [SerializeField]
  private GameObject remainPlayer;
  [SerializeField]
  private GameObject remainEnemy;
  private PVPManager _pvpManager;
  private BL.BattleModified<BL.StructValue<int>> remainTurnModified;
  private BL.BattleModified<BL.StructValue<int>> timeLimitModified;
  private BL.BattleModified<BL.StructValue<int>> playerPointModified;
  private BL.BattleModified<BL.StructValue<int>> enemyPointModified;
  private BL.BattleModified<BL.PhaseState> phaseStateModified;
  private SpriteNumberSelectDirect[] numberDirects;

  private PVPManager pvpManager
  {
    get
    {
      if (Object.op_Equality((Object) this._pvpManager, (Object) null))
        this._pvpManager = Singleton<PVPManager>.GetInstanceOrNull();
      return this._pvpManager;
    }
  }

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01PVPHeader.\u003CStart_Battle\u003Ec__Iterator738()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected override void Update_Battle()
  {
    if (Object.op_Equality((Object) this.pvpManager, (Object) null))
      return;
    if (this.phaseStateModified.isChangedOnce())
    {
      BL.PhaseState phaseState = this.phaseStateModified.value;
      if (phaseState.state == BL.Phase.pvp_enemy_start)
      {
        this.remainPlayer.SetActive(false);
        this.remainEnemy.SetActive(true);
        foreach (Component numberDirect in this.numberDirects)
          numberDirect.gameObject.SetActive(false);
      }
      else if (phaseState.state == BL.Phase.pvp_player_start)
      {
        this.remainPlayer.SetActive(true);
        this.remainEnemy.SetActive(false);
        foreach (Component numberDirect in this.numberDirects)
          numberDirect.gameObject.SetActive(true);
      }
    }
    if (this.remainTurnModified.isChangedOnce())
      this.remainTurn.setNumber(this.remainTurnModified.value.value);
    if (this.timeLimitModified.isChangedOnce())
      this.remainTime.setNumber(this.timeLimitModified.value.value);
    if (this.playerPointModified.isChangedOnce())
      this.enemyGauge.setValue(this.pvpManager.stage.point - this.playerPointModified.value.value, this.pvpManager.stage.point);
    if (!this.enemyPointModified.isChangedOnce())
      return;
    this.playerGauge.setValue(this.pvpManager.stage.point - this.enemyPointModified.value.value, this.pvpManager.stage.point);
  }
}
