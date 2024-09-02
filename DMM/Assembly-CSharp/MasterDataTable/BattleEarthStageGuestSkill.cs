// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleEarthStageGuestSkill
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class BattleEarthStageGuestSkill
  {
    public int ID;
    public int skill_group_id;
    public int skill_BattleskillSkill;
    public int skill_level;

    public static BattleEarthStageGuestSkill Parse(MasterDataReader reader) => new BattleEarthStageGuestSkill()
    {
      ID = reader.ReadInt(),
      skill_group_id = reader.ReadInt(),
      skill_BattleskillSkill = reader.ReadInt(),
      skill_level = reader.ReadInt()
    };

    public BattleskillSkill skill
    {
      get
      {
        BattleskillSkill battleskillSkill;
        if (!MasterData.BattleskillSkill.TryGetValue(this.skill_BattleskillSkill, out battleskillSkill))
          Debug.LogError((object) ("Key not Found: MasterData.BattleskillSkill[" + (object) this.skill_BattleskillSkill + "]"));
        return battleskillSkill;
      }
    }
  }
}
