﻿// Decompiled with JetBrains decompiler
// Type: Com.Google.Android.Gms.Games.Stats.PlayerStatsObject
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using Google.Developers;
using System;

#nullable disable
namespace Com.Google.Android.Gms.Games.Stats
{
  public class PlayerStatsObject : JavaObjWrapper, PlayerStats
  {
    private const string CLASS_NAME = "com/google/android/gms/games/stats/PlayerStats";

    public PlayerStatsObject(IntPtr ptr)
      : base(ptr)
    {
    }

    public static float UNSET_VALUE
    {
      get
      {
        return JavaObjWrapper.GetStaticFloatField("com/google/android/gms/games/stats/PlayerStats", nameof (UNSET_VALUE));
      }
    }

    public static int CONTENTS_FILE_DESCRIPTOR
    {
      get
      {
        return JavaObjWrapper.GetStaticIntField("com/google/android/gms/games/stats/PlayerStats", nameof (CONTENTS_FILE_DESCRIPTOR));
      }
    }

    public static int PARCELABLE_WRITE_RETURN_VALUE
    {
      get
      {
        return JavaObjWrapper.GetStaticIntField("com/google/android/gms/games/stats/PlayerStats", nameof (PARCELABLE_WRITE_RETURN_VALUE));
      }
    }

    public float getAverageSessionLength()
    {
      return this.InvokeCall<float>(nameof (getAverageSessionLength), "()F");
    }

    public float getChurnProbability()
    {
      return this.InvokeCall<float>(nameof (getChurnProbability), "()F");
    }

    public int getDaysSinceLastPlayed()
    {
      return this.InvokeCall<int>(nameof (getDaysSinceLastPlayed), "()I");
    }

    public int getNumberOfPurchases() => this.InvokeCall<int>(nameof (getNumberOfPurchases), "()I");

    public int getNumberOfSessions() => this.InvokeCall<int>(nameof (getNumberOfSessions), "()I");

    public float getSessionPercentile()
    {
      return this.InvokeCall<float>(nameof (getSessionPercentile), "()F");
    }

    public float getSpendPercentile() => this.InvokeCall<float>(nameof (getSpendPercentile), "()F");

    public float getSpendProbability()
    {
      return this.InvokeCall<float>(nameof (getSpendProbability), "()F");
    }

    public float getHighSpenderProbability()
    {
      return this.InvokeCall<float>(nameof (getHighSpenderProbability), "()F");
    }

    public float getTotalSpendNext28Days()
    {
      return this.InvokeCall<float>(nameof (getTotalSpendNext28Days), "()F");
    }
  }
}
