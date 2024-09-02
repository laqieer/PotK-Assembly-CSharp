// Decompiled with JetBrains decompiler
// Type: UIButtonOffset
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("NGUI/Interaction/Button Offset")]
public class UIButtonOffset : MonoBehaviour
{
  public Transform tweenTarget;
  public Vector3 hover = Vector3.zero;
  public Vector3 pressed = new Vector3(2f, -2f);
  public float duration = 0.2f;
  private Vector3 mPos;
  private bool mStarted;

  private void Start()
  {
    if (this.mStarted)
      return;
    this.mStarted = true;
    if (Object.op_Equality((Object) this.tweenTarget, (Object) null))
      this.tweenTarget = ((Component) this).transform;
    this.mPos = this.tweenTarget.localPosition;
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
    TweenPosition component = ((Component) this.tweenTarget).GetComponent<TweenPosition>();
    if (!Object.op_Inequality((Object) component, (Object) null))
      return;
    component.value = this.mPos;
    ((Behaviour) component).enabled = false;
  }

  private void OnPress(bool isPressed)
  {
    if (!((Behaviour) this).enabled)
      return;
    if (!this.mStarted)
      this.Start();
    TweenPosition.Begin(((Component) this.tweenTarget).gameObject, this.duration, !isPressed ? (!UICamera.IsHighlighted(((Component) this).gameObject) ? this.mPos : Vector3.op_Addition(this.mPos, this.hover)) : Vector3.op_Addition(this.mPos, this.pressed)).method = UITweener.Method.EaseInOut;
  }

  private void OnHover(bool isOver)
  {
    if (!((Behaviour) this).enabled)
      return;
    if (!this.mStarted)
      this.Start();
    TweenPosition.Begin(((Component) this.tweenTarget).gameObject, this.duration, !isOver ? this.mPos : Vector3.op_Addition(this.mPos, this.hover)).method = UITweener.Method.EaseInOut;
  }

  private void OnSelect(bool isSelected)
  {
    if (!((Behaviour) this).enabled || isSelected && UICamera.currentScheme != UICamera.ControlScheme.Controller)
      return;
    this.OnHover(isSelected);
  }
}
