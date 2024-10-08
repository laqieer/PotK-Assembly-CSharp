﻿// Decompiled with JetBrains decompiler
// Type: GearNameTypeRarity
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using UnityEngine;

public class GearNameTypeRarity : MonoBehaviour
{
  [SerializeField]
  private GearKindIcon gearType;
  [SerializeField]
  private UILabel gearName;
  [SerializeField]
  private UI2DSprite gearRarity;
  [SerializeField]
  private UnityEngine.Sprite[] gearRarityList;

  public void Init()
  {
    this.SetType((GearKind) null, CommonElement.none);
    this.SetName((string) null);
    this.SetRarity((GearRarity) null);
  }

  public void Set(ItemInfo gear)
  {
    this.SetName(gear.Name());
    this.SetType(gear.gear.kind, gear.GetElement());
    this.SetRarity(gear.gear.rarity);
  }

  private void SetType(GearKind kind, CommonElement element)
  {
    if (kind == null)
    {
      this.gearType.gameObject.SetActive(false);
    }
    else
    {
      this.gearType.Init(kind, element);
      this.gearType.gameObject.SetActive(true);
    }
  }

  private void SetName(string gName)
  {
    if (gName == null)
    {
      this.gearName.gameObject.SetActive(false);
    }
    else
    {
      this.gearName.SetTextLocalize(gName);
      this.gearName.gameObject.SetActive(true);
    }
  }

  private void SetRarity(GearRarity gear)
  {
    if (gear == null || gear.index > 0)
    {
      this.gearRarity.gameObject.SetActive(false);
    }
    else
    {
      UI2DSprite gearRarity = this.gearRarity;
      Rect textureRect = this.gearRarityList[gear.index - 1].textureRect;
      int width = (int) textureRect.width;
      textureRect = this.gearRarityList[gear.index - 1].textureRect;
      int height = (int) textureRect.height;
      gearRarity.SetDimensions(width, height);
      this.gearRarity.sprite2D = this.gearRarityList[gear.index - 1];
      this.gearRarity.gameObject.SetActive(true);
    }
  }
}
