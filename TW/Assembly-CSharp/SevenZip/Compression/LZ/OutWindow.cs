﻿// Decompiled with JetBrains decompiler
// Type: SevenZip.Compression.LZ.OutWindow
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.IO;

#nullable disable
namespace SevenZip.Compression.LZ
{
  public class OutWindow
  {
    private byte[] _buffer;
    private uint _pos;
    private uint _windowSize;
    private uint _streamPos;
    private Stream _stream;
    public uint TrainSize;

    public void Create(uint windowSize)
    {
      if ((int) this._windowSize != (int) windowSize)
        this._buffer = new byte[(IntPtr) windowSize];
      this._windowSize = windowSize;
      this._pos = 0U;
      this._streamPos = 0U;
    }

    public void Init(Stream stream, bool solid)
    {
      this.ReleaseStream();
      this._stream = stream;
      if (solid)
        return;
      this._streamPos = 0U;
      this._pos = 0U;
      this.TrainSize = 0U;
    }

    public bool Train(Stream stream)
    {
      long length = stream.Length;
      uint num1 = length >= (long) this._windowSize ? this._windowSize : (uint) length;
      this.TrainSize = num1;
      stream.Position = length - (long) num1;
      this._streamPos = this._pos = 0U;
      while (num1 > 0U)
      {
        uint count = this._windowSize - this._pos;
        if (num1 < count)
          count = num1;
        int num2 = stream.Read(this._buffer, (int) this._pos, (int) count);
        if (num2 == 0)
          return false;
        num1 -= (uint) num2;
        this._pos += (uint) num2;
        this._streamPos += (uint) num2;
        if ((int) this._pos == (int) this._windowSize)
          this._streamPos = this._pos = 0U;
      }
      return true;
    }

    public void ReleaseStream()
    {
      this.Flush();
      this._stream = (Stream) null;
    }

    public void Flush()
    {
      uint count = this._pos - this._streamPos;
      if (count == 0U)
        return;
      this._stream.Write(this._buffer, (int) this._streamPos, (int) count);
      if (this._pos >= this._windowSize)
        this._pos = 0U;
      this._streamPos = this._pos;
    }

    public void CopyBlock(uint distance, uint len)
    {
      uint num = (uint) ((int) this._pos - (int) distance - 1);
      if (num >= this._windowSize)
        num += this._windowSize;
      for (; len > 0U; --len)
      {
        if (num >= this._windowSize)
          num = 0U;
        this._buffer[(IntPtr) this._pos++] = this._buffer[(IntPtr) num++];
        if (this._pos >= this._windowSize)
          this.Flush();
      }
    }

    public void PutByte(byte b)
    {
      this._buffer[(IntPtr) this._pos++] = b;
      if (this._pos < this._windowSize)
        return;
      this.Flush();
    }

    public byte GetByte(uint distance)
    {
      uint index = (uint) ((int) this._pos - (int) distance - 1);
      if (index >= this._windowSize)
        index += this._windowSize;
      return this._buffer[(IntPtr) index];
    }
  }
}
