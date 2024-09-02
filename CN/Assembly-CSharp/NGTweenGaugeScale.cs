// Decompiled with JetBrains decompiler
// Type: NGTweenGaugeScale
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class NGTweenGaugeScale : MonoBehaviour
{
  [SerializeField]
  protected GameObject gauge;
  private float gaugeValue = -1f;
  private TweenScale _gaugeTweener;

  private TweenScale gaugeTweener
  {
    get
    {
      if (Object.op_Equality((Object) this._gaugeTweener, (Object) null))
      {
        TweenScale[] componentsInChildren = this.gauge.GetComponentsInChildren<TweenScale>();
        if (componentsInChildren.Length > 0)
          this._gaugeTweener = componentsInChildren[0];
      }
      return this._gaugeTweener;
    }
  }

  public bool setValue(int n, int max, bool doTween = true, float delay = -1f, float duration = -1f)
  {
    if (Object.op_Inequality((Object) this.gaugeTweener, (Object) null))
    {
      if ((double) delay < 0.0)
        delay = this.gaugeTweener.delay;
      if ((double) duration < 0.0)
        duration = this.gaugeTweener.duration;
    }
    if (Mathf.Approximately((float) max, 0.0f))
      return false;
    float num1 = (float) n / (float) max;
    if (Mathf.Approximately(this.gaugeValue, num1))
      return false;
    float num2 = num1;
    if (doTween && Object.op_Inequality((Object) this.gaugeTweener, (Object) null))
    {
      this.gaugeTweener.from = this.gauge.transform.localScale;
      this.gaugeTweener.to = new Vector3(num2, this.gauge.transform.localScale.y, this.gauge.transform.localScale.z);
      this.gaugeTweener.duration = duration;
      this.gaugeTweener.delay = delay;
      NGTween.playTween((UITweener) this.gaugeTweener);
    }
    else
    {
      if (Object.op_Inequality((Object) this.gaugeTweener, (Object) null))
        ((Behaviour) this.gaugeTweener).enabled = false;
      this.gauge.transform.localScale = new Vector3(num2, this.gauge.transform.localScale.y, this.gauge.transform.localScale.z);
    }
    this.gaugeValue = num1;
    return true;
  }
}
