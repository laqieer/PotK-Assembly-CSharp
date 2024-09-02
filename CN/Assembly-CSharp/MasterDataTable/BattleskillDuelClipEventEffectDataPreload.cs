// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleskillDuelClipEventEffectDataPreload
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
