// Decompiled with JetBrains decompiler
// Type: SocialManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

#nullable disable
public class SocialManager : Singleton<SocialManager>
{
  private List<IAchievementDescription> _achieveDescriptions;
  private List<IScore> _scores;

  [SerializeField]
  public bool isLogin
  {
    get
    {
      if (Social.localUser != null)
        return Social.localUser.authenticated;
      Debug.LogWarning((object) "ログインしてません！");
      return false;
    }
  }

  protected override void Initialize()
  {
  }

  public void Auth(Action<bool> callback)
  {
    if (!this.isLogin)
      ;
  }

  private static void ProcessAuthGameCenter(bool success)
  {
    if (success)
      Debug.Log((object) "[GameCenter]UserLogin Success!!");
    else
      Debug.Log((object) "[GameCenter]UserLogin Failed!!");
  }

  public void ShowAchievementsUI()
  {
    if (this.isLogin)
      Social.ShowAchievementsUI();
    else
      this.Auth((Action<bool>) (success =>
      {
        if (!success)
          return;
        this.ShowAchievementsUI();
      }));
  }

  public void ReportProgress(string achievementID, double progress, Action<bool> callback)
  {
    if (!this.isLogin)
      return;
    Social.ReportProgress(achievementID, progress, callback);
  }

  public void ReportProgress(string achievementID, double progress)
  {
    if (!this.isLogin)
      return;
    Social.ReportProgress(achievementID, progress, (Action<bool>) (success => { }));
  }
}
