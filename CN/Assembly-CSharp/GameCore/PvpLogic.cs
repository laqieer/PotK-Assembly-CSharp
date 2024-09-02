// Decompiled with JetBrains decompiler
// Type: GameCore.PvpLogic
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
namespace GameCore
{
  public class PvpLogic
  {
    private static bool CompFromString(PvpLogic.CompFunc func, string compValue)
    {
      int result = 0;
      return int.TryParse(compValue, out result) && func(result);
    }

    public static bool IsEnable(
      BL.Unit unit,
      int category,
      int logic,
      int value,
      string today,
      StartParameter parm = null)
    {
      PvpLogic.CompFunc func = (PvpLogic.CompFunc) null;
      switch (logic)
      {
        case 1:
          func = (PvpLogic.CompFunc) (v => value == v);
          break;
        case 2:
          func = (PvpLogic.CompFunc) (v => value >= v);
          break;
        case 3:
          func = (PvpLogic.CompFunc) (v => value <= v);
          break;
      }
      if (func == null)
        return false;
      switch (category)
      {
        case 1:
          return func(unit.playerUnit.unit_type.ID);
        case 2:
          return func(unit.unit.job.ID);
        case 3:
          return ((IEnumerable<UnitFamily>) unit.unit.Families).Any<UnitFamily>((Func<UnitFamily, bool>) (x => func((int) x)));
        case 4:
          return func(unit.unit.kind.ID);
        case 5:
          ColosseumBonusBloodType colosseumBonusBloodType = ((IEnumerable<ColosseumBonusBloodType>) MasterData.ColosseumBonusBloodTypeList).Where<ColosseumBonusBloodType>((Func<ColosseumBonusBloodType, bool>) (x => x.name == unit.unit.character.blood_type)).FirstOrDefault<ColosseumBonusBloodType>();
          return colosseumBonusBloodType != null && func(colosseumBonusBloodType.value);
        case 6:
          ColosseumBonusZodiacType colosseumBonusZodiacType = ((IEnumerable<ColosseumBonusZodiacType>) MasterData.ColosseumBonusZodiacTypeList).Where<ColosseumBonusZodiacType>((Func<ColosseumBonusZodiacType, bool>) (x => x.name == unit.unit.character.zodiac_sign)).FirstOrDefault<ColosseumBonusZodiacType>();
          return colosseumBonusZodiacType != null && func(colosseumBonusZodiacType.value);
        case 7:
          return PvpLogic.CompFromString(func, unit.unit.character.height);
        case 8:
          return PvpLogic.CompFromString(func, unit.unit.character.weight);
        case 9:
          return PvpLogic.CompFromString(func, unit.unit.character.bust);
        case 10:
          return PvpLogic.CompFromString(func, unit.unit.character.waist);
        case 11:
          return PvpLogic.CompFromString(func, unit.unit.character.hip);
        case 12:
          return unit.unit.character.birthday == today;
        case 13:
          return func((int) unit.playerUnit.GetElement());
        case 14:
          return func(unit.parameter.Strength);
        case 15:
          return func(unit.parameter.Intelligence);
        case 16:
          return func(unit.parameter.Vitality);
        case 17:
          return func(unit.parameter.Mind);
        case 18:
          return func(unit.parameter.Agility);
        case 19:
          return func(unit.parameter.Dexterity);
        case 20:
          return func(unit.parameter.Luck);
        case 21:
          return func(unit.parameter.PhysicalAttack);
        case 22:
          return func(unit.parameter.MagicAttack);
        case 23:
          return func(unit.parameter.PhysicalDefense);
        case 24:
          return func(unit.parameter.MagicDefense);
        case 25:
          return func(unit.parameter.Hit);
        case 26:
          return func(unit.parameter.Critical);
        case 27:
          return func(unit.parameter.Evasion);
        case 28:
          return func(unit.parameter.Combat);
        case 29:
          return func(unit.unitId);
        case 30:
          return parm != null && -1 != Array.IndexOf<int?>(parm.activity_ids, new int?(value));
        case 31:
          return func(unit.weapon.gearId);
        default:
          return false;
      }
    }

    private delegate bool CompFunc(int value);
  }
}
