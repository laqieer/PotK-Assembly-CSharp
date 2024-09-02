// Decompiled with JetBrains decompiler
// Type: FloatingDialogBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System.Collections.Generic;
using UnityEngine;

public class FloatingDialogBase : MonoBehaviour
{
  protected TweenAlpha tweenAlpha;
  protected TweenScale tweenScale;
  protected bool show;

  public bool IsShow => this.show;

  protected void Awake()
  {
    this.tweenAlpha = this.gameObject.GetComponent<TweenAlpha>();
    this.tweenScale = this.gameObject.GetComponent<TweenScale>();
  }

  private void Start() => this.gameObject.SetActive(false);

  protected virtual void Update()
  {
    if (!Input.GetMouseButtonDown(0) || !this.show)
      return;
    this.Hide();
  }

  public virtual void Show()
  {
    this.gameObject.SetActive(true);
    ((IEnumerable<UITweener>) this.gameObject.GetComponentsInChildren<UITweener>()).ForEach<UITweener>((System.Action<UITweener>) (c =>
    {
      c.enabled = true;
      c.onFinished.Clear();
      c.PlayForward();
    }));
    this.show = true;
  }

  public virtual void Hide()
  {
    this.show = false;
    UITweener[] tweens = this.gameObject.GetComponentsInChildren<UITweener>();
    if (tweens.Length == 0)
      return;
    int finishCount = 0;
    EventDelegate.Callback onFinish = (EventDelegate.Callback) (() =>
    {
      if (++finishCount < tweens.Length)
        return;
      this.gameObject.SetActive(false);
    });
    ((IEnumerable<UITweener>) tweens).ForEach<UITweener>((System.Action<UITweener>) (c =>
    {
      c.onFinished.Clear();
      c.AddOnFinished(onFinish);
      c.PlayReverse();
    }));
  }
}
