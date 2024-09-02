// Decompiled with JetBrains decompiler
// Type: RankingInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using UnityEngine;

#nullable disable
public class RankingInfo
{
  public Quest00229MenuParts scroll;
  public GameObject TextObject;

  public QuestScoreRankingPlayer player { get; set; }

  public RankingInfo TempCopy()
  {
    RankingInfo rankingInfo = (RankingInfo) this.MemberwiseClone();
    rankingInfo.scroll = (Quest00229MenuParts) null;
    return rankingInfo;
  }
}
