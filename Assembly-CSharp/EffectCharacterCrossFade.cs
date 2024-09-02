// Decompiled with JetBrains decompiler
// Type: EffectCharacterCrossFade
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("PUNK Scripts/Detail/EffectCharacterCrossFade")]
public class EffectCharacterCrossFade : MonoBehaviour
{
  [SerializeField]
  private float duration_ = 0.6f;
  private int startFrame_;
  private float time_;
  private UI2DSprite in_;
  private UI2DSprite out_;

  public List<EventDelegate> onFinished { get; set; } = new List<EventDelegate>();

  public void play(GameObject fadeIn, GameObject fadeOut)
  {
    this.in_ = fadeIn.GetComponent<UI2DSprite>();
    this.out_ = fadeOut.GetComponent<UI2DSprite>();
    ++this.out_.depth;
    this.time_ = 0.0f;
    this.startFrame_ = Time.frameCount;
    this.enabled = true;
    this.onUpdate();
  }

  private void Awake() => this.enabled = false;

  private void Update()
  {
    if (this.startFrame_ != Time.frameCount)
      this.time_ += Time.deltaTime;
    this.onUpdate();
  }

  private void onUpdate()
  {
    float num = Mathf.Clamp(this.time_ / this.duration_, 0.0f, 1f);
    this.in_.alpha = num;
    this.out_.alpha = 1f - num;
    if ((double) this.time_ < (double) this.duration_)
      return;
    this.in_.alpha = 1f;
    EventDelegate.Execute(this.onFinished);
    this.out_.gameObject.SetActive(false);
    Object.Destroy((Object) this.out_.gameObject);
    this.out_ = (UI2DSprite) null;
    this.onFinished.Clear();
    this.enabled = false;
  }
}
