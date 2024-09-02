// Decompiled with JetBrains decompiler
// Type: TweenScaleWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class TweenScaleWrap
{
  private static System.Type classType = typeof (TweenScale);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[6]
    {
      new LuaMethod("Begin", new LuaCSFunction(TweenScaleWrap.Begin)),
      new LuaMethod("SetStartToCurrentValue", new LuaCSFunction(TweenScaleWrap.SetStartToCurrentValue)),
      new LuaMethod("SetEndToCurrentValue", new LuaCSFunction(TweenScaleWrap.SetEndToCurrentValue)),
      new LuaMethod("New", new LuaCSFunction(TweenScaleWrap._CreateTweenScale)),
      new LuaMethod("GetClassType", new LuaCSFunction(TweenScaleWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(TweenScaleWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[5]
    {
      new LuaField("from", new LuaCSFunction(TweenScaleWrap.get_from), new LuaCSFunction(TweenScaleWrap.set_from)),
      new LuaField("to", new LuaCSFunction(TweenScaleWrap.get_to), new LuaCSFunction(TweenScaleWrap.set_to)),
      new LuaField("updateTable", new LuaCSFunction(TweenScaleWrap.get_updateTable), new LuaCSFunction(TweenScaleWrap.set_updateTable)),
      new LuaField("cachedTransform", new LuaCSFunction(TweenScaleWrap.get_cachedTransform), (LuaCSFunction) null),
      new LuaField("value", new LuaCSFunction(TweenScaleWrap.get_value), new LuaCSFunction(TweenScaleWrap.set_value))
    };
    LuaScriptMgr.RegisterLib(L, "TweenScale", typeof (TweenScale), regs, fields, typeof (UITweener));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateTweenScale(IntPtr L)
  {
    LuaDLL.luaL_error(L, "TweenScale class does not have a constructor function");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, TweenScaleWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_from(IntPtr L)
  {
    TweenScale luaObject = (TweenScale) LuaScriptMgr.GetLuaObject(L, 1);
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
    TweenScale luaObject = (TweenScale) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int get_updateTable(IntPtr L)
  {
    TweenScale luaObject = (TweenScale) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name updateTable");
      else
        LuaDLL.luaL_error(L, "attempt to index updateTable on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.updateTable);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_cachedTransform(IntPtr L)
  {
    TweenScale luaObject = (TweenScale) LuaScriptMgr.GetLuaObject(L, 1);
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
    TweenScale luaObject = (TweenScale) LuaScriptMgr.GetLuaObject(L, 1);
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
    TweenScale luaObject = (TweenScale) LuaScriptMgr.GetLuaObject(L, 1);
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
    TweenScale luaObject = (TweenScale) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int set_updateTable(IntPtr L)
  {
    TweenScale luaObject = (TweenScale) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name updateTable");
      else
        LuaDLL.luaL_error(L, "attempt to index updateTable on a nil value");
    }
    luaObject.updateTable = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_value(IntPtr L)
  {
    TweenScale luaObject = (TweenScale) LuaScriptMgr.GetLuaObject(L, 1);
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
    TweenScale tweenScale = TweenScale.Begin((GameObject) LuaScriptMgr.GetUnityObject(L, 1, typeof (GameObject)), (float) LuaScriptMgr.GetNumber(L, 2), LuaScriptMgr.GetVector3(L, 3));
    LuaScriptMgr.Push(L, (Object) tweenScale);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetStartToCurrentValue(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((TweenScale) LuaScriptMgr.GetUnityObjectSelf(L, 1, "TweenScale")).SetStartToCurrentValue();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetEndToCurrentValue(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((TweenScale) LuaScriptMgr.GetUnityObjectSelf(L, 1, "TweenScale")).SetEndToCurrentValue();
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
