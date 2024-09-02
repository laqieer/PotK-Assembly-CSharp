// Decompiled with JetBrains decompiler
// Type: DelegateWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using System;
using System.Reflection;
using System.Runtime.Serialization;

#nullable disable
public class DelegateWrap
{
  private static System.Type classType = typeof (Delegate);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[15]
    {
      new LuaMethod("CreateDelegate", new LuaCSFunction(DelegateWrap.CreateDelegate)),
      new LuaMethod("DynamicInvoke", new LuaCSFunction(DelegateWrap.DynamicInvoke)),
      new LuaMethod("Clone", new LuaCSFunction(DelegateWrap.Clone)),
      new LuaMethod("GetObjectData", new LuaCSFunction(DelegateWrap.GetObjectData)),
      new LuaMethod("GetInvocationList", new LuaCSFunction(DelegateWrap.GetInvocationList)),
      new LuaMethod("Combine", new LuaCSFunction(DelegateWrap.Combine)),
      new LuaMethod("Remove", new LuaCSFunction(DelegateWrap.Remove)),
      new LuaMethod("RemoveAll", new LuaCSFunction(DelegateWrap.RemoveAll)),
      new LuaMethod("GetHashCode", new LuaCSFunction(DelegateWrap.GetHashCode)),
      new LuaMethod("Equals", new LuaCSFunction(DelegateWrap.Equals)),
      new LuaMethod("New", new LuaCSFunction(DelegateWrap._CreateDelegate)),
      new LuaMethod("GetClassType", new LuaCSFunction(DelegateWrap.GetClassType)),
      new LuaMethod("__add", new LuaCSFunction(DelegateWrap.Lua_Add)),
      new LuaMethod("__sub", new LuaCSFunction(DelegateWrap.Lua_Sub)),
      new LuaMethod("__eq", new LuaCSFunction(DelegateWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[2]
    {
      new LuaField("Method", new LuaCSFunction(DelegateWrap.get_Method), (LuaCSFunction) null),
      new LuaField("Target", new LuaCSFunction(DelegateWrap.get_Target), (LuaCSFunction) null)
    };
    LuaScriptMgr.RegisterLib(L, "System.Delegate", typeof (Delegate), regs, fields, typeof (object));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateDelegate(IntPtr L)
  {
    LuaDLL.luaL_error(L, "Delegate class does not have a constructor function");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, DelegateWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_Method(IntPtr L)
  {
    Delegate luaObject = (Delegate) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name Method");
      else
        LuaDLL.luaL_error(L, "attempt to index Method on a nil value");
    }
    LuaScriptMgr.PushObject(L, (object) luaObject.Method);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_Target(IntPtr L)
  {
    Delegate luaObject = (Delegate) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name Target");
      else
        LuaDLL.luaL_error(L, "attempt to index Target on a nil value");
    }
    LuaScriptMgr.PushVarObject(L, luaObject.Target);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int CreateDelegate(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 2)
    {
      Delegate o = Delegate.CreateDelegate(LuaScriptMgr.GetTypeObject(L, 1), (MethodInfo) LuaScriptMgr.GetNetObject(L, 2, typeof (MethodInfo)));
      LuaScriptMgr.Push(L, o);
      return 1;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (System.Type), typeof (MethodInfo), typeof (bool)))
    {
      Delegate o = Delegate.CreateDelegate(LuaScriptMgr.GetTypeObject(L, 1), (MethodInfo) LuaScriptMgr.GetLuaObject(L, 2), LuaDLL.lua_toboolean(L, 3));
      LuaScriptMgr.Push(L, o);
      return 1;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (System.Type), typeof (System.Type), typeof (string)))
    {
      Delegate o = Delegate.CreateDelegate(LuaScriptMgr.GetTypeObject(L, 1), LuaScriptMgr.GetTypeObject(L, 2), LuaScriptMgr.GetString(L, 3));
      LuaScriptMgr.Push(L, o);
      return 1;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (System.Type), typeof (object), typeof (string)))
    {
      Delegate o = Delegate.CreateDelegate(LuaScriptMgr.GetTypeObject(L, 1), LuaScriptMgr.GetVarObject(L, 2), LuaScriptMgr.GetString(L, 3));
      LuaScriptMgr.Push(L, o);
      return 1;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (System.Type), typeof (object), typeof (MethodInfo)))
    {
      Delegate o = Delegate.CreateDelegate(LuaScriptMgr.GetTypeObject(L, 1), LuaScriptMgr.GetVarObject(L, 2), (MethodInfo) LuaScriptMgr.GetLuaObject(L, 3));
      LuaScriptMgr.Push(L, o);
      return 1;
    }
    if (num == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof (System.Type), typeof (System.Type), typeof (string), typeof (bool)))
    {
      Delegate o = Delegate.CreateDelegate(LuaScriptMgr.GetTypeObject(L, 1), LuaScriptMgr.GetTypeObject(L, 2), LuaScriptMgr.GetString(L, 3), LuaDLL.lua_toboolean(L, 4));
      LuaScriptMgr.Push(L, o);
      return 1;
    }
    if (num == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof (System.Type), typeof (object), typeof (string), typeof (bool)))
    {
      Delegate o = Delegate.CreateDelegate(LuaScriptMgr.GetTypeObject(L, 1), LuaScriptMgr.GetVarObject(L, 2), LuaScriptMgr.GetString(L, 3), LuaDLL.lua_toboolean(L, 4));
      LuaScriptMgr.Push(L, o);
      return 1;
    }
    if (num == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof (System.Type), typeof (object), typeof (MethodInfo), typeof (bool)))
    {
      Delegate o = Delegate.CreateDelegate(LuaScriptMgr.GetTypeObject(L, 1), LuaScriptMgr.GetVarObject(L, 2), (MethodInfo) LuaScriptMgr.GetLuaObject(L, 3), LuaDLL.lua_toboolean(L, 4));
      LuaScriptMgr.Push(L, o);
      return 1;
    }
    if (num == 5 && LuaScriptMgr.CheckTypes(L, 1, typeof (System.Type), typeof (System.Type), typeof (string), typeof (bool), typeof (bool)))
    {
      Delegate o = Delegate.CreateDelegate(LuaScriptMgr.GetTypeObject(L, 1), LuaScriptMgr.GetTypeObject(L, 2), LuaScriptMgr.GetString(L, 3), LuaDLL.lua_toboolean(L, 4), LuaDLL.lua_toboolean(L, 5));
      LuaScriptMgr.Push(L, o);
      return 1;
    }
    if (num == 5 && LuaScriptMgr.CheckTypes(L, 1, typeof (System.Type), typeof (object), typeof (string), typeof (bool), typeof (bool)))
    {
      Delegate o = Delegate.CreateDelegate(LuaScriptMgr.GetTypeObject(L, 1), LuaScriptMgr.GetVarObject(L, 2), LuaScriptMgr.GetString(L, 3), LuaDLL.lua_toboolean(L, 4), LuaDLL.lua_toboolean(L, 5));
      LuaScriptMgr.Push(L, o);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Delegate.CreateDelegate");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int DynamicInvoke(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    object o = ((Delegate) LuaScriptMgr.GetNetObjectSelf(L, 1, "Delegate")).DynamicInvoke(LuaScriptMgr.GetParamsObject(L, 2, num - 1));
    LuaScriptMgr.PushVarObject(L, o);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Clone(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    object o = ((Delegate) LuaScriptMgr.GetNetObjectSelf(L, 1, "Delegate")).Clone();
    LuaScriptMgr.PushVarObject(L, o);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetObjectData(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 3);
    ((Delegate) LuaScriptMgr.GetNetObjectSelf(L, 1, "Delegate")).GetObjectData((SerializationInfo) LuaScriptMgr.GetNetObject(L, 2, typeof (SerializationInfo)), (StreamingContext) LuaScriptMgr.GetNetObject(L, 3, typeof (StreamingContext)));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetInvocationList(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    Delegate[] invocationList = ((Delegate) LuaScriptMgr.GetNetObjectSelf(L, 1, "Delegate")).GetInvocationList();
    LuaScriptMgr.PushArray(L, (Array) invocationList);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Combine(IntPtr L)
  {
    int count = LuaDLL.lua_gettop(L);
    if (count == 2)
    {
      Delegate o = Delegate.Combine((Delegate) LuaScriptMgr.GetNetObject(L, 1, typeof (Delegate)), (Delegate) LuaScriptMgr.GetNetObject(L, 2, typeof (Delegate)));
      LuaScriptMgr.Push(L, o);
      return 1;
    }
    if (LuaScriptMgr.CheckParamsType(L, typeof (Delegate), 1, count))
    {
      Delegate o = Delegate.Combine(LuaScriptMgr.GetParamsObject<Delegate>(L, 1, count));
      LuaScriptMgr.Push(L, o);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Delegate.Combine");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Remove(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    Delegate o = Delegate.Remove((Delegate) LuaScriptMgr.GetNetObject(L, 1, typeof (Delegate)), (Delegate) LuaScriptMgr.GetNetObject(L, 2, typeof (Delegate)));
    LuaScriptMgr.Push(L, o);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int RemoveAll(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    Delegate o = Delegate.RemoveAll((Delegate) LuaScriptMgr.GetNetObject(L, 1, typeof (Delegate)), (Delegate) LuaScriptMgr.GetNetObject(L, 2, typeof (Delegate)));
    LuaScriptMgr.Push(L, o);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Lua_Sub(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    Delegate o = Delegate.Remove((Delegate) LuaScriptMgr.GetNetObject(L, 1, typeof (Delegate)), (Delegate) LuaScriptMgr.GetNetObject(L, 2, typeof (Delegate)));
    LuaScriptMgr.Push(L, o);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Lua_Add(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    Delegate luaObject1 = LuaScriptMgr.GetLuaObject(L, 1) as Delegate;
    if (LuaDLL.lua_type(L, 2) != LuaTypes.LUA_TFUNCTION)
    {
      Delegate luaObject2 = LuaScriptMgr.GetLuaObject(L, 2) as Delegate;
      Delegate o = Delegate.Combine(luaObject1, luaObject2);
      LuaScriptMgr.Push(L, o);
      return 1;
    }
    LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 2);
    Delegate b = DelegateFactory.CreateDelegate(luaObject1.GetType(), luaFunction);
    Delegate o1 = Delegate.Combine(luaObject1, b);
    LuaScriptMgr.Push(L, o1);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Lua_Eq(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    bool b = LuaScriptMgr.GetLuaObject(L, 1) as Delegate == LuaScriptMgr.GetLuaObject(L, 2) as Delegate;
    LuaScriptMgr.Push(L, b);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetHashCode(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    int hashCode = ((Delegate) LuaScriptMgr.GetNetObjectSelf(L, 1, "Delegate")).GetHashCode();
    LuaScriptMgr.Push(L, hashCode);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Equals(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    Delegate varObject1 = LuaScriptMgr.GetVarObject(L, 1) as Delegate;
    object varObject2 = LuaScriptMgr.GetVarObject(L, 2);
    bool b = (object) varObject1 == null ? varObject2 == null : varObject1.Equals(varObject2);
    LuaScriptMgr.Push(L, b);
    return 1;
  }
}
