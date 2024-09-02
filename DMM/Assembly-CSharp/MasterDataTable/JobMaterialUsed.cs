// Decompiled with JetBrains decompiler
// Type: MasterDataTable.JobMaterialUsed
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class JobMaterialUsed
  {
    public int ID;
    public int? unit_UnitUnit;
    public int? material_group_id_JobMaterialGroup;
    public int? check_item_id;

    public static JobMaterialUsed Parse(MasterDataReader reader) => new JobMaterialUsed()
    {
      ID = reader.ReadInt(),
      unit_UnitUnit = reader.ReadIntOrNull(),
      material_group_id_JobMaterialGroup = reader.ReadIntOrNull(),
      check_item_id = reader.ReadIntOrNull()
    };

    public UnitUnit unit
    {
      get
      {
        if (!this.unit_UnitUnit.HasValue)
          return (UnitUnit) null;
        UnitUnit unitUnit;
        if (!MasterData.UnitUnit.TryGetValue(this.unit_UnitUnit.Value, out unitUnit))
          Debug.LogError((object) ("Key not Found: MasterData.UnitUnit[" + (object) this.unit_UnitUnit.Value + "]"));
        return unitUnit;
      }
    }

    public JobMaterialGroup material_group_id
    {
      get
      {
        if (!this.material_group_id_JobMaterialGroup.HasValue)
          return (JobMaterialGroup) null;
        JobMaterialGroup jobMaterialGroup;
        if (!MasterData.JobMaterialGroup.TryGetValue(this.material_group_id_JobMaterialGroup.Value, out jobMaterialGroup))
          Debug.LogError((object) ("Key not Found: MasterData.JobMaterialGroup[" + (object) this.material_group_id_JobMaterialGroup.Value + "]"));
        return jobMaterialGroup;
      }
    }
  }
}
