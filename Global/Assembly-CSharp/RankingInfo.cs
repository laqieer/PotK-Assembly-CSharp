// Decompiled with JetBrains decompiler
// Type: RankingInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
