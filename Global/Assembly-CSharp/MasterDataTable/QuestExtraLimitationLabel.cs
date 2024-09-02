// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestExtraLimitationLabel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using I2.Loc;
using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class QuestExtraLimitationLabel
  {
    public int ID;
    public int quest_s_id_QuestExtraS;
    private string _label;

    public string label
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._label;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("quest_extra_QuestExtraLimitationLabel_label_" + (object) this.ID, out Translation) ? Translation : this._label;
      }
      set => this._label = value;
    }

    public static QuestExtraLimitationLabel Parse(MasterDataReader reader)
    {
      return new QuestExtraLimitationLabel()
      {
        ID = reader.ReadInt(),
        quest_s_id_QuestExtraS = reader.ReadInt(),
        label = reader.ReadString(true)
      };
    }

    public QuestExtraS quest_s_id
    {
      get
      {
        QuestExtraS questSId;
        if (!MasterData.QuestExtraS.TryGetValue(this.quest_s_id_QuestExtraS, out questSId))
          Debug.LogError((object) ("Key not Found: MasterData.QuestExtraS[" + (object) this.quest_s_id_QuestExtraS + "]"));
        return questSId;
      }
    }
  }
}
