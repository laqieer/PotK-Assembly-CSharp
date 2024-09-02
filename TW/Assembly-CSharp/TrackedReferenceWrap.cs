// Decompiled with JetBrains decompiler
// Type: TrackedReferenceWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class TrackedReferenceWrap
{
  private static System.Type classType = typeof (TrackedReference);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[5]
    {
      new LuaMethod("Equals", new LuaCSFunction(TrackedReferenceWrap.Equals)),
      new LuaMethod("GetHashCode", new LuaCSFunction(TrackedReferenceWrap.GetHashCode)),
      new LuaMethod("New", new LuaCSFunction(TrackedReferenceWrap._CreateTrackedReference)),
      new LuaMethod("GetClassType", new LuaCSFunction(TrackedReferenceWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(TrackedReferenceWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[0];
    LuaScriptMgr.RegisterLib(L, "UnityEngine.TrackedReference", typeof (TrackedReference), regs, fields, typeof (object));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateTrackedReference(IntPtr L)
  {
    LuaDLL.luaL_error(L, "TrackedReference class does not have a constructor function");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, TrackedReferenceWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Equals(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    TrackedReference varObject1 = LuaScriptMgr.GetVarObject(L, 1) as TrackedReference;
    object varObject2 = LuaScriptMgr.GetVarObject(L, 2);
    bool b = !TrackedReference.op_Inequality(varObject1, (TrackedReference) null) ? varObject2 == null : varObject1.Equals(varObject2);
    LuaScriptMgr.Push(L, b);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetHashCode(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    int hashCode = ((TrackedReference) LuaScriptMgr.GetTrackedObjectSelf(L, 1, "TrackedReference")).GetHashCode();
    LuaScriptMgr.Push(L, hashCode);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Lua_Eq(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    bool b = TrackedReference.op_Equality(LuaScriptMgr.GetLuaObject(L, 1) as TrackedReference, LuaScriptMgr.GetLuaObject(L, 2) as TrackedReference);
    LuaScriptMgr.Push(L, b);
    return 1;
  }
}
