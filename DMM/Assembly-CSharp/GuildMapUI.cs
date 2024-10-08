﻿// Decompiled with JetBrains decompiler
// Type: GuildMapUI
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

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
    this.memberButton.gameObject.SetActive(flag);
  }
}
