﻿// Decompiled with JetBrains decompiler
// Type: GameCore.Stat.MatchingServerStat
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

namespace GameCore.Stat
{
  public class MatchingServerStat
  {
    public int peer_count;

    public object ToJson() => (object) new Dictionary<string, object>()
    {
      {
        "peer_count",
        (object) this.peer_count
      }
    };

    public void FromJson(object obj) => this.peer_count = (int) (long) ((IDictionary<string, object>) obj)["peer_count"];
  }
}
