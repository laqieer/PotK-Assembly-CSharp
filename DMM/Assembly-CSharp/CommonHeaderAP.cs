﻿// Decompiled with JetBrains decompiler
// Type: CommonHeaderAP
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using SM;
using UnityEngine;

public class CommonHeaderAP : MonoBehaviour
{
  public NGTweenParts timeContainer;
  public GameObject gauge;
  public UILabel timeText;
  [SerializeField]
  private UILabel gaugeText;
  private TweenScale gaugeTweener;
  private TweenWidth widthTweener;
  private UIWidget widget;
  private int maxWidth;

  private void Awake()
  {
    this.gaugeTweener = this.gauge.GetComponent<TweenScale>();
    if ((Object) this.gaugeTweener != (Object) null)
    {
      this.gauge.transform.localScale = new Vector3(0.0f, this.gauge.transform.localScale.y, this.gauge.transform.localScale.z);
    }
    else
    {
      this.widthTweener = this.gauge.GetComponent<TweenWidth>();
      this.widget = this.gauge.GetComponent<UIWidget>();
      this.maxWidth = this.widget.width;
      this.widget.width = 0;
    }
  }

  public void setTime(float time)
  {
    if ((Object) this.timeContainer == (Object) null)
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
    float num1 = (apSummary >= apMax ? (float) apMax : (float) ap) / (float) apMax;
    if ((Object) this.gaugeText != (Object) null)
      this.gaugeText.SetTextLocalize(CommonHeaderAP.GetApString(apSummary, apMax));
    if ((Object) this.gaugeTweener != (Object) null)
    {
      float x1 = this.gauge.transform.localScale.x;
      float x2 = num1;
      this.gaugeTweener.from = new Vector3(x1, this.gauge.transform.localScale.y, this.gauge.transform.localScale.z);
      this.gaugeTweener.to = new Vector3(x2, this.gauge.transform.localScale.y, this.gauge.transform.localScale.z);
      this.gaugeTweener.onFinished.Clear();
      NGTween.playTween((UITweener) this.gaugeTweener);
    }
    else
    {
      int width = this.widget.width;
      int num2 = Mathf.FloorToInt((float) this.maxWidth * num1);
      this.widthTweener.from = width;
      this.widthTweener.to = num2;
      this.widthTweener.onFinished.Clear();
      NGTween.playTween((UITweener) this.widthTweener);
    }
  }

  public static string GetApString(int apSummary, int apMax) => string.Format((apSummary > apMax ? "[f6ff01]{0}[-]" : "{0}") + "/{1}", (object) apSummary.ToLocalizeNumberText(), (object) apMax.ToLocalizeNumberText());
}
