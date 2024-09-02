// Decompiled with JetBrains decompiler
// Type: UISlider
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using System;
using UnityEngine;

#nullable disable
[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/NGUI Slider")]
public class UISlider : UIProgressBar
{
  [SerializeField]
  [HideInInspector]
  private Transform foreground;
  [SerializeField]
  [HideInInspector]
  private float rawValue = 1f;
  [HideInInspector]
  [SerializeField]
  private UISlider.Direction direction = UISlider.Direction.Upgraded;
  [SerializeField]
  [HideInInspector]
  protected bool mInverted;

  [Obsolete("Use 'value' instead")]
  public float sliderValue
  {
    get => this.value;
    set => this.value = value;
  }

  [Obsolete("Use 'fillDirection' instead")]
  public bool inverted
  {
    get => this.isInverted;
    set
    {
    }
  }

  protected override void Upgrade()
  {
    if (this.direction == UISlider.Direction.Upgraded)
      return;
    this.mValue = this.rawValue;
    if (Object.op_Inequality((Object) this.foreground, (Object) null))
      this.mFG = ((Component) this.foreground).GetComponent<UIWidget>();
    if (this.direction == UISlider.Direction.Horizontal)
      this.mFill = !this.mInverted ? UIProgressBar.FillDirection.LeftToRight : UIProgressBar.FillDirection.RightToLeft;
    else
      this.mFill = !this.mInverted ? UIProgressBar.FillDirection.BottomToTop : UIProgressBar.FillDirection.TopToBottom;
    this.direction = UISlider.Direction.Upgraded;
  }

  protected override void OnStart()
  {
    UIEventListener uiEventListener1 = UIEventListener.Get(!Object.op_Inequality((Object) this.mBG, (Object) null) || !Object.op_Inequality((Object) ((Component) this.mBG).GetComponent<Collider>(), (Object) null) ? ((Component) this).gameObject : ((Component) this.mBG).gameObject);
    uiEventListener1.onPress += new UIEventListener.BoolDelegate(this.OnPressBackground);
    uiEventListener1.onDrag += new UIEventListener.VectorDelegate(this.OnDragBackground);
    if (!Object.op_Inequality((Object) this.thumb, (Object) null) || !Object.op_Inequality((Object) ((Component) this.thumb).GetComponent<Collider>(), (Object) null) || !Object.op_Equality((Object) this.mFG, (Object) null) && !Object.op_Inequality((Object) this.thumb, (Object) this.mFG.cachedTransform))
      return;
    UIEventListener uiEventListener2 = UIEventListener.Get(((Component) this.thumb).gameObject);
    uiEventListener2.onPress += new UIEventListener.BoolDelegate(this.OnPressForeground);
    uiEventListener2.onDrag += new UIEventListener.VectorDelegate(this.OnDragForeground);
  }

  protected void OnPressBackground(GameObject go, bool isPressed)
  {
    if (UICamera.currentScheme == UICamera.ControlScheme.Controller)
      return;
    this.mCam = UICamera.currentCamera;
    this.value = this.ScreenToValue(UICamera.lastTouchPosition);
    if (isPressed || this.onDragFinished == null)
      return;
    this.onDragFinished();
  }

  protected void OnDragBackground(GameObject go, Vector2 delta)
  {
    if (UICamera.currentScheme == UICamera.ControlScheme.Controller)
      return;
    this.mCam = UICamera.currentCamera;
    this.value = this.ScreenToValue(UICamera.lastTouchPosition);
  }

  protected void OnPressForeground(GameObject go, bool isPressed)
  {
    if (UICamera.currentScheme == UICamera.ControlScheme.Controller)
      return;
    if (isPressed)
    {
      this.mOffset = !Object.op_Equality((Object) this.mFG, (Object) null) ? this.value - this.ScreenToValue(UICamera.lastTouchPosition) : 0.0f;
    }
    else
    {
      if (this.onDragFinished == null)
        return;
      this.onDragFinished();
    }
  }

  protected void OnDragForeground(GameObject go, Vector2 delta)
  {
    if (UICamera.currentScheme == UICamera.ControlScheme.Controller)
      return;
    this.mCam = UICamera.currentCamera;
    this.value = this.mOffset + this.ScreenToValue(UICamera.lastTouchPosition);
  }

  protected void OnKey(KeyCode key)
  {
    if (!((Behaviour) this).enabled)
      return;
    float num = (double) this.numberOfSteps <= 1.0 ? 0.125f : 1f / (float) (this.numberOfSteps - 1);
    if (this.fillDirection == UIProgressBar.FillDirection.LeftToRight || this.fillDirection == UIProgressBar.FillDirection.RightToLeft)
    {
      if (key == 276)
      {
        this.value = this.mValue - num;
      }
      else
      {
        if (key != 275)
          return;
        this.value = this.mValue + num;
      }
    }
    else if (key == 274)
    {
      this.value = this.mValue - num;
    }
    else
    {
      if (key != 273)
        return;
      this.value = this.mValue + num;
    }
  }

  private enum Direction
  {
    Horizontal,
    Vertical,
    Upgraded,
  }
}
