// Decompiled with JetBrains decompiler
// Type: Gacha0063TicketItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Gacha0063TicketItem : MonoBehaviour
{
  [SerializeField]
  private UILabel mTitleLabel;
  [SerializeField]
  private UI2DSprite mThumSprite;
  [SerializeField]
  private UIButton mPullObject;
  [SerializeField]
  private GameObject mPullDisableObject;
  [SerializeField]
  private UIButton mDetailButton;
  [SerializeField]
  private UILabel mLimitDateLabel;
  [SerializeField]
  private UILabel mNonLimitDateLabel;
  [SerializeField]
  private UILabel mTicketNeed;
  [SerializeField]
  private UILabel mTicketProgressLabel;
  [SerializeField]
  private UILabel mTicketProgressLabelRed;
  [SerializeField]
  private GachaButton gachaButton;
  private Gacha0063Menu mMenu;
  private static readonly List<string> NumberSpriteNameList = new List<string>()
  {
    "slc_gacha_text_0.png__GUI__006-3_sozai__006-3_sozai_prefab.png",
    "slc_gacha_text_1.png__GUI__006-3_sozai__006-3_sozai_prefab.png",
    "slc_gacha_text_2.png__GUI__006-3_sozai__006-3_sozai_prefab.png",
    "slc_gacha_text_3.png__GUI__006-3_sozai__006-3_sozai_prefab.png",
    "slc_gacha_text_4.png__GUI__006-3_sozai__006-3_sozai_prefab.png",
    "slc_gacha_text_5.png__GUI__006-3_sozai__006-3_sozai_prefab.png",
    "slc_gacha_text_6.png__GUI__006-3_sozai__006-3_sozai_prefab.png",
    "slc_gacha_text_7.png__GUI__006-3_sozai__006-3_sozai_prefab.png",
    "slc_gacha_text_8.png__GUI__006-3_sozai__006-3_sozai_prefab.png",
    "slc_gacha_text_9.png__GUI__006-3_sozai__006-3_sozai_prefab.png"
  };
  private static readonly string DateTimeFormat = "yyyy/M/d H:mm";

  [DebuggerHidden]
  public IEnumerator Init(GachaModuleGacha gacha, GameObject detailPopup, Gacha0063Menu menu)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0063TicketItem.\u003CInit\u003Ec__Iterator447()
    {
      gacha = gacha,
      detailPopup = detailPopup,
      menu = menu,
      \u003C\u0024\u003Egacha = gacha,
      \u003C\u0024\u003EdetailPopup = detailPopup,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u003Ef__this = this
    };
  }

  private void SetAmountCount(int amountCount, int haveCount)
  {
    this.mTicketNeed.SetTextLocalize(amountCount);
    if (haveCount >= amountCount)
    {
      ((Component) this.mTicketProgressLabel).gameObject.SetActive(true);
      ((Component) this.mTicketProgressLabelRed).gameObject.SetActive(false);
      this.mTicketProgressLabel.SetTextLocalize(haveCount);
    }
    else
    {
      ((Component) this.mTicketProgressLabel).gameObject.SetActive(false);
      ((Component) this.mTicketProgressLabelRed).gameObject.SetActive(true);
      this.mTicketProgressLabelRed.SetTextLocalize(haveCount);
    }
  }

  private void SetNumberSprite(int number, UISprite sprite)
  {
    sprite.spriteName = Gacha0063TicketItem.NumberSpriteNameList[number];
  }

  private void SetLimitDate(DateTime? date)
  {
    if (date.HasValue)
    {
      ((Component) this.mNonLimitDateLabel).gameObject.SetActive(false);
      ((Component) this.mLimitDateLabel).gameObject.SetActive(true);
      this.mLimitDateLabel.SetTextLocalize(date.Value.ToString(Gacha0063TicketItem.DateTimeFormat));
    }
    else
    {
      ((Component) this.mNonLimitDateLabel).gameObject.SetActive(true);
      ((Component) this.mLimitDateLabel).gameObject.SetActive(false);
    }
  }

  private void SetDetailButton(GachaModuleGacha gacha, GameObject detailPopup)
  {
    EventDelegate.Add(this.mDetailButton.onClick, (EventDelegate.Callback) (() =>
    {
      if (this.mMenu.IsPushAndSet())
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
    return (IEnumerator) new Gacha0063TicketItem.\u003COpenDetailPopup\u003Ec__Iterator448()
    {
      gacha = gacha,
      detailPopup = detailPopup,
      \u003C\u0024\u003Egacha = gacha,
      \u003C\u0024\u003EdetailPopup = detailPopup,
      \u003C\u003Ef__this = this
    };
  }
}
