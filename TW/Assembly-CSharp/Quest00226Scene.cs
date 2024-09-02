// Decompiled with JetBrains decompiler
// Type: Quest00226Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest00226Scene : NGSceneBase
{
  [SerializeField]
  private Quest00226Menu menu00226;
  protected bool IsInit;

  public static void ChangeScene(int Sid, bool stack = true)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_26", (stack ? 1 : 0) != 0, (object) Sid);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00226Scene.\u003ConStartSceneAsync\u003Ec__Iterator27E()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(int Sid)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00226Scene.\u003ConStartSceneAsync\u003Ec__Iterator27F()
    {
      Sid = Sid,
      \u003C\u0024\u003ESid = Sid,
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene()
  {
  }

  public void onStartScene(int Sid)
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
    Persist.eventStoryPlay.Data.PlayEventScript(this.sceneName, ServerTime.NowAppTime(), Sid);
  }
}
