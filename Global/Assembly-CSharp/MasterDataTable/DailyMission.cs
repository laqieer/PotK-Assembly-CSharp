// Decompiled with JetBrains decompiler
// Type: MasterDataTable.DailyMission
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using I2.Loc;
using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class DailyMission
  {
    public int ID;
    public bool _enable;
    public int priority;
    public int num;
    public int limit_count;
    private string _name;
    private string _detail;
    public string scene;
    public DateTime? start_at;
    public DateTime? end_at;

    public string name
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._name;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("dailymission_DailyMission_name_" + (object) this.ID, out Translation) ? Translation : this._name;
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
        return LocalizationManager.TryGetTermTranslation("dailymission_DailyMission_detail_" + (object) this.ID, out Translation) ? Translation : this._detail;
      }
      set => this._detail = value;
    }

    public static DailyMission Parse(MasterDataReader reader)
    {
      return new DailyMission()
      {
        ID = reader.ReadInt(),
        _enable = reader.ReadBool(),
        priority = reader.ReadInt(),
        num = reader.ReadInt(),
        limit_count = reader.ReadInt(),
        name = reader.ReadString(true),
        detail = reader.ReadString(true),
        scene = reader.ReadString(true),
        start_at = reader.ReadDateTimeOrNull(),
        end_at = reader.ReadDateTimeOrNull()
      };
    }
  }
}
