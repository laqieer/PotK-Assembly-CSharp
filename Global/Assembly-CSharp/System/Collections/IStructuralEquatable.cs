// Decompiled with JetBrains decompiler
// Type: System.Collections.IStructuralEquatable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

#nullable disable
namespace System.Collections
{
  public interface IStructuralEquatable
  {
    bool Equals(object other, IEqualityComparer comparer);

    int GetHashCode(IEqualityComparer comparer);
  }
}
