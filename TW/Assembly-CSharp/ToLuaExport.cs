// Decompiled with JetBrains decompiler
// Type: ToLuaExport
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using UnityEngine;

#nullable disable
public static class ToLuaExport
{
  public static string className = string.Empty;
  public static System.Type type = (System.Type) null;
  public static string baseClassName = (string) null;
  public static bool isStaticClass = true;
  private static HashSet<string> usingList = new HashSet<string>();
  private static MetaOp op = MetaOp.None;
  private static StringBuilder sb = (StringBuilder) null;
  private static MethodInfo[] methods = (MethodInfo[]) null;
  private static Dictionary<string, int> nameCounter = (Dictionary<string, int>) null;
  private static FieldInfo[] fields = (FieldInfo[]) null;
  private static PropertyInfo[] props = (PropertyInfo[]) null;
  private static List<PropertyInfo> propList = new List<PropertyInfo>();
  private static BindingFlags binding = BindingFlags.IgnoreCase | BindingFlags.Static | BindingFlags.Public;
  private static ObjAmbig ambig = ObjAmbig.NetObj;
  public static string wrapClassName = string.Empty;
  public static string libClassName = string.Empty;
  public static string extendName = string.Empty;
  public static System.Type extendType = (System.Type) null;
  public static HashSet<System.Type> eventSet = new HashSet<System.Type>();
  public static List<string> memberFilter = new List<string>()
  {
    "AnimationClip.averageDuration",
    "AnimationClip.averageAngularSpeed",
    "AnimationClip.averageSpeed",
    "AnimationClip.apparentSpeed",
    "AnimationClip.isLooping",
    "AnimationClip.isAnimatorMotion",
    "AnimationClip.isHumanMotion",
    "AnimatorOverrideController.PerformOverrideClipListCleanup",
    "Caching.SetNoBackupFlag",
    "Caching.ResetNoBackupFlag",
    "Light.areaSize",
    "Security.GetChainOfTrustValue",
    "Texture2D.alphaIsTransparency",
    "WWW.movie",
    "WebCamTexture.MarkNonReadable",
    "WebCamTexture.isReadable",
    "Graphic.OnRebuildRequested",
    "Text.OnRebuildRequested",
    "UIInput.ProcessEvent",
    "UIWidget.showHandlesWithMoveTool",
    "UIWidget.showHandles",
    "Application.ExternalEval",
    "Resources.LoadAssetAtPath",
    "Input.IsJoystickPreconfigured",
    "String.Chars"
  };
  private static Dictionary<System.Type, int> typeSize = new Dictionary<System.Type, int>()
  {
    {
      typeof (bool),
      1
    },
    {
      typeof (char),
      2
    },
    {
      typeof (byte),
      3
    },
    {
      typeof (sbyte),
      4
    },
    {
      typeof (ushort),
      5
    },
    {
      typeof (short),
      6
    },
    {
      typeof (uint),
      7
    },
    {
      typeof (int),
      8
    },
    {
      typeof (float),
      9
    },
    {
      typeof (ulong),
      10
    },
    {
      typeof (long),
      11
    },
    {
      typeof (double),
      12
    }
  };

  public static bool IsMemberFilter(MemberInfo mi)
  {
    return ToLuaExport.memberFilter.Contains(ToLuaExport.type.Name + "." + mi.Name);
  }

  public static void Clear()
  {
    ToLuaExport.className = (string) null;
    ToLuaExport.type = (System.Type) null;
    ToLuaExport.isStaticClass = false;
    ToLuaExport.baseClassName = (string) null;
    ToLuaExport.usingList.Clear();
    ToLuaExport.op = MetaOp.None;
    ToLuaExport.sb = new StringBuilder();
    ToLuaExport.methods = (MethodInfo[]) null;
    ToLuaExport.fields = (FieldInfo[]) null;
    ToLuaExport.props = (PropertyInfo[]) null;
    ToLuaExport.propList.Clear();
    ToLuaExport.ambig = ObjAmbig.NetObj;
    ToLuaExport.wrapClassName = string.Empty;
    ToLuaExport.libClassName = string.Empty;
  }

  private static MetaOp GetOp(string name)
  {
    switch (name)
    {
      case "op_Addition":
        return MetaOp.Add;
      case "op_Subtraction":
        return MetaOp.Sub;
      case "op_Equality":
        return MetaOp.Eq;
      case "op_Multiply":
        return MetaOp.Mul;
      case "op_Division":
        return MetaOp.Div;
      case "op_UnaryNegation":
        return MetaOp.Neg;
      default:
        return MetaOp.None;
    }
  }

  private static void GenBaseOpFunction(List<MethodInfo> list)
  {
    for (System.Type baseType = ToLuaExport.type.BaseType; (object) baseType != null; baseType = baseType.BaseType)
    {
      MethodInfo[] methods = baseType.GetMethods(BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
      for (int index = 0; index < methods.Length; ++index)
      {
        MetaOp op = ToLuaExport.GetOp(methods[index].Name);
        if (op != MetaOp.None && (ToLuaExport.op & op) == MetaOp.None)
        {
          list.Add(methods[index]);
          ToLuaExport.op |= op;
        }
      }
    }
  }

  public static void Generate(params string[] param)
  {
    Debugger.Log("Begin Generate lua Wrap for class {0}\r\n", (object) ToLuaExport.className);
    ToLuaExport.sb = new StringBuilder();
    ToLuaExport.usingList.Add("System");
    ToLuaExport.GetTypeStr(ToLuaExport.type);
    if (ToLuaExport.wrapClassName == string.Empty)
      ToLuaExport.wrapClassName = ToLuaExport.className;
    if (ToLuaExport.libClassName == string.Empty)
      ToLuaExport.libClassName = ToLuaExport.className;
    if (ToLuaExport.type.IsEnum)
    {
      ToLuaExport.GenEnum();
      ToLuaExport.GenEnumTranslator();
      ToLuaExport.sb.AppendLine("}\r\n");
      ToLuaExport.SaveFile(AppConst.uLuaPath + "/Source/LuaWrap/" + ToLuaExport.wrapClassName + "Wrap.cs");
    }
    else
    {
      ToLuaExport.nameCounter = new Dictionary<string, int>();
      List<MethodInfo> list = new List<MethodInfo>();
      if (ToLuaExport.baseClassName != null)
        ToLuaExport.binding |= BindingFlags.DeclaredOnly;
      else if (ToLuaExport.baseClassName == null && ToLuaExport.isStaticClass)
        ToLuaExport.binding |= BindingFlags.DeclaredOnly;
      if (ToLuaExport.type.IsInterface)
      {
        list.AddRange((IEnumerable<MethodInfo>) ToLuaExport.type.GetMethods());
      }
      else
      {
        list.AddRange((IEnumerable<MethodInfo>) ToLuaExport.type.GetMethods(BindingFlags.Instance | ToLuaExport.binding));
        for (int index = list.Count - 1; index >= 0; --index)
        {
          if (list[index].Name.Contains("op_") || list[index].Name.Contains("add_") || list[index].Name.Contains("remove_"))
          {
            if (!ToLuaExport.IsNeedOp(list[index].Name))
              list.RemoveAt(index);
          }
          else if (ToLuaExport.IsObsolete((MemberInfo) list[index]))
            list.RemoveAt(index);
        }
      }
      PropertyInfo[] ps = ToLuaExport.type.GetProperties();
      for (int i = 0; i < ps.Length; ++i)
      {
        int index1 = list.FindIndex((Predicate<MethodInfo>) (m => m.Name == "get_" + ps[i].Name));
        if (index1 >= 0 && list[index1].Name != "get_Item")
          list.RemoveAt(index1);
        int index2 = list.FindIndex((Predicate<MethodInfo>) (m => m.Name == "set_" + ps[i].Name));
        if (index2 >= 0 && list[index2].Name != "set_Item")
          list.RemoveAt(index2);
      }
      ToLuaExport.ProcessExtends(list);
      ToLuaExport.GenBaseOpFunction(list);
      ToLuaExport.methods = list.ToArray();
      ToLuaExport.sb.AppendFormat("public class {0}Wrap\r\n", (object) ToLuaExport.wrapClassName);
      ToLuaExport.sb.AppendLine("{");
      ToLuaExport.GenRegFunc();
      ToLuaExport.GenConstruct();
      ToLuaExport.GenGetType();
      ToLuaExport.GenIndexFunc();
      ToLuaExport.GenNewIndexFunc();
      ToLuaExport.GenToStringFunc();
      ToLuaExport.GenFunction();
      ToLuaExport.sb.AppendLine("}\r\n");
      string path = AppConst.uLuaPath + "/Source/LuaWrap/";
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);
      ToLuaExport.SaveFile(path + ToLuaExport.wrapClassName + "Wrap.cs");
    }
  }

  private static void SaveFile(string file)
  {
    using (StreamWriter streamWriter = new StreamWriter(file, false, Encoding.UTF8))
    {
      StringBuilder stringBuilder = new StringBuilder();
      foreach (string str in ToLuaExport.usingList)
        stringBuilder.AppendFormat("using {0};\r\n", (object) str);
      stringBuilder.AppendLine("using LuaInterface;");
      if (ToLuaExport.ambig == ObjAmbig.All)
        stringBuilder.AppendLine("using Object = UnityEngine.Object;");
      stringBuilder.AppendLine();
      streamWriter.Write(stringBuilder.ToString());
      streamWriter.Write(ToLuaExport.sb.ToString());
      streamWriter.Flush();
      streamWriter.Close();
    }
  }

  private static void GenLuaFields()
  {
    ToLuaExport.fields = ToLuaExport.type.GetFields(BindingFlags.Instance | BindingFlags.GetField | BindingFlags.SetField | ToLuaExport.binding);
    ToLuaExport.props = ToLuaExport.type.GetProperties(BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.SetProperty | ToLuaExport.binding);
    ToLuaExport.propList.AddRange((IEnumerable<PropertyInfo>) ToLuaExport.type.GetProperties(BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.SetProperty));
    List<FieldInfo> fieldInfoList = new List<FieldInfo>();
    fieldInfoList.AddRange((IEnumerable<FieldInfo>) ToLuaExport.fields);
    for (int index = fieldInfoList.Count - 1; index >= 0; --index)
    {
      if (ToLuaExport.IsObsolete((MemberInfo) fieldInfoList[index]))
        fieldInfoList.RemoveAt(index);
    }
    ToLuaExport.fields = fieldInfoList.ToArray();
    List<PropertyInfo> propertyInfoList = new List<PropertyInfo>();
    propertyInfoList.AddRange((IEnumerable<PropertyInfo>) ToLuaExport.props);
    for (int index = propertyInfoList.Count - 1; index >= 0; --index)
    {
      if (propertyInfoList[index].Name == "Item" || ToLuaExport.IsObsolete((MemberInfo) propertyInfoList[index]))
        propertyInfoList.RemoveAt(index);
    }
    ToLuaExport.props = propertyInfoList.ToArray();
    for (int index = ToLuaExport.propList.Count - 1; index >= 0; --index)
    {
      if (ToLuaExport.propList[index].Name == "Item" || ToLuaExport.IsObsolete((MemberInfo) ToLuaExport.propList[index]))
        ToLuaExport.propList.RemoveAt(index);
    }
    if (ToLuaExport.fields.Length == 0 && ToLuaExport.props.Length == 0 && ToLuaExport.isStaticClass && ToLuaExport.baseClassName == null)
      return;
    ToLuaExport.sb.AppendLine("\t\tLuaField[] fields = new LuaField[]");
    ToLuaExport.sb.AppendLine("\t\t{");
    for (int index = 0; index < ToLuaExport.fields.Length; ++index)
    {
      if (ToLuaExport.fields[index].IsLiteral || ToLuaExport.fields[index].IsPrivate || ToLuaExport.fields[index].IsInitOnly)
        ToLuaExport.sb.AppendFormat("\t\t\tnew LuaField(\"{0}\", get_{0}, null),\r\n", (object) ToLuaExport.fields[index].Name);
      else
        ToLuaExport.sb.AppendFormat("\t\t\tnew LuaField(\"{0}\", get_{0}, set_{0}),\r\n", (object) ToLuaExport.fields[index].Name);
    }
    for (int index = 0; index < ToLuaExport.props.Length; ++index)
    {
      if (ToLuaExport.props[index].CanRead && ToLuaExport.props[index].CanWrite && ToLuaExport.props[index].GetSetMethod(true).IsPublic)
        ToLuaExport.sb.AppendFormat("\t\t\tnew LuaField(\"{0}\", get_{0}, set_{0}),\r\n", (object) ToLuaExport.props[index].Name);
      else if (ToLuaExport.props[index].CanRead)
        ToLuaExport.sb.AppendFormat("\t\t\tnew LuaField(\"{0}\", get_{0}, null),\r\n", (object) ToLuaExport.props[index].Name);
      else if (ToLuaExport.props[index].CanWrite)
        ToLuaExport.sb.AppendFormat("\t\t\tnew LuaField(\"{0}\", null, set_{0}),\r\n", (object) ToLuaExport.props[index].Name);
    }
    ToLuaExport.sb.AppendLine("\t\t};\r\n");
  }

  private static void GenLuaMethods()
  {
    ToLuaExport.sb.AppendLine("\t\tLuaMethod[] regs = new LuaMethod[]");
    ToLuaExport.sb.AppendLine("\t\t{");
    for (int index = 0; index < ToLuaExport.methods.Length; ++index)
    {
      MethodInfo method = ToLuaExport.methods[index];
      int num = 1;
      if (!method.IsGenericMethod)
      {
        if (!ToLuaExport.nameCounter.TryGetValue(method.Name, out num))
        {
          if (!method.Name.Contains("op_"))
            ToLuaExport.sb.AppendFormat("\t\t\tnew LuaMethod(\"{0}\", {0}),\r\n", (object) method.Name);
          ToLuaExport.nameCounter[method.Name] = 1;
        }
        else
          ToLuaExport.nameCounter[method.Name] = num + 1;
      }
    }
    ToLuaExport.sb.AppendFormat("\t\t\tnew LuaMethod(\"New\", _Create{0}),\r\n", (object) ToLuaExport.wrapClassName);
    ToLuaExport.sb.AppendLine("\t\t\tnew LuaMethod(\"GetClassType\", GetClassType),");
    if (Array.FindIndex<MethodInfo>(ToLuaExport.methods, (Predicate<MethodInfo>) (p => p.Name == "ToString")) >= 0 && !ToLuaExport.isStaticClass)
      ToLuaExport.sb.AppendLine("\t\t\tnew LuaMethod(\"__tostring\", Lua_ToString),");
    ToLuaExport.GenOperatorReg();
    ToLuaExport.sb.AppendLine("\t\t};\r\n");
  }

  private static void GenOperatorReg()
  {
    if ((ToLuaExport.op & MetaOp.Add) != MetaOp.None)
      ToLuaExport.sb.AppendLine("\t\t\tnew LuaMethod(\"__add\", Lua_Add),");
    if ((ToLuaExport.op & MetaOp.Sub) != MetaOp.None)
      ToLuaExport.sb.AppendLine("\t\t\tnew LuaMethod(\"__sub\", Lua_Sub),");
    if ((ToLuaExport.op & MetaOp.Mul) != MetaOp.None)
      ToLuaExport.sb.AppendLine("\t\t\tnew LuaMethod(\"__mul\", Lua_Mul),");
    if ((ToLuaExport.op & MetaOp.Div) != MetaOp.None)
      ToLuaExport.sb.AppendLine("\t\t\tnew LuaMethod(\"__div\", Lua_Div),");
    if ((ToLuaExport.op & MetaOp.Eq) != MetaOp.None)
      ToLuaExport.sb.AppendLine("\t\t\tnew LuaMethod(\"__eq\", Lua_Eq),");
    if ((ToLuaExport.op & MetaOp.Neg) == MetaOp.None)
      return;
    ToLuaExport.sb.AppendLine("\t\t\tnew LuaMethod(\"__unm\", Lua_Neg),");
  }

  private static void GenRegFunc()
  {
    ToLuaExport.sb.AppendLine("\tpublic static void Register(IntPtr L)");
    ToLuaExport.sb.AppendLine("\t{");
    ToLuaExport.GenLuaMethods();
    ToLuaExport.GenLuaFields();
    if (ToLuaExport.baseClassName == null)
    {
      if (ToLuaExport.isStaticClass && ToLuaExport.fields.Length == 0 && ToLuaExport.props.Length == 0)
        ToLuaExport.sb.AppendFormat("\t\tLuaScriptMgr.RegisterLib(L, \"{0}\", regs);\r\n", (object) ToLuaExport.libClassName);
      else
        ToLuaExport.sb.AppendFormat("\t\tLuaScriptMgr.RegisterLib(L, \"{0}\", typeof({1}), regs, fields, null);\r\n", (object) ToLuaExport.libClassName, (object) ToLuaExport.className);
    }
    else
      ToLuaExport.sb.AppendFormat("\t\tLuaScriptMgr.RegisterLib(L, \"{0}\", typeof({1}), regs, fields, typeof({2}));\r\n", (object) ToLuaExport.libClassName, (object) ToLuaExport.className, (object) ToLuaExport.baseClassName);
    ToLuaExport.sb.AppendLine("\t}");
  }

  private static bool IsParams(ParameterInfo param)
  {
    return param.GetCustomAttributes(typeof (ParamArrayAttribute), false).Length > 0;
  }

  private static void GenFunction()
  {
    HashSet<string> stringSet = new HashSet<string>();
    for (int index = 0; index < ToLuaExport.methods.Length; ++index)
    {
      MethodInfo methodInfo1 = ToLuaExport.methods[index];
      if (methodInfo1.IsGenericMethod)
      {
        Debugger.Log("Generic Method {0} cannot be export to lua", (object) methodInfo1.Name);
      }
      else
      {
        if (ToLuaExport.nameCounter[methodInfo1.Name] > 1)
        {
          if (!stringSet.Contains(methodInfo1.Name))
          {
            MethodInfo methodInfo2 = ToLuaExport.GenOverrideFunc(methodInfo1.Name);
            if ((object) methodInfo2 == null)
            {
              stringSet.Add(methodInfo1.Name);
              continue;
            }
            methodInfo1 = methodInfo2;
          }
          else
            continue;
        }
        stringSet.Add(methodInfo1.Name);
        ToLuaExport.sb.AppendLine("\r\n\t[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
        ToLuaExport.sb.AppendFormat("\tstatic int {0}(IntPtr L)\r\n", (object) ToLuaExport.GetFuncName(methodInfo1.Name));
        ToLuaExport.sb.AppendLine("\t{");
        if (ToLuaExport.HasAttribute((MemberInfo) methodInfo1, typeof (OnlyGCAttribute)))
        {
          ToLuaExport.sb.AppendLine("\t\tLuaScriptMgr.__gc(L);");
          ToLuaExport.sb.AppendLine("\t\treturn 0;");
          ToLuaExport.sb.AppendLine("\t}");
        }
        else if (ToLuaExport.HasAttribute((MemberInfo) methodInfo1, typeof (UseDefinedAttribute)))
        {
          string str = ToLuaExport.extendType.GetField(methodInfo1.Name + "Defined").GetValue((object) null) as string;
          ToLuaExport.sb.AppendLine(str);
          ToLuaExport.sb.AppendLine("\t}");
        }
        else
        {
          ParameterInfo[] parameters = methodInfo1.GetParameters();
          int num1 = !methodInfo1.IsStatic ? 2 : 1;
          if (!ToLuaExport.HasOptionalParam(parameters))
          {
            int num2 = parameters.Length + num1 - 1;
            ToLuaExport.sb.AppendFormat("\t\tLuaScriptMgr.CheckArgsCount(L, {0});\r\n", (object) num2);
          }
          else
            ToLuaExport.sb.AppendLine("\t\tint count = LuaDLL.lua_gettop(L);");
          int num3 = ((object) methodInfo1.ReturnType != (object) typeof (void) ? 1 : 0) + ToLuaExport.ProcessParams((MethodBase) methodInfo1, 2, false, false);
          ToLuaExport.sb.AppendFormat("\t\treturn {0};\r\n", (object) num3);
          ToLuaExport.sb.AppendLine("\t}");
        }
      }
    }
  }

  private static void NoConsturct()
  {
    ToLuaExport.sb.AppendLine("\r\n\t[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
    ToLuaExport.sb.AppendFormat("\tstatic int _Create{0}(IntPtr L)\r\n", (object) ToLuaExport.wrapClassName);
    ToLuaExport.sb.AppendLine("\t{");
    ToLuaExport.sb.AppendFormat("\t\tLuaDLL.luaL_error(L, \"{0} class does not have a constructor function\");\r\n", (object) ToLuaExport.className);
    ToLuaExport.sb.AppendLine("\t\treturn 0;");
    ToLuaExport.sb.AppendLine("\t}");
  }

  private static string GetPushFunction(System.Type t)
  {
    if (t.IsEnum || (object) t == (object) typeof (bool) || t.IsPrimitive || (object) t == (object) typeof (string) || (object) t == (object) typeof (LuaTable) || (object) t == (object) typeof (LuaCSFunction) || (object) t == (object) typeof (LuaFunction) || typeof (Object).IsAssignableFrom(t) || (object) t == (object) typeof (System.Type) || (object) t == (object) typeof (IntPtr) || typeof (Delegate).IsAssignableFrom(t) || (object) t == (object) typeof (LuaStringBuffer) || typeof (TrackedReference).IsAssignableFrom(t) || typeof (IEnumerator).IsAssignableFrom(t) || (object) t == (object) typeof (Vector3) || (object) t == (object) typeof (Vector2) || (object) t == (object) typeof (Vector4) || (object) t == (object) typeof (Quaternion) || (object) t == (object) typeof (Color) || (object) t == (object) typeof (RaycastHit) || (object) t == (object) typeof (Ray) || (object) t == (object) typeof (Touch) || (object) t == (object) typeof (Bounds))
      return "Push";
    if ((object) t == (object) typeof (object))
      return "PushVarObject";
    if (t.IsValueType)
      return "PushValue";
    return t.IsArray ? "PushArray" : "PushObject";
  }

  private static void DefaultConstruct()
  {
    ToLuaExport.sb.AppendLine("\r\n\t[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
    ToLuaExport.sb.AppendFormat("\tstatic int _Create{0}(IntPtr L)\r\n", (object) ToLuaExport.wrapClassName);
    ToLuaExport.sb.AppendLine("\t{");
    ToLuaExport.sb.AppendLine("\t\tLuaScriptMgr.CheckArgsCount(L, 0);");
    ToLuaExport.sb.AppendFormat("\t\t{0} obj = new {0}();\r\n", (object) ToLuaExport.className);
    string pushFunction = ToLuaExport.GetPushFunction(ToLuaExport.type);
    ToLuaExport.sb.AppendFormat("\t\tLuaScriptMgr.{0}(L, obj);\r\n", (object) pushFunction);
    ToLuaExport.sb.AppendLine("\t\treturn 1;");
    ToLuaExport.sb.AppendLine("\t}");
  }

  private static string GetCountStr(int count)
  {
    return count != 0 ? string.Format("count - {0}", (object) count) : nameof (count);
  }

  private static void GenGetType()
  {
    ToLuaExport.sb.AppendFormat("\r\n\tstatic Type classType = typeof({0});\r\n", (object) ToLuaExport.className);
    ToLuaExport.sb.AppendLine("\r\n\t[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
    ToLuaExport.sb.AppendFormat("\tstatic int {0}(IntPtr L)\r\n", (object) "GetClassType");
    ToLuaExport.sb.AppendLine("\t{");
    ToLuaExport.sb.AppendLine("\t\tLuaScriptMgr.Push(L, classType);");
    ToLuaExport.sb.AppendLine("\t\treturn 1;");
    ToLuaExport.sb.AppendLine("\t}");
  }

  private static void GenConstruct()
  {
    if (ToLuaExport.isStaticClass || typeof (MonoBehaviour).IsAssignableFrom(ToLuaExport.type))
    {
      ToLuaExport.NoConsturct();
    }
    else
    {
      ConstructorInfo[] constructors1 = ToLuaExport.type.GetConstructors(BindingFlags.Instance | ToLuaExport.binding);
      if ((object) ToLuaExport.extendType != null)
      {
        ConstructorInfo[] constructors2 = ToLuaExport.extendType.GetConstructors(BindingFlags.Instance | ToLuaExport.binding);
        if (constructors2 != null && constructors2.Length > 0 && ToLuaExport.HasAttribute((MemberInfo) constructors2[0], typeof (UseDefinedAttribute)))
        {
          ToLuaExport.sb.AppendLine("\r\n\t[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
          ToLuaExport.sb.AppendFormat("\tstatic int _Create{0}(IntPtr L)\r\n", (object) ToLuaExport.wrapClassName);
          ToLuaExport.sb.AppendLine("\t{");
          if (ToLuaExport.HasAttribute((MemberInfo) constructors2[0], typeof (UseDefinedAttribute)))
          {
            string str = ToLuaExport.extendType.GetField(ToLuaExport.extendName + "Defined").GetValue((object) null) as string;
            ToLuaExport.sb.AppendLine(str);
            ToLuaExport.sb.AppendLine("\t}");
            return;
          }
        }
      }
      if (constructors1.Length == 0)
      {
        if (!ToLuaExport.type.IsValueType)
          ToLuaExport.NoConsturct();
        else
          ToLuaExport.DefaultConstruct();
      }
      else
      {
        List<ConstructorInfo> list = new List<ConstructorInfo>();
        for (int index1 = 0; index1 < constructors1.Length; ++index1)
        {
          if (!ToLuaExport.HasDecimal(constructors1[index1].GetParameters()) && !ToLuaExport.IsObsolete((MemberInfo) constructors1[index1]))
          {
            ConstructorInfo r = constructors1[index1];
            int index2 = list.FindIndex((Predicate<ConstructorInfo>) (p => ToLuaExport.CompareMethod((MethodBase) p, (MethodBase) r) >= 0));
            if (index2 >= 0)
            {
              if (ToLuaExport.CompareMethod((MethodBase) list[index2], (MethodBase) r) == 2)
              {
                list.RemoveAt(index2);
                list.Add(r);
              }
            }
            else
              list.Add(r);
          }
        }
        if (list.Count == 0)
        {
          if (!ToLuaExport.type.IsValueType)
            ToLuaExport.NoConsturct();
          else
            ToLuaExport.DefaultConstruct();
        }
        else
        {
          list.Sort(new Comparison<ConstructorInfo>(ToLuaExport.Compare));
          ToLuaExport.sb.AppendLine("\r\n\t[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
          ToLuaExport.sb.AppendFormat("\tstatic int _Create{0}(IntPtr L)\r\n", (object) ToLuaExport.wrapClassName);
          ToLuaExport.sb.AppendLine("\t{");
          ToLuaExport.sb.AppendLine("\t\tint count = LuaDLL.lua_gettop(L);");
          ToLuaExport.sb.AppendLine();
          List<ConstructorInfo> constructorInfoList = new List<ConstructorInfo>();
          for (int i = 0; i < list.Count; ++i)
          {
            if (list.FindIndex((Predicate<ConstructorInfo>) (p => (object) p != (object) list[i] && p.GetParameters().Length == list[i].GetParameters().Length)) >= 0 || ToLuaExport.HasOptionalParam(list[i].GetParameters()) && list[i].GetParameters().Length > 1)
              constructorInfoList.Add(list[i]);
          }
          MethodBase md1 = (MethodBase) list[0];
          bool flag = list[0].GetParameters().Length == 0;
          if (ToLuaExport.HasOptionalParam(md1.GetParameters()))
          {
            ParameterInfo[] parameters = md1.GetParameters();
            string typeStr = ToLuaExport.GetTypeStr(parameters[parameters.Length - 1].ParameterType.GetElementType());
            if (parameters.Length > 1)
            {
              string str = ToLuaExport.GenParamTypes(parameters, true);
              ToLuaExport.sb.AppendFormat("\t\tif (LuaScriptMgr.CheckTypes(L, 1, {0}) && LuaScriptMgr.CheckParamsType(L, typeof({1}), {2}, {3}))\r\n", (object) str, (object) typeStr, (object) parameters.Length, (object) ToLuaExport.GetCountStr(parameters.Length - 1));
            }
            else
              ToLuaExport.sb.AppendFormat("\t\tif (LuaScriptMgr.CheckParamsType(L, typeof({0}), {1}, {2}))\r\n", (object) typeStr, (object) parameters.Length, (object) ToLuaExport.GetCountStr(parameters.Length - 1));
          }
          else
          {
            ParameterInfo[] parameters = md1.GetParameters();
            if (list.Count == 1 || md1.GetParameters().Length != list[1].GetParameters().Length)
            {
              ToLuaExport.sb.AppendFormat("\t\tif (count == {0})\r\n", (object) parameters.Length);
            }
            else
            {
              string str = ToLuaExport.GenParamTypes(parameters, true);
              ToLuaExport.sb.AppendFormat("\t\tif (count == {0} && LuaScriptMgr.CheckTypes(L, 1, {1}))\r\n", (object) parameters.Length, (object) str);
            }
          }
          ToLuaExport.sb.AppendLine("\t\t{");
          int num1 = ToLuaExport.ProcessParams(md1, 3, true, list.Count > 1);
          ToLuaExport.sb.AppendFormat("\t\t\treturn {0};\r\n", (object) num1);
          ToLuaExport.sb.AppendLine("\t\t}");
          for (int index = 1; index < list.Count; ++index)
          {
            flag = list[index].GetParameters().Length == 0 || flag;
            MethodBase md2 = (MethodBase) list[index];
            ParameterInfo[] parameters = md2.GetParameters();
            if (!ToLuaExport.HasOptionalParam(md2.GetParameters()))
            {
              if (constructorInfoList.Contains(list[index]))
              {
                string str = ToLuaExport.GenParamTypes(parameters, true);
                ToLuaExport.sb.AppendFormat("\t\telse if (count == {0} && LuaScriptMgr.CheckTypes(L, 1, {1}))\r\n", (object) parameters.Length, (object) str);
              }
              else
                ToLuaExport.sb.AppendFormat("\t\telse if (count == {0})\r\n", (object) parameters.Length);
            }
            else
            {
              string typeStr = ToLuaExport.GetTypeStr(parameters[parameters.Length - 1].ParameterType.GetElementType());
              if (parameters.Length > 1)
              {
                string str = ToLuaExport.GenParamTypes(parameters, true);
                ToLuaExport.sb.AppendFormat("\t\telse if (LuaScriptMgr.CheckTypes(L, 1, {0}) && LuaScriptMgr.CheckParamsType(L, typeof({1}), {2}, {3}))\r\n", (object) str, (object) typeStr, (object) parameters.Length, (object) ToLuaExport.GetCountStr(parameters.Length - 1));
              }
              else
                ToLuaExport.sb.AppendFormat("\t\telse if (LuaScriptMgr.CheckParamsType(L, typeof({0}), {1}, {2}))\r\n", (object) typeStr, (object) parameters.Length, (object) ToLuaExport.GetCountStr(parameters.Length - 1));
            }
            ToLuaExport.sb.AppendLine("\t\t{");
            int num2 = ToLuaExport.ProcessParams(md2, 3, true, true);
            ToLuaExport.sb.AppendFormat("\t\t\treturn {0};\r\n", (object) num2);
            ToLuaExport.sb.AppendLine("\t\t}");
          }
          if (ToLuaExport.type.IsValueType && !flag)
          {
            ToLuaExport.sb.AppendLine("\t\telse if (count == 0)");
            ToLuaExport.sb.AppendLine("\t\t{");
            ToLuaExport.sb.AppendFormat("\t\t\t{0} obj = new {0}();\r\n", (object) ToLuaExport.className);
            string pushFunction = ToLuaExport.GetPushFunction(ToLuaExport.type);
            ToLuaExport.sb.AppendFormat("\t\t\tLuaScriptMgr.{0}(L, obj);\r\n", (object) pushFunction);
            ToLuaExport.sb.AppendLine("\t\t\treturn 1;");
            ToLuaExport.sb.AppendLine("\t\t}");
          }
          ToLuaExport.sb.AppendLine("\t\telse");
          ToLuaExport.sb.AppendLine("\t\t{");
          ToLuaExport.sb.AppendFormat("\t\t\tLuaDLL.luaL_error(L, \"invalid arguments to method: {0}.New\");\r\n", (object) ToLuaExport.className);
          ToLuaExport.sb.AppendLine("\t\t}");
          ToLuaExport.sb.AppendLine();
          ToLuaExport.sb.AppendLine("\t\treturn 0;");
          ToLuaExport.sb.AppendLine("\t}");
        }
      }
    }
  }

  private static int GetOptionalParamPos(ParameterInfo[] infos)
  {
    for (int optionalParamPos = 0; optionalParamPos < infos.Length; ++optionalParamPos)
    {
      if (ToLuaExport.IsParams(infos[optionalParamPos]))
        return optionalParamPos;
    }
    return -1;
  }

  private static int Compare(MethodBase lhs, MethodBase rhs)
  {
    int num1 = !lhs.IsStatic ? 1 : 0;
    int num2 = !rhs.IsStatic ? 1 : 0;
    ParameterInfo[] parameters1 = lhs.GetParameters();
    ParameterInfo[] parameters2 = rhs.GetParameters();
    int optionalParamPos1 = ToLuaExport.GetOptionalParamPos(parameters1);
    int optionalParamPos2 = ToLuaExport.GetOptionalParamPos(parameters2);
    if (optionalParamPos1 >= 0 && optionalParamPos2 < 0)
      return 1;
    if (optionalParamPos1 < 0 && optionalParamPos2 >= 0)
      return -1;
    if (optionalParamPos1 >= 0 && optionalParamPos2 >= 0)
    {
      int num3 = optionalParamPos1 + num1;
      int num4 = optionalParamPos2 + num2;
      if (num3 != num4)
        return num3 > num4 ? -1 : 1;
      int index1 = num3 - num1;
      int index2 = num4 - num2;
      if ((object) parameters1[index1].ParameterType.GetElementType() == (object) typeof (object) && (object) parameters2[index2].ParameterType.GetElementType() != (object) typeof (object))
        return 1;
      if ((object) parameters1[index1].ParameterType.GetElementType() != (object) typeof (object) && (object) parameters2[index2].ParameterType.GetElementType() == (object) typeof (object))
        return -1;
    }
    int num5 = num1 + parameters1.Length;
    int num6 = num2 + parameters2.Length;
    if (num5 > num6)
      return 1;
    if (num5 != num6)
      return -1;
    List<ParameterInfo> parameterInfoList1 = new List<ParameterInfo>((IEnumerable<ParameterInfo>) parameters1);
    List<ParameterInfo> parameterInfoList2 = new List<ParameterInfo>((IEnumerable<ParameterInfo>) parameters2);
    if (parameterInfoList1.Count > parameterInfoList2.Count)
    {
      if ((object) parameterInfoList1[0].ParameterType == (object) typeof (object))
        return 1;
      parameterInfoList1.RemoveAt(0);
    }
    else if (parameterInfoList2.Count > parameterInfoList1.Count)
    {
      if ((object) parameterInfoList2[0].ParameterType == (object) typeof (object))
        return -1;
      parameterInfoList2.RemoveAt(0);
    }
    for (int index = 0; index < parameterInfoList1.Count; ++index)
    {
      if ((object) parameterInfoList1[index].ParameterType == (object) typeof (object) && (object) parameterInfoList2[index].ParameterType != (object) typeof (object))
        return 1;
      if ((object) parameterInfoList1[index].ParameterType != (object) typeof (object) && (object) parameterInfoList2[index].ParameterType == (object) typeof (object))
        return -1;
    }
    return 0;
  }

  private static bool HasOptionalParam(ParameterInfo[] infos)
  {
    for (int index = 0; index < infos.Length; ++index)
    {
      if (ToLuaExport.IsParams(infos[index]))
        return true;
    }
    return false;
  }

  private static System.Type GetRefBaseType(string str)
  {
    int startIndex = str.IndexOf("&");
    string typeName = startIndex < 0 ? str : str.Remove(startIndex);
    System.Type type = System.Type.GetType(typeName);
    if ((object) type == null)
      type = System.Type.GetType(typeName + ", UnityEngine");
    if ((object) type == null)
      type = System.Type.GetType(typeName + ", Assembly-CSharp-firstpass");
    return type;
  }

  private static int ProcessParams(
    MethodBase md,
    int tab,
    bool beConstruct,
    bool beLuaString,
    bool beCheckTypes = false)
  {
    ParameterInfo[] parameters = md.GetParameters();
    int length = parameters.Length;
    string empty = string.Empty;
    for (int index = 0; index < tab; ++index)
      empty += "\t";
    if (!md.IsStatic && !beConstruct)
    {
      if (md.Name == "Equals")
      {
        if (!ToLuaExport.type.IsValueType)
          ToLuaExport.sb.AppendFormat("{0}{1} obj = LuaScriptMgr.GetVarObject(L, 1) as {1};\r\n", (object) empty, (object) ToLuaExport.className);
        else
          ToLuaExport.sb.AppendFormat("{0}{1} obj = ({1})LuaScriptMgr.GetVarObject(L, 1);\r\n", (object) empty, (object) ToLuaExport.className);
      }
      else if (ToLuaExport.className != "Type" && ToLuaExport.className != "System.Type")
      {
        if (typeof (Object).IsAssignableFrom(ToLuaExport.type))
          ToLuaExport.sb.AppendFormat("{0}{1} obj = ({1})LuaScriptMgr.GetUnityObjectSelf(L, 1, \"{1}\");\r\n", (object) empty, (object) ToLuaExport.className);
        else if (typeof (TrackedReference).IsAssignableFrom(ToLuaExport.type))
          ToLuaExport.sb.AppendFormat("{0}{1} obj = ({1})LuaScriptMgr.GetTrackedObjectSelf(L, 1, \"{1}\");\r\n", (object) empty, (object) ToLuaExport.className);
        else
          ToLuaExport.sb.AppendFormat("{0}{1} obj = ({1})LuaScriptMgr.GetNetObjectSelf(L, 1, \"{1}\");\r\n", (object) empty, (object) ToLuaExport.className);
      }
      else
        ToLuaExport.sb.AppendFormat("{0}{1} obj = LuaScriptMgr.GetTypeObject(L, 1);\r\n", (object) empty, (object) ToLuaExport.className);
    }
    for (int index = 0; index < length; ++index)
    {
      ParameterInfo parameterInfo = parameters[index];
      string typeStr1 = ToLuaExport.GetTypeStr(parameterInfo.ParameterType);
      string str1 = "arg" + (object) index;
      int num = md.IsStatic || beConstruct ? 1 : 2;
      if (parameterInfo.Attributes == ParameterAttributes.Out)
      {
        if (ToLuaExport.GetRefBaseType(parameterInfo.ParameterType.ToString()).IsValueType)
          ToLuaExport.sb.AppendFormat("{0}{1} {2};\r\n", (object) empty, (object) typeStr1, (object) str1);
        else
          ToLuaExport.sb.AppendFormat("{0}{1} {2} = null;\r\n", (object) empty, (object) typeStr1, (object) str1);
      }
      else if ((object) parameterInfo.ParameterType == (object) typeof (bool))
      {
        if (beCheckTypes)
          ToLuaExport.sb.AppendFormat("{2}bool {0} = LuaDLL.lua_toboolean(L, {1});\r\n", (object) str1, (object) (index + num), (object) empty);
        else
          ToLuaExport.sb.AppendFormat("{2}bool {0} = LuaScriptMgr.GetBoolean(L, {1});\r\n", (object) str1, (object) (index + num), (object) empty);
      }
      else if ((object) parameterInfo.ParameterType == (object) typeof (string))
      {
        string str2 = !beLuaString ? "GetLuaString" : "GetString";
        ToLuaExport.sb.AppendFormat("{2}string {0} = LuaScriptMgr.{3}(L, {1});\r\n", (object) str1, (object) (index + num), (object) empty, (object) str2);
      }
      else if (parameterInfo.ParameterType.IsPrimitive)
      {
        if (beCheckTypes)
          ToLuaExport.sb.AppendFormat("{3}{0} {1} = ({0})LuaDLL.lua_tonumber(L, {2});\r\n", (object) typeStr1, (object) str1, (object) (index + num), (object) empty);
        else
          ToLuaExport.sb.AppendFormat("{3}{0} {1} = ({0})LuaScriptMgr.GetNumber(L, {2});\r\n", (object) typeStr1, (object) str1, (object) (index + num), (object) empty);
      }
      else if ((object) parameterInfo.ParameterType == (object) typeof (LuaFunction))
      {
        if (beCheckTypes)
          ToLuaExport.sb.AppendFormat("{2}LuaFunction {0} = LuaScriptMgr.ToLuaFunction(L, {1});\r\n", (object) str1, (object) (index + num), (object) empty);
        else
          ToLuaExport.sb.AppendFormat("{2}LuaFunction {0} = LuaScriptMgr.GetLuaFunction(L, {1});\r\n", (object) str1, (object) (index + num), (object) empty);
      }
      else if (parameterInfo.ParameterType.IsSubclassOf(typeof (MulticastDelegate)))
      {
        ToLuaExport.sb.AppendFormat("{0}{1} {2} = null;\r\n", (object) empty, (object) typeStr1, (object) str1);
        ToLuaExport.sb.AppendFormat("{0}LuaTypes funcType{1} = LuaDLL.lua_type(L, {1});\r\n", (object) empty, (object) (index + num));
        ToLuaExport.sb.AppendLine();
        ToLuaExport.sb.AppendFormat("{0}if (funcType{1} != LuaTypes.LUA_TFUNCTION)\r\n", (object) empty, (object) (index + num));
        ToLuaExport.sb.AppendLine(empty + "{");
        if (beCheckTypes)
          ToLuaExport.sb.AppendFormat("{3} {1} = ({0})LuaScriptMgr.GetLuaObject(L, {2});\r\n", (object) typeStr1, (object) str1, (object) (index + num), (object) (empty + "\t"));
        else
          ToLuaExport.sb.AppendFormat("{3} {1} = ({0})LuaScriptMgr.GetNetObject(L, {2}, typeof({0}));\r\n", (object) typeStr1, (object) str1, (object) (index + num), (object) (empty + "\t"));
        ToLuaExport.sb.AppendFormat("{0}}}\r\n{0}else\r\n{0}{{\r\n", (object) empty);
        ToLuaExport.sb.AppendFormat("{0}\tLuaFunction func = LuaScriptMgr.GetLuaFunction(L, {1});\r\n", (object) empty, (object) (index + num));
        ToLuaExport.sb.AppendFormat("{0}\t{1} = ", (object) empty, (object) str1);
        ToLuaExport.GenDelegateBody(parameterInfo.ParameterType, empty + "\t", true);
        ToLuaExport.sb.AppendLine(empty + "}\r\n");
      }
      else if ((object) parameterInfo.ParameterType == (object) typeof (LuaTable))
      {
        if (beCheckTypes)
          ToLuaExport.sb.AppendFormat("{2}LuaTable {0} = LuaScriptMgr.ToLuaTable(L, {1});\r\n", (object) str1, (object) (index + num), (object) empty);
        else
          ToLuaExport.sb.AppendFormat("{2}LuaTable {0} = LuaScriptMgr.GetLuaTable(L, {1});\r\n", (object) str1, (object) (index + num), (object) empty);
      }
      else if ((object) parameterInfo.ParameterType == (object) typeof (Vector2) || (object) ToLuaExport.GetRefBaseType(parameterInfo.ParameterType.ToString()) == (object) typeof (Vector2))
        ToLuaExport.sb.AppendFormat("{2}Vector2 {0} = LuaScriptMgr.GetVector2(L, {1});\r\n", (object) str1, (object) (index + num), (object) empty);
      else if ((object) parameterInfo.ParameterType == (object) typeof (Vector3) || (object) ToLuaExport.GetRefBaseType(parameterInfo.ParameterType.ToString()) == (object) typeof (Vector3))
        ToLuaExport.sb.AppendFormat("{2}Vector3 {0} = LuaScriptMgr.GetVector3(L, {1});\r\n", (object) str1, (object) (index + num), (object) empty);
      else if ((object) parameterInfo.ParameterType == (object) typeof (Vector4) || (object) ToLuaExport.GetRefBaseType(parameterInfo.ParameterType.ToString()) == (object) typeof (Vector4))
        ToLuaExport.sb.AppendFormat("{2}Vector4 {0} = LuaScriptMgr.GetVector4(L, {1});\r\n", (object) str1, (object) (index + num), (object) empty);
      else if ((object) parameterInfo.ParameterType == (object) typeof (Quaternion) || (object) ToLuaExport.GetRefBaseType(parameterInfo.ParameterType.ToString()) == (object) typeof (Quaternion))
        ToLuaExport.sb.AppendFormat("{2}Quaternion {0} = LuaScriptMgr.GetQuaternion(L, {1});\r\n", (object) str1, (object) (index + num), (object) empty);
      else if ((object) parameterInfo.ParameterType == (object) typeof (Color) || (object) ToLuaExport.GetRefBaseType(parameterInfo.ParameterType.ToString()) == (object) typeof (Color))
        ToLuaExport.sb.AppendFormat("{2}Color {0} = LuaScriptMgr.GetColor(L, {1});\r\n", (object) str1, (object) (index + num), (object) empty);
      else if ((object) parameterInfo.ParameterType == (object) typeof (Ray) || (object) ToLuaExport.GetRefBaseType(parameterInfo.ParameterType.ToString()) == (object) typeof (Ray))
        ToLuaExport.sb.AppendFormat("{2}Ray {0} = LuaScriptMgr.GetRay(L, {1});\r\n", (object) str1, (object) (index + num), (object) empty);
      else if ((object) parameterInfo.ParameterType == (object) typeof (Bounds) || (object) ToLuaExport.GetRefBaseType(parameterInfo.ParameterType.ToString()) == (object) typeof (Bounds))
        ToLuaExport.sb.AppendFormat("{2}Bounds {0} = LuaScriptMgr.GetBounds(L, {1});\r\n", (object) str1, (object) (index + num), (object) empty);
      else if ((object) parameterInfo.ParameterType == (object) typeof (object))
        ToLuaExport.sb.AppendFormat("{2}object {0} = LuaScriptMgr.GetVarObject(L, {1});\r\n", (object) str1, (object) (index + num), (object) empty);
      else if ((object) parameterInfo.ParameterType == (object) typeof (System.Type))
        ToLuaExport.sb.AppendFormat("{0}{1} {2} = LuaScriptMgr.GetTypeObject(L, {3});\r\n", (object) empty, (object) typeStr1, (object) str1, (object) (index + num));
      else if ((object) parameterInfo.ParameterType == (object) typeof (LuaStringBuffer))
        ToLuaExport.sb.AppendFormat("{2}LuaStringBuffer {0} = LuaScriptMgr.GetStringBuffer(L, {1});\r\n", (object) str1, (object) (index + num), (object) empty);
      else if (parameterInfo.ParameterType.IsArray)
      {
        System.Type elementType = parameterInfo.ParameterType.GetElementType();
        string typeStr2 = ToLuaExport.GetTypeStr(elementType);
        bool flag1 = false;
        bool flag2 = false;
        bool flag3 = false;
        string str3;
        if ((object) elementType == (object) typeof (bool))
          str3 = "GetArrayBool";
        else if (elementType.IsPrimitive)
        {
          flag1 = true;
          str3 = "GetArrayNumber";
        }
        else if ((object) elementType == (object) typeof (string))
        {
          flag2 = ToLuaExport.IsParams(parameterInfo);
          str3 = !flag2 ? "GetArrayString" : "GetParamsString";
        }
        else
        {
          flag1 = true;
          flag2 = ToLuaExport.IsParams(parameterInfo);
          str3 = !flag2 ? "GetArrayObject" : "GetParamsObject";
          if ((object) elementType == (object) typeof (object))
            flag3 = true;
          if ((object) elementType == (object) typeof (Object))
            ToLuaExport.ambig |= ObjAmbig.U3dObj;
        }
        if (flag1)
        {
          if (flag2)
          {
            if (!flag3)
              ToLuaExport.sb.AppendFormat("{5}{0}[] objs{2} = LuaScriptMgr.{4}<{0}>(L, {1}, {3});\r\n", (object) typeStr2, (object) (index + num), (object) index, (object) ToLuaExport.GetCountStr(index + num - 1), (object) str3, (object) empty);
            else
              ToLuaExport.sb.AppendFormat("{4}object[] objs{1} = LuaScriptMgr.{3}(L, {0}, {2});\r\n", (object) (index + num), (object) index, (object) ToLuaExport.GetCountStr(index + num - 1), (object) str3, (object) empty);
          }
          else
            ToLuaExport.sb.AppendFormat("{4}{0}[] objs{2} = LuaScriptMgr.{3}<{0}>(L, {1});\r\n", (object) typeStr2, (object) (index + num), (object) index, (object) str3, (object) empty);
        }
        else if (flag2)
          ToLuaExport.sb.AppendFormat("{5}{0}[] objs{2} = LuaScriptMgr.{4}(L, {1}, {3});\r\n", (object) typeStr2, (object) (index + num), (object) index, (object) ToLuaExport.GetCountStr(index + num - 1), (object) str3, (object) empty);
        else
          ToLuaExport.sb.AppendFormat("{5}{0}[] objs{2} = LuaScriptMgr.{4}(L, {1});\r\n", (object) typeStr2, (object) (index + num), (object) index, (object) (index + num - 1), (object) str3, (object) empty);
      }
      else if (md.Name == "op_Equality")
      {
        if (!ToLuaExport.type.IsValueType)
          ToLuaExport.sb.AppendFormat("{3}{0} {1} = LuaScriptMgr.GetLuaObject(L, {2}) as {0};\r\n", (object) typeStr1, (object) str1, (object) (index + num), (object) empty);
        else
          ToLuaExport.sb.AppendFormat("{3}{0} {1} = ({0})LuaScriptMgr.GetVarObject(L, {2});\r\n", (object) typeStr1, (object) str1, (object) (index + num), (object) empty);
      }
      else if (beCheckTypes)
        ToLuaExport.sb.AppendFormat("{3}{0} {1} = ({0})LuaScriptMgr.GetLuaObject(L, {2});\r\n", (object) typeStr1, (object) str1, (object) (index + num), (object) empty);
      else if (typeof (Object).IsAssignableFrom(parameterInfo.ParameterType))
        ToLuaExport.sb.AppendFormat("{3}{0} {1} = ({0})LuaScriptMgr.GetUnityObject(L, {2}, typeof({0}));\r\n", (object) typeStr1, (object) str1, (object) (index + num), (object) empty);
      else if (typeof (TrackedReference).IsAssignableFrom(parameterInfo.ParameterType))
        ToLuaExport.sb.AppendFormat("{3}{0} {1} = ({0})LuaScriptMgr.GetTrackedObject(L, {2}, typeof({0}));\r\n", (object) typeStr1, (object) str1, (object) (index + num), (object) empty);
      else
        ToLuaExport.sb.AppendFormat("{3}{0} {1} = ({0})LuaScriptMgr.GetNetObject(L, {2}, typeof({0}));\r\n", (object) typeStr1, (object) str1, (object) (index + num), (object) empty);
    }
    StringBuilder stringBuilder = new StringBuilder();
    List<string> stringList = new List<string>();
    List<System.Type> typeList = new List<System.Type>();
    for (int index = 0; index < length - 1; ++index)
    {
      ParameterInfo parameterInfo = parameters[index];
      if (!parameterInfo.ParameterType.IsArray)
      {
        if (!parameterInfo.ParameterType.ToString().Contains("&"))
        {
          stringBuilder.Append("arg");
        }
        else
        {
          if (parameterInfo.Attributes == ParameterAttributes.Out)
            stringBuilder.Append("out arg");
          else
            stringBuilder.Append("ref arg");
          stringList.Add("arg" + (object) index);
          typeList.Add(ToLuaExport.GetRefBaseType(parameterInfo.ParameterType.ToString()));
        }
      }
      else
        stringBuilder.Append("objs");
      stringBuilder.Append(index);
      stringBuilder.Append(",");
    }
    if (length > 0)
    {
      ParameterInfo parameterInfo = parameters[length - 1];
      if (!parameterInfo.ParameterType.IsArray)
      {
        if (!parameterInfo.ParameterType.ToString().Contains("&"))
        {
          stringBuilder.Append("arg");
        }
        else
        {
          if (parameterInfo.Attributes == ParameterAttributes.Out)
            stringBuilder.Append("out arg");
          else
            stringBuilder.Append("ref arg");
          stringList.Add("arg" + (object) (length - 1));
          typeList.Add(ToLuaExport.GetRefBaseType(parameterInfo.ParameterType.ToString()));
        }
      }
      else
        stringBuilder.Append("objs");
      stringBuilder.Append(length - 1);
    }
    if (beConstruct)
    {
      ToLuaExport.sb.AppendFormat("{2}{0} obj = new {0}({1});\r\n", (object) ToLuaExport.className, (object) stringBuilder.ToString(), (object) empty);
      string pushFunction1 = ToLuaExport.GetPushFunction(ToLuaExport.type);
      ToLuaExport.sb.AppendFormat("{0}LuaScriptMgr.{1}(L, obj);\r\n", (object) empty, (object) pushFunction1);
      for (int index = 0; index < stringList.Count; ++index)
      {
        string pushFunction2 = ToLuaExport.GetPushFunction(typeList[index]);
        ToLuaExport.sb.AppendFormat("{1}LuaScriptMgr.{2}(L, {0});\r\n", (object) stringList[index], (object) empty, (object) pushFunction2);
      }
      return stringList.Count + 1;
    }
    string str = !md.IsStatic ? "obj" : ToLuaExport.className;
    MethodInfo methodInfo = md as MethodInfo;
    if ((object) methodInfo.ReturnType == (object) typeof (void))
    {
      if (md.Name == "set_Item")
      {
        switch (length)
        {
          case 2:
            ToLuaExport.sb.AppendFormat("{0}{1}[arg0] = arg1;\r\n", (object) empty, (object) str);
            break;
          case 3:
            ToLuaExport.sb.AppendFormat("{0}{1}[arg0, arg1] = arg2;\r\n", (object) empty, (object) str);
            break;
        }
      }
      else
        ToLuaExport.sb.AppendFormat("{3}{0}.{1}({2});\r\n", (object) str, (object) md.Name, (object) stringBuilder.ToString(), (object) empty);
      if (!md.IsStatic && ToLuaExport.type.IsValueType)
        ToLuaExport.sb.AppendFormat("{0}LuaScriptMgr.SetValueObject(L, 1, obj);\r\n", (object) empty);
    }
    else
    {
      string typeStr = ToLuaExport.GetTypeStr(methodInfo.ReturnType);
      if (md.Name.Contains("op_"))
        ToLuaExport.CallOpFunction(md.Name, tab, typeStr);
      else if (md.Name == "get_Item")
        ToLuaExport.sb.AppendFormat("{4}{3} o = {0}[{2}];\r\n", (object) str, (object) md.Name, (object) stringBuilder.ToString(), (object) typeStr, (object) empty);
      else if (md.Name == "Equals")
      {
        if (ToLuaExport.type.IsValueType)
          ToLuaExport.sb.AppendFormat("{0}bool o = obj.Equals(arg0);\r\n", (object) empty);
        else
          ToLuaExport.sb.AppendFormat("{0}bool o = obj != null ? obj.Equals(arg0) : arg0 == null;\r\n", (object) empty);
      }
      else
        ToLuaExport.sb.AppendFormat("{4}{3} o = {0}.{1}({2});\r\n", (object) str, (object) md.Name, (object) stringBuilder.ToString(), (object) typeStr, (object) empty);
      string pushFunction = ToLuaExport.GetPushFunction(methodInfo.ReturnType);
      ToLuaExport.sb.AppendFormat("{0}LuaScriptMgr.{1}(L, o);\r\n", (object) empty, (object) pushFunction);
    }
    for (int index = 0; index < stringList.Count; ++index)
    {
      string pushFunction = ToLuaExport.GetPushFunction(typeList[index]);
      ToLuaExport.sb.AppendFormat("{1}LuaScriptMgr.{2}(L, {0});\r\n", (object) stringList[index], (object) empty, (object) pushFunction);
    }
    return stringList.Count;
  }

  private static bool CompareParmsCount(MethodBase l, MethodBase r)
  {
    if ((object) l == (object) r)
      return false;
    int num1 = !l.IsStatic ? 1 : 0;
    int num2 = !r.IsStatic ? 1 : 0;
    return num1 + l.GetParameters().Length == num2 + r.GetParameters().Length;
  }

  private static int CompareMethod(MethodBase l, MethodBase r)
  {
    int num = 0;
    if (!ToLuaExport.CompareParmsCount(l, r))
      return -1;
    ParameterInfo[] parameters1 = l.GetParameters();
    ParameterInfo[] parameters2 = r.GetParameters();
    List<System.Type> typeList1 = new List<System.Type>();
    List<System.Type> typeList2 = new List<System.Type>();
    if (!l.IsStatic)
      typeList1.Add(ToLuaExport.type);
    if (!r.IsStatic)
      typeList2.Add(ToLuaExport.type);
    for (int index = 0; index < parameters1.Length; ++index)
      typeList1.Add(parameters1[index].ParameterType);
    for (int index = 0; index < parameters2.Length; ++index)
      typeList2.Add(parameters2[index].ParameterType);
    for (int index = 0; index < typeList1.Count; ++index)
    {
      if (!ToLuaExport.typeSize.ContainsKey(typeList1[index]) || !ToLuaExport.typeSize.ContainsKey(typeList2[index]))
      {
        if ((object) typeList1[index] != (object) typeList2[index])
          return -1;
      }
      else if (typeList1[index].IsPrimitive && typeList2[index].IsPrimitive && num == 0)
        num = ToLuaExport.typeSize[typeList1[index]] < ToLuaExport.typeSize[typeList2[index]] ? 2 : 1;
      else if ((object) typeList1[index] != (object) typeList2[index])
        return -1;
    }
    if (num == 0 && l.IsStatic)
      num = 2;
    return num;
  }

  private static void Push(List<MethodInfo> list, MethodInfo r)
  {
    int index = list.FindIndex((Predicate<MethodInfo>) (p => p.Name == r.Name && ToLuaExport.CompareMethod((MethodBase) p, (MethodBase) r) >= 0));
    if (index >= 0)
    {
      if (ToLuaExport.CompareMethod((MethodBase) list[index], (MethodBase) r) != 2)
        return;
      list.RemoveAt(index);
      list.Add(r);
    }
    else
      list.Add(r);
  }

  private static bool HasDecimal(ParameterInfo[] pi)
  {
    for (int index = 0; index < pi.Length; ++index)
    {
      if ((object) pi[index].ParameterType == (object) typeof (Decimal))
        return true;
    }
    return false;
  }

  public static MethodInfo GenOverrideFunc(string name)
  {
    List<MethodInfo> list = new List<MethodInfo>();
    for (int index = 0; index < ToLuaExport.methods.Length; ++index)
    {
      if (ToLuaExport.methods[index].Name == name && !ToLuaExport.methods[index].IsGenericMethod && !ToLuaExport.HasDecimal(ToLuaExport.methods[index].GetParameters()))
        ToLuaExport.Push(list, ToLuaExport.methods[index]);
    }
    if (list.Count == 1)
      return list[0];
    list.Sort(new Comparison<MethodInfo>(ToLuaExport.Compare));
    ToLuaExport.sb.AppendLine("\r\n\t[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
    ToLuaExport.sb.AppendFormat("\tstatic int {0}(IntPtr L)\r\n", (object) ToLuaExport.GetFuncName(name));
    ToLuaExport.sb.AppendLine("\t{");
    ToLuaExport.sb.AppendLine("\t\tint count = LuaDLL.lua_gettop(L);");
    List<MethodInfo> methodInfoList = new List<MethodInfo>();
    for (int i = 0; i < list.Count; ++i)
    {
      if (list.FindIndex((Predicate<MethodInfo>) (p => ToLuaExport.CompareParmsCount((MethodBase) p, (MethodBase) list[i]))) >= 0 || ToLuaExport.HasOptionalParam(list[i].GetParameters()) && list[i].GetParameters().Length > 1)
        methodInfoList.Add(list[i]);
    }
    ToLuaExport.sb.AppendLine();
    MethodInfo md1 = list[0];
    int num1 = (object) md1.ReturnType != (object) typeof (void) ? 1 : 0;
    int num2 = !md1.IsStatic ? 1 : 0;
    int num3 = num2 + 1;
    int num4 = md1.GetParameters().Length + num2;
    int num5 = list[1].GetParameters().Length + (!list[1].IsStatic ? 1 : 0);
    bool flag = true;
    bool beCheckTypes1 = true;
    if (ToLuaExport.HasOptionalParam(md1.GetParameters()))
    {
      ParameterInfo[] parameters = md1.GetParameters();
      string typeStr = ToLuaExport.GetTypeStr(parameters[parameters.Length - 1].ParameterType.GetElementType());
      if (parameters.Length > 1)
      {
        string str = ToLuaExport.GenParamTypes(parameters, md1.IsStatic);
        ToLuaExport.sb.AppendFormat("\t\tif (LuaScriptMgr.CheckTypes(L, 1, {1}) && LuaScriptMgr.CheckParamsType(L, typeof({2}), {3}, {4}))\r\n", (object) num3, (object) str, (object) typeStr, (object) (parameters.Length + num2), (object) ToLuaExport.GetCountStr(parameters.Length + num2 - 1));
      }
      else
        ToLuaExport.sb.AppendFormat("\t\tif (LuaScriptMgr.CheckParamsType(L, typeof({0}), {1}, {2}))\r\n", (object) typeStr, (object) (parameters.Length + num2), (object) ToLuaExport.GetCountStr(parameters.Length + num2 - 1));
    }
    else if (num4 != num5)
    {
      ToLuaExport.sb.AppendFormat("\t\tif (count == {0})\r\n", (object) (md1.GetParameters().Length + num2));
      flag = false;
      beCheckTypes1 = false;
    }
    else
    {
      ParameterInfo[] parameters = md1.GetParameters();
      if (parameters.Length > 0)
      {
        string str = ToLuaExport.GenParamTypes(parameters, md1.IsStatic);
        ToLuaExport.sb.AppendFormat("\t\tif (count == {0} && LuaScriptMgr.CheckTypes(L, 1, {2}))\r\n", (object) (parameters.Length + num2), (object) num3, (object) str);
      }
      else
        ToLuaExport.sb.AppendFormat("\t\tif (count == {0})\r\n", (object) (parameters.Length + num2));
    }
    ToLuaExport.sb.AppendLine("\t\t{");
    int num6 = ToLuaExport.ProcessParams((MethodBase) md1, 3, false, list.Count > 1 && flag, beCheckTypes1);
    ToLuaExport.sb.AppendFormat("\t\t\treturn {0};\r\n", (object) (num1 + num6));
    ToLuaExport.sb.AppendLine("\t\t}");
    for (int index = 1; index < list.Count; ++index)
    {
      bool beLuaString = true;
      bool beCheckTypes2 = true;
      MethodInfo md2 = list[index];
      int num7 = !md2.IsStatic ? 1 : 0;
      int num8 = num7 + 1;
      int num9 = (object) md2.ReturnType != (object) typeof (void) ? 1 : 0;
      if (!ToLuaExport.HasOptionalParam(md2.GetParameters()))
      {
        ParameterInfo[] parameters = md2.GetParameters();
        if (methodInfoList.Contains(list[index]))
        {
          string str = ToLuaExport.GenParamTypes(parameters, md2.IsStatic);
          ToLuaExport.sb.AppendFormat("\t\telse if (count == {0} && LuaScriptMgr.CheckTypes(L, 1, {2}))\r\n", (object) (parameters.Length + num7), (object) num8, (object) str);
        }
        else
        {
          ToLuaExport.sb.AppendFormat("\t\telse if (count == {0})\r\n", (object) (parameters.Length + num7));
          beLuaString = false;
          beCheckTypes2 = false;
        }
      }
      else
      {
        ParameterInfo[] parameters = md2.GetParameters();
        string typeStr = ToLuaExport.GetTypeStr(parameters[parameters.Length - 1].ParameterType.GetElementType());
        if (parameters.Length > 1)
        {
          string str = ToLuaExport.GenParamTypes(parameters, md2.IsStatic);
          ToLuaExport.sb.AppendFormat("\t\telse if (LuaScriptMgr.CheckTypes(L, 1, {1}) && LuaScriptMgr.CheckParamsType(L, typeof({2}), {3}, {4}))\r\n", (object) num8, (object) str, (object) typeStr, (object) (parameters.Length + num7), (object) ToLuaExport.GetCountStr(parameters.Length + num7 - 1));
        }
        else
          ToLuaExport.sb.AppendFormat("\t\telse if (LuaScriptMgr.CheckParamsType(L, typeof({0}), {1}, {2}))\r\n", (object) typeStr, (object) (parameters.Length + num7), (object) ToLuaExport.GetCountStr(parameters.Length + num7 - 1));
      }
      ToLuaExport.sb.AppendLine("\t\t{");
      int num10 = ToLuaExport.ProcessParams((MethodBase) md2, 3, false, beLuaString, beCheckTypes2);
      ToLuaExport.sb.AppendFormat("\t\t\treturn {0};\r\n", (object) (num9 + num10));
      ToLuaExport.sb.AppendLine("\t\t}");
    }
    ToLuaExport.sb.AppendLine("\t\telse");
    ToLuaExport.sb.AppendLine("\t\t{");
    ToLuaExport.sb.AppendFormat("\t\t\tLuaDLL.luaL_error(L, \"invalid arguments to method: {0}.{1}\");\r\n", (object) ToLuaExport.className, (object) name);
    ToLuaExport.sb.AppendLine("\t\t}");
    ToLuaExport.sb.AppendLine();
    ToLuaExport.sb.AppendLine("\t\treturn 0;");
    ToLuaExport.sb.AppendLine("\t}");
    return (MethodInfo) null;
  }

  private static string[] GetGenericName(System.Type[] types)
  {
    string[] genericName = new string[types.Length];
    for (int index = 0; index < types.Length; ++index)
      genericName[index] = !types[index].IsGenericType ? ToLuaExport.GetTypeStr(types[index]) : ToLuaExport.GetGenericName(types[index]);
    return genericName;
  }

  private static string GetGenericName(System.Type t)
  {
    System.Type[] genericArguments = t.GetGenericArguments();
    string fullName = t.FullName;
    string str1 = ToLuaExport._C(fullName.Substring(0, fullName.IndexOf('`')));
    if (!fullName.Contains("+"))
      return str1 + "<" + string.Join(",", ToLuaExport.GetGenericName(genericArguments)) + ">";
    int num1 = fullName.IndexOf("+");
    int num2 = fullName.IndexOf("[");
    if (num2 <= num1)
      return str1 + "<" + string.Join(",", ToLuaExport.GetGenericName(genericArguments)) + ">";
    string str2 = fullName.Substring(num1 + 1, num2 - num1 - 1);
    return str1 + "<" + string.Join(",", ToLuaExport.GetGenericName(genericArguments)) + ">." + str2;
  }

  public static string GetTypeStr(System.Type t)
  {
    if (t.IsArray)
    {
      t = t.GetElementType();
      return ToLuaExport.GetTypeStr(t) + "[]";
    }
    return t.IsGenericType ? ToLuaExport.GetGenericName(t) : ToLuaExport._C(t.ToString());
  }

  public static string _C(string str)
  {
    if (str.Length > 1 && str[str.Length - 1] == '&')
      str = str.Remove(str.Length - 1);
    switch (str)
    {
      case "System.Single":
      case "Single":
        return "float";
      case "System.String":
      case "String":
        return "string";
      case "System.Int32":
      case "Int32":
        return "int";
      case "System.Int64":
      case "Int64":
        return "long";
      case "System.SByte":
      case "SByte":
        return "sbyte";
      case "System.Byte":
      case "Byte":
        return "byte";
      case "System.Int16":
      case "Int16":
        return "short";
      case "System.UInt16":
      case "UInt16":
        return "ushort";
      case "System.Char":
      case "Char":
        return "char";
      case "System.UInt32":
      case "UInt32":
        return "uint";
      case "System.UInt64":
      case "UInt64":
        return "ulong";
      case "System.Decimal":
      case "Decimal":
        return "decimal";
      case "System.Double":
      case "Double":
        return "double";
      case "System.Boolean":
      case "Boolean":
        return "bool";
      case "System.Object":
        return "object";
      default:
        if (str.Contains("."))
        {
          int length = str.LastIndexOf('.');
          string str1 = str.Substring(0, length);
          if (str.Length > 12 && str.Substring(0, 12) == "UnityEngine.")
          {
            if (str1 == "UnityEngine")
              ToLuaExport.usingList.Add("UnityEngine");
            if (str == "UnityEngine.Object")
              ToLuaExport.ambig |= ObjAmbig.U3dObj;
          }
          else if (str.Length > 7 && str.Substring(0, 7) == "System.")
          {
            switch (str1)
            {
              case "System.Collections":
                ToLuaExport.usingList.Add(str1);
                break;
              case "System.Collections.Generic":
                ToLuaExport.usingList.Add(str1);
                break;
              case "System":
                ToLuaExport.usingList.Add(str1);
                break;
            }
            if (str == "System.Object")
              str = "object";
          }
          if (ToLuaExport.usingList.Contains(str1))
            str = str.Substring(length + 1);
        }
        if (str.Contains("+"))
          return str.Replace('+', '.');
        return str == ToLuaExport.extendName ? ToLuaExport.GetTypeStr(ToLuaExport.type) : str;
    }
  }

  private static bool IsLuaTableType(System.Type t)
  {
    if (t.IsArray)
      t = t.GetElementType();
    return (object) t == (object) typeof (Vector3) || (object) t == (object) typeof (Vector2) || (object) t == (object) typeof (Vector4) || (object) t == (object) typeof (Quaternion) || (object) t == (object) typeof (Color) || (object) t == (object) typeof (Ray) || (object) t == (object) typeof (Bounds);
  }

  private static string GetTypeOf(System.Type t, string sep)
  {
    return (object) t != null ? (!ToLuaExport.IsLuaTableType(t) ? string.Format("typeof({0}){1}", (object) ToLuaExport.GetTypeStr(t), (object) sep) : string.Format("typeof(LuaTable{1}){0}", (object) sep, !t.IsArray ? (object) string.Empty : (object) "[]")) : string.Format("null{0}", (object) sep);
  }

  private static string GenParamTypes(ParameterInfo[] p, bool isStatic)
  {
    StringBuilder stringBuilder = new StringBuilder();
    List<System.Type> typeList = new List<System.Type>();
    if (!isStatic)
      typeList.Add(ToLuaExport.type);
    for (int index = 0; index < p.Length; ++index)
    {
      if (!ToLuaExport.IsParams(p[index]))
      {
        if (p[index].Attributes != ParameterAttributes.Out)
          typeList.Add(p[index].ParameterType);
        else
          typeList.Add((System.Type) null);
      }
    }
    for (int index = 0; index < typeList.Count - 1; ++index)
      stringBuilder.Append(ToLuaExport.GetTypeOf(typeList[index], ", "));
    stringBuilder.Append(ToLuaExport.GetTypeOf(typeList[typeList.Count - 1], string.Empty));
    return stringBuilder.ToString();
  }

  private static void CheckObjectNull()
  {
    if (ToLuaExport.type.IsValueType)
      ToLuaExport.sb.AppendLine("\t\tif (o == null)");
    else
      ToLuaExport.sb.AppendLine("\t\tif (obj == null)");
  }

  private static void GenIndexFunc()
  {
    for (int index = 0; index < ToLuaExport.fields.Length; ++index)
    {
      ToLuaExport.sb.AppendLine("\r\n\t[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
      ToLuaExport.sb.AppendFormat("\tstatic int get_{0}(IntPtr L)\r\n", (object) ToLuaExport.fields[index].Name);
      ToLuaExport.sb.AppendLine("\t{");
      string pushFunction = ToLuaExport.GetPushFunction(ToLuaExport.fields[index].FieldType);
      if (ToLuaExport.fields[index].IsStatic)
      {
        ToLuaExport.sb.AppendFormat("\t\tLuaScriptMgr.{2}(L, {0}.{1});\r\n", (object) ToLuaExport.className, (object) ToLuaExport.fields[index].Name, (object) pushFunction);
      }
      else
      {
        ToLuaExport.sb.AppendFormat("\t\tobject o = LuaScriptMgr.GetLuaObject(L, 1);\r\n");
        if (!ToLuaExport.type.IsValueType)
          ToLuaExport.sb.AppendFormat("\t\t{0} obj = ({0})o;\r\n", (object) ToLuaExport.className);
        ToLuaExport.sb.AppendLine();
        ToLuaExport.CheckObjectNull();
        ToLuaExport.sb.AppendLine("\t\t{");
        ToLuaExport.sb.AppendLine("\t\t\tLuaTypes types = LuaDLL.lua_type(L, 1);");
        ToLuaExport.sb.AppendLine();
        ToLuaExport.sb.AppendLine("\t\t\tif (types == LuaTypes.LUA_TTABLE)");
        ToLuaExport.sb.AppendLine("\t\t\t{");
        ToLuaExport.sb.AppendFormat("\t\t\t\tLuaDLL.luaL_error(L, \"unknown member name {0}\");\r\n", (object) ToLuaExport.fields[index].Name);
        ToLuaExport.sb.AppendLine("\t\t\t}");
        ToLuaExport.sb.AppendLine("\t\t\telse");
        ToLuaExport.sb.AppendLine("\t\t\t{");
        ToLuaExport.sb.AppendFormat("\t\t\t\tLuaDLL.luaL_error(L, \"attempt to index {0} on a nil value\");\r\n", (object) ToLuaExport.fields[index].Name);
        ToLuaExport.sb.AppendLine("\t\t\t}");
        ToLuaExport.sb.AppendLine("\t\t}");
        ToLuaExport.sb.AppendLine();
        if (ToLuaExport.type.IsValueType)
          ToLuaExport.sb.AppendFormat("\t\t{0} obj = ({0})o;\r\n", (object) ToLuaExport.className);
        ToLuaExport.sb.AppendFormat("\t\tLuaScriptMgr.{1}(L, obj.{0});\r\n", (object) ToLuaExport.fields[index].Name, (object) pushFunction);
      }
      ToLuaExport.sb.AppendLine("\t\treturn 1;");
      ToLuaExport.sb.AppendLine("\t}");
    }
    for (int index = 0; index < ToLuaExport.props.Length; ++index)
    {
      if (ToLuaExport.props[index].CanRead)
      {
        bool flag = true;
        if (ToLuaExport.propList.IndexOf(ToLuaExport.props[index]) >= 0)
          flag = false;
        ToLuaExport.sb.AppendLine("\r\n\t[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
        ToLuaExport.sb.AppendFormat("\tstatic int get_{0}(IntPtr L)\r\n", (object) ToLuaExport.props[index].Name);
        ToLuaExport.sb.AppendLine("\t{");
        string pushFunction = ToLuaExport.GetPushFunction(ToLuaExport.props[index].PropertyType);
        if (flag)
        {
          ToLuaExport.sb.AppendFormat("\t\tLuaScriptMgr.{2}(L, {0}.{1});\r\n", (object) ToLuaExport.className, (object) ToLuaExport.props[index].Name, (object) pushFunction);
        }
        else
        {
          ToLuaExport.sb.AppendFormat("\t\tobject o = LuaScriptMgr.GetLuaObject(L, 1);\r\n");
          if (!ToLuaExport.type.IsValueType)
            ToLuaExport.sb.AppendFormat("\t\t{0} obj = ({0})o;\r\n", (object) ToLuaExport.className);
          ToLuaExport.sb.AppendLine();
          ToLuaExport.CheckObjectNull();
          ToLuaExport.sb.AppendLine("\t\t{");
          ToLuaExport.sb.AppendLine("\t\t\tLuaTypes types = LuaDLL.lua_type(L, 1);");
          ToLuaExport.sb.AppendLine();
          ToLuaExport.sb.AppendLine("\t\t\tif (types == LuaTypes.LUA_TTABLE)");
          ToLuaExport.sb.AppendLine("\t\t\t{");
          ToLuaExport.sb.AppendFormat("\t\t\t\tLuaDLL.luaL_error(L, \"unknown member name {0}\");\r\n", (object) ToLuaExport.props[index].Name);
          ToLuaExport.sb.AppendLine("\t\t\t}");
          ToLuaExport.sb.AppendLine("\t\t\telse");
          ToLuaExport.sb.AppendLine("\t\t\t{");
          ToLuaExport.sb.AppendFormat("\t\t\t\tLuaDLL.luaL_error(L, \"attempt to index {0} on a nil value\");\r\n", (object) ToLuaExport.props[index].Name);
          ToLuaExport.sb.AppendLine("\t\t\t}");
          ToLuaExport.sb.AppendLine("\t\t}");
          ToLuaExport.sb.AppendLine();
          if (ToLuaExport.type.IsValueType)
            ToLuaExport.sb.AppendFormat("\t\t{0} obj = ({0})o;\r\n", (object) ToLuaExport.className);
          ToLuaExport.sb.AppendFormat("\t\tLuaScriptMgr.{1}(L, obj.{0});\r\n", (object) ToLuaExport.props[index].Name, (object) pushFunction);
        }
        ToLuaExport.sb.AppendLine("\t\treturn 1;");
        ToLuaExport.sb.AppendLine("\t}");
      }
    }
  }

  private static void GenNewIndexFunc()
  {
    for (int index = 0; index < ToLuaExport.fields.Length; ++index)
    {
      if (!ToLuaExport.fields[index].IsLiteral && !ToLuaExport.fields[index].IsInitOnly && !ToLuaExport.fields[index].IsPrivate)
      {
        ToLuaExport.sb.AppendLine("\r\n\t[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
        ToLuaExport.sb.AppendFormat("\tstatic int set_{0}(IntPtr L)\r\n", (object) ToLuaExport.fields[index].Name);
        ToLuaExport.sb.AppendLine("\t{");
        string o = !ToLuaExport.fields[index].IsStatic ? "obj" : ToLuaExport.className;
        if (!ToLuaExport.fields[index].IsStatic)
        {
          ToLuaExport.sb.AppendFormat("\t\tobject o = LuaScriptMgr.GetLuaObject(L, 1);\r\n");
          if (!ToLuaExport.type.IsValueType)
            ToLuaExport.sb.AppendFormat("\t\t{0} obj = ({0})o;\r\n", (object) ToLuaExport.className);
          ToLuaExport.sb.AppendLine();
          ToLuaExport.CheckObjectNull();
          ToLuaExport.sb.AppendLine("\t\t{");
          ToLuaExport.sb.AppendLine("\t\t\tLuaTypes types = LuaDLL.lua_type(L, 1);");
          ToLuaExport.sb.AppendLine();
          ToLuaExport.sb.AppendLine("\t\t\tif (types == LuaTypes.LUA_TTABLE)");
          ToLuaExport.sb.AppendLine("\t\t\t{");
          ToLuaExport.sb.AppendFormat("\t\t\t\tLuaDLL.luaL_error(L, \"unknown member name {0}\");\r\n", (object) ToLuaExport.fields[index].Name);
          ToLuaExport.sb.AppendLine("\t\t\t}");
          ToLuaExport.sb.AppendLine("\t\t\telse");
          ToLuaExport.sb.AppendLine("\t\t\t{");
          ToLuaExport.sb.AppendFormat("\t\t\t\tLuaDLL.luaL_error(L, \"attempt to index {0} on a nil value\");\r\n", (object) ToLuaExport.fields[index].Name);
          ToLuaExport.sb.AppendLine("\t\t\t}");
          ToLuaExport.sb.AppendLine("\t\t}");
          ToLuaExport.sb.AppendLine();
          if (ToLuaExport.type.IsValueType)
            ToLuaExport.sb.AppendFormat("\t\t{0} obj = ({0})o;\r\n", (object) ToLuaExport.className);
        }
        ToLuaExport.NewIndexSetValue(ToLuaExport.fields[index].FieldType, o, ToLuaExport.fields[index].Name);
        if (!ToLuaExport.fields[index].IsStatic && ToLuaExport.type.IsValueType)
          ToLuaExport.sb.AppendLine("\t\tLuaScriptMgr.SetValueObject(L, 1, obj);");
        ToLuaExport.sb.AppendLine("\t\treturn 0;");
        ToLuaExport.sb.AppendLine("\t}");
      }
    }
    for (int index = 0; index < ToLuaExport.props.Length; ++index)
    {
      if (ToLuaExport.props[index].CanWrite && ToLuaExport.props[index].GetSetMethod(true).IsPublic)
      {
        bool flag = true;
        if (ToLuaExport.propList.IndexOf(ToLuaExport.props[index]) >= 0)
          flag = false;
        ToLuaExport.sb.AppendLine("\r\n\t[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
        ToLuaExport.sb.AppendFormat("\tstatic int set_{0}(IntPtr L)\r\n", (object) ToLuaExport.props[index].Name);
        ToLuaExport.sb.AppendLine("\t{");
        string o = !flag ? "obj" : ToLuaExport.className;
        if (!flag)
        {
          ToLuaExport.sb.AppendFormat("\t\tobject o = LuaScriptMgr.GetLuaObject(L, 1);\r\n");
          if (!ToLuaExport.type.IsValueType)
            ToLuaExport.sb.AppendFormat("\t\t{0} obj = ({0})o;\r\n", (object) ToLuaExport.className);
          ToLuaExport.sb.AppendLine();
          ToLuaExport.CheckObjectNull();
          ToLuaExport.sb.AppendLine("\t\t{");
          ToLuaExport.sb.AppendLine("\t\t\tLuaTypes types = LuaDLL.lua_type(L, 1);");
          ToLuaExport.sb.AppendLine();
          ToLuaExport.sb.AppendLine("\t\t\tif (types == LuaTypes.LUA_TTABLE)");
          ToLuaExport.sb.AppendLine("\t\t\t{");
          ToLuaExport.sb.AppendFormat("\t\t\t\tLuaDLL.luaL_error(L, \"unknown member name {0}\");\r\n", (object) ToLuaExport.props[index].Name);
          ToLuaExport.sb.AppendLine("\t\t\t}");
          ToLuaExport.sb.AppendLine("\t\t\telse");
          ToLuaExport.sb.AppendLine("\t\t\t{");
          ToLuaExport.sb.AppendFormat("\t\t\t\tLuaDLL.luaL_error(L, \"attempt to index {0} on a nil value\");\r\n", (object) ToLuaExport.props[index].Name);
          ToLuaExport.sb.AppendLine("\t\t\t}");
          ToLuaExport.sb.AppendLine("\t\t}");
          ToLuaExport.sb.AppendLine();
          if (ToLuaExport.type.IsValueType)
            ToLuaExport.sb.AppendFormat("\t\t{0} obj = ({0})o;\r\n", (object) ToLuaExport.className);
        }
        ToLuaExport.NewIndexSetValue(ToLuaExport.props[index].PropertyType, o, ToLuaExport.props[index].Name);
        if (!flag && ToLuaExport.type.IsValueType)
          ToLuaExport.sb.AppendLine("\t\tLuaScriptMgr.SetValueObject(L, 1, obj);");
        ToLuaExport.sb.AppendLine("\t\treturn 0;");
        ToLuaExport.sb.AppendLine("\t}");
      }
    }
  }

  private static void GenDelegateBody(System.Type t, string head, bool haveState)
  {
    ToLuaExport.eventSet.Add(t);
    MethodInfo method = t.GetMethod("Invoke");
    ParameterInfo[] parameters = method.GetParameters();
    int length = parameters.Length;
    if (length == 0)
    {
      ToLuaExport.sb.AppendLine("() =>");
      if ((object) method.ReturnType == (object) typeof (void))
      {
        ToLuaExport.sb.AppendFormat("{0}{{\r\n{0}\tfunc.Call();\r\n{0}}};\r\n", (object) head);
      }
      else
      {
        ToLuaExport.sb.AppendFormat("{0}{{\r\n{0}\tobject[] objs = func.Call();\r\n", (object) head);
        ToLuaExport.sb.AppendFormat("{1}\treturn ({0})objs[0];\r\n", (object) ToLuaExport.GetTypeStr(method.ReturnType), (object) head);
        ToLuaExport.sb.AppendFormat("{0}}};\r\n", (object) head);
      }
    }
    else
    {
      ToLuaExport.sb.AppendFormat("(param0");
      for (int index = 1; index < length; ++index)
        ToLuaExport.sb.AppendFormat(", param{0}", (object) index);
      ToLuaExport.sb.AppendFormat(") =>\r\n{0}{{\r\n{0}", (object) head);
      ToLuaExport.sb.AppendLine("\tint top = func.BeginPCall();");
      if (!haveState)
        ToLuaExport.sb.AppendFormat("{0}\tIntPtr L = func.GetLuaState();\r\n", (object) head);
      for (int index = 0; index < length; ++index)
      {
        string pushFunction = ToLuaExport.GetPushFunction(parameters[index].ParameterType);
        ToLuaExport.sb.AppendFormat("{2}\tLuaScriptMgr.{0}(L, param{1});\r\n", (object) pushFunction, (object) index, (object) head);
      }
      ToLuaExport.sb.AppendFormat("{1}\tfunc.PCall(top, {0});\r\n", (object) length, (object) head);
      if ((object) method.ReturnType == (object) typeof (void))
      {
        ToLuaExport.sb.AppendFormat("{0}\tfunc.EndPCall(top);\r\n", (object) head);
      }
      else
      {
        ToLuaExport.sb.AppendFormat("{0}\tobject[] objs = func.PopValues(top);\r\n", (object) head);
        ToLuaExport.sb.AppendFormat("{0}\tfunc.EndPCall(top);\r\n", (object) head);
        ToLuaExport.sb.AppendFormat("{1}\treturn ({0})objs[0];\r\n", (object) ToLuaExport.GetTypeStr(method.ReturnType), (object) head);
      }
      ToLuaExport.sb.AppendFormat("{0}}};\r\n", (object) head);
    }
  }

  private static void NewIndexSetValue(System.Type t, string o, string name)
  {
    if (t.IsArray)
    {
      System.Type elementType = t.GetElementType();
      string typeStr = ToLuaExport.GetTypeStr(elementType);
      if ((object) elementType == (object) typeof (bool))
        ToLuaExport.sb.AppendFormat("\t\t{0}.{1} = LuaScriptMgr.GetArrayBool(L, 3);\r\n", (object) o, (object) name);
      else if (elementType.IsPrimitive)
        ToLuaExport.sb.AppendFormat("\t\t{0}.{1} = LuaScriptMgr.GetArrayNumber<{2}>(L, 3);\r\n", (object) o, (object) name, (object) typeStr);
      else if ((object) elementType == (object) typeof (string))
      {
        ToLuaExport.sb.AppendFormat("\t\t{0}.{1} = LuaScriptMgr.GetArrayString(L, 3);\r\n", (object) o, (object) name);
      }
      else
      {
        if ((object) elementType == (object) typeof (Object))
          ToLuaExport.ambig |= ObjAmbig.U3dObj;
        ToLuaExport.sb.AppendFormat("\t\t{0}.{1} = LuaScriptMgr.GetArrayObject<{2}>(L, 3);\r\n", (object) o, (object) name, (object) typeStr);
      }
    }
    else if ((object) t == (object) typeof (bool))
      ToLuaExport.sb.AppendFormat("\t\t{0}.{1} = LuaScriptMgr.GetBoolean(L, 3);\r\n", (object) o, (object) name);
    else if ((object) t == (object) typeof (string))
      ToLuaExport.sb.AppendFormat("\t\t{0}.{1} = LuaScriptMgr.GetString(L, 3);\r\n", (object) o, (object) name);
    else if (t.IsPrimitive)
      ToLuaExport.sb.AppendFormat("\t\t{0}.{1} = ({2})LuaScriptMgr.GetNumber(L, 3);\r\n", (object) o, (object) name, (object) ToLuaExport._C(t.ToString()));
    else if ((object) t == (object) typeof (LuaFunction))
      ToLuaExport.sb.AppendFormat("\t\t{0}.{1} = LuaScriptMgr.GetLuaFunction(L, 3);\r\n", (object) o, (object) name);
    else if ((object) t == (object) typeof (LuaTable))
      ToLuaExport.sb.AppendFormat("\t\t{0}.{1} = LuaScriptMgr.GetLuaTable(L, 3);\r\n", (object) o, (object) name);
    else if ((object) t == (object) typeof (object))
      ToLuaExport.sb.AppendFormat("\t\t{0}.{1} = LuaScriptMgr.GetVarObject(L, 3);\r\n", (object) o, (object) name);
    else if ((object) t == (object) typeof (Vector3))
      ToLuaExport.sb.AppendFormat("\t\t{0}.{1} = LuaScriptMgr.GetVector3(L, 3);\r\n", (object) o, (object) name);
    else if ((object) t == (object) typeof (Quaternion))
      ToLuaExport.sb.AppendFormat("\t\t{0}.{1} = LuaScriptMgr.GetQuaternion(L, 3);\r\n", (object) o, (object) name);
    else if ((object) t == (object) typeof (Vector2))
      ToLuaExport.sb.AppendFormat("\t\t{0}.{1} = LuaScriptMgr.GetVector2(L, 3);\r\n", (object) o, (object) name);
    else if ((object) t == (object) typeof (Vector4))
      ToLuaExport.sb.AppendFormat("\t\t{0}.{1} = LuaScriptMgr.GetVector4(L, 3);\r\n", (object) o, (object) name);
    else if ((object) t == (object) typeof (Color))
      ToLuaExport.sb.AppendFormat("\t\t{0}.{1} = LuaScriptMgr.GetColor(L, 3);\r\n", (object) o, (object) name);
    else if ((object) t == (object) typeof (Ray))
      ToLuaExport.sb.AppendFormat("\t\t{0}.{1} = LuaScriptMgr.GetRay(L, 3);\r\n", (object) o, (object) name);
    else if ((object) t == (object) typeof (Bounds))
      ToLuaExport.sb.AppendFormat("\t\t{0}.{1} = LuaScriptMgr.GetBounds(L, 3);\r\n", (object) o, (object) name);
    else if ((object) t == (object) typeof (LuaStringBuffer))
      ToLuaExport.sb.AppendFormat("\t\t{0}.{1} = LuaScriptMgr.GetStringBuffer(L, 3);\r\n", (object) o, (object) name);
    else if (typeof (TrackedReference).IsAssignableFrom(t))
      ToLuaExport.sb.AppendFormat("\t\t{0}.{1} = ({2})LuaScriptMgr.GetTrackedObject(L, 3, typeof(2));\r\n", (object) o, (object) name, (object) ToLuaExport.GetTypeStr(t));
    else if (typeof (Object).IsAssignableFrom(t))
      ToLuaExport.sb.AppendFormat("\t\t{0}.{1} = ({2})LuaScriptMgr.GetUnityObject(L, 3, typeof({2}));\r\n", (object) o, (object) name, (object) ToLuaExport.GetTypeStr(t));
    else if (typeof (Delegate).IsAssignableFrom(t))
    {
      ToLuaExport.sb.AppendLine("\t\tLuaTypes funcType = LuaDLL.lua_type(L, 3);\r\n");
      ToLuaExport.sb.AppendLine("\t\tif (funcType != LuaTypes.LUA_TFUNCTION)");
      ToLuaExport.sb.AppendLine("\t\t{");
      ToLuaExport.sb.AppendFormat("\t\t\t{0}.{1} = ({2})LuaScriptMgr.GetNetObject(L, 3, typeof({2}));\r\n", (object) o, (object) name, (object) ToLuaExport.GetTypeStr(t));
      ToLuaExport.sb.AppendLine("\t\t}\r\n\t\telse");
      ToLuaExport.sb.AppendLine("\t\t{");
      ToLuaExport.sb.AppendLine("\t\t\tLuaFunction func = LuaScriptMgr.ToLuaFunction(L, 3);");
      ToLuaExport.sb.AppendFormat("\t\t\t{0}.{1} = ", (object) o, (object) name);
      ToLuaExport.GenDelegateBody(t, "\t\t\t", true);
      ToLuaExport.sb.AppendLine("\t\t}");
    }
    else if (typeof (object).IsAssignableFrom(t) || t.IsEnum)
      ToLuaExport.sb.AppendFormat("\t\t{0}.{1} = ({2})LuaScriptMgr.GetNetObject(L, 3, typeof({2}));\r\n", (object) o, (object) name, (object) ToLuaExport.GetTypeStr(t));
    else if ((object) t == (object) typeof (System.Type))
      ToLuaExport.sb.AppendFormat("\t\t{0}.{1} = LuaScriptMgr.GetTypeObject(L, 3);\r\n", (object) o, (object) name);
    else
      Debugger.LogError("not defined type {0}", (object) t);
  }

  private static void GenToStringFunc()
  {
    if (Array.FindIndex<MethodInfo>(ToLuaExport.methods, (Predicate<MethodInfo>) (p => p.Name == "ToString")) < 0 || ToLuaExport.isStaticClass)
      return;
    ToLuaExport.sb.AppendLine("\r\n\t[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
    ToLuaExport.sb.AppendLine("\tstatic int Lua_ToString(IntPtr L)");
    ToLuaExport.sb.AppendLine("\t{");
    ToLuaExport.sb.AppendLine("\t\tobject obj = LuaScriptMgr.GetLuaObject(L, 1);\r\n");
    ToLuaExport.sb.AppendLine("\t\tif (obj != null)");
    ToLuaExport.sb.AppendLine("\t\t{");
    ToLuaExport.sb.AppendLine("\t\t\tLuaScriptMgr.Push(L, obj.ToString());");
    ToLuaExport.sb.AppendLine("\t\t}");
    ToLuaExport.sb.AppendLine("\t\telse");
    ToLuaExport.sb.AppendLine("\t\t{");
    ToLuaExport.sb.AppendFormat("\t\t\tLuaScriptMgr.Push(L, \"Table: {0}\");\r\n", (object) ToLuaExport.libClassName);
    ToLuaExport.sb.AppendLine("\t\t}");
    ToLuaExport.sb.AppendLine();
    ToLuaExport.sb.AppendLine("\t\treturn 1;");
    ToLuaExport.sb.AppendLine("\t}");
  }

  private static bool IsNeedOp(string name)
  {
    switch (name)
    {
      case "op_Addition":
        ToLuaExport.op |= MetaOp.Add;
        break;
      case "op_Subtraction":
        ToLuaExport.op |= MetaOp.Sub;
        break;
      case "op_Equality":
        ToLuaExport.op |= MetaOp.Eq;
        break;
      case "op_Multiply":
        ToLuaExport.op |= MetaOp.Mul;
        break;
      case "op_Division":
        ToLuaExport.op |= MetaOp.Div;
        break;
      case "op_UnaryNegation":
        ToLuaExport.op |= MetaOp.Neg;
        break;
      default:
        return false;
    }
    return true;
  }

  private static void CallOpFunction(string name, int count, string ret)
  {
    string empty = string.Empty;
    for (int index = 0; index < count; ++index)
      empty += "\t";
    switch (name)
    {
      case "op_Addition":
        ToLuaExport.sb.AppendFormat("{0}{1} o = arg0 + arg1;\r\n", (object) empty, (object) ret);
        break;
      case "op_Subtraction":
        ToLuaExport.sb.AppendFormat("{0}{1} o = arg0 - arg1;\r\n", (object) empty, (object) ret);
        break;
      case "op_Equality":
        ToLuaExport.sb.AppendFormat("{0}bool o = arg0 == arg1;\r\n", (object) empty);
        break;
      case "op_Multiply":
        ToLuaExport.sb.AppendFormat("{0}{1} o = arg0 * arg1;\r\n", (object) empty, (object) ret);
        break;
      case "op_Division":
        ToLuaExport.sb.AppendFormat("{0}{1} o = arg0 / arg1;\r\n", (object) empty, (object) ret);
        break;
      case "op_UnaryNegation":
        ToLuaExport.sb.AppendFormat("{0}{1} o = -arg0;\r\n", (object) empty, (object) ret);
        break;
    }
  }

  private static string GetFuncName(string name)
  {
    switch (name)
    {
      case "op_Addition":
        return "Lua_Add";
      case "op_Subtraction":
        return "Lua_Sub";
      case "op_Equality":
        return "Lua_Eq";
      case "op_Multiply":
        return "Lua_Mul";
      case "op_Division":
        return "Lua_Div";
      case "op_UnaryNegation":
        return "Lua_Neg";
      default:
        return name;
    }
  }

  public static bool IsObsolete(MemberInfo mb)
  {
    foreach (object customAttribute in mb.GetCustomAttributes(true))
    {
      System.Type type = customAttribute.GetType();
      if ((object) type == (object) typeof (ObsoleteAttribute) || (object) type == (object) typeof (NoToLuaAttribute))
        return true;
    }
    return ToLuaExport.IsMemberFilter(mb);
  }

  public static bool HasAttribute(MemberInfo mb, System.Type atrtype)
  {
    foreach (object customAttribute in mb.GetCustomAttributes(true))
    {
      if ((object) customAttribute.GetType() == (object) atrtype)
        return true;
    }
    return false;
  }

  private static void GenEnum()
  {
    ToLuaExport.fields = ToLuaExport.type.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.GetField);
    List<FieldInfo> fieldInfoList = new List<FieldInfo>((IEnumerable<FieldInfo>) ToLuaExport.fields);
    for (int index = fieldInfoList.Count - 1; index > 0; --index)
    {
      if (ToLuaExport.IsObsolete((MemberInfo) fieldInfoList[index]))
        fieldInfoList.RemoveAt(index);
    }
    ToLuaExport.fields = fieldInfoList.ToArray();
    ToLuaExport.sb.AppendFormat("public class {0}Wrap\r\n", (object) ToLuaExport.wrapClassName);
    ToLuaExport.sb.AppendLine("{");
    ToLuaExport.sb.AppendLine("\tstatic LuaMethod[] enums = new LuaMethod[]");
    ToLuaExport.sb.AppendLine("\t{");
    for (int index = 0; index < ToLuaExport.fields.Length; ++index)
      ToLuaExport.sb.AppendFormat("\t\tnew LuaMethod(\"{0}\", Get{0}),\r\n", (object) ToLuaExport.fields[index].Name);
    ToLuaExport.sb.AppendFormat("\t\tnew LuaMethod(\"IntToEnum\", IntToEnum),\r\n");
    ToLuaExport.sb.AppendLine("\t};");
    ToLuaExport.sb.AppendLine("\r\n\tpublic static void Register(IntPtr L)");
    ToLuaExport.sb.AppendLine("\t{");
    ToLuaExport.sb.AppendFormat("\t\tLuaScriptMgr.RegisterLib(L, \"{0}\", typeof({0}), enums);\r\n", (object) ToLuaExport.libClassName);
    ToLuaExport.sb.AppendLine("\t}");
    for (int index = 0; index < ToLuaExport.fields.Length; ++index)
    {
      ToLuaExport.sb.AppendLine("\r\n\t[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
      ToLuaExport.sb.AppendFormat("\tstatic int Get{0}(IntPtr L)\r\n", (object) ToLuaExport.fields[index].Name);
      ToLuaExport.sb.AppendLine("\t{");
      ToLuaExport.sb.AppendFormat("\t\tLuaScriptMgr.Push(L, {0}.{1});\r\n", (object) ToLuaExport.className, (object) ToLuaExport.fields[index].Name);
      ToLuaExport.sb.AppendLine("\t\treturn 1;");
      ToLuaExport.sb.AppendLine("\t}");
    }
  }

  private static void GenEnumTranslator()
  {
    ToLuaExport.sb.AppendLine("\r\n\t[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
    ToLuaExport.sb.AppendLine("\tstatic int IntToEnum(IntPtr L)");
    ToLuaExport.sb.AppendLine("\t{");
    ToLuaExport.sb.AppendLine("\t\tint arg0 = (int)LuaDLL.lua_tonumber(L, 1);");
    ToLuaExport.sb.AppendFormat("\t\t{0} o = ({0})arg0;\r\n", (object) ToLuaExport.className);
    ToLuaExport.sb.AppendLine("\t\tLuaScriptMgr.Push(L, o);");
    ToLuaExport.sb.AppendLine("\t\treturn 1;");
    ToLuaExport.sb.AppendLine("\t}");
  }

  public static void GenDelegates(DelegateType[] list)
  {
    ToLuaExport.usingList.Add("System");
    ToLuaExport.usingList.Add("System.Collections.Generic");
    for (int index = 0; index < list.Length; ++index)
    {
      System.Type type = list[index].type;
      if (!typeof (Delegate).IsAssignableFrom(type))
      {
        Debug.LogError((object) (type.FullName + " not a delegate type"));
        return;
      }
    }
    ToLuaExport.sb.AppendLine("public static class DelegateFactory");
    ToLuaExport.sb.AppendLine("{");
    ToLuaExport.sb.AppendLine("\tdelegate Delegate DelegateValue(LuaFunction func);");
    ToLuaExport.sb.AppendLine("\tstatic Dictionary<Type, DelegateValue> dict = new Dictionary<Type, DelegateValue>();");
    ToLuaExport.sb.AppendLine();
    ToLuaExport.sb.AppendLine("\t[NoToLuaAttribute]");
    ToLuaExport.sb.AppendLine("\tpublic static void Register(IntPtr L)");
    ToLuaExport.sb.AppendLine("\t{");
    for (int index = 0; index < list.Length; ++index)
    {
      string strType = list[index].strType;
      string name = list[index].name;
      ToLuaExport.sb.AppendFormat("\t\tdict.Add(typeof({0}), new DelegateValue({1}));\r\n", (object) strType, (object) name);
    }
    ToLuaExport.sb.AppendLine("\t}\r\n");
    ToLuaExport.sb.AppendLine("\t[NoToLuaAttribute]");
    ToLuaExport.sb.AppendLine("\tpublic static Delegate CreateDelegate(Type t, LuaFunction func)");
    ToLuaExport.sb.AppendLine("\t{");
    ToLuaExport.sb.AppendLine("\t\tDelegateValue create = null;\r\n");
    ToLuaExport.sb.AppendLine("\t\tif (!dict.TryGetValue(t, out create))");
    ToLuaExport.sb.AppendLine("\t\t{");
    ToLuaExport.sb.AppendLine("\t\t\tDebugger.LogError(\"Delegate {0} not register\", t.FullName);");
    ToLuaExport.sb.AppendLine("\t\t\treturn null;");
    ToLuaExport.sb.AppendLine("\t\t}");
    ToLuaExport.sb.AppendLine("\t\treturn create(func);");
    ToLuaExport.sb.AppendLine("\t}\r\n");
    for (int index = 0; index < list.Length; ++index)
    {
      System.Type type = list[index].type;
      string strType = list[index].strType;
      string name = list[index].name;
      ToLuaExport.sb.AppendFormat("\tpublic static Delegate {0}(LuaFunction func)\r\n", (object) name);
      ToLuaExport.sb.AppendLine("\t{");
      ToLuaExport.sb.AppendFormat("\t\t{0} d = ", (object) strType);
      ToLuaExport.GenDelegateBody(type, "\t\t", false);
      ToLuaExport.sb.AppendLine("\t\treturn d;");
      ToLuaExport.sb.AppendLine("\t}\r\n");
    }
    ToLuaExport.sb.AppendLine("\tpublic static void Clear()");
    ToLuaExport.sb.AppendLine("\t{");
    ToLuaExport.sb.AppendLine("\t\tdict.Clear();");
    ToLuaExport.sb.AppendLine("\t}\r\n");
    ToLuaExport.sb.AppendLine("}");
    ToLuaExport.SaveFile(AppConst.uLuaPath + "/Source/Base/DelegateFactory.cs");
    ToLuaExport.Clear();
  }

  private static string[] GetGenericLibName(System.Type[] types)
  {
    string[] genericLibName = new string[types.Length];
    for (int index = 0; index < types.Length; ++index)
    {
      System.Type type = types[index];
      if (type.IsGenericType)
        genericLibName[index] = ToLuaExport.GetGenericLibName(types[index]);
      else if (type.IsArray)
      {
        System.Type elementType = type.GetElementType();
        genericLibName[index] = ToLuaExport._C(elementType.ToString()) + "s";
      }
      else
        genericLibName[index] = ToLuaExport._C(type.ToString());
    }
    return genericLibName;
  }

  public static string GetGenericLibName(System.Type type)
  {
    System.Type[] genericArguments = type.GetGenericArguments();
    string name = type.Name;
    return ToLuaExport._C(name.Substring(0, name.IndexOf('`'))) + "_" + string.Join("_", ToLuaExport.GetGenericLibName(genericArguments));
  }

  private static void ProcessExtends(List<MethodInfo> list)
  {
    ToLuaExport.extendName = "ToLua_" + ToLuaExport.libClassName.Replace(".", "_");
    ToLuaExport.extendType = System.Type.GetType(ToLuaExport.extendName + ", Assembly-CSharp-Editor");
    if ((object) ToLuaExport.extendType == null)
      return;
    List<MethodInfo> list2 = new List<MethodInfo>();
    list2.AddRange((IEnumerable<MethodInfo>) ToLuaExport.extendType.GetMethods(BindingFlags.Instance | ToLuaExport.binding | BindingFlags.DeclaredOnly));
    for (int i = list2.Count - 1; i >= 0; --i)
    {
      if (!list2[i].Name.Contains("op_") && !list2[i].Name.Contains("add_") && !list2[i].Name.Contains("remove_") || ToLuaExport.IsNeedOp(list2[i].Name))
      {
        list.RemoveAll((Predicate<MethodInfo>) (md => md.Name == list2[i].Name));
        if (!ToLuaExport.IsObsolete((MemberInfo) list2[i]))
          list.Add(list2[i]);
      }
    }
  }
}
