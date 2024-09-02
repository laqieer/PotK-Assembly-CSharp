// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitJobFamily
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class UnitJobFamily
  {
    public int ID;
    public int job_UnitJob;
    public int element_UnitFamily;

    public static UnitJobFamily Parse(MasterDataReader reader) => new UnitJobFamily()
    {
      ID = reader.ReadInt(),
      job_UnitJob = reader.ReadInt(),
      element_UnitFamily = reader.ReadInt()
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

    public UnitFamily element => (UnitFamily) this.element_UnitFamily;
  }
}
