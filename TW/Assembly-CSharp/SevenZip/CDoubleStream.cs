// Decompiled with JetBrains decompiler
// Type: SevenZip.CDoubleStream
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.IO;

#nullable disable
namespace SevenZip
{
  public class CDoubleStream : Stream
  {
    public Stream s1;
    public Stream s2;
    public int fileIndex;
    public long skipSize;

    public override bool CanRead => true;

    public override bool CanWrite => false;

    public override bool CanSeek => false;

    public override long Length => this.s1.Length + this.s2.Length - this.skipSize;

    public override long Position
    {
      get => 0;
      set
      {
      }
    }

    public override void Flush()
    {
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
      int num1 = 0;
      while (count > 0)
      {
        if (this.fileIndex == 0)
        {
          int num2 = this.s1.Read(buffer, offset, count);
          offset += num2;
          count -= num2;
          num1 += num2;
          if (num2 == 0)
            ++this.fileIndex;
        }
        if (this.fileIndex == 1)
          return num1 + this.s2.Read(buffer, offset, count);
      }
      return num1;
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
      throw new Exception("can't Write");
    }

    public override long Seek(long offset, SeekOrigin origin) => throw new Exception("can't Seek");

    public override void SetLength(long value) => throw new Exception("can't SetLength");
  }
}
