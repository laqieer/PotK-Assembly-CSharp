// Decompiled with JetBrains decompiler
// Type: Gacha0068Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System.Collections;
using UnityEngine;

public class Gacha0068Scene : NGSceneBase
{
  private Gacha0068Menu menu;
  private RenderTextureRecoveryUtil util;

  public PlayerUnit playerUnit { get; set; }

  public IEnumerator onStartSceneAsync()
  {
    this.playerUnit = (PlayerUnit) null;
    foreach (PlayerUnit playerUnit in SMManager.Get<PlayerUnit[]>())
      this.playerUnit = playerUnit;
    IEnumerator e = this.onStartSceneAsync(this.playerUnit, true);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  public IEnumerator onStartSceneAsync(PlayerUnit playerUnit, bool newFlag)
  {
    IEnumerator e = this.onStartSceneAsync(playerUnit, newFlag, true);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  public IEnumerator onStartSceneAsync(
    PlayerUnit playerUnit,
    bool newFlag,
    bool fixedBG)
  {
    Gacha0068Scene gacha0068Scene = this;
    RenderSettings.ambientLight = Singleton<NGGameDataManager>.GetInstance().baseAmbientLight;
    IEnumerator e = gacha0068Scene.SetBackGround(fixedBG);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    if ((Object) gacha0068Scene.menu == (Object) null)
    {
      Future<GameObject> handler = Res.Prefabs.gacha006_8.MainPanel.Load<GameObject>();
      e = handler.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      gacha0068Scene.menu = handler.Result.Clone(gacha0068Scene.transform).GetComponent<Gacha0068Menu>();
      gacha0068Scene.menu.GetComponent<UIPanel>().SetAnchor(gacha0068Scene.transform);
      handler = (Future<GameObject>) null;
    }
    gacha0068Scene.menuBase = (NGMenuBase) gacha0068Scene.menu;
    gacha0068Scene.menuBase.IsPush = false;
    e = gacha0068Scene.menu.Set(playerUnit, newFlag);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  public void onStartScene()
  {
    Singleton<PopupManager>.GetInstance().closeAll();
    this.StartCoroutine(this.ResultEffect());
  }

  public void onStartScene(PlayerUnit playerUnit, bool newFlag)
  {
    Singleton<PopupManager>.GetInstance().closeAll();
    this.StartCoroutine(this.ResultEffect());
    this.util = this.GetComponent<RenderTextureRecoveryUtil>();
    if (!((Object) this.util != (Object) null))
      return;
    this.util.SaveRenderTexture();
  }

  public void onStartScene(PlayerUnit playerUnit, bool newFlag, bool fixedBG)
  {
    Singleton<PopupManager>.GetInstance().closeAll();
    this.StartCoroutine(this.ResultEffect());
  }

  public IEnumerator ResultEffect()
  {
    Gacha0068Scene gacha0068Scene = this;
    if (GachaResultData.GetInstance().IsPopupEffect())
    {
      gacha0068Scene.menu.BackSceneButton.gameObject.SetActive(false);
      Singleton<CommonRoot>.GetInstance().SetFooterEnable(false);
      IEnumerator e = gacha0068Scene.SheetGachaResult();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      e = gacha0068Scene.CharacterStory();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      e = gacha0068Scene.CoinAcquisition();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      gacha0068Scene.menu.BackSceneButton.gameObject.SetActive(true);
      Singleton<CommonRoot>.GetInstance().SetFooterEnable(true);
    }
    gacha0068Scene.menu.EnableBackScene = true;
    if (!GachaResultData.GetInstance().GetData().is_retry && gacha0068Scene.IsPickupResult() && (gacha0068Scene.IsAppReviewEnable() && SMManager.Observe<Player>().Value.level >= 150))
      PopupAppReview.Show((MonoBehaviour) gacha0068Scene);
  }

  private bool IsPickupResult()
  {
    bool flag = false;
    foreach (GachaResultData.Result result in GachaResultData.GetInstance().GetData().GetResultData())
    {
      if (result.directionType == GachaDirectionType.pickup)
      {
        flag = true;
        break;
      }
    }
    return flag;
  }

  private bool IsAppReviewEnable() => Singleton<NGGameDataManager>.GetInstance().isReviewPopupCurrentGacha;

  public IEnumerator SheetGachaResult()
  {
    IEnumerator e = GachaResultData.GetInstance().SheetGachaResultPopup();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  public IEnumerator CharacterStory()
  {
    IEnumerator e = GachaResultData.GetInstance().CharacterStoryPopup();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  private IEnumerator CoinAcquisition()
  {
    IEnumerator e = GachaResultData.GetInstance().CoinAcquisitionPopup();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  private IEnumerator SetBackGround(bool fixedBG)
  {
    Gacha0068Scene gacha0068Scene = this;
    Future<GameObject> fBG = fixedBG ? Res.Prefabs.BackGround.GachaTopBackground.Load<GameObject>() : Res.Prefabs.BackGround.UnitBackground.Load<GameObject>();
    IEnumerator e = fBG.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    gacha0068Scene.backgroundPrefab = fBG.Result;
    gacha0068Scene.backgroundPrefab.GetComponent<UI2DSprite>().color = Consts.GetInstance().GACHA_RESULT_BACKGROUND_COLOR;
  }

  private void Update()
  {
    if (!((Object) this.util != (Object) null))
      return;
    this.util.FixRenderTexture();
  }
}
