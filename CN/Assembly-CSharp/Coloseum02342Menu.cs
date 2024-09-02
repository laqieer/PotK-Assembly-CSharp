// Decompiled with JetBrains decompiler
// Type: Coloseum02342Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Coloseum02342Menu : BackButtonMenuBase
{
  private const int TWEEN_LOSE_ENEMY = 16;
  private const int TWEEN_LOSE_OWN = 15;
  private const int TWEEN_ID_OUT = 14;
  private const int TWEEN_ID_IN = 0;
  private const float DELAY = 1f;
  private const float DELAY_HALF = 0.5f;
  private const float DELAY_QUARTER = 0.25f;
  [SerializeField]
  protected UILabel TxtAttack;
  [SerializeField]
  protected UILabel TxtAttackOwn;
  [SerializeField]
  protected UILabel TxtCharaname;
  [SerializeField]
  protected UILabel TxtCharaname_ElementOn;
  [SerializeField]
  protected UILabel TxtCriticalEnemy;
  [SerializeField]
  protected UILabel TxtCriticalOwn;
  [SerializeField]
  protected UILabel TxtDexterityEnemy;
  [SerializeField]
  protected UILabel TxtDexterityOwn;
  [SerializeField]
  protected UILabel TxtEnemy;
  [SerializeField]
  protected UILabel TxtEnemyHonor;
  [SerializeField]
  protected UILabel TxtHPEnemy;
  [SerializeField]
  protected UILabel TxtHPOwn;
  [SerializeField]
  protected UILabel TxtOwn;
  [SerializeField]
  protected UILabel TxtOwnHonor;
  [SerializeField]
  protected UILabel TxtUnitNameEnemy;
  [SerializeField]
  protected UILabel TxtUnitNameEnemy_ElementOn;
  [SerializeField]
  protected UILabel TxtWeaponNameEnemy;
  [SerializeField]
  protected UILabel TxtWeaponNameOwn;
  [SerializeField]
  private bool DEBUG_LOSE_PARTICLE_OWN;
  [SerializeField]
  private bool DEBUG_LOSE_PARTICLE_ENEMY;
  private ColosseumUtility.Info info;
  private GameCore.ColosseumResult result;
  private Gladiator gladiator;
  private int nextBattleType;
  private int finalDuelCount;
  private int dueleCount = -1;
  private int resultIndex = -1;
  private int resultEffectType = -1;
  private List<UnitIcon> playerUnitIconC;
  private List<UnitIcon> enemyUnitIconC;
  private bool initialized;
  private GearKindIcon playerElementIcon;
  private GearKindIcon enemyElementIcon;
  private bool isSkip;
  private bool SkipPermission;
  private GearKindIcon playerGearKindIcon;
  private GearKindIcon enemyGearKindIcon;
  private BL.Unit player;
  private BL.Unit opponent;
  private BL.Unit lastPlayer;
  private BL.Unit lastOpponent;
  private float WAIT_LIMIT = 10f;
  private float waitTime;
  [SerializeField]
  private GameObject[] playerAttackValues;
  [SerializeField]
  private GameObject[] enemyAttackValues;
  [SerializeField]
  private GameObject[] playerAttackAdvantage;
  [SerializeField]
  private GameObject[] enemyAttackAdvantage;
  [SerializeField]
  private GameObject[] playerUnitIcon;
  private List<GameObject> playerMatchUpIcons;
  [SerializeField]
  private GameObject[] enemyUnitIcon;
  private List<GameObject> enemyMatchUpIcons;
  [SerializeField]
  private GameObject[] rounds;
  [SerializeField]
  private GameObject[] battleType;
  [SerializeField]
  private GameObject[] battleTypeDecoration;
  [SerializeField]
  private GameObject criticalBuffOwn;
  [SerializeField]
  private GameObject dexterityBuffOwn;
  [SerializeField]
  private GameObject attackBuffOwn;
  [SerializeField]
  private GameObject statusBuffOwn;
  [SerializeField]
  private GameObject criticalBuffEnemy;
  [SerializeField]
  private GameObject dexterityBuffEnemy;
  [SerializeField]
  private GameObject attackBuffEnemy;
  [SerializeField]
  private GameObject statusBuffEnemy;
  [SerializeField]
  private GameObject dirAnimResult;
  [SerializeField]
  private GameObject dirResult;
  private Animator[] resultAnimations = new Animator[2];
  [SerializeField]
  private GameObject dirAnimation;
  private GameObject loseAnimation;
  [SerializeField]
  private GameObject roundButton;
  [SerializeField]
  private GameObject roundButtonAnimate;
  [SerializeField]
  private GameObject playerDuelCharacter;
  [SerializeField]
  private GameObject enemyDuelCharacter;
  [SerializeField]
  private GameObject middle;
  private global::BattleResult battleResults;
  [SerializeField]
  private UI2DSprite[] Emblems;
  [SerializeField]
  private UI2DSprite playerKind;
  [SerializeField]
  private UI2DSprite enemyKind;
  [SerializeField]
  private GameObject dirBonusOwn;
  [SerializeField]
  private GameObject dirBonusEnemy;
  [SerializeField]
  private GameObject linkPlayerElement;
  [SerializeField]
  private GameObject linkEnemyElement;
  [SerializeField]
  private UILabel txtBonusOwn;
  [SerializeField]
  private UILabel txtBonusEnemy;
  [SerializeField]
  private UIButton ibtnResult;
  [SerializeField]
  private Coloseum02342Scene scene;
  [SerializeField]
  private GameObject BtnSkip;
  private Coloseum02342Menu.States state;
  private Coloseum02342Menu.States nextState;
  private NGSoundManager SM;

  private void Awake() => this.SM = Singleton<NGSoundManager>.GetInstance();

  [DebuggerHidden]
  public IEnumerator Initialize(
    ColosseumUtility.Info info,
    GameCore.ColosseumResult result,
    Gladiator gladiator,
    int duelCount)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Coloseum02342Menu.\u003CInitialize\u003Ec__Iterator59A()
    {
      info = info,
      result = result,
      gladiator = gladiator,
      duelCount = duelCount,
      \u003C\u0024\u003Einfo = info,
      \u003C\u0024\u003Eresult = result,
      \u003C\u0024\u003Egladiator = gladiator,
      \u003C\u0024\u003EduelCount = duelCount,
      \u003C\u003Ef__this = this
    };
  }

  public void SetColosseumData(
    ColosseumUtility.Info info,
    GameCore.ColosseumResult result,
    Gladiator gladiator)
  {
    this.info = info;
    this.result = result;
    this.finalDuelCount = result.duelResult.Length;
    this.nextBattleType = info.next_battle_type;
    this.gladiator = gladiator;
  }

  [DebuggerHidden]
  public IEnumerator LoadResource(int duelCount)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Coloseum02342Menu.\u003CLoadResource\u003Ec__Iterator59B()
    {
      duelCount = duelCount,
      \u003C\u0024\u003EduelCount = duelCount,
      \u003C\u003Ef__this = this
    };
  }

  private void InitKindIcon(GameObject weaponPrefab)
  {
    if (Object.op_Equality((Object) this.playerGearKindIcon, (Object) null))
      this.playerGearKindIcon = weaponPrefab.Clone(((Component) this.playerKind).gameObject.transform).GetComponent<GearKindIcon>();
    if (!Object.op_Equality((Object) this.enemyGearKindIcon, (Object) null))
      return;
    this.enemyGearKindIcon = weaponPrefab.Clone(((Component) this.enemyKind).gameObject.transform).GetComponent<GearKindIcon>();
  }

  public void StartToBeginning(int index)
  {
    this.dueleCount = index;
    this.resultIndex = this.dueleCount - 1;
    this.state = Coloseum02342Menu.States.DEFAULT;
    this.nextState = Coloseum02342Menu.States.DEFAULT;
    this.loseAnimation.SetActive(false);
    // ISSUE: object of a compiler-generated type is created
    foreach (\u003C\u003E__AnonType5<int, GameObject> anonType5 in ((IEnumerable<GameObject>) this.rounds).Select<GameObject, \u003C\u003E__AnonType5<int, GameObject>>((Func<GameObject, int, \u003C\u003E__AnonType5<int, GameObject>>) ((s, i) => new \u003C\u003E__AnonType5<int, GameObject>(i, s))))
      anonType5.s.SetActive(anonType5.i == index);
    if (index >= this.finalDuelCount)
      this.ChangeState(Coloseum02342Menu.States.FINAL_DUEL);
    else if (index > 0)
    {
      this.lastPlayer = this.result.duelResult[this.dueleCount - 1].player;
      this.lastOpponent = this.result.duelResult[this.dueleCount - 1].opponent;
      this.player = this.result.duelResult[this.dueleCount].player;
      this.opponent = this.result.duelResult[this.dueleCount].opponent;
      if (this.lastPlayer == null || this.lastOpponent == null)
        this.ChangeState(Coloseum02342Menu.States.WALKOVER);
      else
        this.ChangeState(Coloseum02342Menu.States.DUEL);
    }
    else
    {
      this.player = this.result.duelResult[this.dueleCount].player;
      this.opponent = this.result.duelResult[this.dueleCount].opponent;
      this.ChangeState(Coloseum02342Menu.States.FIRST_DUEL);
    }
    this.SetMatchupIcon(this.playerMatchUpIcons, this.resultIndex, false);
    this.SetMatchupIcon(this.enemyMatchUpIcons, this.resultIndex, false);
  }

  protected override void Update()
  {
    if (!this.initialized)
      return;
    base.Update();
    if (this.roundButton.activeSelf)
    {
      this.waitTime += Time.deltaTime;
      if ((double) this.WAIT_LIMIT < (double) this.waitTime)
        this.IbtnStartBattle();
    }
    switch (this.state)
    {
      case Coloseum02342Menu.States.FIRST_DUEL:
        this.FirstDuel();
        break;
      case Coloseum02342Menu.States.FINAL_DUEL:
        this.FinalDuel();
        break;
      case Coloseum02342Menu.States.DUEL:
        this.Duel();
        break;
      case Coloseum02342Menu.States.WALKOVER:
        this.Walkover();
        break;
      case Coloseum02342Menu.States.DUEL_RESULT:
        this.DuelResult();
        break;
    }
    if (this.state == this.nextState)
      return;
    this.state = this.nextState;
    switch (this.state)
    {
      case Coloseum02342Menu.States.FIRST_DUEL:
        this.StartCoroutine(this.StartFirstDuel());
        break;
      case Coloseum02342Menu.States.FINAL_DUEL:
        this.StartCoroutine(this.StartFinalDuel());
        break;
      case Coloseum02342Menu.States.DUEL:
        this.StartCoroutine(this.StartDuel());
        break;
      case Coloseum02342Menu.States.WALKOVER:
        this.StartCoroutine(this.StartWalkover());
        break;
      case Coloseum02342Menu.States.DUEL_RESULT:
        this.StartDuelResult();
        break;
    }
  }

  private void ChangeState(Coloseum02342Menu.States nextState) => this.nextState = nextState;

  [DebuggerHidden]
  private IEnumerator StartFirstDuel()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Coloseum02342Menu.\u003CStartFirstDuel\u003Ec__Iterator59C()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator StartDuel()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Coloseum02342Menu.\u003CStartDuel\u003Ec__Iterator59D()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator StartWalkover()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Coloseum02342Menu.\u003CStartWalkover\u003Ec__Iterator59E()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator StartFinalDuel()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Coloseum02342Menu.\u003CStartFinalDuel\u003Ec__Iterator59F()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void StartDuelResult()
  {
  }

  private void FirstDuel()
  {
  }

  private void Duel()
  {
  }

  private void Walkover()
  {
  }

  private void FinalDuel()
  {
  }

  private void DuelResult()
  {
  }

  private void ShowWinOrLoss()
  {
    if (this.result.isWin())
    {
      this.resultEffectType = 1;
      this.SM.playSE("SE_1505");
    }
    else
    {
      this.resultEffectType = 0;
      this.SM.playSE("SE_1506");
    }
    foreach (Component resultAnimation in this.resultAnimations)
      resultAnimation.gameObject.SetActive(false);
    ((Component) this.resultAnimations[this.resultEffectType]).gameObject.SetActive(true);
    ((Component) this.ibtnResult).gameObject.SetActive(true);
    if (!Object.op_Inequality((Object) this.battleResults, (Object) null))
      return;
    this.battleResults.dispReplay(true);
  }

  [DebuggerHidden]
  private IEnumerator SetUnitCharacter(DuelColosseumResult result)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Coloseum02342Menu.\u003CSetUnitCharacter\u003Ec__Iterator5A0()
    {
      result = result,
      \u003C\u0024\u003Eresult = result,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator LoadDuelist(UnitUnit unit, GameObject original, ResourceObject resource)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Coloseum02342Menu.\u003CLoadDuelist\u003Ec__Iterator5A1()
    {
      unit = unit,
      original = original,
      resource = resource,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u0024\u003Eoriginal = original,
      \u003C\u0024\u003Eresource = resource
    };
  }

  [DebuggerHidden]
  private IEnumerator UnitBattleResultAnimation(int index, System.Action CallBack = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Coloseum02342Menu.\u003CUnitBattleResultAnimation\u003Ec__Iterator5A2()
    {
      CallBack = CallBack,
      index = index,
      \u003C\u0024\u003ECallBack = CallBack,
      \u003C\u0024\u003Eindex = index,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator BattleResult()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Coloseum02342Menu.\u003CBattleResult\u003Ec__Iterator5A3()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator BattleResultForSkipDuel()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Coloseum02342Menu.\u003CBattleResultForSkipDuel\u003Ec__Iterator5A4()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator BattleResultForNextDuel()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Coloseum02342Menu.\u003CBattleResultForNextDuel\u003Ec__Iterator5A5()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator BattleResultForFinal()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Coloseum02342Menu.\u003CBattleResultForFinal\u003Ec__Iterator5A6()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void DoAdvanceNextDuel() => this.StartCoroutine(this.AdvanceNextDuel());

  [DebuggerHidden]
  private IEnumerator AdvanceNextDuel()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Coloseum02342Menu.\u003CAdvanceNextDuel\u003Ec__Iterator5A7()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetUnit(GameObject unitPrefab, int duelCount)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Coloseum02342Menu.\u003CSetUnit\u003Ec__Iterator5A8()
    {
      unitPrefab = unitPrefab,
      duelCount = duelCount,
      \u003C\u0024\u003EunitPrefab = unitPrefab,
      \u003C\u0024\u003EduelCount = duelCount,
      \u003C\u003Ef__this = this
    };
  }

  private void SetGrayOut(List<UnitIcon> listPlayer, List<UnitIcon> listEnemy, int targetIndex)
  {
    // ISSUE: object of a compiler-generated type is created
    foreach (\u003C\u003E__AnonType2<UnitIcon, int> anonType2 in listPlayer.Select<UnitIcon, \u003C\u003E__AnonType2<UnitIcon, int>>((Func<UnitIcon, int, \u003C\u003E__AnonType2<UnitIcon, int>>) ((s, i) => new \u003C\u003E__AnonType2<UnitIcon, int>(s, i))))
      anonType2.s.Gray = anonType2.i != targetIndex;
    // ISSUE: object of a compiler-generated type is created
    foreach (\u003C\u003E__AnonType2<UnitIcon, int> anonType2 in listEnemy.Select<UnitIcon, \u003C\u003E__AnonType2<UnitIcon, int>>((Func<UnitIcon, int, \u003C\u003E__AnonType2<UnitIcon, int>>) ((s, i) => new \u003C\u003E__AnonType2<UnitIcon, int>(s, i))))
      anonType2.s.Gray = anonType2.i != targetIndex;
  }

  private void SetMatchupIcon(List<GameObject> list, int index, bool withAnimate = true)
  {
    // ISSUE: object of a compiler-generated type is created
    foreach (\u003C\u003E__AnonType2<GameObject, int> anonType2 in list.Select<GameObject, \u003C\u003E__AnonType2<GameObject, int>>((Func<GameObject, int, \u003C\u003E__AnonType2<GameObject, int>>) ((s, i) => new \u003C\u003E__AnonType2<GameObject, int>(s, i))))
    {
      if (anonType2.i == index)
      {
        anonType2.s.SetActive(true);
        this.playerUnitIcon[anonType2.i].GetComponent<UIPanel>().depth = 3;
        this.enemyUnitIcon[anonType2.i].GetComponent<UIPanel>().depth = 3;
        this.SetGrayOut(this.playerUnitIconC, this.enemyUnitIconC, anonType2.i);
        if (withAnimate)
        {
          switch (anonType2.i)
          {
            case 0:
              this.AnimateTargets(40);
              this.AnimateTargets(41, isReverse: true);
              this.AnimateTargets(42, isReverse: true);
              this.AnimateTargets(43, isReverse: true);
              this.AnimateTargets(44, isReverse: true);
              continue;
            case 1:
              this.AnimateTargets(41);
              this.AnimateTargets(40, isReverse: true);
              this.AnimateTargets(42, isReverse: true);
              this.AnimateTargets(43, isReverse: true);
              this.AnimateTargets(44, isReverse: true);
              continue;
            case 2:
              this.AnimateTargets(42);
              this.AnimateTargets(41, isReverse: true);
              this.AnimateTargets(40, isReverse: true);
              this.AnimateTargets(43, isReverse: true);
              this.AnimateTargets(44, isReverse: true);
              continue;
            case 3:
              this.AnimateTargets(43);
              this.AnimateTargets(41, isReverse: true);
              this.AnimateTargets(42, isReverse: true);
              this.AnimateTargets(40, isReverse: true);
              this.AnimateTargets(44, isReverse: true);
              continue;
            case 4:
              this.AnimateTargets(44);
              this.AnimateTargets(41, isReverse: true);
              this.AnimateTargets(42, isReverse: true);
              this.AnimateTargets(43, isReverse: true);
              this.AnimateTargets(40, isReverse: true);
              continue;
            default:
              continue;
          }
        }
      }
      else
      {
        anonType2.s.SetActive(false);
        this.playerUnitIcon[anonType2.i].GetComponent<UIPanel>().depth = 2;
        this.enemyUnitIcon[anonType2.i].GetComponent<UIPanel>().depth = 2;
      }
    }
  }

  [DebuggerHidden]
  private IEnumerator LoadMatchIcon(GameObject go, ResourceObject ro, List<GameObject> list)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Coloseum02342Menu.\u003CLoadMatchIcon\u003Ec__Iterator5A9()
    {
      ro = ro,
      list = list,
      go = go,
      \u003C\u0024\u003Ero = ro,
      \u003C\u0024\u003Elist = list,
      \u003C\u0024\u003Ego = go
    };
  }

  private UnitIcon InitializeUnitIcon(GameObject unitPrefab, GameObject unit)
  {
    foreach (Component component in unit.transform)
      Object.Destroy((Object) component.gameObject);
    return unitPrefab.Clone(unit.transform).GetComponent<UnitIcon>();
  }

  [DebuggerHidden]
  private IEnumerator SetUnitIcon(BL.Unit unit, UnitIcon icon, List<UnitIcon> list)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Coloseum02342Menu.\u003CSetUnitIcon\u003Ec__Iterator5AA()
    {
      unit = unit,
      icon = icon,
      list = list,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u0024\u003Eicon = icon,
      \u003C\u0024\u003Elist = list
    };
  }

  private void SetBuff(GameObject go, int before, int after)
  {
    GameObject[] array = go.transform.GetChildren().Select<Transform, GameObject>((Func<Transform, GameObject>) (x => ((Component) x).gameObject)).ToArray<GameObject>();
    if (after < before)
    {
      array[0].SetActive(true);
      array[1].SetActive(false);
    }
    else if (after > before)
    {
      array[0].SetActive(false);
      array[1].SetActive(true);
    }
    else
    {
      array[0].SetActive(false);
      array[1].SetActive(false);
    }
  }

  private void SetBattleParam(int duelCount)
  {
    duelCount = Mathf.Min(duelCount, 4);
    DuelColosseumResult duelColosseumResult = this.result.duelResult[duelCount];
    bool flag = duelColosseumResult.player != null && duelColosseumResult.opponent != null;
    if (duelColosseumResult.player != null)
    {
      CommonElement element = duelColosseumResult.player.playerUnit.equippedGearOrInitial.GetElement();
      if (duelColosseumResult.player.playerUnit.equippedGear != (PlayerItem) null)
        element = duelColosseumResult.player.playerUnit.equippedGear.GetElement();
      this.playerGearKindIcon.Init(duelColosseumResult.player.playerUnit.equippedGearOrInitial.kind, element);
      ((Component) this.playerElementIcon).gameObject.SetActive(true);
      this.playerElementIcon.Init(duelColosseumResult.player.unit.kind, duelColosseumResult.player.GetElement());
      ((Component) this.TxtCharaname).gameObject.SetActive(false);
      ((Component) this.TxtCharaname_ElementOn).gameObject.SetActive(true);
      this.TxtCharaname_ElementOn.SetTextLocalize(duelColosseumResult.player.playerUnit.unit.name);
      this.TxtWeaponNameOwn.SetTextLocalize(duelColosseumResult.player.playerUnit.equippedGearName);
      this.TxtHPOwn.SetTextLocalize(duelColosseumResult.player.hp.ToLocalizeNumberText());
      this.TxtAttackOwn.SetTextLocalize(!flag ? "-" : duelColosseumResult.playerAttackStatus.attack.ToLocalizeNumberText());
      this.TxtDexterityOwn.SetTextLocalize(!flag ? "-" : duelColosseumResult.playerAttackStatus.dexerityDisplay().ToLocalizeNumberText() + "％");
      this.TxtCriticalOwn.SetTextLocalize(!flag ? "-" : duelColosseumResult.playerAttackStatus.criticalDisplay().ToLocalizeNumberText() + "％");
      int num = !flag ? 1 : NC.Clamp(1, 4, duelColosseumResult.playerAttackStatus.attackCount);
      for (int index = 0; index < this.playerAttackValues.Length; ++index)
        this.playerAttackValues[index].SetActive(flag && index + 2 == num);
      if (flag)
      {
        this.SetBuff(this.statusBuffOwn, duelColosseumResult.playerBeforeBonusParam.HP, duelColosseumResult.player.hp);
        this.SetBuff(this.attackBuffOwn, duelColosseumResult.playerBeforeBonusParam.attack, duelColosseumResult.playerAttackStatus.attack);
        this.SetBuff(this.dexterityBuffOwn, duelColosseumResult.playerBeforeBonusParam.dexerityDisplay, duelColosseumResult.playerAttackStatus.dexerityDisplay());
        this.SetBuff(this.criticalBuffOwn, duelColosseumResult.playerBeforeBonusParam.criticalDisplay, duelColosseumResult.playerAttackStatus.criticalDisplay());
        this.SetValueColor(this.TxtAttackOwn, duelColosseumResult.playerBeforeBonusParam.attack, duelColosseumResult.playerAttackStatus.attack);
        this.SetValueColor(this.TxtDexterityOwn, duelColosseumResult.playerBeforeBonusParam.dexerityDisplay, duelColosseumResult.playerAttackStatus.dexerityDisplay());
        this.SetValueColor(this.TxtCriticalOwn, duelColosseumResult.playerBeforeBonusParam.criticalDisplay, duelColosseumResult.playerAttackStatus.criticalDisplay());
      }
    }
    else
    {
      this.TxtCharaname.SetTextLocalize("-");
      this.TxtCharaname_ElementOn.SetTextLocalize("-");
      this.TxtHPOwn.SetTextLocalize("-");
      this.TxtWeaponNameOwn.SetTextLocalize(string.Empty);
      this.TxtAttackOwn.SetTextLocalize("-");
      this.TxtDexterityOwn.SetTextLocalize("-");
      this.TxtCriticalOwn.SetTextLocalize("-");
      ((IEnumerable<GameObject>) this.playerAttackValues).ForEach<GameObject>((Action<GameObject>) (v => v.SetActive(false)));
      this.TxtAttackOwn.color = new Color((float) byte.MaxValue, (float) byte.MaxValue, (float) byte.MaxValue);
      this.SetBuff(this.criticalBuffOwn, 0, 0);
      this.SetBuff(this.dexterityBuffOwn, 0, 0);
      this.SetBuff(this.attackBuffOwn, 0, 0);
      this.SetBuff(this.statusBuffOwn, 0, 0);
      this.SetValueColor(this.TxtAttackOwn);
      this.SetValueColor(this.TxtDexterityOwn);
      this.SetValueColor(this.TxtCriticalOwn);
      ((Component) this.playerElementIcon).gameObject.SetActive(false);
      ((Component) ((Component) this.playerKind).GetComponentInChildren<GearKindIcon>()).GetComponent<UI2DSprite>().sprite2D = (Sprite) null;
    }
    if (duelColosseumResult.opponent != null)
    {
      CommonElement element = duelColosseumResult.opponent.playerUnit.equippedGearOrInitial.GetElement();
      if (duelColosseumResult.opponent.playerUnit.equippedGear != (PlayerItem) null)
        element = duelColosseumResult.opponent.playerUnit.equippedGear.GetElement();
      this.enemyGearKindIcon.Init(duelColosseumResult.opponent.playerUnit.equippedGearOrInitial.kind, element);
      ((Component) this.enemyElementIcon).gameObject.SetActive(true);
      this.enemyElementIcon.Init(duelColosseumResult.opponent.unit.kind, duelColosseumResult.opponent.GetElement());
      ((Component) this.TxtUnitNameEnemy).gameObject.SetActive(false);
      ((Component) this.TxtUnitNameEnemy_ElementOn).gameObject.SetActive(true);
      this.TxtUnitNameEnemy_ElementOn.SetText(duelColosseumResult.opponent.playerUnit.unit.name);
      this.TxtWeaponNameEnemy.SetTextLocalize(duelColosseumResult.opponent.playerUnit.equippedGearName);
      this.TxtHPEnemy.SetTextLocalize(duelColosseumResult.opponent.hp.ToLocalizeNumberText());
      this.TxtAttack.SetTextLocalize(!flag ? "-" : duelColosseumResult.opponentAttackStatus.attack.ToLocalizeNumberText());
      this.TxtDexterityEnemy.SetTextLocalize(!flag ? "-" : duelColosseumResult.opponentAttackStatus.dexerityDisplay().ToLocalizeNumberText() + "％");
      this.TxtCriticalEnemy.SetTextLocalize(!flag ? "-" : duelColosseumResult.opponentAttackStatus.criticalDisplay().ToLocalizeNumberText() + "％");
      int num = !flag ? 1 : NC.Clamp(1, 4, duelColosseumResult.opponentAttackStatus.attackCount);
      for (int index = 0; index < this.enemyAttackValues.Length; ++index)
        this.enemyAttackValues[index].SetActive(flag && index + 2 == num);
      if (flag)
      {
        this.SetBuff(this.statusBuffEnemy, duelColosseumResult.opponentBeforeBonusParam.HP, duelColosseumResult.opponent.hp);
        this.SetBuff(this.attackBuffEnemy, duelColosseumResult.opponentBeforeBonusParam.attack, duelColosseumResult.opponentAttackStatus.attack);
        this.SetBuff(this.dexterityBuffEnemy, duelColosseumResult.opponentBeforeBonusParam.dexerityDisplay, duelColosseumResult.opponentAttackStatus.dexerityDisplay());
        this.SetBuff(this.criticalBuffEnemy, duelColosseumResult.opponentBeforeBonusParam.criticalDisplay, duelColosseumResult.opponentAttackStatus.criticalDisplay());
        this.SetValueColor(this.TxtAttack, duelColosseumResult.opponentBeforeBonusParam.attack, duelColosseumResult.opponentAttackStatus.attack);
        this.SetValueColor(this.TxtDexterityEnemy, duelColosseumResult.opponentBeforeBonusParam.dexerityDisplay, duelColosseumResult.opponentAttackStatus.dexerityDisplay());
        this.SetValueColor(this.TxtCriticalEnemy, duelColosseumResult.opponentBeforeBonusParam.criticalDisplay, duelColosseumResult.opponentAttackStatus.criticalDisplay());
      }
    }
    else
    {
      this.TxtUnitNameEnemy.SetTextLocalize("-");
      this.TxtUnitNameEnemy_ElementOn.SetText("-");
      this.TxtHPEnemy.SetTextLocalize("-");
      this.TxtWeaponNameEnemy.SetTextLocalize(string.Empty);
      this.TxtAttack.SetTextLocalize("-");
      this.TxtDexterityEnemy.SetTextLocalize("-");
      this.TxtCriticalEnemy.SetTextLocalize("-");
      ((IEnumerable<GameObject>) this.enemyAttackValues).ForEach<GameObject>((Action<GameObject>) (v => v.SetActive(false)));
      this.TxtAttack.color = new Color((float) byte.MaxValue, (float) byte.MaxValue, (float) byte.MaxValue);
      this.SetBuff(this.criticalBuffEnemy, 0, 0);
      this.SetBuff(this.dexterityBuffEnemy, 0, 0);
      this.SetBuff(this.attackBuffEnemy, 0, 0);
      this.SetBuff(this.statusBuffEnemy, 0, 0);
      this.SetValueColor(this.TxtAttack);
      this.SetValueColor(this.TxtDexterityEnemy);
      this.SetValueColor(this.TxtCriticalEnemy);
      ((Component) this.enemyElementIcon).gameObject.SetActive(false);
      ((Component) ((Component) this.enemyKind).GetComponentInChildren<GearKindIcon>()).GetComponent<UI2DSprite>().sprite2D = (Sprite) null;
    }
    ((IEnumerable<GameObject>) this.playerAttackAdvantage).ForEach<GameObject>((Action<GameObject>) (v => v.SetActive(false)));
    ((IEnumerable<GameObject>) this.enemyAttackAdvantage).ForEach<GameObject>((Action<GameObject>) (v => v.SetActive(false)));
    if (!flag)
      return;
    switch (this.CheckAdvantage(duelColosseumResult.player.playerUnit.unit.kind_GearKind, duelColosseumResult.opponent.playerUnit.unit.kind_GearKind))
    {
      case Coloseum02342Menu.Advantage.HIGHER:
        this.playerAttackAdvantage[0].SetActive(true);
        this.enemyAttackAdvantage[1].SetActive(true);
        break;
      case Coloseum02342Menu.Advantage.LOWER:
        this.playerAttackAdvantage[1].SetActive(true);
        this.enemyAttackAdvantage[0].SetActive(true);
        break;
    }
  }

  private void SetValueColor(UILabel label, int before = 0, int after = 0)
  {
    if (before > after)
      label.color = new Color((float) byte.MaxValue, 0.0f, 0.0f);
    else if (before < after)
      label.color = new Color((float) byte.MaxValue, (float) byte.MaxValue, 0.0f);
    else
      label.color = new Color((float) byte.MaxValue, (float) byte.MaxValue, (float) byte.MaxValue);
  }

  private Coloseum02342Menu.Advantage CheckAdvantage(int attack, int defense)
  {
    GearKindCorrelations kindCorrelations = ((IEnumerable<GearKindCorrelations>) MasterData.GearKindCorrelationsList).SingleOrDefault<GearKindCorrelations>((Func<GearKindCorrelations, bool>) (x => x.attacker.ID == attack && x.defender.ID == defense));
    if (kindCorrelations == null)
      return Coloseum02342Menu.Advantage.NONE;
    return kindCorrelations.is_advantage ? Coloseum02342Menu.Advantage.HIGHER : Coloseum02342Menu.Advantage.LOWER;
  }

  private UnitIcon.ColosseumResult[] ChangeResultEnum(DuelColosseumResult result)
  {
    return result.judgment == 0 ? new UnitIcon.ColosseumResult[2]
    {
      UnitIcon.ColosseumResult.DROW,
      UnitIcon.ColosseumResult.DROW
    } : (result.judgment == 1 ? new UnitIcon.ColosseumResult[2]
    {
      UnitIcon.ColosseumResult.WIN,
      UnitIcon.ColosseumResult.LOSE
    } : new UnitIcon.ColosseumResult[2]
    {
      UnitIcon.ColosseumResult.LOSE,
      UnitIcon.ColosseumResult.WIN
    });
  }

  [DebuggerHidden]
  private IEnumerator StartRoundButton(float delay)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Coloseum02342Menu.\u003CStartRoundButton\u003Ec__Iterator5AB()
    {
      delay = delay,
      \u003C\u0024\u003Edelay = delay,
      \u003C\u003Ef__this = this
    };
  }

  private void StartRoundButtonY()
  {
    iTween.ScaleTo(this.roundButtonAnimate, iTween.Hash((object) "y", (object) 1f, (object) "time", (object) 0.2f, (object) "easetype", (object) iTween.EaseType.easeInCubic));
    this.BtnSkip.SetActive(true);
    this.SkipPermission = true;
  }

  public void IbtnStartBattle()
  {
    this.roundButton.SetActive(false);
    this.SkipPermission = false;
    this.BtnSkip.SetActive(false);
    this.SM.playSE("SE_1030");
    if (this.player == null || this.opponent == null || this.isSkip)
      this.scene.Reinitialize();
    else
      this.StartCoroutine(this.ChangeDuelScene());
  }

  [DebuggerHidden]
  private IEnumerator ChangeDuelScene()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Coloseum02342Menu.\u003CChangeDuelScene\u003Ec__Iterator5AC()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void AnimateTargets(int id, bool isPlay = true, bool isReverse = false)
  {
    ((IEnumerable<UITweener>) ((Component) this).gameObject.GetComponentsInChildren<UITweener>()).Where<UITweener>((Func<UITweener, bool>) (v => v.tweenGroup == id)).ForEach<UITweener>((Action<UITweener>) (v2 =>
    {
      if (isReverse)
      {
        v2.PlayReverse();
      }
      else
      {
        v2.ResetToBeginning();
        if (!isPlay)
          return;
        v2.PlayForward();
      }
    }));
  }

  [DebuggerHidden]
  public IEnumerator UpdateDuelist(int index)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Coloseum02342Menu.\u003CUpdateDuelist\u003Ec__Iterator5AD()
    {
      index = index,
      \u003C\u0024\u003Eindex = index,
      \u003C\u003Ef__this = this
    };
  }

  private void SetBonus(Bonus[] bonus, GameObject go, UILabel label)
  {
    if (bonus != null && bonus.Length != 0)
    {
      new BonusDisplay().Set(bonus, label, (UILabel) null);
      go.SetActive(true);
    }
    else
      go.SetActive(false);
  }

  public void GoToResult()
  {
    Colosseum02346Scene.ChangeScene(this.info, this.result, this.gladiator);
  }

  [DebuggerHidden]
  private IEnumerator SetEmblem(UI2DSprite emblem, int id = 0)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Coloseum02342Menu.\u003CSetEmblem\u003Ec__Iterator5AE()
    {
      id = id,
      emblem = emblem,
      \u003C\u0024\u003Eid = id,
      \u003C\u0024\u003Eemblem = emblem
    };
  }

  public void IbtnBack()
  {
  }

  public override void onBackButton()
  {
  }

  public void StartSkipMode()
  {
    if (!this.SkipPermission)
      return;
    this.isSkip = true;
    this.IbtnStartBattle();
  }

  public void Replay()
  {
    this.isSkip = false;
    this.BtnSkip.SetActive(true);
    this.ResetUnitIcons(this.playerUnitIconC);
    this.ResetUnitIcons(this.enemyUnitIconC);
    ((Component) this.resultAnimations[0]).gameObject.SetActive(false);
    ((Component) this.resultAnimations[1]).gameObject.SetActive(false);
    ((Component) this.ibtnResult).gameObject.SetActive(false);
    if (Object.op_Inequality((Object) this.battleResults, (Object) null))
    {
      this.battleResults.dispReplay(false);
      this.dirResult.gameObject.SetActive(false);
    }
    this.scene.ReplayScene();
  }

  private void ResetUnitIcons(List<UnitIcon> unitIcons)
  {
    unitIcons.ForEach((Action<UnitIcon>) (x => x.SetColosseumResult(UnitIcon.ColosseumResult.NONE)));
    foreach (Component unitIcon in unitIcons)
    {
      foreach (Object componentsInChild in unitIcon.GetComponentsInChildren<iTween>())
        Object.Destroy(componentsInChild);
    }
  }

  private enum Advantage
  {
    NONE,
    HIGHER,
    LOWER,
  }

  private enum DuelEffects
  {
    STAYED,
    RUNKUP,
    RUNKDOW,
  }

  private enum ResultEffects
  {
    LOSE,
    WIN,
  }

  private enum States
  {
    DEFAULT,
    FIRST_DUEL,
    FINAL_DUEL,
    DUEL,
    WALKOVER,
    DUEL_RESULT,
  }
}
