// Decompiled with JetBrains decompiler
// Type: SevenZip.Compression.LZ.IInWindowStream
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.IO;

#nullable disable
namespace SevenZip.Compression.LZ
{
  internal interface IInWindowStream
  {
    void SetStream(Stream inStream);

    void Init();

    void ReleaseStream();

    byte GetIndexByte(int index);

    uint GetMatchLen(int index, uint distance, uint limit);

    uint GetNumAvailableBytes();
  }
}
