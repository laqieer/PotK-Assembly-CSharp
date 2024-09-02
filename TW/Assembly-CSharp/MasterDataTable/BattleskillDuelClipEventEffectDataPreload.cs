// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleskillDuelClipEventEffectDataPreload
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class BattleskillDuelClipEventEffectDataPreload
  {
    public int ID;
    public int duel_effect_id;
    public string clipeventeffectdata_file_name;

    public static BattleskillDuelClipEventEffectDataPreload Parse(MasterDataReader reader)
    {
      return new BattleskillDuelClipEventEffectDataPreload()
      {
        ID = reader.ReadInt(),
        duel_effect_id = reader.ReadInt(),
        clipeventeffectdata_file_name = reader.ReadString(true)
      };
    }
  }
}
