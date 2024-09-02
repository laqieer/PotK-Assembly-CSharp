// Decompiled with JetBrains decompiler
// Type: GameCore.IO.ZlibUtilStream
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using gu3.Utils;
using System.IO;

#nullable disable
namespace GameCore.IO
{
  public class ZlibUtilStream : Stream
  {
    private Stream stream;

    private ZlibUtilStream(Stream stream) => this.stream = stream;

    public override long Seek(long offset, SeekOrigin origin) => this.stream.Seek(offset, origin);

    public override void SetLength(long value) => this.stream.SetLength(value);

    public override bool CanRead => this.stream.CanRead;

    public override bool CanWrite => this.stream.CanWrite;

    public override bool CanSeek => this.stream.CanSeek;

    public override long Length => this.stream.Length;

    public override long Position
    {
      get => this.stream.Position;
      set => this.stream.Position = value;
    }

    protected override void Dispose(bool disposing) => this.stream.Dispose();

    public override void Flush() => this.stream.Flush();

    public override int Read(byte[] buffer, int offset, int count)
    {
      return this.stream.Read(buffer, offset, count);
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
      this.stream.Write(buffer, offset, count);
    }

    public static ZlibUtilStream Decompress(Stream stream, ZlibFormat format)
    {
      return new ZlibUtilStream((Stream) ZlibStream.Decompress(stream, format));
    }

    public static ZlibUtilStream DecompressBytes(
      byte[] buffer,
      int offset,
      int length,
      ZlibFormat format)
    {
      return new ZlibUtilStream((Stream) ZlibStream.DecompressBytes(buffer, offset, length, format));
    }

    public static ZlibUtilStream Compress(
      Stream stream,
      ZlibFormat format,
      ZlibCompressionLevel compressionLevel)
    {
      return new ZlibUtilStream((Stream) ZlibStream.Compress(stream, format, compressionLevel));
    }
  }
}
