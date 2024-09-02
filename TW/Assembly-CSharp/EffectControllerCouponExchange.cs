// Decompiled with JetBrains decompiler
// Type: EffectControllerCouponExchange
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class EffectControllerCouponExchange : EffectController
{
  [SerializeField]
  private CommonRarityAnim rarityAnim_;
  [SerializeField]
  private GameObject effNew_;
  [SerializeField]
  private GachaSEAfterUser SE_;
  [NonSerialized]
  public EventDelegate.Callback callbackOnFinishedEffect_;

  private void initializeLocal()
  {
    this.SE_.result = false;
    this.back_button_.SetActive(false);
  }

  [DebuggerHidden]
  public IEnumerator coExchangeUnit(WebAPI.Response.UnitticketSpend unitticketSpend)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new EffectControllerCouponExchange.\u003CcoExchangeUnit\u003Ec__Iterator9C3()
    {
      unitticketSpend = unitticketSpend,
      \u003C\u0024\u003EunitticketSpend = unitticketSpend,
      \u003C\u003Ef__this = this
    };
  }

  public void onFinishedEffect()
  {
    if (this.callbackOnFinishedEffect_ == null)
      return;
    this.callbackOnFinishedEffect_();
  }

  private void Start() => this.SE_.OnPlayResult();
}
