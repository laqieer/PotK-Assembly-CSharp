// Decompiled with JetBrains decompiler
// Type: Battle01PVPSetPointGauge
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Battle01PVPSetPointGauge : BattleMonoBehaviour
{
  [SerializeField]
  private NGTweenGaugeScale hpGauge;
  [SerializeField]
  private NGTweenGaugeScale damegeGauge;
  [SerializeField]
  private GameObject effect;
  [SerializeField]
  private ParticleSystem[] particles;
  [SerializeField]
  private GameObject anim;
  private int oldVal = 1;
  private BattleTimeManager _btm;

  [DebuggerHidden]
  protected override IEnumerator Start_Original()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Battle01PVPSetPointGauge.\u003CStart_Original\u003Ec__Iterator883 originalCIterator883 = new Battle01PVPSetPointGauge.\u003CStart_Original\u003Ec__Iterator883();
    return (IEnumerator) originalCIterator883;
  }

  public void Start_Battle_Debug()
  {
  }

  public void initValue(int remVal, int maxVal)
  {
    this.oldVal = remVal;
    this.damegeGauge.setValue(remVal, maxVal);
  }

  public void setValue(int remVal, int maxVal)
  {
    if (this.oldVal == remVal)
      return;
    this.btm.setScheduleAction((System.Action) (() =>
    {
      this.animGauge(remVal, maxVal);
      if (!this.effect.activeSelf)
        this.effect.SetActive(true);
      if (Object.op_Inequality((Object) this.anim, (Object) null))
      {
        this.anim.SetActive(false);
        this.anim.SetActive(true);
      }
      Singleton<NGSoundManager>.GetInstance().playSE("SE_0538");
      this.oldVal = remVal;
    }), 1f);
  }

  private void animGauge(int remVal, int maxVal)
  {
    int max = ((Component) this.hpGauge).GetComponent<UISprite>().width / 2;
    int n = max - (maxVal - remVal) * max / maxVal;
    this.hpGauge.setValue(n, max);
    this.damegeGauge.setValue(n, max);
  }

  private BattleTimeManager btm
  {
    get
    {
      if (Object.op_Equality((Object) this._btm, (Object) null))
        this._btm = this.battleManager.getManager<BattleTimeManager>();
      return this._btm;
    }
  }
}
