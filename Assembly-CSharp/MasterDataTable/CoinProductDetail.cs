// Decompiled with JetBrains decompiler
// Type: MasterDataTable.CoinProductDetail
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class CoinProductDetail
  {
    public int ID;
    public int group_no;
    public string detail;
    public string image_url;
    public int? image_width;
    public int? image_height;

    public static CoinProductDetail Parse(MasterDataReader reader) => new CoinProductDetail()
    {
      ID = reader.ReadInt(),
      group_no = reader.ReadInt(),
      detail = reader.ReadStringOrNull(true),
      image_url = reader.ReadStringOrNull(true),
      image_width = reader.ReadIntOrNull(),
      image_height = reader.ReadIntOrNull()
    };
  }
}
