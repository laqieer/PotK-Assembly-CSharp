// Decompiled with JetBrains decompiler
// Type: GameCore.TypeInfoCache
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
namespace GameCore
{
  internal static class TypeInfoCache
  {
    private static Dictionary<string, TypeInfo> cache = new Dictionary<string, TypeInfo>();

    public static void Register(string key, TypeInfo value)
    {
      lock (TypeInfoCache.cache)
      {
        if (TypeInfoCache.cache.Count > 1000)
          TypeInfoCache.cache.Clear();
        TypeInfoCache.cache[key] = value;
      }
    }

    public static bool TryGetValue(string key, out TypeInfo value)
    {
      lock (TypeInfoCache.cache)
        return TypeInfoCache.cache.TryGetValue(key, out value);
    }
  }
}
