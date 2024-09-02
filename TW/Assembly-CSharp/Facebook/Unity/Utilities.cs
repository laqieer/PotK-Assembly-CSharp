// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Utilities
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace Facebook.Unity
{
  internal static class Utilities
  {
    private const string WarningMissingParameter = "Did not find expected value '{0}' in dictionary";

    public static bool TryGetValue<T>(
      this IDictionary<string, object> dictionary,
      string key,
      out T value)
    {
      object obj1;
      if (dictionary.TryGetValue(key, out obj1) && obj1 is T obj2)
      {
        value = obj2;
        return true;
      }
      value = default (T);
      return false;
    }

    public static long TotalSeconds(this DateTime dateTime)
    {
      return (long) (dateTime - new DateTime(1970, 1, 1)).TotalSeconds;
    }

    public static T GetValueOrDefault<T>(
      this IDictionary<string, object> dictionary,
      string key,
      bool logWarning = true)
    {
      T valueOrDefault;
      if (!dictionary.TryGetValue<T>(key, out valueOrDefault))
        FacebookLogger.Warn("Did not find expected value '{0}' in dictionary", key);
      return valueOrDefault;
    }

    public static string ToCommaSeparateList(this IEnumerable<string> list)
    {
      return list == null ? string.Empty : string.Join(",", list.ToArray<string>());
    }

    public static string AbsoluteUrlOrEmptyString(this Uri uri)
    {
      return uri == (Uri) null ? string.Empty : uri.AbsoluteUri;
    }
  }
}
