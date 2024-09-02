// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BingoPanel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using I2.Loc;
using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class BingoPanel
  {
    public int ID;
    public int bingo_id;
    public int panel_id;
    private string _name;
    private string _detail;
    public string scene_name;
    public int init_count;
    public int clear_count;
    public int reward_group_id;

    public string name
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._name;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("bingo_BingoPanel_name_" + (object) this.ID, out Translation) ? Translation : this._name;
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
        return LocalizationManager.TryGetTermTranslation("bingo_BingoPanel_detail_" + (object) this.ID, out Translation) ? Translation : this._detail;
      }
      set => this._detail = value;
    }

    public static BingoPanel Parse(MasterDataReader reader)
    {
      return new BingoPanel()
      {
        ID = reader.ReadInt(),
        bingo_id = reader.ReadInt(),
        panel_id = reader.ReadInt(),
        name = reader.ReadString(true),
        detail = reader.ReadString(true),
        scene_name = reader.ReadString(true),
        init_count = reader.ReadInt(),
        clear_count = reader.ReadInt(),
        reward_group_id = reader.ReadInt()
      };
    }
  }
}
