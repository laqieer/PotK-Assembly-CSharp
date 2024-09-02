// Decompiled with JetBrains decompiler
// Type: System.Tuple`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace System
{
  [Serializable]
  public class Tuple<T1> : IComparable, IStructuralComparable, IStructuralEquatable
  {
    private T1 item1;

    public Tuple(T1 item1) => this.item1 = item1;

    int IComparable.CompareTo(object obj)
    {
      return ((IStructuralComparable) this).CompareTo(obj, (IComparer) Comparer<object>.Default);
    }

    int IStructuralComparable.CompareTo(object other, IComparer comparer)
    {
      if (other is Tuple<T1> tuple)
        return comparer.Compare((object) this.item1, (object) tuple.item1);
      if (other == null)
        return 1;
      throw new ArgumentException(nameof (other));
    }

    bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
    {
      return other is Tuple<T1> tuple && comparer.Equals((object) this.item1, (object) tuple.item1);
    }

    int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
    {
      int num = 0;
      return (num << 5) - num + comparer.GetHashCode((object) this.item1);
    }

    public T1 Item1 => this.item1;

    public override bool Equals(object obj)
    {
      return ((IStructuralEquatable) this).Equals(obj, (IEqualityComparer) EqualityComparer<object>.Default);
    }

    public override int GetHashCode()
    {
      return ((IStructuralEquatable) this).GetHashCode((IEqualityComparer) EqualityComparer<object>.Default);
    }

    public override string ToString() => string.Format("({0})", (object) this.item1);
  }
}
