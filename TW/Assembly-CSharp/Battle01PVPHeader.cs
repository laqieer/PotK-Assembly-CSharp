// Decompiled with JetBrains decompiler
// Type: Battle01PVPHeader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
  [SerializeField]
  private Animator playerWipedOutAnime;
  [SerializeField]
  private Animator enemyWipedOutAnime;
  private BL.BattleModified<BL.StructValue<int>> remainTurnModified;
  private BL.BattleModified<BL.StructValue<int>> timeLimitModified;
  private BL.BattleModified<BL.StructValue<int>> playerPointModified;
  private BL.BattleModified<BL.StructValue<int>> enemyPointModified;
  private BL.BattleModified<BL.StructValue<bool>> isPlayerWipedOutModified;
  private BL.BattleModified<BL.StructValue<bool>> isEnemyWipedOutModified;
  private BL.BattleModified<BL.PhaseState> phaseStateModified;
  private SpriteNumberSelectDirect[] numberDirects;
  private BattleTimeManager _btm;

  private BattleTimeManager btm
  {
    get
    {
      if (Object.op_Equality((Object) this._btm, (Object) null))
        this._btm = this.battleManager.getManager<BattleTimeManager>();
      return this._btm;
    }
  }

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01PVPHeader.\u003CStart_Battle\u003Ec__Iterator94F()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected override void Update_Battle()
  {
    IGameEngine gameEngine = this.battleManager.gameEngine;
    if (gameEngine == null)
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
    {
      if (this.isPlayerWipedOutModified.isChangedOnce() && this.isPlayerWipedOutModified.value.value)
      {
        this.btm.setScheduleAction((System.Action) (() => this.enemyWipedOutAnime.SetTrigger("isPlay")));
        this.btm.setEnableWait(0.1f);
        this.isPlayerWipedOutModified.value.value = false;
      }
      this.enemyGauge.setValue(gameEngine.endPoint - this.playerPointModified.value.value, gameEngine.endPoint);
    }
    if (this.enemyPointModified.isChangedOnce())
    {
      if (this.isEnemyWipedOutModified.isChangedOnce() && this.isEnemyWipedOutModified.value.value)
      {
        this.btm.setScheduleAction((System.Action) (() => this.playerWipedOutAnime.SetTrigger("isPlay")));
        this.btm.setEnableWait(0.1f);
        this.isEnemyWipedOutModified.value.value = false;
      }
      this.playerGauge.setValue(gameEngine.endPoint - this.enemyPointModified.value.value, gameEngine.endPoint);
    }
    if (!this.battleManager.isGvg)
      return;
    this.battleManager.gvgManager.execNextState((BattleMonoBehaviour) this);
  }
}
