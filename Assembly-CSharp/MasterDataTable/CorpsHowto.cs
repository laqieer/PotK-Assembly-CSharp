// Decompiled with JetBrains decompiler
// Type: MasterDataTable.CorpsHowto
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class CorpsHowto
  {
    public int ID;
    public int setting_CorpsSetting;
    public int kind;
    public string body;
    public string image_url;
    public int? image_width;
    public int? image_height;

    public static CorpsHowto Parse(MasterDataReader reader) => new CorpsHowto()
    {
      ID = reader.ReadInt(),
      setting_CorpsSetting = reader.ReadInt(),
      kind = reader.ReadInt(),
      body = reader.ReadStringOrNull(true),
      image_url = reader.ReadStringOrNull(true),
      image_width = reader.ReadIntOrNull(),
      image_height = reader.ReadIntOrNull()
    };

    public CorpsSetting setting
    {
      get
      {
        CorpsSetting corpsSetting;
        if (!MasterData.CorpsSetting.TryGetValue(this.setting_CorpsSetting, out corpsSetting))
          Debug.LogError((object) ("Key not Found: MasterData.CorpsSetting[" + (object) this.setting_CorpsSetting + "]"));
        return corpsSetting;
      }
    }
  }
}
