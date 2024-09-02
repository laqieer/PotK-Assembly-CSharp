// Decompiled with JetBrains decompiler
// Type: LuaInterface.LuaRegistrationHelper
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

#nullable disable
namespace LuaInterface
{
  public static class LuaRegistrationHelper
  {
    public static void TaggedInstanceMethods(LuaState lua, object o)
    {
      if (lua == null)
        throw new ArgumentNullException(nameof (lua));
      if (o == null)
        throw new ArgumentNullException(nameof (o));
      foreach (MethodInfo method in o.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public))
      {
        foreach (LuaGlobalAttribute customAttribute in method.GetCustomAttributes(typeof (LuaGlobalAttribute), true))
        {
          if (string.IsNullOrEmpty(customAttribute.Name))
            lua.RegisterFunction(method.Name, o, (MethodBase) method);
          else
            lua.RegisterFunction(customAttribute.Name, o, (MethodBase) method);
        }
      }
    }

    public static void TaggedStaticMethods(LuaState lua, Type type)
    {
      if (lua == null)
        throw new ArgumentNullException(nameof (lua));
      if ((object) type == null)
        throw new ArgumentNullException(nameof (type));
      if (!type.IsClass)
        throw new ArgumentException("The type must be a class!", nameof (type));
      foreach (MethodInfo method in type.GetMethods(BindingFlags.Static | BindingFlags.Public))
      {
        foreach (LuaGlobalAttribute customAttribute in method.GetCustomAttributes(typeof (LuaGlobalAttribute), false))
        {
          if (string.IsNullOrEmpty(customAttribute.Name))
            lua.RegisterFunction(method.Name, (object) null, (MethodBase) method);
          else
            lua.RegisterFunction(customAttribute.Name, (object) null, (MethodBase) method);
        }
      }
    }

    [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The type parameter is used to select an enum type")]
    public static void Enumeration<T>(LuaState lua)
    {
      if (lua == null)
        throw new ArgumentNullException(nameof (lua));
      Type enumType = typeof (T);
      string[] strArray = enumType.IsEnum ? Enum.GetNames(enumType) : throw new ArgumentException("The type must be an enumeration!");
      T[] values = (T[]) Enum.GetValues(enumType);
      lua.NewTable(enumType.Name);
      for (int index = 0; index < strArray.Length; ++index)
      {
        string fullPath = enumType.Name + "." + strArray[index];
        lua[fullPath] = (object) values[index];
      }
    }
  }
}
