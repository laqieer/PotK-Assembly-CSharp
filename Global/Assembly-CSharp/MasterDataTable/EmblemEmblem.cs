// Decompiled with JetBrains decompiler
// Type: MasterDataTable.EmblemEmblem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using I2.Loc;
using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class EmblemEmblem
  {
    public int ID;
    private string _name;
    private string _description;
    public int rarity_EmblemRarity;

    public string name
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._name;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("emblem_EmblemEmblem_name_" + (object) this.ID, out Translation) ? Translation : this._name;
      }
      set => this._name = value;
    }

    public string description
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._description;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("emblem_EmblemEmblem_description_" + (object) this.ID, out Translation) ? Translation : this._description;
      }
      set => this._description = value;
    }

    public static EmblemEmblem Parse(MasterDataReader reader)
    {
      return new EmblemEmblem()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        description = reader.ReadString(true),
        rarity_EmblemRarity = reader.ReadInt()
      };
    }

    public EmblemRarity rarity
    {
      get
      {
        EmblemRarity rarity;
        if (!MasterData.EmblemRarity.TryGetValue(this.rarity_EmblemRarity, out rarity))
          Debug.LogError((object) ("Key not Found: MasterData.EmblemRarity[" + (object) this.rarity_EmblemRarity + "]"));
        return rarity;
      }
    }
  }
}
