// Decompiled with JetBrains decompiler
// Type: UIPlayAnimation
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using AnimationOrTween;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/Play Animation")]
public class UIPlayAnimation : MonoBehaviour
{
  public Animation target;
  public Animator animator;
  public string clipName;
  public AnimationOrTween.Trigger trigger;
  public AnimationOrTween.Direction playDirection = AnimationOrTween.Direction.Forward;
  public bool resetOnPlay;
  public bool clearSelection;
  public EnableCondition ifDisabledOnPlay;
  public DisableCondition disableWhenFinished;
  public List<EventDelegate> onFinished = new List<EventDelegate>();
  [HideInInspector]
  [SerializeField]
  private GameObject eventReceiver;
  [SerializeField]
  [HideInInspector]
  private string callWhenFinished;
  private bool mStarted;
  private bool mActivated;
  private bool dragHighlight;

  private bool dualState => this.trigger == AnimationOrTween.Trigger.OnPress || this.trigger == AnimationOrTween.Trigger.OnHover;

  private void Awake()
  {
    UIButton component = ((Component) this).GetComponent<UIButton>();
    if (Object.op_Inequality((Object) component, (Object) null))
      this.dragHighlight = component.dragHighlight;
    if (!Object.op_Inequality((Object) this.eventReceiver, (Object) null) || !EventDelegate.IsValid(this.onFinished))
      return;
    this.eventReceiver = (GameObject) null;
    this.callWhenFinished = (string) null;
  }

  private void Start()
  {
    this.mStarted = true;
    if (Object.op_Equality((Object) this.target, (Object) null) && Object.op_Equality((Object) this.animator, (Object) null))
      this.animator = ((Component) this).GetComponentInChildren<Animator>();
    if (Object.op_Inequality((Object) this.animator, (Object) null))
    {
      if (!((Behaviour) this.animator).enabled)
        return;
      ((Behaviour) this.animator).enabled = false;
    }
    else
    {
      if (Object.op_Equality((Object) this.target, (Object) null))
        this.target = ((Component) this).GetComponentInChildren<Animation>();
      if (!Object.op_Inequality((Object) this.target, (Object) null) || !((Behaviour) this.target).enabled)
        return;
      ((Behaviour) this.target).enabled = false;
    }
  }

  private void OnEnable()
  {
    if (this.mStarted)
      this.OnHover(UICamera.IsHighlighted(((Component) this).gameObject));
    if (UICamera.currentTouch == null)
      return;
    if (this.trigger == AnimationOrTween.Trigger.OnPress || this.trigger == AnimationOrTween.Trigger.OnPressTrue)
      this.mActivated = Object.op_Equality((Object) UICamera.currentTouch.pressed, (Object) ((Component) this).gameObject);
    if (this.trigger != AnimationOrTween.Trigger.OnHover && this.trigger != AnimationOrTween.Trigger.OnHoverTrue)
      return;
    this.mActivated = Object.op_Equality((Object) UICamera.currentTouch.current, (Object) ((Component) this).gameObject);
  }

  private void OnHover(bool isOver)
  {
    if (!((Behaviour) this).enabled || this.trigger != AnimationOrTween.Trigger.OnHover && (this.trigger != AnimationOrTween.Trigger.OnHoverTrue || !isOver) && (this.trigger != AnimationOrTween.Trigger.OnHoverFalse || isOver))
      return;
    this.Play(isOver, this.dualState);
  }

  private void OnPress(bool isPressed)
  {
    if (!((Behaviour) this).enabled || this.trigger != AnimationOrTween.Trigger.OnPress && (this.trigger != AnimationOrTween.Trigger.OnPressTrue || !isPressed) && (this.trigger != AnimationOrTween.Trigger.OnPressFalse || isPressed))
      return;
    this.Play(isPressed, this.dualState);
  }

  private void OnClick()
  {
    if (!((Behaviour) this).enabled || this.trigger != AnimationOrTween.Trigger.OnClick)
      return;
    this.Play(true, false);
  }

  private void OnDoubleClick()
  {
    if (!((Behaviour) this).enabled || this.trigger != AnimationOrTween.Trigger.OnDoubleClick)
      return;
    this.Play(true, false);
  }

  private void OnSelect(bool isSelected)
  {
    if (!((Behaviour) this).enabled || this.trigger != AnimationOrTween.Trigger.OnSelect && (this.trigger != AnimationOrTween.Trigger.OnSelectTrue || !isSelected) && (this.trigger != AnimationOrTween.Trigger.OnSelectFalse || isSelected))
      return;
    this.Play(isSelected, this.dualState);
  }

  private void OnActivate(bool isActive)
  {
    if (!((Behaviour) this).enabled || this.trigger != AnimationOrTween.Trigger.OnActivate && (this.trigger != AnimationOrTween.Trigger.OnActivateTrue || !isActive) && (this.trigger != AnimationOrTween.Trigger.OnActivateFalse || isActive))
      return;
    this.Play(isActive, this.dualState);
  }

  private void OnDragOver()
  {
    if (!((Behaviour) this).enabled || !this.dualState)
      return;
    if (Object.op_Equality((Object) UICamera.currentTouch.dragged, (Object) ((Component) this).gameObject))
    {
      this.Play(true, true);
    }
    else
    {
      if (!this.dragHighlight || this.trigger != AnimationOrTween.Trigger.OnPress)
        return;
      this.Play(true, true);
    }
  }

  private void OnDragOut()
  {
    if (!((Behaviour) this).enabled || !this.dualState || !Object.op_Inequality((Object) UICamera.hoveredObject, (Object) ((Component) this).gameObject))
      return;
    this.Play(false, true);
  }

  private void OnDrop(GameObject go)
  {
    if (!((Behaviour) this).enabled || this.trigger != AnimationOrTween.Trigger.OnPress || !Object.op_Inequality((Object) UICamera.currentTouch.dragged, (Object) ((Component) this).gameObject))
      return;
    this.Play(false, true);
  }

  public void Play(bool forward) => this.Play(forward, true);

  public void Play(bool forward, bool onlyIfDifferent)
  {
    if (!Object.op_Implicit((Object) this.target) && !Object.op_Implicit((Object) this.animator))
      return;
    if (onlyIfDifferent)
    {
      if (this.mActivated == forward)
        return;
      this.mActivated = forward;
    }
    if (this.clearSelection && Object.op_Equality((Object) UICamera.selectedObject, (Object) ((Component) this).gameObject))
      UICamera.selectedObject = (GameObject) null;
    int num = -(int) this.playDirection;
    AnimationOrTween.Direction playDirection = !forward ? (AnimationOrTween.Direction) num : this.playDirection;
    ActiveAnimation activeAnimation = !Object.op_Implicit((Object) this.target) ? ActiveAnimation.Play(this.animator, this.clipName, playDirection, this.ifDisabledOnPlay, this.disableWhenFinished) : ActiveAnimation.Play(this.target, this.clipName, playDirection, this.ifDisabledOnPlay, this.disableWhenFinished);
    if (!Object.op_Inequality((Object) activeAnimation, (Object) null))
      return;
    if (this.resetOnPlay)
      activeAnimation.Reset();
    for (int index = 0; index < this.onFinished.Count; ++index)
      EventDelegate.Add(activeAnimation.onFinished, new EventDelegate.Callback(this.OnFinished), true);
  }

  private void OnFinished()
  {
    EventDelegate.Execute(this.onFinished);
    if (Object.op_Inequality((Object) this.eventReceiver, (Object) null) && !string.IsNullOrEmpty(this.callWhenFinished))
      this.eventReceiver.SendMessage(this.callWhenFinished, (SendMessageOptions) 1);
    this.eventReceiver = (GameObject) null;
  }
}
