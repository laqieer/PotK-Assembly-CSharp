﻿// Decompiled with JetBrains decompiler
// Type: SocialManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

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

  public void Auth(System.Action<bool> callback)
  {
    int num = this.isLogin ? 1 : 0;
  }

  public void SignOut()
  {
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
    if (!this.isLogin)
      return;
    Social.ShowAchievementsUI();
  }

  public void ReportProgress(string achievementID, double progress, System.Action<bool> callback)
  {
    if (!this.isLogin)
      return;
    Social.ReportProgress(achievementID, progress, callback);
  }

  public void ReportProgress(string achievementID, double progress)
  {
    if (!this.isLogin)
      return;
    Social.ReportProgress(achievementID, progress, (System.Action<bool>) (success => {}));
  }
}
