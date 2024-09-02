// Decompiled with JetBrains decompiler
// Type: NGxBlink
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class NGxBlink : MonoBehaviour
{
  public float waitTime;
  public float durationTime;
  public TweenAlpha animationApply;

  protected virtual NGxBlink.Pair[] GetPairs()
  {
    Transform[] children = this.gameObject.transform.GetChildren().ToArray<Transform>();
    return children.Length == 0 ? (NGxBlink.Pair[]) null : ((IEnumerable<Transform>) children).Select<Transform, NGxBlink.Pair>((Func<Transform, int, NGxBlink.Pair>) ((t, n) => new NGxBlink.Pair()
    {
      first = t.gameObject,
      second = children[(n + 1) % children.Length].gameObject
    })).ToArray<NGxBlink.Pair>();
  }

  public void OnEnable() => this.StartCoroutine(this.RunBlink());

  public void OnDisable() => this.StopAllCoroutines();

  protected virtual IEnumerator RunBlink()
  {
    NGxBlink ngxBlink = this;
label_1:
    while (true)
    {
      NGxBlink.Pair[] pairs = ngxBlink.GetPairs();
      if (pairs != null)
      {
        if (pairs.Length != 1)
        {
          NGxBlink.Pair[] pairArray = pairs;
          for (int index = 0; index < pairArray.Length; ++index)
          {
            NGxBlink.Pair pair = pairArray[index];
            GameObject first = pair.first;
            GameObject second = pair.second;
            TweenAlpha currentTween = first.GetOrAddComponent<TweenAlpha>();
            TweenAlpha nextTween = second.GetOrAddComponent<TweenAlpha>();
            currentTween.from = 1f;
            currentTween.to = 1f;
            currentTween.ResetToBeginning();
            nextTween.from = 0.0f;
            nextTween.to = 0.0f;
            nextTween.ResetToBeginning();
            yield return (object) new WaitForSeconds(ngxBlink.waitTime);
            currentTween.from = 1f;
            currentTween.to = 0.0f;
            nextTween.from = 0.0f;
            nextTween.to = 1f;
            currentTween.animationCurve = ngxBlink.animationApply.animationCurve;
            nextTween.animationCurve = ngxBlink.animationApply.animationCurve;
            currentTween.duration = ngxBlink.durationTime;
            nextTween.duration = ngxBlink.durationTime;
            currentTween.PlayForward();
            nextTween.PlayForward();
            while (nextTween.enabled)
              yield return (object) null;
            currentTween = (TweenAlpha) null;
            nextTween = (TweenAlpha) null;
          }
          pairArray = (NGxBlink.Pair[]) null;
        }
        else
          goto label_6;
      }
      else
        break;
    }
    while (ngxBlink.gameObject.transform.childCount == 0)
      yield return (object) null;
    goto label_1;
label_6:
    while (ngxBlink.gameObject.transform.childCount == 1)
      yield return (object) null;
    goto label_1;
  }

  public class Pair
  {
    public GameObject first;
    public GameObject second;
  }
}
