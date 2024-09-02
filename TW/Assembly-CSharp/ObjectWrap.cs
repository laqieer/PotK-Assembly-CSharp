// Decompiled with JetBrains decompiler
// Type: ObjectWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class ObjectWrap
{
  private static System.Type classType = typeof (Object);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[15]
    {
      new LuaMethod("FindObjectsOfType", new LuaCSFunction(ObjectWrap.FindObjectsOfType)),
      new LuaMethod("DontDestroyOnLoad", new LuaCSFunction(ObjectWrap.DontDestroyOnLoad)),
      new LuaMethod("ToString", new LuaCSFunction(ObjectWrap.ToString)),
      new LuaMethod("Equals", new LuaCSFunction(ObjectWrap.Equals)),
      new LuaMethod("GetHashCode", new LuaCSFunction(ObjectWrap.GetHashCode)),
      new LuaMethod("GetInstanceID", new LuaCSFunction(ObjectWrap.GetInstanceID)),
      new LuaMethod("Instantiate", new LuaCSFunction(ObjectWrap.Instantiate)),
      new LuaMethod("FindObjectOfType", new LuaCSFunction(ObjectWrap.FindObjectOfType)),
      new LuaMethod("DestroyObject", new LuaCSFunction(ObjectWrap.DestroyObject)),
      new LuaMethod("DestroyImmediate", new LuaCSFunction(ObjectWrap.DestroyImmediate)),
      new LuaMethod("Destroy", new LuaCSFunction(ObjectWrap.Destroy)),
      new LuaMethod("New", new LuaCSFunction(ObjectWrap._CreateObject)),
      new LuaMethod("GetClassType", new LuaCSFunction(ObjectWrap.GetClassType)),
      new LuaMethod("__tostring", new LuaCSFunction(ObjectWrap.Lua_ToString)),
      new LuaMethod("__eq", new LuaCSFunction(ObjectWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[2]
    {
      new LuaField("name", new LuaCSFunction(ObjectWrap.get_name), new LuaCSFunction(ObjectWrap.set_name)),
      new LuaField("hideFlags", new LuaCSFunction(ObjectWrap.get_hideFlags), new LuaCSFunction(ObjectWrap.set_hideFlags))
    };
    LuaScriptMgr.RegisterLib(L, "UnityEngine.Object", typeof (Object), regs, fields, typeof (object));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateObject(IntPtr L)
  {
    if (LuaDLL.lua_gettop(L) == 0)
    {
      Object @object = new Object();
      LuaScriptMgr.Push(L, @object);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Object.New");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, ObjectWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_name(IntPtr L)
  {
    Object luaObject = (Object) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality(luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name name");
      else
        LuaDLL.luaL_error(L, "attempt to index name on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.name);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_hideFlags(IntPtr L)
  {
    Object luaObject = (Object) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality(luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name hideFlags");
      else
        LuaDLL.luaL_error(L, "attempt to index hideFlags on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) (object) luaObject.hideFlags);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_name(IntPtr L)
  {
    Object luaObject = (Object) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality(luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name name");
      else
        LuaDLL.luaL_error(L, "attempt to index name on a nil value");
    }
    luaObject.name = LuaScriptMgr.GetString(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_hideFlags(IntPtr L)
  {
    Object luaObject = (Object) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality(luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name hideFlags");
      else
        LuaDLL.luaL_error(L, "attempt to index hideFlags on a nil value");
    }
    luaObject.hideFlags = (HideFlags) (int) LuaScriptMgr.GetNetObject(L, 3, typeof (HideFlags));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Lua_ToString(IntPtr L)
  {
    object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
    if (luaObject != null)
      LuaScriptMgr.Push(L, luaObject.ToString());
    else
      LuaScriptMgr.Push(L, "Table: UnityEngine.Object");
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int FindObjectsOfType(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    Object[] objectsOfType = Object.FindObjectsOfType(LuaScriptMgr.GetTypeObject(L, 1));
    LuaScriptMgr.PushArray(L, (Array) objectsOfType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int DontDestroyOnLoad(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    Object.DontDestroyOnLoad(LuaScriptMgr.GetUnityObject(L, 1, typeof (Object)));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int ToString(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    string str = ((Object) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Object")).ToString();
    LuaScriptMgr.Push(L, str);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Equals(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    Object varObject1 = LuaScriptMgr.GetVarObject(L, 1) as Object;
    object varObject2 = LuaScriptMgr.GetVarObject(L, 2);
    bool b = !Object.op_Inequality(varObject1, (Object) null) ? varObject2 == null : varObject1.Equals(varObject2);
    LuaScriptMgr.Push(L, b);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetHashCode(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    int hashCode = ((Object) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Object")).GetHashCode();
    LuaScriptMgr.Push(L, hashCode);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetInstanceID(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    int instanceId = ((Object) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Object")).GetInstanceID();
    LuaScriptMgr.Push(L, instanceId);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Instantiate(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        Object object1 = Object.Instantiate(LuaScriptMgr.GetUnityObject(L, 1, typeof (Object)));
        LuaScriptMgr.Push(L, object1);
        return 1;
      case 3:
        Object object2 = Object.Instantiate(LuaScriptMgr.GetUnityObject(L, 1, typeof (Object)), LuaScriptMgr.GetVector3(L, 2), LuaScriptMgr.GetQuaternion(L, 3));
        LuaScriptMgr.Push(L, object2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Object.Instantiate");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int FindObjectOfType(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    Object objectOfType = Object.FindObjectOfType(LuaScriptMgr.GetTypeObject(L, 1));
    LuaScriptMgr.Push(L, objectOfType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Lua_Eq(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    bool b = Object.op_Equality(LuaScriptMgr.GetLuaObject(L, 1) as Object, LuaScriptMgr.GetLuaObject(L, 2) as Object);
    LuaScriptMgr.Push(L, b);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int DestroyObject(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        Object luaObject1 = (Object) LuaScriptMgr.GetLuaObject(L, 1);
        LuaScriptMgr.__gc(L);
        Object.DestroyObject(luaObject1);
        return 0;
      case 2:
        Object luaObject2 = (Object) LuaScriptMgr.GetLuaObject(L, 1);
        float number = (float) LuaScriptMgr.GetNumber(L, 2);
        LuaScriptMgr.__gc(L);
        Object.DestroyObject(luaObject2, number);
        return 0;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Object.DestroyObject");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int DestroyImmediate(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        Object luaObject1 = (Object) LuaScriptMgr.GetLuaObject(L, 1);
        LuaScriptMgr.__gc(L);
        Object.DestroyImmediate(luaObject1);
        return 0;
      case 2:
        Object luaObject2 = (Object) LuaScriptMgr.GetLuaObject(L, 1);
        bool boolean = LuaScriptMgr.GetBoolean(L, 2);
        LuaScriptMgr.__gc(L);
        Object.DestroyImmediate(luaObject2, boolean);
        return 0;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Object.DestroyImmediate");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Destroy(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        Object luaObject1 = (Object) LuaScriptMgr.GetLuaObject(L, 1);
        LuaScriptMgr.__gc(L);
        Object.Destroy(luaObject1);
        return 0;
      case 2:
        Object luaObject2 = (Object) LuaScriptMgr.GetLuaObject(L, 1);
        float number = (float) LuaScriptMgr.GetNumber(L, 2);
        LuaScriptMgr.__gc(L);
        Object.Destroy(luaObject2, number);
        return 0;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Object.Destroy");
        return 0;
    }
  }
}
