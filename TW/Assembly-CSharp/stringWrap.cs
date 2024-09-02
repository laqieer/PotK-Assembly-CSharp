// Decompiled with JetBrains decompiler
// Type: stringWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using System;
using System.Collections;
using System.Globalization;
using System.Text;

#nullable disable
public class stringWrap
{
  private static System.Type classType = typeof (string);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[45]
    {
      new LuaMethod("Clone", new LuaCSFunction(stringWrap.Clone)),
      new LuaMethod("GetTypeCode", new LuaCSFunction(stringWrap.GetTypeCode)),
      new LuaMethod("CopyTo", new LuaCSFunction(stringWrap.CopyTo)),
      new LuaMethod("ToCharArray", new LuaCSFunction(stringWrap.ToCharArray)),
      new LuaMethod("Split", new LuaCSFunction(stringWrap.Split)),
      new LuaMethod("Substring", new LuaCSFunction(stringWrap.Substring)),
      new LuaMethod("Trim", new LuaCSFunction(stringWrap.Trim)),
      new LuaMethod("TrimStart", new LuaCSFunction(stringWrap.TrimStart)),
      new LuaMethod("TrimEnd", new LuaCSFunction(stringWrap.TrimEnd)),
      new LuaMethod("Compare", new LuaCSFunction(stringWrap.Compare)),
      new LuaMethod("CompareTo", new LuaCSFunction(stringWrap.CompareTo)),
      new LuaMethod("CompareOrdinal", new LuaCSFunction(stringWrap.CompareOrdinal)),
      new LuaMethod("EndsWith", new LuaCSFunction(stringWrap.EndsWith)),
      new LuaMethod("IndexOfAny", new LuaCSFunction(stringWrap.IndexOfAny)),
      new LuaMethod("IndexOf", new LuaCSFunction(stringWrap.IndexOf)),
      new LuaMethod("LastIndexOf", new LuaCSFunction(stringWrap.LastIndexOf)),
      new LuaMethod("LastIndexOfAny", new LuaCSFunction(stringWrap.LastIndexOfAny)),
      new LuaMethod("Contains", new LuaCSFunction(stringWrap.Contains)),
      new LuaMethod("IsNullOrEmpty", new LuaCSFunction(stringWrap.IsNullOrEmpty)),
      new LuaMethod("Normalize", new LuaCSFunction(stringWrap.Normalize)),
      new LuaMethod("IsNormalized", new LuaCSFunction(stringWrap.IsNormalized)),
      new LuaMethod("Remove", new LuaCSFunction(stringWrap.Remove)),
      new LuaMethod("PadLeft", new LuaCSFunction(stringWrap.PadLeft)),
      new LuaMethod("PadRight", new LuaCSFunction(stringWrap.PadRight)),
      new LuaMethod("StartsWith", new LuaCSFunction(stringWrap.StartsWith)),
      new LuaMethod("Replace", new LuaCSFunction(stringWrap.Replace)),
      new LuaMethod("ToLower", new LuaCSFunction(stringWrap.ToLower)),
      new LuaMethod("ToLowerInvariant", new LuaCSFunction(stringWrap.ToLowerInvariant)),
      new LuaMethod("ToUpper", new LuaCSFunction(stringWrap.ToUpper)),
      new LuaMethod("ToUpperInvariant", new LuaCSFunction(stringWrap.ToUpperInvariant)),
      new LuaMethod("ToString", new LuaCSFunction(stringWrap.ToString)),
      new LuaMethod("Format", new LuaCSFunction(stringWrap.Format)),
      new LuaMethod("Copy", new LuaCSFunction(stringWrap.Copy)),
      new LuaMethod("Concat", new LuaCSFunction(stringWrap.Concat)),
      new LuaMethod("Insert", new LuaCSFunction(stringWrap.Insert)),
      new LuaMethod("Intern", new LuaCSFunction(stringWrap.Intern)),
      new LuaMethod("IsInterned", new LuaCSFunction(stringWrap.IsInterned)),
      new LuaMethod("Join", new LuaCSFunction(stringWrap.Join)),
      new LuaMethod("GetEnumerator", new LuaCSFunction(stringWrap.GetEnumerator)),
      new LuaMethod("GetHashCode", new LuaCSFunction(stringWrap.GetHashCode)),
      new LuaMethod("Equals", new LuaCSFunction(stringWrap.Equals)),
      new LuaMethod("New", new LuaCSFunction(stringWrap._Createstring)),
      new LuaMethod("GetClassType", new LuaCSFunction(stringWrap.GetClassType)),
      new LuaMethod("__tostring", new LuaCSFunction(stringWrap.Lua_ToString)),
      new LuaMethod("__eq", new LuaCSFunction(stringWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[2]
    {
      new LuaField("Empty", new LuaCSFunction(stringWrap.get_Empty), (LuaCSFunction) null),
      new LuaField("Length", new LuaCSFunction(stringWrap.get_Length), (LuaCSFunction) null)
    };
    LuaScriptMgr.RegisterLib(L, "System.String", typeof (string), regs, fields, typeof (object));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _Createstring(IntPtr L)
  {
    if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TSTRING)
    {
      string o = LuaDLL.lua_tostring(L, 1);
      LuaScriptMgr.PushObject(L, (object) o);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: String.New");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, stringWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_Empty(IntPtr L)
  {
    LuaScriptMgr.Push(L, string.Empty);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_Length(IntPtr L)
  {
    string luaObject = (string) LuaScriptMgr.GetLuaObject(L, 1);
    if (luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name Length");
      else
        LuaDLL.luaL_error(L, "attempt to index Length on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.Length);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Lua_ToString(IntPtr L)
  {
    object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
    if (luaObject != null)
      LuaScriptMgr.Push(L, luaObject.ToString());
    else
      LuaScriptMgr.Push(L, "Table: System.String");
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Clone(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    object o = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).Clone();
    LuaScriptMgr.PushVarObject(L, o);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetTypeCode(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    TypeCode typeCode = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).GetTypeCode();
    LuaScriptMgr.Push(L, (Enum) typeCode);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int CopyTo(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 5);
    ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).CopyTo((int) LuaScriptMgr.GetNumber(L, 2), LuaScriptMgr.GetArrayNumber<char>(L, 3), (int) LuaScriptMgr.GetNumber(L, 4), (int) LuaScriptMgr.GetNumber(L, 5));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int ToCharArray(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        char[] charArray1 = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).ToCharArray();
        LuaScriptMgr.PushArray(L, (Array) charArray1);
        return 1;
      case 3:
        char[] charArray2 = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).ToCharArray((int) LuaScriptMgr.GetNumber(L, 2), (int) LuaScriptMgr.GetNumber(L, 3));
        LuaScriptMgr.PushArray(L, (Array) charArray2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: string.ToCharArray");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Split(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (string), typeof (char[]), typeof (StringSplitOptions)))
    {
      string[] o = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).Split(LuaScriptMgr.GetArrayNumber<char>(L, 2), (StringSplitOptions) LuaScriptMgr.GetLuaObject(L, 3));
      LuaScriptMgr.PushArray(L, (Array) o);
      return 1;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (string), typeof (char[]), typeof (int)))
    {
      string[] o = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).Split(LuaScriptMgr.GetArrayNumber<char>(L, 2), (int) LuaDLL.lua_tonumber(L, 3));
      LuaScriptMgr.PushArray(L, (Array) o);
      return 1;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (string), typeof (string[]), typeof (StringSplitOptions)))
    {
      string[] o = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).Split(LuaScriptMgr.GetArrayString(L, 2), (StringSplitOptions) LuaScriptMgr.GetLuaObject(L, 3));
      LuaScriptMgr.PushArray(L, (Array) o);
      return 1;
    }
    if (num == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof (string), typeof (string[]), typeof (int), typeof (StringSplitOptions)))
    {
      string[] o = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).Split(LuaScriptMgr.GetArrayString(L, 2), (int) LuaDLL.lua_tonumber(L, 3), (StringSplitOptions) LuaScriptMgr.GetLuaObject(L, 4));
      LuaScriptMgr.PushArray(L, (Array) o);
      return 1;
    }
    if (num == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof (string), typeof (char[]), typeof (int), typeof (StringSplitOptions)))
    {
      string[] o = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).Split(LuaScriptMgr.GetArrayNumber<char>(L, 2), (int) LuaDLL.lua_tonumber(L, 3), (StringSplitOptions) LuaScriptMgr.GetLuaObject(L, 4));
      LuaScriptMgr.PushArray(L, (Array) o);
      return 1;
    }
    if (LuaScriptMgr.CheckParamsType(L, typeof (char), 2, num - 1))
    {
      string[] o = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).Split(LuaScriptMgr.GetArrayNumber<char>(L, 2));
      LuaScriptMgr.PushArray(L, (Array) o);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: string.Split");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Substring(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        string str1 = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).Substring((int) LuaScriptMgr.GetNumber(L, 2));
        LuaScriptMgr.Push(L, str1);
        return 1;
      case 3:
        string str2 = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).Substring((int) LuaScriptMgr.GetNumber(L, 2), (int) LuaScriptMgr.GetNumber(L, 3));
        LuaScriptMgr.Push(L, str2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: string.Substring");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Trim(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 1)
    {
      string str = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).Trim();
      LuaScriptMgr.Push(L, str);
      return 1;
    }
    if (LuaScriptMgr.CheckParamsType(L, typeof (char), 2, num - 1))
    {
      string str = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).Trim(LuaScriptMgr.GetArrayNumber<char>(L, 2));
      LuaScriptMgr.Push(L, str);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: string.Trim");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int TrimStart(IntPtr L)
  {
    LuaDLL.lua_gettop(L);
    string str = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).TrimStart(LuaScriptMgr.GetArrayNumber<char>(L, 2));
    LuaScriptMgr.Push(L, str);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int TrimEnd(IntPtr L)
  {
    LuaDLL.lua_gettop(L);
    string str = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).TrimEnd(LuaScriptMgr.GetArrayNumber<char>(L, 2));
    LuaScriptMgr.Push(L, str);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Compare(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 2)
    {
      int d = string.Compare(LuaScriptMgr.GetLuaString(L, 1), LuaScriptMgr.GetLuaString(L, 2));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (string), typeof (string), typeof (StringComparison)))
    {
      int d = string.Compare(LuaScriptMgr.GetString(L, 1), LuaScriptMgr.GetString(L, 2), (StringComparison) LuaScriptMgr.GetLuaObject(L, 3));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (string), typeof (string), typeof (bool)))
    {
      int d = string.Compare(LuaScriptMgr.GetString(L, 1), LuaScriptMgr.GetString(L, 2), LuaDLL.lua_toboolean(L, 3));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof (string), typeof (string), typeof (CultureInfo), typeof (CompareOptions)))
    {
      int d = string.Compare(LuaScriptMgr.GetString(L, 1), LuaScriptMgr.GetString(L, 2), (CultureInfo) LuaScriptMgr.GetLuaObject(L, 3), (CompareOptions) LuaScriptMgr.GetLuaObject(L, 4));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof (string), typeof (string), typeof (bool), typeof (CultureInfo)))
    {
      int d = string.Compare(LuaScriptMgr.GetString(L, 1), LuaScriptMgr.GetString(L, 2), LuaDLL.lua_toboolean(L, 3), (CultureInfo) LuaScriptMgr.GetLuaObject(L, 4));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 5)
    {
      int d = string.Compare(LuaScriptMgr.GetLuaString(L, 1), (int) LuaScriptMgr.GetNumber(L, 2), LuaScriptMgr.GetLuaString(L, 3), (int) LuaScriptMgr.GetNumber(L, 4), (int) LuaScriptMgr.GetNumber(L, 5));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 6 && LuaScriptMgr.CheckTypes(L, 1, typeof (string), typeof (int), typeof (string), typeof (int), typeof (int), typeof (StringComparison)))
    {
      int d = string.Compare(LuaScriptMgr.GetString(L, 1), (int) LuaDLL.lua_tonumber(L, 2), LuaScriptMgr.GetString(L, 3), (int) LuaDLL.lua_tonumber(L, 4), (int) LuaDLL.lua_tonumber(L, 5), (StringComparison) LuaScriptMgr.GetLuaObject(L, 6));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 6 && LuaScriptMgr.CheckTypes(L, 1, typeof (string), typeof (int), typeof (string), typeof (int), typeof (int), typeof (bool)))
    {
      int d = string.Compare(LuaScriptMgr.GetString(L, 1), (int) LuaDLL.lua_tonumber(L, 2), LuaScriptMgr.GetString(L, 3), (int) LuaDLL.lua_tonumber(L, 4), (int) LuaDLL.lua_tonumber(L, 5), LuaDLL.lua_toboolean(L, 6));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 7 && LuaScriptMgr.CheckTypes(L, 1, typeof (string), typeof (int), typeof (string), typeof (int), typeof (int), typeof (CultureInfo), typeof (CompareOptions)))
    {
      int d = string.Compare(LuaScriptMgr.GetString(L, 1), (int) LuaDLL.lua_tonumber(L, 2), LuaScriptMgr.GetString(L, 3), (int) LuaDLL.lua_tonumber(L, 4), (int) LuaDLL.lua_tonumber(L, 5), (CultureInfo) LuaScriptMgr.GetLuaObject(L, 6), (CompareOptions) LuaScriptMgr.GetLuaObject(L, 7));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 7 && LuaScriptMgr.CheckTypes(L, 1, typeof (string), typeof (int), typeof (string), typeof (int), typeof (int), typeof (bool), typeof (CultureInfo)))
    {
      int d = string.Compare(LuaScriptMgr.GetString(L, 1), (int) LuaDLL.lua_tonumber(L, 2), LuaScriptMgr.GetString(L, 3), (int) LuaDLL.lua_tonumber(L, 4), (int) LuaDLL.lua_tonumber(L, 5), LuaDLL.lua_toboolean(L, 6), (CultureInfo) LuaScriptMgr.GetLuaObject(L, 7));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: string.Compare");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int CompareTo(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (string), typeof (string)))
    {
      int d = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).CompareTo(LuaScriptMgr.GetString(L, 2));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (string), typeof (object)))
    {
      int d = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).CompareTo(LuaScriptMgr.GetVarObject(L, 2));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: string.CompareTo");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int CompareOrdinal(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        int d1 = string.CompareOrdinal(LuaScriptMgr.GetLuaString(L, 1), LuaScriptMgr.GetLuaString(L, 2));
        LuaScriptMgr.Push(L, d1);
        return 1;
      case 5:
        int d2 = string.CompareOrdinal(LuaScriptMgr.GetLuaString(L, 1), (int) LuaScriptMgr.GetNumber(L, 2), LuaScriptMgr.GetLuaString(L, 3), (int) LuaScriptMgr.GetNumber(L, 4), (int) LuaScriptMgr.GetNumber(L, 5));
        LuaScriptMgr.Push(L, d2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: string.CompareOrdinal");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int EndsWith(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        bool b1 = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).EndsWith(LuaScriptMgr.GetLuaString(L, 2));
        LuaScriptMgr.Push(L, b1);
        return 1;
      case 3:
        bool b2 = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).EndsWith(LuaScriptMgr.GetLuaString(L, 2), (StringComparison) LuaScriptMgr.GetNetObject(L, 3, typeof (StringComparison)));
        LuaScriptMgr.Push(L, b2);
        return 1;
      case 4:
        bool b3 = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).EndsWith(LuaScriptMgr.GetLuaString(L, 2), LuaScriptMgr.GetBoolean(L, 3), (CultureInfo) LuaScriptMgr.GetNetObject(L, 4, typeof (CultureInfo)));
        LuaScriptMgr.Push(L, b3);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: string.EndsWith");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int IndexOfAny(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        int d1 = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).IndexOfAny(LuaScriptMgr.GetArrayNumber<char>(L, 2));
        LuaScriptMgr.Push(L, d1);
        return 1;
      case 3:
        int d2 = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).IndexOfAny(LuaScriptMgr.GetArrayNumber<char>(L, 2), (int) LuaScriptMgr.GetNumber(L, 3));
        LuaScriptMgr.Push(L, d2);
        return 1;
      case 4:
        int d3 = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).IndexOfAny(LuaScriptMgr.GetArrayNumber<char>(L, 2), (int) LuaScriptMgr.GetNumber(L, 3), (int) LuaScriptMgr.GetNumber(L, 4));
        LuaScriptMgr.Push(L, d3);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: string.IndexOfAny");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int IndexOf(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (string), typeof (char)))
    {
      int d = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).IndexOf((char) LuaDLL.lua_tonumber(L, 2));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (string), typeof (string)))
    {
      int d = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).IndexOf(LuaScriptMgr.GetString(L, 2));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (string), typeof (string), typeof (int)))
    {
      int d = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).IndexOf(LuaScriptMgr.GetString(L, 2), (int) LuaDLL.lua_tonumber(L, 3));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (string), typeof (char), typeof (int)))
    {
      int d = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).IndexOf((char) LuaDLL.lua_tonumber(L, 2), (int) LuaDLL.lua_tonumber(L, 3));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (string), typeof (string), typeof (StringComparison)))
    {
      int d = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).IndexOf(LuaScriptMgr.GetString(L, 2), (StringComparison) LuaScriptMgr.GetLuaObject(L, 3));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof (string), typeof (string), typeof (int), typeof (int)))
    {
      int d = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).IndexOf(LuaScriptMgr.GetString(L, 2), (int) LuaDLL.lua_tonumber(L, 3), (int) LuaDLL.lua_tonumber(L, 4));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof (string), typeof (string), typeof (int), typeof (StringComparison)))
    {
      int d = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).IndexOf(LuaScriptMgr.GetString(L, 2), (int) LuaDLL.lua_tonumber(L, 3), (StringComparison) LuaScriptMgr.GetLuaObject(L, 4));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof (string), typeof (char), typeof (int), typeof (int)))
    {
      int d = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).IndexOf((char) LuaDLL.lua_tonumber(L, 2), (int) LuaDLL.lua_tonumber(L, 3), (int) LuaDLL.lua_tonumber(L, 4));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 5)
    {
      int d = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).IndexOf(LuaScriptMgr.GetLuaString(L, 2), (int) LuaScriptMgr.GetNumber(L, 3), (int) LuaScriptMgr.GetNumber(L, 4), (StringComparison) LuaScriptMgr.GetNetObject(L, 5, typeof (StringComparison)));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: string.IndexOf");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int LastIndexOf(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (string), typeof (char)))
    {
      int d = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).LastIndexOf((char) LuaDLL.lua_tonumber(L, 2));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (string), typeof (string)))
    {
      int d = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).LastIndexOf(LuaScriptMgr.GetString(L, 2));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (string), typeof (string), typeof (int)))
    {
      int d = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).LastIndexOf(LuaScriptMgr.GetString(L, 2), (int) LuaDLL.lua_tonumber(L, 3));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (string), typeof (char), typeof (int)))
    {
      int d = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).LastIndexOf((char) LuaDLL.lua_tonumber(L, 2), (int) LuaDLL.lua_tonumber(L, 3));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (string), typeof (string), typeof (StringComparison)))
    {
      int d = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).LastIndexOf(LuaScriptMgr.GetString(L, 2), (StringComparison) LuaScriptMgr.GetLuaObject(L, 3));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof (string), typeof (string), typeof (int), typeof (int)))
    {
      int d = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).LastIndexOf(LuaScriptMgr.GetString(L, 2), (int) LuaDLL.lua_tonumber(L, 3), (int) LuaDLL.lua_tonumber(L, 4));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof (string), typeof (string), typeof (int), typeof (StringComparison)))
    {
      int d = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).LastIndexOf(LuaScriptMgr.GetString(L, 2), (int) LuaDLL.lua_tonumber(L, 3), (StringComparison) LuaScriptMgr.GetLuaObject(L, 4));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof (string), typeof (char), typeof (int), typeof (int)))
    {
      int d = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).LastIndexOf((char) LuaDLL.lua_tonumber(L, 2), (int) LuaDLL.lua_tonumber(L, 3), (int) LuaDLL.lua_tonumber(L, 4));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 5)
    {
      int d = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).LastIndexOf(LuaScriptMgr.GetLuaString(L, 2), (int) LuaScriptMgr.GetNumber(L, 3), (int) LuaScriptMgr.GetNumber(L, 4), (StringComparison) LuaScriptMgr.GetNetObject(L, 5, typeof (StringComparison)));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: string.LastIndexOf");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int LastIndexOfAny(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        int d1 = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).LastIndexOfAny(LuaScriptMgr.GetArrayNumber<char>(L, 2));
        LuaScriptMgr.Push(L, d1);
        return 1;
      case 3:
        int d2 = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).LastIndexOfAny(LuaScriptMgr.GetArrayNumber<char>(L, 2), (int) LuaScriptMgr.GetNumber(L, 3));
        LuaScriptMgr.Push(L, d2);
        return 1;
      case 4:
        int d3 = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).LastIndexOfAny(LuaScriptMgr.GetArrayNumber<char>(L, 2), (int) LuaScriptMgr.GetNumber(L, 3), (int) LuaScriptMgr.GetNumber(L, 4));
        LuaScriptMgr.Push(L, d3);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: string.LastIndexOfAny");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Contains(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    bool b = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).Contains(LuaScriptMgr.GetLuaString(L, 2));
    LuaScriptMgr.Push(L, b);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int IsNullOrEmpty(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    bool b = string.IsNullOrEmpty(LuaScriptMgr.GetLuaString(L, 1));
    LuaScriptMgr.Push(L, b);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Normalize(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        string str1 = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).Normalize();
        LuaScriptMgr.Push(L, str1);
        return 1;
      case 2:
        string str2 = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).Normalize((NormalizationForm) LuaScriptMgr.GetNetObject(L, 2, typeof (NormalizationForm)));
        LuaScriptMgr.Push(L, str2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: string.Normalize");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int IsNormalized(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        bool b1 = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).IsNormalized();
        LuaScriptMgr.Push(L, b1);
        return 1;
      case 2:
        bool b2 = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).IsNormalized((NormalizationForm) LuaScriptMgr.GetNetObject(L, 2, typeof (NormalizationForm)));
        LuaScriptMgr.Push(L, b2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: string.IsNormalized");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Remove(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        string str1 = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).Remove((int) LuaScriptMgr.GetNumber(L, 2));
        LuaScriptMgr.Push(L, str1);
        return 1;
      case 3:
        string str2 = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).Remove((int) LuaScriptMgr.GetNumber(L, 2), (int) LuaScriptMgr.GetNumber(L, 3));
        LuaScriptMgr.Push(L, str2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: string.Remove");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int PadLeft(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        string str1 = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).PadLeft((int) LuaScriptMgr.GetNumber(L, 2));
        LuaScriptMgr.Push(L, str1);
        return 1;
      case 3:
        string str2 = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).PadLeft((int) LuaScriptMgr.GetNumber(L, 2), (char) LuaScriptMgr.GetNumber(L, 3));
        LuaScriptMgr.Push(L, str2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: string.PadLeft");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int PadRight(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        string str1 = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).PadRight((int) LuaScriptMgr.GetNumber(L, 2));
        LuaScriptMgr.Push(L, str1);
        return 1;
      case 3:
        string str2 = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).PadRight((int) LuaScriptMgr.GetNumber(L, 2), (char) LuaScriptMgr.GetNumber(L, 3));
        LuaScriptMgr.Push(L, str2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: string.PadRight");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int StartsWith(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        bool b1 = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).StartsWith(LuaScriptMgr.GetLuaString(L, 2));
        LuaScriptMgr.Push(L, b1);
        return 1;
      case 3:
        bool b2 = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).StartsWith(LuaScriptMgr.GetLuaString(L, 2), (StringComparison) LuaScriptMgr.GetNetObject(L, 3, typeof (StringComparison)));
        LuaScriptMgr.Push(L, b2);
        return 1;
      case 4:
        bool b3 = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).StartsWith(LuaScriptMgr.GetLuaString(L, 2), LuaScriptMgr.GetBoolean(L, 3), (CultureInfo) LuaScriptMgr.GetNetObject(L, 4, typeof (CultureInfo)));
        LuaScriptMgr.Push(L, b3);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: string.StartsWith");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Replace(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (string), typeof (string), typeof (string)))
    {
      string str = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).Replace(LuaScriptMgr.GetString(L, 2), LuaScriptMgr.GetString(L, 3));
      LuaScriptMgr.Push(L, str);
      return 1;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (string), typeof (char), typeof (char)))
    {
      string str = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).Replace((char) LuaDLL.lua_tonumber(L, 2), (char) LuaDLL.lua_tonumber(L, 3));
      LuaScriptMgr.Push(L, str);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: string.Replace");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int ToLower(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        string lower1 = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).ToLower();
        LuaScriptMgr.Push(L, lower1);
        return 1;
      case 2:
        string lower2 = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).ToLower((CultureInfo) LuaScriptMgr.GetNetObject(L, 2, typeof (CultureInfo)));
        LuaScriptMgr.Push(L, lower2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: string.ToLower");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int ToLowerInvariant(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    string lowerInvariant = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).ToLowerInvariant();
    LuaScriptMgr.Push(L, lowerInvariant);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int ToUpper(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        string upper1 = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).ToUpper();
        LuaScriptMgr.Push(L, upper1);
        return 1;
      case 2:
        string upper2 = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).ToUpper((CultureInfo) LuaScriptMgr.GetNetObject(L, 2, typeof (CultureInfo)));
        LuaScriptMgr.Push(L, upper2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: string.ToUpper");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int ToUpperInvariant(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    string upperInvariant = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).ToUpperInvariant();
    LuaScriptMgr.Push(L, upperInvariant);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int ToString(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        string str1 = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).ToString();
        LuaScriptMgr.Push(L, str1);
        return 1;
      case 2:
        string str2 = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).ToString((IFormatProvider) LuaScriptMgr.GetNetObject(L, 2, typeof (IFormatProvider)));
        LuaScriptMgr.Push(L, str2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: string.ToString");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Format(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 2)
    {
      string str = string.Format(LuaScriptMgr.GetLuaString(L, 1), LuaScriptMgr.GetVarObject(L, 2));
      LuaScriptMgr.Push(L, str);
      return 1;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (string), typeof (object), typeof (object)))
    {
      string str = string.Format(LuaScriptMgr.GetString(L, 1), LuaScriptMgr.GetVarObject(L, 2), LuaScriptMgr.GetVarObject(L, 3));
      LuaScriptMgr.Push(L, str);
      return 1;
    }
    if (num == 4)
    {
      string str = string.Format(LuaScriptMgr.GetLuaString(L, 1), LuaScriptMgr.GetVarObject(L, 2), LuaScriptMgr.GetVarObject(L, 3), LuaScriptMgr.GetVarObject(L, 4));
      LuaScriptMgr.Push(L, str);
      return 1;
    }
    if (LuaScriptMgr.CheckTypes(L, 1, typeof (IFormatProvider), typeof (string)) && LuaScriptMgr.CheckParamsType(L, typeof (object), 3, num - 2))
    {
      string str = string.Format((IFormatProvider) LuaScriptMgr.GetLuaObject(L, 1), LuaScriptMgr.GetString(L, 2), LuaScriptMgr.GetParamsObject(L, 3, num - 2));
      LuaScriptMgr.Push(L, str);
      return 1;
    }
    if (LuaScriptMgr.CheckTypes(L, 1, typeof (string)) && LuaScriptMgr.CheckParamsType(L, typeof (object), 2, num - 1))
    {
      string str = string.Format(LuaScriptMgr.GetString(L, 1), LuaScriptMgr.GetParamsObject(L, 2, num - 1));
      LuaScriptMgr.Push(L, str);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: string.Format");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Copy(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    string str = string.Copy(LuaScriptMgr.GetLuaString(L, 1));
    LuaScriptMgr.Push(L, str);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Concat(IntPtr L)
  {
    int count = LuaDLL.lua_gettop(L);
    if (count == 1)
    {
      string str = string.Concat(LuaScriptMgr.GetVarObject(L, 1));
      LuaScriptMgr.Push(L, str);
      return 1;
    }
    if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (string), typeof (string)))
    {
      string str = LuaScriptMgr.GetString(L, 1) + LuaScriptMgr.GetString(L, 2);
      LuaScriptMgr.Push(L, str);
      return 1;
    }
    if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (object), typeof (object)))
    {
      string str = LuaScriptMgr.GetVarObject(L, 1).ToString() + LuaScriptMgr.GetVarObject(L, 2);
      LuaScriptMgr.Push(L, str);
      return 1;
    }
    if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (string), typeof (string), typeof (string)))
    {
      string str = LuaScriptMgr.GetString(L, 1) + LuaScriptMgr.GetString(L, 2) + LuaScriptMgr.GetString(L, 3);
      LuaScriptMgr.Push(L, str);
      return 1;
    }
    if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (object), typeof (object), typeof (object)))
    {
      string str = LuaScriptMgr.GetVarObject(L, 1).ToString() + LuaScriptMgr.GetVarObject(L, 2) + LuaScriptMgr.GetVarObject(L, 3);
      LuaScriptMgr.Push(L, str);
      return 1;
    }
    if (count == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof (string), typeof (string), typeof (string), typeof (string)))
    {
      string str = LuaScriptMgr.GetString(L, 1) + LuaScriptMgr.GetString(L, 2) + LuaScriptMgr.GetString(L, 3) + LuaScriptMgr.GetString(L, 4);
      LuaScriptMgr.Push(L, str);
      return 1;
    }
    if (count == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof (object), typeof (object), typeof (object), typeof (object)))
    {
      string str = LuaScriptMgr.GetVarObject(L, 1).ToString() + LuaScriptMgr.GetVarObject(L, 2) + LuaScriptMgr.GetVarObject(L, 3) + LuaScriptMgr.GetVarObject(L, 4);
      LuaScriptMgr.Push(L, str);
      return 1;
    }
    if (LuaScriptMgr.CheckParamsType(L, typeof (string), 1, count))
    {
      string str = string.Concat(LuaScriptMgr.GetParamsString(L, 1, count));
      LuaScriptMgr.Push(L, str);
      return 1;
    }
    if (LuaScriptMgr.CheckParamsType(L, typeof (object), 1, count))
    {
      string str = string.Concat(LuaScriptMgr.GetParamsObject(L, 1, count));
      LuaScriptMgr.Push(L, str);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: string.Concat");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Insert(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 3);
    string str = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).Insert((int) LuaScriptMgr.GetNumber(L, 2), LuaScriptMgr.GetLuaString(L, 3));
    LuaScriptMgr.Push(L, str);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Intern(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    string str = string.Intern(LuaScriptMgr.GetLuaString(L, 1));
    LuaScriptMgr.Push(L, str);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int IsInterned(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    string str = string.IsInterned(LuaScriptMgr.GetLuaString(L, 1));
    LuaScriptMgr.Push(L, str);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Join(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        string str1 = string.Join(LuaScriptMgr.GetLuaString(L, 1), LuaScriptMgr.GetArrayString(L, 2));
        LuaScriptMgr.Push(L, str1);
        return 1;
      case 4:
        string str2 = string.Join(LuaScriptMgr.GetLuaString(L, 1), LuaScriptMgr.GetArrayString(L, 2), (int) LuaScriptMgr.GetNumber(L, 3), (int) LuaScriptMgr.GetNumber(L, 4));
        LuaScriptMgr.Push(L, str2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: string.Join");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetEnumerator(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    CharEnumerator enumerator = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).GetEnumerator();
    LuaScriptMgr.Push(L, (IEnumerator) enumerator);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetHashCode(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    int hashCode = ((string) LuaScriptMgr.GetNetObjectSelf(L, 1, "string")).GetHashCode();
    LuaScriptMgr.Push(L, hashCode);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Lua_Eq(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    bool b = LuaScriptMgr.GetLuaString(L, 1) == LuaScriptMgr.GetLuaString(L, 2);
    LuaScriptMgr.Push(L, b);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Equals(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 2, typeof (string)))
    {
      string varObject = LuaScriptMgr.GetVarObject(L, 1) as string;
      string str = LuaScriptMgr.GetString(L, 2);
      bool b = varObject == null ? str == null : varObject.Equals(str);
      LuaScriptMgr.Push(L, b);
      return 1;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 2, typeof (object)))
    {
      string varObject1 = LuaScriptMgr.GetVarObject(L, 1) as string;
      object varObject2 = LuaScriptMgr.GetVarObject(L, 2);
      bool b = varObject1 == null ? varObject2 == null : varObject1.Equals(varObject2);
      LuaScriptMgr.Push(L, b);
      return 1;
    }
    if (num == 3)
    {
      string varObject = LuaScriptMgr.GetVarObject(L, 1) as string;
      string luaString = LuaScriptMgr.GetLuaString(L, 2);
      StringComparison netObject = (StringComparison) LuaScriptMgr.GetNetObject(L, 3, typeof (StringComparison));
      bool b = varObject == null ? luaString == null : varObject.Equals(luaString, netObject);
      LuaScriptMgr.Push(L, b);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: string.Equals");
    return 0;
  }
}
