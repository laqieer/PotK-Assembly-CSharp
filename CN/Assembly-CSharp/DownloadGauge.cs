// Decompiled with JetBrains decompiler
// Type: DownloadGauge
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

#nullable disable
public class DownloadGauge : MonoBehaviour
{
  [SerializeField]
  private UILabel percentage;
  [SerializeField]
  private NGTweenGaugeScale gauge;
  [SerializeField]
  private UILabel downloadSize;

  public void setValue(int n, int max, bool doTween = true)
  {
    if (this.gauge.setValue(n, max, doTween))
      this.percentage.SetTextLocalize(Mathf.RoundToInt((float) ((double) n / (double) max * 100.0)).ToString() + "%");
    if (ResourceDownloader.nowDataDownloadSize == 0 || ResourceDownloader.nowDataDownloadName.Equals(string.Empty))
      return;
    int num1 = ResourceDownloader.nowDataDownloadSize / 1024 / 1024;
    if (num1 < 1)
    {
      int num2 = ResourceDownloader.nowDataDownloadSize / 1024;
      if (num2 < 1)
        this.downloadSize.SetText(string.Format(Consts.GetInstance().downloade + ":{0} {1} B", (object) ResourceDownloader.nowDataDownloadName, (object) ResourceDownloader.nowDataDownloadSize));
      else
        this.downloadSize.SetText(string.Format(Consts.GetInstance().downloade + ":{0} {1} KB", (object) ResourceDownloader.nowDataDownloadName, (object) num2));
    }
    else
      this.downloadSize.SetText(string.Format(Consts.GetInstance().downloade + ":{0} {1} MB", (object) ResourceDownloader.nowDataDownloadName, (object) num1));
  }
}
