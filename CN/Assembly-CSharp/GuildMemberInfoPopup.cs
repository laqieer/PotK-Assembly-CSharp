// Decompiled with JetBrains decompiler
// Type: GuildMemberInfoPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class GuildMemberInfoPopup : BackButtonMenuBase
{
  private Guild0282Menu guild282Menu;
  private Guild0282GuildBaseMenu guildBaseMenu;
  private GuildMemberObject guildMemberObjs;
  private GuildMembership memberInfo;
  private UnitIcon unitIcon;
  private GameObject unitIconPrefab;
  [SerializeField]
  private UILabel playerName;
  [SerializeField]
  private UI2DSprite playerImage;
  [SerializeField]
  private UI2DSprite emblemImage;
  [SerializeField]
  private UILabel contribution;
  [SerializeField]
  private UILabel contributionValue;
  [SerializeField]
  private UILabel positionValue;
  [SerializeField]
  private UILabel txt_player_level;
  [SerializeField]
  private UILabel playerLv;
  [SerializeField]
  private UILabel guildCoin;
  [SerializeField]
  private UIButton buttonChangeRole;
  [SerializeField]
  private UIButton buttonMap;
  [SerializeField]
  private GameObject dir_position;
  [SerializeField]
  private GameObject slc_master_icon;
  [SerializeField]
  private GameObject slc_submaster_icon;
  [SerializeField]
  private UILabel attackPower;
  [SerializeField]
  private UILabel attackPowerValue;
  [SerializeField]
  private UILabel defensePower;
  [SerializeField]
  private UILabel defensePowerValue;
  private System.Action actionAfterRoleChange;
  private System.Action actionClose;

  [DebuggerHidden]
  public IEnumerator Initialize(
    Guild0282Menu menu,
    GuildMembership info,
    Guild0282GuildBaseMenu baseMenu,
    GuildMemberObject popupObjs,
    System.Action action = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildMemberInfoPopup.\u003CInitialize\u003Ec__Iterator6AF()
    {
      menu = menu,
      info = info,
      baseMenu = baseMenu,
      popupObjs = popupObjs,
      action = action,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u0024\u003Einfo = info,
      \u003C\u0024\u003EbaseMenu = baseMenu,
      \u003C\u0024\u003EpopupObjs = popupObjs,
      \u003C\u0024\u003Eaction = action,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Initialize(
    string player_id,
    Guild0282Menu menu,
    Guild0282GuildBaseMenu baseMenu,
    GuildMemberObject popupObjs,
    System.Action action = null,
    bool showMapButton = true)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildMemberInfoPopup.\u003CInitialize\u003Ec__Iterator6B0()
    {
      player_id = player_id,
      menu = menu,
      baseMenu = baseMenu,
      popupObjs = popupObjs,
      action = action,
      showMapButton = showMapButton,
      \u003C\u0024\u003Eplayer_id = player_id,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u0024\u003EbaseMenu = baseMenu,
      \u003C\u0024\u003EpopupObjs = popupObjs,
      \u003C\u0024\u003Eaction = action,
      \u003C\u0024\u003EshowMapButton = showMapButton,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Initialize(
    string player_id,
    Guild0282Menu menu,
    GuildMemberObject popupObjs,
    System.Action action = null,
    bool showMapButton = true)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildMemberInfoPopup.\u003CInitialize\u003Ec__Iterator6B1()
    {
      player_id = player_id,
      menu = menu,
      popupObjs = popupObjs,
      action = action,
      showMapButton = showMapButton,
      \u003C\u0024\u003Eplayer_id = player_id,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u0024\u003EpopupObjs = popupObjs,
      \u003C\u0024\u003Eaction = action,
      \u003C\u0024\u003EshowMapButton = showMapButton,
      \u003C\u003Ef__this = this
    };
  }

  private void SetRoleChangeButton()
  {
    bool flag = Player.Current.id.Equals(this.memberInfo.player.player_id);
    GuildRole? role1 = PlayerAffiliation.Current.role;
    if ((role1.GetValueOrDefault() != GuildRole.general ? 0 : (role1.HasValue ? 1 : 0)) == 0)
    {
      GuildRole? role2 = PlayerAffiliation.Current.role;
      if ((role2.GetValueOrDefault() != GuildRole.sub_master ? 0 : (role2.HasValue ? 1 : 0)) == 0 || this.memberInfo.role != GuildRole.master)
      {
        GuildRole? role3 = PlayerAffiliation.Current.role;
        if ((role3.GetValueOrDefault() != GuildRole.sub_master ? 0 : (role3.HasValue ? 1 : 0)) == 0 || this.memberInfo.role != GuildRole.sub_master || flag)
          return;
      }
    }
    ((Component) this.buttonChangeRole).gameObject.SetActive(false);
  }

  [DebuggerHidden]
  private IEnumerator SetData(GuildMembership info)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildMemberInfoPopup.\u003CSetData\u003Ec__Iterator6B2()
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
    return (IEnumerator) new GuildMemberInfoPopup.\u003CSetUnitIcon\u003Ec__Iterator6B3()
    {
      info = info,
      \u003C\u0024\u003Einfo = info,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator MoveToMap()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildMemberInfoPopup.\u003CMoveToMap\u003Ec__Iterator6B4()
    {
      \u003C\u003Ef__this = this
    };
  }

  public override void onBackButton()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().dismiss();
    if (this.actionClose == null)
      return;
    this.actionClose();
  }

  public void onMapButton()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.MoveToMap());
  }

  public void onChangePositionButton()
  {
    if (this.IsPushAndSet())
      return;
    this.ShowChangeRolePopup();
  }

  private void ShowChangeRolePopup()
  {
    GameObject prefab = this.guildMemberObjs.GuildPositionManagementPopup.Clone();
    GuildMemberPositionManagementPopup component = prefab.GetComponent<GuildMemberPositionManagementPopup>();
    prefab.SetActive(false);
    component.Initialize(this.guild282Menu, this.memberInfo, this.guildBaseMenu, this.guildMemberObjs, this.actionAfterRoleChange, ((Component) this.buttonMap).gameObject.activeSelf);
    prefab.SetActive(true);
    component.ResetScroll();
    Singleton<PopupManager>.GetInstance().open(prefab, isCloned: true);
    this.IsPush = false;
  }
}
