// Decompiled with JetBrains decompiler
// Type: MemberBaseItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
