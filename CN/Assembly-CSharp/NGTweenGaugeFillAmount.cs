// Decompiled with JetBrains decompiler
// Type: NGTweenGaugeFillAmount
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class NGTweenGaugeFillAmount : MonoBehaviour
{
  [SerializeField]
  protected GameObject gauge;
  private TweenFillAmount _gaugeTweener;

  private TweenFillAmount gaugeTweener
  {
    get
    {
      if (Object.op_Equality((Object) this._gaugeTweener, (Object) null))
      {
        TweenFillAmount[] componentsInChildren = this.gauge.GetComponentsInChildren<TweenFillAmount>();
        if (componentsInChildren.Length > 0)
          this._gaugeTweener = componentsInChildren[0];
      }
      return this._gaugeTweener;
    }
  }

  public bool setValue(int targetValue, int maxValue, bool doTween, float delay = -1f, float duration = -1f)
  {
    if (Object.op_Inequality((Object) this.gaugeTweener, (Object) null))
    {
      if ((double) delay < 0.0)
        delay = this.gaugeTweener.delay;
      if ((double) duration < 0.0)
        duration = this.gaugeTweener.duration;
    }
    UISprite component = this.gauge.GetComponent<UISprite>();
    if (Mathf.Approximately((float) maxValue, 0.0f))
      return false;
    float num = (float) targetValue / (float) maxValue;
    if (doTween && Object.op_Inequality((Object) this.gaugeTweener, (Object) null))
    {
      this.gaugeTweener.from = component.fillAmount;
      this.gaugeTweener.to = num;
      this.gaugeTweener.duration = duration;
      this.gaugeTweener.delay = delay;
      NGTween.playTween((UITweener) this.gaugeTweener);
    }
    else
      component.fillAmount = num;
    return true;
  }
}
