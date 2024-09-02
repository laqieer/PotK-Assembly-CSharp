// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitUnitBuildupLimitRelease
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class UnitUnitBuildupLimitRelease
  {
    public int ID;
    public int hp_limit_release_cnt;
    public int strength_limit_release_cnt;
    public int vitality_limit_release_cnt;
    public int intelligence_limit_release_cnt;
    public int mind_limit_release_cnt;
    public int agility_limit_release_cnt;
    public int dexterity_limit_release_cnt;
    public int lucky_limit_release_cnt;

    public static UnitUnitBuildupLimitRelease Parse(MasterDataReader reader)
    {
      return new UnitUnitBuildupLimitRelease()
      {
        ID = reader.ReadInt(),
        hp_limit_release_cnt = reader.ReadInt(),
        strength_limit_release_cnt = reader.ReadInt(),
        vitality_limit_release_cnt = reader.ReadInt(),
        intelligence_limit_release_cnt = reader.ReadInt(),
        mind_limit_release_cnt = reader.ReadInt(),
        agility_limit_release_cnt = reader.ReadInt(),
        dexterity_limit_release_cnt = reader.ReadInt(),
        lucky_limit_release_cnt = reader.ReadInt()
      };
    }
  }
}
