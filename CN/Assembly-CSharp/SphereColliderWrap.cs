// Decompiled with JetBrains decompiler
// Type: SphereColliderWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class SphereColliderWrap
{
  private static System.Type classType = typeof (SphereCollider);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[3]
    {
      new LuaMethod("New", new LuaCSFunction(SphereColliderWrap._CreateSphereCollider)),
      new LuaMethod("GetClassType", new LuaCSFunction(SphereColliderWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(SphereColliderWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[2]
    {
      new LuaField("center", new LuaCSFunction(SphereColliderWrap.get_center), new LuaCSFunction(SphereColliderWrap.set_center)),
      new LuaField("radius", new LuaCSFunction(SphereColliderWrap.get_radius), new LuaCSFunction(SphereColliderWrap.set_radius))
    };
    LuaScriptMgr.RegisterLib(L, "UnityEngine.SphereCollider", typeof (SphereCollider), regs, fields, typeof (Collider));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateSphereCollider(IntPtr L)
  {
    if (LuaDLL.lua_gettop(L) == 0)
    {
      SphereCollider sphereCollider = new SphereCollider();
      LuaScriptMgr.Push(L, (Object) sphereCollider);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: SphereCollider.New");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, SphereColliderWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_center(IntPtr L)
  {
    SphereCollider luaObject = (SphereCollider) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int get_radius(IntPtr L)
  {
    SphereCollider luaObject = (SphereCollider) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name radius");
      else
        LuaDLL.luaL_error(L, "attempt to index radius on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.radius);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_center(IntPtr L)
  {
    SphereCollider luaObject = (SphereCollider) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int set_radius(IntPtr L)
  {
    SphereCollider luaObject = (SphereCollider) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name radius");
      else
        LuaDLL.luaL_error(L, "attempt to index radius on a nil value");
    }
    luaObject.radius = (float) LuaScriptMgr.GetNumber(L, 3);
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
