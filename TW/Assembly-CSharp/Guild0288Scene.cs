// Decompiled with JetBrains decompiler
// Type: Guild0288Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Guild0288Scene : NGSceneBase
{
  [SerializeField]
  private Guild0288GuildInBattleResultMenu resultMenu;
  [SerializeField]
  private GameObject touchToNext;
  private List<ResultMenuBase> sequences;
  private bool toNextSequence;
  private bool isInitialized;
  private bool isStarted;
  private WebAPI.Response.GvgBattleFinish guildBattleResultData;
  private string enemyPlayerID;

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0288Scene.\u003ConInitSceneAsync\u003Ec__Iterator7E3()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(
    WebAPI.Response.GvgBattleFinish guildBattleResultData,
    string enemyPlayerID)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0288Scene.\u003ConStartSceneAsync\u003Ec__Iterator7E4()
    {
      guildBattleResultData = guildBattleResultData,
      enemyPlayerID = enemyPlayerID,
      \u003C\u0024\u003EguildBattleResultData = guildBattleResultData,
      \u003C\u0024\u003EenemyPlayerID = enemyPlayerID,
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene(
    WebAPI.Response.GvgBattleFinish guildBattleResultData,
    string enemyPlayerID)
  {
    Singleton<CommonRoot>.GetInstance().isLoading = false;
    if (this.isStarted)
      return;
    this.isStarted = true;
    this.StartCoroutine(this.RunMenus());
  }

  [DebuggerHidden]
  private IEnumerator InitMenus(WebAPI.Response.GvgBattleFinish resultData)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0288Scene.\u003CInitMenus\u003Ec__Iterator7E5()
    {
      resultData = resultData,
      \u003C\u0024\u003EresultData = resultData,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator RunMenus()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0288Scene.\u003CRunMenus\u003Ec__Iterator7E6()
    {
      \u003C\u003Ef__this = this
    };
  }

  public static void ChangeScene(WebAPI.Response.GvgBattleFinish resultData, string enemyPlayerID)
  {
    NGSceneManager instance = Singleton<NGSceneManager>.GetInstance();
    instance.clearStack();
    instance.destroyCurrentScene();
    instance.destroyLoadedScenes();
    instance.changeScene("guild028_8", false, (object) resultData, (object) enemyPlayerID);
  }

  public void IbtnTouchToNext() => this.toNextSequence = true;
}
