// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GuildImagePattern
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections.Generic;

namespace MasterDataTable
{
  [Serializable]
  public class GuildImagePattern
  {
    public int ID;
    public int base_type_GuildBaseType;
    public int level;
    public int grade;
    public int base_pos_GuildBasePos;
    public int base_animation_id;

    public static GuildImagePattern Parse(MasterDataReader reader) => new GuildImagePattern()
    {
      ID = reader.ReadInt(),
      base_type_GuildBaseType = reader.ReadInt(),
      level = reader.ReadInt(),
      grade = reader.ReadInt(),
      base_pos_GuildBasePos = reader.ReadInt(),
      base_animation_id = reader.ReadInt()
    };

    public GuildBaseType base_type => (GuildBaseType) this.base_type_GuildBaseType;

    public GuildBasePos base_pos
    {
      get
      {
        GuildBasePos guildBasePos;
        if (!MasterData.GuildBasePos.TryGetValue(this.base_pos_GuildBasePos, out guildBasePos))
          Debug.LogError((object) ("Key not Found: MasterData.GuildBasePos[" + (object) this.base_pos_GuildBasePos + "]"));
        return guildBasePos;
      }
    }

    public static GuildImagePattern Find(GuildBaseType type, int level)
    {
      int? nullable = ((IEnumerable<GuildImagePattern>) MasterData.GuildImagePatternList).FirstIndexOrNull<GuildImagePattern>((Func<GuildImagePattern, bool>) (x => (GuildBaseType) x.base_type_GuildBaseType == type && x.level == level));
      return nullable.HasValue ? MasterData.GuildImagePatternList[nullable.Value] : (GuildImagePattern) null;
    }

    public string TownSpriteName() => string.Format("slc_memberbase_grade_{0}.png__GUI__guild_map__guild_map_prefab", (object) string.Format("{0:D2}", (object) this.grade));

    public Future<UnityEngine.Sprite> LoadSpriteFacility(GuildBaseType type)
    {
      switch (type)
      {
        case GuildBaseType.walls:
          return this.LoadSpriteWalls();
        case GuildBaseType.tower:
          return this.LoadSpriteTower();
        case GuildBaseType.scaffold:
          return this.LoadSpriteScaffold();
        case GuildBaseType.fortress:
          return this.LoadSpriteFortress();
        default:
          return (Future<UnityEngine.Sprite>) null;
      }
    }

    public Future<UnityEngine.Sprite> LoadSpriteFortress() => Singleton<ResourceManager>.GetInstance().Load<UnityEngine.Sprite>(string.Format("AssetBundle/Resources/GuildFacility/guild_fortress/slc_guildbase_fortress_grade_{0}", (object) string.Format("{0:D2}", (object) this.grade)));

    public Future<UnityEngine.Sprite> LoadSpriteWalls() => Singleton<ResourceManager>.GetInstance().Load<UnityEngine.Sprite>(string.Format("AssetBundle/Resources/GuildFacility/guild_wall/slc_guildbase_wall_grade_{0}", (object) string.Format("{0:D2}", (object) this.grade)));

    public Future<UnityEngine.Sprite> LoadSpriteTower() => Singleton<ResourceManager>.GetInstance().Load<UnityEngine.Sprite>(string.Format("AssetBundle/Resources/GuildFacility/guild_l_tower/slc_guildbase_l_tower_grade_{0}", (object) string.Format("{0:D2}", (object) this.grade)));

    public Future<UnityEngine.Sprite> LoadSpriteScaffold() => Singleton<ResourceManager>.GetInstance().Load<UnityEngine.Sprite>(string.Format("AssetBundle/Resources/GuildFacility/guild_s_tower/slc_guildbase_s_tower_grade_{0}", (object) string.Format("{0:D2}", (object) this.grade)));
  }
}
