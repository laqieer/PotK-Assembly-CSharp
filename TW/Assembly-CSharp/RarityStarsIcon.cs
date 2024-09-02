// Decompiled with JetBrains decompiler
// Type: RarityStarsIcon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using UnityEngine;

#nullable disable
public class RarityStarsIcon : MonoBehaviour
{
  public UI2DSprite iconSprite;
  [SerializeField]
  private Sprite[] GearRarityIcon;
  [SerializeField]
  private Sprite[] SilverIcons;
  [SerializeField]
  private Sprite[] GoldIcons;
  [SerializeField]
  private Sprite[] RainbowIcons;

  public void Init(UnitUnit unit)
  {
    if (unit.job.job_rank_UnitJobRank == 1)
      this.iconSprite.sprite2D = this.SilverIcons[unit.rarity.index];
    else if (unit.job.job_rank_UnitJobRank == 2)
      this.iconSprite.sprite2D = this.GoldIcons[unit.rarity.index];
    else
      this.iconSprite.sprite2D = this.RainbowIcons[unit.rarity.index];
  }

  public void Init(GearRarity rarity)
  {
    if (rarity.index > 0)
      this.iconSprite.sprite2D = this.GearRarityIcon[rarity.index - 1];
    else
      ((Component) this).gameObject.SetActive(false);
  }
}
