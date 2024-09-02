// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GearDisappearanceType
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using I2.Loc;
using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class GearDisappearanceType
  {
    public int ID;
    private string _name;
    private string _discription;

    public string name
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._name;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("gear_GearDisappearanceType_name_" + (object) this.ID, out Translation) ? Translation : this._name;
      }
      set => this._name = value;
    }

    public string discription
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._discription;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("gear_GearDisappearanceType_discription_" + (object) this.ID, out Translation) ? Translation : this._discription;
      }
      set => this._discription = value;
    }

    public static GearDisappearanceType Parse(MasterDataReader reader)
    {
      return new GearDisappearanceType()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        discription = reader.ReadString(true)
      };
    }
  }
}
