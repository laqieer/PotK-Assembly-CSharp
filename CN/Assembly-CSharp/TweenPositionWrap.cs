// Decompiled with JetBrains decompiler
// Type: TweenPositionWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class TweenPositionWrap
{
  private static System.Type classType = typeof (TweenPosition);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[6]
    {
      new LuaMethod("Begin", new LuaCSFunction(TweenPositionWrap.Begin)),
      new LuaMethod("SetStartToCurrentValue", new LuaCSFunction(TweenPositionWrap.SetStartToCurrentValue)),
      new LuaMethod("SetEndToCurrentValue", new LuaCSFunction(TweenPositionWrap.SetEndToCurrentValue)),
      new LuaMethod("New", new LuaCSFunction(TweenPositionWrap._CreateTweenPosition)),
      new LuaMethod("GetClassType", new LuaCSFunction(TweenPositionWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(TweenPositionWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[5]
    {
      new LuaField("from", new LuaCSFunction(TweenPositionWrap.get_from), new LuaCSFunction(TweenPositionWrap.set_from)),
      new LuaField("to", new LuaCSFunction(TweenPositionWrap.get_to), new LuaCSFunction(TweenPositionWrap.set_to)),
      new LuaField("worldSpace", new LuaCSFunction(TweenPositionWrap.get_worldSpace), new LuaCSFunction(TweenPositionWrap.set_worldSpace)),
      new LuaField("cachedTransform", new LuaCSFunction(TweenPositionWrap.get_cachedTransform), (LuaCSFunction) null),
      new LuaField("value", new LuaCSFunction(TweenPositionWrap.get_value), new LuaCSFunction(TweenPositionWrap.set_value))
    };
    LuaScriptMgr.RegisterLib(L, "TweenPosition", typeof (TweenPosition), regs, fields, typeof (UITweener));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateTweenPosition(IntPtr L)
  {
    LuaDLL.luaL_error(L, "TweenPosition class does not have a constructor function");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, TweenPositionWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_from(IntPtr L)
  {
    TweenPosition luaObject = (TweenPosition) LuaScriptMgr.GetLuaObject(L, 1);
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
    TweenPosition luaObject = (TweenPosition) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int get_worldSpace(IntPtr L)
  {
    TweenPosition luaObject = (TweenPosition) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name worldSpace");
      else
        LuaDLL.luaL_error(L, "attempt to index worldSpace on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.worldSpace);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_cachedTransform(IntPtr L)
  {
    TweenPosition luaObject = (TweenPosition) LuaScriptMgr.GetLuaObject(L, 1);
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
    TweenPosition luaObject = (TweenPosition) LuaScriptMgr.GetLuaObject(L, 1);
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
    TweenPosition luaObject = (TweenPosition) LuaScriptMgr.GetLuaObject(L, 1);
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
    TweenPosition luaObject = (TweenPosition) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int set_worldSpace(IntPtr L)
  {
    TweenPosition luaObject = (TweenPosition) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name worldSpace");
      else
        LuaDLL.luaL_error(L, "attempt to index worldSpace on a nil value");
    }
    luaObject.worldSpace = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_value(IntPtr L)
  {
    TweenPosition luaObject = (TweenPosition) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name value");
      else
        LuaDLL.luaL_error(L, "attempt to index value on a nil value");
    }
    luaObject.value = LuaScriptMgr.GetVector3(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Begin(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 3);
    TweenPosition tweenPosition = TweenPosition.Begin((GameObject) LuaScriptMgr.GetUnityObject(L, 1, typeof (GameObject)), (float) LuaScriptMgr.GetNumber(L, 2), LuaScriptMgr.GetVector3(L, 3));
    LuaScriptMgr.Push(L, (Object) tweenPosition);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetStartToCurrentValue(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((TweenPosition) LuaScriptMgr.GetUnityObjectSelf(L, 1, "TweenPosition")).SetStartToCurrentValue();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetEndToCurrentValue(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((TweenPosition) LuaScriptMgr.GetUnityObjectSelf(L, 1, "TweenPosition")).SetEndToCurrentValue();
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
