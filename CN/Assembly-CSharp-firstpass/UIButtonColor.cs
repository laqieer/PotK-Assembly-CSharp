// Decompiled with JetBrains decompiler
// Type: UIButtonColor
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using UnityEngine;

#nullable disable
[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/Button Color")]
public class UIButtonColor : UIWidgetContainer
{
  public GameObject tweenTarget;
  public Color hover = new Color(0.882352948f, 0.784313738f, 0.5882353f, 1f);
  public Color pressed = new Color(0.7176471f, 0.6392157f, 0.482352942f, 1f);
  public Color disabledColor = Color.grey;
  public float duration = 0.2f;
  protected Color mColor;
  protected bool mInitDone;
  protected UIWidget mWidget;
  protected UIButtonColor.State mState;

  public Color defaultColor
  {
    get
    {
      if (!this.mInitDone)
        this.OnInit();
      return this.mColor;
    }
    set
    {
      if (!this.mInitDone)
        this.OnInit();
      this.mColor = value;
    }
  }

  public virtual bool isEnabled
  {
    get => ((Behaviour) this).enabled;
    set => ((Behaviour) this).enabled = value;
  }

  private void Awake()
  {
    if (this.mInitDone)
      return;
    this.OnInit();
  }

  private void Start()
  {
    if (this.isEnabled)
      return;
    this.SetState(UIButtonColor.State.Disabled, true);
  }

  protected virtual void OnInit()
  {
    this.mInitDone = true;
    if (Object.op_Equality((Object) this.tweenTarget, (Object) null))
      this.tweenTarget = ((Component) this).gameObject;
    this.mWidget = this.tweenTarget.GetComponent<UIWidget>();
    if (Object.op_Inequality((Object) this.mWidget, (Object) null))
    {
      this.mColor = this.mWidget.color;
    }
    else
    {
      Renderer component1 = this.tweenTarget.GetComponent<Renderer>();
      if (Object.op_Inequality((Object) component1, (Object) null))
      {
        this.mColor = !Application.isPlaying ? component1.sharedMaterial.color : component1.material.color;
      }
      else
      {
        Light component2 = this.tweenTarget.GetComponent<Light>();
        if (Object.op_Inequality((Object) component2, (Object) null))
        {
          this.mColor = component2.color;
        }
        else
        {
          this.tweenTarget = (GameObject) null;
          this.mInitDone = false;
        }
      }
    }
  }

  protected virtual void OnEnable()
  {
    if (this.mInitDone)
      this.OnHover(UICamera.IsHighlighted(((Component) this).gameObject));
    if (UICamera.currentTouch == null)
      return;
    if (Object.op_Equality((Object) UICamera.currentTouch.pressed, (Object) ((Component) this).gameObject))
    {
      this.OnPress(true);
    }
    else
    {
      if (!Object.op_Equality((Object) UICamera.currentTouch.current, (Object) ((Component) this).gameObject))
        return;
      this.OnHover(true);
    }
  }

  protected virtual void OnDisable()
  {
    if (!this.mInitDone || !Object.op_Inequality((Object) this.tweenTarget, (Object) null))
      return;
    this.SetState(UIButtonColor.State.Normal, true);
    TweenColor component = this.tweenTarget.GetComponent<TweenColor>();
    if (!Object.op_Inequality((Object) component, (Object) null))
      return;
    component.value = this.mColor;
    ((Behaviour) component).enabled = false;
  }

  protected virtual void OnHover(bool isOver)
  {
    if (!this.isEnabled)
      return;
    if (!this.mInitDone)
      this.OnInit();
    if (!Object.op_Inequality((Object) this.tweenTarget, (Object) null))
      return;
    this.SetState(!isOver ? UIButtonColor.State.Normal : UIButtonColor.State.Hover, false);
  }

  protected virtual void OnPress(bool isPressed)
  {
    if (!this.isEnabled || UICamera.currentTouch == null)
      return;
    if (!this.mInitDone)
      this.OnInit();
    if (!Object.op_Inequality((Object) this.tweenTarget, (Object) null))
      return;
    if (isPressed)
      this.SetState(UIButtonColor.State.Pressed, false);
    else if (Object.op_Equality((Object) UICamera.currentTouch.current, (Object) ((Component) this).gameObject))
    {
      switch (UICamera.currentScheme)
      {
        case UICamera.ControlScheme.Mouse:
          if (Object.op_Equality((Object) UICamera.hoveredObject, (Object) ((Component) this).gameObject))
          {
            this.SetState(UIButtonColor.State.Hover, false);
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

  protected virtual void OnDragOver()
  {
    if (!this.isEnabled)
      return;
    if (!this.mInitDone)
      this.OnInit();
    if (!Object.op_Inequality((Object) this.tweenTarget, (Object) null))
      return;
    this.SetState(UIButtonColor.State.Pressed, false);
  }

  protected virtual void OnDragOut()
  {
    if (!this.isEnabled)
      return;
    if (!this.mInitDone)
      this.OnInit();
    if (!Object.op_Inequality((Object) this.tweenTarget, (Object) null))
      return;
    this.SetState(UIButtonColor.State.Normal, false);
  }

  protected virtual void OnSelect(bool isSelected)
  {
    if (!this.isEnabled || isSelected && UICamera.currentScheme != UICamera.ControlScheme.Controller || !Object.op_Inequality((Object) this.tweenTarget, (Object) null))
      return;
    this.OnHover(isSelected);
  }

  protected virtual void SetState(UIButtonColor.State state, bool instant)
  {
    if (!this.mInitDone)
    {
      this.mInitDone = true;
      this.OnInit();
    }
    if (this.mState == state)
      return;
    this.mState = state;
    TweenColor tweenColor;
    switch (this.mState)
    {
      case UIButtonColor.State.Hover:
        tweenColor = TweenColor.Begin(this.tweenTarget, this.duration, this.hover);
        break;
      case UIButtonColor.State.Pressed:
        tweenColor = TweenColor.Begin(this.tweenTarget, this.duration, this.pressed);
        break;
      case UIButtonColor.State.Disabled:
        tweenColor = TweenColor.Begin(this.tweenTarget, this.duration, this.disabledColor);
        break;
      default:
        tweenColor = TweenColor.Begin(this.tweenTarget, this.duration, this.mColor);
        break;
    }
    if (!instant || !Object.op_Inequality((Object) tweenColor, (Object) null))
      return;
    tweenColor.value = tweenColor.to;
    ((Behaviour) tweenColor).enabled = false;
  }

  protected enum State
  {
    Normal,
    Hover,
    Pressed,
    Disabled,
  }
}
