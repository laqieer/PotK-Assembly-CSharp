// Decompiled with JetBrains decompiler
// Type: MasterDataTable.SeaDateProhibition
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class SeaDateProhibition
  {
    public int ID;
    public int? same_character_id_UnitUnit;

    public static SeaDateProhibition Parse(MasterDataReader reader) => new SeaDateProhibition()
    {
      ID = reader.ReadInt(),
      same_character_id_UnitUnit = reader.ReadIntOrNull()
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
  }
}
