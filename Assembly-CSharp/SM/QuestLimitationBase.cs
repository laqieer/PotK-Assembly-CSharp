// Decompiled with JetBrains decompiler
// Type: SM.QuestLimitationBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using DeckOrganization;
using MasterDataTable;
using System;
using System.Collections.Generic;
using UniLinq;

namespace SM
{
  [Serializable]
  public class QuestLimitationBase : KeyCompare
  {
    public int limitation_type;
    public string value;
    public int comparison_operator;
    public int? sub_comparison_operator;
    public int? sub_value;
    private static Dictionary<QuestLimitedCondition, Filter.Factor> dicConditionFactor_;
    private static Dictionary<OperatorEnum, Filter.Expression> dicOperatorExpression_;

    public QuestLimitationBase()
    {
    }

    public QuestLimitationBase(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.limitation_type = (int) (long) json[nameof (limitation_type)];
      this.value = (string) json[nameof (value)];
      this.comparison_operator = (int) (long) json[nameof (comparison_operator)];
      long? nullable1;
      int? nullable2;
      if (json[nameof (sub_comparison_operator)] != null)
      {
        nullable1 = (long?) json[nameof (sub_comparison_operator)];
        nullable2 = nullable1.HasValue ? new int?((int) nullable1.GetValueOrDefault()) : new int?();
      }
      else
        nullable2 = new int?();
      this.sub_comparison_operator = nullable2;
      int? nullable3;
      if (json[nameof (sub_value)] != null)
      {
        nullable1 = (long?) json[nameof (sub_value)];
        nullable3 = nullable1.HasValue ? new int?((int) nullable1.GetValueOrDefault()) : new int?();
      }
      else
        nullable3 = new int?();
      this.sub_value = nullable3;
    }

    public QuestLimitedCondition limitedCondition => (QuestLimitedCondition) this.limitation_type;

    public OperatorEnum operatorEnum => (OperatorEnum) this.comparison_operator;

    public List<string> stringArguments
    {
      get
      {
        if (string.IsNullOrEmpty(this.value))
          return new List<string>();
        return ((IEnumerable<string>) this.value.Split(',')).Select<string, string>((Func<string, string>) (s => s.Trim())).ToList<string>();
      }
    }

    public List<int> intArguments
    {
      get
      {
        List<string> stringArguments = this.stringArguments;
        if (stringArguments.Count == 0)
          return new List<int>();
        List<int> intList = new List<int>();
        foreach (string s in stringArguments)
        {
          double result;
          if (double.TryParse(s, out result))
          {
            int num = (int) Math.Floor(result);
            intList.Add(num);
          }
          else
          {
            intList.Clear();
            break;
          }
        }
        return intList;
      }
    }

    public List<int> unitTypeArguments
    {
      get
      {
        List<string> stringArguments = this.stringArguments;
        if (stringArguments.Count == 0)
          return new List<int>();
        List<int> intList = new List<int>();
        foreach (string str in stringArguments)
        {
          string s = str;
          MasterDataTable.UnitType unitType = ((IEnumerable<MasterDataTable.UnitType>) MasterData.UnitTypeList).FirstOrDefault<MasterDataTable.UnitType>((Func<MasterDataTable.UnitType, bool>) (u => u.name == s));
          if (unitType != null)
          {
            intList.Add(unitType.ID);
          }
          else
          {
            intList.Clear();
            break;
          }
        }
        return intList;
      }
    }

    public List<int> familyArguments
    {
      get
      {
        List<string> stringArguments = this.stringArguments;
        if (stringArguments.Count == 0)
          return new List<int>();
        List<int> intList = new List<int>();
        foreach (string str in stringArguments)
        {
          string s = str;
          UnitFamilyValue unitFamilyValue = ((IEnumerable<UnitFamilyValue>) MasterData.UnitFamilyValueList).FirstOrDefault<UnitFamilyValue>((Func<UnitFamilyValue, bool>) (u => u.name == s));
          if (unitFamilyValue != null)
          {
            intList.Add(unitFamilyValue.ID);
          }
          else
          {
            intList.Clear();
            break;
          }
        }
        return intList;
      }
    }

    public List<int> rarityArguments
    {
      get
      {
        List<string> stringArguments = this.stringArguments;
        if (stringArguments.Count == 0)
          return new List<int>();
        List<int> intList = new List<int>();
        foreach (string str in stringArguments)
        {
          string s = str;
          UnitRarity unitRarity = ((IEnumerable<UnitRarity>) MasterData.UnitRarityList).FirstOrDefault<UnitRarity>((Func<UnitRarity, bool>) (u => u.name == s));
          if (unitRarity != null)
          {
            intList.Add(unitRarity.index + 1);
          }
          else
          {
            intList.Clear();
            break;
          }
        }
        return intList;
      }
    }

    private void getLimitParam(out Filter.Limit limit, out int limitParam)
    {
      limit = Filter.Limit.None;
      limitParam = 0;
      if (!this.sub_comparison_operator.HasValue)
        return;
      int num1 = this.sub_comparison_operator.Value;
      int num2 = this.sub_value.HasValue ? this.sub_value.Value : 0;
      switch (num1)
      {
        case 1:
          if (num2 <= 0)
            break;
          limit = Filter.Limit.Equal;
          limitParam = num2;
          break;
        case 4:
          if (num2 <= 0)
            break;
          limit = Filter.Limit.GreaterEqual;
          limitParam = num2;
          break;
        case 5:
          if (num2 <= 0)
            break;
          limit = Filter.Limit.LessEqual;
          limitParam = num2;
          break;
      }
    }

    private Dictionary<QuestLimitedCondition, Filter.Factor> dicConditionFactor
    {
      get
      {
        if (QuestLimitationBase.dicConditionFactor_ == null)
          QuestLimitationBase.dicConditionFactor_ = new Dictionary<QuestLimitedCondition, Filter.Factor>()
          {
            {
              QuestLimitedCondition.unit_type,
              Filter.Factor.UnitType
            },
            {
              QuestLimitedCondition.job,
              Filter.Factor.Job
            },
            {
              QuestLimitedCondition.population,
              Filter.Factor.UnitFamily
            },
            {
              QuestLimitedCondition.move_type,
              Filter.Factor.MoveType
            },
            {
              QuestLimitedCondition.blood,
              Filter.Factor.Blood
            },
            {
              QuestLimitedCondition.height,
              Filter.Factor.Height
            },
            {
              QuestLimitedCondition.bust,
              Filter.Factor.Bust
            },
            {
              QuestLimitedCondition.hip,
              Filter.Factor.Hips
            },
            {
              QuestLimitedCondition.cost,
              Filter.Factor.Cost
            },
            {
              QuestLimitedCondition.rarity,
              Filter.Factor.Rarity
            },
            {
              QuestLimitedCondition.unit,
              Filter.Factor.UnitID
            },
            {
              QuestLimitedCondition.skill,
              Filter.Factor.Skill
            },
            {
              QuestLimitedCondition.gear_kind,
              Filter.Factor.GearKind
            },
            {
              QuestLimitedCondition.same_character,
              Filter.Factor.SameCharacter
            },
            {
              QuestLimitedCondition.history_number,
              Filter.Factor.HistoryGroup
            },
            {
              QuestLimitedCondition.large_category,
              Filter.Factor.GroupLarge
            },
            {
              QuestLimitedCondition.small_category,
              Filter.Factor.GroupSmall
            },
            {
              QuestLimitedCondition.clothing_category,
              Filter.Factor.GroupClothing
            },
            {
              QuestLimitedCondition.generation_category,
              Filter.Factor.GroupGeneration
            },
            {
              QuestLimitedCondition.minimum_unit_count,
              Filter.Factor.UnitSetMin
            },
            {
              QuestLimitedCondition.max_unit_count,
              Filter.Factor.UnitSetMax
            },
            {
              QuestLimitedCondition.total_cost,
              Filter.Factor.TotalCost
            },
            {
              QuestLimitedCondition.same_unit,
              Filter.Factor.DistinctUnit
            },
            {
              QuestLimitedCondition.character,
              Filter.Factor.Character
            },
            {
              QuestLimitedCondition.unit_level,
              Filter.Factor.Level
            },
            {
              QuestLimitedCondition.weight,
              Filter.Factor.Weight
            },
            {
              QuestLimitedCondition.waist,
              Filter.Factor.Waist
            },
            {
              QuestLimitedCondition.zodiac_sign,
              Filter.Factor.ZodiacSign
            },
            {
              QuestLimitedCondition.birth_month,
              Filter.Factor.BirthdayMonth
            }
          };
        return QuestLimitationBase.dicConditionFactor_;
      }
    }

    public Filter.Factor filterFactor
    {
      get
      {
        Filter.Factor factor;
        return this.dicConditionFactor.TryGetValue(this.limitedCondition, out factor) ? factor : Filter.Factor.None;
      }
    }

    private Dictionary<OperatorEnum, Filter.Expression> dicOperatorExpression
    {
      get
      {
        if (QuestLimitationBase.dicOperatorExpression_ == null)
          QuestLimitationBase.dicOperatorExpression_ = new Dictionary<OperatorEnum, Filter.Expression>()
          {
            {
              OperatorEnum.equal,
              Filter.Expression.Equal
            },
            {
              OperatorEnum.greater_than,
              Filter.Expression.GreaterThan
            },
            {
              OperatorEnum.less_than,
              Filter.Expression.LessThan
            },
            {
              OperatorEnum.greater_than_or_equal_to,
              Filter.Expression.GreaterEqual
            },
            {
              OperatorEnum.less_than_or_equal_to,
              Filter.Expression.LessEqual
            },
            {
              OperatorEnum.In,
              Filter.Expression.Include
            },
            {
              OperatorEnum.Out,
              Filter.Expression.Ignore
            }
          };
        return QuestLimitationBase.dicOperatorExpression_;
      }
    }

    public Filter.Expression filterExpression
    {
      get
      {
        Filter.Expression expression;
        return this.dicOperatorExpression.TryGetValue(this.operatorEnum, out expression) ? expression : Filter.Expression.None;
      }
    }

    public Filter createFilter(int filterno)
    {
      Filter.Factor filterFactor = this.filterFactor;
      Filter.Expression filterExpression = this.filterExpression;
      Filter.Limit limit;
      int limitParam;
      this.getLimitParam(out limit, out limitParam);
      switch (filterFactor)
      {
        case Filter.Factor.UnitType:
          if (filterExpression != Filter.Expression.None)
          {
            List<int> unitTypeArguments = this.unitTypeArguments;
            if (unitTypeArguments.Count != 0)
            {
              switch (filterExpression)
              {
                case Filter.Expression.Include:
                case Filter.Expression.Ignore:
                  return new Filter(filterno, filterFactor, filterExpression, unitTypeArguments, limit, limitParam);
                default:
                  return new Filter(filterno, filterFactor, filterExpression, unitTypeArguments.First<int>(), limit, limitParam);
              }
            }
            else
              break;
          }
          else
            break;
        case Filter.Factor.Job:
        case Filter.Factor.MoveType:
        case Filter.Factor.Height:
        case Filter.Factor.Bust:
        case Filter.Factor.Hips:
        case Filter.Factor.Cost:
        case Filter.Factor.Character:
        case Filter.Factor.UnitID:
        case Filter.Factor.Level:
        case Filter.Factor.GearKind:
        case Filter.Factor.Skill:
        case Filter.Factor.Weight:
        case Filter.Factor.Waist:
        case Filter.Factor.SameCharacter:
        case Filter.Factor.HistoryGroup:
        case Filter.Factor.GroupLarge:
        case Filter.Factor.GroupSmall:
        case Filter.Factor.GroupClothing:
        case Filter.Factor.GroupGeneration:
          if (filterExpression != Filter.Expression.None)
          {
            List<int> intArguments = this.intArguments;
            if (intArguments.Count != 0)
            {
              switch (filterExpression)
              {
                case Filter.Expression.Include:
                case Filter.Expression.Ignore:
                  return new Filter(filterno, filterFactor, filterExpression, intArguments, limit, limitParam);
                default:
                  return new Filter(filterno, filterFactor, filterExpression, intArguments.First<int>(), limit, limitParam);
              }
            }
            else
              break;
          }
          else
            break;
        case Filter.Factor.UnitFamily:
          if (filterExpression != Filter.Expression.None)
          {
            List<int> familyArguments = this.familyArguments;
            if (familyArguments.Count != 0)
            {
              switch (filterExpression)
              {
                case Filter.Expression.Include:
                case Filter.Expression.Ignore:
                  return new Filter(filterno, filterFactor, filterExpression, familyArguments, limit, limitParam);
                default:
                  return new Filter(filterno, filterFactor, filterExpression, familyArguments.First<int>(), limit, limitParam);
              }
            }
            else
              break;
          }
          else
            break;
        case Filter.Factor.Blood:
        case Filter.Factor.BirthdayMonth:
        case Filter.Factor.ZodiacSign:
          if (filterExpression != Filter.Expression.None)
          {
            List<string> stringArguments = this.stringArguments;
            if (stringArguments.Count != 0)
            {
              switch (filterExpression)
              {
                case Filter.Expression.Include:
                case Filter.Expression.Ignore:
                  return new Filter(filterno, filterFactor, filterExpression, stringArguments, limit, limitParam);
                default:
                  return new Filter(filterno, filterFactor, filterExpression, stringArguments.First<string>(), limit, limitParam);
              }
            }
            else
              break;
          }
          else
            break;
        case Filter.Factor.Rarity:
          if (filterExpression != Filter.Expression.None)
          {
            List<int> rarityArguments = this.rarityArguments;
            if (rarityArguments.Count != 0)
            {
              switch (filterExpression)
              {
                case Filter.Expression.Include:
                case Filter.Expression.Ignore:
                  return new Filter(filterno, filterFactor, filterExpression, rarityArguments, limit, limitParam);
                default:
                  return new Filter(filterno, filterFactor, filterExpression, rarityArguments.First<int>(), limit, limitParam);
              }
            }
            else
              break;
          }
          else
            break;
        case Filter.Factor.DistinctUnit:
          List<int> intArguments1 = this.intArguments;
          if (intArguments1.Count != 0)
          {
            List<int> intList = new List<int>();
            foreach (int num in intArguments1)
            {
              switch (num)
              {
                case 1:
                  intList.Add(29);
                  continue;
                case 2:
                  intList.Add(27);
                  continue;
                case 3:
                  intList.Add(26);
                  continue;
                case 4:
                  intList.Add(28);
                  continue;
                default:
                  continue;
              }
            }
            if (intList.Count != 0)
              return intList.Count == 1 ? new Filter(filterno, (Filter.Factor) intList.First<int>()) : new Filter(filterno, (Filter.Factor) intList.First<int>(), Filter.Expression.Include, intList);
            break;
          }
          break;
        case Filter.Factor.UnitSetMin:
        case Filter.Factor.UnitSetMax:
        case Filter.Factor.TotalCost:
          List<int> intArguments2 = this.intArguments;
          if (intArguments2.Count != 0)
            return new Filter(filterno, filterFactor, intArguments2.First<int>());
          break;
      }
      return (Filter) null;
    }
  }
}
