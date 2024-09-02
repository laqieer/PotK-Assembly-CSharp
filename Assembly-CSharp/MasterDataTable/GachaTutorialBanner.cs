// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GachaTutorialBanner
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class GachaTutorialBanner
  {
    public int ID;
    public DateTime? start_at;
    public DateTime? end_at;
    public string title_image_url;
    public string front_image_url;

    public static GachaTutorialBanner Parse(MasterDataReader reader) => new GachaTutorialBanner()
    {
      ID = reader.ReadInt(),
      start_at = reader.ReadDateTimeOrNull(),
      end_at = reader.ReadDateTimeOrNull(),
      title_image_url = reader.ReadStringOrNull(true),
      front_image_url = reader.ReadStringOrNull(true)
    };
  }
}
