// Decompiled with JetBrains decompiler
// Type: MasterDataTable.JobChangePatterns
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using LocaleTimeZone;
using System;
using System.Collections.Generic;

namespace MasterDataTable
{
  [Serializable]
  public class JobChangePatterns
  {
    public int ID;
    public int unit_UnitUnit;
    public int job_UnitJob;
    public int job1_UnitJob;
    public int? materials1_JobChangeMaterials;
    public int job2_UnitJob;
    public int materials2_JobChangeMaterials;
    public int? job3_UnitJob;
    public int? materials3_JobChangeMaterials;
    public int? job4_UnitJob;
    public int? materials4_JobChangeMaterials;
    public int? job5_UnitJob;
    public int? materials5_JobChangeMaterials;
    public int? job6_UnitJob;
    public int? materials6_JobChangeMaterials;
    public int? job7_UnitJob;
    public int? materials7_JobChangeMaterials;

    public static JobChangePatterns Parse(MasterDataReader reader) => new JobChangePatterns()
    {
      ID = reader.ReadInt(),
      unit_UnitUnit = reader.ReadInt(),
      job_UnitJob = reader.ReadInt(),
      job1_UnitJob = reader.ReadInt(),
      materials1_JobChangeMaterials = reader.ReadIntOrNull(),
      job2_UnitJob = reader.ReadInt(),
      materials2_JobChangeMaterials = reader.ReadInt(),
      job3_UnitJob = reader.ReadIntOrNull(),
      materials3_JobChangeMaterials = reader.ReadIntOrNull(),
      job4_UnitJob = reader.ReadIntOrNull(),
      materials4_JobChangeMaterials = reader.ReadIntOrNull(),
      job5_UnitJob = reader.ReadIntOrNull(),
      materials5_JobChangeMaterials = reader.ReadIntOrNull(),
      job6_UnitJob = reader.ReadIntOrNull(),
      materials6_JobChangeMaterials = reader.ReadIntOrNull(),
      job7_UnitJob = reader.ReadIntOrNull(),
      materials7_JobChangeMaterials = reader.ReadIntOrNull()
    };

    public UnitUnit unit
    {
      get
      {
        UnitUnit unitUnit;
        if (!MasterData.UnitUnit.TryGetValue(this.unit_UnitUnit, out unitUnit))
          Debug.LogError((object) ("Key not Found: MasterData.UnitUnit[" + (object) this.unit_UnitUnit + "]"));
        return unitUnit;
      }
    }

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

    public UnitJob job1
    {
      get
      {
        UnitJob unitJob;
        if (!MasterData.UnitJob.TryGetValue(this.job1_UnitJob, out unitJob))
          Debug.LogError((object) ("Key not Found: MasterData.UnitJob[" + (object) this.job1_UnitJob + "]"));
        return unitJob;
      }
    }

    public JobChangeMaterials materials1
    {
      get
      {
        if (!this.materials1_JobChangeMaterials.HasValue)
          return (JobChangeMaterials) null;
        JobChangeMaterials jobChangeMaterials;
        if (!MasterData.JobChangeMaterials.TryGetValue(this.materials1_JobChangeMaterials.Value, out jobChangeMaterials))
          Debug.LogError((object) ("Key not Found: MasterData.JobChangeMaterials[" + (object) this.materials1_JobChangeMaterials.Value + "]"));
        return jobChangeMaterials;
      }
    }

    public UnitJob job2
    {
      get
      {
        UnitJob unitJob;
        if (!MasterData.UnitJob.TryGetValue(this.job2_UnitJob, out unitJob))
          Debug.LogError((object) ("Key not Found: MasterData.UnitJob[" + (object) this.job2_UnitJob + "]"));
        return unitJob;
      }
    }

    public JobChangeMaterials materials2
    {
      get
      {
        JobChangeMaterials jobChangeMaterials;
        if (!MasterData.JobChangeMaterials.TryGetValue(this.materials2_JobChangeMaterials, out jobChangeMaterials))
          Debug.LogError((object) ("Key not Found: MasterData.JobChangeMaterials[" + (object) this.materials2_JobChangeMaterials + "]"));
        return jobChangeMaterials;
      }
    }

    public UnitJob job3
    {
      get
      {
        if (!this.job3_UnitJob.HasValue)
          return (UnitJob) null;
        UnitJob unitJob;
        if (!MasterData.UnitJob.TryGetValue(this.job3_UnitJob.Value, out unitJob))
          Debug.LogError((object) ("Key not Found: MasterData.UnitJob[" + (object) this.job3_UnitJob.Value + "]"));
        return unitJob;
      }
    }

    public JobChangeMaterials materials3
    {
      get
      {
        if (!this.materials3_JobChangeMaterials.HasValue)
          return (JobChangeMaterials) null;
        JobChangeMaterials jobChangeMaterials;
        if (!MasterData.JobChangeMaterials.TryGetValue(this.materials3_JobChangeMaterials.Value, out jobChangeMaterials))
          Debug.LogError((object) ("Key not Found: MasterData.JobChangeMaterials[" + (object) this.materials3_JobChangeMaterials.Value + "]"));
        return jobChangeMaterials;
      }
    }

    public UnitJob job4
    {
      get
      {
        if (!this.job4_UnitJob.HasValue)
          return (UnitJob) null;
        UnitJob unitJob;
        if (!MasterData.UnitJob.TryGetValue(this.job4_UnitJob.Value, out unitJob))
          Debug.LogError((object) ("Key not Found: MasterData.UnitJob[" + (object) this.job4_UnitJob.Value + "]"));
        return unitJob;
      }
    }

    public JobChangeMaterials materials4
    {
      get
      {
        if (!this.materials4_JobChangeMaterials.HasValue)
          return (JobChangeMaterials) null;
        JobChangeMaterials jobChangeMaterials;
        if (!MasterData.JobChangeMaterials.TryGetValue(this.materials4_JobChangeMaterials.Value, out jobChangeMaterials))
          Debug.LogError((object) ("Key not Found: MasterData.JobChangeMaterials[" + (object) this.materials4_JobChangeMaterials.Value + "]"));
        return jobChangeMaterials;
      }
    }

    public UnitJob job5
    {
      get
      {
        if (!this.job5_UnitJob.HasValue)
          return (UnitJob) null;
        UnitJob unitJob;
        if (!MasterData.UnitJob.TryGetValue(this.job5_UnitJob.Value, out unitJob))
          Debug.LogError((object) ("Key not Found: MasterData.UnitJob[" + (object) this.job5_UnitJob.Value + "]"));
        return unitJob;
      }
    }

    public JobChangeMaterials materials5
    {
      get
      {
        if (!this.materials5_JobChangeMaterials.HasValue)
          return (JobChangeMaterials) null;
        JobChangeMaterials jobChangeMaterials;
        if (!MasterData.JobChangeMaterials.TryGetValue(this.materials5_JobChangeMaterials.Value, out jobChangeMaterials))
          Debug.LogError((object) ("Key not Found: MasterData.JobChangeMaterials[" + (object) this.materials5_JobChangeMaterials.Value + "]"));
        return jobChangeMaterials;
      }
    }

    public UnitJob job6
    {
      get
      {
        if (!this.job6_UnitJob.HasValue)
          return (UnitJob) null;
        UnitJob unitJob;
        if (!MasterData.UnitJob.TryGetValue(this.job6_UnitJob.Value, out unitJob))
          Debug.LogError((object) ("Key not Found: MasterData.UnitJob[" + (object) this.job6_UnitJob.Value + "]"));
        return unitJob;
      }
    }

    public JobChangeMaterials materials6
    {
      get
      {
        if (!this.materials6_JobChangeMaterials.HasValue)
          return (JobChangeMaterials) null;
        JobChangeMaterials jobChangeMaterials;
        if (!MasterData.JobChangeMaterials.TryGetValue(this.materials6_JobChangeMaterials.Value, out jobChangeMaterials))
          Debug.LogError((object) ("Key not Found: MasterData.JobChangeMaterials[" + (object) this.materials6_JobChangeMaterials.Value + "]"));
        return jobChangeMaterials;
      }
    }

    public UnitJob job7
    {
      get
      {
        if (!this.job7_UnitJob.HasValue)
          return (UnitJob) null;
        UnitJob unitJob;
        if (!MasterData.UnitJob.TryGetValue(this.job7_UnitJob.Value, out unitJob))
          Debug.LogError((object) ("Key not Found: MasterData.UnitJob[" + (object) this.job7_UnitJob.Value + "]"));
        return unitJob;
      }
    }

    public JobChangeMaterials materials7
    {
      get
      {
        if (!this.materials7_JobChangeMaterials.HasValue)
          return (JobChangeMaterials) null;
        JobChangeMaterials jobChangeMaterials;
        if (!MasterData.JobChangeMaterials.TryGetValue(this.materials7_JobChangeMaterials.Value, out jobChangeMaterials))
          Debug.LogError((object) ("Key not Found: MasterData.JobChangeMaterials[" + (object) this.materials7_JobChangeMaterials.Value + "]"));
        return jobChangeMaterials;
      }
    }

    public JobChangePatterns GetEnablePatterns()
    {
      JobChangePatterns jobChangePatterns = new JobChangePatterns();
      jobChangePatterns.ID = this.ID;
      jobChangePatterns.unit_UnitUnit = this.unit_UnitUnit;
      jobChangePatterns.job_UnitJob = this.job_UnitJob;
      TimeZoneInfo timeZone = Japan.CreateTimeZone();
      DateTime dateTime = ServerTime.NowAppTimeAddDelta();
      UnitJob unitJob;
      if (!MasterData.UnitJob.TryGetValue(this.job1_UnitJob, out unitJob) || unitJob.start_at.HasValue && !(TimeZoneInfo.ConvertTime(unitJob.start_at.Value, timeZone, TimeZoneInfo.Local) <= dateTime))
        return (JobChangePatterns) null;
      jobChangePatterns.job1_UnitJob = this.job1_UnitJob;
      jobChangePatterns.materials1_JobChangeMaterials = this.materials1_JobChangeMaterials;
      if (!MasterData.UnitJob.TryGetValue(this.job2_UnitJob, out unitJob) || unitJob.start_at.HasValue && !(TimeZoneInfo.ConvertTime(unitJob.start_at.Value, timeZone, TimeZoneInfo.Local) <= dateTime))
        return (JobChangePatterns) null;
      jobChangePatterns.job2_UnitJob = this.job2_UnitJob;
      jobChangePatterns.materials2_JobChangeMaterials = this.materials2_JobChangeMaterials;
      if (this.job3_UnitJob.HasValue && MasterData.UnitJob.TryGetValue(this.job3_UnitJob.Value, out unitJob) && (!unitJob.start_at.HasValue || TimeZoneInfo.ConvertTime(unitJob.start_at.Value, timeZone, TimeZoneInfo.Local) <= dateTime))
      {
        jobChangePatterns.job3_UnitJob = this.job3_UnitJob;
        jobChangePatterns.materials3_JobChangeMaterials = this.materials3_JobChangeMaterials;
      }
      if (jobChangePatterns.job3_UnitJob.HasValue && this.job4_UnitJob.HasValue && MasterData.UnitJob.TryGetValue(this.job4_UnitJob.Value, out unitJob) && (!unitJob.start_at.HasValue || TimeZoneInfo.ConvertTime(unitJob.start_at.Value, timeZone, TimeZoneInfo.Local) <= dateTime))
      {
        jobChangePatterns.job4_UnitJob = this.job4_UnitJob;
        jobChangePatterns.materials4_JobChangeMaterials = this.materials4_JobChangeMaterials;
      }
      if (this.job5_UnitJob.HasValue && MasterData.UnitJob.TryGetValue(this.job5_UnitJob.Value, out unitJob) && (!unitJob.start_at.HasValue || TimeZoneInfo.ConvertTime(unitJob.start_at.Value, timeZone, TimeZoneInfo.Local) <= dateTime))
      {
        jobChangePatterns.job5_UnitJob = this.job5_UnitJob;
        jobChangePatterns.materials5_JobChangeMaterials = this.materials5_JobChangeMaterials;
      }
      if (jobChangePatterns.job3_UnitJob.HasValue && this.job6_UnitJob.HasValue && MasterData.UnitJob.TryGetValue(this.job6_UnitJob.Value, out unitJob) && (!unitJob.start_at.HasValue || TimeZoneInfo.ConvertTime(unitJob.start_at.Value, timeZone, TimeZoneInfo.Local) <= dateTime))
      {
        jobChangePatterns.job6_UnitJob = this.job6_UnitJob;
        jobChangePatterns.materials6_JobChangeMaterials = this.materials6_JobChangeMaterials;
      }
      if (jobChangePatterns.job4_UnitJob.HasValue && this.job7_UnitJob.HasValue && MasterData.UnitJob.TryGetValue(this.job7_UnitJob.Value, out unitJob) && (!unitJob.start_at.HasValue || TimeZoneInfo.ConvertTime(unitJob.start_at.Value, timeZone, TimeZoneInfo.Local) <= dateTime))
      {
        jobChangePatterns.job7_UnitJob = this.job7_UnitJob;
        jobChangePatterns.materials7_JobChangeMaterials = this.materials7_JobChangeMaterials;
      }
      return jobChangePatterns;
    }

    public UnitJob[] getJobs(int maxJobs = 4)
    {
      List<UnitJob> unitJobList = new List<UnitJob>(maxJobs)
      {
        this.job1,
        this.job2
      };
      for (int index = 2; index < maxJobs; ++index)
      {
        UnitJob unitJob;
        switch (index)
        {
          case 2:
            unitJob = this.job3;
            break;
          case 3:
            unitJob = this.job4;
            break;
          case 4:
            unitJob = this.job5;
            break;
          case 5:
            unitJob = this.job6;
            break;
          case 6:
            unitJob = this.job7;
            break;
          default:
            unitJob = (UnitJob) null;
            break;
        }
        if (unitJob != null)
          unitJobList.Add(unitJob);
        else
          break;
      }
      return unitJobList.ToArray();
    }
  }
}
