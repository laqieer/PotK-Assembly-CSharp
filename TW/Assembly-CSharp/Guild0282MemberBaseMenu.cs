// Decompiled with JetBrains decompiler
// Type: Guild0282MemberBaseMenu
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
public class Guild0282MemberBaseMenu : GuildMapObject
{
  [SerializeField]
  private bool isEnemy;
  private GuildMembership MemberData;
  private GuildMemberObject memberPopup;
  public GameObject unitIconPos;
  private UnitIcon unitIcon;
  private GameObject unitIconPrefab;
  private Guild0282Menu guild0282Menu;
  private GameObject guildBattlePreparationPopup;
  [SerializeField]
  private SpreadColorButton ibtn_attack_team;
  [SerializeField]
  private GameObject txt_comeout_before_battled_atk_team;
  [SerializeField]
  private SpreadColorButton ibtn_defense_team;
  [SerializeField]
  private GameObject txt_comeout_before_battled_def_team;
  [SerializeField]
  private SpreadColorButton ibtn_battle;
  [SerializeField]
  private GameObject txt_have_battled;

  public GuildMembership memberData
  {
    get => this.MemberData;
    set => this.MemberData = value;
  }

  [DebuggerHidden]
  public IEnumerator ResourceLoad()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282MemberBaseMenu.\u003CResourceLoad\u003Ec__Iterator763()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void Initialize(
    GuildMembership data,
    GuildMemberObject popup,
    Guild0282Menu menu,
    bool isEnemy,
    GvgStatus gvgStatus)
  {
    this.isEnemy = isEnemy;
    this.MemberData = data;
    this.memberPopup = popup;
    this.guild0282Menu = menu;
    if (Object.op_Equality((Object) this.unitIcon, (Object) null))
      this.unitIcon = this.unitIconPrefab.Clone(this.unitIconPos.transform).GetComponent<UnitIcon>();
    this.StartCoroutine(this.unitIcon.SetUnit(data.player.leader_unit_unit, data.player.leader_unit_unit.GetElement(), false));
    this.unitIcon.setLevelTextToString(data.player.leader_unit_level.ToString());
    this.unitIcon.ShowBottomInfo(UnitSortAndFilter.SORT_TYPES.Level);
    this.unitIcon.button.onClick.Clear();
    this.unitIcon.button.onLongPress.Clear();
    if (this.isEnemy)
    {
      int? nullable = ((IEnumerable<GuildMembership>) PlayerAffiliation.Current.guild.memberships).FirstIndexOrNull<GuildMembership>((Func<GuildMembership, bool>) (x => x.player.player_id == Player.Current.id));
      if (nullable.HasValue)
      {
        this.ibtn_battle.isEnabled = this.memberData.is_defense_membership && GuildUtil.isBattle(gvgStatus) && !this.MemberData.in_battle && PlayerAffiliation.Current.guild.memberships[nullable.Value].action_point != 0 && !menu.IsOpposedPlayer(this.memberData.player.player_id);
        this.txt_have_battled.SetActive(menu.IsOpposedPlayer(this.memberData.player.player_id));
      }
      this.ibtn_attack_team.isEnabled = GuildUtil.isBattle(gvgStatus) && this.memberData.scouted;
      this.txt_comeout_before_battled_atk_team.SetActive(!this.ibtn_attack_team.isEnabled);
      this.ibtn_defense_team.isEnabled = GuildUtil.isBattle(gvgStatus) && this.memberData.scouted;
      this.txt_comeout_before_battled_def_team.SetActive(!this.ibtn_defense_team.isEnabled);
    }
    else
    {
      this.ibtn_attack_team.isEnabled = GuildUtil.isBattleOrPreparing(gvgStatus);
      this.ibtn_defense_team.isEnabled = GuildUtil.isBattleOrPreparing(gvgStatus);
    }
  }

  public override void onBackButton()
  {
  }

  public void onButtonMemberLog()
  {
    Singleton<CommonRoot>.GetInstance().guildChatManager.OpenMemberLogDialog(this.MemberData.player.player_id);
  }

  public void onMemberAbout()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.ShowMemberInfo());
  }

  [DebuggerHidden]
  private IEnumerator ShowMemberInfo()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282MemberBaseMenu.\u003CShowMemberInfo\u003Ec__Iterator764()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onButtonATKTeam()
  {
    Debug.Log((object) "MoveATKTeam");
    this.StartCoroutine(this.showAtkTeamPopup());
  }

  public void onButtonDEFTeam()
  {
    Debug.Log((object) "MoveDEFTeam");
    this.StartCoroutine(this.showDefTeamPopup());
  }

  public void onButtonBattle()
  {
    Debug.Log((object) "MoveBattle");
    this.StartCoroutine(this.ShowBattlePreparationPopup());
  }

  public void onButtonTown()
  {
  }

  public void FriendDetailScene(GuildMembership data)
  {
    GuildPlayerInfo player = PlayerAffiliation.Current.Player;
    if (player.player_id.Equals(Player.Current.id))
      Unit0042Scene.changeScene(true, PlayerUnit.create_by_unitunit(player.leader_unit_unit), SMManager.Get<PlayerUnit[]>());
    else
      Unit0042Scene.changeSceneFriendUnit(true, data.player.player_id);
  }

  [DebuggerHidden]
  private IEnumerator showAtkTeamPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282MemberBaseMenu.\u003CshowAtkTeamPopup\u003Ec__Iterator765()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator showDefTeamPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282MemberBaseMenu.\u003CshowDefTeamPopup\u003Ec__Iterator766()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ShowBattlePreparationPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282MemberBaseMenu.\u003CShowBattlePreparationPopup\u003Ec__Iterator767()
    {
      \u003C\u003Ef__this = this
    };
  }
}
