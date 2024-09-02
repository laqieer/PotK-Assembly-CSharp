// Decompiled with JetBrains decompiler
// Type: GameCore.EnumerableExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;

#nullable disable
namespace GameCore
{
  public static class EnumerableExtension
  {
    public static void ForEach<T>(this IEnumerable<T> self, Action<T> f)
    {
      foreach (T obj in self)
        f(obj);
    }

    public static void ForEachIndex<T>(this IEnumerable<T> self, Action<T, int> f)
    {
      int num = 0;
      foreach (T obj in self)
      {
        f(obj, num);
        checked { ++num; }
      }
    }

    public static void ForEach<T1, T2>(
      this IEnumerable<T1> source1,
      IEnumerable<T2> source2,
      Action<T1, T2> f)
    {
      using (IEnumerator<T1> enumerator1 = EnumerableWrapper.Create<T1>(source1).GetEnumerator())
      {
        using (IEnumerator<T2> enumerator2 = EnumerableWrapper.Create<T2>(source2).GetEnumerator())
        {
          while (enumerator1.MoveNext() && enumerator2.MoveNext())
            f(enumerator1.Current, enumerator2.Current);
        }
      }
    }

    public static void ForEach<T1, T2, T3>(
      this IEnumerable<T1> source1,
      IEnumerable<T2> source2,
      IEnumerable<T3> source3,
      Action<T1, T2, T3> f)
    {
      using (IEnumerator<T1> enumerator1 = EnumerableWrapper.Create<T1>(source1).GetEnumerator())
      {
        using (IEnumerator<T2> enumerator2 = EnumerableWrapper.Create<T2>(source2).GetEnumerator())
        {
          using (IEnumerator<T3> enumerator3 = EnumerableWrapper.Create<T3>(source3).GetEnumerator())
          {
            while (enumerator1.MoveNext() && enumerator2.MoveNext() && enumerator3.MoveNext())
              f(enumerator1.Current, enumerator2.Current, enumerator3.Current);
          }
        }
      }
    }

    public static string Join(this IEnumerable<string> self, string separator)
    {
      return string.Join(separator, self.ToArray<string>());
    }

    [DebuggerHidden]
    public static IEnumerable<TResult> Select<T1, T2, TResult>(
      this IEnumerable<T1> source1,
      IEnumerable<T2> source2,
      Func<T1, T2, TResult> func)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      EnumerableExtension.\u003CSelect\u003Ec__Iterator29<T1, T2, TResult> selectCIterator29 = new EnumerableExtension.\u003CSelect\u003Ec__Iterator29<T1, T2, TResult>()
      {
        source1 = source1,
        source2 = source2,
        func = func,
        \u003C\u0024\u003Esource1 = source1,
        \u003C\u0024\u003Esource2 = source2,
        \u003C\u0024\u003Efunc = func
      };
      // ISSUE: reference to a compiler-generated field
      selectCIterator29.\u0024PC = -2;
      return (IEnumerable<TResult>) selectCIterator29;
    }

    public static string ToStringForChars(this IEnumerable<char> str)
    {
      return new string(str.ToArray<char>());
    }

    public static int? FirstIndexOrNull<T>(this IEnumerable<T> self, Func<T, bool> pred)
    {
      int num = 0;
      foreach (T obj in self)
      {
        if (pred(obj))
          return new int?(num);
        checked { ++num; }
      }
      return new int?();
    }

    [DebuggerHidden]
    public static IEnumerator WaitAll(this IEnumerable<IEnumerator> self)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new EnumerableExtension.\u003CWaitAll\u003Ec__Iterator2A()
      {
        self = self,
        \u003C\u0024\u003Eself = self
      };
    }

    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> self)
    {
      return self.Shuffle<T>(new Random());
    }

    [DebuggerHidden]
    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> self, Random random)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      EnumerableExtension.\u003CShuffle\u003Ec__Iterator2B<T> shuffleCIterator2B = new EnumerableExtension.\u003CShuffle\u003Ec__Iterator2B<T>()
      {
        self = self,
        random = random,
        \u003C\u0024\u003Eself = self,
        \u003C\u0024\u003Erandom = random
      };
      // ISSUE: reference to a compiler-generated field
      shuffleCIterator2B.\u0024PC = -2;
      return (IEnumerable<T>) shuffleCIterator2B;
    }
  }
}
