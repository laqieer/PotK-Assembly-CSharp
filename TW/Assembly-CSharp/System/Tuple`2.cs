// Decompiled with JetBrains decompiler
// Type: System.Tuple`2
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace System
{
  [Serializable]
  public class Tuple<T1, T2> : IComparable, IStructuralComparable, IStructuralEquatable
  {
    private T1 item1;
    private T2 item2;

    public Tuple(T1 item1, T2 item2)
    {
      this.item1 = item1;
      this.item2 = item2;
    }

    int IComparable.CompareTo(object obj)
    {
      return ((IStructuralComparable) this).CompareTo(obj, (IComparer) Comparer<object>.Default);
    }

    int IStructuralComparable.CompareTo(object other, IComparer comparer)
    {
      if (!(other is Tuple<T1, T2> tuple))
      {
        if (other == null)
          return 1;
        throw new ArgumentException(nameof (other));
      }
      int num = comparer.Compare((object) this.item1, (object) tuple.item1);
      return num != 0 ? num : comparer.Compare((object) this.item2, (object) tuple.item2);
    }

    bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
    {
      return other is Tuple<T1, T2> tuple && comparer.Equals((object) this.item1, (object) tuple.item1) && comparer.Equals((object) this.item2, (object) tuple.item2);
    }

    int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
    {
      int num1 = 0;
      int num2 = (num1 << 5) - num1 + comparer.GetHashCode((object) this.item1);
      return (num2 << 5) - num2 + comparer.GetHashCode((object) this.item2);
    }

    public T1 Item1 => this.item1;

    public T2 Item2 => this.item2;

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
      return string.Format("({0}, {1})", (object) this.item1, (object) this.item2);
    }
  }
}
