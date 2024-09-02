// Decompiled with JetBrains decompiler
// Type: GameCore.EnumerableWrapper`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
      return (IEnumerator<T>) new EnumerableWrapper<T>.\u003CGetEnumerator\u003Ec__Iterator24()
      {
        \u003C\u003Ef__this = this
      };
    }
  }
}
