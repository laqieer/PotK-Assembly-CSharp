// Decompiled with JetBrains decompiler
// Type: TweenRotationWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class TweenRotationWrap
{
  private static System.Type classType = typeof (TweenRotation);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[6]
    {
      new LuaMethod("Begin", new LuaCSFunction(TweenRotationWrap.Begin)),
      new LuaMethod("SetStartToCurrentValue", new LuaCSFunction(TweenRotationWrap.SetStartToCurrentValue)),
      new LuaMethod("SetEndToCurrentValue", new LuaCSFunction(TweenRotationWrap.SetEndToCurrentValue)),
      new LuaMethod("New", new LuaCSFunction(TweenRotationWrap._CreateTweenRotation)),
      new LuaMethod("GetClassType", new LuaCSFunction(TweenRotationWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(TweenRotationWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[4]
    {
      new LuaField("from", new LuaCSFunction(TweenRotationWrap.get_from), new LuaCSFunction(TweenRotationWrap.set_from)),
      new LuaField("to", new LuaCSFunction(TweenRotationWrap.get_to), new LuaCSFunction(TweenRotationWrap.set_to)),
      new LuaField("cachedTransform", new LuaCSFunction(TweenRotationWrap.get_cachedTransform), (LuaCSFunction) null),
      new LuaField("value", new LuaCSFunction(TweenRotationWrap.get_value), new LuaCSFunction(TweenRotationWrap.set_value))
    };
    LuaScriptMgr.RegisterLib(L, "TweenRotation", typeof (TweenRotation), regs, fields, typeof (UITweener));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateTweenRotation(IntPtr L)
  {
    LuaDLL.luaL_error(L, "TweenRotation class does not have a constructor function");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, TweenRotationWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_from(IntPtr L)
  {
    TweenRotation luaObject = (TweenRotation) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name from");
      else
        LuaDLL.luaL_error(L, "attempt to index from on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.from);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_to(IntPtr L)
  {
    TweenRotation luaObject = (TweenRotation) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name to");
      else
        LuaDLL.luaL_error(L, "attempt to index to on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.to);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_cachedTransform(IntPtr L)
  {
    TweenRotation luaObject = (TweenRotation) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name cachedTransform");
      else
        LuaDLL.luaL_error(L, "attempt to index cachedTransform on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.cachedTransform);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_value(IntPtr L)
  {
    TweenRotation luaObject = (TweenRotation) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name value");
      else
        LuaDLL.luaL_error(L, "attempt to index value on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.value);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_from(IntPtr L)
  {
    TweenRotation luaObject = (TweenRotation) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name from");
      else
        LuaDLL.luaL_error(L, "attempt to index from on a nil value");
    }
    luaObject.from = LuaScriptMgr.GetVector3(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_to(IntPtr L)
  {
    TweenRotation luaObject = (TweenRotation) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name to");
      else
        LuaDLL.luaL_error(L, "attempt to index to on a nil value");
    }
    luaObject.to = LuaScriptMgr.GetVector3(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_value(IntPtr L)
  {
    TweenRotation luaObject = (TweenRotation) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name value");
      else
        LuaDLL.luaL_error(L, "attempt to index value on a nil value");
    }
    luaObject.value = LuaScriptMgr.GetQuaternion(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Begin(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 3);
    TweenRotation tweenRotation = TweenRotation.Begin((GameObject) LuaScriptMgr.GetUnityObject(L, 1, typeof (GameObject)), (float) LuaScriptMgr.GetNumber(L, 2), LuaScriptMgr.GetQuaternion(L, 3));
    LuaScriptMgr.Push(L, (Object) tweenRotation);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetStartToCurrentValue(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((TweenRotation) LuaScriptMgr.GetUnityObjectSelf(L, 1, "TweenRotation")).SetStartToCurrentValue();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetEndToCurrentValue(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((TweenRotation) LuaScriptMgr.GetUnityObjectSelf(L, 1, "TweenRotation")).SetEndToCurrentValue();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Lua_Eq(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    bool b = Object.op_Equality(LuaScriptMgr.GetLuaObject(L, 1) as Object, LuaScriptMgr.GetLuaObject(L, 2) as Object);
    LuaScriptMgr.Push(L, b);
    return 1;
  }
}
