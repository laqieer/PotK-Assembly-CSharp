// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitVoicePattern
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using I2.Loc;
using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class UnitVoicePattern
  {
    public int ID;
    public int character_id;
    public int voice_pattern;
    private string _dead_message;
    public string file_name;

    public string dead_message
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._dead_message;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("unit_UnitVoicePattern_dead_message_" + (object) this.ID, out Translation) ? Translation : this._dead_message;
      }
      set => this._dead_message = value;
    }

    public static UnitVoicePattern Parse(MasterDataReader reader)
    {
      return new UnitVoicePattern()
      {
        ID = reader.ReadInt(),
        character_id = reader.ReadInt(),
        voice_pattern = reader.ReadInt(),
        dead_message = reader.ReadString(true),
        file_name = reader.ReadString(true)
      };
    }
  }
}
