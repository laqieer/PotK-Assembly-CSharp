﻿// Decompiled with JetBrains decompiler
// Type: System.Tuple`6
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace System
{
  [Serializable]
  public class Tuple<T1, T2, T3, T4, T5, T6> : 
    IComparable,
    IStructuralComparable,
    IStructuralEquatable
  {
    private T1 item1;
    private T2 item2;
    private T3 item3;
    private T4 item4;
    private T5 item5;
    private T6 item6;

    public Tuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6)
    {
      this.item1 = item1;
      this.item2 = item2;
      this.item3 = item3;
      this.item4 = item4;
      this.item5 = item5;
      this.item6 = item6;
    }

    int IComparable.CompareTo(object obj)
    {
      return ((IStructuralComparable) this).CompareTo(obj, (IComparer) Comparer<object>.Default);
    }

    int IStructuralComparable.CompareTo(object other, IComparer comparer)
    {
      if (!(other is Tuple<T1, T2, T3, T4, T5, T6> tuple))
      {
        if (other == null)
          return 1;
        throw new ArgumentException(nameof (other));
      }
      int num1 = comparer.Compare((object) this.item1, (object) tuple.item1);
      if (num1 != 0)
        return num1;
      int num2 = comparer.Compare((object) this.item2, (object) tuple.item2);
      if (num2 != 0)
        return num2;
      int num3 = comparer.Compare((object) this.item3, (object) tuple.item3);
      if (num3 != 0)
        return num3;
      int num4 = comparer.Compare((object) this.item4, (object) tuple.item4);
      if (num4 != 0)
        return num4;
      int num5 = comparer.Compare((object) this.item5, (object) tuple.item5);
      return num5 != 0 ? num5 : comparer.Compare((object) this.item6, (object) tuple.item6);
    }

    bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
    {
      return other is Tuple<T1, T2, T3, T4, T5, T6> tuple && comparer.Equals((object) this.item1, (object) tuple.item1) && comparer.Equals((object) this.item2, (object) tuple.item2) && comparer.Equals((object) this.item3, (object) tuple.item3) && comparer.Equals((object) this.item4, (object) tuple.item4) && comparer.Equals((object) this.item5, (object) tuple.item5) && comparer.Equals((object) this.item6, (object) tuple.item6);
    }

    int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
    {
      int num1 = 0;
      int num2 = (num1 << 5) - num1 + comparer.GetHashCode((object) this.item1);
      int num3 = (num2 << 5) - num2 + comparer.GetHashCode((object) this.item2);
      int num4 = (num3 << 5) - num3 + comparer.GetHashCode((object) this.item3);
      int num5 = (num4 << 5) - num4 + comparer.GetHashCode((object) this.item4);
      int num6 = (num5 << 5) - num5 + comparer.GetHashCode((object) this.item5);
      return (num6 << 5) - num6 + comparer.GetHashCode((object) this.item6);
    }

    public T1 Item1 => this.item1;

    public T2 Item2 => this.item2;

    public T3 Item3 => this.item3;

    public T4 Item4 => this.item4;

    public T5 Item5 => this.item5;

    public T6 Item6 => this.item6;

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
      return string.Format("({0}, {1}, {2}, {3}, {4}, {5})", (object) this.item1, (object) this.item2, (object) this.item3, (object) this.item4, (object) this.item5, (object) this.item6);
    }
  }
}
