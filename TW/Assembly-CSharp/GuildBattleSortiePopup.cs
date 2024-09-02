// Decompiled with JetBrains decompiler
// Type: GuildBattleSortiePopup
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
public class GuildBattleSortiePopup : BackButtonMenuBase
{
  private const float LINK_WIDTH = 92f;
  private const float LINK_DEFWIDTH = 114f;
  private const float scale = 0.807017565f;
  private const int FRIEND_NUM = 5;
  [SerializeField]
  private UILabel lblLeaderSkillName;
  [SerializeField]
  private UILabel lblLeaderSkillDesc;
  [SerializeField]
  private GameObject slc_NotFriend_Skill;
  [SerializeField]
  private UILabel lblFriendSkillName;
  [SerializeField]
  private UILabel lblFriendSkillDesc;
  [SerializeField]
  private UILabel lblNoFriend;
  [SerializeField]
  protected GameObject[] linkCharacters;
  private UnitIcon unitIcon;
  private GameObject unitIconPrefab;
  private GvgDeck deckInfo;
  private GuildBattlePreparationPopup parent;
  private GameObject commonOkPopup;
  private string targetPlayerID = string.Empty;
  private Guild0282Menu guildMapMenu;

  [DebuggerHidden]
  private IEnumerator SetDeck()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildBattleSortiePopup.\u003CSetDeck\u003Ec__Iterator71E()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator LoadUnitPrefab(int index, PlayerUnit unit, bool isFriend)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildBattleSortiePopup.\u003CLoadUnitPrefab\u003Ec__Iterator71F()
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
    return (IEnumerator) new GuildBattleSortiePopup.\u003CChangeDetailScene\u003Ec__Iterator720()
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
    if (this.linkCharacters == null)
      return;
    foreach (GameObject linkCharacter in this.linkCharacters)
    {
      UnitIcon componentInChildren = linkCharacter.GetComponentInChildren<UnitIcon>();
      if (Object.op_Inequality((Object) componentInChildren, (Object) null))
        Object.Destroy((Object) ((Component) componentInChildren).gameObject);
    }
  }

  [DebuggerHidden]
  private IEnumerator ResourceLoad()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildBattleSortiePopup.\u003CResourceLoad\u003Ec__Iterator721()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator sortie()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildBattleSortiePopup.\u003Csortie\u003Ec__Iterator722()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator showSortieUnAvailablePopup(GuildBattleSortiePopup.NotSortieType type)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildBattleSortiePopup.\u003CshowSortieUnAvailablePopup\u003Ec__Iterator723()
    {
      type = type,
      \u003C\u0024\u003Etype = type,
      \u003C\u003Ef__this = this
    };
  }

  private void setGvgSetting(GVGSetting setting, int turns, int point, int annihilation_point)
  {
    float? gvgFactor = this.getGvgFactor("POINT_LEADER_FACTOR");
    setting.point_leader_factor = !gvgFactor.HasValue ? 1f : gvgFactor.Value;
    gvgFactor = this.getGvgFactor("POINT_NO_LEADER_FACTOR");
    setting.point_no_leader_factor = !gvgFactor.HasValue ? 1f : gvgFactor.Value;
    gvgFactor = this.getGvgFactor("POINT_COST_FACTOR");
    setting.point_cost_factor = !gvgFactor.HasValue ? 1f : gvgFactor.Value;
    gvgFactor = this.getGvgFactor("POINT_RARITY_FACTOR");
    setting.point_rarity_factor = !gvgFactor.HasValue ? 1f : gvgFactor.Value;
    gvgFactor = this.getGvgFactor("POINT_BASE_FACTOR");
    setting.point_base_factor = !gvgFactor.HasValue ? 1f : gvgFactor.Value;
    gvgFactor = this.getGvgFactor("RESPAWN_BASE_FACTOR");
    setting.respawn_base_factor = !gvgFactor.HasValue ? 1f : gvgFactor.Value;
    gvgFactor = this.getGvgFactor("RESPAWN_RARITY_FACTOR");
    setting.respawn_rarity_factor = !gvgFactor.HasValue ? 1f : gvgFactor.Value;
    gvgFactor = this.getGvgFactor("RESPAWN_COST_FACTOR");
    setting.respawn_cost_factor = !gvgFactor.HasValue ? 1f : gvgFactor.Value;
    gvgFactor = this.getGvgFactor("TURNS_FACTOR");
    setting.turns_factor = !gvgFactor.HasValue ? 1f : gvgFactor.Value;
    setting.turns = turns;
    setting.point = point;
    setting.annihilation_point = annihilation_point;
  }

  private float? getGvgFactor(string key)
  {
    int? nullable = MasterData.GvgSettings.FirstIndexOrNull<KeyValuePair<int, GvgSettings>>((Func<KeyValuePair<int, GvgSettings>, bool>) (x => x.Value.key.Equals(key)));
    return !nullable.HasValue ? new float?() : new float?(MasterData.GvgSettingsList[nullable.Value].value);
  }

  [DebuggerHidden]
  public IEnumerator InitializeAsync(
    Guild0282Menu menu,
    GuildBattlePreparationPopup parent,
    string targetPlayerID)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildBattleSortiePopup.\u003CInitializeAsync\u003Ec__Iterator724()
    {
      parent = parent,
      targetPlayerID = targetPlayerID,
      menu = menu,
      \u003C\u0024\u003Eparent = parent,
      \u003C\u0024\u003EtargetPlayerID = targetPlayerID,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u003Ef__this = this
    };
  }

  public void SetGvgPopup()
  {
    this.guildMapMenu.SetGvgPopup(GuildUtil.GvGPopupState.Sortie, (System.Action) (() =>
    {
      ((Component) this).gameObject.SetActive(true);
      this.IsPush = false;
      this.StartCoroutine(this.SetDeck());
    }));
  }

  [DebuggerHidden]
  public IEnumerator SetFriendUnit(GvgCandidate friend)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildBattleSortiePopup.\u003CSetFriendUnit\u003Ec__Iterator725()
    {
      friend = friend,
      \u003C\u0024\u003Efriend = friend,
      \u003C\u003Ef__this = this
    };
  }

  public void onSortieButton()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.sortie());
  }

  public override void onBackButton()
  {
    if (this.IsPushAndSet() || !((Component) this).gameObject.activeSelf || this.parent.Mode != GuildBattlePreparationPopup.MODE.Sortie)
      return;
    this.parent.ShowGuestSelect();
  }

  public enum NotSortieType
  {
    None = -1, // 0xFFFFFFFF
    EndGuildBattle = 1,
    Fighting = 2,
    OtherReason = 3,
  }
}
