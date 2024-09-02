// Decompiled with JetBrains decompiler
// Type: Quest00219Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Quest00219Scene : NGSceneBase
{
  public Quest00219Menu menu;
  protected bool IsInit;

  public static void ChangeScene(int Sid, bool stack = true)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_19", (stack ? 1 : 0) != 0, (object) Sid);
  }

  public static void ChangeScene(int Sid, PlayerExtraQuestS[] extra, bool stack = true)
  {
    if (extra == null)
      Singleton<NGSceneManager>.GetInstance().changeScene("quest002_19", (stack ? 1 : 0) != 0, (object) Sid);
    else
      Singleton<NGSceneManager>.GetInstance().changeScene("quest002_19", (stack ? 1 : 0) != 0, (object) Sid, (object) new Quest00219Scene.PlayerExtraWrap()
      {
        extra = extra
      });
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00219Scene.\u003ConStartSceneAsync\u003Ec__Iterator205()
    {
      \u003C\u003Ef__this = this
    };
  }

  public IEnumerator onStartSceneAsync(int Sid)
  {
    return this._onStartSceneAsync(Sid, (PlayerExtraQuestS[]) null);
  }

  public IEnumerator onStartSceneAsync(int Sid, Quest00219Scene.PlayerExtraWrap wrap)
  {
    return this._onStartSceneAsync(Sid, wrap.extra);
  }

  [DebuggerHidden]
  private IEnumerator _onStartSceneAsync(int Sid, PlayerExtraQuestS[] Extra)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00219Scene.\u003C_onStartSceneAsync\u003Ec__Iterator206()
    {
      Extra = Extra,
      Sid = Sid,
      \u003C\u0024\u003EExtra = Extra,
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
    catch (Exception ex)
    {
      Persist.eventStoryPlay.Delete();
    }
    Persist.eventStoryPlay.Data.SetReserveList(StoryPlaybackEventPlay.GetPlayList(ServerTime.NowAppTime(), playedTime), ServerTime.NowAppTime());
    Persist.eventStoryPlay.Data.PlayEventScript(this.sceneName, ServerTime.NowAppTime(), Sid);
  }

  public class PlayerExtraWrap
  {
    public PlayerExtraQuestS[] extra;
  }
}
