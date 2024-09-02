// Decompiled with JetBrains decompiler
// Type: Coloseum02342Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Coloseum02342Scene : NGSceneBase
{
  private const int START_DUEL_COUNT = 0;
  private int duelCount;
  [SerializeField]
  private Coloseum02342Menu menu;
  private GameCore.ColosseumResult battle_result;
  private ColosseumUtility.Info info;
  private Gladiator gladiator;
  public TextAsset test_assets;

  public static void changeScene(
    ColosseumUtility.Info info,
    int opponent_index,
    GameCore.ColosseumResult battle_result)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("colosseum023_4_2", false, (object) info, (object) info.gladiators[opponent_index], (object) battle_result);
  }

  public static void changeScene(
    ColosseumUtility.Info info,
    WebAPI.Response.ColosseumResume resume,
    GameCore.ColosseumResult battle_result)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("colosseum023_4_2", false, (object) info, (object) resume, (object) battle_result);
  }

  public static void changeScene(
    ColosseumUtility.Info info,
    WebAPI.Response.ColosseumTutorialResume resume,
    GameCore.ColosseumResult battle_result)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("colosseum023_4_2", false, (object) info, (object) resume, (object) battle_result);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Coloseum02342Scene.\u003ConInitSceneAsync\u003Ec__Iterator509()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Coloseum02342Scene.\u003ConStartSceneAsync\u003Ec__Iterator50A()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(
    ColosseumUtility.Info info,
    Gladiator gladiator,
    GameCore.ColosseumResult battle_result)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Coloseum02342Scene.\u003ConStartSceneAsync\u003Ec__Iterator50B()
    {
      gladiator = gladiator,
      info = info,
      battle_result = battle_result,
      \u003C\u0024\u003Egladiator = gladiator,
      \u003C\u0024\u003Einfo = info,
      \u003C\u0024\u003Ebattle_result = battle_result,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(
    ColosseumUtility.Info info,
    WebAPI.Response.ColosseumResume resume,
    GameCore.ColosseumResult battle_result)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Coloseum02342Scene.\u003ConStartSceneAsync\u003Ec__Iterator50C()
    {
      resume = resume,
      info = info,
      battle_result = battle_result,
      \u003C\u0024\u003Eresume = resume,
      \u003C\u0024\u003Einfo = info,
      \u003C\u0024\u003Ebattle_result = battle_result,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(
    ColosseumUtility.Info info,
    WebAPI.Response.ColosseumTutorialResume resume,
    GameCore.ColosseumResult battle_result)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Coloseum02342Scene.\u003ConStartSceneAsync\u003Ec__Iterator50D()
    {
      resume = resume,
      info = info,
      battle_result = battle_result,
      \u003C\u0024\u003Eresume = resume,
      \u003C\u0024\u003Einfo = info,
      \u003C\u0024\u003Ebattle_result = battle_result,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(ColosseumUtility.Info info, GameCore.ColosseumResult result)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Coloseum02342Scene.\u003ConStartSceneAsync\u003Ec__Iterator50E()
    {
      info = info,
      result = result,
      \u003C\u0024\u003Einfo = info,
      \u003C\u0024\u003Eresult = result,
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene()
  {
    this.menu.StartToBeginning(this.duelCount);
    ++this.duelCount;
  }

  public void onStartScene(
    ColosseumUtility.Info info,
    Gladiator gladiator,
    GameCore.ColosseumResult battle_result)
  {
    this.onStartScene();
  }

  public void onStartScene(
    ColosseumUtility.Info info,
    WebAPI.Response.ColosseumResume resume,
    GameCore.ColosseumResult battle_result)
  {
    this.onStartScene();
  }

  public void onStartScene(
    ColosseumUtility.Info info,
    WebAPI.Response.ColosseumTutorialResume resume,
    GameCore.ColosseumResult battle_result)
  {
    this.onStartScene();
  }

  public void onStartScene(ColosseumUtility.Info info, GameCore.ColosseumResult result)
  {
    this.onStartScene();
  }

  public void Reinitialize()
  {
    Singleton<CommonRoot>.GetInstance().isTouchBlock = true;
    this.menu.StartToBeginning(this.duelCount);
    Singleton<CommonRoot>.GetInstance().isTouchBlock = false;
    ++this.duelCount;
  }

  public void ReplayScene()
  {
    this.duelCount = 0;
    this.onStartScene();
  }
}
