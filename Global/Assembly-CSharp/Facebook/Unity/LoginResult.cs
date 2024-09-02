// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.LoginResult
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
namespace Facebook.Unity
{
  internal class LoginResult : ResultBase, ILoginResult, IResult
  {
    public const string LastRefreshKey = "last_refresh";
    public static readonly string UserIdKey = !Constants.IsWeb ? "user_id" : "userID";
    public static readonly string ExpirationTimestampKey = !Constants.IsWeb ? "expiration_timestamp" : "expiresIn";
    public static readonly string PermissionsKey = !Constants.IsWeb ? "permissions" : "grantedScopes";
    public static readonly string AccessTokenKey = !Constants.IsWeb ? "access_token" : "accessToken";

    internal LoginResult(ResultContainer resultContainer)
      : base(resultContainer)
    {
      if (this.ResultDictionary == null || !this.ResultDictionary.ContainsKey(LoginResult.AccessTokenKey))
        return;
      this.AccessToken = Utilities.ParseAccessTokenFromResult(this.ResultDictionary);
    }

    public AccessToken AccessToken { get; private set; }

    public override string ToString()
    {
      return Utilities.FormatToString(base.ToString(), this.GetType().Name, (IDictionary<string, string>) new Dictionary<string, string>()
      {
        {
          "AccessToken",
          this.AccessToken.ToStringNullOk()
        }
      });
    }
  }
}
