﻿// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.Cwrapper.Achievement
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;
using System.Text;

#nullable disable
namespace GooglePlayGames.Native.Cwrapper
{
  internal static class Achievement
  {
    [DllImport("gpg")]
    internal static extern uint Achievement_TotalSteps(HandleRef self);

    [DllImport("gpg")]
    internal static extern UIntPtr Achievement_Description(
      HandleRef self,
      StringBuilder out_arg,
      UIntPtr out_size);

    [DllImport("gpg")]
    internal static extern void Achievement_Dispose(HandleRef self);

    [DllImport("gpg")]
    internal static extern UIntPtr Achievement_UnlockedIconUrl(
      HandleRef self,
      StringBuilder out_arg,
      UIntPtr out_size);

    [DllImport("gpg")]
    internal static extern ulong Achievement_LastModifiedTime(HandleRef self);

    [DllImport("gpg")]
    internal static extern UIntPtr Achievement_RevealedIconUrl(
      HandleRef self,
      StringBuilder out_arg,
      UIntPtr out_size);

    [DllImport("gpg")]
    internal static extern uint Achievement_CurrentSteps(HandleRef self);

    [DllImport("gpg")]
    internal static extern Types.AchievementState Achievement_State(HandleRef self);

    [DllImport("gpg")]
    [return: MarshalAs(UnmanagedType.I1)]
    internal static extern bool Achievement_Valid(HandleRef self);

    [DllImport("gpg")]
    internal static extern ulong Achievement_LastModified(HandleRef self);

    [DllImport("gpg")]
    internal static extern ulong Achievement_XP(HandleRef self);

    [DllImport("gpg")]
    internal static extern Types.AchievementType Achievement_Type(HandleRef self);

    [DllImport("gpg")]
    internal static extern UIntPtr Achievement_Id(
      HandleRef self,
      StringBuilder out_arg,
      UIntPtr out_size);

    [DllImport("gpg")]
    internal static extern UIntPtr Achievement_Name(
      HandleRef self,
      StringBuilder out_arg,
      UIntPtr out_size);
  }
}
