// Decompiled with JetBrains decompiler
// Type: MasterDataTable.SeaPresentPresentResult
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class SeaPresentPresentResult
  {
    public int ID;
    public int? same_character_id_UnitUnit;
    public int? character_id;
    public int affinity_SeaPresentAffinity;
    public string serif;
    public string face;
    public string voice_cue_name;

    public static SeaPresentPresentResult Parse(MasterDataReader reader) => new SeaPresentPresentResult()
    {
      ID = reader.ReadInt(),
      same_character_id_UnitUnit = reader.ReadIntOrNull(),
      character_id = reader.ReadIntOrNull(),
      affinity_SeaPresentAffinity = reader.ReadInt(),
      serif = reader.ReadString(true),
      face = reader.ReadString(true),
      voice_cue_name = reader.ReadString(true)
    };

    public UnitUnit same_character_id
    {
      get
      {
        if (!this.same_character_id_UnitUnit.HasValue)
          return (UnitUnit) null;
        UnitUnit unitUnit;
        if (!MasterData.UnitUnit.TryGetValue(this.same_character_id_UnitUnit.Value, out unitUnit))
          Debug.LogError((object) ("Key not Found: MasterData.UnitUnit[" + (object) this.same_character_id_UnitUnit.Value + "]"));
        return unitUnit;
      }
    }

    public SeaPresentAffinity affinity
    {
      get
      {
        SeaPresentAffinity seaPresentAffinity;
        if (!MasterData.SeaPresentAffinity.TryGetValue(this.affinity_SeaPresentAffinity, out seaPresentAffinity))
          Debug.LogError((object) ("Key not Found: MasterData.SeaPresentAffinity[" + (object) this.affinity_SeaPresentAffinity + "]"));
        return seaPresentAffinity;
      }
    }
  }
}
