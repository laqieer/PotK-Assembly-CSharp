// Decompiled with JetBrains decompiler
// Type: EffectControllerCouponExchange
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new EffectControllerCouponExchange.\u003CcoExchangeUnit\u003Ec__Iterator8F6()
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
