// Decompiled with JetBrains decompiler
// Type: DownloadGauge
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class DownloadGauge : MonoBehaviour
{
  [SerializeField]
  private UILabel percentage;
  [SerializeField]
  private NGTweenGaugeScale gauge;

  public void setValue(int n, int max, bool doTween = true)
  {
    if (!this.gauge.setValue(n, max, doTween))
      return;
    this.percentage.SetTextLocalize(Mathf.RoundToInt((float) ((double) n / (double) max * 100.0)).ToString() + "%");
  }
}
