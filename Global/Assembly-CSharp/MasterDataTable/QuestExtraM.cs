// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestExtraM
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using I2.Loc;
using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class QuestExtraM
  {
    public int ID;
    private string _name;
    public int priority;
    public int? description;
    public int background_QuestCommonBackground;
    public int? button_type;
    public string background_button_name;

    public string name
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._name;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("quest_extra_QuestExtraM_name_" + (object) this.ID, out Translation) ? Translation : this._name;
      }
      set => this._name = value;
    }

    public static QuestExtraM Parse(MasterDataReader reader)
    {
      return new QuestExtraM()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        priority = reader.ReadInt(),
        description = reader.ReadIntOrNull(),
        background_QuestCommonBackground = reader.ReadInt(),
        button_type = reader.ReadIntOrNull(),
        background_button_name = reader.ReadString(true)
      };
    }

    public QuestCommonBackground background
    {
      get
      {
        QuestCommonBackground background;
        if (!MasterData.QuestCommonBackground.TryGetValue(this.background_QuestCommonBackground, out background))
          Debug.LogError((object) ("Key not Found: MasterData.QuestCommonBackground[" + (object) this.background_QuestCommonBackground + "]"));
        return background;
      }
    }
  }
}
