// Decompiled with JetBrains decompiler
// Type: UniLinq.Enumerable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
namespace UniLinq
{
  public static class Enumerable
  {
    public static TSource Aggregate<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, TSource, TSource> func)
    {
      Check.SourceAndFunc((object) source, (object) func);
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        TSource source1 = enumerator.MoveNext() ? enumerator.Current : throw Enumerable.EmptySequence();
        while (enumerator.MoveNext())
          source1 = func(source1, enumerator.Current);
        return source1;
      }
    }

    public static TAccumulate Aggregate<TSource, TAccumulate>(
      this IEnumerable<TSource> source,
      TAccumulate seed,
      Func<TAccumulate, TSource, TAccumulate> func)
    {
      Check.SourceAndFunc((object) source, (object) func);
      TAccumulate accumulate = seed;
      foreach (TSource source1 in source)
        accumulate = func(accumulate, source1);
      return accumulate;
    }

    public static TResult Aggregate<TSource, TAccumulate, TResult>(
      this IEnumerable<TSource> source,
      TAccumulate seed,
      Func<TAccumulate, TSource, TAccumulate> func,
      Func<TAccumulate, TResult> resultSelector)
    {
      Check.SourceAndFunc((object) source, (object) func);
      if (resultSelector == null)
        throw new ArgumentNullException(nameof (resultSelector));
      TAccumulate accumulate = seed;
      foreach (TSource source1 in source)
        accumulate = func(accumulate, source1);
      return resultSelector(accumulate);
    }

    public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
      Check.SourceAndPredicate((object) source, (object) predicate);
      foreach (TSource source1 in source)
      {
        if (!predicate(source1))
          return false;
      }
      return true;
    }

    public static bool Any<TSource>(this IEnumerable<TSource> source)
    {
      Check.Source((object) source);
      if (source is ICollection<TSource> sources)
        return sources.Count > 0;
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
        return enumerator.MoveNext();
    }

    public static bool Any<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
      Check.SourceAndPredicate((object) source, (object) predicate);
      foreach (TSource source1 in source)
      {
        if (predicate(source1))
          return true;
      }
      return false;
    }

    public static IEnumerable<TSource> AsEnumerable<TSource>(this IEnumerable<TSource> source)
    {
      return source;
    }

    public static double Average(this IEnumerable<int> source)
    {
      Check.Source((object) source);
      long num1 = 0;
      int num2 = 0;
      foreach (int num3 in source)
      {
        checked { num1 += (long) num3; }
        ++num2;
      }
      if (num2 == 0)
        throw Enumerable.EmptySequence();
      return (double) num1 / (double) num2;
    }

    public static double Average(this IEnumerable<long> source)
    {
      Check.Source((object) source);
      long num1 = 0;
      long num2 = 0;
      foreach (long num3 in source)
      {
        num1 += num3;
        ++num2;
      }
      if (num2 == 0L)
        throw Enumerable.EmptySequence();
      return (double) num1 / (double) num2;
    }

    public static double Average(this IEnumerable<double> source)
    {
      Check.Source((object) source);
      double num1 = 0.0;
      long num2 = 0;
      foreach (double num3 in source)
      {
        num1 += num3;
        ++num2;
      }
      if (num2 == 0L)
        throw Enumerable.EmptySequence();
      return num1 / (double) num2;
    }

    public static float Average(this IEnumerable<float> source)
    {
      Check.Source((object) source);
      float num1 = 0.0f;
      long num2 = 0;
      foreach (float num3 in source)
      {
        num1 += num3;
        ++num2;
      }
      if (num2 == 0L)
        throw Enumerable.EmptySequence();
      return num1 / (float) num2;
    }

    public static Decimal Average(this IEnumerable<Decimal> source)
    {
      Check.Source((object) source);
      Decimal num1 = 0M;
      long num2 = 0;
      foreach (Decimal num3 in source)
      {
        num1 += num3;
        ++num2;
      }
      if (num2 == 0L)
        throw Enumerable.EmptySequence();
      return num1 / (Decimal) num2;
    }

    private static TResult? AverageNullable<TElement, TAggregate, TResult>(
      this IEnumerable<TElement?> source,
      Func<TAggregate, TElement, TAggregate> func,
      Func<TAggregate, long, TResult> result)
      where TElement : struct
      where TAggregate : struct
      where TResult : struct
    {
      Check.Source((object) source);
      TAggregate aggregate = default (TAggregate);
      long num = 0;
      foreach (TElement? nullable in source)
      {
        if (nullable.HasValue)
        {
          aggregate = func(aggregate, nullable.Value);
          ++num;
        }
      }
      return num == 0L ? new TResult?() : new TResult?(result(aggregate, num));
    }

    public static double? Average(this IEnumerable<int?> source)
    {
      Check.Source((object) source);
      long num1 = 0;
      long num2 = 0;
      foreach (int? nullable in source)
      {
        if (nullable.HasValue)
        {
          num1 += (long) nullable.Value;
          ++num2;
        }
      }
      return num2 == 0L ? new double?() : new double?((double) num1 / (double) num2);
    }

    public static double? Average(this IEnumerable<long?> source)
    {
      Check.Source((object) source);
      long num1 = 0;
      long num2 = 0;
      foreach (long? nullable in source)
      {
        if (nullable.HasValue)
        {
          checked { num1 += nullable.Value; }
          ++num2;
        }
      }
      return num2 == 0L ? new double?() : new double?((double) num1 / (double) num2);
    }

    public static double? Average(this IEnumerable<double?> source)
    {
      Check.Source((object) source);
      double num1 = 0.0;
      long num2 = 0;
      foreach (double? nullable in source)
      {
        if (nullable.HasValue)
        {
          num1 += nullable.Value;
          ++num2;
        }
      }
      return num2 == 0L ? new double?() : new double?(num1 / (double) num2);
    }

    public static Decimal? Average(this IEnumerable<Decimal?> source)
    {
      Check.Source((object) source);
      Decimal num1 = 0M;
      long num2 = 0;
      foreach (Decimal? nullable in source)
      {
        if (nullable.HasValue)
        {
          num1 += nullable.Value;
          ++num2;
        }
      }
      return num2 == 0L ? new Decimal?() : new Decimal?(num1 / (Decimal) num2);
    }

    public static float? Average(this IEnumerable<float?> source)
    {
      Check.Source((object) source);
      float num1 = 0.0f;
      long num2 = 0;
      foreach (float? nullable in source)
      {
        if (nullable.HasValue)
        {
          num1 += nullable.Value;
          ++num2;
        }
      }
      return num2 == 0L ? new float?() : new float?(num1 / (float) num2);
    }

    public static double Average<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, int> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      long num1 = 0;
      long num2 = 0;
      foreach (TSource source1 in source)
      {
        num1 += (long) selector(source1);
        ++num2;
      }
      if (num2 == 0L)
        throw Enumerable.EmptySequence();
      return (double) num1 / (double) num2;
    }

    public static double? Average<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, int?> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      long num1 = 0;
      long num2 = 0;
      foreach (TSource source1 in source)
      {
        int? nullable = selector(source1);
        if (nullable.HasValue)
        {
          num1 += (long) nullable.Value;
          ++num2;
        }
      }
      return num2 == 0L ? new double?() : new double?((double) num1 / (double) num2);
    }

    public static double Average<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, long> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      long num1 = 0;
      long num2 = 0;
      foreach (TSource source1 in source)
      {
        checked { num1 += selector(source1); }
        ++num2;
      }
      if (num2 == 0L)
        throw Enumerable.EmptySequence();
      return (double) num1 / (double) num2;
    }

    public static double? Average<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, long?> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      long num1 = 0;
      long num2 = 0;
      foreach (TSource source1 in source)
      {
        long? nullable = selector(source1);
        if (nullable.HasValue)
        {
          checked { num1 += nullable.Value; }
          ++num2;
        }
      }
      return num2 == 0L ? new double?() : new double?((double) num1 / (double) num2);
    }

    public static double Average<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, double> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      double num1 = 0.0;
      long num2 = 0;
      foreach (TSource source1 in source)
      {
        num1 += selector(source1);
        ++num2;
      }
      if (num2 == 0L)
        throw Enumerable.EmptySequence();
      return num1 / (double) num2;
    }

    public static double? Average<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, double?> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      double num1 = 0.0;
      long num2 = 0;
      foreach (TSource source1 in source)
      {
        double? nullable = selector(source1);
        if (nullable.HasValue)
        {
          num1 += nullable.Value;
          ++num2;
        }
      }
      return num2 == 0L ? new double?() : new double?(num1 / (double) num2);
    }

    public static float Average<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, float> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      float num1 = 0.0f;
      long num2 = 0;
      foreach (TSource source1 in source)
      {
        num1 += selector(source1);
        ++num2;
      }
      if (num2 == 0L)
        throw Enumerable.EmptySequence();
      return num1 / (float) num2;
    }

    public static float? Average<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, float?> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      float num1 = 0.0f;
      long num2 = 0;
      foreach (TSource source1 in source)
      {
        float? nullable = selector(source1);
        if (nullable.HasValue)
        {
          num1 += nullable.Value;
          ++num2;
        }
      }
      return num2 == 0L ? new float?() : new float?(num1 / (float) num2);
    }

    public static Decimal Average<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, Decimal> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      Decimal num1 = 0M;
      long num2 = 0;
      foreach (TSource source1 in source)
      {
        num1 += selector(source1);
        ++num2;
      }
      if (num2 == 0L)
        throw Enumerable.EmptySequence();
      return num1 / (Decimal) num2;
    }

    public static Decimal? Average<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, Decimal?> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      Decimal num1 = 0M;
      long num2 = 0;
      foreach (TSource source1 in source)
      {
        Decimal? nullable = selector(source1);
        if (nullable.HasValue)
        {
          num1 += nullable.Value;
          ++num2;
        }
      }
      return num2 == 0L ? new Decimal?() : new Decimal?(num1 / (Decimal) num2);
    }

    public static IEnumerable<TResult> Cast<TResult>(this IEnumerable source)
    {
      Check.Source((object) source);
      return source is IEnumerable<TResult> results ? results : Enumerable.CreateCastIterator<TResult>(source);
    }

    [DebuggerHidden]
    private static IEnumerable<TResult> CreateCastIterator<TResult>(IEnumerable source)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Enumerable.\u003CCreateCastIterator\u003Ec__Iterator158<TResult> castIterator = new Enumerable.\u003CCreateCastIterator\u003Ec__Iterator158<TResult>()
      {
        source = source,
        \u003C\u0024\u003Esource = source
      };
      // ISSUE: reference to a compiler-generated field
      castIterator.\u0024PC = -2;
      return (IEnumerable<TResult>) castIterator;
    }

    public static IEnumerable<TSource> Concat<TSource>(
      this IEnumerable<TSource> first,
      IEnumerable<TSource> second)
    {
      Check.FirstAndSecond((object) first, (object) second);
      return Enumerable.CreateConcatIterator<TSource>(first, second);
    }

    [DebuggerHidden]
    private static IEnumerable<TSource> CreateConcatIterator<TSource>(
      IEnumerable<TSource> first,
      IEnumerable<TSource> second)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Enumerable.\u003CCreateConcatIterator\u003Ec__Iterator159<TSource> concatIterator = new Enumerable.\u003CCreateConcatIterator\u003Ec__Iterator159<TSource>()
      {
        first = first,
        second = second,
        \u003C\u0024\u003Efirst = first,
        \u003C\u0024\u003Esecond = second
      };
      // ISSUE: reference to a compiler-generated field
      concatIterator.\u0024PC = -2;
      return (IEnumerable<TSource>) concatIterator;
    }

    public static bool Contains<TSource>(this IEnumerable<TSource> source, TSource value)
    {
      return source is ICollection<TSource> sources ? sources.Contains(value) : source.Contains<TSource>(value, (IEqualityComparer<TSource>) null);
    }

    public static bool Contains<TSource>(
      this IEnumerable<TSource> source,
      TSource value,
      IEqualityComparer<TSource> comparer)
    {
      Check.Source((object) source);
      if (comparer == null)
        comparer = (IEqualityComparer<TSource>) EqualityComparer<TSource>.Default;
      foreach (TSource x in source)
      {
        if (comparer.Equals(x, value))
          return true;
      }
      return false;
    }

    public static int Count<TSource>(this IEnumerable<TSource> source)
    {
      Check.Source((object) source);
      if (source is ICollection<TSource> sources)
        return sources.Count;
      int num = 0;
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        while (enumerator.MoveNext())
          checked { ++num; }
      }
      return num;
    }

    public static int Count<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, bool> predicate)
    {
      Check.SourceAndSelector((object) source, (object) predicate);
      int num = 0;
      foreach (TSource source1 in source)
      {
        if (predicate(source1))
          checked { ++num; }
      }
      return num;
    }

    public static IEnumerable<TSource> DefaultIfEmpty<TSource>(this IEnumerable<TSource> source)
    {
      return source.DefaultIfEmpty<TSource>(default (TSource));
    }

    public static IEnumerable<TSource> DefaultIfEmpty<TSource>(
      this IEnumerable<TSource> source,
      TSource defaultValue)
    {
      Check.Source((object) source);
      return Enumerable.CreateDefaultIfEmptyIterator<TSource>(source, defaultValue);
    }

    [DebuggerHidden]
    private static IEnumerable<TSource> CreateDefaultIfEmptyIterator<TSource>(
      IEnumerable<TSource> source,
      TSource defaultValue)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Enumerable.\u003CCreateDefaultIfEmptyIterator\u003Ec__Iterator15A<TSource> defaultIfEmptyIterator = new Enumerable.\u003CCreateDefaultIfEmptyIterator\u003Ec__Iterator15A<TSource>()
      {
        source = source,
        defaultValue = defaultValue,
        \u003C\u0024\u003Esource = source,
        \u003C\u0024\u003EdefaultValue = defaultValue
      };
      // ISSUE: reference to a compiler-generated field
      defaultIfEmptyIterator.\u0024PC = -2;
      return (IEnumerable<TSource>) defaultIfEmptyIterator;
    }

    public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source)
    {
      return source.Distinct<TSource>((IEqualityComparer<TSource>) null);
    }

    public static IEnumerable<TSource> Distinct<TSource>(
      this IEnumerable<TSource> source,
      IEqualityComparer<TSource> comparer)
    {
      Check.Source((object) source);
      if (comparer == null)
        comparer = (IEqualityComparer<TSource>) EqualityComparer<TSource>.Default;
      return Enumerable.CreateDistinctIterator<TSource>(source, comparer);
    }

    [DebuggerHidden]
    private static IEnumerable<TSource> CreateDistinctIterator<TSource>(
      IEnumerable<TSource> source,
      IEqualityComparer<TSource> comparer)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Enumerable.\u003CCreateDistinctIterator\u003Ec__Iterator15B<TSource> distinctIterator = new Enumerable.\u003CCreateDistinctIterator\u003Ec__Iterator15B<TSource>()
      {
        comparer = comparer,
        source = source,
        \u003C\u0024\u003Ecomparer = comparer,
        \u003C\u0024\u003Esource = source
      };
      // ISSUE: reference to a compiler-generated field
      distinctIterator.\u0024PC = -2;
      return (IEnumerable<TSource>) distinctIterator;
    }

    private static TSource ElementAt<TSource>(
      this IEnumerable<TSource> source,
      int index,
      Enumerable.Fallback fallback)
    {
      long num = 0;
      foreach (TSource source1 in source)
      {
        if ((long) index == num++)
          return source1;
      }
      if (fallback == Enumerable.Fallback.Throw)
        throw new ArgumentOutOfRangeException();
      return default (TSource);
    }

    public static TSource ElementAt<TSource>(this IEnumerable<TSource> source, int index)
    {
      Check.Source((object) source);
      if (index < 0)
        throw new ArgumentOutOfRangeException();
      return source is IList<TSource> sourceList ? sourceList[index] : source.ElementAt<TSource>(index, Enumerable.Fallback.Throw);
    }

    public static TSource ElementAtOrDefault<TSource>(this IEnumerable<TSource> source, int index)
    {
      Check.Source((object) source);
      if (index < 0)
        return default (TSource);
      if (!(source is IList<TSource> sourceList))
        return source.ElementAt<TSource>(index, Enumerable.Fallback.Default);
      return index < sourceList.Count ? sourceList[index] : default (TSource);
    }

    public static IEnumerable<TResult> Empty<TResult>() => (IEnumerable<TResult>) new TResult[0];

    public static IEnumerable<TSource> Except<TSource>(
      this IEnumerable<TSource> first,
      IEnumerable<TSource> second)
    {
      return first.Except<TSource>(second, (IEqualityComparer<TSource>) null);
    }

    public static IEnumerable<TSource> Except<TSource>(
      this IEnumerable<TSource> first,
      IEnumerable<TSource> second,
      IEqualityComparer<TSource> comparer)
    {
      Check.FirstAndSecond((object) first, (object) second);
      if (comparer == null)
        comparer = (IEqualityComparer<TSource>) EqualityComparer<TSource>.Default;
      return Enumerable.CreateExceptIterator<TSource>(first, second, comparer);
    }

    [DebuggerHidden]
    private static IEnumerable<TSource> CreateExceptIterator<TSource>(
      IEnumerable<TSource> first,
      IEnumerable<TSource> second,
      IEqualityComparer<TSource> comparer)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Enumerable.\u003CCreateExceptIterator\u003Ec__Iterator15C<TSource> exceptIterator = new Enumerable.\u003CCreateExceptIterator\u003Ec__Iterator15C<TSource>()
      {
        second = second,
        comparer = comparer,
        first = first,
        \u003C\u0024\u003Esecond = second,
        \u003C\u0024\u003Ecomparer = comparer,
        \u003C\u0024\u003Efirst = first
      };
      // ISSUE: reference to a compiler-generated field
      exceptIterator.\u0024PC = -2;
      return (IEnumerable<TSource>) exceptIterator;
    }

    private static TSource First<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, bool> predicate,
      Enumerable.Fallback fallback)
    {
      foreach (TSource source1 in source)
      {
        if (predicate(source1))
          return source1;
      }
      if (fallback == Enumerable.Fallback.Throw)
        throw Enumerable.NoMatchingElement();
      return default (TSource);
    }

    public static TSource First<TSource>(this IEnumerable<TSource> source)
    {
      Check.Source((object) source);
      if (source is IList<TSource> sourceList)
      {
        if (sourceList.Count != 0)
          return sourceList[0];
      }
      else
      {
        using (IEnumerator<TSource> enumerator = source.GetEnumerator())
        {
          if (enumerator.MoveNext())
            return enumerator.Current;
        }
      }
      throw Enumerable.EmptySequence();
    }

    public static TSource First<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, bool> predicate)
    {
      Check.SourceAndPredicate((object) source, (object) predicate);
      return source.First<TSource>(predicate, Enumerable.Fallback.Throw);
    }

    public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source)
    {
      Check.Source((object) source);
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        if (enumerator.MoveNext())
          return enumerator.Current;
      }
      return default (TSource);
    }

    public static TSource FirstOrDefault<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, bool> predicate)
    {
      Check.SourceAndPredicate((object) source, (object) predicate);
      return source.First<TSource>(predicate, Enumerable.Fallback.Default);
    }

    public static IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector)
    {
      return source.GroupBy<TSource, TKey>(keySelector, (IEqualityComparer<TKey>) null);
    }

    public static IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      IEqualityComparer<TKey> comparer)
    {
      Check.SourceAndKeySelector((object) source, (object) keySelector);
      return source.CreateGroupByIterator<TSource, TKey>(keySelector, comparer);
    }

    [DebuggerHidden]
    private static IEnumerable<IGrouping<TKey, TSource>> CreateGroupByIterator<TSource, TKey>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      IEqualityComparer<TKey> comparer)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Enumerable.\u003CCreateGroupByIterator\u003Ec__Iterator15D<TSource, TKey> groupByIterator = new Enumerable.\u003CCreateGroupByIterator\u003Ec__Iterator15D<TSource, TKey>()
      {
        comparer = comparer,
        source = source,
        keySelector = keySelector,
        \u003C\u0024\u003Ecomparer = comparer,
        \u003C\u0024\u003Esource = source,
        \u003C\u0024\u003EkeySelector = keySelector
      };
      // ISSUE: reference to a compiler-generated field
      groupByIterator.\u0024PC = -2;
      return (IEnumerable<IGrouping<TKey, TSource>>) groupByIterator;
    }

    public static IEnumerable<IGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      Func<TSource, TElement> elementSelector)
    {
      return source.GroupBy<TSource, TKey, TElement>(keySelector, elementSelector, (IEqualityComparer<TKey>) null);
    }

    public static IEnumerable<IGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      Func<TSource, TElement> elementSelector,
      IEqualityComparer<TKey> comparer)
    {
      Check.SourceAndKeyElementSelectors((object) source, (object) keySelector, (object) elementSelector);
      return source.CreateGroupByIterator<TSource, TKey, TElement>(keySelector, elementSelector, comparer);
    }

    [DebuggerHidden]
    private static IEnumerable<IGrouping<TKey, TElement>> CreateGroupByIterator<TSource, TKey, TElement>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      Func<TSource, TElement> elementSelector,
      IEqualityComparer<TKey> comparer)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Enumerable.\u003CCreateGroupByIterator\u003Ec__Iterator15E<TSource, TKey, TElement> groupByIterator = new Enumerable.\u003CCreateGroupByIterator\u003Ec__Iterator15E<TSource, TKey, TElement>()
      {
        comparer = comparer,
        source = source,
        keySelector = keySelector,
        elementSelector = elementSelector,
        \u003C\u0024\u003Ecomparer = comparer,
        \u003C\u0024\u003Esource = source,
        \u003C\u0024\u003EkeySelector = keySelector,
        \u003C\u0024\u003EelementSelector = elementSelector
      };
      // ISSUE: reference to a compiler-generated field
      groupByIterator.\u0024PC = -2;
      return (IEnumerable<IGrouping<TKey, TElement>>) groupByIterator;
    }

    public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      Func<TSource, TElement> elementSelector,
      Func<TKey, IEnumerable<TElement>, TResult> resultSelector)
    {
      return source.GroupBy<TSource, TKey, TElement, TResult>(keySelector, elementSelector, resultSelector, (IEqualityComparer<TKey>) null);
    }

    public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      Func<TSource, TElement> elementSelector,
      Func<TKey, IEnumerable<TElement>, TResult> resultSelector,
      IEqualityComparer<TKey> comparer)
    {
      Check.GroupBySelectors((object) source, (object) keySelector, (object) elementSelector, (object) resultSelector);
      return source.CreateGroupByIterator<TSource, TKey, TElement, TResult>(keySelector, elementSelector, resultSelector, comparer);
    }

    [DebuggerHidden]
    private static IEnumerable<TResult> CreateGroupByIterator<TSource, TKey, TElement, TResult>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      Func<TSource, TElement> elementSelector,
      Func<TKey, IEnumerable<TElement>, TResult> resultSelector,
      IEqualityComparer<TKey> comparer)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Enumerable.\u003CCreateGroupByIterator\u003Ec__Iterator15F<TSource, TKey, TElement, TResult> groupByIterator = new Enumerable.\u003CCreateGroupByIterator\u003Ec__Iterator15F<TSource, TKey, TElement, TResult>()
      {
        source = source,
        keySelector = keySelector,
        elementSelector = elementSelector,
        comparer = comparer,
        resultSelector = resultSelector,
        \u003C\u0024\u003Esource = source,
        \u003C\u0024\u003EkeySelector = keySelector,
        \u003C\u0024\u003EelementSelector = elementSelector,
        \u003C\u0024\u003Ecomparer = comparer,
        \u003C\u0024\u003EresultSelector = resultSelector
      };
      // ISSUE: reference to a compiler-generated field
      groupByIterator.\u0024PC = -2;
      return (IEnumerable<TResult>) groupByIterator;
    }

    public static IEnumerable<TResult> GroupBy<TSource, TKey, TResult>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      Func<TKey, IEnumerable<TSource>, TResult> resultSelector)
    {
      return source.GroupBy<TSource, TKey, TResult>(keySelector, resultSelector, (IEqualityComparer<TKey>) null);
    }

    public static IEnumerable<TResult> GroupBy<TSource, TKey, TResult>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      Func<TKey, IEnumerable<TSource>, TResult> resultSelector,
      IEqualityComparer<TKey> comparer)
    {
      Check.SourceAndKeyResultSelectors((object) source, (object) keySelector, (object) resultSelector);
      return source.CreateGroupByIterator<TSource, TKey, TResult>(keySelector, resultSelector, comparer);
    }

    [DebuggerHidden]
    private static IEnumerable<TResult> CreateGroupByIterator<TSource, TKey, TResult>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      Func<TKey, IEnumerable<TSource>, TResult> resultSelector,
      IEqualityComparer<TKey> comparer)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Enumerable.\u003CCreateGroupByIterator\u003Ec__Iterator160<TSource, TKey, TResult> groupByIterator = new Enumerable.\u003CCreateGroupByIterator\u003Ec__Iterator160<TSource, TKey, TResult>()
      {
        source = source,
        keySelector = keySelector,
        comparer = comparer,
        resultSelector = resultSelector,
        \u003C\u0024\u003Esource = source,
        \u003C\u0024\u003EkeySelector = keySelector,
        \u003C\u0024\u003Ecomparer = comparer,
        \u003C\u0024\u003EresultSelector = resultSelector
      };
      // ISSUE: reference to a compiler-generated field
      groupByIterator.\u0024PC = -2;
      return (IEnumerable<TResult>) groupByIterator;
    }

    public static IEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(
      this IEnumerable<TOuter> outer,
      IEnumerable<TInner> inner,
      Func<TOuter, TKey> outerKeySelector,
      Func<TInner, TKey> innerKeySelector,
      Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
    {
      return outer.GroupJoin<TOuter, TInner, TKey, TResult>(inner, outerKeySelector, innerKeySelector, resultSelector, (IEqualityComparer<TKey>) null);
    }

    public static IEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(
      this IEnumerable<TOuter> outer,
      IEnumerable<TInner> inner,
      Func<TOuter, TKey> outerKeySelector,
      Func<TInner, TKey> innerKeySelector,
      Func<TOuter, IEnumerable<TInner>, TResult> resultSelector,
      IEqualityComparer<TKey> comparer)
    {
      Check.JoinSelectors((object) outer, (object) inner, (object) outerKeySelector, (object) innerKeySelector, (object) resultSelector);
      if (comparer == null)
        comparer = (IEqualityComparer<TKey>) EqualityComparer<TKey>.Default;
      return outer.CreateGroupJoinIterator<TOuter, TInner, TKey, TResult>(inner, outerKeySelector, innerKeySelector, resultSelector, comparer);
    }

    [DebuggerHidden]
    private static IEnumerable<TResult> CreateGroupJoinIterator<TOuter, TInner, TKey, TResult>(
      this IEnumerable<TOuter> outer,
      IEnumerable<TInner> inner,
      Func<TOuter, TKey> outerKeySelector,
      Func<TInner, TKey> innerKeySelector,
      Func<TOuter, IEnumerable<TInner>, TResult> resultSelector,
      IEqualityComparer<TKey> comparer)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Enumerable.\u003CCreateGroupJoinIterator\u003Ec__Iterator161<TOuter, TInner, TKey, TResult> groupJoinIterator = new Enumerable.\u003CCreateGroupJoinIterator\u003Ec__Iterator161<TOuter, TInner, TKey, TResult>()
      {
        inner = inner,
        innerKeySelector = innerKeySelector,
        comparer = comparer,
        outer = outer,
        outerKeySelector = outerKeySelector,
        resultSelector = resultSelector,
        \u003C\u0024\u003Einner = inner,
        \u003C\u0024\u003EinnerKeySelector = innerKeySelector,
        \u003C\u0024\u003Ecomparer = comparer,
        \u003C\u0024\u003Eouter = outer,
        \u003C\u0024\u003EouterKeySelector = outerKeySelector,
        \u003C\u0024\u003EresultSelector = resultSelector
      };
      // ISSUE: reference to a compiler-generated field
      groupJoinIterator.\u0024PC = -2;
      return (IEnumerable<TResult>) groupJoinIterator;
    }

    public static IEnumerable<TSource> Intersect<TSource>(
      this IEnumerable<TSource> first,
      IEnumerable<TSource> second)
    {
      return first.Intersect<TSource>(second, (IEqualityComparer<TSource>) null);
    }

    public static IEnumerable<TSource> Intersect<TSource>(
      this IEnumerable<TSource> first,
      IEnumerable<TSource> second,
      IEqualityComparer<TSource> comparer)
    {
      Check.FirstAndSecond((object) first, (object) second);
      if (comparer == null)
        comparer = (IEqualityComparer<TSource>) EqualityComparer<TSource>.Default;
      return Enumerable.CreateIntersectIterator<TSource>(first, second, comparer);
    }

    [DebuggerHidden]
    private static IEnumerable<TSource> CreateIntersectIterator<TSource>(
      IEnumerable<TSource> first,
      IEnumerable<TSource> second,
      IEqualityComparer<TSource> comparer)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Enumerable.\u003CCreateIntersectIterator\u003Ec__Iterator162<TSource> intersectIterator = new Enumerable.\u003CCreateIntersectIterator\u003Ec__Iterator162<TSource>()
      {
        second = second,
        comparer = comparer,
        first = first,
        \u003C\u0024\u003Esecond = second,
        \u003C\u0024\u003Ecomparer = comparer,
        \u003C\u0024\u003Efirst = first
      };
      // ISSUE: reference to a compiler-generated field
      intersectIterator.\u0024PC = -2;
      return (IEnumerable<TSource>) intersectIterator;
    }

    public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(
      this IEnumerable<TOuter> outer,
      IEnumerable<TInner> inner,
      Func<TOuter, TKey> outerKeySelector,
      Func<TInner, TKey> innerKeySelector,
      Func<TOuter, TInner, TResult> resultSelector,
      IEqualityComparer<TKey> comparer)
    {
      Check.JoinSelectors((object) outer, (object) inner, (object) outerKeySelector, (object) innerKeySelector, (object) resultSelector);
      if (comparer == null)
        comparer = (IEqualityComparer<TKey>) EqualityComparer<TKey>.Default;
      return outer.CreateJoinIterator<TOuter, TInner, TKey, TResult>(inner, outerKeySelector, innerKeySelector, resultSelector, comparer);
    }

    [DebuggerHidden]
    private static IEnumerable<TResult> CreateJoinIterator<TOuter, TInner, TKey, TResult>(
      this IEnumerable<TOuter> outer,
      IEnumerable<TInner> inner,
      Func<TOuter, TKey> outerKeySelector,
      Func<TInner, TKey> innerKeySelector,
      Func<TOuter, TInner, TResult> resultSelector,
      IEqualityComparer<TKey> comparer)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Enumerable.\u003CCreateJoinIterator\u003Ec__Iterator163<TOuter, TInner, TKey, TResult> joinIterator = new Enumerable.\u003CCreateJoinIterator\u003Ec__Iterator163<TOuter, TInner, TKey, TResult>()
      {
        inner = inner,
        innerKeySelector = innerKeySelector,
        comparer = comparer,
        outer = outer,
        outerKeySelector = outerKeySelector,
        resultSelector = resultSelector,
        \u003C\u0024\u003Einner = inner,
        \u003C\u0024\u003EinnerKeySelector = innerKeySelector,
        \u003C\u0024\u003Ecomparer = comparer,
        \u003C\u0024\u003Eouter = outer,
        \u003C\u0024\u003EouterKeySelector = outerKeySelector,
        \u003C\u0024\u003EresultSelector = resultSelector
      };
      // ISSUE: reference to a compiler-generated field
      joinIterator.\u0024PC = -2;
      return (IEnumerable<TResult>) joinIterator;
    }

    public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(
      this IEnumerable<TOuter> outer,
      IEnumerable<TInner> inner,
      Func<TOuter, TKey> outerKeySelector,
      Func<TInner, TKey> innerKeySelector,
      Func<TOuter, TInner, TResult> resultSelector)
    {
      return outer.Join<TOuter, TInner, TKey, TResult>(inner, outerKeySelector, innerKeySelector, resultSelector, (IEqualityComparer<TKey>) null);
    }

    private static TSource Last<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, bool> predicate,
      Enumerable.Fallback fallback)
    {
      bool flag = true;
      TSource source1 = default (TSource);
      foreach (TSource source2 in source)
      {
        if (predicate(source2))
        {
          source1 = source2;
          flag = false;
        }
      }
      if (!flag || fallback != Enumerable.Fallback.Throw)
        return source1;
      throw Enumerable.NoMatchingElement();
    }

    public static TSource Last<TSource>(this IEnumerable<TSource> source)
    {
      Check.Source((object) source);
      switch (source)
      {
        case ICollection<TSource> sources when sources.Count == 0:
          throw Enumerable.EmptySequence();
        case IList<TSource> sourceList:
          return sourceList[sourceList.Count - 1];
        default:
          bool flag = true;
          TSource source1 = default (TSource);
          foreach (TSource source2 in source)
          {
            source1 = source2;
            flag = false;
          }
          if (!flag)
            return source1;
          throw Enumerable.EmptySequence();
      }
    }

    public static TSource Last<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, bool> predicate)
    {
      Check.SourceAndPredicate((object) source, (object) predicate);
      return source.Last<TSource>(predicate, Enumerable.Fallback.Throw);
    }

    public static TSource LastOrDefault<TSource>(this IEnumerable<TSource> source)
    {
      Check.Source((object) source);
      if (source is IList<TSource> sourceList)
        return sourceList.Count > 0 ? sourceList[sourceList.Count - 1] : default (TSource);
      bool flag = true;
      TSource source1 = default (TSource);
      foreach (TSource source2 in source)
      {
        source1 = source2;
        flag = false;
      }
      return !flag ? source1 : source1;
    }

    public static TSource LastOrDefault<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, bool> predicate)
    {
      Check.SourceAndPredicate((object) source, (object) predicate);
      return source.Last<TSource>(predicate, Enumerable.Fallback.Default);
    }

    public static long LongCount<TSource>(this IEnumerable<TSource> source)
    {
      Check.Source((object) source);
      if (source is TSource[] sourceArray)
        return sourceArray.LongLength;
      long num = 0;
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        while (enumerator.MoveNext())
          ++num;
      }
      return num;
    }

    public static long LongCount<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, bool> predicate)
    {
      Check.SourceAndSelector((object) source, (object) predicate);
      long num = 0;
      foreach (TSource source1 in source)
      {
        if (predicate(source1))
          ++num;
      }
      return num;
    }

    public static int Max(this IEnumerable<int> source)
    {
      Check.Source((object) source);
      bool flag = true;
      int val2 = int.MinValue;
      foreach (int val1 in source)
      {
        val2 = Math.Max(val1, val2);
        flag = false;
      }
      if (flag)
        throw Enumerable.EmptySequence();
      return val2;
    }

    public static long Max(this IEnumerable<long> source)
    {
      Check.Source((object) source);
      bool flag = true;
      long val2 = long.MinValue;
      foreach (long val1 in source)
      {
        val2 = Math.Max(val1, val2);
        flag = false;
      }
      if (flag)
        throw Enumerable.EmptySequence();
      return val2;
    }

    public static double Max(this IEnumerable<double> source)
    {
      Check.Source((object) source);
      bool flag = true;
      double val2 = double.MinValue;
      foreach (double val1 in source)
      {
        val2 = Math.Max(val1, val2);
        flag = false;
      }
      if (flag)
        throw Enumerable.EmptySequence();
      return val2;
    }

    public static float Max(this IEnumerable<float> source)
    {
      Check.Source((object) source);
      bool flag = true;
      float val2 = float.MinValue;
      foreach (float val1 in source)
      {
        val2 = Math.Max(val1, val2);
        flag = false;
      }
      if (flag)
        throw Enumerable.EmptySequence();
      return val2;
    }

    public static Decimal Max(this IEnumerable<Decimal> source)
    {
      Check.Source((object) source);
      bool flag = true;
      Decimal val2 = Decimal.MinValue;
      foreach (Decimal val1 in source)
      {
        val2 = Math.Max(val1, val2);
        flag = false;
      }
      if (flag)
        throw Enumerable.EmptySequence();
      return val2;
    }

    public static int? Max(this IEnumerable<int?> source)
    {
      Check.Source((object) source);
      bool flag = true;
      int val2 = int.MinValue;
      foreach (int? nullable in source)
      {
        if (nullable.HasValue)
        {
          val2 = Math.Max(nullable.Value, val2);
          flag = false;
        }
      }
      return flag ? new int?() : new int?(val2);
    }

    public static long? Max(this IEnumerable<long?> source)
    {
      Check.Source((object) source);
      bool flag = true;
      long val2 = long.MinValue;
      foreach (long? nullable in source)
      {
        if (nullable.HasValue)
        {
          val2 = Math.Max(nullable.Value, val2);
          flag = false;
        }
      }
      return flag ? new long?() : new long?(val2);
    }

    public static double? Max(this IEnumerable<double?> source)
    {
      Check.Source((object) source);
      bool flag = true;
      double val2 = double.MinValue;
      foreach (double? nullable in source)
      {
        if (nullable.HasValue)
        {
          val2 = Math.Max(nullable.Value, val2);
          flag = false;
        }
      }
      return flag ? new double?() : new double?(val2);
    }

    public static float? Max(this IEnumerable<float?> source)
    {
      Check.Source((object) source);
      bool flag = true;
      float val2 = float.MinValue;
      foreach (float? nullable in source)
      {
        if (nullable.HasValue)
        {
          val2 = Math.Max(nullable.Value, val2);
          flag = false;
        }
      }
      return flag ? new float?() : new float?(val2);
    }

    public static Decimal? Max(this IEnumerable<Decimal?> source)
    {
      Check.Source((object) source);
      bool flag = true;
      Decimal val2 = Decimal.MinValue;
      foreach (Decimal? nullable in source)
      {
        if (nullable.HasValue)
        {
          val2 = Math.Max(nullable.Value, val2);
          flag = false;
        }
      }
      return flag ? new Decimal?() : new Decimal?(val2);
    }

    public static TSource Max<TSource>(this IEnumerable<TSource> source)
    {
      Check.Source((object) source);
      Comparer<TSource> comparer = Comparer<TSource>.Default;
      TSource y = default (TSource);
      if ((object) default (TSource) == null)
      {
        foreach (TSource x in source)
        {
          if ((object) x != null && ((object) y == null || comparer.Compare(x, y) > 0))
            y = x;
        }
      }
      else
      {
        bool flag = true;
        foreach (TSource x in source)
        {
          if (flag)
          {
            y = x;
            flag = false;
          }
          else if (comparer.Compare(x, y) > 0)
            y = x;
        }
        if (flag)
          throw Enumerable.EmptySequence();
      }
      return y;
    }

    public static int Max<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      bool flag = true;
      int val2 = int.MinValue;
      foreach (TSource source1 in source)
      {
        val2 = Math.Max(selector(source1), val2);
        flag = false;
      }
      if (flag)
        throw Enumerable.NoMatchingElement();
      return val2;
    }

    public static long Max<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      bool flag = true;
      long val2 = long.MinValue;
      foreach (TSource source1 in source)
      {
        val2 = Math.Max(selector(source1), val2);
        flag = false;
      }
      if (flag)
        throw Enumerable.NoMatchingElement();
      return val2;
    }

    public static double Max<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, double> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      bool flag = true;
      double val2 = double.MinValue;
      foreach (TSource source1 in source)
      {
        val2 = Math.Max(selector(source1), val2);
        flag = false;
      }
      if (flag)
        throw Enumerable.NoMatchingElement();
      return val2;
    }

    public static float Max<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, float> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      bool flag = true;
      float val2 = float.MinValue;
      foreach (TSource source1 in source)
      {
        val2 = Math.Max(selector(source1), val2);
        flag = false;
      }
      if (flag)
        throw Enumerable.NoMatchingElement();
      return val2;
    }

    public static Decimal Max<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, Decimal> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      bool flag = true;
      Decimal val2 = Decimal.MinValue;
      foreach (TSource source1 in source)
      {
        val2 = Math.Max(selector(source1), val2);
        flag = false;
      }
      if (flag)
        throw Enumerable.NoMatchingElement();
      return val2;
    }

    private static U Iterate<T, U>(IEnumerable<T> source, U initValue, Func<T, U, U> selector)
    {
      bool flag = true;
      foreach (T obj in source)
      {
        initValue = selector(obj, initValue);
        flag = false;
      }
      if (flag)
        throw Enumerable.NoMatchingElement();
      return initValue;
    }

    public static int? Max<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      bool flag = true;
      int? nullable1 = new int?();
      foreach (TSource source1 in source)
      {
        int? nullable2 = selector(source1);
        if (!nullable1.HasValue)
          nullable1 = nullable2;
        else if ((!nullable2.HasValue || !nullable1.HasValue ? 0 : (nullable2.Value > nullable1.Value ? 1 : 0)) != 0)
          nullable1 = nullable2;
        flag = false;
      }
      return flag ? new int?() : nullable1;
    }

    public static long? Max<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, long?> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      bool flag = true;
      long? nullable1 = new long?();
      foreach (TSource source1 in source)
      {
        long? nullable2 = selector(source1);
        if (!nullable1.HasValue)
          nullable1 = nullable2;
        else if ((!nullable2.HasValue || !nullable1.HasValue ? 0 : (nullable2.Value > nullable1.Value ? 1 : 0)) != 0)
          nullable1 = nullable2;
        flag = false;
      }
      return flag ? new long?() : nullable1;
    }

    public static double? Max<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, double?> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      bool flag = true;
      double? nullable1 = new double?();
      foreach (TSource source1 in source)
      {
        double? nullable2 = selector(source1);
        if (!nullable1.HasValue)
          nullable1 = nullable2;
        else if ((!nullable2.HasValue || !nullable1.HasValue ? 0 : (nullable2.Value > nullable1.Value ? 1 : 0)) != 0)
          nullable1 = nullable2;
        flag = false;
      }
      return flag ? new double?() : nullable1;
    }

    public static float? Max<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, float?> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      bool flag = true;
      float? nullable1 = new float?();
      foreach (TSource source1 in source)
      {
        float? nullable2 = selector(source1);
        if (!nullable1.HasValue)
          nullable1 = nullable2;
        else if ((!nullable2.HasValue || !nullable1.HasValue ? 0 : ((double) nullable2.Value > (double) nullable1.Value ? 1 : 0)) != 0)
          nullable1 = nullable2;
        flag = false;
      }
      return flag ? new float?() : nullable1;
    }

    public static Decimal? Max<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, Decimal?> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      bool flag = true;
      Decimal? nullable1 = new Decimal?();
      foreach (TSource source1 in source)
      {
        Decimal? nullable2 = selector(source1);
        if (!nullable1.HasValue)
          nullable1 = nullable2;
        else if ((!nullable2.HasValue || !nullable1.HasValue ? 0 : (nullable2.Value > nullable1.Value ? 1 : 0)) != 0)
          nullable1 = nullable2;
        flag = false;
      }
      return flag ? new Decimal?() : nullable1;
    }

    public static TResult Max<TSource, TResult>(
      this IEnumerable<TSource> source,
      Func<TSource, TResult> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      return source.Select<TSource, TResult>(selector).Max<TResult>();
    }

    public static int Min(this IEnumerable<int> source)
    {
      Check.Source((object) source);
      bool flag = true;
      int val2 = int.MaxValue;
      foreach (int val1 in source)
      {
        val2 = Math.Min(val1, val2);
        flag = false;
      }
      if (flag)
        throw Enumerable.EmptySequence();
      return val2;
    }

    public static long Min(this IEnumerable<long> source)
    {
      Check.Source((object) source);
      bool flag = true;
      long val2 = long.MaxValue;
      foreach (long val1 in source)
      {
        val2 = Math.Min(val1, val2);
        flag = false;
      }
      if (flag)
        throw Enumerable.EmptySequence();
      return val2;
    }

    public static double Min(this IEnumerable<double> source)
    {
      Check.Source((object) source);
      bool flag = true;
      double val2 = double.MaxValue;
      foreach (double val1 in source)
      {
        val2 = Math.Min(val1, val2);
        flag = false;
      }
      if (flag)
        throw Enumerable.EmptySequence();
      return val2;
    }

    public static float Min(this IEnumerable<float> source)
    {
      Check.Source((object) source);
      bool flag = true;
      float val2 = float.MaxValue;
      foreach (float val1 in source)
      {
        val2 = Math.Min(val1, val2);
        flag = false;
      }
      if (flag)
        throw Enumerable.EmptySequence();
      return val2;
    }

    public static Decimal Min(this IEnumerable<Decimal> source)
    {
      Check.Source((object) source);
      bool flag = true;
      Decimal val2 = Decimal.MaxValue;
      foreach (Decimal val1 in source)
      {
        val2 = Math.Min(val1, val2);
        flag = false;
      }
      if (flag)
        throw Enumerable.EmptySequence();
      return val2;
    }

    public static int? Min(this IEnumerable<int?> source)
    {
      Check.Source((object) source);
      bool flag = true;
      int val2 = int.MaxValue;
      foreach (int? nullable in source)
      {
        if (nullable.HasValue)
        {
          val2 = Math.Min(nullable.Value, val2);
          flag = false;
        }
      }
      return flag ? new int?() : new int?(val2);
    }

    public static long? Min(this IEnumerable<long?> source)
    {
      Check.Source((object) source);
      bool flag = true;
      long val2 = long.MaxValue;
      foreach (long? nullable in source)
      {
        if (nullable.HasValue)
        {
          val2 = Math.Min(nullable.Value, val2);
          flag = false;
        }
      }
      return flag ? new long?() : new long?(val2);
    }

    public static double? Min(this IEnumerable<double?> source)
    {
      Check.Source((object) source);
      bool flag = true;
      double val2 = double.MaxValue;
      foreach (double? nullable in source)
      {
        if (nullable.HasValue)
        {
          val2 = Math.Min(nullable.Value, val2);
          flag = false;
        }
      }
      return flag ? new double?() : new double?(val2);
    }

    public static float? Min(this IEnumerable<float?> source)
    {
      Check.Source((object) source);
      bool flag = true;
      float val2 = float.MaxValue;
      foreach (float? nullable in source)
      {
        if (nullable.HasValue)
        {
          val2 = Math.Min(nullable.Value, val2);
          flag = false;
        }
      }
      return flag ? new float?() : new float?(val2);
    }

    public static Decimal? Min(this IEnumerable<Decimal?> source)
    {
      Check.Source((object) source);
      bool flag = true;
      Decimal val2 = Decimal.MaxValue;
      foreach (Decimal? nullable in source)
      {
        if (nullable.HasValue)
        {
          val2 = Math.Min(nullable.Value, val2);
          flag = false;
        }
      }
      return flag ? new Decimal?() : new Decimal?(val2);
    }

    public static TSource Min<TSource>(this IEnumerable<TSource> source)
    {
      Check.Source((object) source);
      Comparer<TSource> comparer = Comparer<TSource>.Default;
      TSource y = default (TSource);
      if ((object) default (TSource) == null)
      {
        foreach (TSource x in source)
        {
          if ((object) x != null && ((object) y == null || comparer.Compare(x, y) < 0))
            y = x;
        }
      }
      else
      {
        bool flag = true;
        foreach (TSource x in source)
        {
          if (flag)
          {
            y = x;
            flag = false;
          }
          else if (comparer.Compare(x, y) < 0)
            y = x;
        }
        if (flag)
          throw Enumerable.EmptySequence();
      }
      return y;
    }

    public static int Min<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      bool flag = true;
      int val2 = int.MaxValue;
      foreach (TSource source1 in source)
      {
        val2 = Math.Min(selector(source1), val2);
        flag = false;
      }
      if (flag)
        throw Enumerable.NoMatchingElement();
      return val2;
    }

    public static long Min<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      bool flag = true;
      long val2 = long.MaxValue;
      foreach (TSource source1 in source)
      {
        val2 = Math.Min(selector(source1), val2);
        flag = false;
      }
      if (flag)
        throw Enumerable.NoMatchingElement();
      return val2;
    }

    public static double Min<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, double> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      bool flag = true;
      double val2 = double.MaxValue;
      foreach (TSource source1 in source)
      {
        val2 = Math.Min(selector(source1), val2);
        flag = false;
      }
      if (flag)
        throw Enumerable.NoMatchingElement();
      return val2;
    }

    public static float Min<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, float> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      bool flag = true;
      float val2 = float.MaxValue;
      foreach (TSource source1 in source)
      {
        val2 = Math.Min(selector(source1), val2);
        flag = false;
      }
      if (flag)
        throw Enumerable.NoMatchingElement();
      return val2;
    }

    public static Decimal Min<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, Decimal> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      bool flag = true;
      Decimal val2 = Decimal.MaxValue;
      foreach (TSource source1 in source)
      {
        val2 = Math.Min(selector(source1), val2);
        flag = false;
      }
      if (flag)
        throw Enumerable.NoMatchingElement();
      return val2;
    }

    public static int? Min<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      bool flag = true;
      int? nullable1 = new int?();
      foreach (TSource source1 in source)
      {
        int? nullable2 = selector(source1);
        if (!nullable1.HasValue)
          nullable1 = nullable2;
        else if ((!nullable2.HasValue || !nullable1.HasValue ? 0 : (nullable2.Value < nullable1.Value ? 1 : 0)) != 0)
          nullable1 = nullable2;
        flag = false;
      }
      return flag ? new int?() : nullable1;
    }

    public static long? Min<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, long?> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      bool flag = true;
      long? nullable1 = new long?();
      foreach (TSource source1 in source)
      {
        long? nullable2 = selector(source1);
        if (!nullable1.HasValue)
          nullable1 = nullable2;
        else if ((!nullable2.HasValue || !nullable1.HasValue ? 0 : (nullable2.Value < nullable1.Value ? 1 : 0)) != 0)
          nullable1 = nullable2;
        flag = false;
      }
      return flag ? new long?() : nullable1;
    }

    public static float? Min<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, float?> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      bool flag = true;
      float? nullable1 = new float?();
      foreach (TSource source1 in source)
      {
        float? nullable2 = selector(source1);
        if (!nullable1.HasValue)
          nullable1 = nullable2;
        else if ((!nullable2.HasValue || !nullable1.HasValue ? 0 : ((double) nullable2.Value < (double) nullable1.Value ? 1 : 0)) != 0)
          nullable1 = nullable2;
        flag = false;
      }
      return flag ? new float?() : nullable1;
    }

    public static double? Min<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, double?> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      bool flag = true;
      double? nullable1 = new double?();
      foreach (TSource source1 in source)
      {
        double? nullable2 = selector(source1);
        if (!nullable1.HasValue)
          nullable1 = nullable2;
        else if ((!nullable2.HasValue || !nullable1.HasValue ? 0 : (nullable2.Value < nullable1.Value ? 1 : 0)) != 0)
          nullable1 = nullable2;
        flag = false;
      }
      return flag ? new double?() : nullable1;
    }

    public static Decimal? Min<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, Decimal?> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      bool flag = true;
      Decimal? nullable1 = new Decimal?();
      foreach (TSource source1 in source)
      {
        Decimal? nullable2 = selector(source1);
        if (!nullable1.HasValue)
          nullable1 = nullable2;
        else if ((!nullable2.HasValue || !nullable1.HasValue ? 0 : (nullable2.Value < nullable1.Value ? 1 : 0)) != 0)
          nullable1 = nullable2;
        flag = false;
      }
      return flag ? new Decimal?() : nullable1;
    }

    public static TResult Min<TSource, TResult>(
      this IEnumerable<TSource> source,
      Func<TSource, TResult> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      return source.Select<TSource, TResult>(selector).Min<TResult>();
    }

    public static IEnumerable<TResult> OfType<TResult>(this IEnumerable source)
    {
      Check.Source((object) source);
      return Enumerable.CreateOfTypeIterator<TResult>(source);
    }

    [DebuggerHidden]
    private static IEnumerable<TResult> CreateOfTypeIterator<TResult>(IEnumerable source)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Enumerable.\u003CCreateOfTypeIterator\u003Ec__Iterator164<TResult> ofTypeIterator = new Enumerable.\u003CCreateOfTypeIterator\u003Ec__Iterator164<TResult>()
      {
        source = source,
        \u003C\u0024\u003Esource = source
      };
      // ISSUE: reference to a compiler-generated field
      ofTypeIterator.\u0024PC = -2;
      return (IEnumerable<TResult>) ofTypeIterator;
    }

    public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector)
    {
      return source.OrderBy<TSource, TKey>(keySelector, (IComparer<TKey>) null);
    }

    public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      IComparer<TKey> comparer)
    {
      Check.SourceAndKeySelector((object) source, (object) keySelector);
      return (IOrderedEnumerable<TSource>) new OrderedSequence<TSource, TKey>(source, keySelector, comparer, SortDirection.Ascending);
    }

    public static IOrderedEnumerable<TSource> OrderByDescending<TSource, TKey>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector)
    {
      return source.OrderByDescending<TSource, TKey>(keySelector, (IComparer<TKey>) null);
    }

    public static IOrderedEnumerable<TSource> OrderByDescending<TSource, TKey>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      IComparer<TKey> comparer)
    {
      Check.SourceAndKeySelector((object) source, (object) keySelector);
      return (IOrderedEnumerable<TSource>) new OrderedSequence<TSource, TKey>(source, keySelector, comparer, SortDirection.Descending);
    }

    public static IEnumerable<int> Range(int start, int count)
    {
      if (count < 0)
        throw new ArgumentOutOfRangeException(nameof (count));
      return (long) start + (long) count - 1L <= (long) int.MaxValue ? Enumerable.CreateRangeIterator(start, count) : throw new ArgumentOutOfRangeException();
    }

    [DebuggerHidden]
    private static IEnumerable<int> CreateRangeIterator(int start, int count)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Enumerable.\u003CCreateRangeIterator\u003Ec__Iterator165 rangeIterator = new Enumerable.\u003CCreateRangeIterator\u003Ec__Iterator165()
      {
        count = count,
        start = start,
        \u003C\u0024\u003Ecount = count,
        \u003C\u0024\u003Estart = start
      };
      // ISSUE: reference to a compiler-generated field
      rangeIterator.\u0024PC = -2;
      return (IEnumerable<int>) rangeIterator;
    }

    public static IEnumerable<TResult> Repeat<TResult>(TResult element, int count)
    {
      return count >= 0 ? Enumerable.CreateRepeatIterator<TResult>(element, count) : throw new ArgumentOutOfRangeException();
    }

    [DebuggerHidden]
    private static IEnumerable<TResult> CreateRepeatIterator<TResult>(TResult element, int count)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Enumerable.\u003CCreateRepeatIterator\u003Ec__Iterator166<TResult> repeatIterator = new Enumerable.\u003CCreateRepeatIterator\u003Ec__Iterator166<TResult>()
      {
        count = count,
        element = element,
        \u003C\u0024\u003Ecount = count,
        \u003C\u0024\u003Eelement = element
      };
      // ISSUE: reference to a compiler-generated field
      repeatIterator.\u0024PC = -2;
      return (IEnumerable<TResult>) repeatIterator;
    }

    public static IEnumerable<TSource> Reverse<TSource>(this IEnumerable<TSource> source)
    {
      Check.Source((object) source);
      return Enumerable.CreateReverseIterator<TSource>(source);
    }

    [DebuggerHidden]
    private static IEnumerable<TSource> CreateReverseIterator<TSource>(IEnumerable<TSource> source)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Enumerable.\u003CCreateReverseIterator\u003Ec__Iterator167<TSource> reverseIterator = new Enumerable.\u003CCreateReverseIterator\u003Ec__Iterator167<TSource>()
      {
        source = source,
        \u003C\u0024\u003Esource = source
      };
      // ISSUE: reference to a compiler-generated field
      reverseIterator.\u0024PC = -2;
      return (IEnumerable<TSource>) reverseIterator;
    }

    public static IEnumerable<TResult> Select<TSource, TResult>(
      this IEnumerable<TSource> source,
      Func<TSource, TResult> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      return Enumerable.CreateSelectIterator<TSource, TResult>(source, selector);
    }

    [DebuggerHidden]
    private static IEnumerable<TResult> CreateSelectIterator<TSource, TResult>(
      IEnumerable<TSource> source,
      Func<TSource, TResult> selector)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Enumerable.\u003CCreateSelectIterator\u003Ec__Iterator168<TSource, TResult> selectIterator = new Enumerable.\u003CCreateSelectIterator\u003Ec__Iterator168<TSource, TResult>()
      {
        source = source,
        selector = selector,
        \u003C\u0024\u003Esource = source,
        \u003C\u0024\u003Eselector = selector
      };
      // ISSUE: reference to a compiler-generated field
      selectIterator.\u0024PC = -2;
      return (IEnumerable<TResult>) selectIterator;
    }

    public static IEnumerable<TResult> Select<TSource, TResult>(
      this IEnumerable<TSource> source,
      Func<TSource, int, TResult> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      return Enumerable.CreateSelectIterator<TSource, TResult>(source, selector);
    }

    [DebuggerHidden]
    private static IEnumerable<TResult> CreateSelectIterator<TSource, TResult>(
      IEnumerable<TSource> source,
      Func<TSource, int, TResult> selector)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Enumerable.\u003CCreateSelectIterator\u003Ec__Iterator169<TSource, TResult> selectIterator = new Enumerable.\u003CCreateSelectIterator\u003Ec__Iterator169<TSource, TResult>()
      {
        source = source,
        selector = selector,
        \u003C\u0024\u003Esource = source,
        \u003C\u0024\u003Eselector = selector
      };
      // ISSUE: reference to a compiler-generated field
      selectIterator.\u0024PC = -2;
      return (IEnumerable<TResult>) selectIterator;
    }

    public static IEnumerable<TResult> SelectMany<TSource, TResult>(
      this IEnumerable<TSource> source,
      Func<TSource, IEnumerable<TResult>> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      return Enumerable.CreateSelectManyIterator<TSource, TResult>(source, selector);
    }

    [DebuggerHidden]
    private static IEnumerable<TResult> CreateSelectManyIterator<TSource, TResult>(
      IEnumerable<TSource> source,
      Func<TSource, IEnumerable<TResult>> selector)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Enumerable.\u003CCreateSelectManyIterator\u003Ec__Iterator16A<TSource, TResult> selectManyIterator = new Enumerable.\u003CCreateSelectManyIterator\u003Ec__Iterator16A<TSource, TResult>()
      {
        source = source,
        selector = selector,
        \u003C\u0024\u003Esource = source,
        \u003C\u0024\u003Eselector = selector
      };
      // ISSUE: reference to a compiler-generated field
      selectManyIterator.\u0024PC = -2;
      return (IEnumerable<TResult>) selectManyIterator;
    }

    public static IEnumerable<TResult> SelectMany<TSource, TResult>(
      this IEnumerable<TSource> source,
      Func<TSource, int, IEnumerable<TResult>> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      return Enumerable.CreateSelectManyIterator<TSource, TResult>(source, selector);
    }

    [DebuggerHidden]
    private static IEnumerable<TResult> CreateSelectManyIterator<TSource, TResult>(
      IEnumerable<TSource> source,
      Func<TSource, int, IEnumerable<TResult>> selector)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Enumerable.\u003CCreateSelectManyIterator\u003Ec__Iterator16B<TSource, TResult> selectManyIterator = new Enumerable.\u003CCreateSelectManyIterator\u003Ec__Iterator16B<TSource, TResult>()
      {
        source = source,
        selector = selector,
        \u003C\u0024\u003Esource = source,
        \u003C\u0024\u003Eselector = selector
      };
      // ISSUE: reference to a compiler-generated field
      selectManyIterator.\u0024PC = -2;
      return (IEnumerable<TResult>) selectManyIterator;
    }

    public static IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(
      this IEnumerable<TSource> source,
      Func<TSource, IEnumerable<TCollection>> collectionSelector,
      Func<TSource, TCollection, TResult> resultSelector)
    {
      Check.SourceAndCollectionSelectors((object) source, (object) collectionSelector, (object) resultSelector);
      return Enumerable.CreateSelectManyIterator<TSource, TCollection, TResult>(source, collectionSelector, resultSelector);
    }

    [DebuggerHidden]
    private static IEnumerable<TResult> CreateSelectManyIterator<TSource, TCollection, TResult>(
      IEnumerable<TSource> source,
      Func<TSource, IEnumerable<TCollection>> collectionSelector,
      Func<TSource, TCollection, TResult> selector)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Enumerable.\u003CCreateSelectManyIterator\u003Ec__Iterator16C<TSource, TCollection, TResult> selectManyIterator = new Enumerable.\u003CCreateSelectManyIterator\u003Ec__Iterator16C<TSource, TCollection, TResult>()
      {
        source = source,
        collectionSelector = collectionSelector,
        selector = selector,
        \u003C\u0024\u003Esource = source,
        \u003C\u0024\u003EcollectionSelector = collectionSelector,
        \u003C\u0024\u003Eselector = selector
      };
      // ISSUE: reference to a compiler-generated field
      selectManyIterator.\u0024PC = -2;
      return (IEnumerable<TResult>) selectManyIterator;
    }

    public static IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(
      this IEnumerable<TSource> source,
      Func<TSource, int, IEnumerable<TCollection>> collectionSelector,
      Func<TSource, TCollection, TResult> resultSelector)
    {
      Check.SourceAndCollectionSelectors((object) source, (object) collectionSelector, (object) resultSelector);
      return Enumerable.CreateSelectManyIterator<TSource, TCollection, TResult>(source, collectionSelector, resultSelector);
    }

    [DebuggerHidden]
    private static IEnumerable<TResult> CreateSelectManyIterator<TSource, TCollection, TResult>(
      IEnumerable<TSource> source,
      Func<TSource, int, IEnumerable<TCollection>> collectionSelector,
      Func<TSource, TCollection, TResult> selector)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Enumerable.\u003CCreateSelectManyIterator\u003Ec__Iterator16D<TSource, TCollection, TResult> selectManyIterator = new Enumerable.\u003CCreateSelectManyIterator\u003Ec__Iterator16D<TSource, TCollection, TResult>()
      {
        source = source,
        collectionSelector = collectionSelector,
        selector = selector,
        \u003C\u0024\u003Esource = source,
        \u003C\u0024\u003EcollectionSelector = collectionSelector,
        \u003C\u0024\u003Eselector = selector
      };
      // ISSUE: reference to a compiler-generated field
      selectManyIterator.\u0024PC = -2;
      return (IEnumerable<TResult>) selectManyIterator;
    }

    private static TSource Single<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, bool> predicate,
      Enumerable.Fallback fallback)
    {
      bool flag = false;
      TSource source1 = default (TSource);
      foreach (TSource source2 in source)
      {
        if (predicate(source2))
        {
          flag = !flag ? true : throw Enumerable.MoreThanOneMatchingElement();
          source1 = source2;
        }
      }
      if (!flag && fallback == Enumerable.Fallback.Throw)
        throw Enumerable.NoMatchingElement();
      return source1;
    }

    public static TSource Single<TSource>(this IEnumerable<TSource> source)
    {
      Check.Source((object) source);
      bool flag = false;
      TSource source1 = default (TSource);
      foreach (TSource source2 in source)
      {
        flag = !flag ? true : throw Enumerable.MoreThanOneElement();
        source1 = source2;
      }
      if (!flag)
        throw Enumerable.NoMatchingElement();
      return source1;
    }

    public static TSource Single<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, bool> predicate)
    {
      Check.SourceAndPredicate((object) source, (object) predicate);
      return source.Single<TSource>(predicate, Enumerable.Fallback.Throw);
    }

    public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source)
    {
      Check.Source((object) source);
      bool flag = false;
      TSource source1 = default (TSource);
      foreach (TSource source2 in source)
      {
        flag = !flag ? true : throw Enumerable.MoreThanOneMatchingElement();
        source1 = source2;
      }
      return source1;
    }

    public static TSource SingleOrDefault<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, bool> predicate)
    {
      Check.SourceAndPredicate((object) source, (object) predicate);
      return source.Single<TSource>(predicate, Enumerable.Fallback.Default);
    }

    public static IEnumerable<TSource> Skip<TSource>(this IEnumerable<TSource> source, int count)
    {
      Check.Source((object) source);
      return Enumerable.CreateSkipIterator<TSource>(source, count);
    }

    [DebuggerHidden]
    private static IEnumerable<TSource> CreateSkipIterator<TSource>(
      IEnumerable<TSource> source,
      int count)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Enumerable.\u003CCreateSkipIterator\u003Ec__Iterator16E<TSource> skipIterator = new Enumerable.\u003CCreateSkipIterator\u003Ec__Iterator16E<TSource>()
      {
        source = source,
        count = count,
        \u003C\u0024\u003Esource = source,
        \u003C\u0024\u003Ecount = count
      };
      // ISSUE: reference to a compiler-generated field
      skipIterator.\u0024PC = -2;
      return (IEnumerable<TSource>) skipIterator;
    }

    public static IEnumerable<TSource> SkipWhile<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, bool> predicate)
    {
      Check.SourceAndPredicate((object) source, (object) predicate);
      return Enumerable.CreateSkipWhileIterator<TSource>(source, predicate);
    }

    [DebuggerHidden]
    private static IEnumerable<TSource> CreateSkipWhileIterator<TSource>(
      IEnumerable<TSource> source,
      Func<TSource, bool> predicate)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Enumerable.\u003CCreateSkipWhileIterator\u003Ec__Iterator16F<TSource> skipWhileIterator = new Enumerable.\u003CCreateSkipWhileIterator\u003Ec__Iterator16F<TSource>()
      {
        source = source,
        predicate = predicate,
        \u003C\u0024\u003Esource = source,
        \u003C\u0024\u003Epredicate = predicate
      };
      // ISSUE: reference to a compiler-generated field
      skipWhileIterator.\u0024PC = -2;
      return (IEnumerable<TSource>) skipWhileIterator;
    }

    public static IEnumerable<TSource> SkipWhile<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, int, bool> predicate)
    {
      Check.SourceAndPredicate((object) source, (object) predicate);
      return Enumerable.CreateSkipWhileIterator<TSource>(source, predicate);
    }

    [DebuggerHidden]
    private static IEnumerable<TSource> CreateSkipWhileIterator<TSource>(
      IEnumerable<TSource> source,
      Func<TSource, int, bool> predicate)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Enumerable.\u003CCreateSkipWhileIterator\u003Ec__Iterator170<TSource> skipWhileIterator = new Enumerable.\u003CCreateSkipWhileIterator\u003Ec__Iterator170<TSource>()
      {
        source = source,
        predicate = predicate,
        \u003C\u0024\u003Esource = source,
        \u003C\u0024\u003Epredicate = predicate
      };
      // ISSUE: reference to a compiler-generated field
      skipWhileIterator.\u0024PC = -2;
      return (IEnumerable<TSource>) skipWhileIterator;
    }

    public static int Sum(this IEnumerable<int> source)
    {
      Check.Source((object) source);
      int num1 = 0;
      foreach (int num2 in source)
        checked { num1 += num2; }
      return num1;
    }

    public static int? Sum(this IEnumerable<int?> source)
    {
      Check.Source((object) source);
      int num = 0;
      foreach (int? nullable in source)
      {
        if (nullable.HasValue)
          checked { num += nullable.Value; }
      }
      return new int?(num);
    }

    public static int Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      int num = 0;
      foreach (TSource source1 in source)
        checked { num += selector(source1); }
      return num;
    }

    public static int? Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      int num = 0;
      foreach (TSource source1 in source)
      {
        int? nullable = selector(source1);
        if (nullable.HasValue)
          checked { num += nullable.Value; }
      }
      return new int?(num);
    }

    public static long Sum(this IEnumerable<long> source)
    {
      Check.Source((object) source);
      long num1 = 0;
      foreach (long num2 in source)
        checked { num1 += num2; }
      return num1;
    }

    public static long? Sum(this IEnumerable<long?> source)
    {
      Check.Source((object) source);
      long num = 0;
      foreach (long? nullable in source)
      {
        if (nullable.HasValue)
          checked { num += nullable.Value; }
      }
      return new long?(num);
    }

    public static long Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      long num = 0;
      foreach (TSource source1 in source)
        checked { num += selector(source1); }
      return num;
    }

    public static long? Sum<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, long?> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      long num = 0;
      foreach (TSource source1 in source)
      {
        long? nullable = selector(source1);
        if (nullable.HasValue)
          checked { num += nullable.Value; }
      }
      return new long?(num);
    }

    public static double Sum(this IEnumerable<double> source)
    {
      Check.Source((object) source);
      double num1 = 0.0;
      foreach (double num2 in source)
        num1 += num2;
      return num1;
    }

    public static double? Sum(this IEnumerable<double?> source)
    {
      Check.Source((object) source);
      double num = 0.0;
      foreach (double? nullable in source)
      {
        if (nullable.HasValue)
          num += nullable.Value;
      }
      return new double?(num);
    }

    public static double Sum<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, double> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      double num = 0.0;
      foreach (TSource source1 in source)
        num += selector(source1);
      return num;
    }

    public static double? Sum<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, double?> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      double num = 0.0;
      foreach (TSource source1 in source)
      {
        double? nullable = selector(source1);
        if (nullable.HasValue)
          num += nullable.Value;
      }
      return new double?(num);
    }

    public static float Sum(this IEnumerable<float> source)
    {
      Check.Source((object) source);
      float num1 = 0.0f;
      foreach (float num2 in source)
        num1 += num2;
      return num1;
    }

    public static float? Sum(this IEnumerable<float?> source)
    {
      Check.Source((object) source);
      float num = 0.0f;
      foreach (float? nullable in source)
      {
        if (nullable.HasValue)
          num += nullable.Value;
      }
      return new float?(num);
    }

    public static float Sum<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, float> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      float num = 0.0f;
      foreach (TSource source1 in source)
        num += selector(source1);
      return num;
    }

    public static float? Sum<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, float?> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      float num = 0.0f;
      foreach (TSource source1 in source)
      {
        float? nullable = selector(source1);
        if (nullable.HasValue)
          num += nullable.Value;
      }
      return new float?(num);
    }

    public static Decimal Sum(this IEnumerable<Decimal> source)
    {
      Check.Source((object) source);
      Decimal num1 = 0M;
      foreach (Decimal num2 in source)
        num1 += num2;
      return num1;
    }

    public static Decimal? Sum(this IEnumerable<Decimal?> source)
    {
      Check.Source((object) source);
      Decimal num = 0M;
      foreach (Decimal? nullable in source)
      {
        if (nullable.HasValue)
          num += nullable.Value;
      }
      return new Decimal?(num);
    }

    public static Decimal Sum<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, Decimal> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      Decimal num = 0M;
      foreach (TSource source1 in source)
        num += selector(source1);
      return num;
    }

    public static Decimal? Sum<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, Decimal?> selector)
    {
      Check.SourceAndSelector((object) source, (object) selector);
      Decimal num = 0M;
      foreach (TSource source1 in source)
      {
        Decimal? nullable = selector(source1);
        if (nullable.HasValue)
          num += nullable.Value;
      }
      return new Decimal?(num);
    }

    public static IEnumerable<TSource> Take<TSource>(this IEnumerable<TSource> source, int count)
    {
      Check.Source((object) source);
      return Enumerable.CreateTakeIterator<TSource>(source, count);
    }

    [DebuggerHidden]
    private static IEnumerable<TSource> CreateTakeIterator<TSource>(
      IEnumerable<TSource> source,
      int count)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Enumerable.\u003CCreateTakeIterator\u003Ec__Iterator171<TSource> takeIterator = new Enumerable.\u003CCreateTakeIterator\u003Ec__Iterator171<TSource>()
      {
        count = count,
        source = source,
        \u003C\u0024\u003Ecount = count,
        \u003C\u0024\u003Esource = source
      };
      // ISSUE: reference to a compiler-generated field
      takeIterator.\u0024PC = -2;
      return (IEnumerable<TSource>) takeIterator;
    }

    public static IEnumerable<TSource> TakeWhile<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, bool> predicate)
    {
      Check.SourceAndPredicate((object) source, (object) predicate);
      return Enumerable.CreateTakeWhileIterator<TSource>(source, predicate);
    }

    [DebuggerHidden]
    private static IEnumerable<TSource> CreateTakeWhileIterator<TSource>(
      IEnumerable<TSource> source,
      Func<TSource, bool> predicate)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Enumerable.\u003CCreateTakeWhileIterator\u003Ec__Iterator172<TSource> takeWhileIterator = new Enumerable.\u003CCreateTakeWhileIterator\u003Ec__Iterator172<TSource>()
      {
        source = source,
        predicate = predicate,
        \u003C\u0024\u003Esource = source,
        \u003C\u0024\u003Epredicate = predicate
      };
      // ISSUE: reference to a compiler-generated field
      takeWhileIterator.\u0024PC = -2;
      return (IEnumerable<TSource>) takeWhileIterator;
    }

    public static IEnumerable<TSource> TakeWhile<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, int, bool> predicate)
    {
      Check.SourceAndPredicate((object) source, (object) predicate);
      return Enumerable.CreateTakeWhileIterator<TSource>(source, predicate);
    }

    [DebuggerHidden]
    private static IEnumerable<TSource> CreateTakeWhileIterator<TSource>(
      IEnumerable<TSource> source,
      Func<TSource, int, bool> predicate)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Enumerable.\u003CCreateTakeWhileIterator\u003Ec__Iterator173<TSource> takeWhileIterator = new Enumerable.\u003CCreateTakeWhileIterator\u003Ec__Iterator173<TSource>()
      {
        source = source,
        predicate = predicate,
        \u003C\u0024\u003Esource = source,
        \u003C\u0024\u003Epredicate = predicate
      };
      // ISSUE: reference to a compiler-generated field
      takeWhileIterator.\u0024PC = -2;
      return (IEnumerable<TSource>) takeWhileIterator;
    }

    public static IOrderedEnumerable<TSource> ThenBy<TSource, TKey>(
      this IOrderedEnumerable<TSource> source,
      Func<TSource, TKey> keySelector)
    {
      return source.ThenBy<TSource, TKey>(keySelector, (IComparer<TKey>) null);
    }

    public static IOrderedEnumerable<TSource> ThenBy<TSource, TKey>(
      this IOrderedEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      IComparer<TKey> comparer)
    {
      Check.SourceAndKeySelector((object) source, (object) keySelector);
      return (source as OrderedEnumerable<TSource>).CreateOrderedEnumerable<TKey>(keySelector, comparer, false);
    }

    public static IOrderedEnumerable<TSource> ThenByDescending<TSource, TKey>(
      this IOrderedEnumerable<TSource> source,
      Func<TSource, TKey> keySelector)
    {
      return source.ThenByDescending<TSource, TKey>(keySelector, (IComparer<TKey>) null);
    }

    public static IOrderedEnumerable<TSource> ThenByDescending<TSource, TKey>(
      this IOrderedEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      IComparer<TKey> comparer)
    {
      Check.SourceAndKeySelector((object) source, (object) keySelector);
      return (source as OrderedEnumerable<TSource>).CreateOrderedEnumerable<TKey>(keySelector, comparer, true);
    }

    public static TSource[] ToArray<TSource>(this IEnumerable<TSource> source)
    {
      Check.Source((object) source);
      if (source is ICollection<TSource> sources)
      {
        if (sources.Count == 0)
          return new TSource[0];
        TSource[] array = new TSource[sources.Count];
        sources.CopyTo(array, 0);
        return array;
      }
      int newSize = 0;
      TSource[] array1 = new TSource[0];
      foreach (TSource source1 in source)
      {
        if (newSize == array1.Length)
        {
          if (newSize == 0)
            array1 = new TSource[4];
          else
            Array.Resize<TSource>(ref array1, newSize * 2);
        }
        array1[newSize++] = source1;
      }
      if (newSize != array1.Length)
        Array.Resize<TSource>(ref array1, newSize);
      return array1;
    }

    public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      Func<TSource, TElement> elementSelector)
    {
      return source.ToDictionary<TSource, TKey, TElement>(keySelector, elementSelector, (IEqualityComparer<TKey>) null);
    }

    public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      Func<TSource, TElement> elementSelector,
      IEqualityComparer<TKey> comparer)
    {
      Check.SourceAndKeyElementSelectors((object) source, (object) keySelector, (object) elementSelector);
      if (comparer == null)
        comparer = (IEqualityComparer<TKey>) EqualityComparer<TKey>.Default;
      Dictionary<TKey, TElement> dictionary = new Dictionary<TKey, TElement>(comparer);
      foreach (TSource source1 in source)
        dictionary.Add(keySelector(source1), elementSelector(source1));
      return dictionary;
    }

    public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector)
    {
      return source.ToDictionary<TSource, TKey>(keySelector, (IEqualityComparer<TKey>) null);
    }

    public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      IEqualityComparer<TKey> comparer)
    {
      Check.SourceAndKeySelector((object) source, (object) keySelector);
      if (comparer == null)
        comparer = (IEqualityComparer<TKey>) EqualityComparer<TKey>.Default;
      Dictionary<TKey, TSource> dictionary = new Dictionary<TKey, TSource>(comparer);
      foreach (TSource source1 in source)
        dictionary.Add(keySelector(source1), source1);
      return dictionary;
    }

    public static List<TSource> ToList<TSource>(this IEnumerable<TSource> source)
    {
      Check.Source((object) source);
      return new List<TSource>(source);
    }

    public static ILookup<TKey, TSource> ToLookup<TSource, TKey>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector)
    {
      return source.ToLookup<TSource, TKey>(keySelector, (IEqualityComparer<TKey>) null);
    }

    public static ILookup<TKey, TSource> ToLookup<TSource, TKey>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      IEqualityComparer<TKey> comparer)
    {
      Check.SourceAndKeySelector((object) source, (object) keySelector);
      List<TSource> nullKeyElements = (List<TSource>) null;
      Dictionary<TKey, List<TSource>> lookup = new Dictionary<TKey, List<TSource>>(comparer ?? (IEqualityComparer<TKey>) EqualityComparer<TKey>.Default);
      foreach (TSource source1 in source)
      {
        TKey key = keySelector(source1);
        List<TSource> sourceList;
        if ((object) key == null)
        {
          if (nullKeyElements == null)
            nullKeyElements = new List<TSource>();
          sourceList = nullKeyElements;
        }
        else if (!lookup.TryGetValue(key, out sourceList))
        {
          sourceList = new List<TSource>();
          lookup.Add(key, sourceList);
        }
        sourceList.Add(source1);
      }
      return (ILookup<TKey, TSource>) new Lookup<TKey, TSource>(lookup, (IEnumerable<TSource>) nullKeyElements);
    }

    public static ILookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      Func<TSource, TElement> elementSelector)
    {
      return source.ToLookup<TSource, TKey, TElement>(keySelector, elementSelector, (IEqualityComparer<TKey>) null);
    }

    public static ILookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      Func<TSource, TElement> elementSelector,
      IEqualityComparer<TKey> comparer)
    {
      Check.SourceAndKeyElementSelectors((object) source, (object) keySelector, (object) elementSelector);
      List<TElement> nullKeyElements = (List<TElement>) null;
      Dictionary<TKey, List<TElement>> lookup = new Dictionary<TKey, List<TElement>>(comparer ?? (IEqualityComparer<TKey>) EqualityComparer<TKey>.Default);
      foreach (TSource source1 in source)
      {
        TKey key = keySelector(source1);
        List<TElement> elementList;
        if ((object) key == null)
        {
          if (nullKeyElements == null)
            nullKeyElements = new List<TElement>();
          elementList = nullKeyElements;
        }
        else if (!lookup.TryGetValue(key, out elementList))
        {
          elementList = new List<TElement>();
          lookup.Add(key, elementList);
        }
        elementList.Add(elementSelector(source1));
      }
      return (ILookup<TKey, TElement>) new Lookup<TKey, TElement>(lookup, (IEnumerable<TElement>) nullKeyElements);
    }

    public static bool SequenceEqual<TSource>(
      this IEnumerable<TSource> first,
      IEnumerable<TSource> second)
    {
      return first.SequenceEqual<TSource>(second, (IEqualityComparer<TSource>) null);
    }

    public static bool SequenceEqual<TSource>(
      this IEnumerable<TSource> first,
      IEnumerable<TSource> second,
      IEqualityComparer<TSource> comparer)
    {
      Check.FirstAndSecond((object) first, (object) second);
      if (comparer == null)
        comparer = (IEqualityComparer<TSource>) EqualityComparer<TSource>.Default;
      using (IEnumerator<TSource> enumerator1 = first.GetEnumerator())
      {
        using (IEnumerator<TSource> enumerator2 = second.GetEnumerator())
        {
          while (enumerator1.MoveNext())
          {
            if (!enumerator2.MoveNext() || !comparer.Equals(enumerator1.Current, enumerator2.Current))
              return false;
          }
          return !enumerator2.MoveNext();
        }
      }
    }

    public static IEnumerable<TSource> Union<TSource>(
      this IEnumerable<TSource> first,
      IEnumerable<TSource> second)
    {
      Check.FirstAndSecond((object) first, (object) second);
      return first.Union<TSource>(second, (IEqualityComparer<TSource>) null);
    }

    public static IEnumerable<TSource> Union<TSource>(
      this IEnumerable<TSource> first,
      IEnumerable<TSource> second,
      IEqualityComparer<TSource> comparer)
    {
      Check.FirstAndSecond((object) first, (object) second);
      if (comparer == null)
        comparer = (IEqualityComparer<TSource>) EqualityComparer<TSource>.Default;
      return Enumerable.CreateUnionIterator<TSource>(first, second, comparer);
    }

    [DebuggerHidden]
    private static IEnumerable<TSource> CreateUnionIterator<TSource>(
      IEnumerable<TSource> first,
      IEnumerable<TSource> second,
      IEqualityComparer<TSource> comparer)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Enumerable.\u003CCreateUnionIterator\u003Ec__Iterator174<TSource> unionIterator = new Enumerable.\u003CCreateUnionIterator\u003Ec__Iterator174<TSource>()
      {
        comparer = comparer,
        first = first,
        second = second,
        \u003C\u0024\u003Ecomparer = comparer,
        \u003C\u0024\u003Efirst = first,
        \u003C\u0024\u003Esecond = second
      };
      // ISSUE: reference to a compiler-generated field
      unionIterator.\u0024PC = -2;
      return (IEnumerable<TSource>) unionIterator;
    }

    public static IEnumerable<TSource> Where<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, bool> predicate)
    {
      Check.SourceAndPredicate((object) source, (object) predicate);
      return source is TSource[] source1 ? Enumerable.CreateWhereIterator<TSource>(source1, predicate) : Enumerable.CreateWhereIterator<TSource>(source, predicate);
    }

    [DebuggerHidden]
    private static IEnumerable<TSource> CreateWhereIterator<TSource>(
      IEnumerable<TSource> source,
      Func<TSource, bool> predicate)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Enumerable.\u003CCreateWhereIterator\u003Ec__Iterator175<TSource> whereIterator = new Enumerable.\u003CCreateWhereIterator\u003Ec__Iterator175<TSource>()
      {
        source = source,
        predicate = predicate,
        \u003C\u0024\u003Esource = source,
        \u003C\u0024\u003Epredicate = predicate
      };
      // ISSUE: reference to a compiler-generated field
      whereIterator.\u0024PC = -2;
      return (IEnumerable<TSource>) whereIterator;
    }

    [DebuggerHidden]
    private static IEnumerable<TSource> CreateWhereIterator<TSource>(
      TSource[] source,
      Func<TSource, bool> predicate)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Enumerable.\u003CCreateWhereIterator\u003Ec__Iterator176<TSource> whereIterator = new Enumerable.\u003CCreateWhereIterator\u003Ec__Iterator176<TSource>()
      {
        source = source,
        predicate = predicate,
        \u003C\u0024\u003Esource = source,
        \u003C\u0024\u003Epredicate = predicate
      };
      // ISSUE: reference to a compiler-generated field
      whereIterator.\u0024PC = -2;
      return (IEnumerable<TSource>) whereIterator;
    }

    public static IEnumerable<TSource> Where<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, int, bool> predicate)
    {
      Check.SourceAndPredicate((object) source, (object) predicate);
      return source is TSource[] source1 ? Enumerable.CreateWhereIterator<TSource>(source1, predicate) : Enumerable.CreateWhereIterator<TSource>(source, predicate);
    }

    [DebuggerHidden]
    private static IEnumerable<TSource> CreateWhereIterator<TSource>(
      IEnumerable<TSource> source,
      Func<TSource, int, bool> predicate)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Enumerable.\u003CCreateWhereIterator\u003Ec__Iterator177<TSource> whereIterator = new Enumerable.\u003CCreateWhereIterator\u003Ec__Iterator177<TSource>()
      {
        source = source,
        predicate = predicate,
        \u003C\u0024\u003Esource = source,
        \u003C\u0024\u003Epredicate = predicate
      };
      // ISSUE: reference to a compiler-generated field
      whereIterator.\u0024PC = -2;
      return (IEnumerable<TSource>) whereIterator;
    }

    [DebuggerHidden]
    private static IEnumerable<TSource> CreateWhereIterator<TSource>(
      TSource[] source,
      Func<TSource, int, bool> predicate)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Enumerable.\u003CCreateWhereIterator\u003Ec__Iterator178<TSource> whereIterator = new Enumerable.\u003CCreateWhereIterator\u003Ec__Iterator178<TSource>()
      {
        source = source,
        predicate = predicate,
        \u003C\u0024\u003Esource = source,
        \u003C\u0024\u003Epredicate = predicate
      };
      // ISSUE: reference to a compiler-generated field
      whereIterator.\u0024PC = -2;
      return (IEnumerable<TSource>) whereIterator;
    }

    private static Exception EmptySequence()
    {
      return (Exception) new InvalidOperationException("Sequence contains no elements");
    }

    private static Exception NoMatchingElement()
    {
      return (Exception) new InvalidOperationException("Sequence contains no matching element");
    }

    private static Exception MoreThanOneElement()
    {
      return (Exception) new InvalidOperationException("Sequence contains more than one element");
    }

    private static Exception MoreThanOneMatchingElement()
    {
      return (Exception) new InvalidOperationException("Sequence contains more than one matching element");
    }

    private enum Fallback
    {
      Default,
      Throw,
    }
  }
}
