﻿// Decompiled with JetBrains decompiler
// Type: Guild0285Menu
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
using UnityEngine;

#nullable disable
public class Guild0285Menu : GuildApplicantsBarBase
{
  private const int MAX_APPLICANT_NUM = 30;
  private const int Width = 612;
  private const int Height = 157;
  private const int ColumnValue = 1;
  private const int RowValue = 8;
  private const int ScreenValue = 5;
  private GameObject scrollObj;
  [SerializeField]
  private UILabel txtTitle;
  [SerializeField]
  private UILabel txtMemberNum;
  [SerializeField]
  private UILabel txtMember;
  [SerializeField]
  private GameObject dirNoApplicant;
  [SerializeField]
  private UILabel txtNoApplicant;
  [SerializeField]
  private UIButton btnAllReject;
  [SerializeField]
  private UIButton btnAllAccept;
  private GameObject commonOkPopup;

  public GameObject CommonOkPupup => this.commonOkPopup;

  [DebuggerHidden]
  public IEnumerator InitializeAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0285Menu.\u003CInitializeAsync\u003Ec__Iterator7A8()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void Initialize()
  {
    this.txtTitle.SetTextLocalize(Consts.Format(Consts.GetInstance().GUILD_28_5_MENU_TITLE));
    this.txtMember.SetTextLocalize(Consts.Format(Consts.GetInstance().GUILD_28_5_MEMBER_NUM));
    this.txtNoApplicant.SetTextLocalize(Consts.Format(Consts.GetInstance().GUILD_28_5_NO_APPLICANT));
    if (Persist.guildSetting.Exists)
    {
      GuildUtil.setBadgeState(GuildUtil.GuildBadgeInfoType.newApplicant, false);
      Persist.guildSetting.Flush();
    }
    Singleton<CommonRoot>.GetInstance().SetGuildFooterBadgeBikkuri();
  }

  [DebuggerHidden]
  public IEnumerator InitApplicantScroll(GuildApplicant[] applicants)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0285Menu.\u003CInitApplicantScroll\u003Ec__Iterator7A9()
    {
      applicants = applicants,
      \u003C\u0024\u003Eapplicants = applicants,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected override IEnumerator CreateScroll(int info_index, int bar_index)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0285Menu.\u003CCreateScroll\u003Ec__Iterator7AA()
    {
      bar_index = bar_index,
      info_index = info_index,
      \u003C\u0024\u003Ebar_index = bar_index,
      \u003C\u0024\u003Einfo_index = info_index,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator RefreshList()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0285Menu.\u003CRefreshList\u003Ec__Iterator7AB()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ResourceLoad()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0285Menu.\u003CResourceLoad\u003Ec__Iterator7AC()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void ShowOkPopup(string title, string message, System.Action ok = null)
  {
    GuildOkPopup component = Singleton<PopupManager>.GetInstance().open(this.commonOkPopup).GetComponent<GuildOkPopup>();
    System.Action action = ok;
    string title1 = title;
    string message1 = message;
    Vector2? size = new Vector2?();
    System.Action ok1 = action;
    component.Initialize(title1, message1, size, ok1);
  }

  public void ShowLoading()
  {
    Singleton<CommonRoot>.GetInstance().loadingMode = 1;
    Singleton<CommonRoot>.GetInstance().isLoading = true;
  }

  public void HideLoading()
  {
    Singleton<CommonRoot>.GetInstance().isLoading = false;
    Singleton<CommonRoot>.GetInstance().loadingMode = 0;
  }

  [DebuggerHidden]
  public IEnumerator Accept(
    string[] player_ids,
    System.Action actionSuccess = null,
    Action<WebAPI.Response.UserError> actionFailure = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0285Menu.\u003CAccept\u003Ec__Iterator7AD()
    {
      player_ids = player_ids,
      actionFailure = actionFailure,
      actionSuccess = actionSuccess,
      \u003C\u0024\u003Eplayer_ids = player_ids,
      \u003C\u0024\u003EactionFailure = actionFailure,
      \u003C\u0024\u003EactionSuccess = actionSuccess,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Refuse(
    string[] player_ids,
    System.Action actionSuccess = null,
    Action<WebAPI.Response.UserError> actionFailure = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0285Menu.\u003CRefuse\u003Ec__Iterator7AE()
    {
      player_ids = player_ids,
      actionFailure = actionFailure,
      actionSuccess = actionSuccess,
      \u003C\u0024\u003Eplayer_ids = player_ids,
      \u003C\u0024\u003EactionFailure = actionFailure,
      \u003C\u0024\u003EactionSuccess = actionSuccess,
      \u003C\u003Ef__this = this
    };
  }

  public void onRefuseBulkButton()
  {
    if (this.IsPushAndSet())
      return;
    List<string> stringList = new List<string>();
    for (int index = 0; index < this.allApplicantInfo.Count; ++index)
      stringList.Add(this.allApplicantInfo[index].applicant.player.player_id);
    this.StartCoroutine(this.Refuse(stringList.ToArray(), (System.Action) (() => this.ShowOkPopup(Consts.Format(Consts.GetInstance().GUILD_28_5_REJECT_REQUEST_TITLE), Consts.Format(Consts.GetInstance().GUILD_28_5_REJECT_BULK_DESC))), (Action<WebAPI.Response.UserError>) (error =>
    {
      if (error.Code.Equals("GLD006"))
      {
        this.ShowOkPopup(Consts.GetInstance().GUILD_28_5_REJECT_REQUEST_TITLE, Consts.GetInstance().GUILD_28_5_REFUSE_ERROR);
      }
      else
      {
        if (!error.Code.Equals("GVG002"))
          return;
        this.ShowOkPopup(Consts.GetInstance().GUILD_28_5_REJECT_REQUEST_TITLE, PlayerAffiliation.Current.guild.gvg_status != GvgStatus.preparing ? Consts.GetInstance().GUILD_28_5_REJECT_ERROR_GVG : Consts.GetInstance().GUILD_28_5_REJECT_ERROR_GVG_PREPARE);
      }
    })));
  }

  public void onAcceptBulkButton()
  {
    if (this.IsPushAndSet())
      return;
    int num = PlayerAffiliation.Current.guild.appearance.membership_capacity - PlayerAffiliation.Current.guild.memberships.Length;
    if (num <= 0)
    {
      this.ShowOkPopup(Consts.Format(Consts.GetInstance().GUILD_28_5_ACCEPT_REQUEST_TITLE), Consts.Format(Consts.GetInstance().GUILD_28_5_ACCEAT_FAILED_DESC));
    }
    else
    {
      int count = this.allApplicantInfo.Count;
      if (count > num)
        count = num;
      List<string> stringList = new List<string>();
      for (int index = 0; index < count; ++index)
        stringList.Add(this.allApplicantInfo[index].applicant.player.player_id);
      this.StartCoroutine(this.Accept(stringList.ToArray(), (System.Action) (() => this.ShowOkPopup(Consts.Format(Consts.GetInstance().GUILD_28_5_ACCEPT_REQUEST_TITLE), Consts.Format(Consts.GetInstance().GUILD_28_5_ACCEAPT_BULK_DESC, (IDictionary) new Hashtable()
      {
        {
          (object) "num",
          (object) count
        }
      }))), (Action<WebAPI.Response.UserError>) (error =>
      {
        if (error.Code.Equals("GLD006"))
        {
          this.ShowOkPopup(Consts.GetInstance().GUILD_28_5_ACCEPT_REQUEST_TITLE, Consts.GetInstance().GUILD_28_5_ACCEPT_ERROR);
        }
        else
        {
          if (!error.Code.Equals("GVG002"))
            return;
          this.ShowOkPopup(Consts.GetInstance().GUILD_28_5_ACCEPT_REQUEST_TITLE, PlayerAffiliation.Current.guild.gvg_status != GvgStatus.preparing ? Consts.GetInstance().GUILD_28_5_ACCEPT_ERROR_GVG : Consts.GetInstance().GUILD_28_5_ACCEPT_ERROR_GVG_PREPARE);
        }
      })));
    }
  }

  public override void onBackButton()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  protected override void Update()
  {
    base.Update();
    this.ScrollUpdate();
  }
}
