﻿// Decompiled with JetBrains decompiler
// Type: gu3.Utils.ZlibDecompress
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using System;

#nullable disable
namespace gu3.Utils
{
  public class ZlibDecompress : IDisposable
  {
    private IntPtr p;

    public ZlibDecompress(ZlibFormat format) => this.p = Zlib.ZlibDecompress_init((int) format);

    public bool inflate(
      byte[] in_buf,
      int in_offset,
      int in_size,
      byte[] out_buf,
      int out_offset,
      int out_size,
      out int in_avail,
      out int out_avail)
    {
      return Zlib.ZlibDecompress_inflate(this.p, in_buf, in_offset, in_size, out_buf, out_offset, out_size, out in_avail, out out_avail);
    }

    public void Dispose() => Zlib.ZlibDecompress_release(this.p);
  }
}
