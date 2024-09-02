// Decompiled with JetBrains decompiler
// Type: Colosseum0234Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Colosseum0234Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtCustomeName;
  [SerializeField]
  protected UILabel TxtCustomeName2;
  [SerializeField]
  protected UILabel TxtCustomeName3;
  [SerializeField]
  protected UILabel TxtFightnum;
  [SerializeField]
  protected UILabel TxtFightnum2;
  [SerializeField]
  protected UILabel TxtFightnum3;
  [SerializeField]
  protected UILabel TxtLVnumber;
  [SerializeField]
  protected UILabel TxtLVnumber2;
  [SerializeField]
  protected UILabel TxtLVnumber3;
  [SerializeField]
  protected UILabel TxtRankBattle01;
  [SerializeField]
  protected UILabel TxtRankBattle02;
  [SerializeField]
  protected UILabel TxtRankname;
  [SerializeField]
  protected UILabel TxtRankname2;
  [SerializeField]
  protected UILabel TxtRankname3;
  [SerializeField]
  protected UILabel TxtRankpt;
  [SerializeField]
  protected UILabel TxtRankpt2;
  [SerializeField]
  protected UILabel TxtRankpt3;
  [SerializeField]
  private UIButton ibtnRanking;
  [SerializeField]
  private GameObject dirScrollText;
  [SerializeField]
  private GameObject firstBottomObject;
  [SerializeField]
  private GameObject secondBottomObject;
  [SerializeField]
  private GameObject[] unitIcons;
  [SerializeField]
  private GameObject bgCharacter;
  [SerializeField]
  private float matchingChangeTime = 0.3f;
  [SerializeField]
  private GameObject[] opponentUnitIcons;
  [SerializeField]
  private GameObject[] opponentUnitIconsBase;
  [SerializeField]
  private UIButton opponentUpdateButton;
  [SerializeField]
  private GameObject DirBonus;
  [SerializeField]
  private UILabel bonusText;
  [SerializeField]
  private UILabel bonusLimitText;
  [SerializeField]
  private UILabel liderSkillText;
  [SerializeField]
  private GameObject selectButton;
  [SerializeField]
  private GameObject repairButton;
  private Colosseum0234Status statusWnd;
  private bool isRepair;
  private GameObject ScrollTextPrefab;
  private ColosseumUtility.Info colosseumInfo;
  private int[] opponents;
  private GameObject unitPrefab;
  public Dictionary<int, UnitIcon.SpriteCache> unitIconCache;
  private GameObject nowPopup;
  private Colosseum0234Menu.HeaderType headerType;
  private Colosseum0234Scene scene;

  public int[] Opponents => this.opponents;

  public override void onBackButton()
  {
    if (this.headerType == Colosseum0234Menu.HeaderType.HOME)
      this.IbtnHome();
    else
      this.IbtnBack();
  }

  private void WarningYesBtn() => this.StartCoroutine(this.Resume());

  private void WarningNoBtn()
  {
    this.nowPopup = ((Component) ModalWindow.ShowYesNo(Consts.GetInstance().COLOSSEUM_RESUME_TITLE2, Consts.GetInstance().COLOSSEUM_RESUME_MESSAGE2_1, new System.Action(this.ConfirmationYesBtn), new System.Action(this.ConfirmationNoBtn))).gameObject;
  }

  private void ConfirmationYesBtn() => this.StartCoroutine(this.Destory());

  private void ConfirmationNoBtn()
  {
    Object.DestroyObject((Object) this.nowPopup);
    this.nowPopup = ((Component) ModalWindow.ShowYesNo(Consts.GetInstance().COLOSSEUM_RESUME_TITLE1, Consts.GetInstance().COLOSSEUM_RESUME_MESSAGE1, new System.Action(this.WarningYesBtn), new System.Action(this.WarningNoBtn))).gameObject;
  }

  private void DestoryYesBtn()
  {
    this.colosseumInfo.is_battle = false;
    Object.DestroyObject((Object) this.nowPopup);
    this.StartCoroutine(this.Restart());
  }

  [DebuggerHidden]
  private IEnumerator Restart()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum0234Menu.\u003CRestart\u003Ec__Iterator5D5()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator Resume()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum0234Menu.\u003CResume\u003Ec__Iterator5D6()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator Destory()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum0234Menu.\u003CDestory\u003Ec__Iterator5D7()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void NotGladiators()
  {
    Object.DestroyObject((Object) this.nowPopup);
    this.IbtnHome();
  }

  [DebuggerHidden]
  private IEnumerator SetLiderSkillInfo()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum0234Menu.\u003CSetLiderSkillInfo\u003Ec__Iterator5D8()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Initialize(
    Colosseum0234Scene scene,
    ColosseumUtility.Info colosseumInfo,
    int[] opponents,
    bool isTutorial,
    RankingPlayer myRanking)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum0234Menu.\u003CInitialize\u003Ec__Iterator5D9()
    {
      scene = scene,
      colosseumInfo = colosseumInfo,
      opponents = opponents,
      myRanking = myRanking,
      isTutorial = isTutorial,
      \u003C\u0024\u003Escene = scene,
      \u003C\u0024\u003EcolosseumInfo = colosseumInfo,
      \u003C\u0024\u003Eopponents = opponents,
      \u003C\u0024\u003EmyRanking = myRanking,
      \u003C\u0024\u003EisTutorial = isTutorial,
      \u003C\u003Ef__this = this
    };
  }

  private bool EquipBrokenWeapon()
  {
    PlayerDeck deck = this.GetDeck();
    bool flag = false;
    foreach (PlayerUnit playerUnit in deck.player_units)
    {
      if (playerUnit != (PlayerUnit) null && playerUnit.equippedGear != (PlayerItem) null)
        flag |= playerUnit.equippedGear.broken;
    }
    return flag;
  }

  [DebuggerHidden]
  private IEnumerator SetBgCharacter()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum0234Menu.\u003CSetBgCharacter\u003Ec__Iterator5DA()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetUnitIcon()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum0234Menu.\u003CSetUnitIcon\u003Ec__Iterator5DB()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetOther()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum0234Menu.\u003CSetOther\u003Ec__Iterator5DC()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void SetOpponents(int[] oppnets = null)
  {
    int num = 3;
    if (oppnets != null)
      this.opponents = oppnets;
    else if (this.colosseumInfo.gladiators.Length < 3 && this.colosseumInfo.gladiators.Length >= 1)
    {
      num = this.colosseumInfo.gladiators.Length;
      this.opponents = this.GetRandomShuffle(this.colosseumInfo.gladiators.Length, this.colosseumInfo.gladiators.Length);
    }
    else
      this.opponents = this.GetRandomShuffle(3, this.colosseumInfo.gladiators.Length);
    this.opponentUnitIconsBase[0].SetActive(false);
    this.opponentUnitIconsBase[1].SetActive(false);
    this.opponentUnitIconsBase[2].SetActive(false);
    if (this.colosseumInfo.next_battle_type == 0)
    {
      for (int index = 0; index < num; ++index)
      {
        Gladiator gladiator = this.colosseumInfo.gladiators[this.opponents[index]];
        this.opponentUnitIconsBase[index].SetActive(true);
        switch (index)
        {
          case 0:
            this.TxtCustomeName.SetText(gladiator.name.ToConverter());
            this.TxtFightnum.SetText(gladiator.total_power.ToLocalizeNumberText());
            this.TxtLVnumber.SetText(gladiator.player_level.ToLocalizeNumberText());
            this.TxtRankname.SetText(ColosseumUtility.GetRankName(gladiator.rank_pt));
            this.TxtRankpt.SetText(gladiator.rank_pt.ToLocalizeNumberText());
            break;
          case 1:
            this.TxtCustomeName2.SetText(gladiator.name.ToConverter());
            this.TxtFightnum2.SetText(gladiator.total_power.ToLocalizeNumberText());
            this.TxtLVnumber2.SetText(gladiator.player_level.ToLocalizeNumberText());
            this.TxtRankname2.SetText(ColosseumUtility.GetRankName(gladiator.rank_pt));
            this.TxtRankpt2.SetText(gladiator.rank_pt.ToLocalizeNumberText());
            break;
          default:
            this.TxtCustomeName3.SetText(gladiator.name.ToConverter());
            this.TxtFightnum3.SetText(gladiator.total_power.ToLocalizeNumberText());
            this.TxtLVnumber3.SetText(gladiator.player_level.ToLocalizeNumberText());
            this.TxtRankname3.SetText(ColosseumUtility.GetRankName(gladiator.rank_pt));
            this.TxtRankpt3.SetText(gladiator.rank_pt.ToLocalizeNumberText());
            break;
        }
        foreach (Component component in this.opponentUnitIcons[index].transform)
          Object.Destroy((Object) component.gameObject);
        UnitIcon component1 = this.unitPrefab.Clone(this.opponentUnitIcons[index].transform).GetComponent<UnitIcon>();
        if (Object.op_Inequality((Object) component1, (Object) null))
          component1.setColosseumMatchingUnit(gladiator.leader_unit_id, gladiator.leader_unit_level, this.unitIconCache);
      }
    }
    else if (this.colosseumInfo.next_battle_type == 1)
    {
      this.opponentUnitIconsBase[1].SetActive(true);
      Gladiator gladiator = this.colosseumInfo.gladiators[this.colosseumInfo.gladiators.Length - 2];
      this.TxtCustomeName2.SetText(gladiator.name.ToConverter());
      this.TxtFightnum2.SetText(gladiator.total_power.ToLocalizeNumberText());
      this.TxtLVnumber2.SetText(gladiator.player_level.ToLocalizeNumberText());
      this.TxtRankname2.SetText(ColosseumUtility.GetRankName(gladiator.rank_pt));
      this.TxtRankpt2.SetText(gladiator.rank_pt.ToLocalizeNumberText());
      foreach (Component component in this.opponentUnitIcons[1].transform)
        Object.Destroy((Object) component.gameObject);
      UnitIcon component2 = this.unitPrefab.Clone(this.opponentUnitIcons[1].transform).GetComponent<UnitIcon>();
      if (!Object.op_Inequality((Object) component2, (Object) null))
        return;
      component2.setColosseumMatchingUnit(gladiator.leader_unit_id, gladiator.leader_unit_level, this.unitIconCache);
    }
    else
    {
      if (this.colosseumInfo.next_battle_type != 2)
        return;
      this.opponentUnitIconsBase[1].SetActive(true);
      Gladiator gladiator = this.colosseumInfo.gladiators[this.colosseumInfo.gladiators.Length - 1];
      this.TxtCustomeName2.SetText(gladiator.name.ToConverter());
      this.TxtFightnum2.SetText(gladiator.total_power.ToLocalizeNumberText());
      this.TxtLVnumber2.SetText(gladiator.player_level.ToLocalizeNumberText());
      this.TxtRankname2.SetText(ColosseumUtility.GetRankName(gladiator.rank_pt));
      this.TxtRankpt2.SetText(gladiator.rank_pt.ToLocalizeNumberText());
      foreach (Component component in this.opponentUnitIcons[1].transform)
        Object.Destroy((Object) component.gameObject);
      UnitIcon component3 = this.unitPrefab.Clone(this.opponentUnitIcons[1].transform).GetComponent<UnitIcon>();
      if (!Object.op_Inequality((Object) component3, (Object) null))
        return;
      component3.setColosseumMatchingUnit(gladiator.leader_unit_id, gladiator.leader_unit_level, this.unitIconCache);
    }
  }

  public virtual void IbtnCombine()
  {
    if (this.colosseumInfo.gladiators == null || this.colosseumInfo.gladiators.Length == 0)
    {
      this.nowPopup = ((Component) ModalWindow.Show(Consts.GetInstance().COLOSSEUM_NOT_GLADIATORS_TITLE, Consts.GetInstance().COLOSSEUM_NOT_GLADIATORS_MESSAGE3, new System.Action(this.NotGladiators))).gameObject;
    }
    else
    {
      PlayerDeck deck = this.GetDeck();
      if (((IEnumerable<PlayerUnit>) deck.player_units).Where<PlayerUnit>((Func<PlayerUnit, bool>) (v => v != (PlayerUnit) null)).Count<PlayerUnit>() <= 2)
        this.StartCoroutine(this.ShowUnitAlertPopup());
      else if (deck.cost > deck.cost_limit)
      {
        this.nowPopup = ((Component) ModalWindow.Show(Consts.GetInstance().VERSUS_00262POPUP_COSTOVER_TITLE, Consts.GetInstance().VERSUS_00262POPUP_COSTOVER_DESCRIPTION, (System.Action) (() => { }))).gameObject;
      }
      else
      {
        iTween.ValueTo(((Component) this).gameObject, iTween.Hash((object) "from", (object) 1f, (object) "to", (object) 0.0f, (object) "time", (object) this.matchingChangeTime, (object) "onupdate", (object) "FirstBottomUpdate", (object) "oncomplete", (object) "FirstBottomFinishEnd"));
        Singleton<CommonRoot>.GetInstance().isTouchBlock = true;
      }
    }
  }

  public virtual void IbtnRepair()
  {
    if (this.IsPushAndSet())
      return;
    Bugu00524Scene.ChangeScene(true);
  }

  public virtual void IbtnWarExperience()
  {
    if (this.IsPushAndSet())
      return;
    Colosseum0236Scene.ChangeScene(this.colosseumInfo);
  }

  public virtual void IbtnRanking()
  {
    if (this.IsPushAndSet())
      return;
    Colosseum02371Scene.ChangeScene(this.colosseumInfo);
  }

  public virtual void IbtnOrganization()
  {
    if (this.IsPushAndSet())
      return;
    Unit0046Scene.changeScene(false, this.colosseumInfo);
  }

  public virtual void IbtnCostomerUnit() => this.SelectOpponent(0);

  public virtual void IbtnCostomerUnit2() => this.SelectOpponent(1);

  public virtual void IbtnCostomerUnit3() => this.SelectOpponent(2);

  public void IbtnHome()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().clearStack();
    Singleton<NGSceneManager>.GetInstance().destroyCurrentScene();
    MypageScene.ChangeScene(false);
  }

  public void IbtnBack()
  {
    iTween.ValueTo(((Component) this).gameObject, iTween.Hash((object) "from", (object) 1f, (object) "to", (object) 0.0f, (object) "time", (object) this.matchingChangeTime, (object) "onupdate", (object) "SecondBottomUpdate", (object) "oncomplete", (object) "SecondBottomFinishEnd"));
    Singleton<CommonRoot>.GetInstance().isTouchBlock = true;
  }

  public void IbtnOpponentUpdate()
  {
    this.SetOpponents();
    this.opponentUpdateButton.isEnabled = false;
    this.StartCoroutine(this.WaitOpponentUpdateButton());
  }

  [DebuggerHidden]
  private IEnumerator WaitOpponentUpdateButton()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum0234Menu.\u003CWaitOpponentUpdateButton\u003Ec__Iterator5DD()
    {
      \u003C\u003Ef__this = this
    };
  }

  private PlayerDeck GetDeck()
  {
    PlayerDeck[] playerDeckArray = SMManager.Get<PlayerDeck[]>();
    if (((IEnumerable<PlayerUnit>) playerDeckArray[Persist.colosseumDeckOrganized.Data.number].player_units).FirstOrDefault<PlayerUnit>() == (PlayerUnit) null)
    {
      Persist.colosseumDeckOrganized.Data.number = 0;
      Persist.colosseumDeckOrganized.Flush();
    }
    return playerDeckArray[Persist.colosseumDeckOrganized.Data.number];
  }

  private void FirstBottomStartEnd() => Singleton<CommonRoot>.GetInstance().isTouchBlock = false;

  private void FirstBottomUpdate(float value)
  {
    this.firstBottomObject.GetComponent<UIWidget>().alpha = value;
  }

  private void FirstBottomFinishEnd()
  {
    this.firstBottomObject.SetActive(false);
    this.secondBottomObject.SetActive(true);
    this.secondBottomObject.GetComponent<UIWidget>().alpha = 0.0f;
    this.SetOpponents();
    iTween.ValueTo(((Component) this).gameObject, iTween.Hash((object) "from", (object) 0.0f, (object) "to", (object) 1f, (object) "time", (object) this.matchingChangeTime, (object) "onupdate", (object) "SecondBottomUpdate", (object) "oncomplete", (object) "SecondBottomStartEnd"));
    this.StartCoroutine(this.ChangeHeader(Colosseum0234Menu.HeaderType.MATCHING));
    if (!this.colosseumInfo.is_tutorial || Persist.colosseumTutorial.Data.CurrentPage != 1)
      return;
    Persist.colosseumTutorial.Data.CurrentPage = 2;
    Singleton<TutorialRoot>.GetInstance().ForceShowAdvice("colosseum2");
  }

  private void SecondBottomStartEnd() => Singleton<CommonRoot>.GetInstance().isTouchBlock = false;

  private void SecondBottomUpdate(float value)
  {
    this.secondBottomObject.GetComponent<UIWidget>().alpha = value;
  }

  private void SecondBottomFinishEnd()
  {
    this.firstBottomObject.SetActive(true);
    this.secondBottomObject.SetActive(false);
    this.firstBottomObject.GetComponent<UIWidget>().alpha = 0.0f;
    this.opponents = (int[]) null;
    iTween.ValueTo(((Component) this).gameObject, iTween.Hash((object) "from", (object) 0.0f, (object) "to", (object) 1f, (object) "time", (object) this.matchingChangeTime, (object) "onupdate", (object) "FirstBottomUpdate", (object) "oncomplete", (object) "FirstBottomStartEnd"));
    this.StartCoroutine(this.ChangeHeader(Colosseum0234Menu.HeaderType.HOME));
  }

  private int[] GetRandomShuffle(int arrayMax, int rangeMax)
  {
    int[] source = new int[rangeMax];
    for (int index = 0; index < source.Length; ++index)
      source[index] = index;
    int[] array = ((IEnumerable<int>) source).OrderBy<int, Guid>((Func<int, Guid>) (i => Guid.NewGuid())).ToArray<int>();
    int[] destinationArray = new int[arrayMax];
    Array.Copy((Array) array, (Array) destinationArray, arrayMax);
    return destinationArray;
  }

  [DebuggerHidden]
  private IEnumerator ChangeHeader(Colosseum0234Menu.HeaderType type)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum0234Menu.\u003CChangeHeader\u003Ec__Iterator5DE()
    {
      type = type,
      \u003C\u0024\u003Etype = type,
      \u003C\u003Ef__this = this
    };
  }

  private void SelectOpponent(int index)
  {
    if (SMManager.Get<Player>().bp < 1)
      this.StartCoroutine(this.ShowCPAlertPopup());
    else
      this.StartCoroutine(this.BattleStart(index));
  }

  [DebuggerHidden]
  private IEnumerator BattleStart(int index)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum0234Menu.\u003CBattleStart\u003Ec__Iterator5DF()
    {
      index = index,
      \u003C\u0024\u003Eindex = index,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ShowCPAlertPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Colosseum0234Menu.\u003CShowCPAlertPopup\u003Ec__Iterator5E0 popupCIterator5E0 = new Colosseum0234Menu.\u003CShowCPAlertPopup\u003Ec__Iterator5E0();
    return (IEnumerator) popupCIterator5E0;
  }

  [DebuggerHidden]
  private IEnumerator ShowCPErrorPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Colosseum0234Menu.\u003CShowCPErrorPopup\u003Ec__Iterator5E1 popupCIterator5E1 = new Colosseum0234Menu.\u003CShowCPErrorPopup\u003Ec__Iterator5E1();
    return (IEnumerator) popupCIterator5E1;
  }

  [DebuggerHidden]
  private IEnumerator ShowUnitAlertPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Colosseum0234Menu.\u003CShowUnitAlertPopup\u003Ec__Iterator5E2 popupCIterator5E2 = new Colosseum0234Menu.\u003CShowUnitAlertPopup\u003Ec__Iterator5E2();
    return (IEnumerator) popupCIterator5E2;
  }

  private enum HeaderType
  {
    HOME,
    MATCHING,
  }
}
