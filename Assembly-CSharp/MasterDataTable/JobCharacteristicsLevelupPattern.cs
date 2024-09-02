// Decompiled with JetBrains decompiler
// Type: MasterDataTable.JobCharacteristicsLevelupPattern
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class JobCharacteristicsLevelupPattern
  {
    public int ID;
    public int? culled_value;
    public int? proficiency;
    public int? material_group_id1_JobMaterialGroup;
    public int? quantity1;
    public int? material_group_id2_JobMaterialGroup;
    public int? quantity2;
    public int? material_group_id3_JobMaterialGroup;
    public int? quantity3;
    public int? material_group_id4_JobMaterialGroup;
    public int? quantity4;
    public int? material_group_id5_JobMaterialGroup;
    public int? quantity5;
    public int amount;

    public static JobCharacteristicsLevelupPattern Parse(
      MasterDataReader reader)
    {
      return new JobCharacteristicsLevelupPattern()
      {
        ID = reader.ReadInt(),
        culled_value = reader.ReadIntOrNull(),
        proficiency = reader.ReadIntOrNull(),
        material_group_id1_JobMaterialGroup = reader.ReadIntOrNull(),
        quantity1 = reader.ReadIntOrNull(),
        material_group_id2_JobMaterialGroup = reader.ReadIntOrNull(),
        quantity2 = reader.ReadIntOrNull(),
        material_group_id3_JobMaterialGroup = reader.ReadIntOrNull(),
        quantity3 = reader.ReadIntOrNull(),
        material_group_id4_JobMaterialGroup = reader.ReadIntOrNull(),
        quantity4 = reader.ReadIntOrNull(),
        material_group_id5_JobMaterialGroup = reader.ReadIntOrNull(),
        quantity5 = reader.ReadIntOrNull(),
        amount = reader.ReadInt()
      };
    }

    public JobMaterialGroup material_group_id1
    {
      get
      {
        if (!this.material_group_id1_JobMaterialGroup.HasValue)
          return (JobMaterialGroup) null;
        JobMaterialGroup jobMaterialGroup;
        if (!MasterData.JobMaterialGroup.TryGetValue(this.material_group_id1_JobMaterialGroup.Value, out jobMaterialGroup))
          Debug.LogError((object) ("Key not Found: MasterData.JobMaterialGroup[" + (object) this.material_group_id1_JobMaterialGroup.Value + "]"));
        return jobMaterialGroup;
      }
    }

    public JobMaterialGroup material_group_id2
    {
      get
      {
        if (!this.material_group_id2_JobMaterialGroup.HasValue)
          return (JobMaterialGroup) null;
        JobMaterialGroup jobMaterialGroup;
        if (!MasterData.JobMaterialGroup.TryGetValue(this.material_group_id2_JobMaterialGroup.Value, out jobMaterialGroup))
          Debug.LogError((object) ("Key not Found: MasterData.JobMaterialGroup[" + (object) this.material_group_id2_JobMaterialGroup.Value + "]"));
        return jobMaterialGroup;
      }
    }

    public JobMaterialGroup material_group_id3
    {
      get
      {
        if (!this.material_group_id3_JobMaterialGroup.HasValue)
          return (JobMaterialGroup) null;
        JobMaterialGroup jobMaterialGroup;
        if (!MasterData.JobMaterialGroup.TryGetValue(this.material_group_id3_JobMaterialGroup.Value, out jobMaterialGroup))
          Debug.LogError((object) ("Key not Found: MasterData.JobMaterialGroup[" + (object) this.material_group_id3_JobMaterialGroup.Value + "]"));
        return jobMaterialGroup;
      }
    }

    public JobMaterialGroup material_group_id4
    {
      get
      {
        if (!this.material_group_id4_JobMaterialGroup.HasValue)
          return (JobMaterialGroup) null;
        JobMaterialGroup jobMaterialGroup;
        if (!MasterData.JobMaterialGroup.TryGetValue(this.material_group_id4_JobMaterialGroup.Value, out jobMaterialGroup))
          Debug.LogError((object) ("Key not Found: MasterData.JobMaterialGroup[" + (object) this.material_group_id4_JobMaterialGroup.Value + "]"));
        return jobMaterialGroup;
      }
    }

    public JobMaterialGroup material_group_id5
    {
      get
      {
        if (!this.material_group_id5_JobMaterialGroup.HasValue)
          return (JobMaterialGroup) null;
        JobMaterialGroup jobMaterialGroup;
        if (!MasterData.JobMaterialGroup.TryGetValue(this.material_group_id5_JobMaterialGroup.Value, out jobMaterialGroup))
          Debug.LogError((object) ("Key not Found: MasterData.JobMaterialGroup[" + (object) this.material_group_id5_JobMaterialGroup.Value + "]"));
        return jobMaterialGroup;
      }
    }
  }
}
