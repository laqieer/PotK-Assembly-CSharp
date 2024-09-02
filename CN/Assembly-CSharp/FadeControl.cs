// Decompiled with JetBrains decompiler
// Type: FadeControl
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class FadeControl : MonoBehaviour
{
  public FadeControl.FadeState fadeState;
  private FadeControl.FadeState nextFadeState;
  public float r;
  public float g;
  public float b;
  public float fromAlpha;
  public float toAlpha;
  public float time = 5f;
  public float flushTime = 0.1f;
  public float waitTime;
  private GameObject fadeObj;
  private UI2DSprite fade;
  private float elapsedTime;

  private void Start()
  {
    this.fadeObj = GameObject.Find("Fade");
    this.fade = this.fadeObj.GetComponent<UI2DSprite>();
    this.fadeState = FadeControl.FadeState.None;
  }

  private void SetFade(float a, float t)
  {
    TweenAlpha.Begin(this.fadeObj, t, a);
    this.fadeState = FadeControl.FadeState.None;
  }

  private void Update()
  {
    if (this.fadeState == FadeControl.FadeState.Wait)
    {
      this.elapsedTime += Time.deltaTime;
      Debug.Log((object) ("Wait:" + (object) this.elapsedTime));
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
        this.fade.color = new Color(this.r, this.g, this.b, this.fromAlpha);
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
        this.fade.color = new Color(this.r, this.g, this.b, this.fromAlpha);
        this.SetFade(this.toAlpha, this.time);
      }
    }
  }

  public void StartWait(float time)
  {
    this.fadeState = FadeControl.FadeState.Wait;
    this.elapsedTime = 0.0f;
    this.waitTime = time;
  }

  public void StartFade() => this.fadeState = FadeControl.FadeState.Fade;

  public void StartFillrect() => this.fadeState = FadeControl.FadeState.Fillrect;

  public enum FadeState
  {
    None,
    Wait,
    Fade,
    Fillrect,
  }
}
