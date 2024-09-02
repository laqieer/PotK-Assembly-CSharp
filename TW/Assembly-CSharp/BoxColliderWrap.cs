// Decompiled with JetBrains decompiler
// Type: BoxColliderWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class BoxColliderWrap
{
  private static System.Type classType = typeof (BoxCollider);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[3]
    {
      new LuaMethod("New", new LuaCSFunction(BoxColliderWrap._CreateBoxCollider)),
      new LuaMethod("GetClassType", new LuaCSFunction(BoxColliderWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(BoxColliderWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[2]
    {
      new LuaField("center", new LuaCSFunction(BoxColliderWrap.get_center), new LuaCSFunction(BoxColliderWrap.set_center)),
      new LuaField("size", new LuaCSFunction(BoxColliderWrap.get_size), new LuaCSFunction(BoxColliderWrap.set_size))
    };
    LuaScriptMgr.RegisterLib(L, "UnityEngine.BoxCollider", typeof (BoxCollider), regs, fields, typeof (Collider));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateBoxCollider(IntPtr L)
  {
    if (LuaDLL.lua_gettop(L) == 0)
    {
      BoxCollider boxCollider = new BoxCollider();
      LuaScriptMgr.Push(L, (Object) boxCollider);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: BoxCollider.New");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, BoxColliderWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_center(IntPtr L)
  {
    BoxCollider luaObject = (BoxCollider) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name center");
      else
        LuaDLL.luaL_error(L, "attempt to index center on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.center);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_size(IntPtr L)
  {
    BoxCollider luaObject = (BoxCollider) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name size");
      else
        LuaDLL.luaL_error(L, "attempt to index size on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.size);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_center(IntPtr L)
  {
    BoxCollider luaObject = (BoxCollider) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name center");
      else
        LuaDLL.luaL_error(L, "attempt to index center on a nil value");
    }
    luaObject.center = LuaScriptMgr.GetVector3(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_size(IntPtr L)
  {
    BoxCollider luaObject = (BoxCollider) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name size");
      else
        LuaDLL.luaL_error(L, "attempt to index size on a nil value");
    }
    luaObject.size = LuaScriptMgr.GetVector3(L, 3);
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
