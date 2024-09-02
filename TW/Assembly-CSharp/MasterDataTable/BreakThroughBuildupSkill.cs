// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BreakThroughBuildupSkill
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class BreakThroughBuildupSkill
  {
    public int ID;
    public int skill_id;

    public static BreakThroughBuildupSkill Parse(MasterDataReader reader)
    {
      return new BreakThroughBuildupSkill()
      {
        ID = reader.ReadInt(),
        skill_id = reader.ReadInt()
      };
    }
  }
}
