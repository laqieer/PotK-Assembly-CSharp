// Decompiled with JetBrains decompiler
// Type: UIToggle
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/Toggle")]
public class UIToggle : UIWidgetContainer
{
  public static BetterList<UIToggle> list = new BetterList<UIToggle>();
  public static UIToggle current;
  public int group;
  public UIWidget activeSprite;
  public Animation activeAnimation;
  public bool startsActive;
  public bool instantTween;
  public bool optionCanBeNone;
  public List<EventDelegate> onChange = new List<EventDelegate>();
  [SerializeField]
  [HideInInspector]
  private UISprite checkSprite;
  [HideInInspector]
  [SerializeField]
  private Animation checkAnimation;
  [SerializeField]
  [HideInInspector]
  private GameObject eventReceiver;
  [SerializeField]
  [HideInInspector]
  private string functionName = "OnActivate";
  [HideInInspector]
  [SerializeField]
  private bool startsChecked;
  private bool mIsActive = true;
  private bool mStarted;

  public bool value
  {
    get => this.mIsActive;
    set
    {
      if (this.group != 0 && !value && !this.optionCanBeNone && this.mStarted)
        return;
      this.Set(value);
    }
  }

  [Obsolete("Use 'value' instead")]
  public bool isChecked
  {
    get => this.value;
    set => this.value = value;
  }

  public static UIToggle GetActiveToggle(int group)
  {
    for (int i = 0; i < UIToggle.list.size; ++i)
    {
      UIToggle activeToggle = UIToggle.list[i];
      if (Object.op_Inequality((Object) activeToggle, (Object) null) && activeToggle.group == group && activeToggle.mIsActive)
        return activeToggle;
    }
    return (UIToggle) null;
  }

  private void OnEnable() => UIToggle.list.Add(this);

  private void OnDisable() => UIToggle.list.Remove(this);

  private void Start()
  {
    if (this.startsChecked)
    {
      this.startsChecked = false;
      this.startsActive = true;
    }
    if (!Application.isPlaying)
    {
      if (Object.op_Inequality((Object) this.checkSprite, (Object) null) && Object.op_Equality((Object) this.activeSprite, (Object) null))
      {
        this.activeSprite = (UIWidget) this.checkSprite;
        this.checkSprite = (UISprite) null;
      }
      if (Object.op_Inequality((Object) this.checkAnimation, (Object) null) && Object.op_Equality((Object) this.activeAnimation, (Object) null))
      {
        this.activeAnimation = this.checkAnimation;
        this.checkAnimation = (Animation) null;
      }
      if (Application.isPlaying && Object.op_Inequality((Object) this.activeSprite, (Object) null))
        this.activeSprite.alpha = !this.startsActive ? 0.0f : 1f;
      if (!EventDelegate.IsValid(this.onChange))
        return;
      this.eventReceiver = (GameObject) null;
      this.functionName = (string) null;
    }
    else
    {
      this.mIsActive = !this.startsActive;
      this.mStarted = true;
      this.Set(this.startsActive);
    }
  }

  private void OnClick()
  {
    if (!((Behaviour) this).enabled)
      return;
    this.value = !this.value;
  }

  private void Set(bool state)
  {
    if (!this.mStarted)
    {
      this.mIsActive = state;
      this.startsActive = state;
      if (!Object.op_Inequality((Object) this.activeSprite, (Object) null))
        return;
      this.activeSprite.alpha = !state ? 0.0f : 1f;
    }
    else
    {
      if (this.mIsActive == state)
        return;
      if (this.group != 0 && state)
      {
        int i = 0;
        int size = UIToggle.list.size;
        while (i < size)
        {
          UIToggle uiToggle = UIToggle.list[i];
          if (Object.op_Inequality((Object) uiToggle, (Object) this) && uiToggle.group == this.group)
            uiToggle.Set(false);
          if (UIToggle.list.size != size)
          {
            size = UIToggle.list.size;
            i = 0;
          }
          else
            ++i;
        }
      }
      this.mIsActive = state;
      if (Object.op_Inequality((Object) this.activeSprite, (Object) null))
      {
        if (this.instantTween)
          this.activeSprite.alpha = !this.mIsActive ? 0.0f : 1f;
        else
          TweenAlpha.Begin(((Component) this.activeSprite).gameObject, 0.15f, !this.mIsActive ? 0.0f : 1f);
      }
      UIToggle.current = this;
      if (EventDelegate.IsValid(this.onChange))
        EventDelegate.Execute(this.onChange);
      else if (Object.op_Inequality((Object) this.eventReceiver, (Object) null) && !string.IsNullOrEmpty(this.functionName))
        this.eventReceiver.SendMessage(this.functionName, (object) this.mIsActive, (SendMessageOptions) 1);
      UIToggle.current = (UIToggle) null;
      if (!Object.op_Inequality((Object) this.activeAnimation, (Object) null))
        return;
      ActiveAnimation.Play(this.activeAnimation, !state ? AnimationOrTween.Direction.Reverse : AnimationOrTween.Direction.Forward);
    }
  }
}
