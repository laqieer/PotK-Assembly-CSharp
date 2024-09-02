// Decompiled with JetBrains decompiler
// Type: StoryEffectBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class StoryEffectBase : MonoBehaviour
{
  [SerializeField]
  [Tooltip("演出開始時にアクティブ")]
  protected GameObject topObject_;
  protected ParticleSystem topParticle_;
  [SerializeField]
  [Tooltip("自動終了判断をしたい場合にそのチェック対象を指定")]
  protected ParticleSystem checkEnd_;
  [SerializeField]
  [Tooltip("ParticleSystem毎のカラーパターン設定配列")]
  protected StoryEffectBase.ParticleControl[] particles_;
  [SerializeField]
  [Tooltip("演出開始まで非アクティブにしたいGameObjectを指定")]
  protected GameObject[] firstOffObjects_;
  [SerializeField]
  [Tooltip("演出終了で非アクティブにしたいGameObjectを指定")]
  protected GameObject[] skipOffObjects_;
  private bool hasUIPanel;

  protected bool isPlayingEffect_ { get; private set; }

  protected bool isEndEffect_ { get; private set; }

  protected bool isAliveCheckEnd_ { get; private set; }

  private void setEnabledObjects(GameObject[] objs, bool bEnabled, bool bImmediate = false)
  {
    if (objs == null || objs.Length == 0)
      return;
    if (bImmediate)
    {
      foreach (GameObject gameObject in objs)
        gameObject.SetActive(bEnabled);
    }
    else
    {
      foreach (GameObject gameObject in objs)
      {
        NGTweenParts component = gameObject.GetComponent<NGTweenParts>();
        if ((UnityEngine.Object) component != (UnityEngine.Object) null)
          component.isActive = bEnabled;
        else
          gameObject.SetActive(bEnabled);
      }
    }
  }

  public void startEffect()
  {
    if ((UnityEngine.Object) this.topObject_ != (UnityEngine.Object) null)
      this.topObject_.SetActive(true);
    if ((UnityEngine.Object) this.topParticle_ != (UnityEngine.Object) null)
    {
      this.isPlayingEffect_ = true;
      this.playParticle();
    }
    this.setEnabledObjects(this.firstOffObjects_, true);
  }

  public void skipEffect()
  {
    this.isPlayingEffect_ = false;
    this.isEndEffect_ = true;
    if ((UnityEngine.Object) this.topParticle_ != (UnityEngine.Object) null)
      this.topParticle_.Stop();
    this.setEnabledObjects(this.skipOffObjects_, false);
    StoryExecuter componentInChildren = Singleton<NGSceneManager>.GetInstance().sceneBase.GetComponentInChildren<StoryExecuter>();
    if (!((UnityEngine.Object) componentInChildren != (UnityEngine.Object) null) || !this.hasUIPanel || componentInChildren.topButtons.activeSelf)
      return;
    componentInChildren.topButtons.SetActive(true);
  }

  protected void playParticle()
  {
    this.topParticle_.Play();
    if (!((UnityEngine.Object) this.checkEnd_ != (UnityEngine.Object) null))
      return;
    this.isAliveCheckEnd_ = this.checkEnd_.IsAlive();
  }

  public void setColor(int noColor)
  {
    if (this.particles_ == null || this.particles_.Length == 0)
      return;
    foreach (StoryEffectBase.ParticleControl particle in this.particles_)
      particle.setColor(noColor);
  }

  private void Awake() => this.awakeLocal();

  protected virtual void awakeLocal()
  {
    this.isPlayingEffect_ = false;
    if ((UnityEngine.Object) this.topObject_ != (UnityEngine.Object) null)
    {
      this.topParticle_ = this.topObject_.GetComponent<ParticleSystem>();
      this.topObject_.SetActive(false);
    }
    if ((UnityEngine.Object) this.topParticle_ != (UnityEngine.Object) null)
    {
      this.isEndEffect_ = false;
      this.topParticle_.Stop();
    }
    else
      this.isEndEffect_ = true;
    this.setEnabledObjects(this.firstOffObjects_, false, true);
    StoryExecuter componentInChildren = Singleton<NGSceneManager>.GetInstance().sceneBase.GetComponentInChildren<StoryExecuter>();
    if (!((UnityEngine.Object) componentInChildren != (UnityEngine.Object) null) || !(bool) (UnityEngine.Object) this.GetComponent<UIPanel>())
      return;
    this.hasUIPanel = true;
    componentInChildren.onLogCloseButton();
    componentInChildren.topButtons.SetActive(false);
    Singleton<PopupManager>.GetInstance().closeAll();
    componentInChildren.continuousPopupView = false;
  }

  private void Update() => this.updateLocal();

  protected virtual void updateLocal()
  {
    if (!this.isPlayingEffect_ || !((UnityEngine.Object) this.checkEnd_ != (UnityEngine.Object) null))
      return;
    bool flag = this.checkEnd_.IsAlive();
    if (this.isAliveCheckEnd_ == flag)
      return;
    this.isAliveCheckEnd_ = flag;
    if (!flag)
      return;
    this.skipEffect();
  }

  [Serializable]
  protected class ParticleControl
  {
    public string name_;
    public ParticleSystem particle_;
    public Color[] startColors_;
    public Gradient[] lifetimeColors_;

    public void setColor(int noColor = 0)
    {
      if ((UnityEngine.Object) this.particle_ == (UnityEngine.Object) null)
        return;
      --noColor;
      if (this.startColors_ != null && noColor >= 0 && noColor < this.startColors_.Length)
        this.particle_.startColor = this.startColors_[noColor];
      if (this.lifetimeColors_ == null || noColor < 0 || noColor >= this.lifetimeColors_.Length)
        return;
      ParticleSystem.ColorOverLifetimeModule colorOverLifetime = this.particle_.colorOverLifetime;
      colorOverLifetime.enabled = true;
      colorOverLifetime.color = new ParticleSystem.MinMaxGradient(this.lifetimeColors_[noColor]);
    }
  }
}
