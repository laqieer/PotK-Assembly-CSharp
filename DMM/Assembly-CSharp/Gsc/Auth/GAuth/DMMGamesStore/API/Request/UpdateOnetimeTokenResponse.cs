﻿// Decompiled with JetBrains decompiler
// Type: Gsc.Auth.GAuth.DMMGamesStore.API.Request.UpdateOnetimeTokenResponse
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using Gsc.Network.Support.MiniJsonHelper;
using System;
using System.Collections.Generic;

namespace Gsc.Auth.GAuth.DMMGamesStore.API.Request
{
  public class UpdateOnetimeTokenResponse : Gsc.Network.Response<UpdateOnetimeTokenResponse>
  {
    public string OnetimeToken { get; private set; }

    public UpdateOnetimeTokenResponse(byte[] payload)
    {
      Dictionary<string, object> result = Gsc.Network.Response<UpdateOnetimeTokenResponse>.GetResult(payload);
      this.OnetimeToken = Deserializer.Instance.Add<string>(new Func<object, string>(Deserializer.To<string>)).Deserialize<string>(result["dmm_onetime_token"]);
    }
  }
}
