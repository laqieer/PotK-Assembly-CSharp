﻿// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.Cwrapper.TurnBasedMatchConfigBuilder
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace GooglePlayGames.Native.Cwrapper
{
  internal static class TurnBasedMatchConfigBuilder
  {
    [DllImport("gpg")]
    internal static extern void TurnBasedMatchConfig_Builder_PopulateFromPlayerSelectUIResponse(
      HandleRef self,
      IntPtr response);

    [DllImport("gpg")]
    internal static extern void TurnBasedMatchConfig_Builder_SetVariant(
      HandleRef self,
      uint variant);

    [DllImport("gpg")]
    internal static extern void TurnBasedMatchConfig_Builder_AddPlayerToInvite(
      HandleRef self,
      string player_id);

    [DllImport("gpg")]
    internal static extern IntPtr TurnBasedMatchConfig_Builder_Construct();

    [DllImport("gpg")]
    internal static extern void TurnBasedMatchConfig_Builder_SetExclusiveBitMask(
      HandleRef self,
      ulong exclusive_bit_mask);

    [DllImport("gpg")]
    internal static extern void TurnBasedMatchConfig_Builder_SetMaximumAutomatchingPlayers(
      HandleRef self,
      uint maximum_automatching_players);

    [DllImport("gpg")]
    internal static extern IntPtr TurnBasedMatchConfig_Builder_Create(HandleRef self);

    [DllImport("gpg")]
    internal static extern void TurnBasedMatchConfig_Builder_SetMinimumAutomatchingPlayers(
      HandleRef self,
      uint minimum_automatching_players);

    [DllImport("gpg")]
    internal static extern void TurnBasedMatchConfig_Builder_Dispose(HandleRef self);
  }
}
