// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BingoBingo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using I2.Loc;
using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class BingoBingo
  {
    public int ID;
    private string _name;
    private string _message;
    public int cleared_bingo_id;
    public string complete_reward_group_ids;

    public string name
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._name;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("bingo_BingoBingo_name_" + (object) this.ID, out Translation) ? Translation : this._name;
      }
      set => this._name = value;
    }

    public string message
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._message;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("bingo_BingoBingo_message_" + (object) this.ID, out Translation) ? Translation : this._message;
      }
      set => this._message = value;
    }

    public static BingoBingo Parse(MasterDataReader reader)
    {
      return new BingoBingo()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        message = reader.ReadString(true),
        cleared_bingo_id = reader.ReadInt(),
        complete_reward_group_ids = reader.ReadString(true)
      };
    }
  }
}
