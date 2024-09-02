// Decompiled with JetBrains decompiler
// Type: System.Collections.IStructuralEquatable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

namespace System.Collections
{
  public interface IStructuralEquatable
  {
    bool Equals(object other, IEqualityComparer comparer);

    int GetHashCode(IEqualityComparer comparer);
  }
}
