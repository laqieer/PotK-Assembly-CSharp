﻿// Decompiled with JetBrains decompiler
// Type: SprGearElement
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using MasterDataTable;
using UnityEngine;

public class SprGearElement : MonoBehaviour
{
  public UI2DSprite iconSprite;

  public void Initialize(CommonElementIcon icons, CommonElement element) => this.iconSprite.sprite2D = icons.getIcon(element);
}
