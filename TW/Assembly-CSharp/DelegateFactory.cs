// Decompiled with JetBrains decompiler
// Type: DelegateFactory
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public static class DelegateFactory
{
  private static Dictionary<System.Type, DelegateFactory.DelegateValue> dict = new Dictionary<System.Type, DelegateFactory.DelegateValue>();

  [NoToLua]
  public static void Register(IntPtr L)
  {
    DelegateFactory.dict.Add(typeof (Action<GameObject>), new DelegateFactory.DelegateValue(DelegateFactory.Action_GameObject));
  }

  [NoToLua]
  public static Delegate CreateDelegate(System.Type t, LuaFunction func)
  {
    DelegateFactory.DelegateValue delegateValue = (DelegateFactory.DelegateValue) null;
    if (DelegateFactory.dict.TryGetValue(t, out delegateValue))
      return delegateValue(func);
    Debugger.LogError("Delegate {0} not register", (object) t.FullName);
    return (Delegate) null;
  }

  public static Delegate Action_GameObject(LuaFunction func)
  {
    return (Delegate) (param0 =>
    {
      int oldTop = func.BeginPCall();
      LuaScriptMgr.Push(func.GetLuaState(), (Object) param0);
      func.PCall(oldTop, 1);
      func.EndPCall(oldTop);
    });
  }

  public static void Clear() => DelegateFactory.dict.Clear();

  private delegate Delegate DelegateValue(LuaFunction func);
}
