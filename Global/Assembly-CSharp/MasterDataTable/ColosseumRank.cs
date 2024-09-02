// Decompiled with JetBrains decompiler
// Type: MasterDataTable.ColosseumRank
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using I2.Loc;
using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class ColosseumRank
  {
    public int ID;
    private string _name;
    public int to_point;

    public string name
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._name;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("colosseum_ColosseumRank_name_" + (object) this.ID, out Translation) ? Translation : this._name;
      }
      set => this._name = value;
    }

    public static ColosseumRank Parse(MasterDataReader reader)
    {
      return new ColosseumRank()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        to_point = reader.ReadInt()
      };
    }
  }
}
