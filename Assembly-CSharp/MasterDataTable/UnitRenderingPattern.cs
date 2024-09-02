// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitRenderingPattern
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class UnitRenderingPattern
  {
    public int ID;
    public int? camera_pattern_UnitCameraPattern;
    public float texture_x;
    public float texture_y;

    public static UnitRenderingPattern Parse(MasterDataReader reader) => new UnitRenderingPattern()
    {
      ID = reader.ReadInt(),
      camera_pattern_UnitCameraPattern = reader.ReadIntOrNull(),
      texture_x = reader.ReadFloat(),
      texture_y = reader.ReadFloat()
    };

    public UnitCameraPattern camera_pattern
    {
      get
      {
        if (!this.camera_pattern_UnitCameraPattern.HasValue)
          return (UnitCameraPattern) null;
        UnitCameraPattern unitCameraPattern;
        if (!MasterData.UnitCameraPattern.TryGetValue(this.camera_pattern_UnitCameraPattern.Value, out unitCameraPattern))
          Debug.LogError((object) ("Key not Found: MasterData.UnitCameraPattern[" + (object) this.camera_pattern_UnitCameraPattern.Value + "]"));
        return unitCameraPattern;
      }
    }
  }
}
