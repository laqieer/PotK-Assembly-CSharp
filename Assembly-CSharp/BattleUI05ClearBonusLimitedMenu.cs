// Decompiled with JetBrains decompiler
// Type: BattleUI05ClearBonusLimitedMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class BattleUI05ClearBonusLimitedMenu : ResultMenuBase
{
  private List<BattleResultBonusInfo> Rewards;
  private GameObject bonus;
  private GameObject ClearBonusPrefab;

  public override IEnumerator Init(BattleInfo info, BattleEnd result)
  {
    BattleUI05ClearBonusLimitedMenu bonusLimitedMenu = this;
    bonusLimitedMenu.Rewards = new List<BattleResultBonusInfo>();
    // ISSUE: reference to a compiler-generated method
    ((IEnumerable<int>) ((IEnumerable<BattleEndStage_clear_rewards>) result.stage_clear_rewards).Select<BattleEndStage_clear_rewards, int>((Func<BattleEndStage_clear_rewards, int>) (x => x.id)).ToArray<int>()).ForEach<int>(new System.Action<int>(bonusLimitedMenu.\u003CInit\u003Eb__3_1));
    IEnumerator e = bonusLimitedMenu.LoadResources();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  private IEnumerator LoadResources()
  {
    IEnumerator e;
    if ((UnityEngine.Object) this.ClearBonusPrefab == (UnityEngine.Object) null)
    {
      Future<GameObject> ClearBonusPrefabF = Res.Prefabs.battle.Quest_ClearBonus.Load<GameObject>();
      e = ClearBonusPrefabF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      this.ClearBonusPrefab = ClearBonusPrefabF.Result;
      ClearBonusPrefabF = (Future<GameObject>) null;
    }
    this.bonus = this.ClearBonusPrefab.Clone(Singleton<CommonRoot>.GetInstance().LoadTmpObj.transform);
    this.bonus.SetActive(false);
    e = this.bonus.GetComponent<BattleUI05ClearBonusSetting>().CreateClearBonusIcon(this.Rewards);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  public override IEnumerator Run()
  {
    BattleUI05ClearBonusLimitedMenu bonusLimitedMenu = this;
    bonusLimitedMenu.bonus.SetParent(bonusLimitedMenu.gameObject);
    bonusLimitedMenu.bonus.SetActive(true);
    bonusLimitedMenu.bonus.GetComponent<BattleUI05ClearBonusSetting>().SetClearBonusInfo(bonusLimitedMenu.Rewards);
    Singleton<NGSoundManager>.GetInstance().playSE("SE_1034");
    IEnumerator e = bonusLimitedMenu.SetColorBackground();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    bool toNext = false;
    GameObject touchObj = bonusLimitedMenu.CreateTouchObject((EventDelegate.Callback) (() => toNext = true));
    while (!toNext)
    {
      if (Singleton<NGGameDataManager>.GetInstance().questAutoLap)
      {
        yield return (object) new WaitForSeconds(3f);
        toNext = true;
      }
      yield return (object) null;
    }
    UnityEngine.Object.DestroyObject((UnityEngine.Object) bonusLimitedMenu.bonus);
    UnityEngine.Object.DestroyObject((UnityEngine.Object) touchObj);
  }

  private IEnumerator CreateBonusObject()
  {
    BattleUI05ClearBonusLimitedMenu bonusLimitedMenu = this;
    Future<GameObject> loader = Res.Prefabs.battle.Quest_ClearBonus_Limited.Load<GameObject>();
    IEnumerator e = loader.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    bonusLimitedMenu.bonus = loader.Result.Clone(bonusLimitedMenu.gameObject.transform);
  }

  private IEnumerator SetColorBackground()
  {
    BattleUI05ClearBonusLimitedMenu bonusLimitedMenu = this;
    Future<UnityEngine.Sprite> textureLoader = Res.Prefabs.BackGround.black.Load<UnityEngine.Sprite>();
    IEnumerator e = textureLoader.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    Resolution currentResolution = Screen.currentResolution;
    GameObject gameObject = new GameObject("Color Layer");
    gameObject.transform.parent = bonusLimitedMenu.bonus.transform;
    gameObject.layer = bonusLimitedMenu.gameObject.layer;
    UIPanel uiPanel = gameObject.AddComponent<UIPanel>();
    UI2DSprite ui2Dsprite = gameObject.AddComponent<UI2DSprite>();
    uiPanel.depth = 20;
    ui2Dsprite.sprite2D = textureLoader.Result;
    ui2Dsprite.alpha = 0.75f;
    ui2Dsprite.height = currentResolution.height;
    ui2Dsprite.width = currentResolution.width;
  }
}
