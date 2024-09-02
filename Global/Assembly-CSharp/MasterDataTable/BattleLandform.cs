// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleLandform
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using I2.Loc;
using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class BattleLandform
  {
    private static GameGlobalVariable<AssocList<int, BattleLandformIncr>> incrDic = GameGlobalVariable<AssocList<int, BattleLandformIncr>>.Null();
    public int ID;
    private string _name;
    public int physical_defense_incr;
    public int magic_defense_incr;
    public int hit_incr;
    public int critical_incr;
    public int evasion_incr;
    public float hp_healing_ratio;
    public int moveA_incr;
    public int moveB_incr;
    public int moveC_incr;
    public int moveD_incr;
    public int moveE_incr;
    public int moveF_incr;
    public int in_out_BattleInOutSide;
    public int footstep_type_BattleLandformFootstepType;

    private static int MakeIncrKey(BattleLandform landform, UnitMoveType move_type)
    {
      return (int) ((landform.ID << 8) + move_type);
    }

    public static void CacheClear()
    {
      BattleLandform.incrDic = GameGlobalVariable<AssocList<int, BattleLandformIncr>>.Null();
    }

    public BattleLandformIncr GetIncr(UnitMoveType move_type)
    {
      if (BattleLandform.incrDic.Get() == null)
      {
        AssocList<int, BattleLandformIncr> v = new AssocList<int, BattleLandformIncr>();
        BattleLandform.incrDic.Reset(v);
        foreach (BattleLandformIncr battleLandformIncr in MasterData.BattleLandformIncrList)
          v.Add(BattleLandform.MakeIncrKey(battleLandformIncr.landform, battleLandformIncr.move_type), battleLandformIncr);
      }
      return BattleLandform.incrDic.Get()[BattleLandform.MakeIncrKey(this, move_type)];
    }

    public BattleLandformIncr GetIncr(UnitUnit unit) => this.GetIncr(unit.job.move_type);

    public BattleLandformIncr GetDisplayIncr() => this.GetIncr(UnitMoveType.keihohei);

    public BattleLandformIncr[] GetAllIncr()
    {
      return ((IEnumerable<BattleLandformIncr>) MasterData.BattleLandformIncrList).Where<BattleLandformIncr>((Func<BattleLandformIncr, bool>) (x => x.landform.ID == this.ID)).ToArray<BattleLandformIncr>();
    }

    public BattleUnitLandformFootstep GetFootstep(UnitUnit unit)
    {
      return ((IEnumerable<BattleUnitLandformFootstep>) MasterData.BattleUnitLandformFootstepList).Single<BattleUnitLandformFootstep>((Func<BattleUnitLandformFootstep, bool>) (x => x.unit_footstep_type.ID == unit.footstep_type.ID && x.landform_footstep_type.ID == this.footstep_type.ID));
    }

    public string name
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._name;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("battle_BattleLandform_name_" + (object) this.ID, out Translation) ? Translation : this._name;
      }
      set => this._name = value;
    }

    public static BattleLandform Parse(MasterDataReader reader)
    {
      return new BattleLandform()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        physical_defense_incr = reader.ReadInt(),
        magic_defense_incr = reader.ReadInt(),
        hit_incr = reader.ReadInt(),
        critical_incr = reader.ReadInt(),
        evasion_incr = reader.ReadInt(),
        hp_healing_ratio = reader.ReadFloat(),
        moveA_incr = reader.ReadInt(),
        moveB_incr = reader.ReadInt(),
        moveC_incr = reader.ReadInt(),
        moveD_incr = reader.ReadInt(),
        moveE_incr = reader.ReadInt(),
        moveF_incr = reader.ReadInt(),
        in_out_BattleInOutSide = reader.ReadInt(),
        footstep_type_BattleLandformFootstepType = reader.ReadInt()
      };
    }

    public BattleInOutSide in_out => (BattleInOutSide) this.in_out_BattleInOutSide;

    public BattleLandformFootstepType footstep_type
    {
      get
      {
        BattleLandformFootstepType footstepType;
        if (!MasterData.BattleLandformFootstepType.TryGetValue(this.footstep_type_BattleLandformFootstepType, out footstepType))
          Debug.LogError((object) ("Key not Found: MasterData.BattleLandformFootstepType[" + (object) this.footstep_type_BattleLandformFootstepType + "]"));
        return footstepType;
      }
    }
  }
}
