// Decompiled with JetBrains decompiler
// Type: Quest002272SceneChangeData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
