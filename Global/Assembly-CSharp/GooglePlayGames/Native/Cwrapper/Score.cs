﻿// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.Cwrapper.Score
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;
using System.Text;

#nullable disable
namespace GooglePlayGames.Native.Cwrapper
{
  internal static class Score
  {
    [DllImport("gpg")]
    internal static extern ulong Score_Value(HandleRef self);

    [DllImport("gpg")]
    [return: MarshalAs(UnmanagedType.I1)]
    internal static extern bool Score_Valid(HandleRef self);

    [DllImport("gpg")]
    internal static extern ulong Score_Rank(HandleRef self);

    [DllImport("gpg")]
    internal static extern void Score_Dispose(HandleRef self);

    [DllImport("gpg")]
    internal static extern UIntPtr Score_Metadata(
      HandleRef self,
      StringBuilder out_arg,
      UIntPtr out_size);
  }
}
