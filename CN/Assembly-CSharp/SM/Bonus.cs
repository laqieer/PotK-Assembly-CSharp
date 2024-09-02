// Decompiled with JetBrains decompiler
// Type: SM.Bonus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
namespace SM
{
  [Serializable]
  public class Bonus : KeyCompare
  {
    public int category;
    public int remaining_time;
    public int id;
    public int value;
    public int logic;
    public int _skill;
    public int groupid;

    public Bonus()
    {
    }

    public Bonus(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.category = (int) (long) json[nameof (category)];
      this.remaining_time = (int) (long) json[nameof (remaining_time)];
      this.id = (int) (long) json[nameof (id)];
      this.value = (int) (long) json[nameof (value)];
      this.logic = (int) (long) json[nameof (logic)];
      this._skill = (int) (long) json[nameof (skill)];
      this.groupid = (int) (long) json[nameof (groupid)];
    }

    private static bool CompFromString(Bonus.CompFunc func, string compValue)
    {
      int result = 0;
      return int.TryParse(compValue, out result) && func(result);
    }

    public static bool IsEnableBonus(BL.Unit unit, Bonus bonus, string today)
    {
      Bonus.CompFunc func = (Bonus.CompFunc) null;
      if (bonus.logic == 1)
        func = (Bonus.CompFunc) (value => bonus.value == value);
      else if (bonus.logic == 2)
        func = (Bonus.CompFunc) (value => bonus.value >= value);
      else if (bonus.logic == 3)
        func = (Bonus.CompFunc) (value => bonus.value <= value);
      if (func == null)
        return false;
      switch (bonus.category)
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
          return Bonus.CompFromString(func, unit.unit.character.height);
        case 8:
          return Bonus.CompFromString(func, unit.unit.character.weight);
        case 9:
          return Bonus.CompFromString(func, unit.unit.character.bust);
        case 10:
          return Bonus.CompFromString(func, unit.unit.character.waist);
        case 11:
          return Bonus.CompFromString(func, unit.unit.character.hip);
        case 12:
          return unit.unit.character.birthday == today;
        case 13:
          return func((int) unit.playerUnit.GetElement());
        default:
          return false;
      }
    }

    public string DisplayName(bool isPvp = false)
    {
      if (isPvp)
      {
        MasterDataTable.PvpBonus pvpBonus = ((IEnumerable<MasterDataTable.PvpBonus>) MasterData.PvpBonusList).FirstOrDefault<MasterDataTable.PvpBonus>((Func<MasterDataTable.PvpBonus, bool>) (x => x.ID == this.id));
        if (pvpBonus != null)
          return pvpBonus.disp_text + this.skill.name;
      }
      else
      {
        MasterDataTable.ColosseumBonus colosseumBonus = ((IEnumerable<MasterDataTable.ColosseumBonus>) MasterData.ColosseumBonusList).FirstOrDefault<MasterDataTable.ColosseumBonus>((Func<MasterDataTable.ColosseumBonus, bool>) (x => x.ID == this.id));
        if (colosseumBonus != null)
          return colosseumBonus.disp_text + this.skill.name;
      }
      return string.Empty;
    }

    public string RemainingTime()
    {
      int num1 = this.remaining_time / 1440;
      int num2 = this.remaining_time / 60;
      int num3 = this.remaining_time % 60;
      string empty = string.Empty;
      string str;
      if (num1 > 0)
        str = empty + Consts.Format(Consts.GetInstance().COLOSSEUM_BONUS_DAY, (IDictionary) new Hashtable()
        {
          {
            (object) "day",
            (object) num1
          }
        });
      else if (num2 > 0)
        str = empty + Consts.Format(Consts.GetInstance().COLOSSEUM_BONUS_HOUR, (IDictionary) new Hashtable()
        {
          {
            (object) "hour",
            (object) num2
          }
        });
      else
        str = empty + Consts.Format(Consts.GetInstance().COLOSSEUM_BONUS_MINUE, (IDictionary) new Hashtable()
        {
          {
            (object) "min",
            (object) num3
          }
        });
      return str;
    }

    public BattleskillSkill skill
    {
      get
      {
        if (MasterData.BattleskillSkill.ContainsKey(this._skill))
          return MasterData.BattleskillSkill[this._skill];
        Debug.LogError((object) ("Key not Found: MasterData.BattleskillSkill[" + (object) this._skill + "]"));
        return (BattleskillSkill) null;
      }
    }

    private delegate bool CompFunc(int value);
  }
}
