// Decompiled with JetBrains decompiler
// Type: Gacha0063Point
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Gacha0063Point : Gacha0063hindicator
{
  private const int GachaButtonMax = 2;
  [SerializeField]
  private UI2DSprite bannerSprite;
  [SerializeField]
  private GameObject dirBtnSingle;
  [SerializeField]
  private GameObject dirBtnDouble;
  [SerializeField]
  private GameObject dirBtnSingleLimit;
  [SerializeField]
  private GameObject slcStepUPBase;
  [SerializeField]
  private UISprite slcDenominator;
  [SerializeField]
  private UISprite slcNumerator;
  private bool isSingleLimit;

  public override void InitGachaModuleGacha(
    Gacha0063Menu gacha0063Menu,
    GachaModule gachaModule,
    DateTime serverTime,
    UIScrollView scrollView)
  {
    SMManager.Get<Player>();
    this.GachaModule = gachaModule;
    this.Menu = gacha0063Menu;
    this.isSingleLimit = false;
    if (gachaModule.gacha.Length > 1)
    {
      this.dirBtnDouble.SetActive(true);
      this.dirBtnSingle.SetActive(false);
      this.dirBtnSingleLimit.SetActive(false);
      ((IEnumerable<GachaModuleGacha>) gachaModule.gacha).ForEachIndex<GachaModuleGacha>((Action<GachaModuleGacha, int>) ((x, n) => this.gachaButton[n].Init(gachaModule.name, x, this.Menu, gachaModule.number)));
    }
    else
    {
      if (gachaModule.gacha.Length != 1)
        return;
      this.dirBtnDouble.SetActive(false);
      this.dirBtnSingle.SetActive(false);
      this.dirBtnSingleLimit.SetActive(false);
      this.slcStepUPBase.SetActive(false);
      int num1 = 0;
      int num2 = 0;
      if (gachaModule.gacha[0].limit.HasValue)
      {
        num2 = gachaModule.gacha[0].count;
        num1 = gachaModule.gacha[0].limit.Value;
      }
      else if (gachaModule.gacha[0].daily_limit.HasValue)
      {
        num2 = gachaModule.gacha[0].daily_count;
        num1 = gachaModule.gacha[0].daily_limit.Value;
      }
      if (num1 > 0)
      {
        this.dirBtnSingleLimit.SetActive(true);
        this.slcStepUPBase.SetActive(true);
        this.isSingleLimit = true;
        string name1 = string.Format("slc_StepUpSmall_num{0}.png__GUI__006-3_sozai__006-3_sozai_prefab", (object) num1);
        UISpriteData sprite1 = this.slcDenominator.atlas.GetSprite(name1);
        if (sprite1 != null)
        {
          this.slcDenominator.SetDimensions(sprite1.width, sprite1.height);
          this.slcDenominator.spriteName = name1;
        }
        string name2 = string.Format("slc_StepUp_num{0}.png__GUI__006-3_sozai__006-3_sozai_prefab", (object) num2);
        UISpriteData sprite2 = this.slcNumerator.atlas.GetSprite(name2);
        if (sprite2 != null)
        {
          this.slcNumerator.SetDimensions(sprite2.width, sprite2.height);
          this.slcNumerator.spriteName = name2;
        }
        this.singleGachaButtonEx.Init(gachaModule.name, gachaModule.gacha[0], this.Menu, gachaModule.number);
      }
      else
      {
        this.dirBtnSingle.SetActive(true);
        this.singleGachaButton.Init(gachaModule.name, gachaModule.gacha[0], this.Menu, gachaModule.number);
      }
    }
  }

  private void SetGachBtnInfo(Player playerData, GachaButton btn, GachaModuleGacha gachaData)
  {
    UISprite component1 = ((Component) btn).GetComponent<UISprite>();
    UISprite[] componentsInChildren = ((Component) btn).GetComponentsInChildren<UISprite>();
    UIButton component2 = ((Component) btn).GetComponent<UIButton>();
    int max_play_nam1 = !gachaData.max_roll_count.HasValue ? 0 : gachaData.max_roll_count.Value;
    if (max_play_nam1 == 0)
      return;
    int max_play_nam2 = Mathf.Clamp(playerData.friend_point / gachaData.payment_amount, 0, max_play_nam1);
    if (max_play_nam1 == 1)
    {
      if (max_play_nam2 >= 1)
      {
        component1.color = PunkColor.button_on;
        ((IEnumerable<UISprite>) componentsInChildren).ForEach<UISprite>((Action<UISprite>) (x => x.color = PunkColor.button_on));
        ((Behaviour) component2).enabled = true;
      }
      else
      {
        component1.color = PunkColor.button_off;
        ((IEnumerable<UISprite>) componentsInChildren).ForEach<UISprite>((Action<UISprite>) (x => x.color = PunkColor.button_off));
        ((Behaviour) component2).enabled = false;
      }
    }
    else
    {
      btn.SetMaxPlayNum(max_play_nam2);
      if (max_play_nam2 >= 2)
      {
        component1.color = PunkColor.button_on;
        this.ChangeColor(((Component) btn).transform, PunkColor.button_on);
        ((Behaviour) component2).enabled = true;
      }
      else
      {
        btn.SetMaxPlayNum(max_play_nam1);
        component1.color = PunkColor.button_off;
        this.ChangeColor(((Component) btn).transform, PunkColor.button_off);
        ((Behaviour) component2).enabled = false;
      }
    }
  }

  [DebuggerHidden]
  public override IEnumerator Set(GameObject detailPopup)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0063Point.\u003CSet\u003Ec__Iterator383()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void ChangeColor(Transform trans, Color color)
  {
    UISprite component = ((Component) trans).GetComponent<UISprite>();
    if (Object.op_Inequality((Object) component, (Object) null))
      component.color = color;
    trans.GetChildren().ForEach<Transform>((Action<Transform>) (x => this.ChangeColor(x, color)));
  }
}
