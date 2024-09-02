// Decompiled with JetBrains decompiler
// Type: Battle01PVPSetPointGauge
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
    Battle01PVPSetPointGauge.\u003CStart_Original\u003Ec__Iterator950 originalCIterator950 = new Battle01PVPSetPointGauge.\u003CStart_Original\u003Ec__Iterator950();
    return (IEnumerator) originalCIterator950;
  }

  public void Start_Battle_Debug()
  {
  }

  public void initValue(int remVal, int maxVal)
  {
    this.hpGauge.setValue(remVal, maxVal);
    this.damegeGauge.setValue(remVal, maxVal);
    this.oldVal = remVal;
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
    }), 1f);
    this.oldVal = remVal;
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
