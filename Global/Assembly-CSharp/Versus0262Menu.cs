// Decompiled with JetBrains decompiler
// Type: Versus0262Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using UniLinq;
using UnityEngine;

#nullable disable
public class Versus0262Menu : Versus026MatchBase
{
  [SerializeField]
  private GameObject randomEnemyStatus;
  [SerializeField]
  private GameObject friendEnemyStatus;
  [SerializeField]
  private GameObject[] btnStrengthOn;
  [SerializeField]
  private GameObject btnFriendOn;
  [SerializeField]
  private UIButton btnFriendOff;
  private bool hasFriend;

  [DebuggerHidden]
  public override IEnumerator Init(PvpMatchingTypeEnum type, WebAPI.Response.PvpBoot pvpInfo)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus0262Menu.\u003CInit\u003Ec__Iterator598()
    {
      type = type,
      pvpInfo = pvpInfo,
      \u003C\u0024\u003Etype = type,
      \u003C\u0024\u003EpvpInfo = pvpInfo,
      \u003C\u003Ef__this = this
    };
  }

  public void InitDisplayType()
  {
    bool isFriendMatch = this.isFriendMatch;
    this.txtTitle.text = !isFriendMatch ? Consts.Lookup("VERSUS_00262TITLE_RANDOM") : Consts.Lookup("VERSUS_00262TITLE_FRIEND");
    this.randomEnemyStatus.SetActive(!isFriendMatch);
    this.friendEnemyStatus.SetActive(isFriendMatch);
    if (!isFriendMatch)
    {
      this.OnClickNormal();
    }
    else
    {
      this.type = PvpMatchingTypeEnum.guest;
      this.btnFriendOn.SetActive(false);
      PlayerFriend[] source = ((IEnumerable<PlayerFriend>) SMManager.Get<PlayerFriend[]>()).Friends();
      this.hasFriend = source != null && ((IEnumerable<PlayerFriend>) source).Count<PlayerFriend>() > 0;
      this.btnFriendOff.isEnabled = this.hasFriend;
    }
  }

  public void OnClickFriend()
  {
    if (!this.hasFriend)
      return;
    this.btnFriendOn.SetActive(!this.btnFriendOn.activeSelf);
    this.type = !this.btnFriendOn.activeSelf ? PvpMatchingTypeEnum.guest : PvpMatchingTypeEnum.friend;
  }

  public void OnClickNormal()
  {
    if (this.IsPush)
      return;
    this.ChangeStrengthCondition(0);
    this.type = PvpMatchingTypeEnum.normal;
  }

  public void OnClickChallenge()
  {
    if (this.IsPush)
      return;
    this.ChangeStrengthCondition(1);
    this.type = PvpMatchingTypeEnum.challenge;
  }

  private void ChangeStrengthCondition(int index)
  {
    ((IEnumerable<GameObject>) this.btnStrengthOn).ForEachIndex<GameObject>((Action<GameObject, int>) ((x, i) => x.SetActive(i == index)));
  }

  public override void IbtnWarExperience()
  {
    if (this.IsPushAndSet())
      return;
    base.IbtnWarExperience();
    Versus02622Scene.ChangeScene(true, this.pvpInfo.pvp_record, this.pvpInfo.pvp_record_by_friend);
  }

  public void CheckRoomkey()
  {
    if (!Regex.IsMatch(this.txtPass.text, "[^0-9]"))
      return;
    ModalWindow.Show(Consts.Lookup("VERSUS_00262POPUP_TITLE"), Consts.Lookup("VERSUS_00262POPUP_DESCRIPTION"), (System.Action) (() => { }));
    ((Component) this.txtPass).GetComponent<UIInput>().value = string.Empty;
    this.txtPass.text = string.Empty;
  }

  protected override string SetRoomKey(string key)
  {
    if (this.isFriendMatch)
      key += this.txtPass.text;
    return key;
  }

  public enum EnemyStrength
  {
    NORMAL,
    CHALLENGE,
  }
}
