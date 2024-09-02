// Decompiled with JetBrains decompiler
// Type: System.Tuple`3
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace System
{
  [Serializable]
  public class Tuple<T1, T2, T3> : IComparable, IStructuralComparable, IStructuralEquatable
  {
    private T1 item1;
    private T2 item2;
    private T3 item3;

    public Tuple(T1 item1, T2 item2, T3 item3)
    {
      this.item1 = item1;
      this.item2 = item2;
      this.item3 = item3;
    }

    int IComparable.CompareTo(object obj)
    {
      return ((IStructuralComparable) this).CompareTo(obj, (IComparer) Comparer<object>.Default);
    }

    int IStructuralComparable.CompareTo(object other, IComparer comparer)
    {
      if (!(other is Tuple<T1, T2, T3> tuple))
      {
        if (other == null)
          return 1;
        throw new ArgumentException(nameof (other));
      }
      int num1 = comparer.Compare((object) this.item1, (object) tuple.item1);
      if (num1 != 0)
        return num1;
      int num2 = comparer.Compare((object) this.item2, (object) tuple.item2);
      return num2 != 0 ? num2 : comparer.Compare((object) this.item3, (object) tuple.item3);
    }

    bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
    {
      return other is Tuple<T1, T2, T3> tuple && comparer.Equals((object) this.item1, (object) tuple.item1) && comparer.Equals((object) this.item2, (object) tuple.item2) && comparer.Equals((object) this.item3, (object) tuple.item3);
    }

    int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
    {
      int num1 = 0;
      int num2 = (num1 << 5) - num1 + comparer.GetHashCode((object) this.item1);
      int num3 = (num2 << 5) - num2 + comparer.GetHashCode((object) this.item2);
      return (num3 << 5) - num3 + comparer.GetHashCode((object) this.item3);
    }

    public T1 Item1 => this.item1;

    public T2 Item2 => this.item2;

    public T3 Item3 => this.item3;

    public override bool Equals(object obj)
    {
      return ((IStructuralEquatable) this).Equals(obj, (IEqualityComparer) EqualityComparer<object>.Default);
    }

    public override int GetHashCode()
    {
      return ((IStructuralEquatable) this).GetHashCode((IEqualityComparer) EqualityComparer<object>.Default);
    }

    public override string ToString()
    {
      return string.Format("({0}, {1}, {2})", (object) this.item1, (object) this.item2, (object) this.item3);
    }
  }
}
