// Decompiled with JetBrains decompiler
// Type: MasterDataTable.AIScoreCorrection
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class AIScoreCorrection
  {
    public int ID;
    public int pattern_AIScorePattern;
    public int score_AIScore;
    public float var1;
    public float var2;
    public float var3;

    public static AIScoreCorrection Parse(MasterDataReader reader)
    {
      return new AIScoreCorrection()
      {
        ID = reader.ReadInt(),
        pattern_AIScorePattern = reader.ReadInt(),
        score_AIScore = reader.ReadInt(),
        var1 = reader.ReadFloat(),
        var2 = reader.ReadFloat(),
        var3 = reader.ReadFloat()
      };
    }

    public AIScorePattern pattern
    {
      get
      {
        AIScorePattern pattern;
        if (!MasterData.AIScorePattern.TryGetValue(this.pattern_AIScorePattern, out pattern))
          Debug.LogError((object) ("Key not Found: MasterData.AIScorePattern[" + (object) this.pattern_AIScorePattern + "]"));
        return pattern;
      }
    }

    public AIScore score
    {
      get
      {
        AIScore score;
        if (!MasterData.AIScore.TryGetValue(this.score_AIScore, out score))
          Debug.LogError((object) ("Key not Found: MasterData.AIScore[" + (object) this.score_AIScore + "]"));
        return score;
      }
    }
  }
}
