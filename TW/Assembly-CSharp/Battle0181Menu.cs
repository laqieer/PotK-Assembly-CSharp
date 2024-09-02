// Decompiled with JetBrains decompiler
// Type: Battle0181Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Battle0181Menu : NGMenuBase
{
  private const float SKILLDISP_OFFSET_Y = -52f;
  [SerializeField]
  private Battle0181CharacterStatus player;
  [SerializeField]
  private Battle0181CharacterStatus enemy;
  [SerializeField]
  private GameObject colosseumSkillOwnRoot;
  [SerializeField]
  private GameObject colosseumSkillEnemyRoot;
  private BL.UnitPosition attacker;
  private BL.UnitPosition defender;
  private GameObject mColosseumSkillActivity_Prefab;
  private GameObject mDirColosseumSkillOwn_Prefab;
  private GameObject mDirColosseumSkillEnemy_Prefab;
  private GameObject mUpEffectPrefab;
  private GameObject mDownEffectPrefab;

  public void Init(
    BL.UnitPosition attack,
    AttackStatus attackStatus,
    BL.UnitPosition defense,
    AttackStatus defenseStatus)
  {
    this.attacker = attack;
    this.defender = defense;
    this.player.Init(attack, attackStatus);
    this.enemy.Init(defense, defenseStatus);
  }

  public void ChangeStatus(AttackStatus attackStatus, AttackStatus defenseStatus)
  {
    this.player.ChangeStatus(this.attacker, attackStatus);
    this.enemy.ChangeStatus(this.defender, defenseStatus);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(bool isColosseum)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle0181Menu.\u003ConStartSceneAsync\u003Ec__Iterator8A2()
    {
      isColosseum = isColosseum,
      \u003C\u0024\u003EisColosseum = isColosseum,
      \u003C\u003Ef__this = this
    };
  }

  public void backToBattle()
  {
    this.backScene();
    Debug.Log((object) "Battle0181Menu backScene called");
  }

  public BL.UnitPosition Attacker => this.attacker;

  public BL.UnitPosition Defender => this.defender;

  [DebuggerHidden]
  public IEnumerator createColosseumDuelInvokeSkillDisp(
    BL.Unit playerUnit,
    BL.Unit enemyUnit,
    AttackStatus playerStatus,
    AttackStatus newPlayerStatus,
    AttackStatus enemyStatus,
    AttackStatus newEnemyStatus)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle0181Menu.\u003CcreateColosseumDuelInvokeSkillDisp\u003Ec__Iterator8A3()
    {
      playerUnit = playerUnit,
      enemyUnit = enemyUnit,
      playerStatus = playerStatus,
      newPlayerStatus = newPlayerStatus,
      enemyStatus = enemyStatus,
      newEnemyStatus = newEnemyStatus,
      \u003C\u0024\u003EplayerUnit = playerUnit,
      \u003C\u0024\u003EenemyUnit = enemyUnit,
      \u003C\u0024\u003EplayerStatus = playerStatus,
      \u003C\u0024\u003EnewPlayerStatus = newPlayerStatus,
      \u003C\u0024\u003EenemyStatus = enemyStatus,
      \u003C\u0024\u003EnewEnemyStatus = newEnemyStatus,
      \u003C\u003Ef__this = this
    };
  }
}
