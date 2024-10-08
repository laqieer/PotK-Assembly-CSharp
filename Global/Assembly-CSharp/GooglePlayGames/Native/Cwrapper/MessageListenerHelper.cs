﻿// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.Cwrapper.MessageListenerHelper
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace GooglePlayGames.Native.Cwrapper
{
  internal static class MessageListenerHelper
  {
    [DllImport("gpg")]
    internal static extern void MessageListenerHelper_SetOnMessageReceivedCallback(
      HandleRef self,
      MessageListenerHelper.OnMessageReceivedCallback callback,
      IntPtr callback_arg);

    [DllImport("gpg")]
    internal static extern void MessageListenerHelper_SetOnDisconnectedCallback(
      HandleRef self,
      MessageListenerHelper.OnDisconnectedCallback callback,
      IntPtr callback_arg);

    [DllImport("gpg")]
    internal static extern IntPtr MessageListenerHelper_Construct();

    [DllImport("gpg")]
    internal static extern void MessageListenerHelper_Dispose(HandleRef self);

    internal delegate void OnMessageReceivedCallback(
      long arg0,
      string arg1,
      IntPtr arg2,
      UIntPtr arg3,
      [MarshalAs(UnmanagedType.I1)] bool arg4,
      IntPtr arg5);

    internal delegate void OnDisconnectedCallback(long arg0, string arg1, IntPtr arg2);
  }
}
