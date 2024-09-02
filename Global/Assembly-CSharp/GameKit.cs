// Decompiled with JetBrains decompiler
// Type: GameKit
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class GameKit : MonoBehaviour
{
  public static void SyncAchievements(object achievements)
  {
    foreach (Dictionary<string, object> achievement in (IEnumerable) achievements)
    {
      PlayerGameKitAchievement gameKitAchievement = new PlayerGameKitAchievement(achievement);
      Singleton<SocialManager>.GetInstance().ReportProgress(gameKitAchievement.achievement_id, (double) gameKitAchievement.progress);
    }
  }

  public static void SyncLeaderboards(object leaderboards)
  {
    foreach (Dictionary<string, object> leaderboard in (IEnumerable) leaderboards)
    {
      PlayerGameKitLeaderboard gameKitLeaderboard = new PlayerGameKitLeaderboard(leaderboard);
      Singleton<SocialManager>.GetInstance().ReportScore((long) gameKitLeaderboard.score, gameKitLeaderboard.leaderboard_id);
    }
  }
}
