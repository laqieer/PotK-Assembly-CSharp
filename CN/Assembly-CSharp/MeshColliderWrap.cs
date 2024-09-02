// Decompiled with JetBrains decompiler
// Type: MeshColliderWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class MeshColliderWrap
{
  private static System.Type classType = typeof (MeshCollider);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[3]
    {
      new LuaMethod("New", new LuaCSFunction(MeshColliderWrap._CreateMeshCollider)),
      new LuaMethod("GetClassType", new LuaCSFunction(MeshColliderWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(MeshColliderWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[2]
    {
      new LuaField("sharedMesh", new LuaCSFunction(MeshColliderWrap.get_sharedMesh), new LuaCSFunction(MeshColliderWrap.set_sharedMesh)),
      new LuaField("convex", new LuaCSFunction(MeshColliderWrap.get_convex), new LuaCSFunction(MeshColliderWrap.set_convex))
    };
    LuaScriptMgr.RegisterLib(L, "UnityEngine.MeshCollider", typeof (MeshCollider), regs, fields, typeof (Collider));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateMeshCollider(IntPtr L)
  {
    if (LuaDLL.lua_gettop(L) == 0)
    {
      MeshCollider meshCollider = new MeshCollider();
      LuaScriptMgr.Push(L, (Object) meshCollider);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: MeshCollider.New");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, MeshColliderWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_sharedMesh(IntPtr L)
  {
    MeshCollider luaObject = (MeshCollider) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name sharedMesh");
      else
        LuaDLL.luaL_error(L, "attempt to index sharedMesh on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.sharedMesh);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_convex(IntPtr L)
  {
    MeshCollider luaObject = (MeshCollider) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name convex");
      else
        LuaDLL.luaL_error(L, "attempt to index convex on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.convex);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_sharedMesh(IntPtr L)
  {
    MeshCollider luaObject = (MeshCollider) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name sharedMesh");
      else
        LuaDLL.luaL_error(L, "attempt to index sharedMesh on a nil value");
    }
    luaObject.sharedMesh = (Mesh) LuaScriptMgr.GetUnityObject(L, 3, typeof (Mesh));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_convex(IntPtr L)
  {
    MeshCollider luaObject = (MeshCollider) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name convex");
      else
        LuaDLL.luaL_error(L, "attempt to index convex on a nil value");
    }
    luaObject.convex = LuaScriptMgr.GetBoolean(L, 3);
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
