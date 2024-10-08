﻿// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.Cwrapper.Quest
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;
using System.Text;

#nullable disable
namespace GooglePlayGames.Native.Cwrapper
{
  internal static class Quest
  {
    [DllImport("gpg")]
    internal static extern UIntPtr Quest_Description(
      HandleRef self,
      StringBuilder out_arg,
      UIntPtr out_size);

    [DllImport("gpg")]
    internal static extern UIntPtr Quest_BannerUrl(
      HandleRef self,
      StringBuilder out_arg,
      UIntPtr out_size);

    [DllImport("gpg")]
    internal static extern long Quest_ExpirationTime(HandleRef self);

    [DllImport("gpg")]
    internal static extern UIntPtr Quest_IconUrl(
      HandleRef self,
      StringBuilder out_arg,
      UIntPtr out_size);

    [DllImport("gpg")]
    internal static extern Types.QuestState Quest_State(HandleRef self);

    [DllImport("gpg")]
    internal static extern IntPtr Quest_Copy(HandleRef self);

    [DllImport("gpg")]
    [return: MarshalAs(UnmanagedType.I1)]
    internal static extern bool Quest_Valid(HandleRef self);

    [DllImport("gpg")]
    internal static extern long Quest_StartTime(HandleRef self);

    [DllImport("gpg")]
    internal static extern void Quest_Dispose(HandleRef self);

    [DllImport("gpg")]
    internal static extern IntPtr Quest_CurrentMilestone(HandleRef self);

    [DllImport("gpg")]
    internal static extern long Quest_AcceptedTime(HandleRef self);

    [DllImport("gpg")]
    internal static extern UIntPtr Quest_Id(
      HandleRef self,
      StringBuilder out_arg,
      UIntPtr out_size);

    [DllImport("gpg")]
    internal static extern UIntPtr Quest_Name(
      HandleRef self,
      StringBuilder out_arg,
      UIntPtr out_size);
  }
}
