// Decompiled with JetBrains decompiler
// Type: GameCore.Future
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Diagnostics;

#nullable disable
namespace GameCore
{
  public class Future
  {
    [DebuggerHidden]
    private static IEnumerator SingleFunc<T>(T value, Promise<T> promise)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new Future.\u003CSingleFunc\u003Ec__Iterator28<T>()
      {
        value = value,
        promise = promise,
        \u003C\u0024\u003Evalue = value,
        \u003C\u0024\u003Epromise = promise
      };
    }

    public static Future<T> Single<T>(T value)
    {
      return new Future<T>((Func<Promise<T>, IEnumerator>) (promise => Future.SingleFunc<T>(value, promise)));
    }

    [DebuggerHidden]
    private static IEnumerator WhenAllFunc<T1>(Future<T1> arg1, Promise<Tuple<T1>> result)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new Future.\u003CWhenAllFunc\u003Ec__Iterator29<T1>()
      {
        arg1 = arg1,
        result = result,
        \u003C\u0024\u003Earg1 = arg1,
        \u003C\u0024\u003Eresult = result
      };
    }

    public static Future<Tuple<T1>> WhenAll<T1>(Future<T1> arg1)
    {
      return new Future<Tuple<T1>>((Func<Promise<Tuple<T1>>, IEnumerator>) (promise => Future.WhenAllFunc<T1>(arg1, promise)));
    }

    public static Future<TResult> WhenAllThen<T1, TResult>(Future<T1> arg1, Func<T1, TResult> f)
    {
      return Future.WhenAll<T1>(arg1).Then<TResult>((Func<Tuple<T1>, TResult>) (t => f(t.Item1)));
    }

    [DebuggerHidden]
    private static IEnumerator WhenAllFunc<T1, T2>(
      Future<T1> arg1,
      Future<T2> arg2,
      Promise<Tuple<T1, T2>> result)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new Future.\u003CWhenAllFunc\u003Ec__Iterator2A<T1, T2>()
      {
        arg1 = arg1,
        arg2 = arg2,
        result = result,
        \u003C\u0024\u003Earg1 = arg1,
        \u003C\u0024\u003Earg2 = arg2,
        \u003C\u0024\u003Eresult = result
      };
    }

    public static Future<Tuple<T1, T2>> WhenAll<T1, T2>(Future<T1> arg1, Future<T2> arg2)
    {
      return new Future<Tuple<T1, T2>>((Func<Promise<Tuple<T1, T2>>, IEnumerator>) (promise => Future.WhenAllFunc<T1, T2>(arg1, arg2, promise)));
    }

    public static Future<TResult> WhenAllThen<T1, T2, TResult>(
      Future<T1> arg1,
      Future<T2> arg2,
      Func<T1, T2, TResult> f)
    {
      return Future.WhenAll<T1, T2>(arg1, arg2).Then<TResult>((Func<Tuple<T1, T2>, TResult>) (t => f(t.Item1, t.Item2)));
    }

    [DebuggerHidden]
    private static IEnumerator WhenAllFunc<T1, T2, T3>(
      Future<T1> arg1,
      Future<T2> arg2,
      Future<T3> arg3,
      Promise<Tuple<T1, T2, T3>> result)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new Future.\u003CWhenAllFunc\u003Ec__Iterator2B<T1, T2, T3>()
      {
        arg1 = arg1,
        arg2 = arg2,
        arg3 = arg3,
        result = result,
        \u003C\u0024\u003Earg1 = arg1,
        \u003C\u0024\u003Earg2 = arg2,
        \u003C\u0024\u003Earg3 = arg3,
        \u003C\u0024\u003Eresult = result
      };
    }

    public static Future<Tuple<T1, T2, T3>> WhenAll<T1, T2, T3>(
      Future<T1> arg1,
      Future<T2> arg2,
      Future<T3> arg3)
    {
      return new Future<Tuple<T1, T2, T3>>((Func<Promise<Tuple<T1, T2, T3>>, IEnumerator>) (promise => Future.WhenAllFunc<T1, T2, T3>(arg1, arg2, arg3, promise)));
    }

    public static Future<TResult> WhenAllThen<T1, T2, T3, TResult>(
      Future<T1> arg1,
      Future<T2> arg2,
      Future<T3> arg3,
      Func<T1, T2, T3, TResult> f)
    {
      return Future.WhenAll<T1, T2, T3>(arg1, arg2, arg3).Then<TResult>((Func<Tuple<T1, T2, T3>, TResult>) (t => f(t.Item1, t.Item2, t.Item3)));
    }

    [DebuggerHidden]
    private static IEnumerator WhenAllFunc<T1, T2, T3, T4>(
      Future<T1> arg1,
      Future<T2> arg2,
      Future<T3> arg3,
      Future<T4> arg4,
      Promise<Tuple<T1, T2, T3, T4>> result)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new Future.\u003CWhenAllFunc\u003Ec__Iterator2C<T1, T2, T3, T4>()
      {
        arg1 = arg1,
        arg2 = arg2,
        arg3 = arg3,
        arg4 = arg4,
        result = result,
        \u003C\u0024\u003Earg1 = arg1,
        \u003C\u0024\u003Earg2 = arg2,
        \u003C\u0024\u003Earg3 = arg3,
        \u003C\u0024\u003Earg4 = arg4,
        \u003C\u0024\u003Eresult = result
      };
    }

    public static Future<Tuple<T1, T2, T3, T4>> WhenAll<T1, T2, T3, T4>(
      Future<T1> arg1,
      Future<T2> arg2,
      Future<T3> arg3,
      Future<T4> arg4)
    {
      return new Future<Tuple<T1, T2, T3, T4>>((Func<Promise<Tuple<T1, T2, T3, T4>>, IEnumerator>) (promise => Future.WhenAllFunc<T1, T2, T3, T4>(arg1, arg2, arg3, arg4, promise)));
    }

    public static Future<TResult> WhenAllThen<T1, T2, T3, T4, TResult>(
      Future<T1> arg1,
      Future<T2> arg2,
      Future<T3> arg3,
      Future<T4> arg4,
      Func<T1, T2, T3, T4, TResult> f)
    {
      return Future.WhenAll<T1, T2, T3, T4>(arg1, arg2, arg3, arg4).Then<TResult>((Func<Tuple<T1, T2, T3, T4>, TResult>) (t => f(t.Item1, t.Item2, t.Item3, t.Item4)));
    }

    [DebuggerHidden]
    private static IEnumerator WhenAllFunc<T1, T2, T3, T4, T5>(
      Future<T1> arg1,
      Future<T2> arg2,
      Future<T3> arg3,
      Future<T4> arg4,
      Future<T5> arg5,
      Promise<Tuple<T1, T2, T3, T4, T5>> result)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new Future.\u003CWhenAllFunc\u003Ec__Iterator2D<T1, T2, T3, T4, T5>()
      {
        arg1 = arg1,
        arg2 = arg2,
        arg3 = arg3,
        arg4 = arg4,
        arg5 = arg5,
        result = result,
        \u003C\u0024\u003Earg1 = arg1,
        \u003C\u0024\u003Earg2 = arg2,
        \u003C\u0024\u003Earg3 = arg3,
        \u003C\u0024\u003Earg4 = arg4,
        \u003C\u0024\u003Earg5 = arg5,
        \u003C\u0024\u003Eresult = result
      };
    }

    public static Future<Tuple<T1, T2, T3, T4, T5>> WhenAll<T1, T2, T3, T4, T5>(
      Future<T1> arg1,
      Future<T2> arg2,
      Future<T3> arg3,
      Future<T4> arg4,
      Future<T5> arg5)
    {
      return new Future<Tuple<T1, T2, T3, T4, T5>>((Func<Promise<Tuple<T1, T2, T3, T4, T5>>, IEnumerator>) (promise => Future.WhenAllFunc<T1, T2, T3, T4, T5>(arg1, arg2, arg3, arg4, arg5, promise)));
    }

    public static Future<TResult> WhenAllThen<T1, T2, T3, T4, T5, TResult>(
      Future<T1> arg1,
      Future<T2> arg2,
      Future<T3> arg3,
      Future<T4> arg4,
      Future<T5> arg5,
      Func<T1, T2, T3, T4, T5, TResult> f)
    {
      return Future.WhenAll<T1, T2, T3, T4, T5>(arg1, arg2, arg3, arg4, arg5).Then<TResult>((Func<Tuple<T1, T2, T3, T4, T5>, TResult>) (t => f(t.Item1, t.Item2, t.Item3, t.Item4, t.Item5)));
    }

    [DebuggerHidden]
    private static IEnumerator WhenAllFunc<T1, T2, T3, T4, T5, T6>(
      Future<T1> arg1,
      Future<T2> arg2,
      Future<T3> arg3,
      Future<T4> arg4,
      Future<T5> arg5,
      Future<T6> arg6,
      Promise<Tuple<T1, T2, T3, T4, T5, T6>> result)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new Future.\u003CWhenAllFunc\u003Ec__Iterator2E<T1, T2, T3, T4, T5, T6>()
      {
        arg1 = arg1,
        arg2 = arg2,
        arg3 = arg3,
        arg4 = arg4,
        arg5 = arg5,
        arg6 = arg6,
        result = result,
        \u003C\u0024\u003Earg1 = arg1,
        \u003C\u0024\u003Earg2 = arg2,
        \u003C\u0024\u003Earg3 = arg3,
        \u003C\u0024\u003Earg4 = arg4,
        \u003C\u0024\u003Earg5 = arg5,
        \u003C\u0024\u003Earg6 = arg6,
        \u003C\u0024\u003Eresult = result
      };
    }

    public static Future<Tuple<T1, T2, T3, T4, T5, T6>> WhenAll<T1, T2, T3, T4, T5, T6>(
      Future<T1> arg1,
      Future<T2> arg2,
      Future<T3> arg3,
      Future<T4> arg4,
      Future<T5> arg5,
      Future<T6> arg6)
    {
      return new Future<Tuple<T1, T2, T3, T4, T5, T6>>((Func<Promise<Tuple<T1, T2, T3, T4, T5, T6>>, IEnumerator>) (promise => Future.WhenAllFunc<T1, T2, T3, T4, T5, T6>(arg1, arg2, arg3, arg4, arg5, arg6, promise)));
    }

    public static Future<TResult> WhenAllThen<T1, T2, T3, T4, T5, T6, TResult>(
      Future<T1> arg1,
      Future<T2> arg2,
      Future<T3> arg3,
      Future<T4> arg4,
      Future<T5> arg5,
      Future<T6> arg6,
      Func<T1, T2, T3, T4, T5, T6, TResult> f)
    {
      return Future.WhenAll<T1, T2, T3, T4, T5, T6>(arg1, arg2, arg3, arg4, arg5, arg6).Then<TResult>((Func<Tuple<T1, T2, T3, T4, T5, T6>, TResult>) (t => f(t.Item1, t.Item2, t.Item3, t.Item4, t.Item5, t.Item6)));
    }

    [DebuggerHidden]
    private static IEnumerator WhenAllFunc<T1, T2, T3, T4, T5, T6, T7>(
      Future<T1> arg1,
      Future<T2> arg2,
      Future<T3> arg3,
      Future<T4> arg4,
      Future<T5> arg5,
      Future<T6> arg6,
      Future<T7> arg7,
      Promise<Tuple<T1, T2, T3, T4, T5, T6, T7>> result)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new Future.\u003CWhenAllFunc\u003Ec__Iterator2F<T1, T2, T3, T4, T5, T6, T7>()
      {
        arg1 = arg1,
        arg2 = arg2,
        arg3 = arg3,
        arg4 = arg4,
        arg5 = arg5,
        arg6 = arg6,
        arg7 = arg7,
        result = result,
        \u003C\u0024\u003Earg1 = arg1,
        \u003C\u0024\u003Earg2 = arg2,
        \u003C\u0024\u003Earg3 = arg3,
        \u003C\u0024\u003Earg4 = arg4,
        \u003C\u0024\u003Earg5 = arg5,
        \u003C\u0024\u003Earg6 = arg6,
        \u003C\u0024\u003Earg7 = arg7,
        \u003C\u0024\u003Eresult = result
      };
    }

    public static Future<Tuple<T1, T2, T3, T4, T5, T6, T7>> WhenAll<T1, T2, T3, T4, T5, T6, T7>(
      Future<T1> arg1,
      Future<T2> arg2,
      Future<T3> arg3,
      Future<T4> arg4,
      Future<T5> arg5,
      Future<T6> arg6,
      Future<T7> arg7)
    {
      return new Future<Tuple<T1, T2, T3, T4, T5, T6, T7>>((Func<Promise<Tuple<T1, T2, T3, T4, T5, T6, T7>>, IEnumerator>) (promise => Future.WhenAllFunc<T1, T2, T3, T4, T5, T6, T7>(arg1, arg2, arg3, arg4, arg5, arg6, arg7, promise)));
    }

    public static Future<TResult> WhenAllThen<T1, T2, T3, T4, T5, T6, T7, TResult>(
      Future<T1> arg1,
      Future<T2> arg2,
      Future<T3> arg3,
      Future<T4> arg4,
      Future<T5> arg5,
      Future<T6> arg6,
      Future<T7> arg7,
      Func<T1, T2, T3, T4, T5, T6, T7, TResult> f)
    {
      return Future.WhenAll<T1, T2, T3, T4, T5, T6, T7>(arg1, arg2, arg3, arg4, arg5, arg6, arg7).Then<TResult>((Func<Tuple<T1, T2, T3, T4, T5, T6, T7>, TResult>) (t => f(t.Item1, t.Item2, t.Item3, t.Item4, t.Item5, t.Item6, t.Item7)));
    }
  }
}
