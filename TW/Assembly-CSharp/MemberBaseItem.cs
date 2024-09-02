// Decompiled with JetBrains decompiler
// Type: MemberBaseItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System;
using UnityEngine;

#nullable disable
[Serializable]
public class MemberBaseItem
{
  [SerializeField]
  private GameObject masterIcon;
  [SerializeField]
  private GameObject submasterIcon;
  [SerializeField]
  private GameObject enemyPlate;
  [SerializeField]
  private GameObject friendPlate;
  [SerializeField]
  private UILabel nameLabel;
  [SerializeField]
  private GameObject parentObject;

  public void Initialize(bool isEnemy, GuildMembership member)
  {
    this.SetRole(member.role);
    this.SetNamePlate(isEnemy);
    this.nameLabel.SetTextLocalize(member.player.player_name);
  }

  public void InitializeGB()
  {
    this.enemyPlate.SetActive(false);
    this.friendPlate.SetActive(false);
    ((Component) this.nameLabel).gameObject.SetActive(false);
  }

  public void SetRole(GuildRole role)
  {
    this.masterIcon.SetActive(role == GuildRole.master);
    this.submasterIcon.SetActive(role == GuildRole.sub_master);
  }

  public void SetNamePlate(bool isEnemy)
  {
    this.enemyPlate.SetActive(isEnemy);
    this.friendPlate.SetActive(!isEnemy);
  }

  public void SetActive(bool flag) => this.parentObject.SetActive(flag);
}
