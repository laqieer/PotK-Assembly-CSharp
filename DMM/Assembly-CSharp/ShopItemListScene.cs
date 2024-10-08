﻿// Decompiled with JetBrains decompiler
// Type: ShopItemListScene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using UnityEngine;

public class ShopItemListScene : NGSceneBase
{
  [SerializeField]
  private GameObject mainPanel;
  [SerializeField]
  private ShopItemListMenu menu;

  public static void ChangeScene(int shopId, int bannerId, string shopName, string shopTime) => Singleton<NGSceneManager>.GetInstance().changeScene("shop007_4_new", true, (object) shopId, (object) bannerId, (object) shopName, (object) shopTime);

  public override IEnumerator onInitSceneAsync()
  {
    Singleton<CommonRoot>.GetInstance().ShowLoadingLayer(1);
    yield break;
  }

  public IEnumerator onStartSceneAsync(
    int shopId,
    int bannerId,
    string shopName,
    string shopTime)
  {
    Future<GameObject> f;
    IEnumerator e;
    if (shopId == 5000)
    {
      if (ShopBackgroundAnimation.CurrentShopBackground.name != "ShopLimitedBackground(Clone)")
      {
        f = Singleton<ResourceManager>.GetInstance().Load<GameObject>("Prefabs/BackGround/ShopLimitedBackground");
        e = f.Wait();
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
        Singleton<CommonRoot>.GetInstance().setBackground(f.Result);
        f = (Future<GameObject>) null;
      }
      Persist.lastAccessTime.Data.UpdateLimitedShopLatestLoginTimes(bannerId);
      e = Singleton<CommonRoot>.GetInstance().UpdateFooterLimitedShopButton();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
    }
    else if ((Object) ShopBackgroundAnimation.CurrentShopBackground != (Object) null && ShopBackgroundAnimation.CurrentShopBackground.name != "ShopBackground(Clone)")
    {
      f = Res.Prefabs.BackGround.ShopBackground.Load<GameObject>();
      e = f.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      Singleton<CommonRoot>.GetInstance().setBackground(f.Result);
      f = (Future<GameObject>) null;
    }
    this.mainPanel.GetComponent<UIPanel>().alpha = 0.0f;
    yield return (object) this.menu.Init(shopId, bannerId, shopName, shopTime);
    Singleton<CommonRoot>.GetInstance().HideLoadingLayer();
  }

  public override void onSceneInitialized() => this.StartCoroutine(this.FadeIn());

  private IEnumerator FadeIn()
  {
    yield return (object) null;
    TweenAlpha orAddComponent = this.mainPanel.GetOrAddComponent<TweenAlpha>();
    orAddComponent.from = 0.0f;
    orAddComponent.to = 1f;
    orAddComponent.style = UITweener.Style.Once;
    orAddComponent.duration = 0.2f;
    orAddComponent.animationCurve = new AnimationCurve();
    orAddComponent.animationCurve.AddKey(new Keyframe(0.0f, 0.0f, 2f, 2f));
    orAddComponent.animationCurve.AddKey(new Keyframe(1f, 1f, 0.0f, 0.0f));
  }
}
