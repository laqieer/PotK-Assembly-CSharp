// Decompiled with JetBrains decompiler
// Type: GearStatusUpParam
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
public class GearStatusUpParam : MonoBehaviour
{
  [SerializeField]
  private UILabel lblVal;
  [SerializeField]
  private UILabel lblUpVal;
  [SerializeField]
  private UILabel lblUpPar;
  [SerializeField]
  private GameObject gaugeLiteBlue;
  [SerializeField]
  private GameObject gaugeBule;
  [SerializeField]
  private GameObject gaugeGreen;
  [SerializeField]
  private GameObject gaugeYellow;

  public void SetCalcStatus(
    int gearBaseMaxParam,
    int gearBaseParam,
    int gearBaseAddParam,
    List<PlayerItem> gearMaterialData,
    GearKindEnum gearkindEnum)
  {
    bool max = false;
    if (gearBaseMaxParam == gearBaseAddParam)
      max = true;
    int? nullable = ((IEnumerable<GearBuildupLogic>) MasterData.GearBuildupLogicList).FirstIndexOrNull<GearBuildupLogic>((Func<GearBuildupLogic, bool>) (x => x.base_param == gearBaseAddParam));
    GearBuildupLogic logic = (GearBuildupLogic) null;
    if (!max)
      logic = MasterData.GearBuildupLogicList[nullable.Value];
    int num = !max ? logic.base_rate : 0;
    int gearMaterialParamRate = 0;
    gearMaterialData.Where<PlayerItem>((Func<PlayerItem, bool>) (x => x.gear.kind.Enum == gearkindEnum)).ToList<PlayerItem>().ForEach((Action<PlayerItem>) (x => gearMaterialParamRate += !max ? logic.MaterialRank(x.gear_level) : 0));
    if (gearMaterialParamRate == 0)
      num = 0;
    int SumRate = num + gearMaterialParamRate;
    int gearMaterialAddParam = Mathf.CeilToInt((float) SumRate / 100f);
    if (gearMaterialAddParam + gearBaseAddParam > gearBaseMaxParam)
      gearMaterialAddParam = gearBaseMaxParam - (gearBaseParam + gearBaseAddParam);
    this.SetParameter(gearBaseMaxParam, gearBaseParam, gearBaseAddParam, SumRate, gearMaterialAddParam);
  }

  private void SetParameter(
    int gearBaseMaxParam,
    int gearBaseParam,
    int gearBaseAddParam,
    int SumRate,
    int gearMaterialAddParam)
  {
    this.SetValue(gearBaseParam + gearBaseAddParam);
    this.SetUpValue(gearMaterialAddParam);
    this.SetUpPercent(SumRate);
    if (gearBaseMaxParam <= gearBaseAddParam)
      this.SetLiteGauge(gearBaseParam + gearBaseAddParam);
    else
      this.SetTriGauge(gearBaseParam, gearBaseAddParam, gearMaterialAddParam);
  }

  public void Init() => this.SetParameter(0, 0, 0, 0, 0);

  private float ScaleCalc(int val) => (float) val / 20f;

  private void SetGaugeScale(GameObject obj, float val)
  {
    obj.transform.localScale = new Vector3(val, 1f, 1f);
  }

  private void SetLiteGauge(int gearBaseMaxParam)
  {
    this.gaugeLiteBlue.SetActive(true);
    this.gaugeBule.SetActive(false);
    this.gaugeGreen.SetActive(false);
    this.gaugeYellow.SetActive(false);
    this.SetGaugeScale(this.gaugeLiteBlue, this.ScaleCalc(gearBaseMaxParam));
  }

  private void SetTriGauge(int gearBaseParam, int gearBaseAddParam, int gearMaterialAddParam)
  {
    this.gaugeLiteBlue.SetActive(false);
    this.gaugeBule.SetActive(true);
    this.gaugeGreen.SetActive(true);
    this.gaugeYellow.SetActive(true);
    this.SetGaugeScale(this.gaugeBule, this.ScaleCalc(gearBaseParam));
    this.SetGaugeScale(this.gaugeGreen, this.ScaleCalc(gearBaseParam + gearBaseAddParam));
    this.SetGaugeScale(this.gaugeYellow, this.ScaleCalc(gearBaseParam + gearBaseAddParam + gearMaterialAddParam));
  }

  private void SetValue(int value) => this.lblVal.SetTextLocalize(value.ToString());

  private void SetUpValue(int value)
  {
    if (value == 0)
    {
      ((Component) ((Component) this.lblUpVal).transform.parent).gameObject.SetActive(false);
    }
    else
    {
      ((Component) ((Component) this.lblUpVal).transform.parent).gameObject.SetActive(true);
      this.lblUpVal.SetTextLocalize(value.ToString());
    }
  }

  private void SetUpPercent(int value) => this.lblUpPar.SetTextLocalize(value.ToString() + "%");
}
