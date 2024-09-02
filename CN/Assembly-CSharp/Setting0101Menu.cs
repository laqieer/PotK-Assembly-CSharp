// Decompiled with JetBrains decompiler
// Type: Setting0101Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Setting0101Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  protected UISlider sldBgm;
  [SerializeField]
  protected UISlider sldSe;
  [SerializeField]
  protected UISlider sldVoice;
  [SerializeField]
  public GameObject[] btnHpRecoverOn;
  [SerializeField]
  public GameObject[] btnHpRecoverOff;
  [SerializeField]
  private BoxCollider bgmCollider;
  [SerializeField]
  private BoxCollider seCollider;
  [SerializeField]
  private BoxCollider voiceCollider;
  private bool initFlg;

  public float bgmVolume => this.sldBgm.value;

  public float seVolume => this.sldSe.value;

  public float voiceVolume => this.sldVoice.value;

  public void Initialize()
  {
    this.sldBgm.value = Persist.volume.Data.Bgm;
    this.sldSe.value = Persist.volume.Data.Se;
    this.sldVoice.value = Persist.volume.Data.Voice;
    Singleton<NGSoundManager>.GetInstance().playBGM("bgm001");
    this.initFlg = true;
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    ((Collider) this.bgmCollider).enabled = false;
    ((Collider) this.seCollider).enabled = false;
    ((Collider) this.voiceCollider).enabled = false;
    Singleton<NGSceneManager>.GetInstance().backScene();
  }

  public virtual void SldBgmValueChange()
  {
    if (!this.initFlg)
      return;
    NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
    if (!Object.op_Inequality((Object) instance, (Object) null))
      return;
    instance.getVolume().bgmVolume = this.sldBgm.value;
  }

  public virtual void SldSeValueChange()
  {
    if (!this.initFlg)
      return;
    NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
    if (!Object.op_Inequality((Object) instance, (Object) null))
      return;
    instance.getVolume().seVolume = this.sldSe.value;
  }

  public virtual void SldVoiceValueChange()
  {
    if (!this.initFlg)
      return;
    NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
    if (!Object.op_Inequality((Object) instance, (Object) null))
      return;
    instance.getVolume().voiceVolume = this.sldVoice.value;
  }

  public virtual void IbtnNotificationChange()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("setting010_2", true);
  }

  public virtual void IbtnNameChange()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("setting010_1_3", true);
  }
}
