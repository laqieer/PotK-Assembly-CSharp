// Decompiled with JetBrains decompiler
// Type: GameCore.Serialization.ICrossFormatter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
