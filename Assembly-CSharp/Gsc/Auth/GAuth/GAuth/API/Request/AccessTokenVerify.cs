// Decompiled with JetBrains decompiler
// Type: Gsc.Auth.GAuth.GAuth.API.Request.AccessTokenVerify
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

namespace Gsc.Auth.GAuth.GAuth.API.Request
{
  public class AccessTokenVerify : Gsc.Network.Request<AccessTokenVerify, Gsc.Auth.GAuth.GAuth.API.Response.AccessTokenVerify>
  {
    private const string ___path = "/v2/accesstoken/verify";

    public override string GetPath() => SDK.Configuration.Env.AuthApiPrefix + "/v2/accesstoken/verify";

    public override string GetMethod() => "POST";
  }
}
