// Decompiled with JetBrains decompiler
// Type: UIButton
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
[AddComponentMenu("NGUI/Interaction/Button")]
public class UIButton : UIButtonColor
{
  public static UIButton current;
  public bool dragHighlight;
  public string hoverSprite;
  public string pressedSprite;
  public string disabledSprite;
  public bool pixelSnap;
  public List<EventDelegate> onClick = new List<EventDelegate>();
  [NonSerialized]
  private string mNormalSprite;
  [NonSerialized]
  private UISprite mSprite;

  public override bool isEnabled
  {
    get
    {
      if (!((Behaviour) this).enabled)
        return false;
      Collider component = ((Component) this).GetComponent<Collider>();
      return Object.op_Implicit((Object) component) && component.enabled;
    }
    set
    {
      Collider component = ((Component) this).GetComponent<Collider>();
      if (Object.op_Inequality((Object) component, (Object) null))
      {
        component.enabled = value;
        this.SetState(!value ? UIButtonColor.State.Disabled : UIButtonColor.State.Normal, false);
      }
      else
        ((Behaviour) this).enabled = value;
    }
  }

  public string normalSprite
  {
    get
    {
      if (!this.mInitDone)
        this.OnInit();
      return this.mNormalSprite;
    }
    set
    {
      this.mNormalSprite = value;
      if (this.mState != UIButtonColor.State.Normal)
        return;
      this.SetSprite(value);
    }
  }

  protected override void OnInit()
  {
    base.OnInit();
    this.mSprite = this.mWidget as UISprite;
    if (!Object.op_Inequality((Object) this.mSprite, (Object) null))
      return;
    this.mNormalSprite = this.mSprite.spriteName;
  }

  protected override void OnEnable()
  {
    if (this.isEnabled)
    {
      if (!this.mInitDone)
        return;
      if (UICamera.currentScheme == UICamera.ControlScheme.Controller)
        this.OnHover(Object.op_Equality((Object) UICamera.selectedObject, (Object) ((Component) this).gameObject));
      else if (UICamera.currentScheme == UICamera.ControlScheme.Mouse)
        this.OnHover(Object.op_Equality((Object) UICamera.hoveredObject, (Object) ((Component) this).gameObject));
      else
        this.SetState(UIButtonColor.State.Normal, false);
    }
    else
      this.SetState(UIButtonColor.State.Disabled, true);
  }

  protected override void OnDragOver()
  {
    if (!this.isEnabled || !this.dragHighlight && !Object.op_Equality((Object) UICamera.currentTouch.pressed, (Object) ((Component) this).gameObject))
      return;
    base.OnDragOver();
  }

  protected override void OnDragOut()
  {
    if (!this.isEnabled || !this.dragHighlight && !Object.op_Equality((Object) UICamera.currentTouch.pressed, (Object) ((Component) this).gameObject))
      return;
    base.OnDragOut();
  }

  protected virtual void OnClick()
  {
    if (!this.isEnabled)
      return;
    UIButton.current = this;
    EventDelegate.Execute(this.onClick);
    UIButton.current = (UIButton) null;
  }

  protected override void SetState(UIButtonColor.State state, bool immediate)
  {
    base.SetState(state, immediate);
    switch (state)
    {
      case UIButtonColor.State.Normal:
        this.SetSprite(this.mNormalSprite);
        break;
      case UIButtonColor.State.Hover:
        this.SetSprite(this.hoverSprite);
        break;
      case UIButtonColor.State.Pressed:
        this.SetSprite(this.pressedSprite);
        break;
      case UIButtonColor.State.Disabled:
        this.SetSprite(this.disabledSprite);
        break;
    }
  }

  protected void SetSprite(string sp)
  {
    if (!Object.op_Inequality((Object) this.mSprite, (Object) null) || string.IsNullOrEmpty(sp) || !(this.mSprite.spriteName != sp))
      return;
    this.mSprite.spriteName = sp;
    if (!this.pixelSnap)
      return;
    this.mSprite.MakePixelPerfect();
  }
}
