// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitMaterialQuestInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using I2.Loc;
using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class UnitMaterialQuestInfo
  {
    public int ID;
    public int unit_id;
    private string _short_desc;
    private string _long_desc;

    public string short_desc
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._short_desc;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("unit_UnitMaterialQuestInfo_short_desc_" + (object) this.ID, out Translation) ? Translation : this._short_desc;
      }
      set => this._short_desc = value;
    }

    public string long_desc
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._long_desc;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("unit_UnitMaterialQuestInfo_long_desc_" + (object) this.ID, out Translation) ? Translation : this._long_desc;
      }
      set => this._long_desc = value;
    }

    public static UnitMaterialQuestInfo Parse(MasterDataReader reader)
    {
      return new UnitMaterialQuestInfo()
      {
        ID = reader.ReadInt(),
        unit_id = reader.ReadInt(),
        short_desc = reader.ReadString(true),
        long_desc = reader.ReadString(true)
      };
    }
  }
}
