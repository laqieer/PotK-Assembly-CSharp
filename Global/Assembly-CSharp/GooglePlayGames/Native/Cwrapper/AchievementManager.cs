﻿// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.Cwrapper.AchievementManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace GooglePlayGames.Native.Cwrapper
{
  internal static class AchievementManager
  {
    [DllImport("gpg")]
    internal static extern void AchievementManager_FetchAll(
      HandleRef self,
      Types.DataSource data_source,
      AchievementManager.FetchAllCallback callback,
      IntPtr callback_arg);

    [DllImport("gpg")]
    internal static extern void AchievementManager_Reveal(HandleRef self, string achievement_id);

    [DllImport("gpg")]
    internal static extern void AchievementManager_Unlock(HandleRef self, string achievement_id);

    [DllImport("gpg")]
    internal static extern void AchievementManager_ShowAllUI(
      HandleRef self,
      AchievementManager.ShowAllUICallback callback,
      IntPtr callback_arg);

    [DllImport("gpg")]
    internal static extern void AchievementManager_SetStepsAtLeast(
      HandleRef self,
      string achievement_id,
      uint steps);

    [DllImport("gpg")]
    internal static extern void AchievementManager_Increment(
      HandleRef self,
      string achievement_id,
      uint steps);

    [DllImport("gpg")]
    internal static extern void AchievementManager_Fetch(
      HandleRef self,
      Types.DataSource data_source,
      string achievement_id,
      AchievementManager.FetchCallback callback,
      IntPtr callback_arg);

    [DllImport("gpg")]
    internal static extern void AchievementManager_FetchAllResponse_Dispose(HandleRef self);

    [DllImport("gpg")]
    internal static extern CommonErrorStatus.ResponseStatus AchievementManager_FetchAllResponse_GetStatus(
      HandleRef self);

    [DllImport("gpg")]
    internal static extern UIntPtr AchievementManager_FetchAllResponse_GetData_Length(HandleRef self);

    [DllImport("gpg")]
    internal static extern IntPtr AchievementManager_FetchAllResponse_GetData_GetElement(
      HandleRef self,
      UIntPtr index);

    [DllImport("gpg")]
    internal static extern void AchievementManager_FetchResponse_Dispose(HandleRef self);

    [DllImport("gpg")]
    internal static extern CommonErrorStatus.ResponseStatus AchievementManager_FetchResponse_GetStatus(
      HandleRef self);

    [DllImport("gpg")]
    internal static extern IntPtr AchievementManager_FetchResponse_GetData(HandleRef self);

    internal delegate void FetchAllCallback(IntPtr arg0, IntPtr arg1);

    internal delegate void FetchCallback(IntPtr arg0, IntPtr arg1);

    internal delegate void ShowAllUICallback(CommonErrorStatus.UIStatus arg0, IntPtr arg1);
  }
}
