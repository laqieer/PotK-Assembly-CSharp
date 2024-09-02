// Decompiled with JetBrains decompiler
// Type: GuildGuestSelectScroll
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
public class GuildGuestSelectScroll : MonoBehaviour
{
  [SerializeField]
  private GameObject slc_icon_guildmaseter;
  [SerializeField]
  private GameObject slc_icon_submaseter;
  [SerializeField]
  private GameObject link_Character;
  [SerializeField]
  private UILabel lblFriendName;
  [SerializeField]
  private GameObject dir_player_info;
  [SerializeField]
  private GameObject dir_player_info_master;
  [SerializeField]
  private GameObject slc_icon_guildmaster;
  [SerializeField]
  private GameObject slc_icon_submaster;
  [SerializeField]
  private UILabel lblFriendName_master;
  [SerializeField]
  private UILabel lblFriendSkillName;
  [SerializeField]
  private UILabel lblFriendSkillDesc;
  [SerializeField]
  private UI2DSprite playerTitle;
  [SerializeField]
  private UI2DSprite playerTitle_master;
  [SerializeField]
  private GameObject dir_unit_rented;
  [SerializeField]
  private UIButton btnDecide;
  [SerializeField]
  private GameObject dir_Friendlist_None;
  [SerializeField]
  private GameObject dir_Friendlist;
  private GameObject unitIconPrefab;
  private UnitIcon unitIcon;
  private Action<GvgCandidate> decideButtonAction;
  private GvgCandidate friend;
  private GuildGuestSelectScroll.MODE mode;

  [DebuggerHidden]
  private IEnumerator SetUnitIcon(GvgCandidate friend)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildGuestSelectScroll.\u003CSetUnitIcon\u003Ec__Iterator78A()
    {
      friend = friend,
      \u003C\u0024\u003Efriend = friend,
      \u003C\u003Ef__this = this
    };
  }

  private void SetMemberPositionIcon(string member_id)
  {
    int? nullable = ((IEnumerable<GuildMembership>) PlayerAffiliation.Current.guild.memberships).FirstIndexOrNull<GuildMembership>((Func<GuildMembership, bool>) (x => x.player.player_id.Equals(member_id)));
    if (!nullable.HasValue)
      return;
    GuildMembership membership = PlayerAffiliation.Current.guild.memberships[nullable.Value];
    bool flag = membership.role == GuildRole.general;
    this.dir_player_info.SetActive(flag);
    this.dir_player_info_master.SetActive(!flag);
    if (flag)
      return;
    this.slc_icon_guildmaster.SetActive(membership.role == GuildRole.master);
    this.slc_icon_submaster.SetActive(membership.role == GuildRole.sub_master);
  }

  [DebuggerHidden]
  public IEnumerator InitializeAsync(
    GvgCandidate friend,
    GuildGuestSelectScroll.MODE mode,
    Action<GvgCandidate> action)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildGuestSelectScroll.\u003CInitializeAsync\u003Ec__Iterator78B()
    {
      friend = friend,
      mode = mode,
      action = action,
      \u003C\u0024\u003Efriend = friend,
      \u003C\u0024\u003Emode = mode,
      \u003C\u0024\u003Eaction = action,
      \u003C\u003Ef__this = this
    };
  }

  public void DecideButton()
  {
    if (this.decideButtonAction == null)
      return;
    this.decideButtonAction(this.friend);
  }

  public enum MODE
  {
    Atk,
    Def,
  }
}
