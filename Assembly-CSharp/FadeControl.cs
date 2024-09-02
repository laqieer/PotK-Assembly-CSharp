// Decompiled with JetBrains decompiler
// Type: FadeControl
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class FadeControl : MonoBehaviour
{
  [SerializeField]
  private bool isSubControl_;
  [NonSerialized]
  public FadeControl.FadeState fadeState;
  private FadeControl.FadeState nextFadeState;
  [NonSerialized]
  public float r;
  [NonSerialized]
  public float g;
  [NonSerialized]
  public float b;
  [NonSerialized]
  public float fromAlpha;
  [NonSerialized]
  public float toAlpha;
  [NonSerialized]
  public float time = 5f;
  [NonSerialized]
  public float flushTime = 0.1f;
  [NonSerialized]
  public float waitTime;
  private UI2DSprite fade_;
  private float elapsedTime;

  private UI2DSprite fade
  {
    get
    {
      if ((UnityEngine.Object) this.fade_ == (UnityEngine.Object) null)
        this.fade_ = this.GetComponent<UI2DSprite>();
      return this.fade_;
    }
  }

  private void Awake()
  {
    this.fadeState = FadeControl.FadeState.None;
    UI2DSprite fade = this.fade;
    if (!((UnityEngine.Object) fade != (UnityEngine.Object) null))
      return;
    fade.alpha = 0.0f;
  }

  private void SetFade(float a, float t)
  {
    TweenAlpha tweenAlpha = TweenAlpha.Begin(this.gameObject, t, a);
    this.fadeState = FadeControl.FadeState.None;
    if (!this.isSubControl_ || !((UnityEngine.Object) tweenAlpha != (UnityEngine.Object) null) || (double) a != 0.0)
      return;
    EventDelegate.Add(tweenAlpha.onFinished, (EventDelegate.Callback) (() => this.gameObject.SetActive(false)), true);
  }

  private void Update()
  {
    if (this.fadeState == FadeControl.FadeState.Wait)
    {
      this.elapsedTime += Time.deltaTime;
      if ((double) this.elapsedTime <= (double) this.waitTime)
        return;
      this.elapsedTime = 0.0f;
      this.waitTime = 0.0f;
      this.fadeState = this.nextFadeState;
    }
    else if (this.fadeState == FadeControl.FadeState.Fade)
    {
      if ((double) this.waitTime != 0.0)
      {
        this.fadeState = FadeControl.FadeState.Wait;
        this.elapsedTime = 0.0f;
        this.nextFadeState = FadeControl.FadeState.Fade;
      }
      else
      {
        this.setColor(new Color(this.r, this.g, this.b, this.fromAlpha));
        this.SetFade(this.toAlpha, this.time);
      }
    }
    else
    {
      if (this.fadeState != FadeControl.FadeState.Fillrect)
        return;
      if ((double) this.waitTime != 0.0)
      {
        this.fadeState = FadeControl.FadeState.Wait;
        this.elapsedTime = 0.0f;
        this.nextFadeState = FadeControl.FadeState.Fillrect;
      }
      else
      {
        this.setColor(new Color(this.r, this.g, this.b, this.fromAlpha));
        this.SetFade(this.toAlpha, this.time);
      }
    }
  }

  private void setColor(Color c)
  {
    UI2DSprite fade = this.fade;
    if (!((UnityEngine.Object) fade != (UnityEngine.Object) null))
      return;
    fade.color = c;
  }

  public void setDepth(int d)
  {
    UI2DSprite fade = this.fade;
    if (!((UnityEngine.Object) fade != (UnityEngine.Object) null))
      return;
    fade.depth = d;
  }

  public void StartWait(float time)
  {
    this.fadeState = FadeControl.FadeState.Wait;
    this.elapsedTime = 0.0f;
    this.waitTime = time;
  }

  public void StartFade() => this.fadeState = FadeControl.FadeState.Fade;

  public void StartFillrect()
  {
    if (this.isSubControl_)
      this.gameObject.SetActive(true);
    this.fadeState = FadeControl.FadeState.Fillrect;
  }

  public enum FadeState
  {
    None,
    Wait,
    Fade,
    Fillrect,
  }
}
