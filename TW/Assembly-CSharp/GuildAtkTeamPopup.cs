// Decompiled with JetBrains decompiler
// Type: GuildAtkTeamPopup
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
public class GuildAtkTeamPopup : BackButtonMenuBase
{
  private const float LINK_WIDTH = 92f;
  private const float LINK_DEFWIDTH = 114f;
  private const float scale = 0.807017565f;
  private bool isEnemy;
  private bool myself;
  [SerializeField]
  private GameObject dyn_leader_unit;
  [SerializeField]
  private UILabel lblPlayerName;
  [SerializeField]
  private UILabel lblTotalPower;
  [SerializeField]
  private UI2DSprite playerTitle;
  [SerializeField]
  private GameObject slc_icon_guildmaseter;
  [SerializeField]
  private GameObject slc_icon_submaseter;
  [SerializeField]
  private UIButton btnEquipment;
  [SerializeField]
  private UIButton btnTeamEdit;
  [SerializeField]
  private GameObject dir_unavailable_teamformation;
  [SerializeField]
  private UILabel lblLeaderSkillName;
  [SerializeField]
  private UILabel lblLeaderSkillDesc;
  [SerializeField]
  private UILabel lblSelectFriendLater;
  [SerializeField]
  protected GameObject[] linkCharacters;
  private UnitIcon unitIcon;
  private GameObject unitIconPrefab;
  private GvgDeck deckInfo;
  private Guild0282Menu guild0282Menu;
  private GameObject commonOkPopup;

  private int totalCombat
  {
    get
    {
      if (this.deckInfo == null)
        return 0;
      int combat = 0;
      ((IEnumerable<PlayerUnit>) this.deckInfo.player_units).ForEach<PlayerUnit>((Action<PlayerUnit>) (x =>
      {
        if (!(x != (PlayerUnit) null))
          return;
        combat += Judgement.NonBattleParameter.FromPlayerUnit(x).Combat;
      }));
      return combat;
    }
  }

  [DebuggerHidden]
  private IEnumerator SetPlayerInfo(GuildMembership info)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildAtkTeamPopup.\u003CSetPlayerInfo\u003Ec__Iterator70F()
    {
      info = info,
      \u003C\u0024\u003Einfo = info,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetUnitIcon(GuildMembership info)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildAtkTeamPopup.\u003CSetUnitIcon\u003Ec__Iterator710()
    {
      info = info,
      \u003C\u0024\u003Einfo = info,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetDeck()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildAtkTeamPopup.\u003CSetDeck\u003Ec__Iterator711()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator LoadUnitPrefab(int index, PlayerUnit unit, bool isFriend)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildAtkTeamPopup.\u003CLoadUnitPrefab\u003Ec__Iterator712()
    {
      index = index,
      unit = unit,
      isFriend = isFriend,
      \u003C\u0024\u003Eindex = index,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u0024\u003EisFriend = isFriend,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ChangeDetailScene(PlayerUnit unit, bool isFriend, int index)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildAtkTeamPopup.\u003CChangeDetailScene\u003Ec__Iterator713()
    {
      isFriend = isFriend,
      unit = unit,
      index = index,
      \u003C\u0024\u003EisFriend = isFriend,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u0024\u003Eindex = index,
      \u003C\u003Ef__this = this
    };
  }

  private void DestroyObject()
  {
    foreach (GameObject linkCharacter in this.linkCharacters)
    {
      UnitIcon componentInChildren = linkCharacter.GetComponentInChildren<UnitIcon>();
      if (Object.op_Inequality((Object) componentInChildren, (Object) null))
        Object.Destroy((Object) ((Component) componentInChildren).gameObject);
    }
  }

  [DebuggerHidden]
  private IEnumerator ShowDeckEditScene()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildAtkTeamPopup.\u003CShowDeckEditScene\u003Ec__Iterator714()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ShowEquipScene()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildAtkTeamPopup.\u003CShowEquipScene\u003Ec__Iterator715()
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

  [DebuggerHidden]
  public IEnumerator InitializeAsync(
    bool isEnemy,
    Guild0282Menu menu,
    GuildMembership info,
    System.Action success = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildAtkTeamPopup.\u003CInitializeAsync\u003Ec__Iterator716()
    {
      isEnemy = isEnemy,
      menu = menu,
      info = info,
      success = success,
      \u003C\u0024\u003EisEnemy = isEnemy,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u0024\u003Einfo = info,
      \u003C\u0024\u003Esuccess = success,
      \u003C\u003Ef__this = this
    };
  }

  public void onEquipButton()
  {
    if (this.IsPushAndSet())
      return;
    if (PlayerAffiliation.Current.guild.gvg_status == GvgStatus.fighting)
      this.ShowOkPopup(Consts.GetInstance().POPUP_GUILD_BATTLE_ATK_TEAM_TITLE, Consts.GetInstance().POPUP_GUILD_BATTLE_EDIT_GEAR_UNAVAILABLE_IN_GVG, (System.Action) (() => this.IsPush = false));
    else
      this.StartCoroutine(this.ShowEquipScene());
  }

  public void onTeamEditButton()
  {
    if (this.IsPushAndSet())
      return;
    if (PlayerAffiliation.Current.guild.gvg_status == GvgStatus.fighting)
      this.ShowOkPopup(Consts.GetInstance().POPUP_GUILD_BATTLE_ATK_TEAM_TITLE, Consts.GetInstance().POPUP_GUILD_BATTLE_ATK_TEAM_ERROR, (System.Action) (() => this.IsPush = false));
    else
      this.StartCoroutine(this.ShowDeckEditScene());
  }

  public override void onBackButton()
  {
    if (Object.op_Equality((Object) this.guild0282Menu, (Object) null) || this.IsPushAndSet())
      return;
    GuildUtil.gvgPopupState = GuildUtil.GvGPopupState.None;
    this.guild0282Menu.closePopup(true);
  }
}
