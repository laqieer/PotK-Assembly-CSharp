// Decompiled with JetBrains decompiler
// Type: SM_PlayerItemHistoryExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using SM;
using System;
using System.Collections.Generic;
using UniLinq;

public static class SM_PlayerItemHistoryExtension
{
  public static PlayerItemHistory[] AllGears(this PlayerItemHistory[] self) => ((IEnumerable<PlayerItemHistory>) self).Where<PlayerItemHistory>((Func<PlayerItemHistory, bool>) (pi => pi.gear != null)).ToArray<PlayerItemHistory>();

  public static PlayerItemHistory[] AllItems(this PlayerItemHistory[] self) => ((IEnumerable<PlayerItemHistory>) self).Where<PlayerItemHistory>((Func<PlayerItemHistory, bool>) (pi => pi.item != null)).ToArray<PlayerItemHistory>();
}
