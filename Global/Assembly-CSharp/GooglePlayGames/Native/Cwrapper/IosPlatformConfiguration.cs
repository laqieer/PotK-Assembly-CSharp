// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.Cwrapper.IosPlatformConfiguration
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace GooglePlayGames.Native.Cwrapper
{
  internal static class IosPlatformConfiguration
  {
    [DllImport("gpg")]
    internal static extern IntPtr IosPlatformConfiguration_Construct();

    [DllImport("gpg")]
    internal static extern void IosPlatformConfiguration_Dispose(HandleRef self);

    [DllImport("gpg")]
    [return: MarshalAs(UnmanagedType.I1)]
    internal static extern bool IosPlatformConfiguration_Valid(HandleRef self);

    [DllImport("gpg")]
    internal static extern void IosPlatformConfiguration_SetClientID(
      HandleRef self,
      string client_id);
  }
}
