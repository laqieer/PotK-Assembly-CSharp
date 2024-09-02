// Decompiled with JetBrains decompiler
// Type: GameKit
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    GameKit.\u003CSyncForPlatform\u003Ec__Iterator9FD platformCIterator9Fd = new GameKit.\u003CSyncForPlatform\u003Ec__Iterator9FD();
    return (IEnumerator) platformCIterator9Fd;
  }

  public static void SyncAchievements(object achievements)
  {
    List<UserAchievements> userAchievementsList = new List<UserAchievements>();
    foreach (object achievement in (IEnumerable) achievements)
      userAchievementsList.Add(new UserAchievements((Dictionary<string, object>) achievement));
    GameKit.SyncAchievements(userAchievementsList.ToArray());
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
