// Decompiled with JetBrains decompiler
// Type: UICenterOnChildWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class UICenterOnChildWrap
{
  private static System.Type classType = typeof (UICenterOnChild);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[5]
    {
      new LuaMethod("Recenter", new LuaCSFunction(UICenterOnChildWrap.Recenter)),
      new LuaMethod("CenterOn", new LuaCSFunction(UICenterOnChildWrap.CenterOn)),
      new LuaMethod("New", new LuaCSFunction(UICenterOnChildWrap._CreateUICenterOnChild)),
      new LuaMethod("GetClassType", new LuaCSFunction(UICenterOnChildWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(UICenterOnChildWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[4]
    {
      new LuaField("springStrength", new LuaCSFunction(UICenterOnChildWrap.get_springStrength), new LuaCSFunction(UICenterOnChildWrap.set_springStrength)),
      new LuaField("nextPageThreshold", new LuaCSFunction(UICenterOnChildWrap.get_nextPageThreshold), new LuaCSFunction(UICenterOnChildWrap.set_nextPageThreshold)),
      new LuaField("onFinished", new LuaCSFunction(UICenterOnChildWrap.get_onFinished), new LuaCSFunction(UICenterOnChildWrap.set_onFinished)),
      new LuaField("centeredObject", new LuaCSFunction(UICenterOnChildWrap.get_centeredObject), (LuaCSFunction) null)
    };
    LuaScriptMgr.RegisterLib(L, "UICenterOnChild", typeof (UICenterOnChild), regs, fields, typeof (MonoBehaviour));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateUICenterOnChild(IntPtr L)
  {
    LuaDLL.luaL_error(L, "UICenterOnChild class does not have a constructor function");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, UICenterOnChildWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_springStrength(IntPtr L)
  {
    UICenterOnChild luaObject = (UICenterOnChild) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name springStrength");
      else
        LuaDLL.luaL_error(L, "attempt to index springStrength on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.springStrength);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_nextPageThreshold(IntPtr L)
  {
    UICenterOnChild luaObject = (UICenterOnChild) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name nextPageThreshold");
      else
        LuaDLL.luaL_error(L, "attempt to index nextPageThreshold on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.nextPageThreshold);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_onFinished(IntPtr L)
  {
    UICenterOnChild luaObject = (UICenterOnChild) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name onFinished");
      else
        LuaDLL.luaL_error(L, "attempt to index onFinished on a nil value");
    }
    LuaScriptMgr.Push(L, (Delegate) luaObject.onFinished);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_centeredObject(IntPtr L)
  {
    UICenterOnChild luaObject = (UICenterOnChild) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name centeredObject");
      else
        LuaDLL.luaL_error(L, "attempt to index centeredObject on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.centeredObject);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_springStrength(IntPtr L)
  {
    UICenterOnChild luaObject = (UICenterOnChild) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name springStrength");
      else
        LuaDLL.luaL_error(L, "attempt to index springStrength on a nil value");
    }
    luaObject.springStrength = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_nextPageThreshold(IntPtr L)
  {
    UICenterOnChild luaObject = (UICenterOnChild) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name nextPageThreshold");
      else
        LuaDLL.luaL_error(L, "attempt to index nextPageThreshold on a nil value");
    }
    luaObject.nextPageThreshold = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_onFinished(IntPtr L)
  {
    UICenterOnChild luaObject = (UICenterOnChild) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name onFinished");
      else
        LuaDLL.luaL_error(L, "attempt to index onFinished on a nil value");
    }
    if (LuaDLL.lua_type(L, 3) != LuaTypes.LUA_TFUNCTION)
    {
      luaObject.onFinished = (SpringPanel.OnFinished) LuaScriptMgr.GetNetObject(L, 3, typeof (SpringPanel.OnFinished));
    }
    else
    {
      LuaFunction func = LuaScriptMgr.ToLuaFunction(L, 3);
      luaObject.onFinished = (SpringPanel.OnFinished) (() => func.Call());
    }
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Recenter(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((UICenterOnChild) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UICenterOnChild")).Recenter();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int CenterOn(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    ((UICenterOnChild) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UICenterOnChild")).CenterOn((Transform) LuaScriptMgr.GetUnityObject(L, 2, typeof (Transform)));
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
