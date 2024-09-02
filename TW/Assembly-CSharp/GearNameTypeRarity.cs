// Decompiled with JetBrains decompiler
// Type: GearNameTypeRarity
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
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
