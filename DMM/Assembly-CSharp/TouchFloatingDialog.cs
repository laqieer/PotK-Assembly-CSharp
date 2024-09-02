// Decompiled with JetBrains decompiler
// Type: TouchFloatingDialog
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TouchFloatingDialog : FloatingDialogBase
{
  private bool touchEnable = true;

  protected bool TouchEnable
  {
    get => this.touchEnable;
    set => this.touchEnable = value;
  }

  protected override void Update()
  {
    if (!Input.GetMouseButtonDown(0) || !this.IsShow || !this.touchEnable)
      return;
    this.Hide();
  }

  public override void Show()
  {
    this.gameObject.SetActive(true);
    if ((Object) this.tweenAlpha != (Object) null)
    {
      this.tweenAlpha.enabled = true;
      this.tweenAlpha.onFinished.Clear();
      this.tweenAlpha.PlayForward();
    }
    if ((Object) this.tweenScale != (Object) null)
    {
      this.tweenScale.enabled = true;
      this.tweenScale.onFinished.Clear();
      this.tweenScale.PlayForward();
    }
    this.touchEnable = true;
    this.show = true;
  }

  public override void Hide()
  {
    this.touchEnable = false;
    EventDelegate.Callback del = (EventDelegate.Callback) (() =>
    {
      if (((Object) this.tweenAlpha == (Object) null ? 0 : (!this.tweenAlpha.enabled ? 1 : 0)) != ((Object) this.tweenScale == (Object) null ? 0 : (!this.tweenScale.enabled ? 1 : 0)))
        return;
      this.show = false;
      this.gameObject.SetActive(false);
    });
    if ((Object) this.tweenAlpha != (Object) null)
    {
      this.tweenAlpha.onFinished.Clear();
      this.tweenAlpha.AddOnFinished(del);
      this.tweenAlpha.PlayReverse();
    }
    if (!((Object) this.tweenScale != (Object) null))
      return;
    this.tweenScale.onFinished.Clear();
    this.tweenScale.AddOnFinished(del);
    this.tweenScale.PlayReverse();
  }
}
