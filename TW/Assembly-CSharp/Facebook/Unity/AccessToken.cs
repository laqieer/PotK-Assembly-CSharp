// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.AccessToken
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using Facebook.MiniJSON;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace Facebook.Unity
{
  public class AccessToken
  {
    public AccessToken(
      string tokenString,
      string userId,
      DateTime expirationTime,
      IEnumerable<string> permissions)
    {
      if (string.IsNullOrEmpty(tokenString))
        throw new ArgumentNullException(nameof (tokenString));
      if (string.IsNullOrEmpty(userId))
        throw new ArgumentNullException(nameof (userId));
      if (expirationTime == DateTime.MinValue)
        throw new ArgumentException("Expiration time is unassigned");
      if (permissions == null)
        throw new ArgumentNullException(nameof (permissions));
      this.TokenString = tokenString;
      this.ExpirationTime = expirationTime;
      this.Permissions = permissions;
      this.UserId = userId;
    }

    public static AccessToken CurrentAccessToken { get; internal set; }

    public string TokenString { get; internal set; }

    public DateTime ExpirationTime { get; internal set; }

    public IEnumerable<string> Permissions { get; internal set; }

    public string UserId { get; internal set; }

    internal string ToJson()
    {
      return Json.Serialize((object) new Dictionary<string, string>()
      {
        [LoginResult.PermissionsKey] = string.Join(",", this.Permissions.ToArray<string>()),
        [LoginResult.ExpirationTimestampKey] = this.ExpirationTime.TotalSeconds().ToString(),
        [LoginResult.AccessTokenKey] = this.TokenString,
        [LoginResult.UserIdKey] = this.UserId
      });
    }
  }
}
