﻿// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.Cwrapper.MultiplayerParticipant
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;
using System.Text;

#nullable disable
namespace GooglePlayGames.Native.Cwrapper
{
  internal static class MultiplayerParticipant
  {
    [DllImport("gpg")]
    internal static extern Types.ParticipantStatus MultiplayerParticipant_Status(HandleRef self);

    [DllImport("gpg")]
    internal static extern uint MultiplayerParticipant_MatchRank(HandleRef self);

    [DllImport("gpg")]
    [return: MarshalAs(UnmanagedType.I1)]
    internal static extern bool MultiplayerParticipant_IsConnectedToRoom(HandleRef self);

    [DllImport("gpg")]
    internal static extern UIntPtr MultiplayerParticipant_DisplayName(
      HandleRef self,
      StringBuilder out_arg,
      UIntPtr out_size);

    [DllImport("gpg")]
    [return: MarshalAs(UnmanagedType.I1)]
    internal static extern bool MultiplayerParticipant_HasPlayer(HandleRef self);

    [DllImport("gpg")]
    internal static extern UIntPtr MultiplayerParticipant_AvatarUrl(
      HandleRef self,
      Types.ImageResolution resolution,
      StringBuilder out_arg,
      UIntPtr out_size);

    [DllImport("gpg")]
    internal static extern Types.MatchResult MultiplayerParticipant_MatchResult(HandleRef self);

    [DllImport("gpg")]
    internal static extern IntPtr MultiplayerParticipant_Player(HandleRef self);

    [DllImport("gpg")]
    internal static extern void MultiplayerParticipant_Dispose(HandleRef self);

    [DllImport("gpg")]
    [return: MarshalAs(UnmanagedType.I1)]
    internal static extern bool MultiplayerParticipant_Valid(HandleRef self);

    [DllImport("gpg")]
    [return: MarshalAs(UnmanagedType.I1)]
    internal static extern bool MultiplayerParticipant_HasMatchResult(HandleRef self);

    [DllImport("gpg")]
    internal static extern UIntPtr MultiplayerParticipant_Id(
      HandleRef self,
      StringBuilder out_arg,
      UIntPtr out_size);
  }
}
