﻿// Decompiled with JetBrains decompiler
// Type: Gsc.Auth.GAuth.GAuth.API.Request.Passcode
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using Gsc.Network.Support.MiniJsonHelper;
using System;
using System.Collections.Generic;

namespace Gsc.Auth.GAuth.GAuth.API.Request
{
  public class Passcode : Gsc.Network.Request<Passcode, Gsc.Auth.GAuth.GAuth.API.Response.Passcode>
  {
    private const string ___path = "/passcode";

    public string SecretKey { get; set; }

    public string DeviceId { get; set; }

    public Passcode(string secretKey, string deviceId)
    {
      this.SecretKey = secretKey;
      this.DeviceId = deviceId;
    }

    public override string GetPath() => SDK.Configuration.Env.AuthApiPrefix + "/passcode";

    public override string GetMethod() => "POST";

    protected override Dictionary<string, object> GetParameters() => new Dictionary<string, object>()
    {
      ["secret_key"] = Serializer.Instance.Add<string>(new Func<string, object>(Serializer.From<string>)).Serialize<string>(this.SecretKey),
      ["device_id"] = Serializer.Instance.Add<string>(new Func<string, object>(Serializer.From<string>)).Serialize<string>(this.DeviceId)
    };
  }
}
