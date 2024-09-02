// Decompiled with JetBrains decompiler
// Type: BannerLimitEmphasie
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class BannerLimitEmphasie : MonoBehaviour
{
  [SerializeField]
  private GameObject slcBase;
  [SerializeField]
  private GameObject slcFor;
  [SerializeField]
  private GameObject dirDays;
  [SerializeField]
  private GameObject dirHours;
  [SerializeField]
  private GameObject dirHoursEff;
  [SerializeField]
  private GameObject dirMinutes;
  [SerializeField]
  private GameObject dirMinutesEff;
  [SerializeField]
  private UISprite digit01Day;
  [SerializeField]
  private UISprite digit10Day;
  [SerializeField]
  private UISprite digitCenterDay;
  [SerializeField]
  private UISprite digit01Hours;
  [SerializeField]
  private UISprite digit10Hours;
  [SerializeField]
  private UISprite digitCenterHours;
  [SerializeField]
  private UISprite digit01HoursEff;
  [SerializeField]
  private UISprite digit10HoursEff;
  [SerializeField]
  private UISprite digitCenterHoursEff;
  [SerializeField]
  private UISprite digit01Minutes;
  [SerializeField]
  private UISprite digit10Minutes;
  [SerializeField]
  private UISprite digitCenterMinutes;
  [SerializeField]
  private UISprite digit01MinutesEff;
  [SerializeField]
  private UISprite digit10MinutesEff;
  [SerializeField]
  private UISprite digitCenterMinutesEff;

  [DebuggerHidden]
  public IEnumerator Init(DateTime serverTime, DateTime? EndTime)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BannerLimitEmphasie.\u003CInit\u003Ec__IteratorB79()
    {
      EndTime = EndTime,
      serverTime = serverTime,
      \u003C\u0024\u003EEndTime = EndTime,
      \u003C\u0024\u003EserverTime = serverTime,
      \u003C\u003Ef__this = this
    };
  }
}
