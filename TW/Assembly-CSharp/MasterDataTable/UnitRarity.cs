// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitRarity
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class UnitRarity
  {
    public int ID;
    public string name;
    public int index;
    public int sell_rarity_medal;
    public int skill_levelup_rate;
    public float indicator_level_rate;
    public int reincarnation_level;

    public static UnitRarity Parse(MasterDataReader reader)
    {
      return new UnitRarity()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        index = reader.ReadInt(),
        sell_rarity_medal = reader.ReadInt(),
        skill_levelup_rate = reader.ReadInt(),
        indicator_level_rate = reader.ReadFloat(),
        reincarnation_level = reader.ReadInt()
      };
    }
  }
}
