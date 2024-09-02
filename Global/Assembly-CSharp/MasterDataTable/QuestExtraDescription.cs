// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestExtraDescription
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using I2.Loc;
using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class QuestExtraDescription
  {
    public int ID;
    public int descriptionID;
    private string _body;
    public string image_url;
    public int? image_width;
    public int? image_height;
    public int? extra_type;
    public int? extra_id;
    public int? extra_position;

    public string body
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._body;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("quest_extra_QuestExtraDescription_body_" + (object) this.ID, out Translation) ? Translation : this._body;
      }
      set => this._body = value;
    }

    public static QuestExtraDescription Parse(MasterDataReader reader)
    {
      return new QuestExtraDescription()
      {
        ID = reader.ReadInt(),
        descriptionID = reader.ReadInt(),
        body = reader.ReadStringOrNull(true),
        image_url = reader.ReadStringOrNull(true),
        image_width = reader.ReadIntOrNull(),
        image_height = reader.ReadIntOrNull(),
        extra_type = reader.ReadIntOrNull(),
        extra_id = reader.ReadIntOrNull(),
        extra_position = reader.ReadIntOrNull()
      };
    }
  }
}
