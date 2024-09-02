﻿// Decompiled with JetBrains decompiler
// Type: Quest00217Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Quest00217Scene : NGSceneBase
{
  public Quest00217Menu menu;
  private bool IsInit;

  public static void ChangeScene(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_17", stack);
  }

  public static void ChangeScene(bool stack, bool needInit)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_17", (stack ? 1 : 0) != 0, (object) needInit);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00217Scene.\u003ConStartSceneAsync\u003Ec__Iterator1E4()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(bool needInit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00217Scene.\u003ConStartSceneAsync\u003Ec__Iterator1E5()
    {
      needInit = needInit,
      \u003C\u0024\u003EneedInit = needInit,
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene()
  {
    if (Singleton<TutorialRoot>.GetInstance().isReadHint(this.sceneName, 0))
    {
      DateTime playedTime = new DateTime();
      try
      {
        playedTime = Persist.eventStoryPlay.Data.reservedTime;
      }
      catch
      {
        Persist.eventStoryPlay.Delete();
      }
      Persist.eventStoryPlay.Data.SetReserveList(StoryPlaybackEventPlay.GetPlayList(ServerTime.NowAppTime(), playedTime), ServerTime.NowAppTime());
      if (Persist.eventStoryPlay.Data.PlayEventScript(this.sceneName, ServerTime.NowAppTime(), 0))
        return;
      Singleton<CommonRoot>.GetInstance().isLoading = false;
    }
    else
      Singleton<CommonRoot>.GetInstance().isLoading = false;
  }

  public void onStartScene(bool needInit) => this.onStartScene();

  [DebuggerHidden]
  private IEnumerator ProgressExtra()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00217Scene.\u003CProgressExtra\u003Ec__Iterator1E6()
    {
      \u003C\u003Ef__this = this
    };
  }
}
