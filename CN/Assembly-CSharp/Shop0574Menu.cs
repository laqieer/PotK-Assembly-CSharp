// Decompiled with JetBrains decompiler
// Type: Shop0574Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using Earth;
using MasterDataTable;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop0574Menu : BackButtonMenuBase
{
  [SerializeField]
  private NGxScroll scroll;
  private GameObject ListPrefab;
  private GameObject ConfirmPopupPrefab;
  private GameObject FinalConfirmPopupPrefab;
  private GameObject DetailPopupPrefab;

  [DebuggerHidden]
  public IEnumerator InitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop0574Menu.\u003CInitSceneAsync\u003Ec__Iterator78A()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator StartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop0574Menu.\u003CStartSceneAsync\u003Ec__Iterator78B()
    {
      \u003C\u003Ef__this = this
    };
  }

  public override void onBackButton()
  {
    Singleton<NGSceneManager>.GetInstance().clearStack();
    Singleton<NGSceneManager>.GetInstance().destroyCurrentScene();
    Singleton<NGSceneManager>.GetInstance().changeScene("mypage051");
  }

  private void openDetailPopup(EarthShopArticle article)
  {
    this.StartCoroutine(this.openDetailPopupAsync(article));
  }

  [DebuggerHidden]
  private IEnumerator openDetailPopupAsync(EarthShopArticle article)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop0574Menu.\u003CopenDetailPopupAsync\u003Ec__Iterator78C()
    {
      article = article,
      \u003C\u0024\u003Earticle = article,
      \u003C\u003Ef__this = this
    };
  }

  private void completeBuy(EarthShopArticle article, GameObject thum, int buyNum)
  {
    EarthDataManager instanceOrNull = Singleton<EarthDataManager>.GetInstanceOrNull();
    if (!Object.op_Inequality((Object) instanceOrNull, (Object) null))
      return;
    instanceOrNull.ShopBuy(article, buyNum);
    this.StartCoroutine(this.StartSceneAsync());
    this.StartCoroutine(this.openCompletePopup(article, thum, buyNum));
  }

  private void openConfirmPopup(EarthShopArticle article, GameObject thum)
  {
    GameObject prefab = this.ConfirmPopupPrefab.Clone();
    prefab.GetComponent<Shop0574ConfirmPopup>().Init(article, thum, this.FinalConfirmPopupPrefab, new Action<EarthShopArticle, GameObject, int>(this.completeBuy));
    Singleton<PopupManager>.GetInstance().open(prefab, isCloned: true);
  }

  [DebuggerHidden]
  private IEnumerator openCompletePopup(EarthShopArticle article, GameObject thum, int buyNum)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop0574Menu.\u003CopenCompletePopup\u003Ec__Iterator78D()
    {
      thum = thum,
      article = article,
      buyNum = buyNum,
      \u003C\u0024\u003Ethum = thum,
      \u003C\u0024\u003Earticle = article,
      \u003C\u0024\u003EbuyNum = buyNum
    };
  }
}
