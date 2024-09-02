// Decompiled with JetBrains decompiler
// Type: Colosseum02346Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class Colosseum02346Scene : NGSceneBase
{
  [SerializeField]
  private Colosseum02346Menu menu;
  [SerializeField]
  private GameObject touchToNext;
  private ColosseumUtility.Info info;
  private List<ResultMenuBase> sequences;
  private bool toNextSequence;
  private bool isStarted;
  private bool isTutorial;
  private Colosseum0234Scene.Param bootParam;
  private ResultMenuBase nowPlayBase;

  public override void onEndScene() => this.sequences.Clear();

  public void IbtnTouchToNext()
  {
    this.toNextSequence = true;
    if (!((UnityEngine.Object) this.nowPlayBase != (UnityEngine.Object) null))
      return;
    this.nowPlayBase.isSkip = true;
  }

  public static void ChangeScene(
    ColosseumUtility.Info info,
    GameCore.ColosseumResult result,
    Gladiator gladiator)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("colosseum023_4_6", false, (object) info, (object) result, (object) gladiator);
  }

  public override IEnumerator onInitSceneAsync()
  {
    Colosseum02346Scene colosseum02346Scene = this;
    Future<GameObject> bgF = Res.Prefabs.BackGround.ColosseumBackground.Load<GameObject>();
    IEnumerator e = bgF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    colosseum02346Scene.backgroundPrefab = bgF.Result;
  }

  public IEnumerator onStartSceneAsync()
  {
    Future<WebAPI.Response.ColosseumBoot> futureF = WebAPI.ColosseumBoot((System.Action<WebAPI.Response.UserError>) (e =>
    {
      WebAPI.DefaultUserErrorCallback(e);
      MypageScene.ChangeSceneOnError();
    }));
    IEnumerator e1 = futureF.Wait();
    while (e1.MoveNext())
      yield return e1.Current;
    e1 = (IEnumerator) null;
    if (futureF.Result != null)
    {
      Future<WebAPI.Response.ColosseumStart> futureF2 = WebAPI.ColosseumStart(0, 1, futureF.Result.gladiators[0].player_id, 0, SMManager.Get<PlayerDeck[]>()[0].total_combat, (System.Action<WebAPI.Response.UserError>) (e =>
      {
        WebAPI.DefaultUserErrorCallback(e);
        MypageScene.ChangeSceneOnError();
      }));
      e1 = futureF2.Wait();
      while (e1.MoveNext())
        yield return e1.Current;
      e1 = (IEnumerator) null;
      if (futureF2.Result != null)
      {
        GameCore.ColosseumResult result = ColosseumBattleCalc.calcColosseum(ColosseumEnvironmentInitializer.initializeData(new ColosseumInitialData(futureF2.Result, 0), (ColosseumEnvironment) null));
        e1 = this.onStartSceneAsync(new ColosseumUtility.Info(false, futureF.Result), result, futureF.Result.gladiators[0]);
        while (e1.MoveNext())
          yield return e1.Current;
        e1 = (IEnumerator) null;
      }
    }
  }

  public IEnumerator onStartSceneAsync(
    ColosseumUtility.Info info,
    GameCore.ColosseumResult result,
    Gladiator gladiator)
  {
    Colosseum02346Scene colosseum02346Scene = this;
    Singleton<CommonRoot>.GetInstance().isTouchBlock = true;
    IEnumerator e1;
    ColosseumUtility.Info info1;
    ResultMenuBase.Param obj;
    bool targetPlayerIsFriend;
    if (info.is_tutorial)
    {
      colosseum02346Scene.isTutorial = true;
      PlayerDeck[] playerDeckArray = SMManager.Get<PlayerDeck[]>();
      int deck_number = ((IEnumerable<PlayerUnit>) playerDeckArray[Persist.colosseumDeckOrganized.Data.number].player_units).FirstOrDefault<PlayerUnit>() != (PlayerUnit) null ? Persist.colosseumDeckOrganized.Data.number : 0;
      Future<WebAPI.Response.ColosseumTutorialFinish> receive = WebAPI.ColosseumTutorialFinish(Persist.colosseumEnv.Data.id, result.GetResultJsonString(), deck_number, 1, result.isWin(), playerDeckArray[deck_number].total_combat, (System.Action<WebAPI.Response.UserError>) (e =>
      {
        WebAPI.DefaultUserErrorCallback(e);
        MypageScene.ChangeSceneOnError();
      }));
      e1 = receive.Wait();
      while (e1.MoveNext())
        yield return e1.Current;
      e1 = (IEnumerator) null;
      if (receive.Result == null)
      {
        yield break;
      }
      else
      {
        Persist.colosseumEnv.Data.id = "";
        Persist.colosseumEnv.Flush();
        info1 = new ColosseumUtility.Info(true, receive.Result);
        obj = new ResultMenuBase.Param(receive.Result);
        targetPlayerIsFriend = receive.Result.target_player_is_friend;
        receive = (Future<WebAPI.Response.ColosseumTutorialFinish>) null;
      }
    }
    else
    {
      Future<WebAPI.Response.ColosseumFinish> receive = WebAPI.ColosseumFinish(Persist.colosseumEnv.Data.id, result.GetResultJsonString(), result.isWin(), (System.Action<WebAPI.Response.UserError>) (e =>
      {
        WebAPI.DefaultUserErrorCallback(e);
        MypageScene.ChangeSceneOnError();
      }));
      e1 = receive.Wait();
      while (e1.MoveNext())
        yield return e1.Current;
      e1 = (IEnumerator) null;
      if (receive.Result == null)
      {
        yield break;
      }
      else
      {
        Persist.colosseumEnv.Data.id = "";
        Persist.colosseumEnv.Flush();
        info1 = new ColosseumUtility.Info(true, receive.Result);
        obj = new ResultMenuBase.Param(receive.Result);
        targetPlayerIsFriend = receive.Result.target_player_is_friend;
        receive = (Future<WebAPI.Response.ColosseumFinish>) null;
      }
    }
    colosseum02346Scene.bootParam = new Colosseum0234Scene.Param(false, (int[]) null, info1);
    colosseum02346Scene.sequences = new List<ResultMenuBase>()
    {
      (ResultMenuBase) colosseum02346Scene.GetComponent<Colosseum02346Menu>(),
      (ResultMenuBase) null
    };
    if (!targetPlayerIsFriend)
      colosseum02346Scene.sequences.Add((ResultMenuBase) colosseum02346Scene.GetComponent<FriendMenu>());
    e1 = colosseum02346Scene.InitMenus(info, obj, gladiator);
    while (e1.MoveNext())
      yield return e1.Current;
    e1 = (IEnumerator) null;
    Singleton<CommonRoot>.GetInstance().isTouchBlock = false;
  }

  public void onStartScene()
  {
    Singleton<CommonRoot>.GetInstance().isLoading = false;
    if (this.isStarted)
      return;
    this.isStarted = true;
    this.StartCoroutine(this.RunMenus());
  }

  public void onStartScene(ColosseumUtility.Info info, GameCore.ColosseumResult result, Gladiator gladiator)
  {
    Singleton<CommonRoot>.GetInstance().isLoading = false;
    if (this.isStarted)
      return;
    this.isStarted = true;
    this.StartCoroutine(this.RunMenus());
  }

  private IEnumerator InitMenus(
    ColosseumUtility.Info info,
    ResultMenuBase.Param param,
    Gladiator gladiator)
  {
    this.touchToNext.SetActive(false);
    foreach (ResultMenuBase sequence in this.sequences)
    {
      if ((UnityEngine.Object) sequence != (UnityEngine.Object) null)
      {
        IEnumerator e = sequence.Init(info, param, gladiator);
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
      }
    }
  }

  private IEnumerator RunMenus()
  {
    List<ResultMenuBase>.Enumerator seqe = this.sequences.GetEnumerator();
    IEnumerator e;
    while (seqe.MoveNext())
    {
      this.nowPlayBase = seqe.Current;
      if (!((UnityEngine.Object) this.nowPlayBase == (UnityEngine.Object) null))
      {
        this.touchToNext.SetActive(true);
        e = this.nowPlayBase.Run();
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
        this.toNextSequence = false;
        while (!this.toNextSequence)
          yield return (object) null;
        this.toNextSequence = false;
        e = this.nowPlayBase.OnFinish();
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
      }
      else
        break;
    }
    this.nowPlayBase = (ResultMenuBase) null;
    this.touchToNext.SetActive(true);
    this.touchToNext.GetComponent<BoxCollider>().enabled = false;
    while (seqe.MoveNext())
    {
      e = seqe.Current.Run();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
    }
    Singleton<NGSceneManager>.GetInstance().clearStack();
    Singleton<NGSceneManager>.GetInstance().destroyLoadedScenes();
    Colosseum0234Scene.ChangeSceneFromBattleResult(this.bootParam, this.isTutorial);
  }
}
