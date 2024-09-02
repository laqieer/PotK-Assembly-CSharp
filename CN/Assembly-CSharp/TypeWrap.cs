// Decompiled with JetBrains decompiler
// Type: TypeWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using System;
using System.Globalization;
using System.Reflection;

#nullable disable
public class TypeWrap
{
  private static System.Type classType = typeof (System.Type);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[47]
    {
      new LuaMethod("Equals", new LuaCSFunction(TypeWrap.Equals)),
      new LuaMethod("GetType", new LuaCSFunction(TypeWrap.GetType)),
      new LuaMethod("GetTypeArray", new LuaCSFunction(TypeWrap.GetTypeArray)),
      new LuaMethod("GetTypeCode", new LuaCSFunction(TypeWrap.GetTypeCode)),
      new LuaMethod("GetTypeFromCLSID", new LuaCSFunction(TypeWrap.GetTypeFromCLSID)),
      new LuaMethod("GetTypeFromHandle", new LuaCSFunction(TypeWrap.GetTypeFromHandle)),
      new LuaMethod("GetTypeFromProgID", new LuaCSFunction(TypeWrap.GetTypeFromProgID)),
      new LuaMethod("GetTypeHandle", new LuaCSFunction(TypeWrap.GetTypeHandle)),
      new LuaMethod("IsSubclassOf", new LuaCSFunction(TypeWrap.IsSubclassOf)),
      new LuaMethod("FindInterfaces", new LuaCSFunction(TypeWrap.FindInterfaces)),
      new LuaMethod("GetInterface", new LuaCSFunction(TypeWrap.GetInterface)),
      new LuaMethod("GetInterfaceMap", new LuaCSFunction(TypeWrap.GetInterfaceMap)),
      new LuaMethod("GetInterfaces", new LuaCSFunction(TypeWrap.GetInterfaces)),
      new LuaMethod("IsAssignableFrom", new LuaCSFunction(TypeWrap.IsAssignableFrom)),
      new LuaMethod("IsInstanceOfType", new LuaCSFunction(TypeWrap.IsInstanceOfType)),
      new LuaMethod("GetArrayRank", new LuaCSFunction(TypeWrap.GetArrayRank)),
      new LuaMethod("GetElementType", new LuaCSFunction(TypeWrap.GetElementType)),
      new LuaMethod("GetEvent", new LuaCSFunction(TypeWrap.GetEvent)),
      new LuaMethod("GetEvents", new LuaCSFunction(TypeWrap.GetEvents)),
      new LuaMethod("GetField", new LuaCSFunction(TypeWrap.GetField)),
      new LuaMethod("GetFields", new LuaCSFunction(TypeWrap.GetFields)),
      new LuaMethod("GetHashCode", new LuaCSFunction(TypeWrap.GetHashCode)),
      new LuaMethod("GetMember", new LuaCSFunction(TypeWrap.GetMember)),
      new LuaMethod("GetMembers", new LuaCSFunction(TypeWrap.GetMembers)),
      new LuaMethod("GetMethod", new LuaCSFunction(TypeWrap.GetMethod)),
      new LuaMethod("GetMethods", new LuaCSFunction(TypeWrap.GetMethods)),
      new LuaMethod("GetNestedType", new LuaCSFunction(TypeWrap.GetNestedType)),
      new LuaMethod("GetNestedTypes", new LuaCSFunction(TypeWrap.GetNestedTypes)),
      new LuaMethod("GetProperties", new LuaCSFunction(TypeWrap.GetProperties)),
      new LuaMethod("GetProperty", new LuaCSFunction(TypeWrap.GetProperty)),
      new LuaMethod("GetConstructor", new LuaCSFunction(TypeWrap.GetConstructor)),
      new LuaMethod("GetConstructors", new LuaCSFunction(TypeWrap.GetConstructors)),
      new LuaMethod("GetDefaultMembers", new LuaCSFunction(TypeWrap.GetDefaultMembers)),
      new LuaMethod("FindMembers", new LuaCSFunction(TypeWrap.FindMembers)),
      new LuaMethod("InvokeMember", new LuaCSFunction(TypeWrap.InvokeMember)),
      new LuaMethod("ToString", new LuaCSFunction(TypeWrap.ToString)),
      new LuaMethod("GetGenericArguments", new LuaCSFunction(TypeWrap.GetGenericArguments)),
      new LuaMethod("GetGenericTypeDefinition", new LuaCSFunction(TypeWrap.GetGenericTypeDefinition)),
      new LuaMethod("MakeGenericType", new LuaCSFunction(TypeWrap.MakeGenericType)),
      new LuaMethod("GetGenericParameterConstraints", new LuaCSFunction(TypeWrap.GetGenericParameterConstraints)),
      new LuaMethod("MakeArrayType", new LuaCSFunction(TypeWrap.MakeArrayType)),
      new LuaMethod("MakeByRefType", new LuaCSFunction(TypeWrap.MakeByRefType)),
      new LuaMethod("MakePointerType", new LuaCSFunction(TypeWrap.MakePointerType)),
      new LuaMethod("ReflectionOnlyGetType", new LuaCSFunction(TypeWrap.ReflectionOnlyGetType)),
      new LuaMethod("New", new LuaCSFunction(TypeWrap._CreateType)),
      new LuaMethod("GetClassType", new LuaCSFunction(TypeWrap.GetClassType)),
      new LuaMethod("__tostring", new LuaCSFunction(TypeWrap.Lua_ToString))
    };
    LuaField[] fields = new LuaField[62]
    {
      new LuaField("Delimiter", new LuaCSFunction(TypeWrap.get_Delimiter), (LuaCSFunction) null),
      new LuaField("EmptyTypes", new LuaCSFunction(TypeWrap.get_EmptyTypes), (LuaCSFunction) null),
      new LuaField("FilterAttribute", new LuaCSFunction(TypeWrap.get_FilterAttribute), (LuaCSFunction) null),
      new LuaField("FilterName", new LuaCSFunction(TypeWrap.get_FilterName), (LuaCSFunction) null),
      new LuaField("FilterNameIgnoreCase", new LuaCSFunction(TypeWrap.get_FilterNameIgnoreCase), (LuaCSFunction) null),
      new LuaField("Missing", new LuaCSFunction(TypeWrap.get_Missing), (LuaCSFunction) null),
      new LuaField("Assembly", new LuaCSFunction(TypeWrap.get_Assembly), (LuaCSFunction) null),
      new LuaField("AssemblyQualifiedName", new LuaCSFunction(TypeWrap.get_AssemblyQualifiedName), (LuaCSFunction) null),
      new LuaField("Attributes", new LuaCSFunction(TypeWrap.get_Attributes), (LuaCSFunction) null),
      new LuaField("BaseType", new LuaCSFunction(TypeWrap.get_BaseType), (LuaCSFunction) null),
      new LuaField("DeclaringType", new LuaCSFunction(TypeWrap.get_DeclaringType), (LuaCSFunction) null),
      new LuaField("DefaultBinder", new LuaCSFunction(TypeWrap.get_DefaultBinder), (LuaCSFunction) null),
      new LuaField("FullName", new LuaCSFunction(TypeWrap.get_FullName), (LuaCSFunction) null),
      new LuaField("GUID", new LuaCSFunction(TypeWrap.get_GUID), (LuaCSFunction) null),
      new LuaField("HasElementType", new LuaCSFunction(TypeWrap.get_HasElementType), (LuaCSFunction) null),
      new LuaField("IsAbstract", new LuaCSFunction(TypeWrap.get_IsAbstract), (LuaCSFunction) null),
      new LuaField("IsAnsiClass", new LuaCSFunction(TypeWrap.get_IsAnsiClass), (LuaCSFunction) null),
      new LuaField("IsArray", new LuaCSFunction(TypeWrap.get_IsArray), (LuaCSFunction) null),
      new LuaField("IsAutoClass", new LuaCSFunction(TypeWrap.get_IsAutoClass), (LuaCSFunction) null),
      new LuaField("IsAutoLayout", new LuaCSFunction(TypeWrap.get_IsAutoLayout), (LuaCSFunction) null),
      new LuaField("IsByRef", new LuaCSFunction(TypeWrap.get_IsByRef), (LuaCSFunction) null),
      new LuaField("IsClass", new LuaCSFunction(TypeWrap.get_IsClass), (LuaCSFunction) null),
      new LuaField("IsCOMObject", new LuaCSFunction(TypeWrap.get_IsCOMObject), (LuaCSFunction) null),
      new LuaField("IsContextful", new LuaCSFunction(TypeWrap.get_IsContextful), (LuaCSFunction) null),
      new LuaField("IsEnum", new LuaCSFunction(TypeWrap.get_IsEnum), (LuaCSFunction) null),
      new LuaField("IsExplicitLayout", new LuaCSFunction(TypeWrap.get_IsExplicitLayout), (LuaCSFunction) null),
      new LuaField("IsImport", new LuaCSFunction(TypeWrap.get_IsImport), (LuaCSFunction) null),
      new LuaField("IsInterface", new LuaCSFunction(TypeWrap.get_IsInterface), (LuaCSFunction) null),
      new LuaField("IsLayoutSequential", new LuaCSFunction(TypeWrap.get_IsLayoutSequential), (LuaCSFunction) null),
      new LuaField("IsMarshalByRef", new LuaCSFunction(TypeWrap.get_IsMarshalByRef), (LuaCSFunction) null),
      new LuaField("IsNestedAssembly", new LuaCSFunction(TypeWrap.get_IsNestedAssembly), (LuaCSFunction) null),
      new LuaField("IsNestedFamANDAssem", new LuaCSFunction(TypeWrap.get_IsNestedFamANDAssem), (LuaCSFunction) null),
      new LuaField("IsNestedFamily", new LuaCSFunction(TypeWrap.get_IsNestedFamily), (LuaCSFunction) null),
      new LuaField("IsNestedFamORAssem", new LuaCSFunction(TypeWrap.get_IsNestedFamORAssem), (LuaCSFunction) null),
      new LuaField("IsNestedPrivate", new LuaCSFunction(TypeWrap.get_IsNestedPrivate), (LuaCSFunction) null),
      new LuaField("IsNestedPublic", new LuaCSFunction(TypeWrap.get_IsNestedPublic), (LuaCSFunction) null),
      new LuaField("IsNotPublic", new LuaCSFunction(TypeWrap.get_IsNotPublic), (LuaCSFunction) null),
      new LuaField("IsPointer", new LuaCSFunction(TypeWrap.get_IsPointer), (LuaCSFunction) null),
      new LuaField("IsPrimitive", new LuaCSFunction(TypeWrap.get_IsPrimitive), (LuaCSFunction) null),
      new LuaField("IsPublic", new LuaCSFunction(TypeWrap.get_IsPublic), (LuaCSFunction) null),
      new LuaField("IsSealed", new LuaCSFunction(TypeWrap.get_IsSealed), (LuaCSFunction) null),
      new LuaField("IsSerializable", new LuaCSFunction(TypeWrap.get_IsSerializable), (LuaCSFunction) null),
      new LuaField("IsSpecialName", new LuaCSFunction(TypeWrap.get_IsSpecialName), (LuaCSFunction) null),
      new LuaField("IsUnicodeClass", new LuaCSFunction(TypeWrap.get_IsUnicodeClass), (LuaCSFunction) null),
      new LuaField("IsValueType", new LuaCSFunction(TypeWrap.get_IsValueType), (LuaCSFunction) null),
      new LuaField("MemberType", new LuaCSFunction(TypeWrap.get_MemberType), (LuaCSFunction) null),
      new LuaField("Module", new LuaCSFunction(TypeWrap.get_Module), (LuaCSFunction) null),
      new LuaField("Namespace", new LuaCSFunction(TypeWrap.get_Namespace), (LuaCSFunction) null),
      new LuaField("ReflectedType", new LuaCSFunction(TypeWrap.get_ReflectedType), (LuaCSFunction) null),
      new LuaField("TypeHandle", new LuaCSFunction(TypeWrap.get_TypeHandle), (LuaCSFunction) null),
      new LuaField("TypeInitializer", new LuaCSFunction(TypeWrap.get_TypeInitializer), (LuaCSFunction) null),
      new LuaField("UnderlyingSystemType", new LuaCSFunction(TypeWrap.get_UnderlyingSystemType), (LuaCSFunction) null),
      new LuaField("ContainsGenericParameters", new LuaCSFunction(TypeWrap.get_ContainsGenericParameters), (LuaCSFunction) null),
      new LuaField("IsGenericTypeDefinition", new LuaCSFunction(TypeWrap.get_IsGenericTypeDefinition), (LuaCSFunction) null),
      new LuaField("IsGenericType", new LuaCSFunction(TypeWrap.get_IsGenericType), (LuaCSFunction) null),
      new LuaField("IsGenericParameter", new LuaCSFunction(TypeWrap.get_IsGenericParameter), (LuaCSFunction) null),
      new LuaField("IsNested", new LuaCSFunction(TypeWrap.get_IsNested), (LuaCSFunction) null),
      new LuaField("IsVisible", new LuaCSFunction(TypeWrap.get_IsVisible), (LuaCSFunction) null),
      new LuaField("GenericParameterPosition", new LuaCSFunction(TypeWrap.get_GenericParameterPosition), (LuaCSFunction) null),
      new LuaField("GenericParameterAttributes", new LuaCSFunction(TypeWrap.get_GenericParameterAttributes), (LuaCSFunction) null),
      new LuaField("DeclaringMethod", new LuaCSFunction(TypeWrap.get_DeclaringMethod), (LuaCSFunction) null),
      new LuaField("StructLayoutAttribute", new LuaCSFunction(TypeWrap.get_StructLayoutAttribute), (LuaCSFunction) null)
    };
    LuaScriptMgr.RegisterLib(L, "System.Type", typeof (System.Type), regs, fields, typeof (object));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateType(IntPtr L)
  {
    LuaDLL.luaL_error(L, "Type class does not have a constructor function");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, TypeWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_Delimiter(IntPtr L)
  {
    LuaScriptMgr.Push(L, System.Type.Delimiter);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_EmptyTypes(IntPtr L)
  {
    LuaScriptMgr.PushArray(L, (Array) System.Type.EmptyTypes);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_FilterAttribute(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Delegate) System.Type.FilterAttribute);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_FilterName(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Delegate) System.Type.FilterName);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_FilterNameIgnoreCase(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Delegate) System.Type.FilterNameIgnoreCase);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_Missing(IntPtr L)
  {
    LuaScriptMgr.PushVarObject(L, System.Type.Missing);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_Assembly(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name Assembly");
      else
        LuaDLL.luaL_error(L, "attempt to index Assembly on a nil value");
    }
    LuaScriptMgr.PushObject(L, (object) luaObject.Assembly);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_AssemblyQualifiedName(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name AssemblyQualifiedName");
      else
        LuaDLL.luaL_error(L, "attempt to index AssemblyQualifiedName on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.AssemblyQualifiedName);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_Attributes(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name Attributes");
      else
        LuaDLL.luaL_error(L, "attempt to index Attributes on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) luaObject.Attributes);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_BaseType(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name BaseType");
      else
        LuaDLL.luaL_error(L, "attempt to index BaseType on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.BaseType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_DeclaringType(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name DeclaringType");
      else
        LuaDLL.luaL_error(L, "attempt to index DeclaringType on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.DeclaringType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_DefaultBinder(IntPtr L)
  {
    LuaScriptMgr.PushObject(L, (object) System.Type.DefaultBinder);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_FullName(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name FullName");
      else
        LuaDLL.luaL_error(L, "attempt to index FullName on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.FullName);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_GUID(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name GUID");
      else
        LuaDLL.luaL_error(L, "attempt to index GUID on a nil value");
    }
    LuaScriptMgr.PushValue(L, (object) luaObject.GUID);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_HasElementType(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name HasElementType");
      else
        LuaDLL.luaL_error(L, "attempt to index HasElementType on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.HasElementType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_IsAbstract(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name IsAbstract");
      else
        LuaDLL.luaL_error(L, "attempt to index IsAbstract on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.IsAbstract);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_IsAnsiClass(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name IsAnsiClass");
      else
        LuaDLL.luaL_error(L, "attempt to index IsAnsiClass on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.IsAnsiClass);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_IsArray(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name IsArray");
      else
        LuaDLL.luaL_error(L, "attempt to index IsArray on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.IsArray);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_IsAutoClass(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name IsAutoClass");
      else
        LuaDLL.luaL_error(L, "attempt to index IsAutoClass on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.IsAutoClass);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_IsAutoLayout(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name IsAutoLayout");
      else
        LuaDLL.luaL_error(L, "attempt to index IsAutoLayout on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.IsAutoLayout);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_IsByRef(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name IsByRef");
      else
        LuaDLL.luaL_error(L, "attempt to index IsByRef on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.IsByRef);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_IsClass(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name IsClass");
      else
        LuaDLL.luaL_error(L, "attempt to index IsClass on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.IsClass);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_IsCOMObject(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name IsCOMObject");
      else
        LuaDLL.luaL_error(L, "attempt to index IsCOMObject on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.IsCOMObject);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_IsContextful(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name IsContextful");
      else
        LuaDLL.luaL_error(L, "attempt to index IsContextful on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.IsContextful);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_IsEnum(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name IsEnum");
      else
        LuaDLL.luaL_error(L, "attempt to index IsEnum on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.IsEnum);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_IsExplicitLayout(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name IsExplicitLayout");
      else
        LuaDLL.luaL_error(L, "attempt to index IsExplicitLayout on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.IsExplicitLayout);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_IsImport(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name IsImport");
      else
        LuaDLL.luaL_error(L, "attempt to index IsImport on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.IsImport);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_IsInterface(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name IsInterface");
      else
        LuaDLL.luaL_error(L, "attempt to index IsInterface on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.IsInterface);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_IsLayoutSequential(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name IsLayoutSequential");
      else
        LuaDLL.luaL_error(L, "attempt to index IsLayoutSequential on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.IsLayoutSequential);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_IsMarshalByRef(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name IsMarshalByRef");
      else
        LuaDLL.luaL_error(L, "attempt to index IsMarshalByRef on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.IsMarshalByRef);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_IsNestedAssembly(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name IsNestedAssembly");
      else
        LuaDLL.luaL_error(L, "attempt to index IsNestedAssembly on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.IsNestedAssembly);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_IsNestedFamANDAssem(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name IsNestedFamANDAssem");
      else
        LuaDLL.luaL_error(L, "attempt to index IsNestedFamANDAssem on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.IsNestedFamANDAssem);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_IsNestedFamily(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name IsNestedFamily");
      else
        LuaDLL.luaL_error(L, "attempt to index IsNestedFamily on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.IsNestedFamily);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_IsNestedFamORAssem(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name IsNestedFamORAssem");
      else
        LuaDLL.luaL_error(L, "attempt to index IsNestedFamORAssem on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.IsNestedFamORAssem);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_IsNestedPrivate(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name IsNestedPrivate");
      else
        LuaDLL.luaL_error(L, "attempt to index IsNestedPrivate on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.IsNestedPrivate);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_IsNestedPublic(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name IsNestedPublic");
      else
        LuaDLL.luaL_error(L, "attempt to index IsNestedPublic on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.IsNestedPublic);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_IsNotPublic(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name IsNotPublic");
      else
        LuaDLL.luaL_error(L, "attempt to index IsNotPublic on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.IsNotPublic);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_IsPointer(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name IsPointer");
      else
        LuaDLL.luaL_error(L, "attempt to index IsPointer on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.IsPointer);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_IsPrimitive(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name IsPrimitive");
      else
        LuaDLL.luaL_error(L, "attempt to index IsPrimitive on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.IsPrimitive);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_IsPublic(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name IsPublic");
      else
        LuaDLL.luaL_error(L, "attempt to index IsPublic on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.IsPublic);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_IsSealed(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name IsSealed");
      else
        LuaDLL.luaL_error(L, "attempt to index IsSealed on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.IsSealed);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_IsSerializable(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name IsSerializable");
      else
        LuaDLL.luaL_error(L, "attempt to index IsSerializable on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.IsSerializable);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_IsSpecialName(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name IsSpecialName");
      else
        LuaDLL.luaL_error(L, "attempt to index IsSpecialName on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.IsSpecialName);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_IsUnicodeClass(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name IsUnicodeClass");
      else
        LuaDLL.luaL_error(L, "attempt to index IsUnicodeClass on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.IsUnicodeClass);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_IsValueType(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name IsValueType");
      else
        LuaDLL.luaL_error(L, "attempt to index IsValueType on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.IsValueType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_MemberType(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name MemberType");
      else
        LuaDLL.luaL_error(L, "attempt to index MemberType on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) luaObject.MemberType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_Module(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name Module");
      else
        LuaDLL.luaL_error(L, "attempt to index Module on a nil value");
    }
    LuaScriptMgr.PushObject(L, (object) luaObject.Module);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_Namespace(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name Namespace");
      else
        LuaDLL.luaL_error(L, "attempt to index Namespace on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.Namespace);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_ReflectedType(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name ReflectedType");
      else
        LuaDLL.luaL_error(L, "attempt to index ReflectedType on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.ReflectedType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_TypeHandle(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name TypeHandle");
      else
        LuaDLL.luaL_error(L, "attempt to index TypeHandle on a nil value");
    }
    LuaScriptMgr.PushValue(L, (object) luaObject.TypeHandle);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_TypeInitializer(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name TypeInitializer");
      else
        LuaDLL.luaL_error(L, "attempt to index TypeInitializer on a nil value");
    }
    LuaScriptMgr.PushObject(L, (object) luaObject.TypeInitializer);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_UnderlyingSystemType(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name UnderlyingSystemType");
      else
        LuaDLL.luaL_error(L, "attempt to index UnderlyingSystemType on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.UnderlyingSystemType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_ContainsGenericParameters(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name ContainsGenericParameters");
      else
        LuaDLL.luaL_error(L, "attempt to index ContainsGenericParameters on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.ContainsGenericParameters);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_IsGenericTypeDefinition(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name IsGenericTypeDefinition");
      else
        LuaDLL.luaL_error(L, "attempt to index IsGenericTypeDefinition on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.IsGenericTypeDefinition);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_IsGenericType(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name IsGenericType");
      else
        LuaDLL.luaL_error(L, "attempt to index IsGenericType on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.IsGenericType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_IsGenericParameter(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name IsGenericParameter");
      else
        LuaDLL.luaL_error(L, "attempt to index IsGenericParameter on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.IsGenericParameter);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_IsNested(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name IsNested");
      else
        LuaDLL.luaL_error(L, "attempt to index IsNested on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.IsNested);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_IsVisible(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name IsVisible");
      else
        LuaDLL.luaL_error(L, "attempt to index IsVisible on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.IsVisible);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_GenericParameterPosition(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name GenericParameterPosition");
      else
        LuaDLL.luaL_error(L, "attempt to index GenericParameterPosition on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.GenericParameterPosition);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_GenericParameterAttributes(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name GenericParameterAttributes");
      else
        LuaDLL.luaL_error(L, "attempt to index GenericParameterAttributes on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) luaObject.GenericParameterAttributes);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_DeclaringMethod(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name DeclaringMethod");
      else
        LuaDLL.luaL_error(L, "attempt to index DeclaringMethod on a nil value");
    }
    LuaScriptMgr.PushObject(L, (object) luaObject.DeclaringMethod);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_StructLayoutAttribute(IntPtr L)
  {
    System.Type luaObject = (System.Type) LuaScriptMgr.GetLuaObject(L, 1);
    if ((object) luaObject == null)
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name StructLayoutAttribute");
      else
        LuaDLL.luaL_error(L, "attempt to index StructLayoutAttribute on a nil value");
    }
    LuaScriptMgr.PushObject(L, (object) luaObject.StructLayoutAttribute);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Lua_ToString(IntPtr L)
  {
    object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
    if (luaObject != null)
      LuaScriptMgr.Push(L, luaObject.ToString());
    else
      LuaScriptMgr.Push(L, "Table: System.Type");
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Equals(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (System.Type), typeof (System.Type)))
    {
      System.Type varObject = LuaScriptMgr.GetVarObject(L, 1) as System.Type;
      System.Type typeObject = LuaScriptMgr.GetTypeObject(L, 2);
      bool b = (object) varObject == null ? (object) typeObject == null : varObject.Equals(typeObject);
      LuaScriptMgr.Push(L, b);
      return 1;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (System.Type), typeof (object)))
    {
      System.Type varObject1 = LuaScriptMgr.GetVarObject(L, 1) as System.Type;
      object varObject2 = LuaScriptMgr.GetVarObject(L, 2);
      bool b = (object) varObject1 == null ? varObject2 == null : varObject1.Equals(varObject2);
      LuaScriptMgr.Push(L, b);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Type.Equals");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetType(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 1)
    {
      System.Type type = LuaScriptMgr.GetTypeObject(L, 1).GetType();
      LuaScriptMgr.Push(L, type);
      return 1;
    }
    if (num == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof (string)))
    {
      System.Type type = System.Type.GetType(LuaScriptMgr.GetString(L, 1));
      LuaScriptMgr.Push(L, type);
      return 1;
    }
    if (num == 2)
    {
      System.Type type = System.Type.GetType(LuaScriptMgr.GetLuaString(L, 1), LuaScriptMgr.GetBoolean(L, 2));
      LuaScriptMgr.Push(L, type);
      return 1;
    }
    if (num == 3)
    {
      System.Type type = System.Type.GetType(LuaScriptMgr.GetLuaString(L, 1), LuaScriptMgr.GetBoolean(L, 2), LuaScriptMgr.GetBoolean(L, 3));
      LuaScriptMgr.Push(L, type);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Type.GetType");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetTypeArray(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    System.Type[] typeArray = System.Type.GetTypeArray(LuaScriptMgr.GetArrayObject<object>(L, 1));
    LuaScriptMgr.PushArray(L, (Array) typeArray);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetTypeCode(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    TypeCode typeCode = System.Type.GetTypeCode(LuaScriptMgr.GetTypeObject(L, 1));
    LuaScriptMgr.Push(L, (Enum) typeCode);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetTypeFromCLSID(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 1)
    {
      System.Type typeFromClsid = System.Type.GetTypeFromCLSID((Guid) LuaScriptMgr.GetNetObject(L, 1, typeof (Guid)));
      LuaScriptMgr.Push(L, typeFromClsid);
      return 1;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (Guid), typeof (string)))
    {
      System.Type typeFromClsid = System.Type.GetTypeFromCLSID((Guid) LuaScriptMgr.GetLuaObject(L, 1), LuaScriptMgr.GetString(L, 2));
      LuaScriptMgr.Push(L, typeFromClsid);
      return 1;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (Guid), typeof (bool)))
    {
      System.Type typeFromClsid = System.Type.GetTypeFromCLSID((Guid) LuaScriptMgr.GetLuaObject(L, 1), LuaDLL.lua_toboolean(L, 2));
      LuaScriptMgr.Push(L, typeFromClsid);
      return 1;
    }
    if (num == 3)
    {
      System.Type typeFromClsid = System.Type.GetTypeFromCLSID((Guid) LuaScriptMgr.GetNetObject(L, 1, typeof (Guid)), LuaScriptMgr.GetLuaString(L, 2), LuaScriptMgr.GetBoolean(L, 3));
      LuaScriptMgr.Push(L, typeFromClsid);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Type.GetTypeFromCLSID");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetTypeFromHandle(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    System.Type typeFromHandle = System.Type.GetTypeFromHandle((RuntimeTypeHandle) LuaScriptMgr.GetNetObject(L, 1, typeof (RuntimeTypeHandle)));
    LuaScriptMgr.Push(L, typeFromHandle);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetTypeFromProgID(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 1)
    {
      System.Type typeFromProgId = System.Type.GetTypeFromProgID(LuaScriptMgr.GetLuaString(L, 1));
      LuaScriptMgr.Push(L, typeFromProgId);
      return 1;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (string), typeof (string)))
    {
      System.Type typeFromProgId = System.Type.GetTypeFromProgID(LuaScriptMgr.GetString(L, 1), LuaScriptMgr.GetString(L, 2));
      LuaScriptMgr.Push(L, typeFromProgId);
      return 1;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (string), typeof (bool)))
    {
      System.Type typeFromProgId = System.Type.GetTypeFromProgID(LuaScriptMgr.GetString(L, 1), LuaDLL.lua_toboolean(L, 2));
      LuaScriptMgr.Push(L, typeFromProgId);
      return 1;
    }
    if (num == 3)
    {
      System.Type typeFromProgId = System.Type.GetTypeFromProgID(LuaScriptMgr.GetLuaString(L, 1), LuaScriptMgr.GetLuaString(L, 2), LuaScriptMgr.GetBoolean(L, 3));
      LuaScriptMgr.Push(L, typeFromProgId);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Type.GetTypeFromProgID");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetTypeHandle(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    RuntimeTypeHandle typeHandle = System.Type.GetTypeHandle(LuaScriptMgr.GetVarObject(L, 1));
    LuaScriptMgr.PushValue(L, (object) typeHandle);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int IsSubclassOf(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    bool b = LuaScriptMgr.GetTypeObject(L, 1).IsSubclassOf(LuaScriptMgr.GetTypeObject(L, 2));
    LuaScriptMgr.Push(L, b);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int FindInterfaces(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 3);
    System.Type typeObject = LuaScriptMgr.GetTypeObject(L, 1);
    TypeFilter filter;
    if (LuaDLL.lua_type(L, 2) != LuaTypes.LUA_TFUNCTION)
    {
      filter = (TypeFilter) LuaScriptMgr.GetNetObject(L, 2, typeof (TypeFilter));
    }
    else
    {
      LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 2);
      filter = (TypeFilter) ((param0, param1) =>
      {
        int oldTop = func.BeginPCall();
        LuaScriptMgr.Push(L, param0);
        LuaScriptMgr.PushVarObject(L, param1);
        func.PCall(oldTop, 2);
        object[] objArray = func.PopValues(oldTop);
        func.EndPCall(oldTop);
        return (bool) objArray[0];
      });
    }
    object varObject = LuaScriptMgr.GetVarObject(L, 3);
    System.Type[] interfaces = typeObject.FindInterfaces(filter, varObject);
    LuaScriptMgr.PushArray(L, (Array) interfaces);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetInterface(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        System.Type o1 = LuaScriptMgr.GetTypeObject(L, 1).GetInterface(LuaScriptMgr.GetLuaString(L, 2));
        LuaScriptMgr.Push(L, o1);
        return 1;
      case 3:
        System.Type o2 = LuaScriptMgr.GetTypeObject(L, 1).GetInterface(LuaScriptMgr.GetLuaString(L, 2), LuaScriptMgr.GetBoolean(L, 3));
        LuaScriptMgr.Push(L, o2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Type.GetInterface");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetInterfaceMap(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    InterfaceMapping interfaceMap = LuaScriptMgr.GetTypeObject(L, 1).GetInterfaceMap(LuaScriptMgr.GetTypeObject(L, 2));
    LuaScriptMgr.PushValue(L, (object) interfaceMap);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetInterfaces(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    System.Type[] interfaces = LuaScriptMgr.GetTypeObject(L, 1).GetInterfaces();
    LuaScriptMgr.PushArray(L, (Array) interfaces);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int IsAssignableFrom(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    bool b = LuaScriptMgr.GetTypeObject(L, 1).IsAssignableFrom(LuaScriptMgr.GetTypeObject(L, 2));
    LuaScriptMgr.Push(L, b);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int IsInstanceOfType(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    bool b = LuaScriptMgr.GetTypeObject(L, 1).IsInstanceOfType(LuaScriptMgr.GetVarObject(L, 2));
    LuaScriptMgr.Push(L, b);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetArrayRank(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    int arrayRank = LuaScriptMgr.GetTypeObject(L, 1).GetArrayRank();
    LuaScriptMgr.Push(L, arrayRank);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetElementType(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    System.Type elementType = LuaScriptMgr.GetTypeObject(L, 1).GetElementType();
    LuaScriptMgr.Push(L, elementType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetEvent(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        EventInfo o1 = LuaScriptMgr.GetTypeObject(L, 1).GetEvent(LuaScriptMgr.GetLuaString(L, 2));
        LuaScriptMgr.PushObject(L, (object) o1);
        return 1;
      case 3:
        EventInfo o2 = LuaScriptMgr.GetTypeObject(L, 1).GetEvent(LuaScriptMgr.GetLuaString(L, 2), (BindingFlags) LuaScriptMgr.GetNetObject(L, 3, typeof (BindingFlags)));
        LuaScriptMgr.PushObject(L, (object) o2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Type.GetEvent");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetEvents(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        EventInfo[] events1 = LuaScriptMgr.GetTypeObject(L, 1).GetEvents();
        LuaScriptMgr.PushArray(L, (Array) events1);
        return 1;
      case 2:
        EventInfo[] events2 = LuaScriptMgr.GetTypeObject(L, 1).GetEvents((BindingFlags) LuaScriptMgr.GetNetObject(L, 2, typeof (BindingFlags)));
        LuaScriptMgr.PushArray(L, (Array) events2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Type.GetEvents");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetField(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        FieldInfo field1 = LuaScriptMgr.GetTypeObject(L, 1).GetField(LuaScriptMgr.GetLuaString(L, 2));
        LuaScriptMgr.PushObject(L, (object) field1);
        return 1;
      case 3:
        FieldInfo field2 = LuaScriptMgr.GetTypeObject(L, 1).GetField(LuaScriptMgr.GetLuaString(L, 2), (BindingFlags) LuaScriptMgr.GetNetObject(L, 3, typeof (BindingFlags)));
        LuaScriptMgr.PushObject(L, (object) field2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Type.GetField");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetFields(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        FieldInfo[] fields1 = LuaScriptMgr.GetTypeObject(L, 1).GetFields();
        LuaScriptMgr.PushArray(L, (Array) fields1);
        return 1;
      case 2:
        FieldInfo[] fields2 = LuaScriptMgr.GetTypeObject(L, 1).GetFields((BindingFlags) LuaScriptMgr.GetNetObject(L, 2, typeof (BindingFlags)));
        LuaScriptMgr.PushArray(L, (Array) fields2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Type.GetFields");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetHashCode(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    int hashCode = LuaScriptMgr.GetTypeObject(L, 1).GetHashCode();
    LuaScriptMgr.Push(L, hashCode);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetMember(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        MemberInfo[] member1 = LuaScriptMgr.GetTypeObject(L, 1).GetMember(LuaScriptMgr.GetLuaString(L, 2));
        LuaScriptMgr.PushArray(L, (Array) member1);
        return 1;
      case 3:
        MemberInfo[] member2 = LuaScriptMgr.GetTypeObject(L, 1).GetMember(LuaScriptMgr.GetLuaString(L, 2), (BindingFlags) LuaScriptMgr.GetNetObject(L, 3, typeof (BindingFlags)));
        LuaScriptMgr.PushArray(L, (Array) member2);
        return 1;
      case 4:
        MemberInfo[] member3 = LuaScriptMgr.GetTypeObject(L, 1).GetMember(LuaScriptMgr.GetLuaString(L, 2), (MemberTypes) LuaScriptMgr.GetNetObject(L, 3, typeof (MemberTypes)), (BindingFlags) LuaScriptMgr.GetNetObject(L, 4, typeof (BindingFlags)));
        LuaScriptMgr.PushArray(L, (Array) member3);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Type.GetMember");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetMembers(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        MemberInfo[] members1 = LuaScriptMgr.GetTypeObject(L, 1).GetMembers();
        LuaScriptMgr.PushArray(L, (Array) members1);
        return 1;
      case 2:
        MemberInfo[] members2 = LuaScriptMgr.GetTypeObject(L, 1).GetMembers((BindingFlags) LuaScriptMgr.GetNetObject(L, 2, typeof (BindingFlags)));
        LuaScriptMgr.PushArray(L, (Array) members2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Type.GetMembers");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetMethod(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 2)
    {
      MethodInfo method = LuaScriptMgr.GetTypeObject(L, 1).GetMethod(LuaScriptMgr.GetLuaString(L, 2));
      LuaScriptMgr.PushObject(L, (object) method);
      return 1;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (System.Type), typeof (string), typeof (System.Type[])))
    {
      MethodInfo method = LuaScriptMgr.GetTypeObject(L, 1).GetMethod(LuaScriptMgr.GetString(L, 2), LuaScriptMgr.GetArrayObject<System.Type>(L, 3));
      LuaScriptMgr.PushObject(L, (object) method);
      return 1;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (System.Type), typeof (string), typeof (BindingFlags)))
    {
      MethodInfo method = LuaScriptMgr.GetTypeObject(L, 1).GetMethod(LuaScriptMgr.GetString(L, 2), (BindingFlags) LuaScriptMgr.GetLuaObject(L, 3));
      LuaScriptMgr.PushObject(L, (object) method);
      return 1;
    }
    switch (num)
    {
      case 4:
        MethodInfo method1 = LuaScriptMgr.GetTypeObject(L, 1).GetMethod(LuaScriptMgr.GetLuaString(L, 2), LuaScriptMgr.GetArrayObject<System.Type>(L, 3), LuaScriptMgr.GetArrayObject<ParameterModifier>(L, 4));
        LuaScriptMgr.PushObject(L, (object) method1);
        return 1;
      case 6:
        MethodInfo method2 = LuaScriptMgr.GetTypeObject(L, 1).GetMethod(LuaScriptMgr.GetLuaString(L, 2), (BindingFlags) LuaScriptMgr.GetNetObject(L, 3, typeof (BindingFlags)), (Binder) LuaScriptMgr.GetNetObject(L, 4, typeof (Binder)), LuaScriptMgr.GetArrayObject<System.Type>(L, 5), LuaScriptMgr.GetArrayObject<ParameterModifier>(L, 6));
        LuaScriptMgr.PushObject(L, (object) method2);
        return 1;
      case 7:
        MethodInfo method3 = LuaScriptMgr.GetTypeObject(L, 1).GetMethod(LuaScriptMgr.GetLuaString(L, 2), (BindingFlags) LuaScriptMgr.GetNetObject(L, 3, typeof (BindingFlags)), (Binder) LuaScriptMgr.GetNetObject(L, 4, typeof (Binder)), (CallingConventions) LuaScriptMgr.GetNetObject(L, 5, typeof (CallingConventions)), LuaScriptMgr.GetArrayObject<System.Type>(L, 6), LuaScriptMgr.GetArrayObject<ParameterModifier>(L, 7));
        LuaScriptMgr.PushObject(L, (object) method3);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Type.GetMethod");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetMethods(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        MethodInfo[] methods1 = LuaScriptMgr.GetTypeObject(L, 1).GetMethods();
        LuaScriptMgr.PushArray(L, (Array) methods1);
        return 1;
      case 2:
        MethodInfo[] methods2 = LuaScriptMgr.GetTypeObject(L, 1).GetMethods((BindingFlags) LuaScriptMgr.GetNetObject(L, 2, typeof (BindingFlags)));
        LuaScriptMgr.PushArray(L, (Array) methods2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Type.GetMethods");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetNestedType(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        System.Type nestedType1 = LuaScriptMgr.GetTypeObject(L, 1).GetNestedType(LuaScriptMgr.GetLuaString(L, 2));
        LuaScriptMgr.Push(L, nestedType1);
        return 1;
      case 3:
        System.Type nestedType2 = LuaScriptMgr.GetTypeObject(L, 1).GetNestedType(LuaScriptMgr.GetLuaString(L, 2), (BindingFlags) LuaScriptMgr.GetNetObject(L, 3, typeof (BindingFlags)));
        LuaScriptMgr.Push(L, nestedType2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Type.GetNestedType");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetNestedTypes(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        System.Type[] nestedTypes1 = LuaScriptMgr.GetTypeObject(L, 1).GetNestedTypes();
        LuaScriptMgr.PushArray(L, (Array) nestedTypes1);
        return 1;
      case 2:
        System.Type[] nestedTypes2 = LuaScriptMgr.GetTypeObject(L, 1).GetNestedTypes((BindingFlags) LuaScriptMgr.GetNetObject(L, 2, typeof (BindingFlags)));
        LuaScriptMgr.PushArray(L, (Array) nestedTypes2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Type.GetNestedTypes");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetProperties(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        PropertyInfo[] properties1 = LuaScriptMgr.GetTypeObject(L, 1).GetProperties();
        LuaScriptMgr.PushArray(L, (Array) properties1);
        return 1;
      case 2:
        PropertyInfo[] properties2 = LuaScriptMgr.GetTypeObject(L, 1).GetProperties((BindingFlags) LuaScriptMgr.GetNetObject(L, 2, typeof (BindingFlags)));
        LuaScriptMgr.PushArray(L, (Array) properties2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Type.GetProperties");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetProperty(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 2)
    {
      PropertyInfo property = LuaScriptMgr.GetTypeObject(L, 1).GetProperty(LuaScriptMgr.GetLuaString(L, 2));
      LuaScriptMgr.PushObject(L, (object) property);
      return 1;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (System.Type), typeof (string), typeof (System.Type[])))
    {
      PropertyInfo property = LuaScriptMgr.GetTypeObject(L, 1).GetProperty(LuaScriptMgr.GetString(L, 2), LuaScriptMgr.GetArrayObject<System.Type>(L, 3));
      LuaScriptMgr.PushObject(L, (object) property);
      return 1;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (System.Type), typeof (string), typeof (System.Type)))
    {
      PropertyInfo property = LuaScriptMgr.GetTypeObject(L, 1).GetProperty(LuaScriptMgr.GetString(L, 2), LuaScriptMgr.GetTypeObject(L, 3));
      LuaScriptMgr.PushObject(L, (object) property);
      return 1;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (System.Type), typeof (string), typeof (BindingFlags)))
    {
      PropertyInfo property = LuaScriptMgr.GetTypeObject(L, 1).GetProperty(LuaScriptMgr.GetString(L, 2), (BindingFlags) LuaScriptMgr.GetLuaObject(L, 3));
      LuaScriptMgr.PushObject(L, (object) property);
      return 1;
    }
    switch (num)
    {
      case 4:
        PropertyInfo property1 = LuaScriptMgr.GetTypeObject(L, 1).GetProperty(LuaScriptMgr.GetLuaString(L, 2), LuaScriptMgr.GetTypeObject(L, 3), LuaScriptMgr.GetArrayObject<System.Type>(L, 4));
        LuaScriptMgr.PushObject(L, (object) property1);
        return 1;
      case 5:
        PropertyInfo property2 = LuaScriptMgr.GetTypeObject(L, 1).GetProperty(LuaScriptMgr.GetLuaString(L, 2), LuaScriptMgr.GetTypeObject(L, 3), LuaScriptMgr.GetArrayObject<System.Type>(L, 4), LuaScriptMgr.GetArrayObject<ParameterModifier>(L, 5));
        LuaScriptMgr.PushObject(L, (object) property2);
        return 1;
      case 7:
        PropertyInfo property3 = LuaScriptMgr.GetTypeObject(L, 1).GetProperty(LuaScriptMgr.GetLuaString(L, 2), (BindingFlags) LuaScriptMgr.GetNetObject(L, 3, typeof (BindingFlags)), (Binder) LuaScriptMgr.GetNetObject(L, 4, typeof (Binder)), LuaScriptMgr.GetTypeObject(L, 5), LuaScriptMgr.GetArrayObject<System.Type>(L, 6), LuaScriptMgr.GetArrayObject<ParameterModifier>(L, 7));
        LuaScriptMgr.PushObject(L, (object) property3);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Type.GetProperty");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetConstructor(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        ConstructorInfo constructor1 = LuaScriptMgr.GetTypeObject(L, 1).GetConstructor(LuaScriptMgr.GetArrayObject<System.Type>(L, 2));
        LuaScriptMgr.PushObject(L, (object) constructor1);
        return 1;
      case 5:
        ConstructorInfo constructor2 = LuaScriptMgr.GetTypeObject(L, 1).GetConstructor((BindingFlags) LuaScriptMgr.GetNetObject(L, 2, typeof (BindingFlags)), (Binder) LuaScriptMgr.GetNetObject(L, 3, typeof (Binder)), LuaScriptMgr.GetArrayObject<System.Type>(L, 4), LuaScriptMgr.GetArrayObject<ParameterModifier>(L, 5));
        LuaScriptMgr.PushObject(L, (object) constructor2);
        return 1;
      case 6:
        ConstructorInfo constructor3 = LuaScriptMgr.GetTypeObject(L, 1).GetConstructor((BindingFlags) LuaScriptMgr.GetNetObject(L, 2, typeof (BindingFlags)), (Binder) LuaScriptMgr.GetNetObject(L, 3, typeof (Binder)), (CallingConventions) LuaScriptMgr.GetNetObject(L, 4, typeof (CallingConventions)), LuaScriptMgr.GetArrayObject<System.Type>(L, 5), LuaScriptMgr.GetArrayObject<ParameterModifier>(L, 6));
        LuaScriptMgr.PushObject(L, (object) constructor3);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Type.GetConstructor");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetConstructors(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        ConstructorInfo[] constructors1 = LuaScriptMgr.GetTypeObject(L, 1).GetConstructors();
        LuaScriptMgr.PushArray(L, (Array) constructors1);
        return 1;
      case 2:
        ConstructorInfo[] constructors2 = LuaScriptMgr.GetTypeObject(L, 1).GetConstructors((BindingFlags) LuaScriptMgr.GetNetObject(L, 2, typeof (BindingFlags)));
        LuaScriptMgr.PushArray(L, (Array) constructors2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Type.GetConstructors");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetDefaultMembers(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    MemberInfo[] defaultMembers = LuaScriptMgr.GetTypeObject(L, 1).GetDefaultMembers();
    LuaScriptMgr.PushArray(L, (Array) defaultMembers);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int FindMembers(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 5);
    System.Type typeObject = LuaScriptMgr.GetTypeObject(L, 1);
    MemberTypes netObject1 = (MemberTypes) LuaScriptMgr.GetNetObject(L, 2, typeof (MemberTypes));
    BindingFlags netObject2 = (BindingFlags) LuaScriptMgr.GetNetObject(L, 3, typeof (BindingFlags));
    MemberFilter filter;
    if (LuaDLL.lua_type(L, 4) != LuaTypes.LUA_TFUNCTION)
    {
      filter = (MemberFilter) LuaScriptMgr.GetNetObject(L, 4, typeof (MemberFilter));
    }
    else
    {
      LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 4);
      filter = (MemberFilter) ((param0, param1) =>
      {
        int oldTop = func.BeginPCall();
        LuaScriptMgr.PushObject(L, (object) param0);
        LuaScriptMgr.PushVarObject(L, param1);
        func.PCall(oldTop, 2);
        object[] objArray = func.PopValues(oldTop);
        func.EndPCall(oldTop);
        return (bool) objArray[0];
      });
    }
    object varObject = LuaScriptMgr.GetVarObject(L, 5);
    MemberInfo[] members = typeObject.FindMembers(netObject1, netObject2, filter, varObject);
    LuaScriptMgr.PushArray(L, (Array) members);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int InvokeMember(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 6:
        object o1 = LuaScriptMgr.GetTypeObject(L, 1).InvokeMember(LuaScriptMgr.GetLuaString(L, 2), (BindingFlags) LuaScriptMgr.GetNetObject(L, 3, typeof (BindingFlags)), (Binder) LuaScriptMgr.GetNetObject(L, 4, typeof (Binder)), LuaScriptMgr.GetVarObject(L, 5), LuaScriptMgr.GetArrayObject<object>(L, 6));
        LuaScriptMgr.PushVarObject(L, o1);
        return 1;
      case 7:
        object o2 = LuaScriptMgr.GetTypeObject(L, 1).InvokeMember(LuaScriptMgr.GetLuaString(L, 2), (BindingFlags) LuaScriptMgr.GetNetObject(L, 3, typeof (BindingFlags)), (Binder) LuaScriptMgr.GetNetObject(L, 4, typeof (Binder)), LuaScriptMgr.GetVarObject(L, 5), LuaScriptMgr.GetArrayObject<object>(L, 6), (CultureInfo) LuaScriptMgr.GetNetObject(L, 7, typeof (CultureInfo)));
        LuaScriptMgr.PushVarObject(L, o2);
        return 1;
      case 9:
        object o3 = LuaScriptMgr.GetTypeObject(L, 1).InvokeMember(LuaScriptMgr.GetLuaString(L, 2), (BindingFlags) LuaScriptMgr.GetNetObject(L, 3, typeof (BindingFlags)), (Binder) LuaScriptMgr.GetNetObject(L, 4, typeof (Binder)), LuaScriptMgr.GetVarObject(L, 5), LuaScriptMgr.GetArrayObject<object>(L, 6), LuaScriptMgr.GetArrayObject<ParameterModifier>(L, 7), (CultureInfo) LuaScriptMgr.GetNetObject(L, 8, typeof (CultureInfo)), LuaScriptMgr.GetArrayString(L, 9));
        LuaScriptMgr.PushVarObject(L, o3);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Type.InvokeMember");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int ToString(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    string str = LuaScriptMgr.GetTypeObject(L, 1).ToString();
    LuaScriptMgr.Push(L, str);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetGenericArguments(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    System.Type[] genericArguments = LuaScriptMgr.GetTypeObject(L, 1).GetGenericArguments();
    LuaScriptMgr.PushArray(L, (Array) genericArguments);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetGenericTypeDefinition(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    System.Type genericTypeDefinition = LuaScriptMgr.GetTypeObject(L, 1).GetGenericTypeDefinition();
    LuaScriptMgr.Push(L, genericTypeDefinition);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int MakeGenericType(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    System.Type o = LuaScriptMgr.GetTypeObject(L, 1).MakeGenericType(LuaScriptMgr.GetParamsObject<System.Type>(L, 2, num - 1));
    LuaScriptMgr.Push(L, o);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetGenericParameterConstraints(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    System.Type[] parameterConstraints = LuaScriptMgr.GetTypeObject(L, 1).GetGenericParameterConstraints();
    LuaScriptMgr.PushArray(L, (Array) parameterConstraints);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int MakeArrayType(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        System.Type o1 = LuaScriptMgr.GetTypeObject(L, 1).MakeArrayType();
        LuaScriptMgr.Push(L, o1);
        return 1;
      case 2:
        System.Type o2 = LuaScriptMgr.GetTypeObject(L, 1).MakeArrayType((int) LuaScriptMgr.GetNumber(L, 2));
        LuaScriptMgr.Push(L, o2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Type.MakeArrayType");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int MakeByRefType(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    System.Type o = LuaScriptMgr.GetTypeObject(L, 1).MakeByRefType();
    LuaScriptMgr.Push(L, o);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int MakePointerType(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    System.Type o = LuaScriptMgr.GetTypeObject(L, 1).MakePointerType();
    LuaScriptMgr.Push(L, o);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int ReflectionOnlyGetType(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 3);
    System.Type type = System.Type.ReflectionOnlyGetType(LuaScriptMgr.GetLuaString(L, 1), LuaScriptMgr.GetBoolean(L, 2), LuaScriptMgr.GetBoolean(L, 3));
    LuaScriptMgr.Push(L, type);
    return 1;
  }
}
