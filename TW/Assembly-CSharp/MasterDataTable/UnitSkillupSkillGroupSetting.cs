// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitSkillupSkillGroupSetting
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class UnitSkillupSkillGroupSetting
  {
    public int ID;
    public int group_id;
    public int skill_id;

    public static UnitSkillupSkillGroupSetting Parse(MasterDataReader reader)
    {
      return new UnitSkillupSkillGroupSetting()
      {
        ID = reader.ReadInt(),
        group_id = reader.ReadInt(),
        skill_id = reader.ReadInt()
      };
    }
  }
}
