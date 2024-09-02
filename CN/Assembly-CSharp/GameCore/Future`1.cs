// Decompiled with JetBrains decompiler
// Type: GameCore.Future`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Diagnostics;

#nullable disable
namespace GameCore
{
  public class Future<T>
  {
    private Promise<T> promise;
    private IEnumerator enumerator;
    private Action<T> callback;

    public Future(Func<Promise<T>, IEnumerator> func)
    {
      this.promise = new Promise<T>();
      this.enumerator = this.WaitResult(func);
    }

    [DebuggerHidden]
    private IEnumerator ThenFunc<U>(Future<T> future, Func<T, U> f, Promise<U> promise)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new Future<T>.\u003CThenFunc\u003Ec__Iterator30<U>()
      {
        future = future,
        f = f,
        promise = promise,
        \u003C\u0024\u003Efuture = future,
        \u003C\u0024\u003Ef = f,
        \u003C\u0024\u003Epromise = promise
      };
    }

    public Future<U> Then<U>(Func<T, U> f)
    {
      return new Future<U>((Func<Promise<U>, IEnumerator>) (promise => this.ThenFunc<U>(this, f, promise)));
    }

    public void SetCallback(Action<T> callback) => this.callback = callback;

    public IEnumerator Wait() => this.enumerator;

    [DebuggerHidden]
    private IEnumerator WaitResult(Func<Promise<T>, IEnumerator> func)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new Future<T>.\u003CWaitResult\u003Ec__Iterator31()
      {
        func = func,
        \u003C\u0024\u003Efunc = func,
        \u003C\u003Ef__this = this
      };
    }

    public bool HasResult => this.promise.HasResult;

    public T Result => this.promise.Result;

    public Exception Exception => this.promise.Exception;

    public T GetResultOrException() => this.promise.ResultOrException;
  }
}
