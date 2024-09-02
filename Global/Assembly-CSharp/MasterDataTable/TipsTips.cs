// Decompiled with JetBrains decompiler
// Type: MasterDataTable.TipsTips
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using I2.Loc;
using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class TipsTips
  {
    public int ID;
    private string _description;
    public int weight;

    public string description
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._description;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("tips_TipsTips_description_" + (object) this.ID, out Translation) ? Translation : this._description;
      }
      set => this._description = value;
    }

    public static TipsTips Parse(MasterDataReader reader)
    {
      return new TipsTips()
      {
        ID = reader.ReadInt(),
        description = reader.ReadString(true),
        weight = reader.ReadInt()
      };
    }
  }
}
