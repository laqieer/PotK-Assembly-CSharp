// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitJob
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class UnitJob
  {
    public int ID;
    public string name;
    public string flavor;
    public int move_type_UnitMoveType;
    public int movement;
    public int hp_initial;
    public int strength_initial;
    public int vitality_initial;
    public int intelligence_initial;
    public int mind_initial;
    public int agility_initial;
    public int dexterity_initial;
    public int lucky_initial;
    public int job_rank_UnitJobRank;

    public static UnitJob Parse(MasterDataReader reader)
    {
      return new UnitJob()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        flavor = reader.ReadString(true),
        move_type_UnitMoveType = reader.ReadInt(),
        movement = reader.ReadInt(),
        hp_initial = reader.ReadInt(),
        strength_initial = reader.ReadInt(),
        vitality_initial = reader.ReadInt(),
        intelligence_initial = reader.ReadInt(),
        mind_initial = reader.ReadInt(),
        agility_initial = reader.ReadInt(),
        dexterity_initial = reader.ReadInt(),
        lucky_initial = reader.ReadInt(),
        job_rank_UnitJobRank = reader.ReadInt()
      };
    }

    public UnitMoveType move_type => (UnitMoveType) this.move_type_UnitMoveType;

    public UnitJobRank job_rank => (UnitJobRank) this.job_rank_UnitJobRank;
  }
}
