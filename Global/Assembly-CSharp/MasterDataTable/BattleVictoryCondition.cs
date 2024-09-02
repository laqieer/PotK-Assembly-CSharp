// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleVictoryCondition
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using I2.Loc;
using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class BattleVictoryCondition
  {
    public int ID;
    private string _name;
    private string _sub_name;
    public int? enemy_BattleStageEnemy;
    public int? turn;
    public int? elapsed_turn;
    public int? win_area_confition_group_id;
    public int? lose_area_confition_group_id;
    private string _lose_on_unit_dead;
    private string _lose_on_gesut_dead;
    public int gameover_type_guest;
    public string victory_text;
    public string lose_text;

    public string name
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._name;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("battle_BattleVictoryCondition_name_" + (object) this.ID, out Translation) ? Translation : this._name;
      }
      set => this._name = value;
    }

    public string sub_name
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._sub_name;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("battle_BattleVictoryCondition_sub_name_" + (object) this.ID, out Translation) ? Translation : this._sub_name;
      }
      set => this._sub_name = value;
    }

    public string lose_on_unit_dead
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._lose_on_unit_dead;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("battle_BattleVictoryCondition_lose_on_unit_dead_" + (object) this.ID, out Translation) ? Translation : this._lose_on_unit_dead;
      }
      set => this._lose_on_unit_dead = value;
    }

    public string lose_on_gesut_dead
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._lose_on_gesut_dead;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("battle_BattleVictoryCondition_lose_on_gesut_dead_" + (object) this.ID, out Translation) ? Translation : this._lose_on_gesut_dead;
      }
      set => this._lose_on_gesut_dead = value;
    }

    public static BattleVictoryCondition Parse(MasterDataReader reader)
    {
      return new BattleVictoryCondition()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        sub_name = reader.ReadString(true),
        enemy_BattleStageEnemy = reader.ReadIntOrNull(),
        turn = reader.ReadIntOrNull(),
        elapsed_turn = reader.ReadIntOrNull(),
        win_area_confition_group_id = reader.ReadIntOrNull(),
        lose_area_confition_group_id = reader.ReadIntOrNull(),
        lose_on_unit_dead = reader.ReadStringOrNull(true),
        lose_on_gesut_dead = reader.ReadStringOrNull(true),
        gameover_type_guest = reader.ReadInt(),
        victory_text = reader.ReadString(true),
        lose_text = reader.ReadString(true)
      };
    }

    public BattleStageEnemy enemy
    {
      get
      {
        if (!this.enemy_BattleStageEnemy.HasValue)
          return (BattleStageEnemy) null;
        BattleStageEnemy enemy;
        if (!MasterData.BattleStageEnemy.TryGetValue(this.enemy_BattleStageEnemy.Value, out enemy))
          Debug.LogError((object) ("Key not Found: MasterData.BattleStageEnemy[" + (object) this.enemy_BattleStageEnemy.Value + "]"));
        return enemy;
      }
    }
  }
}
