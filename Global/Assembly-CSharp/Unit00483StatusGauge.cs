﻿// Decompiled with JetBrains decompiler
// Type: Unit00483StatusGauge
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System;
using UnityEngine;

#nullable disable
public class Unit00483StatusGauge : MonoBehaviour
{
  private const int HP_MAX = 198;
  private const int STATUS_MAX = 99;
  public GameObject incBase;
  public GameObject paramMaxStar;
  public UILabel valueLabel;
  public UISprite blueGauge;
  public UISprite greenGauge;
  public UISprite yellowGauge;
  public UISprite blueMaxGauge;
  public UISprite whiteGauge;
  public UISprite whiteAddGauge;

  private void SetGaugeInfo(UISprite gauge, int width, float posX)
  {
    gauge.width = width;
    ((Component) gauge).transform.localPosition = new Vector3(posX, 0.0f, 0.0f);
  }

  private int getGaugeWidth(int w, int v, int max, bool reduction)
  {
    Func<int, int> func = (Func<int, int>) (x => Math.Min(x, max));
    return reduction ? (int) Math.Round((double) w * ((double) func(v == 0 ? v : v + 1) / (double) max), MidpointRounding.AwayFromZero) : (int) Math.Round((double) w * ((double) func(v) / (double) max));
  }

  private void SetGauge(
    int baseValue,
    int buildupValue,
    int composeValue,
    int inc,
    int buildupInc,
    int max,
    bool isComposeMax,
    bool reduction)
  {
    this.valueLabel.SetTextLocalize((baseValue + buildupInc + inc).ToString());
    this.valueLabel.color = inc != 0 || buildupInc != 0 ? Color.yellow : Color.white;
    int gaugeWidth1 = this.getGaugeWidth(99, baseValue, max, reduction);
    int gaugeWidth2 = this.getGaugeWidth(99, buildupValue, max, reduction);
    int gaugeWidth3 = this.getGaugeWidth(99, buildupInc, max, reduction);
    int gaugeWidth4 = this.getGaugeWidth(99, composeValue, max, reduction);
    int gaugeWidth5 = this.getGaugeWidth(99, inc, max, reduction);
    float posX1 = ((Component) this.blueGauge).transform.localPosition.x + (float) gaugeWidth1;
    float posX2 = posX1 + (float) gaugeWidth2;
    float posX3 = posX2 + (float) gaugeWidth3;
    float posX4 = posX3 + (float) gaugeWidth4;
    this.SetGaugeInfo(this.blueGauge, gaugeWidth1, ((Component) this.blueGauge).transform.localPosition.x);
    this.SetGaugeInfo(this.whiteGauge, gaugeWidth2, posX1);
    this.SetGaugeInfo(this.whiteAddGauge, gaugeWidth3, posX2);
    this.SetGaugeInfo(this.greenGauge, gaugeWidth4, posX3);
    this.SetGaugeInfo(this.blueMaxGauge, gaugeWidth4, posX3);
    this.SetGaugeInfo(this.yellowGauge, gaugeWidth5, posX4);
    ((Component) this.blueGauge).gameObject.SetActive(gaugeWidth1 != 0);
    ((Component) this.yellowGauge).gameObject.SetActive(gaugeWidth5 != 0);
    ((Component) this.whiteGauge).gameObject.SetActive(gaugeWidth2 != 0);
    ((Component) this.whiteAddGauge).gameObject.SetActive(gaugeWidth3 != 0);
    if (isComposeMax)
    {
      ((Component) this.greenGauge).gameObject.SetActive(false);
      ((Component) this.blueMaxGauge).gameObject.SetActive(true);
    }
    else
    {
      ((Component) this.greenGauge).gameObject.SetActive(gaugeWidth4 != 0);
      ((Component) this.blueMaxGauge).gameObject.SetActive(false);
    }
    this.incBase.SetActive(inc + buildupInc > 0);
    if (!this.incBase.activeSelf)
      return;
    ((Component) this.incBase.transform.Find("txt_Uppt")).GetComponent<UILabel>().SetTextLocalize(inc + buildupInc);
  }

  public void Init(
    PlayerUnit basePlayerUnit,
    PlayerUnit[] materialPlayerUnits,
    CalcUnitCompose.ComposeType type,
    int tValue,
    int cValuse,
    int bValue,
    bool isMax)
  {
    int composeValue = CalcUnitCompose.getComposeValue(basePlayerUnit, materialPlayerUnits, type);
    int buildupValue = CalcUnitCompose.getBuildupValue(basePlayerUnit, materialPlayerUnits, type);
    if (type == CalcUnitCompose.ComposeType.HP)
      this.SetGauge(tValue, bValue, cValuse, composeValue, buildupValue, 198, CalcUnitCompose.isComposeMax(basePlayerUnit, type), true);
    else
      this.SetGauge(tValue, bValue, cValuse, composeValue, buildupValue, 99, CalcUnitCompose.isComposeMax(basePlayerUnit, type), false);
    this.paramMaxStar.SetActive(isMax);
  }
}
