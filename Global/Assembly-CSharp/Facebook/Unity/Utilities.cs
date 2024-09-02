// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Utilities
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using Facebook.MiniJSON;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

#nullable disable
namespace Facebook.Unity
{
  internal static class Utilities
  {
    private const string WarningMissingParameter = "Did not find expected value '{0}' in dictionary";
    private static Dictionary<string, string> commandLineArguments;

    public static Dictionary<string, string> CommandLineArguments
    {
      get
      {
        if (Utilities.commandLineArguments != null)
          return Utilities.commandLineArguments;
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        string[] commandLineArgs = Environment.GetCommandLineArgs();
        for (int index = 0; index < commandLineArgs.Length; ++index)
        {
          if (commandLineArgs[index].StartsWith("/") || commandLineArgs[index].StartsWith("-"))
          {
            string str = index + 1 >= commandLineArgs.Length ? (string) null : commandLineArgs[index + 1];
            dictionary.Add(commandLineArgs[index], str);
          }
        }
        Utilities.commandLineArguments = dictionary;
        return Utilities.commandLineArguments;
      }
    }

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
      return (long) (dateTime - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
    }

    public static T GetValueOrDefault<T>(
      this IDictionary<string, object> dictionary,
      string key,
      bool logWarning = true)
    {
      T valueOrDefault;
      if (!dictionary.TryGetValue<T>(key, out valueOrDefault) && logWarning)
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

    public static string GetUserAgent(string productName, string productVersion)
    {
      return string.Format((IFormatProvider) CultureInfo.InvariantCulture, "{0}/{1}", new object[2]
      {
        (object) productName,
        (object) productVersion
      });
    }

    public static string ToJson(this IDictionary<string, object> dictionary)
    {
      return Json.Serialize((object) dictionary);
    }

    public static void AddAllKVPFrom<T1, T2>(
      this IDictionary<T1, T2> dest,
      IDictionary<T1, T2> source)
    {
      foreach (T1 key in (IEnumerable<T1>) source.Keys)
        dest[key] = source[key];
    }

    public static AccessToken ParseAccessTokenFromResult(
      IDictionary<string, object> resultDictionary)
    {
      string valueOrDefault1 = resultDictionary.GetValueOrDefault<string>(LoginResult.UserIdKey);
      string valueOrDefault2 = resultDictionary.GetValueOrDefault<string>(LoginResult.AccessTokenKey);
      DateTime expirationDateFromResult = Utilities.ParseExpirationDateFromResult(resultDictionary);
      ICollection<string> permissionFromResult = Utilities.ParsePermissionFromResult(resultDictionary);
      DateTime? refreshFromResult = Utilities.ParseLastRefreshFromResult(resultDictionary);
      return new AccessToken(valueOrDefault2, valueOrDefault1, expirationDateFromResult, (IEnumerable<string>) permissionFromResult, refreshFromResult);
    }

    public static string ToStringNullOk(this object obj) => obj == null ? "null" : obj.ToString();

    public static string FormatToString(
      string baseString,
      string className,
      IDictionary<string, string> propertiesAndValues)
    {
      StringBuilder stringBuilder = new StringBuilder();
      if (baseString != null)
        stringBuilder.Append(baseString);
      stringBuilder.AppendFormat("\n{0}:", (object) className);
      foreach (KeyValuePair<string, string> propertiesAndValue in (IEnumerable<KeyValuePair<string, string>>) propertiesAndValues)
      {
        string str = propertiesAndValue.Value == null ? "null" : propertiesAndValue.Value;
        stringBuilder.AppendFormat("\n\t{0}: {1}", (object) propertiesAndValue.Key, (object) str);
      }
      return stringBuilder.ToString();
    }

    private static DateTime ParseExpirationDateFromResult(
      IDictionary<string, object> resultDictionary)
    {
      int result;
      return !Constants.IsWeb ? (!int.TryParse(resultDictionary.GetValueOrDefault<string>(LoginResult.ExpirationTimestampKey), out result) || result <= 0 ? DateTime.MaxValue : Utilities.FromTimestamp(result)) : DateTime.UtcNow.AddSeconds((double) resultDictionary.GetValueOrDefault<long>(LoginResult.ExpirationTimestampKey));
    }

    private static DateTime? ParseLastRefreshFromResult(IDictionary<string, object> resultDictionary)
    {
      int result;
      return int.TryParse(resultDictionary.GetValueOrDefault<string>("last_refresh", false), out result) && result > 0 ? new DateTime?(Utilities.FromTimestamp(result)) : new DateTime?();
    }

    private static ICollection<string> ParsePermissionFromResult(
      IDictionary<string, object> resultDictionary)
    {
      string str;
      IEnumerable<object> source;
      if (resultDictionary.TryGetValue<string>(LoginResult.PermissionsKey, out str))
        source = (IEnumerable<object>) str.Split(',');
      else if (!resultDictionary.TryGetValue<IEnumerable<object>>(LoginResult.PermissionsKey, out source))
      {
        source = (IEnumerable<object>) new string[0];
        FacebookLogger.Warn("Failed to find parameter '{0}' in login result", LoginResult.PermissionsKey);
      }
      return (ICollection<string>) source.Select<object, string>((Func<object, string>) (permission => permission.ToString())).ToList<string>();
    }

    private static DateTime FromTimestamp(int timestamp)
    {
      return new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds((double) timestamp);
    }

    public delegate void Callback<T>(T obj);
  }
}
