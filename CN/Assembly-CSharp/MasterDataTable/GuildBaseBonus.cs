// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GuildBaseBonus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class GuildBaseBonus
  {
    public int ID;
    public int base_type_GuildBaseType;
    public int base_rank;
    public int bonus_type_GuildBaseBonusType;
    public int bonus_grade;

    public static GuildBaseBonus Parse(MasterDataReader reader)
    {
      return new GuildBaseBonus()
      {
        ID = reader.ReadInt(),
        base_type_GuildBaseType = reader.ReadInt(),
        base_rank = reader.ReadInt(),
        bonus_type_GuildBaseBonusType = reader.ReadInt(),
        bonus_grade = reader.ReadInt()
      };
    }

    public GuildBaseType base_type => (GuildBaseType) this.base_type_GuildBaseType;

    public GuildBaseBonusType bonus_type => (GuildBaseBonusType) this.bonus_type_GuildBaseBonusType;
  }
}
