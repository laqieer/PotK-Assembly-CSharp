// Decompiled with JetBrains decompiler
// Type: MasterDataTable.SlotS001MedalDeck
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using I2.Loc;
using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class SlotS001MedalDeck
  {
    public int ID;
    private string _name;
    public int result_icon;
    private string _description;
    public int prize_first;
    public int prize_second;
    public int prize_third;

    public string name
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._name;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("slot.s001_medal.slot_SlotS001MedalDeck_name_" + (object) this.ID, out Translation) ? Translation : this._name;
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
        return LocalizationManager.TryGetTermTranslation("slot.s001_medal.slot_SlotS001MedalDeck_description_" + (object) this.ID, out Translation) ? Translation : this._description;
      }
      set => this._description = value;
    }

    public static SlotS001MedalDeck Parse(MasterDataReader reader)
    {
      return new SlotS001MedalDeck()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        result_icon = reader.ReadInt(),
        description = reader.ReadString(true),
        prize_first = reader.ReadInt(),
        prize_second = reader.ReadInt(),
        prize_third = reader.ReadInt()
      };
    }
  }
}
