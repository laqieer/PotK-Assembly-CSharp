// Decompiled with JetBrains decompiler
// Type: Battle01PVPSetPointGauge
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

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
  private Transform leaderAnimParent;
  private GameObject leaderAnim;
  private Animator leaderGaugeAnimator;
  private string leaderGaugeAnimatorTrigger;
  private bool isTriggerLeaderEffect;
  private int oldVal = 1;
  private BattleTimeManager _btm;

  public void InitLeaderEffect(string leaderEffectName, string leaderGaugeAnimatorTrigger)
  {
    this.leaderAnimParent = this.transform.parent;
    Transform transform = this.leaderAnimParent.Find(leaderEffectName);
    if ((UnityEngine.Object) transform != (UnityEngine.Object) null)
      this.leaderAnim = transform.gameObject;
    this.leaderGaugeAnimator = this.transform.parent.GetComponent<Animator>();
    this.leaderGaugeAnimatorTrigger = leaderGaugeAnimatorTrigger;
  }

  private Vector3 CalcLeaderAnimPosition() => new Vector3(this.effect.transform.position.x, this.leaderAnim.transform.position.y, this.leaderAnim.transform.position.z);

  public void OnTriggerLeaderEffect() => this.isTriggerLeaderEffect = true;

  protected override IEnumerator Start_Original()
  {
    yield break;
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
      if (this.isTriggerLeaderEffect)
      {
        this.isTriggerLeaderEffect = false;
        if ((UnityEngine.Object) this.leaderAnim != (UnityEngine.Object) null)
        {
          this.leaderAnim.transform.position = this.CalcLeaderAnimPosition();
          this.leaderAnim.SetActive(false);
          this.leaderAnim.SetActive(true);
        }
        if ((UnityEngine.Object) this.leaderGaugeAnimator != (UnityEngine.Object) null)
          this.leaderGaugeAnimator.SetTrigger(this.leaderGaugeAnimatorTrigger);
        Singleton<NGSoundManager>.GetInstance().playSE("SE_0582");
      }
      else
      {
        if (!this.effect.activeSelf)
          this.effect.SetActive(true);
        if ((UnityEngine.Object) this.anim != (UnityEngine.Object) null)
        {
          this.anim.SetActive(false);
          this.anim.SetActive(true);
        }
        Singleton<NGSoundManager>.GetInstance().playSE("SE_0538");
      }
    }), 1f);
    this.oldVal = remVal;
  }

  public void initValueHistory(int remVal, int maxVal)
  {
    if (maxVal <= 0)
      return;
    float x = (float) remVal / (float) maxVal;
    this.hpGauge.transform.localScale = new Vector3(x, this.hpGauge.transform.localScale.y, this.hpGauge.transform.localScale.z);
    this.damegeGauge.transform.localScale = new Vector3(x, this.damegeGauge.transform.localScale.y, this.damegeGauge.transform.localScale.z);
  }

  private void animGauge(int remVal, int maxVal)
  {
    int max = this.hpGauge.GetComponent<UISprite>().width / 2;
    int n = max - (maxVal - remVal) * max / maxVal;
    this.hpGauge.setValue(n, max);
    this.damegeGauge.setValue(n, max);
  }

  private BattleTimeManager btm
  {
    get
    {
      if ((UnityEngine.Object) this._btm == (UnityEngine.Object) null)
        this._btm = this.battleManager.getManager<BattleTimeManager>();
      return this._btm;
    }
  }
}
