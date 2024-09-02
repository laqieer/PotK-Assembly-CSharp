﻿// Decompiled with JetBrains decompiler
// Type: Gacha0063KisekiExtention
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
public class Gacha0063KisekiExtention : MonoBehaviour
{
  [SerializeField]
  private GameObject singleGachaMode;
  [SerializeField]
  private GameObject multiGachaMode;
  [SerializeField]
  private GameObject ExGachaMode;
  [SerializeField]
  private GameObject singleGachaModeEx;
  [SerializeField]
  private GameObject multiGachaModeEx;
  [SerializeField]
  private GameObject stepUp;
  [SerializeField]
  private GameObject buyKiseki;
  [SerializeField]
  private UIButton detailButton;
  [SerializeField]
  private UILabel digitGacha;
  [SerializeField]
  private UILabel digitGachaShadow;
  [SerializeField]
  private UILabel digitKiseki;
  [SerializeField]
  private UILabel digitKisekiShadow;
  [SerializeField]
  private UISprite stepNowText;
  [SerializeField]
  private UISprite stepMaxText;
  [SerializeField]
  private UILabel dateLimitText;
  [SerializeField]
  private UILabel hourLimitText;
  [SerializeField]
  private GameObject Sheet;
  [SerializeField]
  private GameObject[] panel;
  [SerializeField]
  private GameObject SheetChange;
  [SerializeField]
  private UISprite Slash;
  [SerializeField]
  private UISprite Denominator;
  [SerializeField]
  private UISprite Numerator;
  public Gacha0063Menu Menu;
  private bool isSheetDetail = true;
  private bool isAboveDay;

  private void Init()
  {
    this.singleGachaMode.SetActive(false);
    this.multiGachaMode.SetActive(false);
    this.Sheet.SetActive(false);
    this.SheetChange.SetActive(false);
    this.ExGachaMode.SetActive(true);
  }

  public void UpdateSheetInfo()
  {
    GachaG007PlayerSheet[] gachaG007PlayerSheetArray = SMManager.Get<GachaG007PlayerSheet[]>();
    this.stepUp.SetActive(false);
    this.buyKiseki.SetActive(false);
    this.Sheet.SetActive(true);
    this.SheetChange.SetActive(false);
    if (gachaG007PlayerSheetArray[0].total_count.HasValue)
    {
      int? totalCount = gachaG007PlayerSheetArray[0].total_count;
      if ((!totalCount.HasValue ? 0 : (totalCount.Value > 1 ? 1 : 0)) != 0 && gachaG007PlayerSheetArray[0].current_count > 0)
      {
        ((Component) this.Slash).gameObject.SetActive(false);
        this.SheetChange.SetActive(true);
        if (gachaG007PlayerSheetArray[0].total_count.HasValue)
        {
          ((Component) this.Slash).gameObject.SetActive(true);
          this.ChangeSprite(this.Denominator, string.Format("slc_StepUpSmall_num{0}.png__GUI__006-3_sozai__006-3_sozai_prefab", (object) gachaG007PlayerSheetArray[0].total_count));
        }
        if (gachaG007PlayerSheetArray[0].current_count > 0)
          this.ChangeSprite(this.Numerator, string.Format("slc_StepUp_num{0}.png__GUI__006-3_sozai__006-3_sozai_prefab", (object) gachaG007PlayerSheetArray[0].current_count));
      }
    }
    GachaG007PlayerPanel[] array = ((IEnumerable<GachaG007PlayerPanel>) gachaG007PlayerSheetArray[0].player_panels).OrderBy<GachaG007PlayerPanel, int>((Func<GachaG007PlayerPanel, int>) (x => x.position)).ToArray<GachaG007PlayerPanel>();
    int num = ((IEnumerable<GachaG007PlayerPanel>) array).Count<GachaG007PlayerPanel>();
    for (int index = 0; index < num; ++index)
    {
      this.panel[index].transform.Clear();
      Gacha0063DirPanel gacha0063DirPanel = !array[index].highlight ? this.Menu.scene.dirPanel.Clone(this.panel[index].transform).GetComponent<Gacha0063DirPanel>() : this.Menu.scene.dirPanelSpecial.Clone(this.panel[index].transform).GetComponent<Gacha0063DirPanel>();
      gacha0063DirPanel.onObject.SetActive(true);
      gacha0063DirPanel.offObject.SetActive(false);
      if (array[index].is_opened)
      {
        gacha0063DirPanel.onObject.SetActive(false);
        gacha0063DirPanel.offObject.SetActive(true);
      }
    }
  }

  private void InitSheetGacha() => this.UpdateSheetInfo();

  private void DispStepUp(bool canDisp)
  {
    this.stepUp.SetActive(canDisp);
    this.buyKiseki.SetActive(!canDisp);
  }

  private void SetStepUp(int? now, int? max)
  {
    if (!now.HasValue || !max.HasValue)
    {
      this.DispStepUp(false);
    }
    else
    {
      this.DispStepUp(true);
      this.ChangeSprite(this.stepNowText, "slc_StepUp_num" + now.ToString() + ".png__GUI__006-3_sozai__006-3_sozai_prefab");
      this.ChangeSprite(this.stepMaxText, "slc_StepUpSmall_num" + max.ToString() + ".png__GUI__006-3_sozai__006-3_sozai_prefab");
    }
  }

  private void DispGachaModeEx(int num)
  {
    if (num == 1)
    {
      this.singleGachaModeEx.SetActive(true);
      this.multiGachaModeEx.SetActive(false);
    }
    else
    {
      this.singleGachaModeEx.SetActive(false);
      this.multiGachaModeEx.SetActive(true);
    }
  }

  private void SetGachaSprite(int num)
  {
    this.digitGacha.SetText(num.ToString() + Consts.Lookup("UI_GACHA_RECRUIT_X"));
    this.digitGachaShadow.SetText(num.ToString() + Consts.Lookup("UI_GACHA_RECRUIT_X"));
  }

  private void SetKisekiSprite(int amount)
  {
    this.digitKiseki.SetText("x" + amount.ToString());
    this.digitKisekiShadow.SetText("x" + amount.ToString());
  }

  private void SetGacha(int num, int amount)
  {
    this.DispGachaModeEx(num);
    this.SetGachaSprite(num);
    this.SetKisekiSprite(amount);
  }

  private void DispDetailButton(bool canDisp)
  {
    ((Component) this.detailButton).gameObject.SetActive(canDisp);
  }

  private void SetDetailButton(GachaModule module, GameObject detailPopup)
  {
    if (module.description.title == null)
      this.DispDetailButton(false);
    else
      EventDelegate.Add(this.detailButton.onClick, (EventDelegate.Callback) (() =>
      {
        if (this.Menu.IsPushAndSet())
          return;
        Singleton<CommonRoot>.GetInstance().loadingMode = 1;
        Singleton<CommonRoot>.GetInstance().isLoading = true;
        this.StartCoroutine(this.OpenDetailPopup(module, detailPopup));
      }));
  }

  [DebuggerHidden]
  private IEnumerator OpenDetailPopup(GachaModule module, GameObject detailPopup)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0063KisekiExtention.\u003COpenDetailPopup\u003Ec__Iterator380()
    {
      module = module,
      detailPopup = detailPopup,
      \u003C\u0024\u003Emodule = module,
      \u003C\u0024\u003EdetailPopup = detailPopup
    };
  }

  [DebuggerHidden]
  public IEnumerator InitDetail(GachaModule module, GameObject detailPopup, Gacha0063Menu menu)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0063KisekiExtention.\u003CInitDetail\u003Ec__Iterator381()
    {
      module = module,
      detailPopup = detailPopup,
      \u003C\u0024\u003Emodule = module,
      \u003C\u0024\u003EdetailPopup = detailPopup,
      \u003C\u003Ef__this = this
    };
  }

  private void DispTimeLimit(bool canDisp)
  {
    ((Component) ((Component) this.dateLimitText).transform.parent).gameObject.SetActive(canDisp);
    ((Component) ((Component) this.hourLimitText).transform.parent).gameObject.SetActive(canDisp);
  }

  private void SwitchTimeLimit(bool isAboveDay)
  {
    this.isAboveDay = isAboveDay;
    ((Component) ((Component) this.dateLimitText).transform.parent).gameObject.SetActive(isAboveDay);
    ((Component) ((Component) this.hourLimitText).transform.parent).gameObject.SetActive(!isAboveDay);
  }

  public void UpdateLimitTime(GachaModule module, DateTime serverTime)
  {
    TimeSpan? nullable1 = new TimeSpan?();
    DateTime? endAt = module.period.end_at;
    TimeSpan? nullable2 = !endAt.HasValue ? new TimeSpan?() : new TimeSpan?(endAt.Value - serverTime);
    int days = nullable2.Value.Days;
    int hours = nullable2.Value.Hours;
    int minutes = nullable2.Value.Minutes;
    int seconds = nullable2.Value.Seconds;
    if (nullable2.Value.Milliseconds < 0)
      return;
    if (days > 0)
    {
      this.dateLimitText.SetTextLocalize(Consts.Lookup("GACHA_0063KISEKI_TIME_LIMIT_DAY", (IDictionary) new Hashtable()
      {
        {
          (object) "day",
          (object) days
        }
      }));
    }
    else
    {
      if (this.isAboveDay)
        this.SwitchTimeLimit(false);
      this.hourLimitText.SetTextLocalize(Consts.Lookup("GACHA_0063KISEKI_TIME_LIMIT", (IDictionary) new Hashtable()
      {
        {
          (object) "hour",
          (object) string.Format("{0:00}", (object) hours)
        },
        {
          (object) "min",
          (object) string.Format("{0:00}", (object) minutes)
        },
        {
          (object) "sec",
          (object) string.Format("{0:00}", (object) seconds)
        }
      }));
    }
  }

  public void SetTimiLimit(GachaModule module)
  {
    if (module.period.display_count_down && module.period.end_at.HasValue)
    {
      if (module.period.end_at.Value.Day > 0)
        this.SwitchTimeLimit(true);
      else
        this.SwitchTimeLimit(false);
    }
    else
      this.DispTimeLimit(false);
  }

  public void SetKisekiEx(GachaModule module, Gacha0063Menu menu)
  {
    Gacha0063SheetModel gacha0063SheetModel = new Gacha0063SheetModel(module);
    this.Init();
    this.Menu = menu;
    if (gacha0063SheetModel.IsSheetGachaOpen)
      this.InitSheetGacha();
    else
      this.SetStepUp(module.stepup.current_count, module.stepup.total_count);
    this.SetGacha(module.gacha[0].roll_count, module.gacha[0].payment_amount);
  }

  private void ChangeSprite(UISprite target, string newName)
  {
    target.spriteName = newName;
    UISpriteData atlasSprite = target.GetAtlasSprite();
    if (atlasSprite == null)
    {
      Debug.LogWarning((object) "Atlas内のSprite取得失敗");
    }
    else
    {
      target.width = atlasSprite.width;
      target.height = atlasSprite.height;
    }
  }

  public void IbtnProgressSheet()
  {
    if (this.Menu.IsPushAndSet() || !this.isSheetDetail)
      return;
    ((Behaviour) this.Menu.scene.ScrollView).enabled = false;
    this.Menu.isSheetPopup = true;
    this.isSheetDetail = false;
    this.StartCoroutine(this.ShowProgressSheet());
  }

  [DebuggerHidden]
  private IEnumerator ShowProgressSheet()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0063KisekiExtention.\u003CShowProgressSheet\u003Ec__Iterator382()
    {
      \u003C\u003Ef__this = this
    };
  }
}
