// Decompiled with JetBrains decompiler
// Type: CommonHeaderAP
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using SM;
using UnityEngine;

#nullable disable
public class CommonHeaderAP : MonoBehaviour
{
  public NGTweenParts timeContainer;
  public GameObject gauge;
  public UILabel timeText;
  [SerializeField]
  private UILabel gaugeText;
  private TweenScale gaugeTweener;

  private void Awake()
  {
    this.gaugeTweener = this.gauge.GetComponent<TweenScale>();
    this.gauge.transform.localScale = new Vector3(0.0f, this.gauge.transform.localScale.y, this.gauge.transform.localScale.z);
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

  public void setGauge(Player player)
  {
    int ap = player.ap;
    int apOverflow = player.ap_overflow;
    int apMax = player.ap_max;
    int apSummary = ap + apOverflow;
    float num1 = (apSummary < apMax ? (float) ap : (float) apMax) / (float) apMax;
    if (Object.op_Inequality((Object) this.gaugeText, (Object) null))
      this.gaugeText.SetTextLocalize(CommonHeaderAP.GetApString(apSummary, apMax));
    float x = this.gauge.transform.localScale.x;
    float num2 = num1;
    this.gaugeTweener.from = new Vector3(x, this.gauge.transform.localScale.y, this.gauge.transform.localScale.z);
    this.gaugeTweener.to = new Vector3(num2, this.gauge.transform.localScale.y, this.gauge.transform.localScale.z);
    this.gaugeTweener.onFinished.Clear();
    NGTween.playTween((UITweener) this.gaugeTweener);
  }

  public static string GetApString(int apSummary, int apMax)
  {
    return string.Format((apSummary <= apMax ? "{0}" : "[f6ff01]{0}[-]") + "/{1}", (object) apSummary.ToLocalizeNumberText(), (object) apMax.ToLocalizeNumberText());
  }
}
