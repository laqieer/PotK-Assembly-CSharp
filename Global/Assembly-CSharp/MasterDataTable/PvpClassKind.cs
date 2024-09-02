// Decompiled with JetBrains decompiler
// Type: MasterDataTable.PvpClassKind
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using I2.Loc;
using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class PvpClassKind
  {
    public int ID;
    private string _name;
    public int stay_point;
    public int up_point;
    public int title_point;
    public int weight;

    public string name
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._name;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("pvp_PvpClassKind_name_" + (object) this.ID, out Translation) ? Translation : this._name;
      }
      set => this._name = value;
    }

    public static PvpClassKind Parse(MasterDataReader reader)
    {
      return new PvpClassKind()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        stay_point = reader.ReadInt(),
        up_point = reader.ReadInt(),
        title_point = reader.ReadInt(),
        weight = reader.ReadInt()
      };
    }

    public bool isTopClass
    {
      get
      {
        return ((IEnumerable<PvpClassKind>) MasterData.PvpClassKindList).OrderByDescending<PvpClassKind, int>((Func<PvpClassKind, int>) (x => x.weight)).ToList<PvpClassKind>().First<PvpClassKind>() == this;
      }
    }

    public bool isLowestClass
    {
      get
      {
        return ((IEnumerable<PvpClassKind>) MasterData.PvpClassKindList).OrderBy<PvpClassKind, int>((Func<PvpClassKind, int>) (x => x.weight)).ToList<PvpClassKind>().First<PvpClassKind>() == this;
      }
    }

    public PvpClassKind NextClass
    {
      get
      {
        return ((IEnumerable<PvpClassKind>) MasterData.PvpClassKindList).OrderBy<PvpClassKind, int>((Func<PvpClassKind, int>) (x => x.weight)).ToList<PvpClassKind>().FirstOrDefault<PvpClassKind>((Func<PvpClassKind, bool>) (x => x.weight > this.weight));
      }
    }

    public PvpClassKind PreviousClass
    {
      get
      {
        return ((IEnumerable<PvpClassKind>) MasterData.PvpClassKindList).OrderByDescending<PvpClassKind, int>((Func<PvpClassKind, int>) (x => x.weight)).ToList<PvpClassKind>().FirstOrDefault<PvpClassKind>((Func<PvpClassKind, bool>) (x => x.weight < this.weight));
      }
    }

    public bool isGetTitle(int nowWin)
    {
      PvpClassKind.Condition condition = this.ClassCondition(nowWin);
      return condition == PvpClassKind.Condition.TITLE || condition == PvpClassKind.Condition.TITLE_TOPCLASS;
    }

    public PvpClassKind.Condition ClassCondition(int nowWin, bool isZone = false)
    {
      PvpClassKind.Condition condition = PvpClassKind.Condition.DOWN;
      if (this.title_point <= nowWin)
        condition = PvpClassKind.Condition.TITLE;
      else if (this.up_point <= nowWin)
        condition = PvpClassKind.Condition.UP;
      else if (this.stay_point <= nowWin)
        condition = PvpClassKind.Condition.STAY;
      if (this.isTopClass && (condition == PvpClassKind.Condition.STAY || condition == PvpClassKind.Condition.TITLE))
        ++condition;
      if (isZone)
        this.ClassConditionZone(ref condition);
      return condition;
    }

    public void ClassConditionZone(ref PvpClassKind.Condition condition)
    {
      if (condition == PvpClassKind.Condition.DOWN)
        condition = PvpClassKind.Condition.DOWN_ZONE;
      else if (condition == PvpClassKind.Condition.STAY)
        condition = PvpClassKind.Condition.STAY_ZONE;
      else if (condition == PvpClassKind.Condition.UP)
        condition = PvpClassKind.Condition.UP_ZONE;
      else if (condition == PvpClassKind.Condition.TITLE)
        condition = PvpClassKind.Condition.TITLE_ZONE;
      else if (condition == PvpClassKind.Condition.STAY_TOPCLASS)
      {
        condition = PvpClassKind.Condition.STAY_TOPCLASS_ZONE;
      }
      else
      {
        if (condition != PvpClassKind.Condition.TITLE_TOPCLASS)
          return;
        condition = PvpClassKind.Condition.TITLE_TOPCLASS_ZONE;
      }
    }

    public PvpClassKind.Condition NextCondition(int nowWin)
    {
      return this.NextCondition(this.ClassCondition(nowWin));
    }

    public PvpClassKind.Condition NextCondition(PvpClassKind.Condition condition)
    {
      switch (condition)
      {
        case PvpClassKind.Condition.DOWN:
          if (this.isTopClass)
            return this.stay_point == this.title_point ? PvpClassKind.Condition.TITLE_TOPCLASS : PvpClassKind.Condition.STAY_TOPCLASS;
          if (this.stay_point != this.up_point)
            return PvpClassKind.Condition.STAY;
          return this.up_point == this.title_point ? PvpClassKind.Condition.TITLE : PvpClassKind.Condition.UP;
        case PvpClassKind.Condition.STAY:
          return this.up_point == this.title_point ? PvpClassKind.Condition.TITLE : PvpClassKind.Condition.UP;
        case PvpClassKind.Condition.STAY_TOPCLASS:
          return PvpClassKind.Condition.TITLE_TOPCLASS;
        case PvpClassKind.Condition.UP:
          return PvpClassKind.Condition.TITLE;
        default:
          return condition;
      }
    }

    public enum Condition
    {
      DOWN,
      STAY,
      STAY_TOPCLASS,
      UP,
      TITLE,
      TITLE_TOPCLASS,
      DOWN_ZONE,
      STAY_ZONE,
      STAY_TOPCLASS_ZONE,
      UP_ZONE,
      TITLE_ZONE,
      TITLE_TOPCLASS_ZONE,
    }
  }
}
