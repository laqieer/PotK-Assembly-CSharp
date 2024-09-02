// Decompiled with JetBrains decompiler
// Type: Gacha0063Ticket
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
  public override IEnumerator Set(
    GameObject detailPopup,
    GameObject textPrefab,
    GameObject spritePrefab)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0063Ticket.\u003CSet\u003Ec__Iterator3FD()
    {
      detailPopup = detailPopup,
      textPrefab = textPrefab,
      spritePrefab = spritePrefab,
      \u003C\u0024\u003EdetailPopup = detailPopup,
      \u003C\u0024\u003EtextPrefab = textPrefab,
      \u003C\u0024\u003EspritePrefab = spritePrefab,
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
    return (IEnumerator) new Gacha0063Ticket.\u003CGetTerm\u003Ec__Iterator3FE()
    {
      endAt = endAt,
      \u003C\u0024\u003EendAt = endAt,
      \u003C\u003Ef__this = this
    };
  }

  private static string GetTerm(TimeSpan diff)
  {
    double num1 = Math.Floor(diff.TotalMinutes);
    string term;
    if (num1 > 1440.0)
    {
      double num2 = Math.Floor(diff.TotalDays);
      term = Consts.Format(Consts.GetInstance().GACHA_0063TICKET_LIMIT_DAY, (IDictionary) new Hashtable()
      {
        {
          (object) "day",
          (object) num2.ToString()
        }
      });
    }
    else if (num1 > 60.0)
    {
      double num3 = Math.Floor(diff.TotalHours);
      term = Consts.Format(Consts.GetInstance().GACHA_0063TICKET_LIMIT_HOUR, (IDictionary) new Hashtable()
      {
        {
          (object) "hour",
          (object) num3.ToString()
        }
      });
    }
    else
    {
      double num4 = Math.Floor(diff.TotalMinutes);
      term = Consts.Format(Consts.GetInstance().GACHA_0063TICKET_LIMIT_MIN, (IDictionary) new Hashtable()
      {
        {
          (object) "min",
          (object) num4.ToString()
        }
      });
    }
    return term;
  }

  [DebuggerHidden]
  private IEnumerator InitDetailButton(
    GachaModuleGacha gacha,
    GameObject detailPopup,
    GameObject textPrefab,
    GameObject spritePrefab)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0063Ticket.\u003CInitDetailButton\u003Ec__Iterator3FF()
    {
      gacha = gacha,
      detailPopup = detailPopup,
      textPrefab = textPrefab,
      spritePrefab = spritePrefab,
      \u003C\u0024\u003Egacha = gacha,
      \u003C\u0024\u003EdetailPopup = detailPopup,
      \u003C\u0024\u003EtextPrefab = textPrefab,
      \u003C\u0024\u003EspritePrefab = spritePrefab,
      \u003C\u003Ef__this = this
    };
  }

  private void SetDetailButton(
    GachaModuleGacha gacha,
    GameObject detailPopup,
    GameObject textPrefab,
    GameObject spritePrefab,
    Texture2D[] detailTextures = null)
  {
    GachaDescription desc = gacha.details;
    EventDelegate.Add(this.m_detailButton.onClick, (EventDelegate.Callback) (() =>
    {
      if (this.Menu.IsPushAndSet())
        return;
      GameObject gameObject = Singleton<PopupManager>.GetInstance().openAlert(detailPopup);
      if (Object.op_Equality((Object) gameObject, (Object) null))
      {
        Debug.LogError((object) ("Can't get popup object from PopupManager: " + ((Object) ((Component) this).gameObject).name));
      }
      else
      {
        Popup00631Menu component = gameObject.GetComponent<Popup00631Menu>();
        if (Object.op_Equality((Object) component, (Object) null))
          Debug.LogError((object) ("Can't get menu object from popup object: " + ((Object) ((Component) this).gameObject).name));
        else
          component.InitGachaDetail(desc.title, desc.bodies, detailTextures, textPrefab, spritePrefab);
      }
    }));
  }
}
