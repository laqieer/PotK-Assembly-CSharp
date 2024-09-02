// Decompiled with JetBrains decompiler
// Type: Guild0282Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
public class Guild0282Menu : BackButtonMenuBase
{
  public const string EntryPressedButton = "ibtn_Sortie_pressed.png__GUI__guild_common__guild_common_prefab";
  public const string EntryIdleButton = "ibtn_Sortie_idle.png__GUI__guild_common__guild_common_prefab";
  private System.Action _actionForGvgPopup;
  [SerializeField]
  private float focusAnimDuration = 0.5f;
  [SerializeField]
  private float cameraChangeDuration = 0.5f;
  [SerializeField]
  private UIButton entryButton;
  [SerializeField]
  private GameObject cloudParent;
  [SerializeField]
  private GameObject guildMap;
  [SerializeField]
  private UIScrollView scrollView;
  [SerializeField]
  private List<SightPattern> sightPattern;
  private int sightUseNumber;
  [SerializeField]
  private GameObject uiStatusUsualObj;
  [SerializeField]
  private StatusUsual uiStatusUsual;
  [SerializeField]
  private GameObject uiStatusReadyObj;
  [SerializeField]
  private GameObject dir_battle_ready;
  [SerializeField]
  private StatusReady uiStatusReady;
  [SerializeField]
  private GameObject uiStatusInBattleObj;
  [SerializeField]
  private StatusInBattle uiStatusInBattle;
  [SerializeField]
  private UILabel txt_not_enough_member;
  [SerializeField]
  private GameObject NotEnoughMemberObj;
  [SerializeField]
  private GameObject WaitingForEnteryToStart;
  [SerializeField]
  private GameObject Matching;
  [SerializeField]
  private GameObject WaitingForEnteryMember;
  [SerializeField]
  private GameObject GuildBattleClose;
  [SerializeField]
  private GameObject OutOfTerm;
  private bool isBattleResultAnimation;
  private bool isBackGuildTop;
  private GuildRegistration myGuild;
  private GuildRegistration enGuild;
  [SerializeField]
  private GuildMapUI myGuildUI;
  [SerializeField]
  private GuildMapUI enGuildUI;
  private Guild0282MemberBaseMenu myGuildMemberMenuPrefab;
  private Guild0282GuildBaseMenu myGuildBaseMenuPrefab;
  private Guild0282MemberBaseMenu enGuildMemberMenuPrefab;
  private Guild0282GuildBaseMenu enGuildBaseMenuPrefab;
  private GameObject guildMemberBasePrefab;
  private GameObject guildMemberBasePrefabForGBResult;
  private GameObject guildBasePrefab;
  private GameObject cloudPrefab;
  private GameObject entryConfirmPrefab;
  [SerializeField]
  private Transform middle;
  private bool isTouchBlock;
  private GuildInfoPopup guildInfoPopup;
  private GuildMemberObject guildMemberPopup;
  private bool isCloud;
  private GuildRegistration selectGuildData;
  private GuildMembership selectMemberData;
  [SerializeField]
  private GameObject cloudAnimParent;
  private System.Action tweenPositionCompleteAction;
  private System.Action tweenScaleCompleteAction;
  private GuildImageCache myGuildImageCache;
  private GuildImageCache enGuildImageCache;
  private GuildImageCache memberImageCache;
  [SerializeField]
  private GameObject blackBg;
  [SerializeField]
  private GameObject _dyn_battle_edit;
  private GameObject _guildDefTeamPopup;
  private GameObject _guildAtkTeamPopup;
  private Coroutine TimeCounter;
  private bool isMatingConnecting;
  [SerializeField]
  private GameObject ibtn_Back;
  private GameObject gvgPopup;
  private string[] opposed_player_ids;
  [SerializeField]
  private PlayerSituation dir_player_situation;
  private bool _isClosePopupByBackBtn = true;
  private bool isAggregatingPopup;

  public System.Action actionForGvgPopup => this._actionForGvgPopup;

  public GuildRegistration MyGuild => this.myGuild;

  public GuildRegistration EnGuild => this.enGuild;

  public GuildMapUI MyGuildUI => this.myGuildUI;

  public GuildMapUI EnGuildUI => this.enGuildUI;

  public GameObject dyn_battle_edit => this._dyn_battle_edit;

  public GameObject guildDefTeamPopup => this._guildDefTeamPopup;

  public GameObject guildAtkTeamPopup => this._guildAtkTeamPopup;

  public bool isClosePopupByBackBtn
  {
    set => this._isClosePopupByBackBtn = value;
    get => this._isClosePopupByBackBtn;
  }

  public bool IsOpposedPlayer(string player_id)
  {
    return ((IEnumerable<string>) this.opposed_player_ids).Any<string>((Func<string, bool>) (x => x == player_id));
  }

  [DebuggerHidden]
  private IEnumerator GuildShow()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282Menu.\u003CGuildShow\u003Ec__Iterator772()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator InitializeAsyncUpdate()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282Menu.\u003CInitializeAsyncUpdate\u003Ec__Iterator773()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator InitializeAsync(bool guildBattleResult = false)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282Menu.\u003CInitializeAsync\u003Ec__Iterator774()
    {
      guildBattleResult = guildBattleResult,
      \u003C\u0024\u003EguildBattleResult = guildBattleResult,
      \u003C\u003Ef__this = this
    };
  }

  private bool IsMember(string plyaer_id)
  {
    if (this.MyGuild != null && ((IEnumerable<GuildMembership>) this.MyGuild.memberships).FirstIndexOrNull<GuildMembership>((Func<GuildMembership, bool>) (x => x.player.player_id == plyaer_id)).HasValue)
      return true;
    return this.EnGuild != null && ((IEnumerable<GuildMembership>) this.EnGuild.memberships).FirstIndexOrNull<GuildMembership>((Func<GuildMembership, bool>) (x => x.player.player_id == plyaer_id)).HasValue;
  }

  [DebuggerHidden]
  private IEnumerator InitializeUsualAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282Menu.\u003CInitializeUsualAsync\u003Ec__Iterator775()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator InitializeReadyAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282Menu.\u003CInitializeReadyAsync\u003Ec__Iterator776()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator InitializeInBattleAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282Menu.\u003CInitializeInBattleAsync\u003Ec__Iterator777()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void Initialize(GuildMembership member)
  {
    this.Initialize();
    this.JumpMember(member);
  }

  public void InitializeGBResult(GuildMembership member, int captureStar)
  {
    this.isBattleResultAnimation = true;
    this.isBackGuildTop = true;
    this.Initialize();
    this.StartCoroutine(this.GBResultAnimation(member, captureStar));
  }

  [DebuggerHidden]
  private IEnumerator GBResultAnimation(GuildMembership member, int captureStar)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282Menu.\u003CGBResultAnimation\u003Ec__Iterator778()
    {
      member = member,
      captureStar = captureStar,
      \u003C\u0024\u003Emember = member,
      \u003C\u0024\u003EcaptureStar = captureStar,
      \u003C\u003Ef__this = this
    };
  }

  public void MemberBaseUpdate()
  {
    foreach (GuildMembership membership in this.MyGuild.memberships)
    {
      GuildMembership member = membership;
      Guild0282MemberBase guild0282MemberBase = this.MyGuildUI.memberBaseList.Find((Predicate<Guild0282MemberBase>) (x => x.Member.player.player_id == member.player.player_id));
      if (Object.op_Inequality((Object) guild0282MemberBase, (Object) null))
        guild0282MemberBase.Initialize(member, this, this.memberImageCache, false, this.MyGuild.gvg_status);
    }
    if (this.EnGuild == null)
      return;
    foreach (GuildMembership membership in this.EnGuild.memberships)
    {
      GuildMembership member = membership;
      Guild0282MemberBase guild0282MemberBase = this.EnGuildUI.memberBaseList.Find((Predicate<Guild0282MemberBase>) (x => x.Member.player.player_id == member.player.player_id));
      if (Object.op_Inequality((Object) guild0282MemberBase, (Object) null))
        guild0282MemberBase.Initialize(member, this, this.memberImageCache, true, this.MyGuild.gvg_status);
    }
  }

  private void CloudCreater(Transform trans)
  {
    if (((Object) trans).name == "cloud_anim_pos")
      this.cloudPrefab.Clone(trans);
    foreach (Transform child in trans.GetChildren())
      this.CloudCreater(child);
  }

  private void CloudDelete(Transform trans)
  {
    if (((Object) trans).name == "cloud(Clone)")
      Object.Destroy((Object) ((Component) trans).gameObject);
    foreach (Transform child in trans.GetChildren())
      this.CloudDelete(child);
  }

  private void UpdateActiveUI()
  {
    switch (this.MyGuild.gvg_status)
    {
      case GvgStatus.not_enough_member:
      case GvgStatus.lock_entry:
      case GvgStatus.can_entry:
      case GvgStatus.matching:
      case GvgStatus.aggregating:
      case GvgStatus.finished:
      case GvgStatus.out_of_term:
        this.uiStatusUsualObj.SetActive(true);
        this.uiStatusReadyObj.SetActive(false);
        this.dir_battle_ready.SetActive(false);
        this.dir_player_situation.SetActive(false);
        this.uiStatusInBattleObj.SetActive(false);
        break;
      case GvgStatus.preparing:
        this.uiStatusUsualObj.SetActive(false);
        this.uiStatusReadyObj.SetActive(true);
        this.dir_battle_ready.SetActive(true);
        this.dir_player_situation.SetActive(false);
        this.uiStatusInBattleObj.SetActive(false);
        break;
      case GvgStatus.fighting:
        this.uiStatusUsualObj.SetActive(false);
        this.uiStatusReadyObj.SetActive(false);
        this.dir_battle_ready.SetActive(false);
        this.dir_player_situation.SetActive(true);
        this.uiStatusInBattleObj.SetActive(true);
        break;
    }
  }

  private void InitializeUI()
  {
    switch (this.MyGuild.gvg_status)
    {
      case GvgStatus.not_enough_member:
      case GvgStatus.lock_entry:
      case GvgStatus.can_entry:
      case GvgStatus.matching:
      case GvgStatus.out_of_term:
        this.uiStatusUsual.MyStatus.SetStatus(this.MyGuild);
        this.SetGVGReleaseEntryHour();
        break;
      case GvgStatus.preparing:
        this.uiStatusReady.SetStatus(this.MyGuild, this.EnGuild);
        this.SetGVGStartHour();
        break;
      case GvgStatus.fighting:
        this.uiStatusInBattle.SetStatus(this.MyGuild, this.EnGuild);
        this.SetGVGEndHour();
        int? nullable = ((IEnumerable<GuildMembership>) this.MyGuild.memberships).FirstIndexOrNull<GuildMembership>((Func<GuildMembership, bool>) (x => x.player.player_id == Player.Current.id));
        if (!nullable.HasValue)
          break;
        this.dir_player_situation.Initialize(this.MyGuild.memberships[nullable.Value], this.guildMemberBasePrefab, this.memberImageCache);
        break;
      case GvgStatus.aggregating:
      case GvgStatus.finished:
        this.StartCoroutine(this.Aggregating());
        this.uiStatusUsual.MyStatus.SetStatus(this.MyGuild);
        this.SetGVGReleaseEntryHour();
        break;
    }
  }

  private void UpdateUI()
  {
    switch (this.MyGuild.gvg_status)
    {
      case GvgStatus.not_enough_member:
      case GvgStatus.lock_entry:
      case GvgStatus.can_entry:
      case GvgStatus.matching:
      case GvgStatus.out_of_term:
        this.uiStatusUsual.MyStatus.SetStatus(this.MyGuild);
        this.SetGVGReleaseEntryHour();
        break;
      case GvgStatus.preparing:
        this.uiStatusReady.UpdateStatus(this.MyGuild, this.EnGuild);
        this.SetGVGStartHour();
        break;
      case GvgStatus.fighting:
        this.uiStatusInBattle.UpdateStatus(this.MyGuild, this.EnGuild);
        this.SetGVGEndHour();
        int? nullable = ((IEnumerable<GuildMembership>) this.MyGuild.memberships).FirstIndexOrNull<GuildMembership>((Func<GuildMembership, bool>) (x => x.player.player_id == Player.Current.id));
        if (!nullable.HasValue)
          break;
        this.dir_player_situation.Initialize(this.MyGuild.memberships[nullable.Value], this.guildMemberBasePrefab, this.memberImageCache);
        break;
      case GvgStatus.aggregating:
      case GvgStatus.finished:
        this.StartCoroutine(this.Aggregating());
        this.uiStatusUsual.MyStatus.SetStatus(this.MyGuild);
        this.SetGVGReleaseEntryHour();
        break;
    }
  }

  private void UpdateMattingUI()
  {
    if (!Player.Current.IsGuildMatingOpen())
    {
      this.uiStatusUsualObj.SetActive(true);
      this.uiStatusReadyObj.SetActive(false);
      this.dir_battle_ready.SetActive(false);
      this.uiStatusInBattleObj.SetActive(false);
      this.NotEnoughMemberObj.SetActive(false);
      this.WaitingForEnteryToStart.SetActive(false);
      this.Matching.SetActive(false);
      this.WaitingForEnteryMember.SetActive(false);
      this.GuildBattleClose.SetActive(true);
      this.OutOfTerm.SetActive(false);
      this.entryButton.isEnabled = false;
    }
    else
    {
      switch (this.MyGuild.gvg_status)
      {
        case GvgStatus.not_enough_member:
          this.NotEnoughMemberObj.SetActive(true);
          this.WaitingForEnteryToStart.SetActive(false);
          this.Matching.SetActive(false);
          this.WaitingForEnteryMember.SetActive(false);
          this.GuildBattleClose.SetActive(false);
          this.OutOfTerm.SetActive(false);
          this.entryButton.isEnabled = false;
          this.txt_not_enough_member.SetTextLocalize(Consts.Format(Consts.GetInstance().GUILD_MATING_MIN_MEMBERS_COUNT, (IDictionary) new Hashtable()
          {
            {
              (object) "num",
              (object) GuildUtil.GetGuildSettingInt("GVG_MIN_MEMBERS_COUNT")
            }
          }));
          break;
        case GvgStatus.lock_entry:
        case GvgStatus.aggregating:
        case GvgStatus.finished:
          this.NotEnoughMemberObj.SetActive(false);
          this.WaitingForEnteryToStart.SetActive(true);
          this.Matching.SetActive(false);
          this.WaitingForEnteryMember.SetActive(false);
          this.GuildBattleClose.SetActive(false);
          this.OutOfTerm.SetActive(false);
          this.entryButton.isEnabled = false;
          break;
        case GvgStatus.can_entry:
          this.NotEnoughMemberObj.SetActive(false);
          this.WaitingForEnteryToStart.SetActive(false);
          this.Matching.SetActive(false);
          this.GuildBattleClose.SetActive(false);
          this.OutOfTerm.SetActive(false);
          int? nullable = ((IEnumerable<GuildMembership>) this.MyGuild.memberships).FirstIndexOrNull<GuildMembership>((Func<GuildMembership, bool>) (x => x.player.player_id == Player.Current.id));
          if (!nullable.HasValue)
            break;
          if (this.MyGuild.memberships[nullable.Value].role != GuildRole.master && this.MyGuild.memberships[nullable.Value].role != GuildRole.sub_master)
          {
            this.WaitingForEnteryMember.SetActive(true);
            this.entryButton.isEnabled = false;
            break;
          }
          this.WaitingForEnteryMember.SetActive(false);
          this.entryButton.defaultColor = Color.white;
          this.entryButton.pressed = Color.white;
          this.entryButton.pressedSprite = "ibtn_Sortie_pressed.png__GUI__guild_common__guild_common_prefab";
          ((Component) this.entryButton).gameObject.SetActive(false);
          ((Component) this.entryButton).gameObject.SetActive(true);
          this.entryButton.isEnabled = true;
          TweenColor component1 = ((Component) this.entryButton).GetComponent<TweenColor>();
          component1.from = Color.white;
          component1.to = Color.white;
          component1.ResetToBeginning();
          break;
        case GvgStatus.matching:
          this.NotEnoughMemberObj.SetActive(false);
          this.WaitingForEnteryToStart.SetActive(false);
          this.Matching.SetActive(true);
          this.WaitingForEnteryMember.SetActive(false);
          this.GuildBattleClose.SetActive(false);
          this.OutOfTerm.SetActive(false);
          this.entryButton.defaultColor = Color.gray;
          this.entryButton.pressed = Color.gray;
          this.entryButton.pressedSprite = "ibtn_Sortie_idle.png__GUI__guild_common__guild_common_prefab";
          this.entryButton.isEnabled = true;
          TweenColor component2 = ((Component) this.entryButton).GetComponent<TweenColor>();
          component2.from = Color.gray;
          component2.to = Color.gray;
          component2.ResetToBeginning();
          break;
        case GvgStatus.preparing:
          this.NotEnoughMemberObj.SetActive(false);
          this.WaitingForEnteryToStart.SetActive(false);
          this.Matching.SetActive(false);
          this.WaitingForEnteryMember.SetActive(false);
          this.GuildBattleClose.SetActive(false);
          this.OutOfTerm.SetActive(false);
          break;
        case GvgStatus.fighting:
          this.NotEnoughMemberObj.SetActive(false);
          this.WaitingForEnteryToStart.SetActive(false);
          this.Matching.SetActive(false);
          this.WaitingForEnteryMember.SetActive(false);
          this.GuildBattleClose.SetActive(false);
          this.OutOfTerm.SetActive(false);
          break;
        case GvgStatus.out_of_term:
          this.NotEnoughMemberObj.SetActive(false);
          this.WaitingForEnteryToStart.SetActive(false);
          this.Matching.SetActive(false);
          this.WaitingForEnteryMember.SetActive(false);
          this.OutOfTerm.SetActive(true);
          this.GuildBattleClose.SetActive(false);
          this.entryButton.isEnabled = false;
          break;
      }
    }
  }

  public void Initialize()
  {
    this.IsPush = false;
    if (!this.isCloud)
    {
      this.CloudCreater(this.cloudAnimParent.transform);
      this.isCloud = true;
    }
    this.InitializeMapUI(this.MyGuildUI);
    this.InitializeMapUI(this.EnGuildUI);
    this.sightUseNumber = 0;
    this.SetSightPattern(this.sightUseNumber);
    this.UpdateActiveUI();
    this.InitializeUI();
    this.CreateGuildMap();
    this.UpdateMattingUI();
  }

  public void InitializeUpdate()
  {
    this.IsPush = false;
    this.UpdateActiveUI();
    this.UpdateUI();
    this.UpdateGuildMap();
    this.UpdateMattingUI();
    this.scrollView.UpdateScrollbars(true);
  }

  private void StopCoroutineTimeCounter()
  {
    this.StopCoroutine("TimeCountSprite");
    this.StopCoroutine("TimeCountText");
  }

  private void SetGVGStartHour()
  {
    this.StopCoroutineTimeCounter();
    this.StartCoroutine(GuildUtil.TimeCountSprite(this.uiStatusReady.slc_Remain_hours, this.uiStatusReady.slc_Remain_minutes, (double) GuildUtil.GVGStartHour(), (System.Action) (() => this.StartCoroutine(this.MapReload())), (NGMenuBase) this));
  }

  private void SetGVGEndHour()
  {
    this.StopCoroutineTimeCounter();
    this.StartCoroutine(GuildUtil.TimeCountSprite(this.uiStatusInBattle.slc_Remain_hours, this.uiStatusInBattle.slc_Remain_minutes, (double) GuildUtil.GVGEndHour(), (System.Action) (() => this.StartCoroutine(this.MapReload())), (NGMenuBase) this));
  }

  private void SetGVGReleaseEntryHour()
  {
    this.StopCoroutineTimeCounter();
    this.StartCoroutine(GuildUtil.TimeCountText(this.uiStatusUsual.txt_waiting_for_entery_to_start, Consts.GetInstance().GUILD_MAP_ENTRY_EXPIRED_HOUR, (double) GuildUtil.GVGReleaseEntryHour(), (System.Action) (() =>
    {
      if (this.MyGuild.gvg_status == GvgStatus.matching)
        ModalWindow.Show(Consts.GetInstance().GUILD_MAP_MATING_AUTO_CANCEL_TITLE, Consts.GetInstance().GUILD_MAP_MATING_AUTO_CANCEL_MESSAGE, (System.Action) (() => this.StartCoroutine(this.MapReload())));
      else
        this.StartCoroutine(this.MapReload());
    }), (MonoBehaviour) this));
  }

  public void onEndScene() => this.StopCoroutineTimeCounter();

  public void InitializeJump()
  {
    if (this.selectMemberData == null)
      this.JumpGuildBase();
    else
      this.JumpMember(this.selectMemberData);
  }

  public void JumpGuildBase()
  {
    this.CloseLingMenu();
    if (this.MyGuild.gvg_status == GvgStatus.fighting)
      this.Focus(this.CalcGuildMapPosition(((Component) this.EnGuildUI.guildBase).transform.parent.localPosition, this.sightPattern[0].MapScale), this.sightPattern[0].MapScale, string.Empty);
    else
      this.Focus(this.CalcGuildMapPosition(((Component) this.MyGuildUI.guildBase).transform.parent.localPosition, this.sightPattern[0].MapScale), this.sightPattern[0].MapScale, string.Empty);
  }

  public void JumpMember(GuildMembership member)
  {
    if (member == null || !this.IsMember(member.player.player_id))
    {
      this.JumpGuildBase();
    }
    else
    {
      this.CloseLingMenu();
      this.selectMemberData = member;
      Guild0282MemberBase guild0282MemberBase1 = this.MyGuildUI.memberBaseList.Find((Predicate<Guild0282MemberBase>) (x => x.Member.player.player_id == member.player.player_id));
      if (Object.op_Inequality((Object) guild0282MemberBase1, (Object) null))
      {
        this.Focus(this.CalcGuildMapPosition(((Component) guild0282MemberBase1).transform.parent.localPosition, this.sightPattern[0].MapScale), this.sightPattern[0].MapScale, "OpenMyMemberBaseMenu");
      }
      else
      {
        Guild0282MemberBase guild0282MemberBase2 = this.EnGuildUI.memberBaseList.Find((Predicate<Guild0282MemberBase>) (x => x.Member.player.player_id == member.player.player_id));
        if (!Object.op_Inequality((Object) guild0282MemberBase2, (Object) null))
          return;
        this.Focus(this.CalcGuildMapPosition(((Component) guild0282MemberBase2).transform.parent.localPosition, this.sightPattern[0].MapScale), this.sightPattern[0].MapScale, "OpenEnMemberBaseMenu");
      }
    }
  }

  [DebuggerHidden]
  private IEnumerator ResourceLoad()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282Menu.\u003CResourceLoad\u003Ec__Iterator779()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void CreateGuildMap(
    GuildMapUI guildMapUI,
    GuildRegistration guildData,
    GuildImageCache guildImageCache,
    bool isEnemy)
  {
    List<GuildMembership> guildMembershipList = new List<GuildMembership>();
    int? nullable1 = ((IEnumerable<GuildMembership>) guildData.memberships).FirstIndexOrNull<GuildMembership>((Func<GuildMembership, bool>) (x => x.player.player_id == Player.Current.id));
    if (nullable1.HasValue)
      guildMembershipList.Add(guildData.memberships[nullable1.Value]);
    guildData.memberships = ((IEnumerable<GuildMembership>) guildData.memberships).Where<GuildMembership>((Func<GuildMembership, bool>) (x => x.player.player_id != Player.Current.id)).ToArray<GuildMembership>();
    int? nullable2 = ((IEnumerable<GuildMembership>) guildData.memberships).FirstIndexOrNull<GuildMembership>((Func<GuildMembership, bool>) (x => x.role == GuildRole.master));
    if (nullable2.HasValue)
      guildMembershipList.Add(guildData.memberships[nullable2.Value]);
    foreach (GuildMembership guildMembership in (IEnumerable<GuildMembership>) ((IEnumerable<GuildMembership>) guildData.memberships).Where<GuildMembership>((Func<GuildMembership, bool>) (x => x.role == GuildRole.sub_master)).OrderByDescending<GuildMembership, int>((Func<GuildMembership, int>) (x => x.contribution)))
      guildMembershipList.Add(guildMembership);
    foreach (GuildMembership guildMembership in (IEnumerable<GuildMembership>) ((IEnumerable<GuildMembership>) guildData.memberships).Where<GuildMembership>((Func<GuildMembership, bool>) (x => x.role != GuildRole.master && x.role != GuildRole.sub_master)).OrderByDescending<GuildMembership, int>((Func<GuildMembership, int>) (x => x.contribution)))
      guildMembershipList.Add(guildMembership);
    guildData.memberships = guildMembershipList.ToArray();
    guildMapUI.guildBase = this.guildBasePrefab.Clone(guildMapUI.guildBasePosition.transform).GetComponent<Guild0282GuildBase>();
    ((Collider) ((Component) guildMapUI.guildBase).GetComponent<BoxCollider>()).enabled = true;
    guildMapUI.guildBase.Initialize(guildData, this, guildImageCache, isEnemy);
    float num1 = guildData.memberships.Length < 10 ? 1f : (float) guildMapUI.memberBasePosition.Count / (float) guildData.memberships.Length;
    float num2 = 0.0f;
    for (int index = 0; index < guildData.memberships.Length; ++index)
    {
      Guild0282MemberBase component = this.guildMemberBasePrefab.Clone(guildMapUI.memberBasePosition[Mathf.FloorToInt(num2)].transform).GetComponent<Guild0282MemberBase>();
      component.Initialize(guildData.memberships[index], this, this.memberImageCache, isEnemy, this.MyGuild.gvg_status);
      guildMapUI.memberBaseList.Add(component);
      num2 += num1;
    }
  }

  private void UpdateGuildMap(
    GuildMapUI guildMapUI,
    GuildRegistration guildData,
    GuildImageCache guildImageCache,
    bool isEnemy)
  {
    List<GuildMembership> guildMembershipList = new List<GuildMembership>();
    int? nullable1 = ((IEnumerable<GuildMembership>) guildData.memberships).FirstIndexOrNull<GuildMembership>((Func<GuildMembership, bool>) (x => x.player.player_id == Player.Current.id));
    if (nullable1.HasValue)
      guildMembershipList.Add(guildData.memberships[nullable1.Value]);
    guildData.memberships = ((IEnumerable<GuildMembership>) guildData.memberships).Where<GuildMembership>((Func<GuildMembership, bool>) (x => x.player.player_id != Player.Current.id)).ToArray<GuildMembership>();
    int? nullable2 = ((IEnumerable<GuildMembership>) guildData.memberships).FirstIndexOrNull<GuildMembership>((Func<GuildMembership, bool>) (x => x.role == GuildRole.master));
    if (nullable2.HasValue)
      guildMembershipList.Add(guildData.memberships[nullable2.Value]);
    foreach (GuildMembership guildMembership in (IEnumerable<GuildMembership>) ((IEnumerable<GuildMembership>) guildData.memberships).Where<GuildMembership>((Func<GuildMembership, bool>) (x => x.role == GuildRole.sub_master)).OrderByDescending<GuildMembership, int>((Func<GuildMembership, int>) (x => x.contribution)))
      guildMembershipList.Add(guildMembership);
    foreach (GuildMembership guildMembership in (IEnumerable<GuildMembership>) ((IEnumerable<GuildMembership>) guildData.memberships).Where<GuildMembership>((Func<GuildMembership, bool>) (x => x.role != GuildRole.master && x.role != GuildRole.sub_master)).OrderByDescending<GuildMembership, int>((Func<GuildMembership, int>) (x => x.contribution)))
      guildMembershipList.Add(guildMembership);
    guildData.memberships = guildMembershipList.ToArray();
    guildMapUI.guildBase.InitializeUpdate(guildData, this, guildImageCache, isEnemy);
    for (int index = 0; index < guildMapUI.memberBaseList.Count; ++index)
      guildMapUI.memberBaseList[index].InitializeUpdate(guildData.memberships[index], this, this.memberImageCache, isEnemy, this.MyGuild.gvg_status);
  }

  private void CreateGuildMap()
  {
    this.CreateGuildMap(this.MyGuildUI, this.MyGuild, this.myGuildImageCache, false);
    this.EnGuildUI.SetActive(this.IsEnemy());
    if (!this.IsEnemy())
      return;
    this.CreateGuildMap(this.EnGuildUI, this.EnGuild, this.enGuildImageCache, true);
  }

  private void UpdateGuildMap()
  {
    this.UpdateGuildMap(this.MyGuildUI, this.MyGuild, this.myGuildImageCache, false);
    this.EnGuildUI.SetActive(this.IsEnemy());
    if (!this.IsEnemy())
      return;
    if (this.EnGuildUI.memberBaseList.Count == 0)
      this.CreateGuildMap(this.EnGuildUI, this.EnGuild, this.enGuildImageCache, true);
    else
      this.UpdateGuildMap(this.EnGuildUI, this.EnGuild, this.enGuildImageCache, true);
  }

  private void SetSightPattern(int number)
  {
    for (int index = 0; index < this.sightPattern.Count; ++index)
      this.sightPattern[index].SightImage.SetActive(index == number);
    this.SetTweenScale(this.guildMap, this.sightPattern[number].MapScale, this.cameraChangeDuration, true);
  }

  [DebuggerHidden]
  private IEnumerator ShowMyMemberList()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282Menu.\u003CShowMyMemberList\u003Ec__Iterator77A()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ShowEnMemberList()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282Menu.\u003CShowEnMemberList\u003Ec__Iterator77B()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void BackScene()
  {
    if (this.isBackGuildTop)
    {
      Guild0281Scene.ChangeSceneBattleResultBackButton();
      Singleton<NGSceneManager>.GetInstance().destroyScene("guild028_2");
    }
    else
      this.backScene();
  }

  public override void onBackButton()
  {
    if (Singleton<PopupManager>.GetInstance().isOpen)
    {
      if (!this.isClosePopupByBackBtn)
        return;
      Singleton<PopupManager>.GetInstance().dismiss();
    }
    else
    {
      if (GuildUtil.gvgPopupState != GuildUtil.GvGPopupState.None)
        return;
      if (this.IsLingMenu())
        this.DoLingMenuDismiss();
      else if (Singleton<CommonRoot>.GetInstance().guildChatManager.GetCurrentGuildChatStatus() == GuildChatManager.GuildChatStatus.DetailedView)
        Singleton<CommonRoot>.GetInstance().guildChatManager.OnBackButtonClicked();
      else
        this.BackScene();
    }
  }

  public void onButtonSightChange()
  {
    this.CloseLingMenu();
    Vector3 newPos;
    // ISSUE: explicit constructor call
    ((Vector3) ref newPos).\u002Ector(this.guildMap.transform.localPosition.x, this.guildMap.transform.localPosition.y);
    Vector3 vector3_1;
    // ISSUE: explicit constructor call
    ((Vector3) ref vector3_1).\u002Ector(((Component) this.scrollView).transform.localPosition.x, ((Component) this.scrollView).transform.localPosition.y);
    Vector3 vector3_2;
    // ISSUE: explicit constructor call
    ((Vector3) ref vector3_2).\u002Ector(this.guildMap.transform.localScale.x, this.guildMap.transform.localScale.y);
    ++this.sightUseNumber;
    if (this.sightPattern.Count <= this.sightUseNumber)
      this.sightUseNumber = 0;
    Vector3 vector3_3;
    // ISSUE: explicit constructor call
    ((Vector3) ref vector3_3).\u002Ector(this.sightPattern[this.sightUseNumber].MapScale.x, this.sightPattern[this.sightUseNumber].MapScale.y);
    // ISSUE: explicit constructor call
    ((Vector3) ref newPos).\u002Ector((newPos.x + vector3_1.x) / vector3_2.x * vector3_3.x - vector3_1.x, (newPos.y + vector3_1.y) / vector3_2.y * vector3_3.y - vector3_1.y);
    this.SetSightPattern(this.sightUseNumber);
    this.SetTweenPosition(this.guildMap, newPos, this.cameraChangeDuration, true);
  }

  public void onButtonDrawMyGuild() => this.StartCoroutine(this.ShowMyMemberList());

  public void onButtonDrawEnGuild() => this.StartCoroutine(this.ShowEnMemberList());

  public void onButtonEntry() => this.UpdateMattingUI();

  protected virtual void OnEnable() => UICamera.fallThrough = ((Component) this).gameObject;

  protected virtual void OnDisable() => UICamera.fallThrough = (GameObject) null;

  public void OnPress(bool isDown)
  {
    if (this.isTouchBlock)
      return;
    this.DoLingMenuDismiss();
  }

  public void OnDrag(Vector2 delta)
  {
    if (this.isTouchBlock)
      return;
    this.DoLingMenuDismiss();
    this.scrollView.UpdateScrollbars(true);
  }

  protected override void Update()
  {
    base.Update();
    Vector3 vector3_1;
    // ISSUE: explicit constructor call
    ((Vector3) ref vector3_1).\u002Ector(this.guildMap.transform.localPosition.x, this.guildMap.transform.localPosition.y);
    Vector3 vector3_2;
    // ISSUE: explicit constructor call
    ((Vector3) ref vector3_2).\u002Ector(((Component) this.scrollView).transform.localPosition.x, ((Component) this.scrollView).transform.localPosition.y);
    // ISSUE: explicit constructor call
    ((Vector3) ref vector3_1).\u002Ector(vector3_1.x + vector3_2.x, vector3_1.y + vector3_2.y);
    this.cloudParent.transform.localPosition = vector3_1;
    this.cloudParent.transform.localScale = this.guildMap.transform.localScale;
  }

  public void onButtonGuildBase(Guild0282GuildBase data, GuildRegistration guild)
  {
    if (this.isTouchBlock || this.IsLingMenu() && !this.DoLingMenuDismiss() || Object.op_Inequality((Object) this.guildMap.GetComponent<iTween>(), (Object) null))
      return;
    this.selectGuildData = guild;
    Vector3 pos = this.CalcGuildMapPosition(((Component) data).transform.parent.localPosition, this.sightPattern[0].MapScale);
    if (data.IsEnemy)
      this.Focus(pos, this.sightPattern[0].MapScale, "OpenEnGuildBaseMenu");
    else
      this.Focus(pos, this.sightPattern[0].MapScale, "OpenMyGuildBaseMenu");
  }

  public void onButtonMemberBase(Guild0282MemberBase data, GuildMembership member)
  {
    if (this.isTouchBlock || this.IsLingMenu() && !this.DoLingMenuDismiss() || Object.op_Inequality((Object) this.guildMap.GetComponent<iTween>(), (Object) null))
      return;
    this.selectMemberData = member;
    Vector3 pos = this.CalcGuildMapPosition(((Component) data).transform.parent.localPosition, this.sightPattern[0].MapScale);
    if (data.IsEnemy)
      this.Focus(pos, this.sightPattern[0].MapScale, "OpenEnMemberBaseMenu");
    else
      this.Focus(pos, this.sightPattern[0].MapScale, "OpenMyMemberBaseMenu");
  }

  public void Focus(Vector3 pos, Vector3 scale, string functionName)
  {
    if (!string.IsNullOrEmpty(functionName))
      ((Component) this).gameObject.SendMessage(functionName);
    this.SetTweenScale(this.guildMap, scale, this.focusAnimDuration, true);
    this.SetTweenPosition(this.guildMap, pos, this.focusAnimDuration, true);
  }

  private void OnOpenMenu()
  {
    ((IEnumerable<UITweener>) this.ibtn_Back.GetComponents<UITweener>()).ForEach<UITweener>((Action<UITweener>) (x => x.PlayReverse()));
    ((IEnumerable<UITweener>) this.dir_player_situation.gameObject.GetComponents<UITweener>()).ForEach<UITweener>((Action<UITweener>) (x => x.PlayReverse()));
    ((IEnumerable<UITweener>) this.dir_battle_ready.GetComponents<UITweener>()).ForEach<UITweener>((Action<UITweener>) (x => x.PlayReverse()));
    Singleton<NGSoundManager>.GetInstance().PlaySe("SE_1002");
  }

  public void OpenMyGuildBaseMenu()
  {
    this.OnOpenMenu();
    ((Component) this.myGuildBaseMenuPrefab).GetComponent<Guild0282GuildBaseMenu>().Initialize(this.selectGuildData, this.guildInfoPopup, this.guildMemberPopup, this);
    this.myGuildBaseMenuPrefab.PlayTween(true);
    this.isTouchBlock = false;
  }

  public void OpenMyMemberBaseMenu()
  {
    this.OnOpenMenu();
    ((Component) this.myGuildMemberMenuPrefab).GetComponent<Guild0282MemberBaseMenu>().Initialize(this.selectMemberData, this.guildMemberPopup, this, false, this.MyGuild.gvg_status);
    this.myGuildMemberMenuPrefab.PlayTween(true);
    this.isTouchBlock = false;
  }

  public void OpenEnGuildBaseMenu()
  {
    this.OnOpenMenu();
    ((Component) this.enGuildBaseMenuPrefab).GetComponent<Guild0282GuildBaseMenu>().Initialize(this.selectGuildData, this.guildInfoPopup, this.guildMemberPopup, this);
    this.enGuildBaseMenuPrefab.PlayTween(true);
    this.isTouchBlock = false;
  }

  public void OpenEnMemberBaseMenu()
  {
    this.OnOpenMenu();
    ((Component) this.enGuildMemberMenuPrefab).GetComponent<Guild0282MemberBaseMenu>().Initialize(this.selectMemberData, this.guildMemberPopup, this, true, this.MyGuild.gvg_status);
    this.enGuildMemberMenuPrefab.PlayTween(true);
    this.isTouchBlock = false;
  }

  private bool CloseLingMenu()
  {
    bool flag = false;
    if (((Component) this.enGuildMemberMenuPrefab).gameObject.activeSelf)
      flag = this.enGuildMemberMenuPrefab.PlayTween(false);
    if (((Component) this.enGuildBaseMenuPrefab).gameObject.activeSelf)
      flag = this.enGuildBaseMenuPrefab.PlayTween(false);
    if (((Component) this.myGuildMemberMenuPrefab).gameObject.activeSelf)
      flag = this.myGuildMemberMenuPrefab.PlayTween(false);
    if (((Component) this.myGuildBaseMenuPrefab).gameObject.activeSelf)
      flag = this.myGuildBaseMenuPrefab.PlayTween(false);
    ((IEnumerable<UITweener>) this.dir_battle_ready.GetComponents<UITweener>()).ForEach<UITweener>((Action<UITweener>) (x => x.PlayForward()));
    ((IEnumerable<UITweener>) this.dir_player_situation.gameObject.GetComponents<UITweener>()).ForEach<UITweener>((Action<UITweener>) (x => x.PlayForward()));
    ((IEnumerable<UITweener>) this.ibtn_Back.GetComponents<UITweener>()).ForEach<UITweener>((Action<UITweener>) (x => x.PlayForward()));
    return flag;
  }

  private bool IsLingMenu()
  {
    return ((Component) this.enGuildMemberMenuPrefab).gameObject.activeSelf || ((Component) this.enGuildBaseMenuPrefab).gameObject.activeSelf || ((Component) this.myGuildMemberMenuPrefab).gameObject.activeSelf || ((Component) this.myGuildBaseMenuPrefab).gameObject.activeSelf;
  }

  public bool DoLingMenuDismiss()
  {
    if (!this.IsLingMenu() || Object.op_Inequality((Object) ((Component) this.scrollView).GetComponent<iTween>(), (Object) null) || !this.CloseLingMenu())
      return false;
    Singleton<NGSoundManager>.GetInstance().PlaySe("SE_1004");
    this.selectMemberData = (GuildMembership) null;
    if (this.sightUseNumber != 0)
    {
      Vector3 newPos;
      // ISSUE: explicit constructor call
      ((Vector3) ref newPos).\u002Ector(this.guildMap.transform.localPosition.x, this.guildMap.transform.localPosition.y);
      Vector3 vector3_1;
      // ISSUE: explicit constructor call
      ((Vector3) ref vector3_1).\u002Ector(((Component) this.scrollView).transform.localPosition.x, ((Component) this.scrollView).transform.localPosition.y);
      Vector3 vector3_2;
      // ISSUE: explicit constructor call
      ((Vector3) ref vector3_2).\u002Ector(this.sightPattern[0].MapScale.x, this.sightPattern[0].MapScale.y);
      Vector3 vector3_3;
      // ISSUE: explicit constructor call
      ((Vector3) ref vector3_3).\u002Ector(this.sightPattern[this.sightUseNumber].MapScale.x, this.sightPattern[this.sightUseNumber].MapScale.y);
      // ISSUE: explicit constructor call
      ((Vector3) ref newPos).\u002Ector((newPos.x + vector3_1.x) / vector3_2.x * vector3_3.x - vector3_1.x, (newPos.y + vector3_1.y) / vector3_2.y * vector3_3.y - vector3_1.y);
      this.SetTweenScale(this.guildMap.gameObject, this.sightPattern[this.sightUseNumber].MapScale, this.focusAnimDuration, true);
      this.SetTweenPosition(this.guildMap, newPos, this.focusAnimDuration, true);
    }
    return true;
  }

  private void InitializeMapUI(GuildMapUI ui)
  {
    if (Object.op_Implicit((Object) ui.guildBase))
      Object.Destroy((Object) ((Component) ui.guildBase).gameObject);
    if (ui.memberBaseList != null)
    {
      ui.memberBaseList.ForEach((Action<Guild0282MemberBase>) (x => Object.Destroy((Object) ((Component) x).gameObject)));
      ui.memberBaseList.Clear();
    }
    else
      ui.memberBaseList = new List<Guild0282MemberBase>();
  }

  private bool SetTweenPosition(
    GameObject target,
    Vector3 newPos,
    float duration,
    bool forced = false,
    System.Action action = null)
  {
    if (Object.op_Implicit((Object) target.GetComponent<TweenPosition>()))
    {
      if (!forced)
        return false;
      Object.Destroy((Object) target.GetComponent<TweenPosition>());
    }
    this.tweenPositionCompleteAction = action;
    Hashtable hashtable = this.CreateHashtable(newPos, duration, "TweenPositionComplete", target);
    iTween.MoveTo(target, hashtable);
    return true;
  }

  private bool SetTweenScale(
    GameObject target,
    Vector3 newScale,
    float duration,
    bool forced = false,
    System.Action action = null)
  {
    if (Object.op_Implicit((Object) target.GetComponent<TweenScale>()))
    {
      if (!forced)
        return false;
      Object.Destroy((Object) target.GetComponent<TweenScale>());
    }
    this.tweenScaleCompleteAction = action;
    Hashtable hashtable = this.CreateHashtable(newScale, duration, "TweenScaleComplete", target);
    iTween.ScaleTo(target, hashtable);
    return true;
  }

  private Hashtable CreateHashtable(
    Vector3 setVec3,
    float duration,
    string onComplete,
    GameObject target)
  {
    return new Hashtable()
    {
      {
        (object) "x",
        (object) setVec3.x
      },
      {
        (object) "y",
        (object) setVec3.y
      },
      {
        (object) "time",
        (object) duration
      },
      {
        (object) "islocal",
        (object) true
      },
      {
        (object) "oncomplete",
        (object) onComplete
      },
      {
        (object) "oncompletetarget",
        (object) ((Component) this).gameObject
      }
    };
  }

  private void TweenPositionComplete()
  {
    if (this.tweenPositionCompleteAction == null)
      return;
    this.tweenPositionCompleteAction();
  }

  private void TweenScaleComplete()
  {
    if (this.tweenScaleCompleteAction == null)
      return;
    this.tweenScaleCompleteAction();
  }

  private Vector3 CalcGuildMapPosition(Vector3 pos, Vector3 scale)
  {
    return new Vector3(-pos.x * scale.x - ((Component) this.scrollView).transform.localPosition.x, -pos.y * scale.y - ((Component) this.scrollView).transform.localPosition.y);
  }

  public void SetGvgPopup(GuildUtil.GvGPopupState state, System.Action action)
  {
    GuildUtil.gvgPopupState = state;
    this._actionForGvgPopup = action;
  }

  public void openPopup(GameObject org, bool isCloned = false)
  {
    if (Object.op_Equality((Object) org, (Object) null))
      return;
    this.blackBg.SetActive(true);
    if (Object.op_Inequality((Object) this.gvgPopup, (Object) null))
    {
      Object.Destroy((Object) this.gvgPopup);
      this.gvgPopup = (GameObject) null;
    }
    if (isCloned)
    {
      this.gvgPopup = org;
      this.gvgPopup.transform.parent = this.dyn_battle_edit.transform;
    }
    else
      this.gvgPopup = org.Clone(this.dyn_battle_edit.transform);
    this.gvgPopup.transform.localScale = Vector3.one;
    NGTweenParts componentInChildren = this.gvgPopup.GetComponentInChildren<NGTweenParts>(false);
    if (!Object.op_Inequality((Object) componentInChildren, (Object) null))
      return;
    componentInChildren.forceActive(true);
  }

  public void closePopup(bool hideBlackBg)
  {
    if (hideBlackBg)
      this.blackBg.SetActive(false);
    NGTweenParts componentInChildren = this.gvgPopup.GetComponentInChildren<NGTweenParts>(false);
    if (Object.op_Inequality((Object) componentInChildren, (Object) null))
      componentInChildren.forceActive(false);
    this.StartCoroutine(this.waitForTweenFinish(componentInChildren));
  }

  [DebuggerHidden]
  public IEnumerator waitForTweenFinish(NGTweenParts tween)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282Menu.\u003CwaitForTweenFinish\u003Ec__Iterator77C()
    {
      tween = tween,
      \u003C\u0024\u003Etween = tween,
      \u003C\u003Ef__this = this
    };
  }

  public void OnButtonMating()
  {
    int? nullable = ((IEnumerable<GuildMembership>) this.MyGuild.memberships).FirstIndexOrNull<GuildMembership>((Func<GuildMembership, bool>) (x => x.player.player_id == Player.Current.id));
    if (!nullable.HasValue || this.MyGuild.memberships[nullable.Value].role != GuildRole.master && this.MyGuild.memberships[nullable.Value].role != GuildRole.sub_master)
      return;
    switch (this.MyGuild.gvg_status)
    {
      case GvgStatus.can_entry:
        this.IsPush = true;
        ModalWindow.ShowYesNo(Consts.GetInstance().GUILD_MAP_MATING_ENTRY_TITLE, Consts.GetInstance().GUILD_MAP_MATING_ENTRY_MESSAGE, (System.Action) (() => this.StartCoroutine(this.MatingStart())), (System.Action) (() => this.IsPush = false));
        break;
      case GvgStatus.matching:
        this.IsPush = true;
        ModalWindow.ShowYesNo(Consts.GetInstance().GUILD_MAP_MATING_CANCEL_TITLE, Consts.GetInstance().GUILD_MAP_MATING_CANCEL_MESSAGE, (System.Action) (() => this.StartCoroutine(this.MatingCancel())), (System.Action) (() => this.IsPush = false));
        break;
    }
  }

  [DebuggerHidden]
  public IEnumerator MapReload()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282Menu.\u003CMapReload\u003Ec__Iterator77D()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator MapReload(GuildEventGvg guildEventGvg)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282Menu.\u003CMapReload\u003Ec__Iterator77E()
    {
      guildEventGvg = guildEventGvg,
      \u003C\u0024\u003EguildEventGvg = guildEventGvg,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator MatingStart()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282Menu.\u003CMatingStart\u003Ec__Iterator77F()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator MatingCancel()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282Menu.\u003CMatingCancel\u003Ec__Iterator780()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onButtonATKTeam() => this.StartCoroutine(this.showAtkTeamPopup());

  public void onButtonDEFTeam() => this.StartCoroutine(this.showDefTeamPopup());

  [DebuggerHidden]
  private IEnumerator showAtkTeamPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282Menu.\u003CshowAtkTeamPopup\u003Ec__Iterator781()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator showDefTeamPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282Menu.\u003CshowDefTeamPopup\u003Ec__Iterator782()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator Aggregating()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282Menu.\u003CAggregating\u003Ec__Iterator783()
    {
      \u003C\u003Ef__this = this
    };
  }

  private bool IsEnemy()
  {
    return GuildUtil.isBattleOrPreparing(this.MyGuild.gvg_status) && this.EnGuild != null;
  }
}
