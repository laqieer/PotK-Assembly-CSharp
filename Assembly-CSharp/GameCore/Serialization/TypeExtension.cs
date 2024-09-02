// Decompiled with JetBrains decompiler
// Type: GameCore.Serialization.TypeExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Reflection;

namespace GameCore.Serialization
{
  internal static class TypeExtension
  {
    public static List<FieldInfo> GetAllFields(this System.Type type)
    {
      List<FieldInfo> fieldInfoList = new List<FieldInfo>();
      do
      {
        fieldInfoList.AddRange((IEnumerable<FieldInfo>) type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
        type = type.BaseType;
      }
      while (type != typeof (object));
      return fieldInfoList;
    }

    public static bool IsBlob(this System.Type type)
    {
      CrossSerializer.Specialized.Value obj;
      return CrossSerializer.Specialized.TryGetValue(type, out obj) || type.IsGenericType && CrossSerializer.Specialized.TryGetValue(type.GetGenericTypeDefinition(), out obj) || !type.IsArray && type.IsEnum;
    }
  }
}
