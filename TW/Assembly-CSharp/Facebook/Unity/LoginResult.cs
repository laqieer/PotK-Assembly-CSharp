// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.LoginResult
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace Facebook.Unity
{
  internal class LoginResult : ResultBase, ILoginResult, IResult
  {
    public static readonly string UserIdKey = !Constants.IsWeb ? "user_id" : "userID";
    public static readonly string ExpirationTimestampKey = !Constants.IsWeb ? "expiration_timestamp" : "expiresIn";
    public static readonly string PermissionsKey = !Constants.IsWeb ? "permissions" : "grantedScopes";
    public static readonly string AccessTokenKey = !Constants.IsWeb ? "access_token" : "accessToken";

    internal LoginResult(string response)
      : base(response)
    {
      if (this.ResultDictionary == null || !this.ResultDictionary.ContainsKey(LoginResult.AccessTokenKey))
        return;
      this.AccessToken = LoginResult.ParseAccessTokenFromResult(this.ResultDictionary);
    }

    public AccessToken AccessToken { get; private set; }

    private static AccessToken ParseAccessTokenFromResult(
      IDictionary<string, object> resultDictionary)
    {
      string valueOrDefault1 = resultDictionary.GetValueOrDefault<string>(LoginResult.UserIdKey);
      string valueOrDefault2 = resultDictionary.GetValueOrDefault<string>(LoginResult.AccessTokenKey);
      DateTime expirationDateFromResult = LoginResult.ParseExpirationDateFromResult(resultDictionary);
      ICollection<string> permissionFromResult = LoginResult.ParsePermissionFromResult(resultDictionary);
      return new AccessToken(valueOrDefault2, valueOrDefault1, expirationDateFromResult, (IEnumerable<string>) permissionFromResult);
    }

    private static DateTime ParseExpirationDateFromResult(
      IDictionary<string, object> resultDictionary)
    {
      int result;
      return !Constants.IsWeb ? (!int.TryParse(resultDictionary.GetValueOrDefault<string>(LoginResult.ExpirationTimestampKey), out result) || result <= 0 ? DateTime.MaxValue : LoginResult.FromTimestamp(result)) : DateTime.Now.AddSeconds((double) resultDictionary.GetValueOrDefault<long>(LoginResult.ExpirationTimestampKey));
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

    private AccessToken ParseAccessTokeFromResponse()
    {
      if (this.ResultDictionary == null || !this.ResultDictionary.ContainsKey("user_id"))
        return (AccessToken) null;
      string result1 = (string) this.ResultDictionary["user_id"];
      string result2 = (string) this.ResultDictionary["access_token"];
      int result3;
      DateTime expirationTime = !int.TryParse((string) this.ResultDictionary["expiration_timestamp"], out result3) || result3 <= 0 ? DateTime.MaxValue : LoginResult.FromTimestamp(result3);
      ICollection<string> permissions;
      if (this.ResultDictionary["permissions"] is string result4)
      {
        char[] chArray = new char[1]{ ',' };
        permissions = (ICollection<string>) result4.Split(chArray);
      }
      else
        permissions = (ICollection<string>) ((IEnumerable<object>) this.ResultDictionary["permissions"]).Select<object, string>((Func<object, string>) (permission => permission.ToString())).ToList<string>();
      return new AccessToken(result2, result1, expirationTime, (IEnumerable<string>) permissions);
    }
  }
}
