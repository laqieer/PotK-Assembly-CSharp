// Decompiled with JetBrains decompiler
// Type: TestEventListenerWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class TestEventListenerWrap
{
  private static System.Type classType = typeof (TestEventListener);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[3]
    {
      new LuaMethod("New", new LuaCSFunction(TestEventListenerWrap._CreateTestEventListener)),
      new LuaMethod("GetClassType", new LuaCSFunction(TestEventListenerWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(TestEventListenerWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[1]
    {
      new LuaField("OnClick", new LuaCSFunction(TestEventListenerWrap.get_OnClick), new LuaCSFunction(TestEventListenerWrap.set_OnClick))
    };
    LuaScriptMgr.RegisterLib(L, "TestEventListener", typeof (TestEventListener), regs, fields, typeof (MonoBehaviour));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateTestEventListener(IntPtr L)
  {
    LuaDLL.luaL_error(L, "TestEventListener class does not have a constructor function");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, TestEventListenerWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_OnClick(IntPtr L)
  {
    TestEventListener luaObject = (TestEventListener) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name OnClick");
      else
        LuaDLL.luaL_error(L, "attempt to index OnClick on a nil value");
    }
    LuaScriptMgr.Push(L, (Delegate) luaObject.OnClick);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_OnClick(IntPtr L)
  {
    TestEventListener luaObject = (TestEventListener) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name OnClick");
      else
        LuaDLL.luaL_error(L, "attempt to index OnClick on a nil value");
    }
    if (LuaDLL.lua_type(L, 3) != LuaTypes.LUA_TFUNCTION)
    {
      luaObject.OnClick = (Action<GameObject>) LuaScriptMgr.GetNetObject(L, 3, typeof (Action<GameObject>));
    }
    else
    {
      LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 3);
      luaObject.OnClick = (Action<GameObject>) (arg0 =>
      {
        int oldTop = func.BeginPCall();
        LuaScriptMgr.Push(L, (Object) arg0);
        func.PCall(oldTop, 1);
        func.EndPCall(oldTop);
      });
    }
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
