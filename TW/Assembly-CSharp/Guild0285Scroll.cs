// Decompiled with JetBrains decompiler
// Type: Guild0285Scroll
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
public class Guild0285Scroll : MonoBehaviour
{
  private const int MAX_DISPLAY_DAY_NUM = 3;
  private Guild0285Menu menu;
  private GuildApplicant applicantInfo;
  private UnitIcon unitIcon;
  private GameObject unitIconPrefab;
  private DateTime now;
  private List<string> player_ids;
  [SerializeField]
  private UILabel playerName;
  [SerializeField]
  private UILabel playerLevel;
  [SerializeField]
  private UILabel requestedDate;
  [SerializeField]
  private UILabel txtLastPlay;
  [SerializeField]
  private UILabel txtLastPlayDate;
  [SerializeField]
  private UI2DSprite playerImage;
  [SerializeField]
  private UI2DSprite playerTitleImage;

  [DebuggerHidden]
  public IEnumerator Initialize(Guild0285Menu menu, GuildApplicant applicant, DateTime now)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0285Scroll.\u003CInitialize\u003Ec__Iterator7B0()
    {
      menu = menu,
      applicant = applicant,
      now = now,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u0024\u003Eapplicant = applicant,
      \u003C\u0024\u003Enow = now,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetUnitIcon()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0285Scroll.\u003CSetUnitIcon\u003Ec__Iterator7B1()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onDetails(GuildPlayerInfo playerInfo)
  {
    Unit0042Scene.changeSceneFriendUnit(true, playerInfo.player_id);
  }

  protected void SetApplication(UILabel label)
  {
    DateTime dateTime = new DateTime(this.applicantInfo.applied_at.Year, this.applicantInfo.applied_at.Month, this.applicantInfo.applied_at.Day);
    TimeSpan self = ServerTime.NowAppTime() - dateTime;
    label.SetTextLocalize(Consts.Format(Consts.GetInstance().FRIEND_0085SCROLLPARTS_DESCRIPTION01, (IDictionary) new Hashtable()
    {
      {
        (object) "dsfapplied",
        (object) self.DisplayStringForFriendsApplied().ToConverter()
      }
    }));
  }

  private void SetData()
  {
    this.txtLastPlay.SetTextLocalize(Consts.Format(Consts.GetInstance().GUILD_28_5_LAST_LOGIN));
    this.playerName.SetTextLocalize(this.applicantInfo.player.player_name);
    this.playerLevel.SetTextLocalize(this.applicantInfo.player.player_level);
    TimeSpan self = this.now - this.applicantInfo.player.last_signed_in_at;
    if (self.Days < 3)
      this.txtLastPlayDate.SetTextLocalize(Consts.Format(Consts.GetInstance().GUILD_28_5_LAST_LOGIN_DATE, (IDictionary) new Hashtable()
      {
        {
          (object) "time",
          (object) self.DisplayString()
        }
      }));
    else
      this.txtLastPlayDate.SetTextLocalize(Consts.GetInstance().GUILD_28_5_LAST_LOGIN_DATE2);
  }

  [DebuggerHidden]
  private IEnumerator Accept()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0285Scroll.\u003CAccept\u003Ec__Iterator7B2()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onAcceptButton()
  {
    if (PlayerAffiliation.Current.onGvgOperation)
      this.menu.ShowOkPopup(Consts.GetInstance().GUILD_28_5_ACCEPT_REQUEST_TITLE, PlayerAffiliation.Current.guild.gvg_status != GvgStatus.preparing ? Consts.GetInstance().GUILD_28_5_ACCEPT_ERROR_GVG : Consts.GetInstance().GUILD_28_5_ACCEPT_ERROR_GVG_PREPARE);
    else if (PlayerAffiliation.Current.guild.appearance.membership_num < PlayerAffiliation.Current.guild.appearance.membership_capacity)
      this.StartCoroutine(this.Accept());
    else
      this.menu.ShowOkPopup(Consts.Format(Consts.GetInstance().GUILD_28_5_ACCEPT_REQUEST_TITLE), Consts.Format(Consts.GetInstance().GUILD_28_5_ACCEAT_FAILED_DESC));
  }

  [DebuggerHidden]
  private IEnumerator Refuse()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0285Scroll.\u003CRefuse\u003Ec__Iterator7B3()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onRefuseButton()
  {
    if (PlayerAffiliation.Current.onGvgOperation)
      this.menu.ShowOkPopup(Consts.GetInstance().GUILD_28_5_REJECT_REQUEST_TITLE, PlayerAffiliation.Current.guild.gvg_status != GvgStatus.preparing ? Consts.GetInstance().GUILD_28_5_REJECT_ERROR_GVG : Consts.GetInstance().GUILD_28_5_REJECT_ERROR_GVG_PREPARE);
    else
      this.StartCoroutine(this.Refuse());
  }
}
