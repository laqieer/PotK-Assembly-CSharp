// Decompiled with JetBrains decompiler
// Type: UITweener
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public abstract class UITweener : MonoBehaviour
{
  public static UITweener current;
  [HideInInspector]
  public UITweener.Method method;
  [HideInInspector]
  public UITweener.Style style;
  [HideInInspector]
  public AnimationCurve animationCurve = new AnimationCurve(new Keyframe[2]
  {
    new Keyframe(0.0f, 0.0f, 0.0f, 1f),
    new Keyframe(1f, 1f, 1f, 0.0f)
  });
  [HideInInspector]
  public bool ignoreTimeScale = true;
  [HideInInspector]
  public float delay;
  [HideInInspector]
  public float duration = 1f;
  [HideInInspector]
  public bool steeperCurves;
  [HideInInspector]
  public int tweenGroup;
  [HideInInspector]
  public List<EventDelegate> onFinished = new List<EventDelegate>();
  [HideInInspector]
  public GameObject eventReceiver;
  [HideInInspector]
  public string callWhenFinished;
  private bool mStarted;
  private float mStartTime;
  private float mDuration;
  private float mAmountPerDelta = 1000f;
  private float mFactor;
  private List<EventDelegate> mTemp = new List<EventDelegate>();

  public float amountPerDelta
  {
    get
    {
      if ((double) this.mDuration != (double) this.duration)
      {
        this.mDuration = this.duration;
        this.mAmountPerDelta = Mathf.Abs((double) this.duration <= 0.0 ? 1000f : 1f / this.duration);
      }
      return this.mAmountPerDelta;
    }
  }

  public float tweenFactor
  {
    get => this.mFactor;
    set => this.mFactor = Mathf.Clamp01(value);
  }

  public AnimationOrTween.Direction direction
  {
    get => (double) this.mAmountPerDelta < 0.0 ? AnimationOrTween.Direction.Reverse : AnimationOrTween.Direction.Forward;
  }

  private void Reset()
  {
    if (this.mStarted)
      return;
    this.SetStartToCurrentValue();
    this.SetEndToCurrentValue();
  }

  protected virtual void Start() => this.Update();

  private void Update()
  {
    float num1 = !this.ignoreTimeScale ? Time.deltaTime : RealTime.deltaTime;
    float num2 = !this.ignoreTimeScale ? Time.time : RealTime.time;
    if (!this.mStarted)
    {
      this.mStarted = true;
      this.mStartTime = num2 + this.delay;
    }
    if ((double) num2 < (double) this.mStartTime)
      return;
    this.mFactor += this.amountPerDelta * num1;
    if (this.style == UITweener.Style.Loop)
    {
      if ((double) this.mFactor > 1.0)
        this.mFactor -= Mathf.Floor(this.mFactor);
    }
    else if (this.style == UITweener.Style.PingPong)
    {
      if ((double) this.mFactor > 1.0)
      {
        this.mFactor = (float) (1.0 - ((double) this.mFactor - (double) Mathf.Floor(this.mFactor)));
        this.mAmountPerDelta = -this.mAmountPerDelta;
      }
      else if ((double) this.mFactor < 0.0)
      {
        this.mFactor = -this.mFactor;
        this.mFactor -= Mathf.Floor(this.mFactor);
        this.mAmountPerDelta = -this.mAmountPerDelta;
      }
    }
    if (this.style == UITweener.Style.Once && ((double) this.duration == 0.0 || (double) this.mFactor > 1.0 || (double) this.mFactor < 0.0))
    {
      this.mFactor = Mathf.Clamp01(this.mFactor);
      this.Sample(this.mFactor, true);
      if ((double) this.duration == 0.0 || (double) this.mFactor == 1.0 && (double) this.mAmountPerDelta > 0.0 || (double) this.mFactor == 0.0 && (double) this.mAmountPerDelta < 0.0)
        ((Behaviour) this).enabled = false;
      UITweener.current = this;
      if (this.onFinished != null)
      {
        List<EventDelegate> onFinished = this.onFinished;
        this.onFinished = new List<EventDelegate>();
        EventDelegate.Execute(onFinished);
        for (int index = 0; index < onFinished.Count; ++index)
        {
          EventDelegate ev = onFinished[index];
          if (ev != null)
          {
            if (!this.mTemp.Contains(ev))
              EventDelegate.Add(this.onFinished, ev, ev.oneShot);
            else
              this.mTemp.Remove(ev);
          }
        }
      }
      if (Object.op_Inequality((Object) this.eventReceiver, (Object) null) && !string.IsNullOrEmpty(this.callWhenFinished))
        this.eventReceiver.SendMessage(this.callWhenFinished, (object) this, (SendMessageOptions) 1);
      UITweener.current = (UITweener) null;
    }
    else
      this.Sample(this.mFactor, false);
  }

  public void SetOnFinished(EventDelegate.Callback del) => EventDelegate.Set(this.onFinished, del);

  public void SetOnFinished(EventDelegate del) => EventDelegate.Set(this.onFinished, del);

  public void AddOnFinished(EventDelegate.Callback del) => EventDelegate.Add(this.onFinished, del);

  public void AddOnFinished(EventDelegate del) => EventDelegate.Add(this.onFinished, del);

  public void RemoveOnFinished(EventDelegate del)
  {
    if (this.onFinished != null)
      this.onFinished.Remove(del);
    if (this.mTemp == null)
      return;
    this.mTemp.Add(del);
  }

  private void OnDisable() => this.mStarted = false;

  public void Sample(float factor, bool isFinished)
  {
    float val = Mathf.Clamp01(factor);
    if (this.method == UITweener.Method.EaseIn)
    {
      val = 1f - Mathf.Sin((float) (1.5707963705062866 * (1.0 - (double) val)));
      if (this.steeperCurves)
        val *= val;
    }
    else if (this.method == UITweener.Method.EaseOut)
    {
      val = Mathf.Sin(1.57079637f * val);
      if (this.steeperCurves)
      {
        float num = 1f - val;
        val = (float) (1.0 - (double) num * (double) num);
      }
    }
    else if (this.method == UITweener.Method.EaseInOut)
    {
      val -= Mathf.Sin(val * 6.28318548f) / 6.28318548f;
      if (this.steeperCurves)
      {
        float num1 = (float) ((double) val * 2.0 - 1.0);
        float num2 = Mathf.Sign(num1);
        float num3 = 1f - Mathf.Abs(num1);
        float num4 = (float) (1.0 - (double) num3 * (double) num3);
        val = (float) ((double) num2 * (double) num4 * 0.5 + 0.5);
      }
    }
    else if (this.method == UITweener.Method.BounceIn)
      val = this.BounceLogic(val);
    else if (this.method == UITweener.Method.BounceOut)
      val = 1f - this.BounceLogic(1f - val);
    this.OnUpdate(this.animationCurve == null ? val : this.animationCurve.Evaluate(val), isFinished);
  }

  private float BounceLogic(float val)
  {
    val = (double) val >= 0.36363598704338074 ? ((double) val >= 0.72727197408676147 ? ((double) val >= 0.909089982509613 ? (float) (121.0 / 16.0 * (double) (val -= 0.9545454f) * (double) val + 63.0 / 64.0) : (float) (121.0 / 16.0 * (double) (val -= 0.818181f) * (double) val + 15.0 / 16.0)) : (float) (121.0 / 16.0 * (double) (val -= 0.545454f) * (double) val + 0.75)) : 7.5685f * val * val;
    return val;
  }

  [Obsolete("Use PlayForward() instead")]
  public void Play() => this.Play(true);

  public void PlayForward() => this.Play(true);

  public void PlayReverse() => this.Play(false);

  public void Play(bool forward)
  {
    this.mAmountPerDelta = Mathf.Abs(this.amountPerDelta);
    if (!forward)
      this.mAmountPerDelta = -this.mAmountPerDelta;
    ((Behaviour) this).enabled = true;
    this.Update();
  }

  public void ResetToBeginning()
  {
    this.mStarted = false;
    this.mFactor = (double) this.mAmountPerDelta >= 0.0 ? 0.0f : 1f;
    this.Sample(this.mFactor, false);
  }

  public void Toggle()
  {
    this.mAmountPerDelta = (double) this.mFactor <= 0.0 ? Mathf.Abs(this.amountPerDelta) : -this.amountPerDelta;
    ((Behaviour) this).enabled = true;
  }

  protected abstract void OnUpdate(float factor, bool isFinished);

  public static T Begin<T>(GameObject go, float duration) where T : UITweener
  {
    T obj = go.GetComponent<T>();
    if (Object.op_Inequality((Object) (object) obj, (Object) null) && obj.tweenGroup != 0)
    {
      obj = (T) null;
      T[] components = go.GetComponents<T>();
      int index = 0;
      for (int length = components.Length; index < length; ++index)
      {
        obj = components[index];
        if (!Object.op_Inequality((Object) (object) obj, (Object) null) || obj.tweenGroup != 0)
          obj = (T) null;
        else
          break;
      }
    }
    if (Object.op_Equality((Object) (object) obj, (Object) null))
      obj = go.AddComponent<T>();
    obj.mStarted = false;
    obj.duration = duration;
    obj.mFactor = 0.0f;
    obj.mAmountPerDelta = Mathf.Abs(obj.mAmountPerDelta);
    obj.style = UITweener.Style.Once;
    obj.animationCurve = new AnimationCurve(new Keyframe[2]
    {
      new Keyframe(0.0f, 0.0f, 0.0f, 1f),
      new Keyframe(1f, 1f, 1f, 0.0f)
    });
    obj.eventReceiver = (GameObject) null;
    obj.callWhenFinished = (string) null;
    obj.enabled = true;
    if ((double) duration <= 0.0)
    {
      obj.Sample(1f, true);
      obj.enabled = false;
    }
    return obj;
  }

  public virtual void SetStartToCurrentValue()
  {
  }

  public virtual void SetEndToCurrentValue()
  {
  }

  public enum Method
  {
    Linear,
    EaseIn,
    EaseOut,
    EaseInOut,
    BounceIn,
    BounceOut,
  }

  public enum Style
  {
    Once,
    Loop,
    PingPong,
  }
}
