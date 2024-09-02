// Decompiled with JetBrains decompiler
// Type: GuildMapUI
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
[Serializable]
public class GuildMapUI
{
  public UIButton memberButton;
  [SerializeField]
  public GameObject guildBasePosition;
  public Guild0282GuildBase guildBase;
  [SerializeField]
  public List<GameObject> memberBasePosition;
  public List<Guild0282MemberBase> memberBaseList;
  public GameObject objectParent;

  public void SetActive(bool flag)
  {
    this.objectParent.SetActive(flag);
    ((Component) this.memberButton).gameObject.SetActive(flag);
  }
}
