﻿// Decompiled with JetBrains decompiler
// Type: GameCore.FutureExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
namespace GameCore
{
  public static class FutureExtension
  {
    [DebuggerHidden]
    private static IEnumerator UnwrapFunc<T>(Future<Future<T>> future, Promise<T> promise)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new FutureExtension.\u003CUnwrapFunc\u003Ec__Iterator36<T>()
      {
        future = future,
        promise = promise,
        \u003C\u0024\u003Efuture = future,
        \u003C\u0024\u003Epromise = promise
      };
    }

    public static Future<T> Unwrap<T>(this Future<Future<T>> future)
    {
      return new Future<T>((Func<Promise<T>, IEnumerator>) (promise => FutureExtension.UnwrapFunc<T>(future, promise)));
    }

    [DebuggerHidden]
    private static IEnumerator SequenceFunc<T>(
      IEnumerable<Future<T>> futures,
      Promise<List<T>> promise)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new FutureExtension.\u003CSequenceFunc\u003Ec__Iterator37<T>()
      {
        futures = futures,
        promise = promise,
        \u003C\u0024\u003Efutures = futures,
        \u003C\u0024\u003Epromise = promise
      };
    }

    public static Future<List<T>> Sequence<T>(this IEnumerable<Future<T>> futures)
    {
      return new Future<List<T>>((Func<Promise<List<T>>, IEnumerator>) (promise => FutureExtension.SequenceFunc<T>(futures, promise)));
    }
  }
}
