// Decompiled with JetBrains decompiler
// Type: MasterDataTable.Bingo2Panel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using I2.Loc;
using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class Bingo2Panel
  {
    public int ID;
    private string _name;
    private string _detail;
    public string scene_name;
    public int reward_group_id;
    public int count;

    public string name
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._name;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("bingo2_Bingo2Panel_name_" + (object) this.ID, out Translation) ? Translation : this._name;
      }
      set => this._name = value;
    }

    public string detail
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._detail;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("bingo2_Bingo2Panel_detail_" + (object) this.ID, out Translation) ? Translation : this._detail;
      }
      set => this._detail = value;
    }

    public static Bingo2Panel Parse(MasterDataReader reader)
    {
      return new Bingo2Panel()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        detail = reader.ReadString(true),
        scene_name = reader.ReadString(true),
        reward_group_id = reader.ReadInt(),
        count = reader.ReadInt()
      };
    }
  }
}
