// Decompiled with JetBrains decompiler
// Type: Quest002272SceneChangeData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;

#nullable disable
public class Quest002272SceneChangeData
{
  public QuestScoreCampaignProgressScore_achivement_rewards achivement_reward;
  public int[] achivement_cleard;
  public string title;
  public int score;

  public Quest002272SceneChangeData(
    QuestScoreCampaignProgressScore_achivement_rewards achivementReward,
    int[] achivementCleard,
    string title,
    int score)
  {
    this.achivement_reward = achivementReward;
    this.achivement_cleard = achivementCleard;
    this.title = title;
    this.score = score;
  }
}
