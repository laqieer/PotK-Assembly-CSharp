// Decompiled with JetBrains decompiler
// Type: CalcUnitCompose
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
public class CalcUnitCompose
{
  private static int BREAKTHROUGH_BASE = 3000;
  private static float[] BREAKTHROUGH_REVISION = new float[4]
  {
    1f,
    1.5f,
    3f,
    5f
  };

  public static int getBaseValue(
    PlayerUnit unit,
    PlayerUnit[] material,
    CalcUnitCompose.ComposeType type)
  {
    IEnumerable<PlayerUnit> source = ((IEnumerable<PlayerUnit>) material).Where<PlayerUnit>((Func<PlayerUnit, bool>) (x => x != (PlayerUnit) null && unit.unit.ID == x.unit.ID));
    switch (type)
    {
      case CalcUnitCompose.ComposeType.HP:
        int num1 = source.Count<PlayerUnit>() <= 0 ? 0 : source.Max<PlayerUnit>((Func<PlayerUnit, int>) (x => x.hp.inheritance));
        return unit.hp.inheritance >= num1 ? unit.total_hp : unit.hp.initial + unit.hp.level + unit.hp.compose + num1 + unit.hp.buildup;
      case CalcUnitCompose.ComposeType.STRENGTH:
        int num2 = source.Count<PlayerUnit>() <= 0 ? 0 : source.Max<PlayerUnit>((Func<PlayerUnit, int>) (x => x.strength.inheritance));
        return unit.strength.inheritance >= num2 ? unit.total_strength : unit.strength.initial + unit.strength.level + unit.strength.compose + num2 + unit.strength.buildup;
      case CalcUnitCompose.ComposeType.INTELLIGENCE:
        int num3 = source.Count<PlayerUnit>() <= 0 ? 0 : source.Max<PlayerUnit>((Func<PlayerUnit, int>) (x => x.intelligence.inheritance));
        return unit.intelligence.inheritance >= num3 ? unit.total_intelligence : unit.intelligence.initial + unit.intelligence.level + unit.intelligence.compose + num3 + unit.intelligence.buildup;
      case CalcUnitCompose.ComposeType.VITALITY:
        int num4 = source.Count<PlayerUnit>() <= 0 ? 0 : source.Max<PlayerUnit>((Func<PlayerUnit, int>) (x => x.vitality.inheritance));
        return unit.vitality.inheritance >= num4 ? unit.total_vitality : unit.vitality.initial + unit.vitality.level + unit.vitality.compose + num4 + unit.vitality.buildup;
      case CalcUnitCompose.ComposeType.MIND:
        int num5 = source.Count<PlayerUnit>() <= 0 ? 0 : source.Max<PlayerUnit>((Func<PlayerUnit, int>) (x => x.mind.inheritance));
        return unit.mind.inheritance >= num5 ? unit.total_mind : unit.mind.initial + unit.mind.level + unit.mind.compose + num5 + unit.mind.buildup;
      case CalcUnitCompose.ComposeType.AGILITY:
        int num6 = source.Count<PlayerUnit>() <= 0 ? 0 : source.Max<PlayerUnit>((Func<PlayerUnit, int>) (x => x.agility.inheritance));
        return unit.agility.inheritance >= num6 ? unit.total_agility : unit.agility.initial + unit.agility.level + unit.agility.compose + num6 + unit.agility.buildup;
      case CalcUnitCompose.ComposeType.DEXTERITY:
        int num7 = source.Count<PlayerUnit>() <= 0 ? 0 : source.Max<PlayerUnit>((Func<PlayerUnit, int>) (x => x.dexterity.inheritance));
        return unit.dexterity.inheritance >= num7 ? unit.total_dexterity : unit.dexterity.initial + unit.dexterity.level + unit.dexterity.compose + num7 + unit.dexterity.buildup;
      case CalcUnitCompose.ComposeType.LUCKY:
        int num8 = source.Count<PlayerUnit>() <= 0 ? 0 : source.Max<PlayerUnit>((Func<PlayerUnit, int>) (x => x.lucky.inheritance));
        return unit.lucky.inheritance >= num8 ? unit.total_lucky : unit.lucky.initial + unit.lucky.level + unit.lucky.compose + num8 + unit.lucky.buildup;
      default:
        return 0;
    }
  }

  public static int getComposeValue(
    PlayerUnit unit,
    PlayerUnit[] material,
    CalcUnitCompose.ComposeType type)
  {
    int num1 = 0;
    int num2 = 0;
    switch (type)
    {
      case CalcUnitCompose.ComposeType.HP:
        num1 = ((IEnumerable<PlayerUnit>) material).Sum<PlayerUnit>((Func<PlayerUnit, int>) (x => x != (PlayerUnit) null ? x.unit.hp_compose : 0));
        num2 = unit.UnitTypeParameter.hp_compose_max - unit.hp.compose;
        break;
      case CalcUnitCompose.ComposeType.STRENGTH:
        num1 = ((IEnumerable<PlayerUnit>) material).Sum<PlayerUnit>((Func<PlayerUnit, int>) (x => x != (PlayerUnit) null ? x.unit.strength_compose : 0));
        num2 = unit.UnitTypeParameter.strength_compose_max - unit.strength.compose;
        break;
      case CalcUnitCompose.ComposeType.INTELLIGENCE:
        num1 = ((IEnumerable<PlayerUnit>) material).Sum<PlayerUnit>((Func<PlayerUnit, int>) (x => x != (PlayerUnit) null ? x.unit.intelligence_compose : 0));
        num2 = unit.UnitTypeParameter.intelligence_compose_max - unit.intelligence.compose;
        break;
      case CalcUnitCompose.ComposeType.VITALITY:
        num1 = ((IEnumerable<PlayerUnit>) material).Sum<PlayerUnit>((Func<PlayerUnit, int>) (x => x != (PlayerUnit) null ? x.unit.vitality_compose : 0));
        num2 = unit.UnitTypeParameter.vitality_compose_max - unit.vitality.compose;
        break;
      case CalcUnitCompose.ComposeType.MIND:
        num1 = ((IEnumerable<PlayerUnit>) material).Sum<PlayerUnit>((Func<PlayerUnit, int>) (x => x != (PlayerUnit) null ? x.unit.mind_compose : 0));
        num2 = unit.UnitTypeParameter.mind_compose_max - unit.mind.compose;
        break;
      case CalcUnitCompose.ComposeType.AGILITY:
        num1 = ((IEnumerable<PlayerUnit>) material).Sum<PlayerUnit>((Func<PlayerUnit, int>) (x => x != (PlayerUnit) null ? x.unit.agility_compose : 0));
        num2 = unit.UnitTypeParameter.agility_compose_max - unit.agility.compose;
        break;
      case CalcUnitCompose.ComposeType.DEXTERITY:
        num1 = ((IEnumerable<PlayerUnit>) material).Sum<PlayerUnit>((Func<PlayerUnit, int>) (x => x != (PlayerUnit) null ? x.unit.dexterity_compose : 0));
        num2 = unit.UnitTypeParameter.dexterity_compose_max - unit.dexterity.compose;
        break;
      case CalcUnitCompose.ComposeType.LUCKY:
        IEnumerable<PlayerUnit> source = ((IEnumerable<PlayerUnit>) material).Where<PlayerUnit>((Func<PlayerUnit, bool>) (x => x != (PlayerUnit) null && x.unit.ID == unit.unit.ID));
        num1 = ((IEnumerable<PlayerUnit>) material).Where<PlayerUnit>((Func<PlayerUnit, bool>) (x => x != (PlayerUnit) null && x.unit.same_character_id == unit.unit.same_character_id)).Count<PlayerUnit>() + source.Sum<PlayerUnit>((Func<PlayerUnit, int>) (x => x.lucky.compose)) + ((IEnumerable<PlayerUnit>) material).Sum<PlayerUnit>((Func<PlayerUnit, int>) (x => x != (PlayerUnit) null ? x.unit.lucky_compose : 0));
        num2 = unit.UnitTypeParameter.lucky_compose_max - unit.lucky.compose;
        break;
    }
    if (num2 < 0)
      num2 = 0;
    if (num1 < 0)
      num1 = 0;
    return num2 < num1 ? num2 : num1;
  }

  public static int getBuildupMaterialCnt(PlayerUnit[] material, CalcUnitCompose.ComposeType type)
  {
    switch (type)
    {
      case CalcUnitCompose.ComposeType.HP:
        return ((IEnumerable<PlayerUnit>) material).Count<PlayerUnit>((Func<PlayerUnit, bool>) (x => x != (PlayerUnit) null && x.unit.hp_buildup > 0));
      case CalcUnitCompose.ComposeType.STRENGTH:
        return ((IEnumerable<PlayerUnit>) material).Count<PlayerUnit>((Func<PlayerUnit, bool>) (x => x != (PlayerUnit) null && x.unit.strength_buildup > 0));
      case CalcUnitCompose.ComposeType.INTELLIGENCE:
        return ((IEnumerable<PlayerUnit>) material).Count<PlayerUnit>((Func<PlayerUnit, bool>) (x => x != (PlayerUnit) null && x.unit.intelligence_buildup > 0));
      case CalcUnitCompose.ComposeType.VITALITY:
        return ((IEnumerable<PlayerUnit>) material).Count<PlayerUnit>((Func<PlayerUnit, bool>) (x => x != (PlayerUnit) null && x.unit.vitality_buildup > 0));
      case CalcUnitCompose.ComposeType.MIND:
        return ((IEnumerable<PlayerUnit>) material).Count<PlayerUnit>((Func<PlayerUnit, bool>) (x => x != (PlayerUnit) null && x.unit.mind_buildup > 0));
      case CalcUnitCompose.ComposeType.AGILITY:
        return ((IEnumerable<PlayerUnit>) material).Count<PlayerUnit>((Func<PlayerUnit, bool>) (x => x != (PlayerUnit) null && x.unit.agility_buildup > 0));
      case CalcUnitCompose.ComposeType.DEXTERITY:
        return ((IEnumerable<PlayerUnit>) material).Count<PlayerUnit>((Func<PlayerUnit, bool>) (x => x != (PlayerUnit) null && x.unit.dexterity_buildup > 0));
      case CalcUnitCompose.ComposeType.LUCKY:
        return ((IEnumerable<PlayerUnit>) material).Count<PlayerUnit>((Func<PlayerUnit, bool>) (x => x != (PlayerUnit) null && x.unit.lucky_buildup > 0));
      default:
        return 0;
    }
  }

  public static int getBuildupValue(
    PlayerUnit unit,
    PlayerUnit[] material,
    CalcUnitCompose.ComposeType type)
  {
    int num1 = 0;
    int num2 = 0;
    switch (type)
    {
      case CalcUnitCompose.ComposeType.HP:
        num1 = ((IEnumerable<PlayerUnit>) material).Sum<PlayerUnit>((Func<PlayerUnit, int>) (x => x != (PlayerUnit) null ? x.unit.hp_buildup : 0));
        num2 = (int) ((float) ((double) unit.unit.hp_max * (10000.0 + (double) unit.UnitTypeParameter.hp_levelup_max_correction * 10000.0) / 10000.0) - (float) (unit.hp.level + unit.hp.buildup));
        break;
      case CalcUnitCompose.ComposeType.STRENGTH:
        num1 = ((IEnumerable<PlayerUnit>) material).Sum<PlayerUnit>((Func<PlayerUnit, int>) (x => x != (PlayerUnit) null ? x.unit.strength_buildup : 0));
        num2 = (int) ((float) ((double) unit.unit.strength_max * (10000.0 + (double) unit.UnitTypeParameter.strength_levelup_max_correction * 10000.0) / 10000.0) - (float) (unit.strength.level + unit.strength.buildup));
        break;
      case CalcUnitCompose.ComposeType.INTELLIGENCE:
        num1 = ((IEnumerable<PlayerUnit>) material).Sum<PlayerUnit>((Func<PlayerUnit, int>) (x => x != (PlayerUnit) null ? x.unit.intelligence_buildup : 0));
        num2 = (int) ((float) ((double) unit.unit.intelligence_max * (10000.0 + (double) unit.UnitTypeParameter.intelligence_levelup_max_correction * 10000.0) / 10000.0) - (float) (unit.intelligence.level + unit.intelligence.buildup));
        break;
      case CalcUnitCompose.ComposeType.VITALITY:
        num1 = ((IEnumerable<PlayerUnit>) material).Sum<PlayerUnit>((Func<PlayerUnit, int>) (x => x != (PlayerUnit) null ? x.unit.vitality_buildup : 0));
        num2 = (int) ((float) ((double) unit.unit.vitality_max * (10000.0 + (double) unit.UnitTypeParameter.vitality_levelup_max_correction * 10000.0) / 10000.0) - (float) (unit.vitality.level + unit.vitality.buildup));
        break;
      case CalcUnitCompose.ComposeType.MIND:
        num1 = ((IEnumerable<PlayerUnit>) material).Sum<PlayerUnit>((Func<PlayerUnit, int>) (x => x != (PlayerUnit) null ? x.unit.mind_buildup : 0));
        num2 = (int) ((float) ((double) unit.unit.mind_max * (10000.0 + (double) unit.UnitTypeParameter.mind_levelup_max_correction * 10000.0) / 10000.0) - (float) (unit.mind.level + unit.mind.buildup));
        break;
      case CalcUnitCompose.ComposeType.AGILITY:
        num1 = ((IEnumerable<PlayerUnit>) material).Sum<PlayerUnit>((Func<PlayerUnit, int>) (x => x != (PlayerUnit) null ? x.unit.agility_buildup : 0));
        num2 = (int) ((float) ((double) unit.unit.agility_max * (10000.0 + (double) unit.UnitTypeParameter.agility_levelup_max_correction * 10000.0) / 10000.0) - (float) (unit.agility.level + unit.agility.buildup));
        break;
      case CalcUnitCompose.ComposeType.DEXTERITY:
        num1 = ((IEnumerable<PlayerUnit>) material).Sum<PlayerUnit>((Func<PlayerUnit, int>) (x => x != (PlayerUnit) null ? x.unit.dexterity_buildup : 0));
        num2 = (int) ((float) ((double) unit.unit.dexterity_max * (10000.0 + (double) unit.UnitTypeParameter.dexterity_levelup_max_correction * 10000.0) / 10000.0) - (float) (unit.dexterity.level + unit.dexterity.buildup));
        break;
      case CalcUnitCompose.ComposeType.LUCKY:
        num1 = ((IEnumerable<PlayerUnit>) material).Sum<PlayerUnit>((Func<PlayerUnit, int>) (x => x != (PlayerUnit) null ? x.unit.lucky_buildup : 0));
        num2 = (int) ((float) ((double) unit.unit.lucky_max * (10000.0 + (double) unit.UnitTypeParameter.lucky_levelup_max_correction * 10000.0) / 10000.0) - (float) (unit.lucky.level + unit.lucky.buildup));
        break;
    }
    if (num2 < 0)
      num2 = 0;
    if (num1 < 0)
      num1 = 0;
    return num2 < num1 ? num2 : num1;
  }

  public static bool isComposeMax(PlayerUnit unit, CalcUnitCompose.ComposeType type)
  {
    bool flag = true;
    switch (type)
    {
      case CalcUnitCompose.ComposeType.HP:
        if (unit.UnitTypeParameter.hp_compose_max > unit.hp.compose)
        {
          flag = false;
          break;
        }
        break;
      case CalcUnitCompose.ComposeType.STRENGTH:
        if (unit.UnitTypeParameter.strength_compose_max > unit.strength.compose)
        {
          flag = false;
          break;
        }
        break;
      case CalcUnitCompose.ComposeType.INTELLIGENCE:
        if (unit.UnitTypeParameter.intelligence_compose_max > unit.intelligence.compose)
        {
          flag = false;
          break;
        }
        break;
      case CalcUnitCompose.ComposeType.VITALITY:
        if (unit.UnitTypeParameter.vitality_compose_max > unit.vitality.compose)
        {
          flag = false;
          break;
        }
        break;
      case CalcUnitCompose.ComposeType.MIND:
        if (unit.UnitTypeParameter.mind_compose_max > unit.mind.compose)
        {
          flag = false;
          break;
        }
        break;
      case CalcUnitCompose.ComposeType.AGILITY:
        if (unit.UnitTypeParameter.agility_compose_max > unit.agility.compose)
        {
          flag = false;
          break;
        }
        break;
      case CalcUnitCompose.ComposeType.DEXTERITY:
        if (unit.UnitTypeParameter.dexterity_compose_max > unit.dexterity.compose)
        {
          flag = false;
          break;
        }
        break;
      case CalcUnitCompose.ComposeType.LUCKY:
        if (unit.UnitTypeParameter.lucky_compose_max > unit.lucky.compose)
        {
          flag = false;
          break;
        }
        break;
    }
    return flag;
  }

  public static int priceCompose(PlayerUnit base_unit, PlayerUnit[] material_units)
  {
    NGGameDataManager.Boost boostInfo = Singleton<NGGameDataManager>.GetInstance().BoostInfo;
    Decimal num = boostInfo != null ? boostInfo.DiscountUnitCompose : 1.0M;
    return (int) ((Decimal) CalcUnitCompose.price(base_unit, material_units, CalcUnitCompose.PriceMode.Compose) * num);
  }

  public static int priceStringth(PlayerUnit base_unit, PlayerUnit[] material_units)
  {
    NGGameDataManager.Boost boostInfo = Singleton<NGGameDataManager>.GetInstance().BoostInfo;
    Decimal num = boostInfo != null ? boostInfo.DiscountUnitBuildup : 1.0M;
    return (int) ((Decimal) CalcUnitCompose.price(base_unit, material_units, CalcUnitCompose.PriceMode.Stringth) * num);
  }

  private static int price(
    PlayerUnit base_unit,
    PlayerUnit[] material_units,
    CalcUnitCompose.PriceMode mode)
  {
    if (base_unit == (PlayerUnit) null || material_units.Length < 1)
      return 0;
    int num1;
    if (mode == CalcUnitCompose.PriceMode.Compose)
    {
      int num2 = 1 + base_unit.amountIncrementInCompose;
      num1 = !base_unit.isMaxParamInCompose ? num2 * ((IEnumerable<CommonStrengthComposePrice>) MasterData.CommonStrengthComposePriceList).FirstOrDefault<CommonStrengthComposePrice>((Func<CommonStrengthComposePrice, bool>) (x => x.ID == 2)).price * material_units.Length : num2 * ((IEnumerable<CommonStrengthComposePrice>) MasterData.CommonStrengthComposePriceList).FirstOrDefault<CommonStrengthComposePrice>((Func<CommonStrengthComposePrice, bool>) (x => x.ID == 1)).price * material_units.Length;
    }
    else
      num1 = (1 + base_unit.buildup_count) * ((IEnumerable<CommonStrengthComposePrice>) MasterData.CommonStrengthComposePriceList).FirstOrDefault<CommonStrengthComposePrice>((Func<CommonStrengthComposePrice, bool>) (x => x.ID == 3)).price * material_units.Length;
    int limitBreakCount = base_unit.breakthrough_count;
    ((IEnumerable<PlayerUnit>) material_units).ForEach<PlayerUnit>((Action<PlayerUnit>) (mu =>
    {
      if (mu.unit.ID != base_unit.unit.ID && !mu.unit.IsBreakThrough)
        return;
      limitBreakCount += !mu.unit.IsBreakThrough ? mu.breakthrough_count + 1 : 1;
    }));
    if (limitBreakCount >= base_unit.unit.breakthrough_limit)
      limitBreakCount = base_unit.unit.breakthrough_limit;
    int num3 = 0;
    for (int breakthroughCount = base_unit.breakthrough_count; breakthroughCount < limitBreakCount; ++breakthroughCount)
      num3 += (int) ((double) CalcUnitCompose.BREAKTHROUGH_BASE * (double) CalcUnitCompose.BREAKTHROUGH_REVISION[breakthroughCount]);
    int num4 = num3;
    return num1 + num4;
  }

  public enum ComposeType
  {
    HP,
    STRENGTH,
    INTELLIGENCE,
    VITALITY,
    MIND,
    AGILITY,
    DEXTERITY,
    LUCKY,
  }

  private enum PriceMode
  {
    Compose,
    Stringth,
  }
}
