// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestHarmonyLimitationLabel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using I2.Loc;
using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class QuestHarmonyLimitationLabel
  {
    public int ID;
    public int quest_s_id_QuestHarmonyS;
    private string _label;

    public string label
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._label;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("quest_harmony_QuestHarmonyLimitationLabel_label_" + (object) this.ID, out Translation) ? Translation : this._label;
      }
      set => this._label = value;
    }

    public static QuestHarmonyLimitationLabel Parse(MasterDataReader reader)
    {
      return new QuestHarmonyLimitationLabel()
      {
        ID = reader.ReadInt(),
        quest_s_id_QuestHarmonyS = reader.ReadInt(),
        label = reader.ReadString(true)
      };
    }

    public QuestHarmonyS quest_s_id
    {
      get
      {
        QuestHarmonyS questSId;
        if (!MasterData.QuestHarmonyS.TryGetValue(this.quest_s_id_QuestHarmonyS, out questSId))
          Debug.LogError((object) ("Key not Found: MasterData.QuestHarmonyS[" + (object) this.quest_s_id_QuestHarmonyS + "]"));
        return questSId;
      }
    }
  }
}
