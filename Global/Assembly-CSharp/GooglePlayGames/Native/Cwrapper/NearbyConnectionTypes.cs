﻿// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.Cwrapper.NearbyConnectionTypes
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;
using System.Text;

#nullable disable
namespace GooglePlayGames.Native.Cwrapper
{
  internal static class NearbyConnectionTypes
  {
    [DllImport("gpg")]
    internal static extern void AppIdentifier_Dispose(HandleRef self);

    [DllImport("gpg")]
    internal static extern UIntPtr AppIdentifier_GetIdentifier(
      HandleRef self,
      StringBuilder out_arg,
      UIntPtr out_size);

    [DllImport("gpg")]
    internal static extern void StartAdvertisingResult_Dispose(HandleRef self);

    [DllImport("gpg")]
    [return: MarshalAs(UnmanagedType.I4)]
    internal static extern int StartAdvertisingResult_GetStatus(HandleRef self);

    [DllImport("gpg")]
    internal static extern UIntPtr StartAdvertisingResult_GetLocalEndpointName(
      HandleRef self,
      StringBuilder out_arg,
      UIntPtr out_size);

    [DllImport("gpg")]
    internal static extern void EndpointDetails_Dispose(HandleRef self);

    [DllImport("gpg")]
    internal static extern UIntPtr EndpointDetails_GetEndpointId(
      HandleRef self,
      StringBuilder out_arg,
      UIntPtr out_size);

    [DllImport("gpg")]
    internal static extern UIntPtr EndpointDetails_GetDeviceId(
      HandleRef self,
      StringBuilder out_arg,
      UIntPtr out_size);

    [DllImport("gpg")]
    internal static extern UIntPtr EndpointDetails_GetName(
      HandleRef self,
      StringBuilder out_arg,
      UIntPtr out_size);

    [DllImport("gpg")]
    internal static extern UIntPtr EndpointDetails_GetServiceId(
      HandleRef self,
      StringBuilder out_arg,
      UIntPtr out_size);

    [DllImport("gpg")]
    internal static extern void ConnectionRequest_Dispose(HandleRef self);

    [DllImport("gpg")]
    internal static extern UIntPtr ConnectionRequest_GetRemoteEndpointId(
      HandleRef self,
      StringBuilder out_arg,
      UIntPtr out_size);

    [DllImport("gpg")]
    internal static extern UIntPtr ConnectionRequest_GetRemoteDeviceId(
      HandleRef self,
      StringBuilder out_arg,
      UIntPtr out_size);

    [DllImport("gpg")]
    internal static extern UIntPtr ConnectionRequest_GetRemoteEndpointName(
      HandleRef self,
      StringBuilder out_arg,
      UIntPtr out_size);

    [DllImport("gpg")]
    internal static extern UIntPtr ConnectionRequest_GetPayload(
      HandleRef self,
      [In, Out] byte[] out_arg,
      UIntPtr out_size);

    [DllImport("gpg")]
    internal static extern void ConnectionResponse_Dispose(HandleRef self);

    [DllImport("gpg")]
    internal static extern UIntPtr ConnectionResponse_GetRemoteEndpointId(
      HandleRef self,
      StringBuilder out_arg,
      UIntPtr out_size);

    [DllImport("gpg")]
    internal static extern NearbyConnectionTypes.ConnectionResponse_ResponseCode ConnectionResponse_GetStatus(
      HandleRef self);

    [DllImport("gpg")]
    internal static extern UIntPtr ConnectionResponse_GetPayload(
      HandleRef self,
      [In, Out] byte[] out_arg,
      UIntPtr out_size);

    internal enum ConnectionResponse_ResponseCode
    {
      ERROR_ENDPOINT_NOT_CONNECTED = -4, // 0xFFFFFFFC
      ERROR_ENDPOINT_ALREADY_CONNECTED = -3, // 0xFFFFFFFD
      ERROR_NETWORK_NOT_CONNECTED = -2, // 0xFFFFFFFE
      ERROR_INTERNAL = -1, // 0xFFFFFFFF
      ACCEPTED = 1,
      REJECTED = 2,
    }

    internal delegate void ConnectionRequestCallback(long arg0, IntPtr arg1, IntPtr arg2);

    internal delegate void StartAdvertisingCallback(long arg0, IntPtr arg1, IntPtr arg2);

    internal delegate void ConnectionResponseCallback(long arg0, IntPtr arg1, IntPtr arg2);
  }
}
