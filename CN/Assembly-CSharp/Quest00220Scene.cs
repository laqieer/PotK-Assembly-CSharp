// Decompiled with JetBrains decompiler
// Type: Quest00220Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest00220Scene : NGSceneBase
{
  private static bool isInit;
  public Quest00220Menu menu;
  public BGChange bgchange;
  private static bool keyQuest;

  public static void ChangeScene00220(
    bool stack,
    int L,
    int M,
    bool Guerrilla = false,
    bool isKeyQuest = false,
    bool isForces = false)
  {
    Quest00220Scene.isInit = true;
    Quest00220Scene.keyQuest = isKeyQuest;
    Quest00220SceneData quest00220SceneData = new Quest00220SceneData(L, M, -1, isForces, Guerrilla);
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_20", (stack ? 1 : 0) != 0, (object) quest00220SceneData);
  }

  public static void ChangeScene00220(int sid, bool isKeyQuest = false, bool isForces = false)
  {
    Quest00220Scene.isInit = true;
    Quest00220Scene.keyQuest = isKeyQuest;
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_20", false, (object) sid, (object) isForces);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(int id, bool isForces)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00220Scene.\u003ConStartSceneAsync\u003Ec__Iterator241()
    {
      id = id,
      isForces = isForces,
      \u003C\u0024\u003Eid = id,
      \u003C\u0024\u003EisForces = isForces,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(Quest00220SceneData data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00220Scene.\u003ConStartSceneAsync\u003Ec__Iterator242()
    {
      data = data,
      \u003C\u0024\u003Edata = data,
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene(int id, bool isForces)
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
    Persist.eventStoryPlay.Data.PlayEventScript(this.sceneName, ServerTime.NowAppTime(), id);
    this.menu.HscrollButtonsAction();
    this.menu.SceneStart = true;
    Singleton<CommonRoot>.GetInstance().isLoading = false;
  }

  public void onStartScene(Quest00220SceneData data)
  {
    PlayerExtraQuestS[] playerExtraQuestSArray = SMManager.Get<PlayerExtraQuestS[]>().S(data.L, data.M);
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
    if (playerExtraQuestSArray != null && playerExtraQuestSArray.Length > 0)
      Persist.eventStoryPlay.Data.PlayEventScript(this.sceneName, ServerTime.NowAppTime(), playerExtraQuestSArray[0]._quest_extra_s);
    this.menu.SceneStart = true;
    Singleton<CommonRoot>.GetInstance().isLoading = false;
  }

  public override void onEndScene()
  {
    foreach (GameObject hscrollButton in this.menu.hscrollButtons)
      hscrollButton.GetComponent<Quest0022Hscroll>().centerAnimation(false);
    this.menu.indicator.SeEnable = false;
    this.menu.nowCenterObj = (GameObject) null;
    this.menu.SceneStart = false;
    this.menu.ButtonMove = false;
    this.menu.onEndScene();
  }
}
