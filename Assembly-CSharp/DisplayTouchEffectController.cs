// Decompiled with JetBrains decompiler
// Type: DisplayTouchEffectController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using ModelViewer;
using UnityEngine;

public class DisplayTouchEffectController : MonoBehaviour
{
  private ParticleController currentEffect;
  private ViewerCameraInput viewerInput = new ViewerCameraInput();
  private bool isPushTrig;
  private Vector3 touchedPosition;
  private bool isEnable;
  private bool isTapLock;

  private void Start()
  {
    this.viewerInput.Initialize(0.01f);
    this.SetTapLock(false);
  }

  public void SetEffect(ParticleController effect)
  {
    this.currentEffect = effect;
    effect.transform.parent = this.transform;
    this.SetEnable(true);
  }

  public void SetEffect(GameObject effect) => this.SetEffect(effect.GetComponent<ParticleController>());

  public void ClearEffect()
  {
    if ((Object) this.currentEffect == (Object) null)
      return;
    this.currentEffect.Erase();
    this.currentEffect = (ParticleController) null;
    this.SetEnable(false);
  }

  public void SetEnable(bool enable)
  {
    this.isEnable = enable;
    this.viewerInput.ClearInputParameter();
    this.isPushTrig = false;
  }

  public void SetTapLock(bool islock) => this.isTapLock = islock;

  private void Update()
  {
    if ((Object) this.currentEffect == (Object) null || !this.isEnable || this.isTapLock)
      return;
    this.viewerInput.UpdateParameter();
    if (this.viewerInput.IsTouchingDisplay())
    {
      this.isPushTrig = true;
      Vector3 touchPosition = this.viewerInput.GetTouchPosition();
      this.touchedPosition = this.transform.InverseTransformPoint(Singleton<CommonRoot>.GetInstance().getCamera().ScreenToWorldPoint(touchPosition));
    }
    else
    {
      if (this.isPushTrig)
      {
        NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
        if ((Object) instance != (Object) null)
          instance.playSE("SE_1079");
        this.currentEffect.transform.localRotation = Quaternion.identity;
        this.currentEffect.transform.localScale = Vector3.one;
        this.currentEffect.transform.localPosition = this.touchedPosition;
        this.currentEffect.Play();
      }
      this.isPushTrig = false;
    }
  }
}
