// Decompiled with JetBrains decompiler
// Type: Com.Google.Android.Gms.Games.Stats.Stats
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using Com.Google.Android.Gms.Common.Api;

#nullable disable
namespace Com.Google.Android.Gms.Games.Stats
{
  public interface Stats
  {
    PendingResult<Stats_LoadPlayerStatsResultObject> loadPlayerStats(
      GoogleApiClient arg_GoogleApiClient_1,
      bool arg_bool_2);
  }
}
