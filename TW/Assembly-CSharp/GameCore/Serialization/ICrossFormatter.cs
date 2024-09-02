// Decompiled with JetBrains decompiler
// Type: GameCore.Serialization.ICrossFormatter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
