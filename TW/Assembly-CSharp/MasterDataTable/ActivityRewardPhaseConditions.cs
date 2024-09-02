// Decompiled with JetBrains decompiler
// Type: MasterDataTable.ActivityRewardPhaseConditions
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
