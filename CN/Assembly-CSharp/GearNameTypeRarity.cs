﻿// Decompiled with JetBrains decompiler
// Type: GearNameTypeRarity
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using UnityEngine;

#nullable disable
public class GearNameTypeRarity : MonoBehaviour
{
  [SerializeField]
  private GearKindIcon gearType;
  [SerializeField]
  private UILabel gearName;
  [SerializeField]
  private UI2DSprite gearRarity;
  [SerializeField]
  private Sprite[] gearRarityList;

  public void Init()
  {
    this.SetType((GearKind) null, CommonElement.none);
    this.SetName((string) null);
    this.SetRarity((GearRarity) null);
  }

  public void Set(PlayerItem gear)
  {
    this.SetName(gear.name);
    this.SetType(gear.gear.kind, gear.GetElement());
    this.SetRarity(gear.gear.rarity);
  }

  private void SetType(GearKind kind, CommonElement element)
  {
    if (kind == null)
    {
      ((Component) this.gearType).gameObject.SetActive(false);
    }
    else
    {
      this.gearType.Init(kind, element);
      ((Component) this.gearType).gameObject.SetActive(true);
    }
  }

  private void SetName(string gName)
  {
    if (gName == null)
    {
      ((Component) this.gearName).gameObject.SetActive(false);
    }
    else
    {
      this.gearName.SetTextLocalize(gName);
      ((Component) this.gearName).gameObject.SetActive(true);
    }
  }

  private void SetRarity(GearRarity gear)
  {
    if (gear == null || gear.index > 0)
    {
      ((Component) this.gearRarity).gameObject.SetActive(false);
    }
    else
    {
      UI2DSprite gearRarity = this.gearRarity;
      Rect textureRect1 = this.gearRarityList[gear.index - 1].textureRect;
      int width = (int) ((Rect) ref textureRect1).width;
      Rect textureRect2 = this.gearRarityList[gear.index - 1].textureRect;
      int height = (int) ((Rect) ref textureRect2).height;
      gearRarity.SetDimensions(width, height);
      this.gearRarity.sprite2D = this.gearRarityList[gear.index - 1];
      ((Component) this.gearRarity).gameObject.SetActive(true);
    }
  }
}
