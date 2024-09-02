// Decompiled with JetBrains decompiler
// Type: SM.GvgCandidate
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

namespace SM
{
  [Serializable]
  public class GvgCandidate : KeyCompare
  {
    public PlayerUnit player_unit;
    public string player_name;
    public int player_level;
    public string using_player_id;
    public string player_id;
    public PlayerItem[] player_gears;
    public PlayerAwakeSkill[] player_awake_skills;
    public int player_emblem_id;
    public PlayerGearReisouSchema[] player_reisou_gears;

    public GvgCandidate()
    {
    }

    public GvgCandidate(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.player_unit = json[nameof (player_unit)] == null ? (PlayerUnit) null : new PlayerUnit((Dictionary<string, object>) json[nameof (player_unit)]);
      this.player_name = (string) json[nameof (player_name)];
      this.player_level = (int) (long) json[nameof (player_level)];
      this.using_player_id = json[nameof (using_player_id)] == null ? (string) null : (string) json[nameof (using_player_id)];
      this.player_id = (string) json[nameof (player_id)];
      List<PlayerItem> playerItemList = new List<PlayerItem>();
      foreach (object obj in (List<object>) json[nameof (player_gears)])
        playerItemList.Add(obj == null ? (PlayerItem) null : new PlayerItem((Dictionary<string, object>) obj));
      this.player_gears = playerItemList.ToArray();
      List<PlayerAwakeSkill> playerAwakeSkillList = new List<PlayerAwakeSkill>();
      foreach (object obj in (List<object>) json[nameof (player_awake_skills)])
        playerAwakeSkillList.Add(obj == null ? (PlayerAwakeSkill) null : new PlayerAwakeSkill((Dictionary<string, object>) obj));
      this.player_awake_skills = playerAwakeSkillList.ToArray();
      this.player_emblem_id = (int) (long) json[nameof (player_emblem_id)];
      List<PlayerGearReisouSchema> gearReisouSchemaList = new List<PlayerGearReisouSchema>();
      foreach (object obj in (List<object>) json[nameof (player_reisou_gears)])
        gearReisouSchemaList.Add(obj == null ? (PlayerGearReisouSchema) null : new PlayerGearReisouSchema((Dictionary<string, object>) obj));
      this.player_reisou_gears = gearReisouSchemaList.ToArray();
    }
  }
}
