// Decompiled with JetBrains decompiler
// Type: MasterDataTable.TipsTips
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class TipsTips
  {
    public int ID;
    public string description;
    public int weight;

    public static TipsTips Parse(MasterDataReader reader) => new TipsTips()
    {
      ID = reader.ReadInt(),
      description = reader.ReadString(true),
      weight = reader.ReadInt()
    };
  }
}
