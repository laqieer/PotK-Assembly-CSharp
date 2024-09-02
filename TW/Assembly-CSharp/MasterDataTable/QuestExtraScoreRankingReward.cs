// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestExtraScoreRankingReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class QuestExtraScoreRankingReward
  {
    public int ID;
    public int campaign_id;
    public string display_text;
    public string image_name;
    public int alignment;
    public int group_id;

    public static QuestExtraScoreRankingReward Parse(MasterDataReader reader)
    {
      return new QuestExtraScoreRankingReward()
      {
        ID = reader.ReadInt(),
        campaign_id = reader.ReadInt(),
        display_text = reader.ReadString(true),
        image_name = reader.ReadString(true),
        alignment = reader.ReadInt(),
        group_id = reader.ReadInt()
      };
    }
  }
}
