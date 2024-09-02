// Decompiled with JetBrains decompiler
// Type: MasterDataTable.DailyMissionTopPage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using I2.Loc;
using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class DailyMissionTopPage
  {
    public int ID;
    private string _title;
    private string _message;
    private string _attention;
    public DateTime? start_at;
    public DateTime? end_at;

    public string title
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._title;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("dailymission_DailyMissionTopPage_title_" + (object) this.ID, out Translation) ? Translation : this._title;
      }
      set => this._title = value;
    }

    public string message
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._message;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("dailymission_DailyMissionTopPage_message_" + (object) this.ID, out Translation) ? Translation : this._message;
      }
      set => this._message = value;
    }

    public string attention
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._attention;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("dailymission_DailyMissionTopPage_attention_" + (object) this.ID, out Translation) ? Translation : this._attention;
      }
      set => this._attention = value;
    }

    public static DailyMissionTopPage Parse(MasterDataReader reader)
    {
      return new DailyMissionTopPage()
      {
        ID = reader.ReadInt(),
        title = reader.ReadString(true),
        message = reader.ReadString(true),
        attention = reader.ReadString(true),
        start_at = reader.ReadDateTimeOrNull(),
        end_at = reader.ReadDateTimeOrNull()
      };
    }
  }
}
