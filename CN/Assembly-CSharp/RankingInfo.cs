// Decompiled with JetBrains decompiler
// Type: RankingInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
