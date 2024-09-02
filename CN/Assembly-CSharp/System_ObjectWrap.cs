// Decompiled with JetBrains decompiler
// Type: System_ObjectWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using System;

#nullable disable
public class System_ObjectWrap
{
  private static System.Type classType = typeof (object);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[9]
    {
      new LuaMethod("Equals", new LuaCSFunction(System_ObjectWrap.Equals)),
      new LuaMethod("GetHashCode", new LuaCSFunction(System_ObjectWrap.GetHashCode)),
      new LuaMethod("GetType", new LuaCSFunction(System_ObjectWrap.GetType)),
      new LuaMethod("ToString", new LuaCSFunction(System_ObjectWrap.ToString)),
      new LuaMethod("ReferenceEquals", new LuaCSFunction(System_ObjectWrap.ReferenceEquals)),
      new LuaMethod("Destroy", new LuaCSFunction(System_ObjectWrap.Destroy)),
      new LuaMethod("New", new LuaCSFunction(System_ObjectWrap._CreateSystem_Object)),
      new LuaMethod("GetClassType", new LuaCSFunction(System_ObjectWrap.GetClassType)),
      new LuaMethod("__tostring", new LuaCSFunction(System_ObjectWrap.Lua_ToString))
    };
    LuaField[] fields = new LuaField[0];
    LuaScriptMgr.RegisterLib(L, "System.Object", typeof (object), regs, fields, (System.Type) null);
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateSystem_Object(IntPtr L)
  {
    if (LuaDLL.lua_gettop(L) == 0)
    {
      object o = new object();
      LuaScriptMgr.PushVarObject(L, o);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: object.New");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, System_ObjectWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Lua_ToString(IntPtr L)
  {
    object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
    if (luaObject != null)
      LuaScriptMgr.Push(L, luaObject.ToString());
    else
      LuaScriptMgr.Push(L, "Table: System.Object");
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Equals(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    object varObject1 = LuaScriptMgr.GetVarObject(L, 1);
    object varObject2 = LuaScriptMgr.GetVarObject(L, 2);
    bool b = varObject1 == null ? varObject2 == null : varObject1.Equals(varObject2);
    LuaScriptMgr.Push(L, b);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetHashCode(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    int hashCode = LuaScriptMgr.GetNetObjectSelf(L, 1, "object").GetHashCode();
    LuaScriptMgr.Push(L, hashCode);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetType(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    System.Type type = LuaScriptMgr.GetNetObjectSelf(L, 1, "object").GetType();
    LuaScriptMgr.Push(L, type);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int ToString(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    string str = LuaScriptMgr.GetNetObjectSelf(L, 1, "object").ToString();
    LuaScriptMgr.Push(L, str);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int ReferenceEquals(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    bool b = object.ReferenceEquals(LuaScriptMgr.GetVarObject(L, 1), LuaScriptMgr.GetVarObject(L, 2));
    LuaScriptMgr.Push(L, b);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Destroy(IntPtr L)
  {
    LuaScriptMgr.__gc(L);
    return 0;
  }
}
