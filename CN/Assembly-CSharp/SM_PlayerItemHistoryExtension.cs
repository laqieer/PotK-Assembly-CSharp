// Decompiled with JetBrains decompiler
// Type: SM_PlayerItemHistoryExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
public static class SM_PlayerItemHistoryExtension
{
  public static PlayerItemHistory[] AllGears(this PlayerItemHistory[] self)
  {
    return ((IEnumerable<PlayerItemHistory>) self).Where<PlayerItemHistory>((Func<PlayerItemHistory, bool>) (pi => pi.gear != null)).ToArray<PlayerItemHistory>();
  }

  public static PlayerItemHistory[] AllItems(this PlayerItemHistory[] self)
  {
    return ((IEnumerable<PlayerItemHistory>) self).Where<PlayerItemHistory>((Func<PlayerItemHistory, bool>) (pi => pi.item != null)).ToArray<PlayerItemHistory>();
  }
}
