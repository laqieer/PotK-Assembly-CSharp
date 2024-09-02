// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestMoviePath
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using I2.Loc;
using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class QuestMoviePath
  {
    public int ID;
    public string ios_path;
    public string android_path;
    private string _title;

    public string title
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._title;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("quest_movie_QuestMoviePath_title_" + (object) this.ID, out Translation) ? Translation : this._title;
      }
      set => this._title = value;
    }

    public static QuestMoviePath Parse(MasterDataReader reader)
    {
      return new QuestMoviePath()
      {
        ID = reader.ReadInt(),
        ios_path = reader.ReadString(true),
        android_path = reader.ReadString(true),
        title = reader.ReadString(true)
      };
    }
  }
}
