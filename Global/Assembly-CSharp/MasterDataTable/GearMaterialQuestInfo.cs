// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GearMaterialQuestInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using I2.Loc;
using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class GearMaterialQuestInfo
  {
    public int ID;
    public int gear_id;
    private string _detail_desc1;
    private string _detail_desc2;
    private string _detail_desc3;

    public string detail_desc1
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._detail_desc1;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("gear_GearMaterialQuestInfo_detail_desc1_" + (object) this.ID, out Translation) ? Translation : this._detail_desc1;
      }
      set => this._detail_desc1 = value;
    }

    public string detail_desc2
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._detail_desc2;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("gear_GearMaterialQuestInfo_detail_desc2_" + (object) this.ID, out Translation) ? Translation : this._detail_desc2;
      }
      set => this._detail_desc2 = value;
    }

    public string detail_desc3
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._detail_desc3;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("gear_GearMaterialQuestInfo_detail_desc3_" + (object) this.ID, out Translation) ? Translation : this._detail_desc3;
      }
      set => this._detail_desc3 = value;
    }

    public static GearMaterialQuestInfo Parse(MasterDataReader reader)
    {
      return new GearMaterialQuestInfo()
      {
        ID = reader.ReadInt(),
        gear_id = reader.ReadInt(),
        detail_desc1 = reader.ReadString(true),
        detail_desc2 = reader.ReadString(true),
        detail_desc3 = reader.ReadString(true)
      };
    }
  }
}
