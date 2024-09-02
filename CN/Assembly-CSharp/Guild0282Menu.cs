// Decompiled with JetBrains decompiler
// Type: Guild0282Menu
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
public class Guild0282Menu : BackButtonMenuBase
{
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
  private Guild0282Menu.UIStatusState uiStatusState;
  [SerializeField]
  private GameObject uiStatusUsualObj;
  [SerializeField]
  private StatusUsual uiStatusUsual;
  [SerializeField]
  private GameObject uiStatusReadyObj;
  [SerializeField]
  private GameObject uiStatusInBattleObj;
  [SerializeField]
  private StatusInBattle uiStatusInBattle;
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
  private Guild0282Menu.MattingState mattingState;
  private bool isEnemyGuild;
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
  private GameObject guildBasePrefab;
  private GameObject cloudPrefab;
  private GameObject entryConfirmPrefab;
  [SerializeField]
  private Transform middle;
  private bool isTouchBlock;
  private bool isMatting;
  private GuildInfoPopup guildInfoPopup;
  private GuildMemberObject guildMemberPopup;
  public System.Action actionAtInitialize;
  private bool isUpdate;
  private GuildRegistration selectGuildData;
  private GuildMembership selectMemberData;
  [SerializeField]
  private GameObject cloudAnimParent;
  private System.Action tweenPositionCompleteAction;
  private System.Action tweenScaleCompleteAction;
  private GuildImageCache guildImageCache;
  private GuildImageCache memberImageCache;

  public GuildMapUI MyGuildUI => this.myGuildUI;

  [DebuggerHidden]
  public IEnumerator InitializeAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282Menu.\u003CInitializeAsync\u003Ec__Iterator6D0()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void Initialize(GuildMembership member)
  {
    this.Initialize();
    this.JumpMember(member);
  }

  public void MemberBaseUpdate()
  {
    foreach (GuildMembership membership in PlayerAffiliation.Current.guild.memberships)
    {
      GuildMembership member = membership;
      Guild0282MemberBase guild0282MemberBase = this.MyGuildUI.memberBaseList.Find((Predicate<Guild0282MemberBase>) (x => x.Member.player.player_id == member.player.player_id));
      if (Object.op_Inequality((Object) guild0282MemberBase, (Object) null))
        guild0282MemberBase.Initialize(member, this, this.guildImageCache);
    }
  }

  private void CloudCreater(Transform trans)
  {
    if (((Object) trans).name == "cloud_anim_pos")
      this.cloudPrefab.Clone(trans);
    foreach (Transform child in trans.GetChildren())
      this.CloudCreater(child);
  }

  public void Initialize()
  {
    this.IsPush = false;
    if (this.isUpdate)
      return;
    this.isUpdate = false;
    this.CloudCreater(this.cloudAnimParent.transform);
    this.InitializeMapUI(this.myGuildUI);
    this.InitializeMapUI(this.enGuildUI);
    this.sightUseNumber = 0;
    this.SetSightPattern(this.sightUseNumber);
    switch (this.uiStatusState)
    {
      case Guild0282Menu.UIStatusState.Usual:
        this.uiStatusUsualObj.SetActive(true);
        this.uiStatusReadyObj.SetActive(false);
        this.uiStatusInBattleObj.SetActive(false);
        this.uiStatusUsual.SetStatus(this.myGuild);
        break;
      case Guild0282Menu.UIStatusState.Ready:
        this.uiStatusUsualObj.SetActive(false);
        this.uiStatusReadyObj.SetActive(true);
        this.uiStatusInBattleObj.SetActive(false);
        break;
      case Guild0282Menu.UIStatusState.InBattle:
        this.uiStatusUsualObj.SetActive(false);
        this.uiStatusReadyObj.SetActive(false);
        this.uiStatusInBattleObj.SetActive(true);
        this.uiStatusInBattle.SetStatus(this.myGuild, this.enGuild);
        break;
    }
    this.CreateGuildMap();
    this.UpdateMattingUI();
    if (this.actionAtInitialize == null)
      return;
    this.actionAtInitialize();
    this.actionAtInitialize = (System.Action) null;
  }

  public void onEndScene()
  {
  }

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
    this.Focus(this.CalcGuildMapPosition(((Component) this.MyGuildUI.guildBase).transform.parent.localPosition, this.sightPattern[0].MapScale), this.sightPattern[0].MapScale, string.Empty);
  }

  public void JumpMember(GuildMembership member)
  {
    if (member == null || !((IEnumerable<GuildMembership>) this.myGuild.memberships).FirstIndexOrNull<GuildMembership>((Func<GuildMembership, bool>) (x => x.player.player_id == member.player.player_id)).HasValue)
    {
      this.JumpGuildBase();
    }
    else
    {
      this.CloseLingMenu();
      this.selectMemberData = member;
      Guild0282MemberBase guild0282MemberBase = this.myGuildUI.memberBaseList.Find((Predicate<Guild0282MemberBase>) (x => x.Member.player.player_id == member.player.player_id));
      if (!Object.op_Inequality((Object) guild0282MemberBase, (Object) null))
        return;
      this.Focus(this.CalcGuildMapPosition(((Component) guild0282MemberBase).transform.parent.localPosition, this.sightPattern[0].MapScale), this.sightPattern[0].MapScale, "OpenMyMemberBaseMenu");
    }
  }

  [DebuggerHidden]
  private IEnumerator ResourceLoad()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282Menu.\u003CResourceLoad\u003Ec__Iterator6D1()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void CreateGuildMap(GuildMapUI guildMapUI, GuildRegistration guildData)
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
    guildMapUI.guildBase.Initialize(guildData, this, this.guildImageCache);
    for (int index = 0; index < guildData.memberships.Length; ++index)
    {
      Guild0282MemberBase component = this.guildMemberBasePrefab.Clone(guildMapUI.memberBasePosition[index].transform).GetComponent<Guild0282MemberBase>();
      component.Initialize(guildData.memberships[index], this, this.guildImageCache);
      guildMapUI.memberBaseList.Add(component);
    }
  }

  private void CreateGuildMap()
  {
    this.CreateGuildMap(this.myGuildUI, this.myGuild);
    this.enGuildUI.SetActive(this.EnemyGuild());
    if (!this.EnemyGuild())
      return;
    this.CreateGuildMap(this.enGuildUI, this.enGuild);
  }

  private void SetSightPattern(int number)
  {
    for (int index = 0; index < this.sightPattern.Count; ++index)
      this.sightPattern[index].SightImage.SetActive(index == number);
    this.SetTweenScale(this.guildMap, this.sightPattern[number].MapScale, this.cameraChangeDuration, true);
  }

  private bool IsGuildBattle() => false;

  private bool EnemyGuild() => this.isEnemyGuild;

  [DebuggerHidden]
  private IEnumerator ShowMyMemberList()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282Menu.\u003CShowMyMemberList\u003Ec__Iterator6D2()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ShowEnMemberList()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282Menu.\u003CShowEnMemberList\u003Ec__Iterator6D3()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void BackScene() => this.backScene();

  public override void onBackButton()
  {
    if (Singleton<PopupManager>.GetInstance().isOpen)
      Singleton<PopupManager>.GetInstance().dismiss();
    else if (this.IsLingMenu())
      this.DoLingMenuDismiss();
    else if (Singleton<CommonRoot>.GetInstance().guildChatManager.GetCurrentGuildChatStatus() == GuildChatManager.GuildChatStatus.DetailedView)
      Singleton<CommonRoot>.GetInstance().guildChatManager.CloseDetailedChat();
    else
      this.BackScene();
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

  public void onButtonEntry()
  {
    this.isMatting = true;
    this.UpdateMattingUI();
  }

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
    if (this.isMatting)
    {
      if (Random.Range(0, 100) != 77)
        return;
      this.isMatting = false;
      this.enGuild = this.myGuild;
      this.Initialize();
    }
    else
    {
      if (!this.EnemyGuild() || this.IsGuildBattle() || Random.Range(0, 100) != 77)
        return;
      this.Initialize();
    }
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

  public void OpenMyGuildBaseMenu()
  {
    Singleton<NGSoundManager>.GetInstance().PlaySe("SE_1002");
    ((Component) this.myGuildBaseMenuPrefab).GetComponent<Guild0282GuildBaseMenu>().Initialize(this.selectGuildData, this.guildInfoPopup, this.guildMemberPopup, this);
    this.myGuildBaseMenuPrefab.PlayTween(true);
    this.isTouchBlock = false;
  }

  public void OpenMyMemberBaseMenu()
  {
    Singleton<NGSoundManager>.GetInstance().PlaySe("SE_1002");
    ((Component) this.myGuildMemberMenuPrefab).GetComponent<Guild0282MemberBaseMenu>().Initialize(this.selectMemberData, this.guildMemberPopup, this);
    this.myGuildMemberMenuPrefab.PlayTween(true);
    this.isTouchBlock = false;
  }

  public void OpenEnGuildBaseMenu()
  {
    Singleton<NGSoundManager>.GetInstance().PlaySe("SE_1002");
    ((Component) this.enGuildBaseMenuPrefab).GetComponent<Guild0282GuildBaseMenu>().Initialize(this.selectGuildData, this.guildInfoPopup, this.guildMemberPopup, this);
    this.enGuildBaseMenuPrefab.PlayTween(true);
    this.isTouchBlock = false;
  }

  public void OpenEnMemberBaseMenu()
  {
    Singleton<NGSoundManager>.GetInstance().PlaySe("SE_1002");
    ((Component) this.enGuildMemberMenuPrefab).GetComponent<Guild0282MemberBaseMenu>().Initialize(this.selectMemberData, this.guildMemberPopup, this);
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

  private void UpdateMattingUI()
  {
    this.mattingState = Guild0282Menu.MattingState.GuildBattleClose;
    this.NotEnoughMemberObj.SetActive(false);
    this.WaitingForEnteryToStart.SetActive(false);
    this.Matching.SetActive(false);
    this.WaitingForEnteryMember.SetActive(false);
    this.GuildBattleClose.SetActive(true);
    this.entryButton.isEnabled = false;
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

  public void onTestButtonDrawEnemy()
  {
    this.enGuild = PlayerAffiliation.Current.guild;
    this.isEnemyGuild = !this.isEnemyGuild;
    this.Initialize();
  }

  private enum UIStatusState
  {
    Usual,
    Ready,
    InBattle,
  }

  private enum MattingState
  {
    NotEnoughMember,
    WaitingForEnteryToStart,
    Matching,
    WaitingForEnteryMember,
    GuildBattleClose,
    NoProblem,
  }
}
