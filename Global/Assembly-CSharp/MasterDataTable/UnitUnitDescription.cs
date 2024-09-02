// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitUnitDescription
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using I2.Loc;
using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class UnitUnitDescription
  {
    public int ID;
    private string _description;
    private string _cv_name;
    private string _illustrator_name;

    public string description
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._description;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("unit_UnitUnitDescription_description_" + (object) this.ID, out Translation) ? Translation : this._description;
      }
      set => this._description = value;
    }

    public string cv_name
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._cv_name;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("unit_UnitUnitDescription_cv_name_" + (object) this.ID, out Translation) ? Translation : this._cv_name;
      }
      set => this._cv_name = value;
    }

    public string illustrator_name
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._illustrator_name;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("unit_UnitUnitDescription_illustrator_name_" + (object) this.ID, out Translation) ? Translation : this._illustrator_name;
      }
      set => this._illustrator_name = value;
    }

    public static UnitUnitDescription Parse(MasterDataReader reader)
    {
      return new UnitUnitDescription()
      {
        ID = reader.ReadInt(),
        description = reader.ReadString(true),
        cv_name = reader.ReadString(true),
        illustrator_name = reader.ReadString(true)
      };
    }
  }
}
