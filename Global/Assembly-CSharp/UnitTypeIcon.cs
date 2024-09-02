﻿// Decompiled with JetBrains decompiler
// Type: UnitTypeIcon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using UnityEngine;

#nullable disable
public class UnitTypeIcon : MonoBehaviour
{
  public UI2DSprite iconSprite;
  [SerializeField]
  private Sprite[] icons;
  private static GameObject self;

  public void Init(UnitType type) => this.iconSprite.sprite2D = this.icons[type.ID - 1];

  public static GameObject GetPrefab()
  {
    if (Object.op_Equality((Object) UnitTypeIcon.self, (Object) null))
      UnitTypeIcon.self = Resources.Load<GameObject>("Icons/UnitTypeIcon");
    return UnitTypeIcon.self;
  }
}
