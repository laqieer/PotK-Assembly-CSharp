// Decompiled with JetBrains decompiler
// Type: GameCore.Serialization.TypeExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
