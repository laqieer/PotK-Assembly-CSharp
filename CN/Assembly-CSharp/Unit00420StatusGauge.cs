// Decompiled with JetBrains decompiler
// Type: Unit00420StatusGauge
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
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
  private UILabel txtValueMax;
  [SerializeField]
  private GameObject[] dirUppt;
  [SerializeField]
  private UILabel txtUpptEnable;
  [SerializeField]
  private UILabel txtUpptDisable;
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
  }

  public void Init(
    PlayerUnit basePlayerUnit,
    PlayerUnit[] materialPlayerUnits,
    CalcUnitCompose.ComposeType type,
    int tValue,
    int maxValue,
    int cValuse,
    int bValue,
    int buildUpCnt,
    int buildUpMax,
    bool isMax)
  {
    int buildupMaterialCnt = CalcUnitCompose.getBuildupMaterialCnt(materialPlayerUnits, type);
    int composeValue = CalcUnitCompose.getComposeValue(basePlayerUnit, materialPlayerUnits, type);
    int buildupValue = CalcUnitCompose.getBuildupValue(basePlayerUnit, materialPlayerUnits, type);
    this.txtValue.color = composeValue != 0 || buildupValue != 0 ? Color.yellow : Color.white;
    this.txtValue.SetTextLocalize(tValue + buildupValue + composeValue);
    this.txtValueMax.SetTextLocalize(Consts.Format(Consts.GetInstance().UNIT_00420_STATUS_GAUGE_VALUE_MAX, (IDictionary) new Hashtable()
    {
      {
        (object) "max",
        (object) maxValue
      }
    }));
    string text = Consts.Format(Consts.GetInstance().UNIT_00420_STATUS_ENFORCE_INFO, (IDictionary) new Hashtable()
    {
      {
        (object) "now",
        (object) (buildUpCnt + buildupMaterialCnt)
      },
      {
        (object) "max",
        (object) buildUpMax
      }
    });
    this.txtUpptEnable.SetTextLocalize(buildUpCnt + buildupMaterialCnt);
    this.txtUpptEnable.color = buildupMaterialCnt != 0 ? Color.yellow : Color.white;
    this.txtUpptDisable.SetTextLocalize(text);
    if (isMax || buildUpCnt >= buildUpMax)
      ((IEnumerable<GameObject>) this.dirUppt).ToggleOnce(1);
    else
      ((IEnumerable<GameObject>) this.dirUppt).ToggleOnce(0);
    if (type == CalcUnitCompose.ComposeType.HP)
      this.SetGauge(tValue, bValue, cValuse, composeValue, buildupValue, 198, CalcUnitCompose.isComposeMax(basePlayerUnit, type), true);
    else
      this.SetGauge(tValue, bValue, cValuse, composeValue, buildupValue, 99, CalcUnitCompose.isComposeMax(basePlayerUnit, type), false);
    this.StatusMaxStar.SetActive(isMax);
  }
}
