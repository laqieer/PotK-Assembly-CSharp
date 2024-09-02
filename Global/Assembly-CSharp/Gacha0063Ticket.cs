// Decompiled with JetBrains decompiler
// Type: Gacha0063Ticket
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Gacha0063Ticket : Gacha0063hindicator
{
  private const float INTERVAL = 30f;
  [SerializeField]
  private UI2DSprite TopImg;
  [SerializeField]
  private UI2DSprite TitleImg;
  [SerializeField]
  private UILabel GachaTickets;
  [SerializeField]
  private UILabel GachaTerm;
  [SerializeField]
  private UIButton m_detailButton;
  private GachaModuleGacha Gacha;
  private TicketBanner BannerInfo;
  private float Timer = 30f;

  public override void InitGachaModuleGacha(Gacha0063Menu menu, GachaModuleGacha gacha)
  {
    this.Menu = menu;
    this.Gacha = gacha;
    this.BannerInfo = ((IEnumerable<TicketBanner>) SMManager.Get<TicketBanner[]>()).FirstOrDefault<TicketBanner>((Func<TicketBanner, bool>) (i => i.gacha_id == gacha.id));
    this.singleGachaButton.Init(string.Empty, gacha, this.Menu, 4);
  }

  [DebuggerHidden]
  public override IEnumerator Set(GameObject detailPopup)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0063Ticket.\u003CSet\u003Ec__Iterator384()
    {
      detailPopup = detailPopup,
      \u003C\u0024\u003EdetailPopup = detailPopup,
      \u003C\u003Ef__this = this
    };
  }

  public void Update()
  {
    this.Timer -= Time.deltaTime;
    if ((double) this.Timer > 0.0)
      return;
    this.StartCoroutine(this.GetTerm(this.Gacha.end_at));
    this.Timer = 30f;
  }

  [DebuggerHidden]
  private IEnumerator GetTerm(DateTime? endAt)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0063Ticket.\u003CGetTerm\u003Ec__Iterator385()
    {
      endAt = endAt,
      \u003C\u0024\u003EendAt = endAt,
      \u003C\u003Ef__this = this
    };
  }

  private static string GetTerm(TimeSpan diff)
  {
    double num = Math.Floor(diff.TotalMinutes);
    string term;
    if (num > 1440.0)
      term = Consts.Lookup("GACHA_0063TICKET_LIMIT_DAY", (IDictionary) new Hashtable()
      {
        {
          (object) "day",
          (object) Math.Floor(diff.TotalDays).ToString()
        }
      });
    else if (num > 60.0)
      term = Consts.Lookup("GACHA_0063TICKET_LIMIT_HOUR", (IDictionary) new Hashtable()
      {
        {
          (object) "hour",
          (object) Math.Floor(diff.TotalHours).ToString()
        }
      });
    else
      term = Consts.Lookup("GACHA_0063TICKET_LIMIT_MIN", (IDictionary) new Hashtable()
      {
        {
          (object) "min",
          (object) Math.Floor(diff.TotalMinutes).ToString()
        }
      });
    return term;
  }

  [DebuggerHidden]
  private IEnumerator InitDetailButton(GachaModuleGacha gacha, GameObject detailPopup)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0063Ticket.\u003CInitDetailButton\u003Ec__Iterator386()
    {
      gacha = gacha,
      detailPopup = detailPopup,
      \u003C\u0024\u003Egacha = gacha,
      \u003C\u0024\u003EdetailPopup = detailPopup,
      \u003C\u003Ef__this = this
    };
  }

  private void SetDetailButton(GachaModuleGacha gacha, GameObject detailPopup)
  {
    GachaDescription details = gacha.details;
    EventDelegate.Add(this.m_detailButton.onClick, (EventDelegate.Callback) (() =>
    {
      if (this.Menu.IsPushAndSet())
        return;
      Singleton<CommonRoot>.GetInstance().loadingMode = 1;
      Singleton<CommonRoot>.GetInstance().isLoading = true;
      this.StartCoroutine(this.OpenDetailPopup(gacha, detailPopup));
    }));
  }

  [DebuggerHidden]
  private IEnumerator OpenDetailPopup(GachaModuleGacha gacha, GameObject detailPopup)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0063Ticket.\u003COpenDetailPopup\u003Ec__Iterator387()
    {
      gacha = gacha,
      detailPopup = detailPopup,
      \u003C\u0024\u003Egacha = gacha,
      \u003C\u0024\u003EdetailPopup = detailPopup,
      \u003C\u003Ef__this = this
    };
  }
}
