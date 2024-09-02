// Decompiled with JetBrains decompiler
// Type: GameCore.Serialization.BlobEqualityComparer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
namespace GameCore.Serialization
{
  internal class BlobEqualityComparer : IEqualityComparer<object>
  {
    bool IEqualityComparer<object>.System\u002ECollections\u002EGeneric\u002EIEqualityComparer\u003Cobject\u003E\u002EEquals(
      object x,
      object y)
    {
      if (x == null)
        return y == null;
      return x.GetType().IsValueType ? x.Equals(y) : object.ReferenceEquals(x, y);
    }

    int IEqualityComparer<object>.System\u002ECollections\u002EGeneric\u002EIEqualityComparer\u003Cobject\u003E\u002EGetHashCode(
      object obj)
    {
      return this.GetHashCode();
    }
  }
}
