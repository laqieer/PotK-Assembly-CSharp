// Decompiled with JetBrains decompiler
// Type: DenaLib.UpdateInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.IO;

#nullable disable
namespace DenaLib
{
  public class UpdateInfo
  {
    public int updateType;
    public string name = string.Empty;
    public string relativePath = string.Empty;
    public string md5 = string.Empty;
    public long length;

    public void Load(BinaryReader br)
    {
      this.updateType = br.ReadInt32();
      this.name = br.ReadString();
      this.relativePath = br.ReadString();
      this.md5 = br.ReadString();
      this.length = br.ReadInt64();
    }

    public void Save(BinaryWriter bw)
    {
      bw.Write(this.updateType);
      bw.Write(this.name);
      bw.Write(this.relativePath);
      bw.Write(this.md5);
      bw.Write(this.length);
    }
  }
}
