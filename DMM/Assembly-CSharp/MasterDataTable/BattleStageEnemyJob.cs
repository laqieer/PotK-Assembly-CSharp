// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleStageEnemyJob
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class BattleStageEnemyJob
  {
    public int ID;
    public int job_UnitJob;
    public int? ability1_JobCharacteristics;
    public int level1;
    public int? ability2_JobCharacteristics;
    public int level2;
    public int? ability3_JobCharacteristics;
    public int level3;
    public int? ability4_JobCharacteristics;
    public int level4;

    public static BattleStageEnemyJob Parse(MasterDataReader reader) => new BattleStageEnemyJob()
    {
      ID = reader.ReadInt(),
      job_UnitJob = reader.ReadInt(),
      ability1_JobCharacteristics = reader.ReadIntOrNull(),
      level1 = reader.ReadInt(),
      ability2_JobCharacteristics = reader.ReadIntOrNull(),
      level2 = reader.ReadInt(),
      ability3_JobCharacteristics = reader.ReadIntOrNull(),
      level3 = reader.ReadInt(),
      ability4_JobCharacteristics = reader.ReadIntOrNull(),
      level4 = reader.ReadInt()
    };

    public UnitJob job
    {
      get
      {
        UnitJob unitJob;
        if (!MasterData.UnitJob.TryGetValue(this.job_UnitJob, out unitJob))
          Debug.LogError((object) ("Key not Found: MasterData.UnitJob[" + (object) this.job_UnitJob + "]"));
        return unitJob;
      }
    }

    public JobCharacteristics ability1
    {
      get
      {
        if (!this.ability1_JobCharacteristics.HasValue)
          return (JobCharacteristics) null;
        JobCharacteristics jobCharacteristics;
        if (!MasterData.JobCharacteristics.TryGetValue(this.ability1_JobCharacteristics.Value, out jobCharacteristics))
          Debug.LogError((object) ("Key not Found: MasterData.JobCharacteristics[" + (object) this.ability1_JobCharacteristics.Value + "]"));
        return jobCharacteristics;
      }
    }

    public JobCharacteristics ability2
    {
      get
      {
        if (!this.ability2_JobCharacteristics.HasValue)
          return (JobCharacteristics) null;
        JobCharacteristics jobCharacteristics;
        if (!MasterData.JobCharacteristics.TryGetValue(this.ability2_JobCharacteristics.Value, out jobCharacteristics))
          Debug.LogError((object) ("Key not Found: MasterData.JobCharacteristics[" + (object) this.ability2_JobCharacteristics.Value + "]"));
        return jobCharacteristics;
      }
    }

    public JobCharacteristics ability3
    {
      get
      {
        if (!this.ability3_JobCharacteristics.HasValue)
          return (JobCharacteristics) null;
        JobCharacteristics jobCharacteristics;
        if (!MasterData.JobCharacteristics.TryGetValue(this.ability3_JobCharacteristics.Value, out jobCharacteristics))
          Debug.LogError((object) ("Key not Found: MasterData.JobCharacteristics[" + (object) this.ability3_JobCharacteristics.Value + "]"));
        return jobCharacteristics;
      }
    }

    public JobCharacteristics ability4
    {
      get
      {
        if (!this.ability4_JobCharacteristics.HasValue)
          return (JobCharacteristics) null;
        JobCharacteristics jobCharacteristics;
        if (!MasterData.JobCharacteristics.TryGetValue(this.ability4_JobCharacteristics.Value, out jobCharacteristics))
          Debug.LogError((object) ("Key not Found: MasterData.JobCharacteristics[" + (object) this.ability4_JobCharacteristics.Value + "]"));
        return jobCharacteristics;
      }
    }
  }
}
