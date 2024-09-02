// Decompiled with JetBrains decompiler
// Type: EventDelegate
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
[Serializable]
public class EventDelegate
{
  [SerializeField]
  private MonoBehaviour mTarget;
  [SerializeField]
  private string mMethodName;
  public bool oneShot;
  private EventDelegate.Callback mCachedCallback;
  private bool mRawDelegate;
  private static int s_Hash = nameof (EventDelegate).GetHashCode();

  public EventDelegate()
  {
  }

  public EventDelegate(EventDelegate.Callback call) => this.Set(call);

  public EventDelegate(MonoBehaviour target, string methodName) => this.Set(target, methodName);

  public MonoBehaviour target
  {
    get => this.mTarget;
    set
    {
      this.mTarget = value;
      this.mCachedCallback = (EventDelegate.Callback) null;
      this.mRawDelegate = false;
    }
  }

  public string methodName
  {
    get => this.mMethodName;
    set
    {
      this.mMethodName = value;
      this.mCachedCallback = (EventDelegate.Callback) null;
      this.mRawDelegate = false;
    }
  }

  public bool isValid
  {
    get
    {
      if (this.mRawDelegate && this.mCachedCallback != null)
        return true;
      return Object.op_Inequality((Object) this.mTarget, (Object) null) && !string.IsNullOrEmpty(this.mMethodName);
    }
  }

  public bool isEnabled
  {
    get
    {
      if (this.mRawDelegate && this.mCachedCallback != null)
        return true;
      if (Object.op_Equality((Object) this.mTarget, (Object) null))
        return false;
      MonoBehaviour mTarget = this.mTarget;
      return Object.op_Equality((Object) mTarget, (Object) null) || ((Behaviour) mTarget).enabled;
    }
  }

  private static string GetMethodName(EventDelegate.Callback callback) => callback.Method.Name;

  private static bool IsValid(EventDelegate.Callback callback)
  {
    return callback != null && (object) callback.Method != null;
  }

  public override bool Equals(object obj)
  {
    switch (obj)
    {
      case null:
        return !this.isValid;
      case EventDelegate.Callback _:
        EventDelegate.Callback callback = obj as EventDelegate.Callback;
        if (callback.Equals((object) this.mCachedCallback))
          return true;
        return Object.op_Equality((Object) this.mTarget, (Object) (callback.Target as MonoBehaviour)) && string.Equals(this.mMethodName, EventDelegate.GetMethodName(callback));
      case EventDelegate _:
        EventDelegate eventDelegate = obj as EventDelegate;
        return Object.op_Equality((Object) this.mTarget, (Object) eventDelegate.mTarget) && string.Equals(this.mMethodName, eventDelegate.mMethodName);
      default:
        return false;
    }
  }

  public override int GetHashCode() => EventDelegate.s_Hash;

  private EventDelegate.Callback Get()
  {
    if (!this.mRawDelegate && (this.mCachedCallback == null || Object.op_Inequality((Object) (this.mCachedCallback.Target as MonoBehaviour), (Object) this.mTarget) || EventDelegate.GetMethodName(this.mCachedCallback) != this.mMethodName))
    {
      if (!Object.op_Inequality((Object) this.mTarget, (Object) null) || string.IsNullOrEmpty(this.mMethodName))
        return (EventDelegate.Callback) null;
      this.mCachedCallback = (EventDelegate.Callback) Delegate.CreateDelegate(typeof (EventDelegate.Callback), (object) this.mTarget, this.mMethodName);
    }
    return this.mCachedCallback;
  }

  private void Set(EventDelegate.Callback call)
  {
    if (call == null || !EventDelegate.IsValid(call))
    {
      this.mTarget = (MonoBehaviour) null;
      this.mMethodName = (string) null;
      this.mCachedCallback = (EventDelegate.Callback) null;
      this.mRawDelegate = false;
    }
    else
    {
      this.mTarget = call.Target as MonoBehaviour;
      if (Object.op_Equality((Object) this.mTarget, (Object) null))
      {
        this.mRawDelegate = true;
        this.mCachedCallback = call;
        this.mMethodName = (string) null;
      }
      else
      {
        this.mMethodName = EventDelegate.GetMethodName(call);
        this.mRawDelegate = false;
      }
    }
  }

  public void Set(MonoBehaviour target, string methodName)
  {
    this.mTarget = target;
    this.mMethodName = methodName;
    this.mCachedCallback = (EventDelegate.Callback) null;
    this.mRawDelegate = false;
  }

  public bool Execute()
  {
    EventDelegate.Callback callback = this.Get();
    if (callback == null)
      return false;
    callback();
    return true;
  }

  public void Clear()
  {
    this.mTarget = (MonoBehaviour) null;
    this.mMethodName = (string) null;
    this.mRawDelegate = false;
    this.mCachedCallback = (EventDelegate.Callback) null;
  }

  public override string ToString()
  {
    if (Object.op_Inequality((Object) this.mTarget, (Object) null))
    {
      string str = this.mTarget.GetType().ToString();
      int num = str.LastIndexOf('.');
      if (num > 0)
        str = str.Substring(num + 1);
      return !string.IsNullOrEmpty(this.methodName) ? str + "." + this.methodName : str + ".[delegate]";
    }
    return this.mRawDelegate ? "[delegate]" : (string) null;
  }

  public static void Execute(List<EventDelegate> list)
  {
    if (list == null)
      return;
    int index = 0;
    while (index < list.Count)
    {
      EventDelegate eventDelegate = list[index];
      if (eventDelegate != null)
      {
        eventDelegate.Execute();
        if (index >= list.Count)
          break;
        if (list[index] == eventDelegate)
        {
          if (eventDelegate.oneShot)
          {
            list.RemoveAt(index);
            continue;
          }
        }
        else
          continue;
      }
      ++index;
    }
  }

  public static bool IsValid(List<EventDelegate> list)
  {
    if (list != null)
    {
      int index = 0;
      for (int count = list.Count; index < count; ++index)
      {
        EventDelegate eventDelegate = list[index];
        if (eventDelegate != null && eventDelegate.isValid)
          return true;
      }
    }
    return false;
  }

  public static void Set(List<EventDelegate> list, EventDelegate.Callback callback)
  {
    if (list == null)
      return;
    list.Clear();
    list.Add(new EventDelegate(callback));
  }

  public static void Set(List<EventDelegate> list, EventDelegate del)
  {
    if (list == null)
      return;
    list.Clear();
    list.Add(del);
  }

  public static void Add(List<EventDelegate> list, EventDelegate.Callback callback)
  {
    EventDelegate.Add(list, callback, false);
  }

  public static void Add(List<EventDelegate> list, EventDelegate.Callback callback, bool oneShot)
  {
    if (list != null)
    {
      int index = 0;
      for (int count = list.Count; index < count; ++index)
      {
        EventDelegate eventDelegate = list[index];
        if (eventDelegate != null && eventDelegate.Equals((object) callback))
          return;
      }
      list.Add(new EventDelegate(callback)
      {
        oneShot = oneShot
      });
    }
    else
      Debug.LogWarning((object) "Attempting to add a callback to a list that's null");
  }

  public static void Add(List<EventDelegate> list, EventDelegate ev)
  {
    EventDelegate.Add(list, ev, ev.oneShot);
  }

  public static void Add(List<EventDelegate> list, EventDelegate ev, bool oneShot)
  {
    if (ev.mRawDelegate || Object.op_Equality((Object) ev.target, (Object) null) || string.IsNullOrEmpty(ev.methodName))
      EventDelegate.Add(list, ev.mCachedCallback, oneShot);
    else if (list != null)
    {
      int index = 0;
      for (int count = list.Count; index < count; ++index)
      {
        EventDelegate eventDelegate = list[index];
        if (eventDelegate != null && eventDelegate.Equals((object) ev))
          return;
      }
      list.Add(new EventDelegate(ev.target, ev.methodName)
      {
        oneShot = oneShot
      });
    }
    else
      Debug.LogWarning((object) "Attempting to add a callback to a list that's null");
  }

  public static bool Remove(List<EventDelegate> list, EventDelegate.Callback callback)
  {
    if (list != null)
    {
      int index = 0;
      for (int count = list.Count; index < count; ++index)
      {
        EventDelegate eventDelegate = list[index];
        if (eventDelegate != null && eventDelegate.Equals((object) callback))
        {
          list.RemoveAt(index);
          return true;
        }
      }
    }
    return false;
  }

  public delegate void Callback();
}
