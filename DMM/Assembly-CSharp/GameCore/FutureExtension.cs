// Decompiled with JetBrains decompiler
// Type: GameCore.FutureExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;

namespace GameCore
{
  public static class FutureExtension
  {
    private static IEnumerator UnwrapFunc<T>(
      Future<Future<T>> future,
      Promise<T> promise)
    {
      IEnumerator e = future.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      Future<T> innerFuture = future.Result;
      e = innerFuture.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      promise.Result = innerFuture.Result;
    }

    public static Future<T> Unwrap<T>(this Future<Future<T>> future) => new Future<T>((Func<Promise<T>, IEnumerator>) (promise => FutureExtension.UnwrapFunc<T>(future, promise)));

    private static IEnumerator SequenceFunc<T>(
      IEnumerable<Future<T>> futures,
      Promise<List<T>> promise)
    {
      List<T> result = new List<T>();
      foreach (Future<T> future1 in futures)
      {
        Future<T> future = future1;
        IEnumerator e = future.Wait();
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
        result.Add(future.Result);
        future = (Future<T>) null;
      }
      promise.Result = result;
    }

    public static Future<List<T>> Sequence<T>(this IEnumerable<Future<T>> futures) => new Future<List<T>>((Func<Promise<List<T>>, IEnumerator>) (promise => FutureExtension.SequenceFunc<T>(futures, promise)));
  }
}
