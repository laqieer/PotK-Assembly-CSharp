// Decompiled with JetBrains decompiler
// Type: UIPlayTween
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using AnimationOrTween;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/Play Tween")]
public class UIPlayTween : MonoBehaviour
{
  public GameObject tweenTarget;
  public int tweenGroup;
  public AnimationOrTween.Trigger trigger;
  public AnimationOrTween.Direction playDirection = AnimationOrTween.Direction.Forward;
  public bool resetOnPlay;
  public bool resetIfDisabled;
  public EnableCondition ifDisabledOnPlay;
  public DisableCondition disableWhenFinished;
  public bool includeChildren;
  public List<EventDelegate> onFinished = new List<EventDelegate>();
  [SerializeField]
  [HideInInspector]
  private GameObject eventReceiver;
  [SerializeField]
  [HideInInspector]
  private string callWhenFinished;
  private UITweener[] mTweens;
  private bool mStarted;
  private int mActive;
  private bool mActivated;

  private void Awake()
  {
    if (!Object.op_Inequality((Object) this.eventReceiver, (Object) null) || !EventDelegate.IsValid(this.onFinished))
      return;
    this.eventReceiver = (GameObject) null;
    this.callWhenFinished = (string) null;
  }

  private void Start()
  {
    this.mStarted = true;
    if (!Object.op_Equality((Object) this.tweenTarget, (Object) null))
      return;
    this.tweenTarget = ((Component) this).gameObject;
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
    this.mActivated = isOver && this.trigger == AnimationOrTween.Trigger.OnHover;
    this.Play(isOver);
  }

  private void OnDragOut()
  {
    if (!((Behaviour) this).enabled || !this.mActivated)
      return;
    this.mActivated = false;
    this.Play(false);
  }

  private void OnPress(bool isPressed)
  {
    if (!((Behaviour) this).enabled || this.trigger != AnimationOrTween.Trigger.OnPress && (this.trigger != AnimationOrTween.Trigger.OnPressTrue || !isPressed) && (this.trigger != AnimationOrTween.Trigger.OnPressFalse || isPressed))
      return;
    this.mActivated = isPressed && this.trigger == AnimationOrTween.Trigger.OnPress;
    this.Play(isPressed);
  }

  private void OnClick()
  {
    if (!((Behaviour) this).enabled || this.trigger != AnimationOrTween.Trigger.OnClick)
      return;
    this.Play(true);
  }

  private void OnDoubleClick()
  {
    if (!((Behaviour) this).enabled || this.trigger != AnimationOrTween.Trigger.OnDoubleClick)
      return;
    this.Play(true);
  }

  private void OnSelect(bool isSelected)
  {
    if (!((Behaviour) this).enabled || this.trigger != AnimationOrTween.Trigger.OnSelect && (this.trigger != AnimationOrTween.Trigger.OnSelectTrue || !isSelected) && (this.trigger != AnimationOrTween.Trigger.OnSelectFalse || isSelected))
      return;
    this.mActivated = isSelected && this.trigger == AnimationOrTween.Trigger.OnSelect;
    this.Play(isSelected);
  }

  private void OnActivate(bool isActive)
  {
    if (!((Behaviour) this).enabled || this.trigger != AnimationOrTween.Trigger.OnActivate && (this.trigger != AnimationOrTween.Trigger.OnActivateTrue || !isActive) && (this.trigger != AnimationOrTween.Trigger.OnActivateFalse || isActive))
      return;
    this.Play(isActive);
  }

  private void Update()
  {
    if (this.disableWhenFinished == DisableCondition.DoNotDisable || this.mTweens == null)
      return;
    bool flag1 = true;
    bool flag2 = true;
    int index = 0;
    for (int length = this.mTweens.Length; index < length; ++index)
    {
      UITweener mTween = this.mTweens[index];
      if (mTween.tweenGroup == this.tweenGroup)
      {
        if (((Behaviour) mTween).enabled)
        {
          flag1 = false;
          break;
        }
        if (mTween.direction != (AnimationOrTween.Direction) this.disableWhenFinished)
          flag2 = false;
      }
    }
    if (!flag1)
      return;
    if (flag2)
      NGUITools.SetActive(this.tweenTarget, false);
    this.mTweens = (UITweener[]) null;
  }

  public void Play(bool forward)
  {
    this.mActive = 0;
    GameObject go = !Object.op_Equality((Object) this.tweenTarget, (Object) null) ? this.tweenTarget : ((Component) this).gameObject;
    if (!NGUITools.GetActive(go))
    {
      if (this.ifDisabledOnPlay != EnableCondition.EnableThenPlay)
        return;
      NGUITools.SetActive(go, true);
    }
    this.mTweens = !this.includeChildren ? go.GetComponents<UITweener>() : go.GetComponentsInChildren<UITweener>();
    if (this.mTweens.Length == 0)
    {
      if (this.disableWhenFinished == DisableCondition.DoNotDisable)
        return;
      NGUITools.SetActive(this.tweenTarget, false);
    }
    else
    {
      bool flag = false;
      if (this.playDirection == AnimationOrTween.Direction.Reverse)
        forward = !forward;
      int index = 0;
      for (int length = this.mTweens.Length; index < length; ++index)
      {
        UITweener mTween = this.mTweens[index];
        if (mTween.tweenGroup == this.tweenGroup)
        {
          if (!flag && !NGUITools.GetActive(go))
          {
            flag = true;
            NGUITools.SetActive(go, true);
          }
          ++this.mActive;
          if (this.playDirection == AnimationOrTween.Direction.Toggle)
          {
            EventDelegate.Add(mTween.onFinished, new EventDelegate.Callback(this.OnFinished), true);
            mTween.Toggle();
          }
          else
          {
            if (this.resetOnPlay || this.resetIfDisabled && !((Behaviour) mTween).enabled)
              mTween.ResetToBeginning();
            EventDelegate.Add(mTween.onFinished, new EventDelegate.Callback(this.OnFinished), true);
            mTween.Play(forward);
          }
        }
      }
    }
  }

  private void OnFinished()
  {
    if (--this.mActive != 0)
      return;
    EventDelegate.Execute(this.onFinished);
    if (Object.op_Inequality((Object) this.eventReceiver, (Object) null) && !string.IsNullOrEmpty(this.callWhenFinished))
      this.eventReceiver.SendMessage(this.callWhenFinished, (SendMessageOptions) 1);
    this.eventReceiver = (GameObject) null;
  }
}
