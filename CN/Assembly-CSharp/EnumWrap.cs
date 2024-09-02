// Decompiled with JetBrains decompiler
// Type: EnumWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using System;

#nullable disable
public class EnumWrap
{
  private static System.Type classType = typeof (Enum);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[17]
    {
      new LuaMethod("GetTypeCode", new LuaCSFunction(EnumWrap.GetTypeCode)),
      new LuaMethod("GetValues", new LuaCSFunction(EnumWrap.GetValues)),
      new LuaMethod("GetNames", new LuaCSFunction(EnumWrap.GetNames)),
      new LuaMethod("GetName", new LuaCSFunction(EnumWrap.GetName)),
      new LuaMethod("IsDefined", new LuaCSFunction(EnumWrap.IsDefined)),
      new LuaMethod("GetUnderlyingType", new LuaCSFunction(EnumWrap.GetUnderlyingType)),
      new LuaMethod("Parse", new LuaCSFunction(EnumWrap.Parse)),
      new LuaMethod("CompareTo", new LuaCSFunction(EnumWrap.CompareTo)),
      new LuaMethod("ToString", new LuaCSFunction(EnumWrap.ToString)),
      new LuaMethod("ToObject", new LuaCSFunction(EnumWrap.ToObject)),
      new LuaMethod("Format", new LuaCSFunction(EnumWrap.Format)),
      new LuaMethod("GetHashCode", new LuaCSFunction(EnumWrap.GetHashCode)),
      new LuaMethod("Equals", new LuaCSFunction(EnumWrap.Equals)),
      new LuaMethod("New", new LuaCSFunction(EnumWrap._CreateEnum)),
      new LuaMethod("GetClassType", new LuaCSFunction(EnumWrap.GetClassType)),
      new LuaMethod("__tostring", new LuaCSFunction(EnumWrap.Lua_ToString)),
      new LuaMethod("__eq", new LuaCSFunction(EnumWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[0];
    LuaScriptMgr.RegisterLib(L, "System.Enum", typeof (Enum), regs, fields, (System.Type) null);
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateEnum(IntPtr L)
  {
    LuaDLL.luaL_error(L, "Enum class does not have a constructor function");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, EnumWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Lua_ToString(IntPtr L)
  {
    object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
    if (luaObject != null)
      LuaScriptMgr.Push(L, luaObject.ToString());
    else
      LuaScriptMgr.Push(L, "Table: System.Enum");
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetTypeCode(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    TypeCode typeCode = ((Enum) LuaScriptMgr.GetNetObjectSelf(L, 1, "Enum")).GetTypeCode();
    LuaScriptMgr.Push(L, (Enum) typeCode);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetValues(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    Array values = Enum.GetValues(LuaScriptMgr.GetTypeObject(L, 1));
    LuaScriptMgr.PushObject(L, (object) values);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetNames(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    string[] names = Enum.GetNames(LuaScriptMgr.GetTypeObject(L, 1));
    LuaScriptMgr.PushArray(L, (Array) names);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetName(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    string name = Enum.GetName(LuaScriptMgr.GetTypeObject(L, 1), LuaScriptMgr.GetVarObject(L, 2));
    LuaScriptMgr.Push(L, name);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int IsDefined(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    bool b = Enum.IsDefined(LuaScriptMgr.GetTypeObject(L, 1), LuaScriptMgr.GetVarObject(L, 2));
    LuaScriptMgr.Push(L, b);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetUnderlyingType(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    System.Type underlyingType = Enum.GetUnderlyingType(LuaScriptMgr.GetTypeObject(L, 1));
    LuaScriptMgr.Push(L, underlyingType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Parse(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        object o1 = Enum.Parse(LuaScriptMgr.GetTypeObject(L, 1), LuaScriptMgr.GetLuaString(L, 2));
        LuaScriptMgr.PushVarObject(L, o1);
        return 1;
      case 3:
        object o2 = Enum.Parse(LuaScriptMgr.GetTypeObject(L, 1), LuaScriptMgr.GetLuaString(L, 2), LuaScriptMgr.GetBoolean(L, 3));
        LuaScriptMgr.PushVarObject(L, o2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Enum.Parse");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int CompareTo(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    int d = ((Enum) LuaScriptMgr.GetNetObjectSelf(L, 1, "Enum")).CompareTo(LuaScriptMgr.GetVarObject(L, 2));
    LuaScriptMgr.Push(L, d);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int ToString(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        string str1 = ((Enum) LuaScriptMgr.GetNetObjectSelf(L, 1, "Enum")).ToString();
        LuaScriptMgr.Push(L, str1);
        return 1;
      case 2:
        string str2 = ((Enum) LuaScriptMgr.GetNetObjectSelf(L, 1, "Enum")).ToString(LuaScriptMgr.GetLuaString(L, 2));
        LuaScriptMgr.Push(L, str2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Enum.ToString");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int ToObject(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (System.Type), typeof (long)))
    {
      object o = Enum.ToObject(LuaScriptMgr.GetTypeObject(L, 1), (long) LuaDLL.lua_tonumber(L, 2));
      LuaScriptMgr.PushVarObject(L, o);
      return 1;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (System.Type), typeof (object)))
    {
      object o = Enum.ToObject(LuaScriptMgr.GetTypeObject(L, 1), LuaScriptMgr.GetVarObject(L, 2));
      LuaScriptMgr.PushVarObject(L, o);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Enum.ToObject");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Format(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 3);
    string str = Enum.Format(LuaScriptMgr.GetTypeObject(L, 1), LuaScriptMgr.GetVarObject(L, 2), LuaScriptMgr.GetLuaString(L, 3));
    LuaScriptMgr.Push(L, str);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Lua_Eq(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    bool b = LuaScriptMgr.GetLuaObject(L, 1) as Enum == LuaScriptMgr.GetLuaObject(L, 2) as Enum;
    LuaScriptMgr.Push(L, b);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetHashCode(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    int hashCode = ((Enum) LuaScriptMgr.GetNetObjectSelf(L, 1, "Enum")).GetHashCode();
    LuaScriptMgr.Push(L, hashCode);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Equals(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    Enum varObject1 = LuaScriptMgr.GetVarObject(L, 1) as Enum;
    object varObject2 = LuaScriptMgr.GetVarObject(L, 2);
    bool b = varObject1 == null ? varObject2 == null : varObject1.Equals(varObject2);
    LuaScriptMgr.Push(L, b);
    return 1;
  }
}
