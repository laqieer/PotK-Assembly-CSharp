// Decompiled with JetBrains decompiler
// Type: BehaviourWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class BehaviourWrap
{
  private static System.Type classType = typeof (Behaviour);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[3]
    {
      new LuaMethod("New", new LuaCSFunction(BehaviourWrap._CreateBehaviour)),
      new LuaMethod("GetClassType", new LuaCSFunction(BehaviourWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(BehaviourWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[2]
    {
      new LuaField("enabled", new LuaCSFunction(BehaviourWrap.get_enabled), new LuaCSFunction(BehaviourWrap.set_enabled)),
      new LuaField("isActiveAndEnabled", new LuaCSFunction(BehaviourWrap.get_isActiveAndEnabled), (LuaCSFunction) null)
    };
    LuaScriptMgr.RegisterLib(L, "UnityEngine.Behaviour", typeof (Behaviour), regs, fields, typeof (Component));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateBehaviour(IntPtr L)
  {
    if (LuaDLL.lua_gettop(L) == 0)
    {
      Behaviour behaviour = new Behaviour();
      LuaScriptMgr.Push(L, (Object) behaviour);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Behaviour.New");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, BehaviourWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_enabled(IntPtr L)
  {
    Behaviour luaObject = (Behaviour) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name enabled");
      else
        LuaDLL.luaL_error(L, "attempt to index enabled on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.enabled);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_isActiveAndEnabled(IntPtr L)
  {
    Behaviour luaObject = (Behaviour) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name isActiveAndEnabled");
      else
        LuaDLL.luaL_error(L, "attempt to index isActiveAndEnabled on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.isActiveAndEnabled);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_enabled(IntPtr L)
  {
    Behaviour luaObject = (Behaviour) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name enabled");
      else
        LuaDLL.luaL_error(L, "attempt to index enabled on a nil value");
    }
    luaObject.enabled = LuaScriptMgr.GetBoolean(L, 3);
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
