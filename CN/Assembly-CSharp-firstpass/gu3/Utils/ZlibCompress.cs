// Decompiled with JetBrains decompiler
// Type: gu3.Utils.ZlibCompress
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using System;

#nullable disable
namespace gu3.Utils
{
  public class ZlibCompress : IDisposable
  {
    private IntPtr p;

    public ZlibCompress(ZlibFormat format, ZlibCompressionLevel level)
    {
      this.p = Zlib.ZlibCompress_init((int) format, (int) level);
    }

    public bool deflate(
      byte[] in_buf,
      int in_offset,
      int in_size,
      byte[] out_buf,
      int out_offset,
      int out_size,
      out int in_avail,
      out int out_avail)
    {
      return Zlib.ZlibCompress_deflate(this.p, in_buf, in_offset, in_size, out_buf, out_offset, out_size, out in_avail, out out_avail);
    }

    public void Dispose() => Zlib.ZlibCompress_release(this.p);
  }
}
