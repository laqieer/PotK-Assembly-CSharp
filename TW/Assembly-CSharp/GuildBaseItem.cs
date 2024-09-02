// Decompiled with JetBrains decompiler
// Type: GuildBaseItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
[Serializable]
public class GuildBaseItem
{
  [SerializeField]
  private GameObject enemyObject;
  [SerializeField]
  private GameObject friendObject;
  [SerializeField]
  private GameObject parentObject;
  [SerializeField]
  private UILabel nameLabel;

  public void Initialize(bool isEnemy, string name)
  {
    this.enemyObject.SetActive(isEnemy);
    this.friendObject.SetActive(!isEnemy);
    this.nameLabel.SetTextLocalize(name);
  }

  public void SetActive(bool flag) => this.parentObject.SetActive(flag);
}
