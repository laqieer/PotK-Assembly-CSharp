﻿// Decompiled with JetBrains decompiler
// Type: Gsc.Auth.GAuth.DMMGamesStore.API.Request.AccessToken
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using Gsc.Network.Support.MiniJsonHelper;
using System;
using System.Collections.Generic;

namespace Gsc.Auth.GAuth.DMMGamesStore.API.Request
{
  public class AccessToken : Gsc.Network.Request<AccessToken, Gsc.Auth.GAuth.GAuth.API.Response.AccessToken>
  {
    private const string ___path = "{0}/dmm-auth-proxy/{1}/get_access_token";

    public int ViewerID { get; set; }

    public string OnetimeToken { get; set; }

    public AccessToken(int viewerId, string onetimeToken)
    {
      this.ViewerID = viewerId;
      this.OnetimeToken = onetimeToken;
    }

    public override string GetUrl() => string.Format("{0}/dmm-auth-proxy/{1}/get_access_token", (object) SDK.Configuration.Env.NativeBaseUrl, (object) SDK.Configuration.AppName);

    public override string GetPath() => "{0}/dmm-auth-proxy/{1}/get_access_token";

    public override string GetMethod() => "POST";

    protected override Dictionary<string, object> GetParameters() => new Dictionary<string, object>()
    {
      ["dmm_viewer_id"] = Serializer.Instance.Add<int>(new Func<int, object>(Serializer.From<int>)).Serialize<int>(this.ViewerID),
      ["dmm_onetime_token"] = Serializer.Instance.Add<string>(new Func<string, object>(Serializer.From<string>)).Serialize<string>(this.OnetimeToken),
      ["udid"] = (object) "",
      ["idfa"] = (object) "",
      ["idfv"] = (object) ""
    };
  }
}
