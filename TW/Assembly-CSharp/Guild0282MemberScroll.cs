// Decompiled with JetBrains decompiler
// Type: Guild0282MemberScroll
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Guild0282MemberScroll : MonoBehaviour
{
  private bool isEnemy;
  private GuildMemberListPopup memberListPopup;
  private Guild0282Menu guild282Menu;
  private Guild0282GuildBaseMenu guildBaseMenu;
  private GuildMembership guildMemberInfo;
  private GuildMemberObject guildMemberObjs;
  private System.Action actionAfterRoleChange;
  private UnitIcon unitIcon;
  private GameObject unitIconPrefab;
  [SerializeField]
  private UI2DSprite playerImage;
  [SerializeField]
  private UI2DSprite emblemImage;
  [SerializeField]
  private UILabel playerName;
  [SerializeField]
  private UILabel contribution;
  [SerializeField]
  private UILabel contributionValue;
  [SerializeField]
  private UILabel txt_playerlv;
  [SerializeField]
  private UILabel playerLv;
  [SerializeField]
  private GameObject slcListbasePlayer;
  [SerializeField]
  private GameObject slcListbaseMember;
  [SerializeField]
  private GameObject masterIconObj;
  [SerializeField]
  private GameObject subMasterIconObj;
  [SerializeField]
  private UILabel txt_nonparticipation;
  [SerializeField]
  private GameObject dir_remain_battle_count;
  [SerializeField]
  private GameObject dir_stars_get;
  [SerializeField]
  private UILabel txt_stars_get;
  [SerializeField]
  private UILabel lbl_star_acquired;
  [SerializeField]
  private GameObject dir_star_possession;
  [SerializeField]
  private List<GameObject> stars;
  [SerializeField]
  private List<Guild0282MemberScroll.BattleCountIcon> battleCountIcon;
  [SerializeField]
  private UILabel txt_last_login_at;

  [DebuggerHidden]
  public IEnumerator Initialize(
    bool is_enemy,
    GuildMemberListPopup popup,
    GuildMembership info,
    Guild0282Menu guildMenu,
    Guild0282GuildBaseMenu baseMenu,
    GuildMemberObject popupObjs,
    System.Action action = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282MemberScroll.\u003CInitialize\u003Ec__Iterator768()
    {
      is_enemy = is_enemy,
      popup = popup,
      info = info,
      guildMenu = guildMenu,
      baseMenu = baseMenu,
      popupObjs = popupObjs,
      action = action,
      \u003C\u0024\u003Eis_enemy = is_enemy,
      \u003C\u0024\u003Epopup = popup,
      \u003C\u0024\u003Einfo = info,
      \u003C\u0024\u003EguildMenu = guildMenu,
      \u003C\u0024\u003EbaseMenu = baseMenu,
      \u003C\u0024\u003EpopupObjs = popupObjs,
      \u003C\u0024\u003Eaction = action,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetData(GuildMembership info)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282MemberScroll.\u003CSetData\u003Ec__Iterator769()
    {
      info = info,
      \u003C\u0024\u003Einfo = info,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetLastLoginText(bool onGvg, GuildMembership info)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282MemberScroll.\u003CSetLastLoginText\u003Ec__Iterator76A()
    {
      onGvg = onGvg,
      info = info,
      \u003C\u0024\u003EonGvg = onGvg,
      \u003C\u0024\u003Einfo = info,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetUnitIcon(GuildMembership info)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282MemberScroll.\u003CSetUnitIcon\u003Ec__Iterator76B()
    {
      info = info,
      \u003C\u0024\u003Einfo = info,
      \u003C\u003Ef__this = this
    };
  }

  public void FriendDetailScene(GuildPlayerInfo playerInfo)
  {
    Singleton<PopupManager>.GetInstance().dismiss();
    if (playerInfo.player_id.Equals(Player.Current.id))
      Unit0042Scene.changeScene(true, PlayerUnit.create_by_unitunit(playerInfo.leader_unit_unit), SMManager.Get<PlayerUnit[]>());
    else
      Unit0042Scene.changeSceneFriendUnit(true, playerInfo.player_id);
  }

  public void onMemberButton()
  {
    if (this.memberListPopup.IsPushAndSet())
      return;
    this.StartCoroutine(this.ShowMemberInfo());
  }

  [DebuggerHidden]
  private IEnumerator ShowMemberInfo()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282MemberScroll.\u003CShowMemberInfo\u003Ec__Iterator76C()
    {
      \u003C\u003Ef__this = this
    };
  }

  [Serializable]
  private class BattleCountIcon
  {
    [SerializeField]
    public GameObject inBattle;
    [SerializeField]
    public GameObject own;
    [SerializeField]
    public GameObject enemy;
  }
}
