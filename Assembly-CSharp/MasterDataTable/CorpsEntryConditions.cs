// Decompiled with JetBrains decompiler
// Type: MasterDataTable.CorpsEntryConditions
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class CorpsEntryConditions
  {
    public int ID;
    public int setting_CorpsSetting;
    public int value;
    public string text;

    public static CorpsEntryConditions Parse(MasterDataReader reader) => new CorpsEntryConditions()
    {
      ID = reader.ReadInt(),
      setting_CorpsSetting = reader.ReadInt(),
      value = reader.ReadInt(),
      text = reader.ReadString(true)
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
