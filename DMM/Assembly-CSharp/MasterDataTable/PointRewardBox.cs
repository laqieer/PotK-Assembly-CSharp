// Decompiled with JetBrains decompiler
// Type: MasterDataTable.PointRewardBox
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class PointRewardBox
  {
    public int ID;
    public int type;
    public int point;
    public int box_type;
    public string point_reward_ids;
    public DateTime? start_at;
    public DateTime? end_at;

    public static PointRewardBox Parse(MasterDataReader reader) => new PointRewardBox()
    {
      ID = reader.ReadInt(),
      type = reader.ReadInt(),
      point = reader.ReadInt(),
      box_type = reader.ReadInt(),
      point_reward_ids = reader.ReadString(true),
      start_at = reader.ReadDateTimeOrNull(),
      end_at = reader.ReadDateTimeOrNull()
    };

    public PointReward[] rewards
    {
      get
      {
        string[] strArray = this.point_reward_ids.Split(PointRewardBox.charSeparator);
        PointReward[] pointRewardArray = new PointReward[strArray.Length];
        for (int index = 0; index < pointRewardArray.Length; ++index)
          pointRewardArray[index] = MasterData.PointReward[int.Parse(strArray[index])];
        return pointRewardArray;
      }
    }

    private static char charSeparator => ':';
  }
}
