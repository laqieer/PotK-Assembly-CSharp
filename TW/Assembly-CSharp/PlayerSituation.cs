// Decompiled with JetBrains decompiler
// Type: PlayerSituation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
[Serializable]
public class PlayerSituation
{
  [SerializeField]
  private UILabel txt_stars_get_num;
  [SerializeField]
  private UILabel txt_player_name;
  [SerializeField]
  private GameObject dyn_memberBase;
  private Guild0282MemberBase memberBase;
  [SerializeField]
  private List<GameObject> slc_guild_battle_icon_on_own;
  [SerializeField]
  private GameObject parent;

  public GameObject gameObject => this.parent;

  public void SetActive(bool flag) => this.parent.SetActive(flag);

  public void Initialize(
    GuildMembership member,
    GameObject memberBaseObj,
    GuildImageCache imageCache)
  {
    if (Object.op_Equality((Object) this.memberBase, (Object) null))
      this.memberBase = memberBaseObj.Clone(this.dyn_memberBase.transform).GetComponent<Guild0282MemberBase>();
    this.memberBase.InitializePlayrtSituation(member, imageCache);
    this.txt_player_name.SetTextLocalize(member.player.player_name);
    this.txt_stars_get_num.SetTextLocalize(member.capture_star.ToString());
    for (int index = 0; index < this.slc_guild_battle_icon_on_own.Count; ++index)
      this.slc_guild_battle_icon_on_own[index].SetActive(member.action_point - 1 >= index);
  }
}
