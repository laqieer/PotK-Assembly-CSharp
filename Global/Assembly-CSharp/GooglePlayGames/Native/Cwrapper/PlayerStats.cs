﻿// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.Cwrapper.PlayerStats
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Runtime.InteropServices;

#nullable disable
namespace GooglePlayGames.Native.Cwrapper
{
  internal static class PlayerStats
  {
    [DllImport("gpg")]
    [return: MarshalAs(UnmanagedType.I1)]
    internal static extern bool PlayerStats_Valid(HandleRef self);

    [DllImport("gpg")]
    internal static extern void PlayerStats_Dispose(HandleRef self);

    [DllImport("gpg")]
    [return: MarshalAs(UnmanagedType.I1)]
    internal static extern bool PlayerStats_HasAverageSessionLength(HandleRef self);

    [DllImport("gpg")]
    internal static extern float PlayerStats_AverageSessionLength(HandleRef self);

    [DllImport("gpg")]
    [return: MarshalAs(UnmanagedType.I1)]
    internal static extern bool PlayerStats_HasChurnProbability(HandleRef self);

    [DllImport("gpg")]
    internal static extern float PlayerStats_ChurnProbability(HandleRef self);

    [DllImport("gpg")]
    [return: MarshalAs(UnmanagedType.I1)]
    internal static extern bool PlayerStats_HasDaysSinceLastPlayed(HandleRef self);

    [DllImport("gpg")]
    internal static extern int PlayerStats_DaysSinceLastPlayed(HandleRef self);

    [DllImport("gpg")]
    [return: MarshalAs(UnmanagedType.I1)]
    internal static extern bool PlayerStats_HasNumberOfPurchases(HandleRef self);

    [DllImport("gpg")]
    internal static extern int PlayerStats_NumberOfPurchases(HandleRef self);

    [DllImport("gpg")]
    [return: MarshalAs(UnmanagedType.I1)]
    internal static extern bool PlayerStats_HasNumberOfSessions(HandleRef self);

    [DllImport("gpg")]
    internal static extern int PlayerStats_NumberOfSessions(HandleRef self);

    [DllImport("gpg")]
    [return: MarshalAs(UnmanagedType.I1)]
    internal static extern bool PlayerStats_HasSessionPercentile(HandleRef self);

    [DllImport("gpg")]
    internal static extern float PlayerStats_SessionPercentile(HandleRef self);

    [DllImport("gpg")]
    [return: MarshalAs(UnmanagedType.I1)]
    internal static extern bool PlayerStats_HasSpendPercentile(HandleRef self);

    [DllImport("gpg")]
    internal static extern float PlayerStats_SpendPercentile(HandleRef self);
  }
}
