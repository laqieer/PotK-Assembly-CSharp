﻿// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.Cwrapper.RealTimeRoomConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;
using System.Text;

#nullable disable
namespace GooglePlayGames.Native.Cwrapper
{
  internal static class RealTimeRoomConfig
  {
    [DllImport("gpg")]
    internal static extern UIntPtr RealTimeRoomConfig_PlayerIdsToInvite_Length(HandleRef self);

    [DllImport("gpg")]
    internal static extern UIntPtr RealTimeRoomConfig_PlayerIdsToInvite_GetElement(
      HandleRef self,
      UIntPtr index,
      StringBuilder out_arg,
      UIntPtr out_size);

    [DllImport("gpg")]
    internal static extern uint RealTimeRoomConfig_Variant(HandleRef self);

    [DllImport("gpg")]
    internal static extern long RealTimeRoomConfig_ExclusiveBitMask(HandleRef self);

    [DllImport("gpg")]
    [return: MarshalAs(UnmanagedType.I1)]
    internal static extern bool RealTimeRoomConfig_Valid(HandleRef self);

    [DllImport("gpg")]
    internal static extern uint RealTimeRoomConfig_MaximumAutomatchingPlayers(HandleRef self);

    [DllImport("gpg")]
    internal static extern uint RealTimeRoomConfig_MinimumAutomatchingPlayers(HandleRef self);

    [DllImport("gpg")]
    internal static extern void RealTimeRoomConfig_Dispose(HandleRef self);
  }
}
