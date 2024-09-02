// Decompiled with JetBrains decompiler
// Type: RarityIcon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
public static class RarityIcon
{
  private static readonly string DETAIL_CURRENT_PATH = "Icons/Materials/RarityStars/";
  private static readonly string DETAIL_SLIVER_IMG_NAME = "{0}s_star_silver_{1}{2}";
  private static readonly string DETAIL_GOLD_IMG_NAME = "{0}s_star_gold_{1}{2}";
  private static readonly string DETAIL_RAINBOW_IMG_NAME = "{0}s_star_rainbow_{1}{2}";
  private static readonly string CURRENT_PATH = "Prefabs/UnitIcon/Materials/";
  private static readonly string SLIVER_IMG_NAME = "{0}s_star_silver{1:D2}{2:D2}";
  private static readonly string GOLD_IMG_NAME = "{0}s_star_gold{1:D2}{2:D2}";
  private static readonly string RAINBOW_IMG_NAME = "{0}s_star_rainbow{1:D2}{2:D2}";
  private static string[] spriteNameTBL = new string[7]
  {
    "Icons/Materials/RarityStars/slc_star1",
    "Icons/Materials/RarityStars/slc_star2",
    "Icons/Materials/RarityStars/slc_star3",
    "Icons/Materials/RarityStars/slc_star4",
    "Icons/Materials/RarityStars/slc_star5",
    "Icons/Materials/RarityStars/slc_star6",
    "Icons/Materials/RarityStars/slc_star7"
  };

  public static string GetSpriteName(UnitUnit unit, bool isDetail = true, bool isSame = false)
  {
    string empty = string.Empty;
    int num1 = unit.rarity.index + 1;
    int num2 = num1;
    if (!isSame)
    {
      UnitUnit[] array = ((IEnumerable<UnitUnit>) MasterData.UnitUnitList).Where<UnitUnit>((Func<UnitUnit, bool>) (x => unit.same_character_id == x.same_character_id)).OrderByDescending<UnitUnit, int>((Func<UnitUnit, int>) (x => x.rarity.index)).ToArray<UnitUnit>();
      if (array != null)
        num2 = array[0].rarity.index + 1;
    }
    return unit.job.job_rank_UnitJobRank != 1 ? (unit.job.job_rank_UnitJobRank != 2 ? (!isDetail ? string.Format(RarityIcon.RAINBOW_IMG_NAME, (object) RarityIcon.CURRENT_PATH, (object) num1, (object) num2) : string.Format(RarityIcon.DETAIL_RAINBOW_IMG_NAME, (object) RarityIcon.DETAIL_CURRENT_PATH, (object) num1, (object) num2)) : (!isDetail ? string.Format(RarityIcon.GOLD_IMG_NAME, (object) RarityIcon.CURRENT_PATH, (object) num1, (object) num2) : string.Format(RarityIcon.DETAIL_GOLD_IMG_NAME, (object) RarityIcon.DETAIL_CURRENT_PATH, (object) num1, (object) num2))) : (!isDetail ? string.Format(RarityIcon.SLIVER_IMG_NAME, (object) RarityIcon.CURRENT_PATH, (object) num1, (object) num2) : string.Format(RarityIcon.DETAIL_SLIVER_IMG_NAME, (object) RarityIcon.DETAIL_CURRENT_PATH, (object) num1, (object) num2));
  }

  private static Sprite GetSprite(GearRarity rarity)
  {
    return Resources.Load<Sprite>(RarityIcon.spriteNameTBL[rarity.index - 1]);
  }

  public static Sprite GetSprite(UnitUnit unit, bool isDetail = true, bool isSame = false)
  {
    return Resources.Load<Sprite>(RarityIcon.GetSpriteName(unit, isDetail, isSame));
  }

  public static void SetRarity(UnitUnit unit, Sprite dstSprite, bool isDetail)
  {
    if (Object.op_Equality((Object) dstSprite, (Object) null))
      return;
    dstSprite = RarityIcon.GetSprite(unit, isDetail);
  }

  public static void SetRarity(UnitUnit unit, UI2DSprite dstSprite, bool isDetail, bool isSame = false)
  {
    if (Object.op_Equality((Object) dstSprite, (Object) null))
      return;
    Sprite sprite = RarityIcon.GetSprite(unit, isDetail, isSame);
    if (!Object.op_Inequality((Object) sprite, (Object) null))
      return;
    dstSprite.sprite2D = sprite;
    UI2DSprite ui2Dsprite = dstSprite;
    Rect textureRect1 = sprite.textureRect;
    int width = (int) ((Rect) ref textureRect1).width;
    Rect textureRect2 = sprite.textureRect;
    int height = (int) ((Rect) ref textureRect2).height;
    ui2Dsprite.SetDimensions(width, height);
    ((Component) dstSprite).gameObject.SetActive(true);
  }

  public static void SetRarity(GearGear gear, UI2DSprite dstSprite)
  {
    if (Object.op_Equality((Object) dstSprite, (Object) null))
      return;
    ((Component) dstSprite).gameObject.SetActive(false);
    if (gear.rarity.index <= 0)
      return;
    Sprite sprite = RarityIcon.GetSprite(gear.rarity);
    if (!Object.op_Inequality((Object) sprite, (Object) null))
      return;
    dstSprite.sprite2D = sprite;
    UI2DSprite ui2Dsprite = dstSprite;
    Rect textureRect1 = sprite.textureRect;
    int width = (int) ((Rect) ref textureRect1).width;
    Rect textureRect2 = sprite.textureRect;
    int height = (int) ((Rect) ref textureRect2).height;
    ui2Dsprite.SetDimensions(width, height);
    ((Component) dstSprite).gameObject.SetActive(true);
  }
}
