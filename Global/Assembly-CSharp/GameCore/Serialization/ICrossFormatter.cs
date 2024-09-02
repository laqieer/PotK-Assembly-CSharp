// Decompiled with JetBrains decompiler
// Type: GameCore.Serialization.ICrossFormatter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.IO;

#nullable disable
namespace GameCore.Serialization
{
  public interface ICrossFormatter
  {
    void Save(int rootId, TypeObject[] objects, TreeObject[] trees, Stream stream);

    void Load(Stream stream, out int rootId, out TypeObject[] objects, out TreeObject[] trees);
  }
}
