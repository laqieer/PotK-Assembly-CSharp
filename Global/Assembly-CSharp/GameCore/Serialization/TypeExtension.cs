// Decompiled with JetBrains decompiler
// Type: GameCore.Serialization.TypeExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace GameCore.Serialization
{
  internal static class TypeExtension
  {
    public static List<FieldInfo> GetAllFields(this Type type)
    {
      List<FieldInfo> allFields = new List<FieldInfo>();
      do
      {
        allFields.AddRange((IEnumerable<FieldInfo>) type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
        type = type.BaseType;
      }
      while ((object) type != (object) typeof (object));
      return allFields;
    }

    public static bool IsBlob(this Type type)
    {
      CrossSerializer.Specialized.Value obj;
      return CrossSerializer.Specialized.TryGetValue(type, out obj) || type.IsGenericType && CrossSerializer.Specialized.TryGetValue(type.GetGenericTypeDefinition(), out obj) || !type.IsArray && type.IsEnum;
    }
  }
}
