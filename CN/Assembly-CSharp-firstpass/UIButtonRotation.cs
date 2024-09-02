// Decompiled with JetBrains decompiler
// Type: UIButtonRotation
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("NGUI/Interaction/Button Rotation")]
public class UIButtonRotation : MonoBehaviour
{
  public Transform tweenTarget;
  public Vector3 hover = Vector3.zero;
  public Vector3 pressed = Vector3.zero;
  public float duration = 0.2f;
  private Quaternion mRot;
  private bool mStarted;

  private void Start()
  {
    if (this.mStarted)
      return;
    this.mStarted = true;
    if (Object.op_Equality((Object) this.tweenTarget, (Object) null))
      this.tweenTarget = ((Component) this).transform;
    this.mRot = this.tweenTarget.localRotation;
  }

  private void OnEnable()
  {
    if (!this.mStarted)
      return;
    this.OnHover(UICamera.IsHighlighted(((Component) this).gameObject));
  }

  private void OnDisable()
  {
    if (!this.mStarted || !Object.op_Inequality((Object) this.tweenTarget, (Object) null))
      return;
    TweenRotation component = ((Component) this.tweenTarget).GetComponent<TweenRotation>();
    if (!Object.op_Inequality((Object) component, (Object) null))
      return;
    component.value = this.mRot;
    ((Behaviour) component).enabled = false;
  }

  private void OnPress(bool isPressed)
  {
    if (!((Behaviour) this).enabled)
      return;
    if (!this.mStarted)
      this.Start();
    TweenRotation.Begin(((Component) this.tweenTarget).gameObject, this.duration, !isPressed ? (!UICamera.IsHighlighted(((Component) this).gameObject) ? this.mRot : Quaternion.op_Multiply(this.mRot, Quaternion.Euler(this.hover))) : Quaternion.op_Multiply(this.mRot, Quaternion.Euler(this.pressed))).method = UITweener.Method.EaseInOut;
  }

  private void OnHover(bool isOver)
  {
    if (!((Behaviour) this).enabled)
      return;
    if (!this.mStarted)
      this.Start();
    TweenRotation.Begin(((Component) this.tweenTarget).gameObject, this.duration, !isOver ? this.mRot : Quaternion.op_Multiply(this.mRot, Quaternion.Euler(this.hover))).method = UITweener.Method.EaseInOut;
  }

  private void OnSelect(bool isSelected)
  {
    if (!((Behaviour) this).enabled || isSelected && UICamera.currentScheme != UICamera.ControlScheme.Controller)
      return;
    this.OnHover(isSelected);
  }
}
