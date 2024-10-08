﻿// Decompiled with JetBrains decompiler
// Type: Unit00420StatusGauge
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit00420StatusGauge : MonoBehaviour
{
  private const int DIR_UPPT_ENABLE = 0;
  private const int DIR_UPPT_DISABLE = 1;
  private const int HP_MAX = 198;
  private const int STATUS_MAX = 99;
  private const int GUAGE_WIDTH = 99;
  [SerializeField]
  private GameObject StatusMaxStar;
  [SerializeField]
  private UILabel txtValue;
  [SerializeField]
  private UILabel txtBuildupValue;
  [SerializeField]
  private UILabel txtValueMax;
  [SerializeField]
  private GameObject[] dirUppt;
  [SerializeField]
  private UILabel txtUppt;
  [SerializeField]
  private UISprite blueGauge;
  [SerializeField]
  private UISprite greenGauge;
  [SerializeField]
  private UISprite yellowGauge;
  [SerializeField]
  private UISprite blueMaxGauge;
  [SerializeField]
  private UISprite whiteGauge;
  [SerializeField]
  private UISprite whiteAddGauge;

  private void SetGaugeInfo(UISprite gauge, int width, float posX)
  {
    gauge.width = width;
    gauge.transform.localPosition = new Vector3(posX, 0.0f, 0.0f);
  }

  private int getGaugeWidth(int w, int v, int max)
  {
    if (v == 0)
      return 0;
    int num = (int) Math.Round((double) w * ((double) Math.Min(v, max) / (double) max));
    return num == 0 ? 1 : num;
  }

  private void SetGauge(
    int baseValue,
    int buildupValue,
    int composeValue,
    int inc,
    int buildupInc,
    int max,
    bool isComposeMax)
  {
    int gaugeWidth1 = this.getGaugeWidth(99, buildupValue, max);
    int gaugeWidth2 = this.getGaugeWidth(99, buildupInc, max);
    int gaugeWidth3 = this.getGaugeWidth(99, composeValue, max);
    int gaugeWidth4 = this.getGaugeWidth(99, inc, max);
    int width = this.getGaugeWidth(99, baseValue + inc + buildupInc, max) - gaugeWidth1 - gaugeWidth2 - gaugeWidth3 - gaugeWidth4;
    if (baseValue - buildupValue - composeValue != 0 && width < 1)
      width = 1;
    float posX1 = this.blueGauge.transform.localPosition.x + (float) width;
    float posX2 = posX1 + (float) gaugeWidth1;
    float posX3 = posX2 + (float) gaugeWidth2;
    float posX4 = posX3 + (float) gaugeWidth3;
    this.SetGaugeInfo(this.blueGauge, width, this.blueGauge.transform.localPosition.x);
    this.SetGaugeInfo(this.whiteGauge, gaugeWidth1, posX1);
    this.SetGaugeInfo(this.whiteAddGauge, gaugeWidth2, posX2);
    this.SetGaugeInfo(this.greenGauge, gaugeWidth3, posX3);
    this.SetGaugeInfo(this.blueMaxGauge, gaugeWidth3, posX3);
    this.SetGaugeInfo(this.yellowGauge, gaugeWidth4, posX4);
    this.blueGauge.gameObject.SetActive((uint) width > 0U);
    this.yellowGauge.gameObject.SetActive((uint) gaugeWidth4 > 0U);
    this.whiteGauge.gameObject.SetActive((uint) gaugeWidth1 > 0U);
    this.whiteAddGauge.gameObject.SetActive((uint) gaugeWidth2 > 0U);
    if (isComposeMax)
    {
      this.greenGauge.gameObject.SetActive(false);
      this.blueMaxGauge.gameObject.SetActive(true);
    }
    else
    {
      this.greenGauge.gameObject.SetActive((uint) gaugeWidth3 > 0U);
      this.blueMaxGauge.gameObject.SetActive(false);
    }
  }

  public void Init(
    PlayerUnit basePlayerUnit,
    PlayerUnit[] materialPlayerUnits,
    CalcUnitCompose.ComposeType type,
    int tValue,
    int maxValue,
    int cValuse,
    int lValue,
    int bValue,
    int buildUpCnt,
    int buildUpMax,
    bool isMax,
    int gaugeMax)
  {
    int buildupMaterialCnt = CalcUnitCompose.getBuildupMaterialCnt(materialPlayerUnits, type);
    int composeValue = CalcUnitCompose.getComposeValue(basePlayerUnit, materialPlayerUnits, type);
    int buildupValue = CalcUnitCompose.getBuildupValue(basePlayerUnit, materialPlayerUnits, type);
    this.txtValue.color = composeValue != 0 || buildupValue != 0 ? Color.yellow : Color.white;
    this.txtValue.SetTextLocalize(tValue + buildupValue + composeValue);
    this.txtBuildupValue.SetTextLocalize(lValue + bValue + buildupValue);
    this.txtValueMax.SetTextLocalize(Consts.Format(Consts.GetInstance().UNIT_00420_STATUS_GAUGE_VALUE_MAX, (IDictionary) new Hashtable()
    {
      {
        (object) "max",
        (object) maxValue
      }
    }));
    Hashtable hashtable1;
    if (buildupMaterialCnt != 0)
    {
      hashtable1 = new Hashtable()
      {
        {
          (object) "now",
          (object) string.Format("[ffff00]{0}[-]", (object) (buildUpCnt + buildupMaterialCnt))
        },
        {
          (object) "max",
          (object) buildUpMax
        }
      };
    }
    else
    {
      hashtable1 = new Hashtable();
      hashtable1.Add((object) "now", (object) buildUpCnt);
      hashtable1.Add((object) "max", (object) buildUpMax);
    }
    Hashtable hashtable2 = hashtable1;
    string text = Consts.Format(Consts.GetInstance().UNIT_00420_STATUS_ENFORCE_INFO, (IDictionary) hashtable2);
    this.txtUppt.SetTextLocalize(buildUpCnt + buildupMaterialCnt);
    this.txtUppt.SetTextLocalize(text);
    if (isMax || buildUpCnt >= buildUpMax)
    {
      ((IEnumerable<GameObject>) this.dirUppt).ToggleOnce(1);
      this.txtUppt.effectColor = new Color(0.1843137f, 0.1843137f, 0.1843137f, 1f);
    }
    else
    {
      ((IEnumerable<GameObject>) this.dirUppt).ToggleOnce(0);
      this.txtUppt.effectColor = new Color(0.0f, 0.2745098f, 0.7215686f, 1f);
    }
    this.SetGauge(tValue, bValue, cValuse, composeValue, buildupValue, gaugeMax, CalcUnitCompose.isComposeMax(basePlayerUnit, type));
    this.StatusMaxStar.SetActive(isMax);
  }
}
