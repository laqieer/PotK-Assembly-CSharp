// Decompiled with JetBrains decompiler
// Type: GameCore.EnumerableWrapper`1
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
  public class EnumerableWrapper<T> : IEnumerable, IEnumerable<T>
  {
    private IEnumerable<T> e;

    public EnumerableWrapper(IEnumerable<T> e) => this.e = e;

    IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();

    [DebuggerHidden]
    public IEnumerator<T> GetEnumerator()
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator<T>) new EnumerableWrapper<T>.\u003CGetEnumerator\u003Ec__Iterator28()
      {
        \u003C\u003Ef__this = this
      };
    }
  }
}
