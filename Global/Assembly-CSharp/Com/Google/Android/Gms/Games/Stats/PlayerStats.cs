// Decompiled with JetBrains decompiler
// Type: Com.Google.Android.Gms.Games.Stats.PlayerStats
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

#nullable disable
namespace Com.Google.Android.Gms.Games.Stats
{
  public interface PlayerStats
  {
    float getAverageSessionLength();

    float getChurnProbability();

    int getDaysSinceLastPlayed();

    int getNumberOfPurchases();

    int getNumberOfSessions();

    float getSessionPercentile();

    float getSpendPercentile();

    float getSpendProbability();

    float getHighSpenderProbability();

    float getTotalSpendNext28Days();
  }
}
