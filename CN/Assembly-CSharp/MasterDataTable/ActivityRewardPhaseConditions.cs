// Decompiled with JetBrains decompiler
// Type: MasterDataTable.ActivityRewardPhaseConditions
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class ActivityRewardPhaseConditions
  {
    public int ID;
    public int step_id;
    public int condition_id;

    public static ActivityRewardPhaseConditions Parse(MasterDataReader reader)
    {
      return new ActivityRewardPhaseConditions()
      {
        ID = reader.ReadInt(),
        step_id = reader.ReadInt(),
        condition_id = reader.ReadInt()
      };
    }
  }
}
