// Decompiled with JetBrains decompiler
// Type: CommonHeaderLevel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using SM;
using UnityEngine;

#nullable disable
public class CommonHeaderLevel : MonoBehaviour
{
  public GameObject gauge;
  public float gaugeMax;
  public float gaugeMin;
  public UILabel levelText;
  private TweenRotation gaugeTweener;
  private int levelValue;
  private float gaugeValue;

  private void Awake()
  {
    this.gaugeTweener = this.gauge.GetComponent<TweenRotation>();
    this.gauge.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, this.gaugeMin);
  }

  public void setLevel(int v)
  {
    if (v == this.levelValue)
      return;
    this.levelText.SetTextLocalize(v.ToString() + string.Empty);
    if (SMManager.Get<Player>().IsSkipDuel() && !Persist.battleinfo.Data.bOpenSkipDuelTips)
    {
      string strContent = string.Format(Consts.GetInstance().TxtOpenSkipDuelButton, (object) Singleton<NGBattleManager>.GetInstance().GetSkipDuelOpenLevel());
      Singleton<PopupManager>.GetInstance().OpenConfirmWindow(Consts.GetInstance().TitleOpenSkipDuelButton, strContent, string.Empty);
      Persist.battleinfo.Data.SetOpenSkipDuelTips(true);
      Persist.battleinfo.Flush();
    }
    this.levelValue = v;
  }

  public void setExperience(int exp, int next)
  {
    float num1 = next != 0 ? (float) exp / (float) next : 0.0f;
    if ((double) this.gaugeValue == (double) num1)
      return;
    float num2 = this.gauge.transform.localEulerAngles.z;
    float num3 = this.gaugeMin + (this.gaugeMax - this.gaugeMin) * num1;
    if ((double) Mathf.Round(num2) > (double) Mathf.Round(this.gaugeMax))
      num2 = (float) -(360.0 - (double) num2);
    else if ((double) Mathf.Round(num2) < (double) Mathf.Round(this.gaugeMin))
      num2 += 360f;
    this.gaugeTweener.from = new Vector3(0.0f, 0.0f, num2);
    this.gaugeTweener.to = new Vector3(0.0f, 0.0f, num3);
    NGTween.playTween((UITweener) this.gaugeTweener);
    this.gaugeValue = num1;
  }
}
