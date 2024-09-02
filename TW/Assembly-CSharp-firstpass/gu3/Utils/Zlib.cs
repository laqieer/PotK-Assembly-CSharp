﻿// Decompiled with JetBrains decompiler
// Type: gu3.Utils.Zlib
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace gu3.Utils
{
  internal static class Zlib
  {
    private const string LIBNAME = "UnityUtils";

    [DllImport("UnityUtils")]
    internal static extern IntPtr ZlibCompress_init(int format, int level);

    [DllImport("UnityUtils")]
    internal static extern bool ZlibCompress_deflate(
      IntPtr obj,
      byte[] in_buf,
      int in_offset,
      int in_size,
      byte[] out_buf,
      int out_offset,
      int out_size,
      out int in_avail,
      out int out_avail);

    [DllImport("UnityUtils")]
    internal static extern void ZlibCompress_release(IntPtr obj);

    [DllImport("UnityUtils")]
    internal static extern IntPtr ZlibDecompress_init(int format);

    [DllImport("UnityUtils")]
    internal static extern bool ZlibDecompress_inflate(
      IntPtr obj,
      byte[] in_buf,
      int in_offset,
      int in_size,
      byte[] out_buf,
      int out_offset,
      int out_size,
      out int in_avail,
      out int out_avail);

    [DllImport("UnityUtils")]
    internal static extern void ZlibDecompress_release(IntPtr obj);
  }
}
