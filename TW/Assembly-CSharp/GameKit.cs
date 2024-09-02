// Decompiled with JetBrains decompiler
// Type: GameKit
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class GameKit : MonoBehaviour
{
  private static System.Action _signInCallback;

  private void Start()
  {
  }

  public static void ShowAchievements(System.Action callback = null)
  {
    GameKit.SignIn((System.Action) (() =>
    {
      if (callback == null)
        return;
      callback();
    }));
  }

  private static void SignIn(System.Action callback)
  {
  }

  private static void _SignIn(System.Action callback)
  {
  }

  [DebuggerHidden]
  private IEnumerator SyncForPlatform()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    GameKit.\u003CSyncForPlatform\u003Ec__IteratorAD7 platformCIteratorAd7 = new GameKit.\u003CSyncForPlatform\u003Ec__IteratorAD7();
    return (IEnumerator) platformCIteratorAd7;
  }

  public static void SyncAchievements(object achievements)
  {
    foreach (Dictionary<string, object> achievement in (IEnumerable) achievements)
    {
      PlayerGameKit2AchievementResult achievementResult = new PlayerGameKit2AchievementResult(achievement);
      Singleton<SocialManager>.GetInstance().ReportProgress(achievementResult.achievement_id, (double) achievementResult.progress);
    }
  }

  public static void SyncAchievements(UserAchievements[] achievements)
  {
  }

  public void OnSignInFailed() => Debug.LogWarning((object) "**** OnSignInFailed() ****");

  public void OnSignInSucceeded()
  {
    Debug.LogWarning((object) "**** OnSignInSucceeded() ****");
    if (GameKit._signInCallback != null)
      GameKit._signInCallback();
    this.StartCoroutine(this.SyncForPlatform());
  }
}
