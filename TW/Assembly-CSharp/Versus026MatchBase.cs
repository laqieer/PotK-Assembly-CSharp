﻿// Decompiled with JetBrains decompiler
// Type: Versus026MatchBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using Net;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Versus026MatchBase : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel txtLeaderSkill;
  [SerializeField]
  protected UILabel txtPass;
  [SerializeField]
  protected UILabel txtTimeLimit;
  [SerializeField]
  protected UILabel txtTotalPower;
  [SerializeField]
  protected UILabel txtTitle;
  [SerializeField]
  protected UILabel txtBonus;
  [SerializeField]
  protected GameObject dirScrollText;
  [SerializeField]
  protected GameObject bgCharacter;
  [SerializeField]
  protected GameObject[] unitIcons;
  [SerializeField]
  protected GameObject dirBonus;
  [SerializeField]
  protected UIButton btnBreakRepair;
  [SerializeField]
  protected UIButton btnStartMatch;
  protected bool isFriendMatch;
  protected PvpMatchingTypeEnum type;
  protected WebAPI.Response.PvpBoot pvpInfo;
  public static readonly int PVP_TUTORIAL_FRIEND_END_PAGE = 100;
  private bool isMatched;
  protected bool isRepair;
  protected bool isCancel;
  private bool isCloseFriendMatchPopup;
  private GameCore.BattleInfo bi;
  private GameObject ScrollTextPrefab;
  public bool isDebugMatching;
  [SerializeField]
  private Versus026MatchBase.DebugInspectorInfo debugInfo;

  [DebuggerHidden]
  public virtual IEnumerator Init(PvpMatchingTypeEnum type, WebAPI.Response.PvpBoot pvpInfo)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus026MatchBase.\u003CInit\u003Ec__Iterator65B()
    {
      pvpInfo = pvpInfo,
      type = type,
      \u003C\u0024\u003EpvpInfo = pvpInfo,
      \u003C\u0024\u003Etype = type,
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnStartMatch()
  {
    if (this.IsPushAndSet())
      return;
    if (this.isMatched)
    {
      Debug.LogError((object) "Already connect matching");
    }
    else
    {
      if (this.GetBoolCostOver())
        return;
      this.StartCoroutine(this.PopupConfirmationMatching());
    }
  }

  public virtual void IbtnOrganization()
  {
    if (this.IsPushAndSet())
      return;
    Unit0046Scene.changeSceneVersus(true);
  }

  public virtual void IbtnWarExperience()
  {
    Debug.Log((object) "click default event IbtnWarExperience");
  }

  public void IbtnRepair()
  {
    if (this.IsPushAndSet())
      return;
    Bugu00524Scene.ChangeScene(true);
  }

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet() || this.isMatched)
      return;
    this.backScene();
  }

  protected override void backScene()
  {
    Singleton<NGSceneManager>.GetInstance().clearStack();
    Singleton<NGSceneManager>.GetInstance().destroyLoadedScenes();
    Singleton<NGSceneManager>.GetInstance().changeScene("versus026_1");
  }

  protected void SetMatchButton()
  {
    ((Component) this.btnBreakRepair).gameObject.SetActive(this.isRepair);
    ((Component) this.btnStartMatch).gameObject.SetActive(!this.isRepair);
  }

  private void SetBonusDisplay()
  {
    if (this.pvpInfo.bonus != null && this.pvpInfo.bonus.Length != 0)
    {
      Bonus[] array = ((IEnumerable<Bonus>) this.pvpInfo.bonus).Where<Bonus>((Func<Bonus, bool>) (x => x.category != 12)).ToArray<Bonus>();
      if (array.Length == 0)
      {
        this.dirBonus.SetActive(false);
      }
      else
      {
        new BonusDisplay().Set(array, this.txtBonus, this.txtTimeLimit, false, true);
        this.dirBonus.SetActive(true);
      }
    }
    else
      this.dirBonus.SetActive(false);
  }

  [DebuggerHidden]
  private IEnumerator SetLiderSkillInfo()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus026MatchBase.\u003CSetLiderSkillInfo\u003Ec__Iterator65C()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetBgCharacter()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus026MatchBase.\u003CSetBgCharacter\u003Ec__Iterator65D()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetUnitIcon()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus026MatchBase.\u003CSetUnitIcon\u003Ec__Iterator65E()
    {
      \u003C\u003Ef__this = this
    };
  }

  private PlayerDeck GetDeck()
  {
    PlayerDeck[] playerDeckArray = SMManager.Get<PlayerDeck[]>();
    if (((IEnumerable<PlayerUnit>) playerDeckArray[Persist.versusDeckOrganized.Data.number].player_units).FirstOrDefault<PlayerUnit>() == (PlayerUnit) null)
    {
      Persist.versusDeckOrganized.Data.number = 0;
      Persist.versusDeckOrganized.Flush();
    }
    return playerDeckArray[Persist.versusDeckOrganized.Data.number];
  }

  private PlayerUnit GetLeaderUnit(PlayerDeck deck)
  {
    PlayerUnit leaderUnit = ((IEnumerable<PlayerUnit>) deck.player_units).FirstOrDefault<PlayerUnit>();
    if (leaderUnit == (PlayerUnit) null)
      leaderUnit = ((IEnumerable<PlayerUnit>) SMManager.Get<PlayerDeck[]>()[0].player_units).First<PlayerUnit>();
    return leaderUnit;
  }

  private bool GetBoolCostOver()
  {
    PlayerDeck deck = this.GetDeck();
    if (deck.cost <= deck.cost_limit)
      return false;
    Consts instance = Consts.GetInstance();
    ModalWindow.Show(instance.VERSUS_00262POPUP_COSTOVER_TITLE, instance.VERSUS_00262POPUP_COSTOVER_DESCRIPTION, (System.Action) (() => this.CancelBattle()));
    return true;
  }

  private void StartMatch()
  {
    this.bi = new GameCore.BattleInfo();
    this.bi.pvp = true;
    Singleton<NGBattleManager>.GetInstance().SetAutoBattleBtnChanged();
    this.StartCoroutine(this.doMatchingAndStartBattle());
  }

  [DebuggerHidden]
  private IEnumerator doMatchingAndStartBattle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus026MatchBase.\u003CdoMatchingAndStartBattle\u003Ec__Iterator65F()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void StartBattle()
  {
    Singleton<PopupManager>.GetInstance().onDismiss();
    Singleton<CommonRoot>.GetInstance().isLoading = true;
    Singleton<NGBattleManager>.GetInstance().startBattle(this.bi);
    PVPManager.createPVPManager().getMatchingBehaviour().cleanupDestroy();
  }

  private void setMatched(MatchingPeer.Matched matched)
  {
    if (matched != null)
    {
      this.bi.host = matched.host;
      this.bi.port = matched.port;
      this.bi.battleToken = matched.battleToken;
    }
    else
    {
      this.bi.host = (string) null;
      this.bi.port = 0;
      this.bi.battleToken = (string) null;
    }
  }

  [DebuggerHidden]
  private IEnumerator GetEnemyInfo(string id)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus026MatchBase.\u003CGetEnemyInfo\u003Ec__Iterator660()
    {
      id = id,
      \u003C\u0024\u003Eid = id,
      \u003C\u003Ef__this = this
    };
  }

  protected virtual string SetRoomKey(string key) => key;

  public void OkFriendMatch() => this.isCloseFriendMatchPopup = true;

  public void CancelFriendMatch()
  {
    this.isCloseFriendMatchPopup = true;
    this.isCancel = true;
  }

  public void CancelBattle()
  {
    Singleton<PopupManager>.GetInstance().onDismiss();
    PVPManager.createPVPManager().getMatchingBehaviour().cleanupDestroy();
    this.isMatched = false;
    this.IsPush = false;
  }

  [DebuggerHidden]
  private IEnumerator PopupConfirmationMatching()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus026MatchBase.\u003CPopupConfirmationMatching\u003Ec__Iterator661()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void PopupCancelBattle(System.Action OkAction, bool byMyself)
  {
    if (!this.isMatched)
      return;
    Singleton<PopupManager>.GetInstance().closeAll();
    Consts instance = Consts.GetInstance();
    ModalWindow.Show(!byMyself ? instance.VERSUS_0026CANCEL_TITLE : instance.VERSUS_0026CANCEL_MYSELF_TITLE, !byMyself ? instance.VERSUS_0026CANCEL_DESCRIPTION : instance.VERSUS_0026CANCEL_MYSELF_DESCRIPTION, (System.Action) (() => OkAction()));
  }

  private void PopupTimeOutMatching(System.Action OkAction)
  {
    if (!this.isMatched)
      return;
    Singleton<PopupManager>.GetInstance().closeAll();
    Consts instance = Consts.GetInstance();
    ModalWindow.Show(instance.VERSUS_002645POPUP_TITLE, instance.VERSUS_002645POPUP_DESCRIPTION, (System.Action) (() => OkAction()));
  }

  private void PopupReadyErrorMatching(System.Action OkAction)
  {
    if (!this.isMatched)
      return;
    Singleton<PopupManager>.GetInstance().closeAll();
    Consts instance = Consts.GetInstance();
    ModalWindow.Show(instance.VERSUS_0026_READY_ERROR_TITLE, instance.VERSUS_0026_READY_ERROR_MESSAGE, (System.Action) (() =>
    {
      OkAction();
      this.isCancel = true;
    }));
  }

  [DebuggerHidden]
  private IEnumerator PopupConnectMatching(Action<GameObject> obj)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus026MatchBase.\u003CPopupConnectMatching\u003Ec__Iterator662()
    {
      obj = obj,
      \u003C\u0024\u003Eobj = obj,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator PopupFindMatching()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus026MatchBase.\u003CPopupFindMatching\u003Ec__Iterator663()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected virtual bool IsMatchingBeginCheck() => true;

  [DebuggerHidden]
  protected virtual IEnumerator ErrorMathcingBegin()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Versus026MatchBase.\u003CErrorMathcingBegin\u003Ec__Iterator664 beginCIterator664 = new Versus026MatchBase.\u003CErrorMathcingBegin\u003Ec__Iterator664();
    return (IEnumerator) beginCIterator664;
  }

  public override void onBackButton() => this.IbtnBack();

  public void GotoLoginScene()
  {
    this.CancelBattle();
    NGSceneManager instance = Singleton<NGSceneManager>.GetInstance();
    Singleton<NGGameDataManager>.GetInstance().refreshHomeHome = true;
    if (Object.op_Inequality((Object) instance, (Object) null))
      instance.RestartGame();
    else
      Application.LoadLevel("startup000_6");
  }

  private void PopupDclError(System.Action yesAction, System.Action noAction)
  {
    if (!this.isMatched)
      return;
    Singleton<PopupManager>.GetInstance().closeAll();
    Consts instance = Consts.GetInstance();
    ModalWindow.ShowYesNo(instance.VERSUS_002645POPUP_TITLE, instance.VERSUS_002645POPUP_DCLDESCRIPTION, (System.Action) (() => yesAction()), (System.Action) (() => noAction()));
  }

  [Serializable]
  private class DebugInspectorInfo
  {
    public string targetPlayerId = string.Empty;
    public int targetDeckType = -1;
    public int targetDeckId = -1;
    public bool ignoreAuth = true;
    public int order = -1;
    public int turns = -1;
    public int point = -1;

    public MatchingDebugInfo toSendInfo()
    {
      return new MatchingDebugInfo()
      {
        targetPlayerId = !(this.targetPlayerId == string.Empty) ? this.targetPlayerId : (string) null,
        targetDeckType = this.targetDeckType != -1 ? new int?(this.targetDeckType) : new int?(),
        targetDeckId = this.targetDeckId != -1 ? new int?(this.targetDeckId) : new int?(),
        ignoreAuth = this.ignoreAuth,
        order = this.order != -1 ? new int?(this.order) : new int?(),
        turns = this.turns != -1 ? new int?(this.turns) : new int?(),
        point = this.point != -1 ? new int?(this.point) : new int?()
      };
    }
  }
}
