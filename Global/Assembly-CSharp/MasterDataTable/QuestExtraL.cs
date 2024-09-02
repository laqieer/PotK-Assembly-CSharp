// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestExtraL
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using I2.Loc;
using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class QuestExtraL
  {
    public int ID;
    private string _name;
    public int priority;
    public int? description_QuestExtraDescription;
    public string background_image_name;

    public string name
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._name;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("quest_extra_QuestExtraL_name_" + (object) this.ID, out Translation) ? Translation : this._name;
      }
      set => this._name = value;
    }

    public static QuestExtraL Parse(MasterDataReader reader)
    {
      return new QuestExtraL()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        priority = reader.ReadInt(),
        description_QuestExtraDescription = reader.ReadIntOrNull(),
        background_image_name = reader.ReadString(true)
      };
    }

    public QuestExtraDescription description
    {
      get
      {
        if (!this.description_QuestExtraDescription.HasValue)
          return (QuestExtraDescription) null;
        QuestExtraDescription description;
        if (!MasterData.QuestExtraDescription.TryGetValue(this.description_QuestExtraDescription.Value, out description))
          Debug.LogError((object) ("Key not Found: MasterData.QuestExtraDescription[" + (object) this.description_QuestExtraDescription.Value + "]"));
        return description;
      }
    }
  }
}
