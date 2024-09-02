// Decompiled with JetBrains decompiler
// Type: ShopCharge
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

public class ShopCharge : MonoBehaviour
{
  [SerializeField]
  private UIWidget pageUiWidget;
  [SerializeField]
  private NGxScroll scroll;

  public IEnumerator Init(
    PurchaseView purchaseView,
    WebAPI.Response.CoinbonusHistory coinbonusHistory)
  {
    this.pageUiWidget.alpha = 0.0f;
    yield return (object) purchaseView.Init(this.scroll, coinbonusHistory);
    while (!purchaseView.isInitialized)
      yield return (object) null;
    this.scroll.ResolvePosition();
    this.pageUiWidget.alpha = 1f;
  }
}
