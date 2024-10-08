﻿// Decompiled with JetBrains decompiler
// Type: ShopTopScene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using UnityEngine;

public class ShopTopScene : NGSceneBase
{
  [SerializeField]
  private ShopTopMenu menu;
  private WebAPI.Response.ShopStatus shopStatus;

  public static void ChangeScene(bool stack) => Singleton<NGSceneManager>.GetInstance().changeScene("shop007_Top", stack);

  public override IEnumerator onInitSceneAsync()
  {
    Singleton<CommonRoot>.GetInstance().ShowLoadingLayer(0);
    yield return (object) ShopCommon.Init();
    Future<WebAPI.Response.ShopStatus> shoplistF = WebAPI.ShopStatus((System.Action<WebAPI.Response.UserError>) (e =>
    {
      WebAPI.DefaultUserErrorCallback(e);
      MypageScene.ChangeSceneOnError();
    })).Then<WebAPI.Response.ShopStatus>((Func<WebAPI.Response.ShopStatus, WebAPI.Response.ShopStatus>) (result =>
    {
      Singleton<NGGameDataManager>.GetInstance().Parse(result);
      return result;
    }));
    IEnumerator e1 = shoplistF.Wait();
    while (e1.MoveNext())
      yield return e1.Current;
    e1 = (IEnumerator) null;
    this.shopStatus = shoplistF.Result;
  }

  public IEnumerator onStartSceneAsync()
  {
    Singleton<CommonRoot>.GetInstance().ShowLoadingLayer(0);
    IEnumerator e = this.menu.Init(this.shopStatus);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    Singleton<CommonRoot>.GetInstance().HideLoadingLayer();
  }

  public void onStartScene() => this.StartCoroutine(this.menu.InitAnimation());

  private void OnDestroy()
  {
    NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
    if ((bool) (UnityEngine.Object) instance)
      instance.stopVoice();
    if (!((UnityEngine.Object) ShopBackgroundAnimation.CurrentShopBackground != (UnityEngine.Object) null))
      return;
    UnityEngine.Object.Destroy((UnityEngine.Object) ShopBackgroundAnimation.CurrentShopBackground);
    ShopBackgroundAnimation.CurrentShopBackground = (GameObject) null;
  }
}
