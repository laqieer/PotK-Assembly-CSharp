﻿// Decompiled with JetBrains decompiler
// Type: ColliderWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class ColliderWrap
{
  private static System.Type classType = typeof (Collider);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[5]
    {
      new LuaMethod("ClosestPointOnBounds", new LuaCSFunction(ColliderWrap.ClosestPointOnBounds)),
      new LuaMethod("Raycast", new LuaCSFunction(ColliderWrap.Raycast)),
      new LuaMethod("New", new LuaCSFunction(ColliderWrap._CreateCollider)),
      new LuaMethod("GetClassType", new LuaCSFunction(ColliderWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(ColliderWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[7]
    {
      new LuaField("enabled", new LuaCSFunction(ColliderWrap.get_enabled), new LuaCSFunction(ColliderWrap.set_enabled)),
      new LuaField("attachedRigidbody", new LuaCSFunction(ColliderWrap.get_attachedRigidbody), (LuaCSFunction) null),
      new LuaField("isTrigger", new LuaCSFunction(ColliderWrap.get_isTrigger), new LuaCSFunction(ColliderWrap.set_isTrigger)),
      new LuaField("contactOffset", new LuaCSFunction(ColliderWrap.get_contactOffset), new LuaCSFunction(ColliderWrap.set_contactOffset)),
      new LuaField("material", new LuaCSFunction(ColliderWrap.get_material), new LuaCSFunction(ColliderWrap.set_material)),
      new LuaField("sharedMaterial", new LuaCSFunction(ColliderWrap.get_sharedMaterial), new LuaCSFunction(ColliderWrap.set_sharedMaterial)),
      new LuaField("bounds", new LuaCSFunction(ColliderWrap.get_bounds), (LuaCSFunction) null)
    };
    LuaScriptMgr.RegisterLib(L, "UnityEngine.Collider", typeof (Collider), regs, fields, typeof (Component));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateCollider(IntPtr L)
  {
    if (LuaDLL.lua_gettop(L) == 0)
    {
      Collider collider = new Collider();
      LuaScriptMgr.Push(L, (Object) collider);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Collider.New");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, ColliderWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_enabled(IntPtr L)
  {
    Collider luaObject = (Collider) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int get_attachedRigidbody(IntPtr L)
  {
    Collider luaObject = (Collider) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name attachedRigidbody");
      else
        LuaDLL.luaL_error(L, "attempt to index attachedRigidbody on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.attachedRigidbody);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_isTrigger(IntPtr L)
  {
    Collider luaObject = (Collider) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name isTrigger");
      else
        LuaDLL.luaL_error(L, "attempt to index isTrigger on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.isTrigger);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_contactOffset(IntPtr L)
  {
    Collider luaObject = (Collider) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name contactOffset");
      else
        LuaDLL.luaL_error(L, "attempt to index contactOffset on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.contactOffset);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_material(IntPtr L)
  {
    Collider luaObject = (Collider) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name material");
      else
        LuaDLL.luaL_error(L, "attempt to index material on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.material);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_sharedMaterial(IntPtr L)
  {
    Collider luaObject = (Collider) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name sharedMaterial");
      else
        LuaDLL.luaL_error(L, "attempt to index sharedMaterial on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.sharedMaterial);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_bounds(IntPtr L)
  {
    Collider luaObject = (Collider) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name bounds");
      else
        LuaDLL.luaL_error(L, "attempt to index bounds on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.bounds);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_enabled(IntPtr L)
  {
    Collider luaObject = (Collider) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int set_isTrigger(IntPtr L)
  {
    Collider luaObject = (Collider) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name isTrigger");
      else
        LuaDLL.luaL_error(L, "attempt to index isTrigger on a nil value");
    }
    luaObject.isTrigger = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_contactOffset(IntPtr L)
  {
    Collider luaObject = (Collider) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name contactOffset");
      else
        LuaDLL.luaL_error(L, "attempt to index contactOffset on a nil value");
    }
    luaObject.contactOffset = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_material(IntPtr L)
  {
    Collider luaObject = (Collider) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name material");
      else
        LuaDLL.luaL_error(L, "attempt to index material on a nil value");
    }
    luaObject.material = (PhysicMaterial) LuaScriptMgr.GetUnityObject(L, 3, typeof (PhysicMaterial));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_sharedMaterial(IntPtr L)
  {
    Collider luaObject = (Collider) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name sharedMaterial");
      else
        LuaDLL.luaL_error(L, "attempt to index sharedMaterial on a nil value");
    }
    luaObject.sharedMaterial = (PhysicMaterial) LuaScriptMgr.GetUnityObject(L, 3, typeof (PhysicMaterial));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int ClosestPointOnBounds(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    Vector3 v3 = ((Collider) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Collider")).ClosestPointOnBounds(LuaScriptMgr.GetVector3(L, 2));
    LuaScriptMgr.Push(L, v3);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Raycast(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 4);
    Collider unityObjectSelf = (Collider) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Collider");
    Ray ray = LuaScriptMgr.GetRay(L, 2);
    float number = (float) LuaScriptMgr.GetNumber(L, 4);
    RaycastHit hit;
    bool b = unityObjectSelf.Raycast(ray, ref hit, number);
    LuaScriptMgr.Push(L, b);
    LuaScriptMgr.Push(L, hit);
    return 2;
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
