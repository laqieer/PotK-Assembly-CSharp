// Decompiled with JetBrains decompiler
// Type: GrowthParameter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GrowthParameter : MonoBehaviour
{
  public static int[] MaxParameters = new int[8]
  {
    198,
    99,
    99,
    99,
    99,
    99,
    99,
    99
  };
  public UILabel[] resultParameters;
  public UISprite[] gaugeBlue;
  public UISprite[] gaugeYellow;
  public UISprite[] gaugeWhite;
  public GameObject[] dirUppt;
  public GameObject[] slcParamMaxStars;
  private List<GameObject> upptParameters = new List<GameObject>();
  private List<UISprite[]> gaugeSprites = new List<UISprite[]>();
  private List<TweenScale> tweenObject = new List<TweenScale>();

  public static Future<GameObject> LoadPrefab() => Singleton<ResourceManager>.GetInstance().Load<GameObject>("Prefabs/unit004_8_13/GrowthParameter");

  public static GrowthParameter GetInstance(GameObject prefab, Transform parent)
  {
    GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(prefab);
    gameObject.transform.parent = parent;
    gameObject.transform.localPosition = Vector3.zero;
    gameObject.transform.localScale = Vector3.one;
    gameObject.transform.localRotation = Quaternion.identity;
    return gameObject.GetComponent<GrowthParameter>();
  }

  private void SetGauge(GameObject gauge, float rate, float delay)
  {
    UISprite component = gauge.GetComponent<UISprite>();
    component.width = (int) ((double) component.width * (double) rate);
    TweenScale tweenScale = gauge.AddComponent<TweenScale>();
    tweenScale.from = new Vector3() { x = 0.0f, y = 1f };
    tweenScale.to = new Vector3() { x = 1f, y = 1f };
    tweenScale.style = UITweener.Style.Once;
    tweenScale.duration = 1f;
    tweenScale.delay = 0.2f + delay;
  }

  public void SetParameter(
    GrowthParameter.ParameterType type,
    int beforePt,
    int afterPt,
    bool isBuildup)
  {
    this.SetParameter(type, beforePt, afterPt, isBuildup, GrowthParameter.MaxParameters[(int) type]);
  }

  public void SetParameter(
    GrowthParameter.ParameterType type,
    int growthValue,
    int beforePt,
    int afterPt,
    bool isBuildup)
  {
    this.SetParameter(type, growthValue, beforePt, afterPt, isBuildup, GrowthParameter.MaxParameters[(int) type]);
  }

  private void SetParameter(
    GrowthParameter.ParameterType type,
    int growthValue,
    int beforePt,
    int afterPt,
    bool isBuildup,
    int maxPt)
  {
    Func<int, float> func = (Func<int, float>) (v => v <= 0 ? 0.0f : (float) v / (float) maxPt);
    UISprite[] uiSpriteArray = new UISprite[2];
    float[] gaugeRate = new float[2]
    {
      func(beforePt),
      func(afterPt)
    };
    this.resultParameters[(int) type].SetTextLocalize(afterPt);
    this.resultParameters[(int) type].color = growthValue > 0 ? Color.yellow : Color.white;
    uiSpriteArray[0] = this.gaugeBlue[(int) type];
    if (!isBuildup)
    {
      uiSpriteArray[1] = this.gaugeYellow[(int) type];
      this.gaugeYellow[(int) type].gameObject.SetActive(true);
      this.gaugeWhite[(int) type].gameObject.SetActive(false);
    }
    else
    {
      uiSpriteArray[1] = this.gaugeWhite[(int) type];
      this.gaugeYellow[(int) type].gameObject.SetActive(false);
      this.gaugeWhite[(int) type].gameObject.SetActive(true);
    }
    if (growthValue <= 0)
    {
      this.dirUppt[(int) type].gameObject.SetActive(false);
    }
    else
    {
      this.dirUppt[(int) type].gameObject.SetActive(true);
      this.dirUppt[(int) type].transform.Find("txt_Uppt").GetComponent<UILabel>().SetTextLocalize(growthValue);
    }
    ((IEnumerable<UISprite>) uiSpriteArray).ForEachIndex<UISprite>((System.Action<UISprite, int>) ((gauge, index) => gauge.width = (int) ((double) gauge.width * (double) gaugeRate[index])));
    this.gaugeSprites.Add(uiSpriteArray);
  }

  public void SetParameter(
    GrowthParameter.ParameterType type,
    int beforePt,
    int afterPt,
    bool isBuildup,
    int maxPt)
  {
    this.SetParameter(type, afterPt - beforePt, beforePt, afterPt, isBuildup, maxPt);
  }

  public void GaugesScaleZero()
  {
    foreach (UISprite[] gaugeSprite in this.gaugeSprites)
    {
      foreach (Component component in gaugeSprite)
        component.transform.localScale = Vector3.zero;
    }
  }

  public void SetParameterEffects()
  {
    this.tweenObject.Clear();
    this.gaugeSprites.ForEachIndex<UISprite[]>((System.Action<UISprite[], int>) ((gauges, index) =>
    {
      float delay = (float) (0.200000002980232 + (double) index * 0.0500000007450581);
      ((IEnumerable<UISprite>) gauges).ForEach<UISprite>((System.Action<UISprite>) (gauge =>
      {
        TweenScale tweenScale = gauge.gameObject.AddComponent<TweenScale>();
        tweenScale.style = UITweener.Style.Once;
        tweenScale.duration = 0.5f;
        tweenScale.delay = delay;
        tweenScale.tweenGroup = 11;
        tweenScale.ignoreTimeScale = true;
        tweenScale.from = new Vector3() { x = 0.0f, y = 1f };
        tweenScale.to = new Vector3() { x = 1f, y = 1f };
        this.tweenObject.Add(tweenScale);
      }));
    }));
    this.gaugeSprites.Clear();
    this.upptParameters.ForEachIndex<GameObject>((System.Action<GameObject, int>) ((gameObject, index) =>
    {
      GameObject effObj = gameObject.Clone();
      effObj.transform.position = gameObject.transform.position;
      effObj.transform.parent = gameObject.transform.parent;
      float num = (float) (0.300000011920929 + (double) index * 0.300000011920929);
      TweenScale tweenScale = effObj.AddComponent<TweenScale>();
      tweenScale.style = UITweener.Style.Once;
      tweenScale.duration = 0.5f;
      tweenScale.delay = num;
      tweenScale.tweenGroup = 11;
      tweenScale.to = new Vector3() { x = 1.5f, y = 1.5f };
      tweenScale.ignoreTimeScale = true;
      TweenAlpha tweenAlpha = effObj.AddComponent<TweenAlpha>();
      tweenAlpha.style = UITweener.Style.Once;
      tweenAlpha.from = 0.87f;
      tweenAlpha.to = 0.0f;
      tweenAlpha.duration = 0.5f;
      tweenAlpha.delay = num;
      tweenAlpha.tweenGroup = 11;
      tweenAlpha.ignoreTimeScale = true;
      EventDelegate.Add(tweenAlpha.onFinished, (EventDelegate.Callback) (() => UnityEngine.Object.Destroy((UnityEngine.Object) effObj)));
    }));
    this.upptParameters.Clear();
  }

  public void RemoveTween() => this.tweenObject.ForEach((System.Action<TweenScale>) (v => UnityEngine.Object.DestroyImmediate((UnityEngine.Object) v)));

  public void SetParameterMaxStar(GrowthParameter.ParameterType type, bool isDisp) => this.slcParamMaxStars[(int) type].SetActive(isDisp);

  public void DisableParameter(GrowthParameter.ParameterType type)
  {
    this.resultParameters[(int) type].SetTextLocalize("---");
    this.resultParameters[(int) type].color = Color.white;
    this.gaugeBlue[(int) type].gameObject.SetActive(false);
    this.gaugeYellow[(int) type].gameObject.SetActive(false);
    this.gaugeWhite[(int) type].gameObject.SetActive(false);
    this.dirUppt[(int) type].gameObject.SetActive(false);
  }

  public enum ParameterType
  {
    HP,
    STR,
    INT,
    VIT,
    MND,
    AGI,
    DEX,
    LUK,
  }
}
