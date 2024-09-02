// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleMap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System;
using UnityEngine;

namespace MasterDataTable
{
  [Serializable]
  public class BattleMap
  {
    public int ID;
    public string name;
    public float duel_ambient_color_r;
    public float duel_ambient_color_g;
    public float duel_ambient_color_b;
    public float duel_directional_light_rotation_x;
    public float duel_directional_light_rotation_y;
    public float duel_directional_light_rotation_z;
    public float duel_directional_light_color_r;
    public float duel_directional_light_color_g;
    public float duel_directional_light_color_b;
    public float duel_directional_light_intensity;
    public string field_prefab;
    public float field_ambient_color_r;
    public float field_ambient_color_g;
    public float field_ambient_color_b;

    public static BattleMap Parse(MasterDataReader reader) => new BattleMap()
    {
      ID = reader.ReadInt(),
      name = reader.ReadString(true),
      duel_ambient_color_r = reader.ReadFloat(),
      duel_ambient_color_g = reader.ReadFloat(),
      duel_ambient_color_b = reader.ReadFloat(),
      duel_directional_light_rotation_x = reader.ReadFloat(),
      duel_directional_light_rotation_y = reader.ReadFloat(),
      duel_directional_light_rotation_z = reader.ReadFloat(),
      duel_directional_light_color_r = reader.ReadFloat(),
      duel_directional_light_color_g = reader.ReadFloat(),
      duel_directional_light_color_b = reader.ReadFloat(),
      duel_directional_light_intensity = reader.ReadFloat(),
      field_prefab = reader.ReadString(true),
      field_ambient_color_r = reader.ReadFloat(),
      field_ambient_color_g = reader.ReadFloat(),
      field_ambient_color_b = reader.ReadFloat()
    };

    public Future<GameObject> LoadFieldMap() => Singleton<ResourceManager>.GetInstance().Load<GameObject>(string.Format("BattleMaps/{0}/3D/field/prefab", (object) this.ID));

    public Future<GameObject> LoadDuelMap() => Singleton<ResourceManager>.GetInstance().Load<GameObject>(string.Format("BattleMaps/{0}/3D/duel/prefab", (object) this.ID));

    public Future<Texture2D> LoadFieldFarLightmap() => Singleton<ResourceManager>.GetInstance().LoadOrNull<Texture2D>(string.Format("BattleMaps/{0}/3D/field/lightmap-far", (object) this.ID));

    public Future<Texture2D> LoadDuelFarLightmap() => Singleton<ResourceManager>.GetInstance().LoadOrNull<Texture2D>(string.Format("BattleMaps/{0}/3D/duel/lightmap-far", (object) this.ID));

    public Future<GameObject> LoadFieldRoot() => Singleton<ResourceManager>.GetInstance().Load<GameObject>(string.Format("BattleMaps/{0}", (object) this.field_prefab));

    public Color getDuelAmbientColor() => new Color(this.duel_ambient_color_r, this.duel_ambient_color_g, this.duel_ambient_color_b, 1f);

    public Quaternion getDuelDirectionalLightRotate() => Quaternion.Euler(this.duel_directional_light_rotation_x, this.duel_directional_light_rotation_y, this.duel_directional_light_rotation_z);

    public Color getDuelDirectionalLightColor() => new Color(this.duel_directional_light_color_r, this.duel_directional_light_color_g, this.duel_directional_light_color_b, 1f);
  }
}
