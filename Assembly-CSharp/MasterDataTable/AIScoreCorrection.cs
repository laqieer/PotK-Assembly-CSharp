// Decompiled with JetBrains decompiler
// Type: MasterDataTable.AIScoreCorrection
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

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

    public static AIScoreCorrection Parse(MasterDataReader reader) => new AIScoreCorrection()
    {
      ID = reader.ReadInt(),
      pattern_AIScorePattern = reader.ReadInt(),
      score_AIScore = reader.ReadInt(),
      var1 = reader.ReadFloat(),
      var2 = reader.ReadFloat(),
      var3 = reader.ReadFloat()
    };

    public AIScorePattern pattern
    {
      get
      {
        AIScorePattern aiScorePattern;
        if (!MasterData.AIScorePattern.TryGetValue(this.pattern_AIScorePattern, out aiScorePattern))
          Debug.LogError((object) ("Key not Found: MasterData.AIScorePattern[" + (object) this.pattern_AIScorePattern + "]"));
        return aiScorePattern;
      }
    }

    public AIScore score
    {
      get
      {
        AIScore aiScore;
        if (!MasterData.AIScore.TryGetValue(this.score_AIScore, out aiScore))
          Debug.LogError((object) ("Key not Found: MasterData.AIScore[" + (object) this.score_AIScore + "]"));
        return aiScore;
      }
    }
  }
}
