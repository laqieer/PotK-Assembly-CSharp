// Decompiled with JetBrains decompiler
// Type: GameCore.Stat.MatchingServerStat
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
namespace GameCore.Stat
{
  public class MatchingServerStat
  {
    public int peer_count;

    public object ToJson()
    {
      return (object) new Dictionary<string, object>()
      {
        {
          "peer_count",
          (object) this.peer_count
        }
      };
    }

    public void FromJson(object obj)
    {
      this.peer_count = (int) (long) ((IDictionary<string, object>) obj)["peer_count"];
    }
  }
}
