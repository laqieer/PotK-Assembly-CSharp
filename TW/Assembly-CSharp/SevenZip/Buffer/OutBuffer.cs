﻿// Decompiled with JetBrains decompiler
// Type: SevenZip.Buffer.OutBuffer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.IO;

#nullable disable
namespace SevenZip.Buffer
{
  public class OutBuffer
  {
    private byte[] m_Buffer;
    private uint m_Pos;
    private uint m_BufferSize;
    private Stream m_Stream;
    private ulong m_ProcessedSize;

    public OutBuffer(uint bufferSize)
    {
      this.m_Buffer = new byte[(IntPtr) bufferSize];
      this.m_BufferSize = bufferSize;
    }

    public void SetStream(Stream stream) => this.m_Stream = stream;

    public void FlushStream() => this.m_Stream.Flush();

    public void CloseStream() => this.m_Stream.Close();

    public void ReleaseStream() => this.m_Stream = (Stream) null;

    public void Init()
    {
      this.m_ProcessedSize = 0UL;
      this.m_Pos = 0U;
    }

    public void WriteByte(byte b)
    {
      this.m_Buffer[(IntPtr) this.m_Pos++] = b;
      if (this.m_Pos < this.m_BufferSize)
        return;
      this.FlushData();
    }

    public void FlushData()
    {
      if (this.m_Pos == 0U)
        return;
      this.m_Stream.Write(this.m_Buffer, 0, (int) this.m_Pos);
      this.m_Pos = 0U;
    }

    public ulong GetProcessedSize() => this.m_ProcessedSize + (ulong) this.m_Pos;
  }
}
