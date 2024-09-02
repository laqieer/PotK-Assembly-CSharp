// Decompiled with JetBrains decompiler
// Type: ResourceLoadHelper
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore.IO;
using gu3.Utils;
using System.IO;

#nullable disable
internal class ResourceLoadHelper
{
  public static byte[] Decompress(byte[] bytes, ZlibFormat format, int skip)
  {
    int num = 0;
    using (MemoryStream memoryStream = new MemoryStream(bytes))
    {
      num += memoryStream.ReadByte();
      num += memoryStream.ReadByte() << 8;
      num += memoryStream.ReadByte() << 16;
      num += memoryStream.ReadByte() << 24;
    }
    byte[] buffer = new byte[num - skip];
    using (ZlibUtilStream zlibUtilStream = ZlibUtilStream.DecompressBytes(bytes, 4, bytes.Length - 4, format))
    {
      zlibUtilStream.Read(new byte[skip], 0, skip);
      zlibUtilStream.Read(buffer, 0, buffer.Length);
    }
    return buffer;
  }
}
