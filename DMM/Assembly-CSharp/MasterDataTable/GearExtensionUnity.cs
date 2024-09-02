// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GearExtensionUnity
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class GearExtensionUnity
  {
    public int ID;
    public int true_unity_value;
    public int total_unity_value;

    public static GearExtensionUnity Parse(MasterDataReader reader) => new GearExtensionUnity()
    {
      ID = reader.ReadInt(),
      true_unity_value = reader.ReadInt(),
      total_unity_value = reader.ReadInt()
    };
  }
}
