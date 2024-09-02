// Decompiled with JetBrains decompiler
// Type: MasterDataTable.MapEditFacilityShaderSetting
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System;

namespace MasterDataTable
{
  [Serializable]
  public class MapEditFacilityShaderSetting
  {
    public int ID;
    public int unit_UnitUnit;
    public string moving;
    public string installed;

    public static MapEditFacilityShaderSetting Parse(
      MasterDataReader reader)
    {
      return new MapEditFacilityShaderSetting()
      {
        ID = reader.ReadInt(),
        unit_UnitUnit = reader.ReadInt(),
        moving = reader.ReadStringOrNull(true),
        installed = reader.ReadStringOrNull(true)
      };
    }

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

    public bool hasMovingMaterial => !string.IsNullOrEmpty(this.moving);

    public Future<UnityEngine.Material> LoadMovingMaterial() => MapEditFacilityShaderSetting.LoadMaterial(this.moving);

    public bool hasInstalledMaterial => !string.IsNullOrEmpty(this.installed);

    public Future<UnityEngine.Material> LoadInstalledMaterial() => MapEditFacilityShaderSetting.LoadMaterial(this.installed);

    public static Future<UnityEngine.Material> LoadMaterial(string materialName)
    {
      if (string.IsNullOrEmpty(materialName))
        return Future.Single<UnityEngine.Material>((UnityEngine.Material) null);
      string path = string.Format("Units/SharedFacility/{0}", (object) materialName);
      return Singleton<ResourceManager>.GetInstance().Load<UnityEngine.Material>(path);
    }
  }
}
