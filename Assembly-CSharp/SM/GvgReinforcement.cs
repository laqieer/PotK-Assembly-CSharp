// Decompiled with JetBrains decompiler
// Type: SM.GvgReinforcement
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

namespace SM
{
  [Serializable]
  public class GvgReinforcement : KeyCompare
  {
    public PlayerUnit player_unit;
    public PlayerGearReisouSchema[] player_reisou_gears;
    public PlayerUnit[] over_killers;
    public PlayerItem[] player_gears;
    public PlayerAwakeSkill[] player_awake_skills;

    public GvgReinforcement()
    {
    }

    public GvgReinforcement(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.player_unit = json[nameof (player_unit)] == null ? (PlayerUnit) null : new PlayerUnit((Dictionary<string, object>) json[nameof (player_unit)]);
      List<PlayerGearReisouSchema> gearReisouSchemaList = new List<PlayerGearReisouSchema>();
      foreach (object obj in (List<object>) json[nameof (player_reisou_gears)])
        gearReisouSchemaList.Add(obj == null ? (PlayerGearReisouSchema) null : new PlayerGearReisouSchema((Dictionary<string, object>) obj));
      this.player_reisou_gears = gearReisouSchemaList.ToArray();
      List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
      foreach (object obj in (List<object>) json[nameof (over_killers)])
        playerUnitList.Add(obj == null ? (PlayerUnit) null : new PlayerUnit((Dictionary<string, object>) obj));
      this.over_killers = playerUnitList.ToArray();
      List<PlayerItem> playerItemList = new List<PlayerItem>();
      foreach (object obj in (List<object>) json[nameof (player_gears)])
        playerItemList.Add(obj == null ? (PlayerItem) null : new PlayerItem((Dictionary<string, object>) obj));
      this.player_gears = playerItemList.ToArray();
      List<PlayerAwakeSkill> playerAwakeSkillList = new List<PlayerAwakeSkill>();
      foreach (object obj in (List<object>) json[nameof (player_awake_skills)])
        playerAwakeSkillList.Add(obj == null ? (PlayerAwakeSkill) null : new PlayerAwakeSkill((Dictionary<string, object>) obj));
      this.player_awake_skills = playerAwakeSkillList.ToArray();
    }
  }
}
