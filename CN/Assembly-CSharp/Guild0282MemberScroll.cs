// Decompiled with JetBrains decompiler
// Type: Guild0282MemberScroll
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Guild0282MemberScroll : MonoBehaviour
{
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
  private UISprite star1;
  [SerializeField]
  private UISprite star2;
  [SerializeField]
  private UISprite star3;
  [SerializeField]
  private GameObject slcListbasePlayer;
  [SerializeField]
  private GameObject slcListbaseMember;
  [SerializeField]
  private GameObject masterIconObj;
  [SerializeField]
  private GameObject subMasterIconObj;

  [DebuggerHidden]
  public IEnumerator Initialize(
    GuildMemberListPopup popup,
    GuildMembership info,
    Guild0282Menu guildMenu,
    Guild0282GuildBaseMenu baseMenu,
    GuildMemberObject popupObjs,
    System.Action action = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282MemberScroll.\u003CInitialize\u003Ec__Iterator6C8()
    {
      popup = popup,
      info = info,
      guildMenu = guildMenu,
      baseMenu = baseMenu,
      popupObjs = popupObjs,
      action = action,
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
    return (IEnumerator) new Guild0282MemberScroll.\u003CSetData\u003Ec__Iterator6C9()
    {
      info = info,
      \u003C\u0024\u003Einfo = info,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetUnitIcon(GuildMembership info)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0282MemberScroll.\u003CSetUnitIcon\u003Ec__Iterator6CA()
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
    return (IEnumerator) new Guild0282MemberScroll.\u003CShowMemberInfo\u003Ec__Iterator6CB()
    {
      \u003C\u003Ef__this = this
    };
  }
}
