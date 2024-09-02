// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestExtraScoreAchivementReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using I2.Loc;
using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class QuestExtraScoreAchivementReward
  {
    public int ID;
    private string _display_text;
    public string image_name;
    public int alignement;

    public string display_text
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._display_text;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("quest_ranking_QuestExtraScoreAchivementReward_display_text_" + (object) this.ID, out Translation) ? Translation : this._display_text;
      }
      set => this._display_text = value;
    }

    public static QuestExtraScoreAchivementReward Parse(MasterDataReader reader)
    {
      return new QuestExtraScoreAchivementReward()
      {
        ID = reader.ReadInt(),
        display_text = reader.ReadString(true),
        image_name = reader.ReadString(true),
        alignement = reader.ReadInt()
      };
    }
  }
}
