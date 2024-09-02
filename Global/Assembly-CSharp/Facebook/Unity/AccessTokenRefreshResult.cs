﻿// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.AccessTokenRefreshResult
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
namespace Facebook.Unity
{
  internal class AccessTokenRefreshResult : ResultBase, IAccessTokenRefreshResult, IResult
  {
    public AccessTokenRefreshResult(ResultContainer resultContainer)
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
