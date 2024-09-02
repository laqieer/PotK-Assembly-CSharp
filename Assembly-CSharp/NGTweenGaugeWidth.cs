// Decompiled with JetBrains decompiler
// Type: NGTweenGaugeWidth
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class NGTweenGaugeWidth : MonoBehaviour
{
  [SerializeField]
  protected GameObject gauge;
  private UIWidget uiWidget;
  private int defaultWidth;
  private float gaugeValue = -1f;
  private TweenWidth _gaugeTweener;

  private TweenWidth gaugeTweener
  {
    get
    {
      if ((Object) this._gaugeTweener == (Object) null)
      {
        TweenWidth[] componentsInChildren = this.gauge.GetComponentsInChildren<TweenWidth>();
        if (componentsInChildren.Length != 0)
          this._gaugeTweener = componentsInChildren[0];
      }
      return this._gaugeTweener;
    }
  }

  public bool setValue(int n, int max, bool doTween = true, float delay = -1f, float duration = -1f)
  {
    if ((Object) this.gaugeTweener != (Object) null)
    {
      if ((double) delay < 0.0)
        delay = this.gaugeTweener.delay;
      if ((double) duration < 0.0)
        duration = this.gaugeTweener.duration;
    }
    if ((Object) this.uiWidget == (Object) null)
    {
      this.uiWidget = this.gauge.GetComponent<UIWidget>();
      this.defaultWidth = this.uiWidget.width;
    }
    if ((Object) this.uiWidget == (Object) null || Mathf.Approximately((float) max, 0.0f))
      return false;
    float b = (float) n / (float) max;
    if (Mathf.Approximately(this.gaugeValue, b))
      return false;
    if (doTween && (Object) this.gaugeTweener != (Object) null)
    {
      this.gaugeTweener.from = this.uiWidget.width;
      this.gaugeTweener.to = Mathf.FloorToInt((float) this.defaultWidth * b);
      this.gaugeTweener.duration = duration;
      this.gaugeTweener.delay = delay;
      NGTween.playTween((UITweener) this.gaugeTweener);
    }
    else
    {
      if ((Object) this.gaugeTweener != (Object) null)
        this.gaugeTweener.enabled = false;
      this.uiWidget.width = Mathf.FloorToInt((float) this.defaultWidth * b);
    }
    this.gaugeValue = b;
    return true;
  }
}
