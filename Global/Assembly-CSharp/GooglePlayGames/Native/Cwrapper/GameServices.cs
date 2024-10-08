﻿// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.Cwrapper.GameServices
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;
using System.Text;

#nullable disable
namespace GooglePlayGames.Native.Cwrapper
{
  internal static class GameServices
  {
    [DllImport("gpg")]
    internal static extern void GameServices_Flush(
      HandleRef self,
      GameServices.FlushCallback callback,
      IntPtr callback_arg);

    [DllImport("gpg")]
    internal static extern void GameServices_FetchServerAuthCode(
      HandleRef self,
      string server_client_id,
      GameServices.FetchServerAuthCodeCallback callback,
      IntPtr callback_arg);

    [DllImport("gpg")]
    [return: MarshalAs(UnmanagedType.I1)]
    internal static extern bool GameServices_IsAuthorized(HandleRef self);

    [DllImport("gpg")]
    internal static extern void GameServices_Dispose(HandleRef self);

    [DllImport("gpg")]
    internal static extern void GameServices_SignOut(HandleRef self);

    [DllImport("gpg")]
    internal static extern void GameServices_StartAuthorizationUI(HandleRef self);

    [DllImport("gpg")]
    internal static extern void GameServices_FetchServerAuthCodeResponse_Dispose(HandleRef self);

    [DllImport("gpg")]
    internal static extern CommonErrorStatus.ResponseStatus GameServices_FetchServerAuthCodeResponse_GetStatus(
      HandleRef self);

    [DllImport("gpg")]
    internal static extern UIntPtr GameServices_FetchServerAuthCodeResponse_GetCode(
      HandleRef self,
      StringBuilder out_arg,
      UIntPtr out_size);

    internal delegate void FlushCallback(CommonErrorStatus.FlushStatus arg0, IntPtr arg1);

    internal delegate void FetchServerAuthCodeCallback(IntPtr arg0, IntPtr arg1);
  }
}
