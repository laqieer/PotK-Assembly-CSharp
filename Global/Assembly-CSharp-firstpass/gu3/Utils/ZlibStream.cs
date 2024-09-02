// Decompiled with JetBrains decompiler
// Type: gu3.Utils.ZlibStream
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using System;
using System.IO;

#nullable disable
namespace gu3.Utils
{
  public class ZlibStream : Stream
  {
    private Stream stream;
    private ZlibStream.CompressionMode mode;
    private ZlibCompress compress;
    private ZlibDecompress decompress;
    private byte[] buffer;
    private int offset;
    private int length;

    public override long Seek(long offset, SeekOrigin origin)
    {
      throw new NotImplementedException();
    }

    public override void SetLength(long value) => throw new NotImplementedException();

    public override bool CanRead
    {
      get
      {
        return this.mode == ZlibStream.CompressionMode.Decompress || this.mode == ZlibStream.CompressionMode.DecompressBytes;
      }
    }

    public override bool CanWrite => this.mode == ZlibStream.CompressionMode.Compress;

    public override bool CanSeek => false;

    public override long Length => throw new NotImplementedException();

    public override long Position
    {
      get => throw new NotImplementedException();
      set => throw new NotImplementedException();
    }

    protected override void Dispose(bool disposing)
    {
      base.Dispose(disposing);
      if (!disposing)
        return;
      try
      {
        this.Flush();
      }
      catch (Exception ex)
      {
      }
      if (this.compress != null)
      {
        this.compress.Dispose();
        this.compress = (ZlibCompress) null;
      }
      if (this.decompress != null)
      {
        this.decompress.Dispose();
        this.decompress = (ZlibDecompress) null;
      }
      if (this.stream == null)
        return;
      this.stream.Dispose();
    }

    public static ZlibStream Decompress(Stream stream, ZlibFormat format, int bufferSize = 8192)
    {
      return new ZlibStream()
      {
        stream = stream,
        mode = ZlibStream.CompressionMode.Decompress,
        decompress = new ZlibDecompress(format),
        buffer = new byte[bufferSize],
        offset = 0,
        length = 0
      };
    }

    public static ZlibStream DecompressBytes(
      byte[] buffer,
      int offset,
      int length,
      ZlibFormat format)
    {
      return new ZlibStream()
      {
        mode = ZlibStream.CompressionMode.DecompressBytes,
        decompress = new ZlibDecompress(format),
        buffer = buffer,
        offset = offset,
        length = length
      };
    }

    public static ZlibStream Compress(
      Stream stream,
      ZlibFormat format,
      ZlibCompressionLevel compressionLevel,
      int bufferSize = 8192)
    {
      ZlibStream zlibStream = new ZlibStream()
      {
        stream = stream,
        mode = ZlibStream.CompressionMode.Compress,
        compress = new ZlibCompress(format, compressionLevel),
        buffer = new byte[bufferSize],
        offset = 0
      };
      zlibStream.length = zlibStream.buffer.Length;
      return zlibStream;
    }

    public override void Flush()
    {
      if (this.mode != ZlibStream.CompressionMode.Compress)
        return;
      this.stream.Write(this.buffer, 0, this.buffer.Length - this.length);
      this.stream.Flush();
      this.offset = 0;
      this.length = this.buffer.Length;
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
      int num = 0;
      int out_avail;
      do
      {
        if (this.length == 0)
        {
          if (this.mode != ZlibStream.CompressionMode.DecompressBytes)
          {
            this.offset = 0;
            this.length = this.stream.Read(this.buffer, 0, this.buffer.Length);
            if (this.length == 0)
              break;
          }
          else
            break;
        }
        int in_avail;
        if (!this.decompress.inflate(this.buffer, this.offset, this.length, buffer, offset + num, count - num, out in_avail, out out_avail))
          throw new IOException("read error");
        num = count - out_avail;
        this.offset += this.length - in_avail;
        this.length = in_avail;
      }
      while (out_avail != 0);
      return num;
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
      int num = 0;
      int in_avail;
      int out_avail;
      while (this.compress.deflate(buffer, offset + num, count - num, this.buffer, this.offset, this.length, out in_avail, out out_avail))
      {
        num = count - in_avail;
        this.offset += this.length - out_avail;
        this.length = out_avail;
        if (out_avail == 0)
        {
          this.stream.Write(this.buffer, 0, this.buffer.Length);
          offset = 0;
          this.length = this.buffer.Length;
        }
        if (in_avail == 0)
          return;
      }
      throw new IOException("write error");
    }

    public enum CompressionMode
    {
      Compress,
      Decompress,
      DecompressBytes,
    }
  }
}
