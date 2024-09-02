// Decompiled with JetBrains decompiler
// Type: FollowColorButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[AddComponentMenu("NGUI/Custum/UI/FollowColorButton")]
public class FollowColorButton : UIButton
{
  [SerializeField]
  private Color followNormal = Color.white;
  [SerializeField]
  private Color followHover = new Color(0.8823529f, 0.7843137f, 0.5882353f, 1f);
  [SerializeField]
  private Color followPressed = new Color(0.7176471f, 0.6392157f, 0.4823529f, 1f);
  [SerializeField]
  private Color followDisabled = Color.grey;
  protected Color followColor;
  [SerializeField]
  private UIWidget[] followWidgets;

  protected override void OnInit()
  {
    base.OnInit();
    this.followColor = this.followNormal;
    if (this.followWidgets != null && this.followWidgets.Length != 0)
      return;
    UIWidget[] noent = this.gameObject.GetComponents<UIWidget>();
    this.followWidgets = ((IEnumerable<UIWidget>) this.gameObject.GetComponentsInChildren<UIWidget>(true)).Where<UIWidget>((Func<UIWidget, bool>) (x => !((IEnumerable<UIWidget>) noent).Contains<UIWidget>(x))).ToArray<UIWidget>();
  }

  public void SetTweenColor(bool instant, float duration, Color color)
  {
    foreach (UIRect followWidget in this.followWidgets)
    {
      GameObject cachedGameObject = followWidget.cachedGameObject;
      if (cachedGameObject.activeSelf)
      {
        TweenColor tweenColor = TweenColor.Begin(cachedGameObject, duration, color);
        if (instant && (UnityEngine.Object) tweenColor != (UnityEngine.Object) null || (double) duration <= 0.0)
        {
          tweenColor.value = tweenColor.to;
          tweenColor.enabled = false;
        }
      }
    }
  }

  protected override void SetState(UIButtonColor.State state, bool instant)
  {
    int mState = (int) this.mState;
    base.SetState(state, instant);
    int num = (int) state;
    if (mState == num)
      return;
    switch (state)
    {
      case UIButtonColor.State.Hover:
        this.followColor = this.followHover;
        break;
      case UIButtonColor.State.Pressed:
        this.followColor = this.followPressed;
        break;
      case UIButtonColor.State.Disabled:
        this.followColor = this.followDisabled;
        break;
      default:
        this.followColor = this.followNormal;
        break;
    }
    this.SetTweenColor(instant, this.duration, this.followColor);
  }

  protected override void OnHover(bool isOver)
  {
    this.hover = this.mColor;
    this.followHover = this.followColor;
  }

  protected override void OnPress(bool isPressed)
  {
    if (!this.isEnabled || UICamera.currentTouch == null)
      return;
    if (!this.mInitDone)
      this.OnInit();
    if (!((UnityEngine.Object) this.tweenTarget != (UnityEngine.Object) null))
      return;
    if (isPressed)
      this.SetState(UIButtonColor.State.Pressed, false);
    else if ((UnityEngine.Object) UICamera.currentTouch.current == (UnityEngine.Object) this.gameObject)
    {
      switch (UICamera.currentScheme)
      {
        case UICamera.ControlScheme.Mouse:
          if ((UnityEngine.Object) UICamera.hoveredObject == (UnityEngine.Object) this.gameObject)
          {
            this.SetState(UIButtonColor.State.Normal, false);
            return;
          }
          break;
        case UICamera.ControlScheme.Controller:
          this.SetState(UIButtonColor.State.Hover, false);
          return;
      }
      this.SetState(UIButtonColor.State.Normal, false);
    }
    else
      this.SetState(UIButtonColor.State.Normal, false);
  }
}
