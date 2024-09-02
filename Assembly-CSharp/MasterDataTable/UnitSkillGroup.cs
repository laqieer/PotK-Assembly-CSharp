// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitSkillGroup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class UnitSkillGroup
  {
    public int ID;
    public int unit_UnitUnit;
    public int skill_groupID;

    public static UnitSkillGroup Parse(MasterDataReader reader) => new UnitSkillGroup()
    {
      ID = reader.ReadInt(),
      unit_UnitUnit = reader.ReadInt(),
      skill_groupID = reader.ReadInt()
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
  }
}
