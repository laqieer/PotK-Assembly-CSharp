// Decompiled with JetBrains decompiler
// Type: Battle0181Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Battle0181Scene : NGSceneBase
{
  [SerializeField]
  private Battle0181Menu menu;
  [SerializeField]
  private NGDuelManager duel;
  private Color orig_ambient;
  private GameObject gDL;
  public GameObject spdButton1x;
  public GameObject spdButton2x;
  public GameObject spdButton4x;
  public GameObject statusAttackBaseNormal;
  public GameObject statusAttackBaseColosseum;
  private float origSpeed;
  private int settingSpeed;
  private bool is_colosseum_duel;
  private bool is_initial_scene;

  public static void changeSceneForColossuem(DuelColosseumResult result, bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("battle018_1", (stack ? 1 : 0) != 0, (object) result);
  }

  public IEnumerator onStartSceneAsync(DuelColosseumResult result)
  {
    return this.onStartSceneAsync(new DuelResult()
    {
      isColosseum = true,
      isPlayerAttack = result.isPlayerFirstAttacker,
      attack = !result.isPlayerFirstAttacker ? result.opponent : result.player,
      attackAttackStatus = !result.isPlayerFirstAttacker ? result.opponentAttackStatus : result.playerAttackStatus,
      colosseumNewAAS = !result.isPlayerFirstAttacker ? result.colosseumNewOAS : result.colosseumNewPAS,
      attackDamage = result.firstAttackerDamage,
      attackFromDamage = result.firstAttackerFromDamage,
      attackDuelSupport = (IntimateDuelSupport) null,
      defense = result.isPlayerFirstAttacker ? result.opponent : result.player,
      defenseAttackStatus = result.isPlayerFirstAttacker ? result.opponentAttackStatus : result.playerAttackStatus,
      colosseumNewDAS = result.isPlayerFirstAttacker ? result.colosseumNewOAS : result.colosseumNewPAS,
      defenseDamage = result.secondAttackerDamage,
      defenseFromDamage = result.secondAttackerFromDamage,
      defenseDuelSupport = (IntimateDuelSupport) null,
      isFirstBoss = false,
      isBossBattle = false,
      isDieAttack = result.isDieFirstAttacker,
      isDieDefense = result.isDieSecondAttacker,
      beforeAttakerAilmentEffectIDs = new int[0],
      beforeDefenderAilmentEffectIDs = new int[0],
      turns = result.turns,
      distance = 1
    }, new DuelEnvironment()
    {
      storys = (List<BL.Story>) null,
      stage = new BL.Stage(501)
    });
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(DuelResult duelResult, DuelEnvironment duelEnv)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle0181Scene.\u003ConStartSceneAsync\u003Ec__Iterator8A4()
    {
      duelResult = duelResult,
      duelEnv = duelEnv,
      \u003C\u0024\u003EduelResult = duelResult,
      \u003C\u0024\u003EduelEnv = duelEnv,
      \u003C\u003Ef__this = this
    };
  }

  private void SetSpeed(int speed)
  {
    int num = Mathf.Clamp(speed, 1, 3);
    if (this.settingSpeed != num)
    {
      this.settingSpeed = num;
      Persist.duel.Data.speed = this.settingSpeed;
      Persist.duel.Flush();
    }
    this.spdButton1x.SetActive(this.settingSpeed == 1);
    this.spdButton2x.SetActive(this.settingSpeed == 2);
    this.spdButton4x.SetActive(this.settingSpeed == 3);
    Time.timeScale = (float) this.settingSpeed;
  }

  public override void onEndScene()
  {
    if (!Singleton<NGBattleManager>.GetInstance().GetIsFastBattel() && this.duel.isDuelEnd)
    {
      Singleton<CommonRoot>.GetInstance().isActiveBackground3DCamera = true;
      RenderSettings.ambientLight = this.orig_ambient;
      Singleton<NGSoundManager>.GetInstance().corssFadeCurrentBGM(2.5f, 0.0f);
      this.is_initial_scene = false;
      if (Object.op_Inequality((Object) this.gDL, (Object) null))
        this.gDL.SetActive(true);
    }
    Time.timeScale = this.origSpeed;
  }

  public void onSpeedButtonClicked() => this.SetSpeed(this.nextSpeed());

  private int nextSpeed()
  {
    if (this.settingSpeed == 1)
      return 2;
    return this.settingSpeed == 2 ? 3 : 1;
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle0181Scene.\u003ConInitSceneAsync\u003Ec__Iterator8A5()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void OnEnable()
  {
    if (!Singleton<NGBattleManager>.GetInstance().GetIsFastBattel())
      this.duel.isWait = false;
    if (!this.is_initial_scene)
      return;
    try
    {
      this.settingSpeed = Persist.duel.Data.speed;
    }
    catch (Exception ex)
    {
      Persist.duel.Delete();
    }
    this.SetSpeed(this.settingSpeed);
  }

  private void OnDisable()
  {
    if (Singleton<NGBattleManager>.GetInstance().GetIsFastBattel())
      return;
    this.duel.isWait = true;
  }
}
