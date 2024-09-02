// Decompiled with JetBrains decompiler
// Type: CommonHeaderAP
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

#nullable disable
public class CommonHeaderAP : MonoBehaviour
{
  public NGTweenParts timeContainer;
  public GameObject gauge;
  [SerializeField]
  private GameObject gaugeRemainder;
  public UILabel timeText;
  [SerializeField]
  private UILabel gaugeText;
  private TweenScale gaugeTweener;
  private TweenScale gaugeTweenerRemainder;

  private void Awake()
  {
    this.gaugeTweener = this.gauge.GetComponent<TweenScale>();
    this.gauge.transform.localScale = new Vector3(0.0f, this.gauge.transform.localScale.y, this.gauge.transform.localScale.z);
    this.gaugeTweenerRemainder = this.gaugeRemainder.GetComponent<TweenScale>();
    this.gaugeRemainder.transform.localScale = new Vector3(0.0f, this.gaugeRemainder.transform.localScale.y, this.gaugeRemainder.transform.localScale.z);
  }

  public void setTime(float time)
  {
    if (Object.op_Equality((Object) this.timeContainer, (Object) null))
      return;
    bool flag = (double) time > 0.0;
    this.timeContainer.isActive = flag;
    if (!flag)
      return;
    this.timeText.SetTextLocalize(string.Format("{0:00}:{1:00}", (object) Mathf.FloorToInt(time / 60f), (object) Mathf.FloorToInt(time % 60f)));
  }

  public void setGauge(int ap, int apOverflow, int apMax)
  {
    int apSummary = ap + apOverflow;
    float num1 = (apSummary < apMax ? (float) ap : (float) apMax) / (float) apMax;
    float num2 = (apSummary >= apMax ? (float) (apSummary - apMax) : 0.0f) / (float) apMax;
    if (Object.op_Inequality((Object) this.gaugeText, (Object) null))
      this.gaugeText.SetTextLocalize(CommonHeaderAP.GetApString(apSummary, apMax));
    float x1 = this.gauge.transform.localScale.x;
    float num3 = num1;
    this.gaugeTweener.from = new Vector3(x1, this.gauge.transform.localScale.y, this.gauge.transform.localScale.z);
    this.gaugeTweener.to = new Vector3(num3, this.gauge.transform.localScale.y, this.gauge.transform.localScale.z);
    float x2 = this.gaugeRemainder.transform.localScale.x;
    float num4 = num2;
    this.gaugeTweenerRemainder.from = new Vector3(x2, this.gaugeRemainder.transform.localScale.y, this.gaugeRemainder.transform.localScale.z);
    this.gaugeTweenerRemainder.to = new Vector3(num4, this.gaugeRemainder.transform.localScale.y, this.gaugeRemainder.transform.localScale.z);
    this.gaugeTweener.onFinished.Clear();
    this.gaugeTweenerRemainder.onFinished.Clear();
    if ((double) x1 <= (double) num3)
    {
      EventDelegate.Set(this.gaugeTweener.onFinished, (EventDelegate.Callback) (() => NGTween.playTween((UITweener) this.gaugeTweenerRemainder)));
      NGTween.playTween((UITweener) this.gaugeTweener);
    }
    else if ((double) x2 > 0.0)
    {
      EventDelegate.Set(this.gaugeTweenerRemainder.onFinished, (EventDelegate.Callback) (() => NGTween.playTween((UITweener) this.gaugeTweener)));
      NGTween.playTween((UITweener) this.gaugeTweenerRemainder);
    }
    else
      NGTween.playTween((UITweener) this.gaugeTweener);
  }

  public static string GetApString(int apSummary, int apMax)
  {
    return string.Format((apSummary <= apMax ? "{0}" : "[f6ff01]{0}[-]") + "/{1}", (object) apSummary.ToLocalizeNumberText(), (object) apMax.ToLocalizeNumberText());
  }
}
