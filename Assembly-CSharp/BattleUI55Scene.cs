// Decompiled with JetBrains decompiler
// Type: BattleUI55Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using Earth;
using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class BattleUI55Scene : NGSceneBase
{
  [SerializeField]
  private GameObject touchToNext;
  private List<ResultMenuBase> sequences;
  private bool isInitialized;
  private bool isStarted;
  private bool toNextSequence;
  private BattleUI55Continue contineMenu;

  public override void onEndScene() => this.sequences.Clear();

  public override List<string> createResourceLoadList()
  {
    PlayerUnit[] playerUnitArray = SMManager.Get<PlayerUnit[]>();
    ResourceManager rm = Singleton<ResourceManager>.GetInstance();
    Func<PlayerUnit, IEnumerable<string>> selector = (Func<PlayerUnit, IEnumerable<string>>) (x => (IEnumerable<string>) rm.PathsFromUnit(x.unit));
    return ((IEnumerable<PlayerUnit>) playerUnitArray).SelectMany<PlayerUnit, string>(selector).ToList<string>();
  }

  public void IbtnTouchToNext() => this.toNextSequence = true;

  public static void ChangeScene(BattleInfo info, bool isWin, BattleEnd result)
  {
    NGSceneManager instance = Singleton<NGSceneManager>.GetInstance();
    instance.clearStack();
    instance.destroyCurrentScene();
    instance.destroyLoadedScenes();
    if (Singleton<EarthDataManager>.GetInstance().isPrologue)
    {
      if (isWin)
        Singleton<EarthDataManager>.GetInstance().NextPrologueScene();
      else
        Singleton<EarthDataManager>.GetInstance().PrevPrologueScene();
    }
    else if (isWin)
      instance.changeScene("battleUI_55", false, (object) info, (object) isWin, (object) result);
    else
      Mypage051Scene.ChangeScene(false);
  }

  public IEnumerator onStartSceneAsync(BattleInfo info, bool isWin, BattleEnd result)
  {
    BattleUI55Scene battleUi55Scene = this;
    if (!battleUi55Scene.isInitialized)
    {
      battleUi55Scene.isInitialized = true;
      IEnumerator e = battleUi55Scene.setBackGround(info);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      battleUi55Scene.contineMenu = battleUi55Scene.GetComponent<BattleUI55Continue>();
      battleUi55Scene.sequences = new List<ResultMenuBase>()
      {
        (ResultMenuBase) battleUi55Scene.GetComponent<BattleUI55ResultMenu>(),
        (ResultMenuBase) battleUi55Scene.GetComponent<BattleUI05RewardMenu>(),
        (ResultMenuBase) battleUi55Scene.contineMenu,
        (ResultMenuBase) null
      };
      e = battleUi55Scene.InitMenus(info, isWin, result);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
    }
  }

  private IEnumerator setBackGround(BattleInfo info)
  {
    BattleUI55Scene battleUi55Scene = this;
    string backgroundName = MasterData.EarthQuestEpisode[info.quest_s_id].background_name;
    string path = Consts.GetInstance().BACKGROUND_BASE_PATH.F((object) backgroundName);
    Future<GameObject> bgF = Res.Prefabs.BackGround.ResultBackGround.Load<GameObject>();
    IEnumerator e = bgF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    GameObject bg = bgF.Result;
    Future<UnityEngine.Sprite> bgSpriteF = Singleton<ResourceManager>.GetInstance().LoadOrNull<UnityEngine.Sprite>(path);
    e = bgSpriteF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    if ((UnityEngine.Object) bgSpriteF.Result != (UnityEngine.Object) null)
    {
      bg.GetComponent<UI2DSprite>().sprite2D = bgSpriteF.Result;
      battleUi55Scene.backgroundPrefab = bg;
    }
  }

  public void onStartScene(BattleInfo info, bool isWin, BattleEnd result)
  {
    Singleton<CommonRoot>.GetInstance().isLoading = false;
    if (this.isStarted)
      return;
    this.isStarted = true;
    this.StartCoroutine(this.RunMenus(info, isWin, result));
  }

  private IEnumerator InitMenus(BattleInfo info, bool isWin, BattleEnd result)
  {
    this.touchToNext.SetActive(false);
    foreach (ResultMenuBase sequence in this.sequences)
    {
      if ((UnityEngine.Object) sequence != (UnityEngine.Object) null)
      {
        IEnumerator e = sequence.Init(info, result);
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
      }
    }
  }

  private IEnumerator RunMenus(BattleInfo info, bool isWin, BattleEnd result)
  {
    List<ResultMenuBase>.Enumerator seqe = this.sequences.GetEnumerator();
    IEnumerator e;
    while (seqe.MoveNext())
    {
      ResultMenuBase seq = seqe.Current;
      if (!((UnityEngine.Object) seq == (UnityEngine.Object) null))
      {
        e = seq.Run();
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
        this.touchToNext.SetActive(true);
        while (!this.toNextSequence)
          yield return (object) null;
        this.touchToNext.SetActive(false);
        this.toNextSequence = false;
        e = seq.OnFinish();
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
        seq = (ResultMenuBase) null;
      }
      else
        break;
    }
    while (seqe.MoveNext())
    {
      e = seqe.Current.Run();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
    }
    Singleton<NGSceneManager>.GetInstance().sceneBase.IsPush = true;
    Singleton<NGSceneManager>.GetInstance().destroyLoadedScenes();
    if (info.quest_type == CommonQuestType.EarthExtra)
      Mypage051Scene.ChangeScene(false);
    else if (!Singleton<EarthDataManager>.GetInstance().questProgress.isCleared)
      Quest0528Scene.changeScene(false);
    else
      Mypage051Scene.ChangeScene(false);
  }
}
