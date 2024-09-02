// Decompiled with JetBrains decompiler
// Type: PopupUnityGrowthResult
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupUnityGrowthResult : BackButtonMenuBase
{
  [SerializeField]
  private UIGrid mGridAnchor;
  private List<UnitUnityGrowthResult> mResults = new List<UnitUnityGrowthResult>();
  private System.Action mOnFinishCallBack;

  public IEnumerator Initialize(PlayerUnit beforeUnit, PlayerUnit afterUnit)
  {
    IEnumerator e = this.Initialize(new List<KeyValuePair<PlayerUnit, PlayerUnit>>()
    {
      new KeyValuePair<PlayerUnit, PlayerUnit>(beforeUnit, afterUnit)
    });
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  public IEnumerator Initialize(
    List<KeyValuePair<PlayerUnit, PlayerUnit>> growthResults)
  {
    PopupUnityGrowthResult unityGrowthResult = this;
    unityGrowthResult.IsPush = true;
    unityGrowthResult.GetComponent<UIRect>().alpha = 0.0f;
    Future<GameObject> ft = new ResourceObject("Prefabs/unit/dir_UnitTouta_Result_Parts").Load<GameObject>();
    IEnumerator e = ft.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    GameObject prefab = ft.Result;
    foreach (KeyValuePair<PlayerUnit, PlayerUnit> growthResult in growthResults)
    {
      UnitUnityGrowthResult resultObj = prefab.CloneAndGetComponent<UnitUnityGrowthResult>(unityGrowthResult.mGridAnchor.gameObject);
      e = resultObj.Initialize(growthResult.Key, growthResult.Value);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      unityGrowthResult.mResults.Add(resultObj);
      resultObj = (UnitUnityGrowthResult) null;
    }
    unityGrowthResult.mGridAnchor.Reposition();
  }

  public void StartGaugeAnime()
  {
    foreach (UnitUnityGrowthResult mResult in this.mResults)
      mResult.StartGaugeAnime();
    this.StartCoroutine(this.IsPushOff());
  }

  public void SkipGaugeAnime()
  {
    foreach (UnitUnityGrowthResult mResult in this.mResults)
      mResult.SkipAnime();
  }

  public void SetOnFinishCallback(System.Action callback) => this.mOnFinishCallBack = callback;

  public override void onBackButton()
  {
    if (this.IsPushAndSet())
      return;
    foreach (UnitUnityGrowthResult mResult in this.mResults)
    {
      if (mResult.isAnime)
      {
        this.SkipGaugeAnime();
        this.StartCoroutine(this.IsPushOff());
        return;
      }
    }
    if (this.mOnFinishCallBack != null)
      this.mOnFinishCallBack();
    GaugeRunner.StopSE();
    Singleton<PopupManager>.GetInstance().dismiss();
  }
}
