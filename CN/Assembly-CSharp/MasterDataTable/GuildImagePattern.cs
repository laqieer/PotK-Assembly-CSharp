// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GuildImagePattern
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class GuildImagePattern
  {
    public int ID;
    public int base_type_GuildBaseType;
    public int level;
    public int grade;
    public float baseXpos;
    public float baseYpos;
    public string anim1PrefixSprite;
    public int anim1frame;
    public float anim1Xpos;
    public float anim1Ypos;
    public string anim2PrefixSprite;
    public int anim2frame;
    public float anim2Xpos;
    public float anim2Ypos;
    public string anim3PrefixSprite;
    public int anim3frame;
    public float anim3Xpos;
    public float anim3Ypos;
    public string anim4PrefixSprite;
    public int anim4frame;
    public float anim4Xpos;
    public float anim4Ypos;

    public static GuildImagePattern Parse(MasterDataReader reader)
    {
      return new GuildImagePattern()
      {
        ID = reader.ReadInt(),
        base_type_GuildBaseType = reader.ReadInt(),
        level = reader.ReadInt(),
        grade = reader.ReadInt(),
        baseXpos = reader.ReadFloat(),
        baseYpos = reader.ReadFloat(),
        anim1PrefixSprite = reader.ReadString(true),
        anim1frame = reader.ReadInt(),
        anim1Xpos = reader.ReadFloat(),
        anim1Ypos = reader.ReadFloat(),
        anim2PrefixSprite = reader.ReadString(true),
        anim2frame = reader.ReadInt(),
        anim2Xpos = reader.ReadFloat(),
        anim2Ypos = reader.ReadFloat(),
        anim3PrefixSprite = reader.ReadString(true),
        anim3frame = reader.ReadInt(),
        anim3Xpos = reader.ReadFloat(),
        anim3Ypos = reader.ReadFloat(),
        anim4PrefixSprite = reader.ReadString(true),
        anim4frame = reader.ReadInt(),
        anim4Xpos = reader.ReadFloat(),
        anim4Ypos = reader.ReadFloat()
      };
    }

    public GuildBaseType base_type => (GuildBaseType) this.base_type_GuildBaseType;

    public static GuildImagePattern Find(GuildBaseType type, int level)
    {
      int? nullable = ((IEnumerable<GuildImagePattern>) MasterData.GuildImagePatternList).FirstIndexOrNull<GuildImagePattern>((Func<GuildImagePattern, bool>) (x => (GuildBaseType) x.base_type_GuildBaseType == type && x.level == level));
      return nullable.HasValue ? MasterData.GuildImagePatternList[nullable.Value] : (GuildImagePattern) null;
    }

    public string TownSpriteName()
    {
      return string.Format("slc_memberbase_grade_{0}.png__GUI__guild_map__guild_map_prefab", (object) string.Format("{0:D2}", (object) this.grade));
    }

    public Future<Sprite> LoadSpriteFacility(GuildBaseType type)
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
          Debug.LogError((object) "画像がない");
          return (Future<Sprite>) null;
      }
    }

    public Future<Sprite> LoadSpriteFortress()
    {
      return Singleton<ResourceManager>.GetInstance().Load<Sprite>(string.Format("AssetBundle/Resources/GuildFacility/guild_fortress/slc_guildbase_fortress_grade_{0}", (object) string.Format("{0:D2}", (object) this.grade)));
    }

    public Future<Sprite> LoadSpriteWalls()
    {
      return Singleton<ResourceManager>.GetInstance().Load<Sprite>(string.Format("AssetBundle/Resources/GuildFacility/guild_wall/slc_guildbase_wall_grade_{0}", (object) string.Format("{0:D2}", (object) this.grade)));
    }

    public Future<Sprite> LoadSpriteTower()
    {
      return Singleton<ResourceManager>.GetInstance().Load<Sprite>(string.Format("AssetBundle/Resources/GuildFacility/guild_l_tower/slc_guildbase_l_tower_grade_{0}", (object) string.Format("{0:D2}", (object) this.grade)));
    }

    public Future<Sprite> LoadSpriteScaffold()
    {
      return Singleton<ResourceManager>.GetInstance().Load<Sprite>(string.Format("AssetBundle/Resources/GuildFacility/guild_s_tower/slc_guildbase_s_tower_grade_{0}", (object) string.Format("{0:D2}", (object) this.grade)));
    }
  }
}
