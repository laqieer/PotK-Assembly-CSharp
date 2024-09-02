// Decompiled with JetBrains decompiler
// Type: GuildBaseItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
