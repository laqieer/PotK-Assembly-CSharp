// Decompiled with JetBrains decompiler
// Type: TweenWidthWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class TweenWidthWrap
{
  private static System.Type classType = typeof (TweenWidth);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[6]
    {
      new LuaMethod("Begin", new LuaCSFunction(TweenWidthWrap.Begin)),
      new LuaMethod("SetStartToCurrentValue", new LuaCSFunction(TweenWidthWrap.SetStartToCurrentValue)),
      new LuaMethod("SetEndToCurrentValue", new LuaCSFunction(TweenWidthWrap.SetEndToCurrentValue)),
      new LuaMethod("New", new LuaCSFunction(TweenWidthWrap._CreateTweenWidth)),
      new LuaMethod("GetClassType", new LuaCSFunction(TweenWidthWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(TweenWidthWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[5]
    {
      new LuaField("from", new LuaCSFunction(TweenWidthWrap.get_from), new LuaCSFunction(TweenWidthWrap.set_from)),
      new LuaField("to", new LuaCSFunction(TweenWidthWrap.get_to), new LuaCSFunction(TweenWidthWrap.set_to)),
      new LuaField("updateTable", new LuaCSFunction(TweenWidthWrap.get_updateTable), new LuaCSFunction(TweenWidthWrap.set_updateTable)),
      new LuaField("cachedWidget", new LuaCSFunction(TweenWidthWrap.get_cachedWidget), (LuaCSFunction) null),
      new LuaField("value", new LuaCSFunction(TweenWidthWrap.get_value), new LuaCSFunction(TweenWidthWrap.set_value))
    };
    LuaScriptMgr.RegisterLib(L, "TweenWidth", typeof (TweenWidth), regs, fields, typeof (UITweener));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateTweenWidth(IntPtr L)
  {
    LuaDLL.luaL_error(L, "TweenWidth class does not have a constructor function");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, TweenWidthWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_from(IntPtr L)
  {
    TweenWidth luaObject = (TweenWidth) LuaScriptMgr.GetLuaObject(L, 1);
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
    TweenWidth luaObject = (TweenWidth) LuaScriptMgr.GetLuaObject(L, 1);
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
    TweenWidth luaObject = (TweenWidth) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int get_cachedWidget(IntPtr L)
  {
    TweenWidth luaObject = (TweenWidth) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name cachedWidget");
      else
        LuaDLL.luaL_error(L, "attempt to index cachedWidget on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.cachedWidget);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_value(IntPtr L)
  {
    TweenWidth luaObject = (TweenWidth) LuaScriptMgr.GetLuaObject(L, 1);
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
    TweenWidth luaObject = (TweenWidth) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name from");
      else
        LuaDLL.luaL_error(L, "attempt to index from on a nil value");
    }
    luaObject.from = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_to(IntPtr L)
  {
    TweenWidth luaObject = (TweenWidth) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name to");
      else
        LuaDLL.luaL_error(L, "attempt to index to on a nil value");
    }
    luaObject.to = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_updateTable(IntPtr L)
  {
    TweenWidth luaObject = (TweenWidth) LuaScriptMgr.GetLuaObject(L, 1);
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
    TweenWidth luaObject = (TweenWidth) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name value");
      else
        LuaDLL.luaL_error(L, "attempt to index value on a nil value");
    }
    luaObject.value = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Begin(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 3);
    TweenWidth tweenWidth = TweenWidth.Begin((UIWidget) LuaScriptMgr.GetUnityObject(L, 1, typeof (UIWidget)), (float) LuaScriptMgr.GetNumber(L, 2), (int) LuaScriptMgr.GetNumber(L, 3));
    LuaScriptMgr.Push(L, (Object) tweenWidth);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetStartToCurrentValue(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((TweenWidth) LuaScriptMgr.GetUnityObjectSelf(L, 1, "TweenWidth")).SetStartToCurrentValue();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetEndToCurrentValue(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((TweenWidth) LuaScriptMgr.GetUnityObjectSelf(L, 1, "TweenWidth")).SetEndToCurrentValue();
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
