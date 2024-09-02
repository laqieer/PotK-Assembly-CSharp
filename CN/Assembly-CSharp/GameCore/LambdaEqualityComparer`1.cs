// Decompiled with JetBrains decompiler
// Type: GameCore.LambdaEqualityComparer`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace GameCore
{
  public class LambdaEqualityComparer<T> : IEqualityComparer<T>
  {
    private readonly Func<T, T, bool> _lambdaComparer;
    private readonly Func<T, int> _lambdaHash;

    public LambdaEqualityComparer(Func<T, T, bool> lambdaComparer)
      : this(lambdaComparer, (Func<T, int>) (o => 0))
    {
    }

    public LambdaEqualityComparer(Func<T, T, bool> lambdaComparer, Func<T, int> lambdaHash)
    {
      if (lambdaComparer == null)
        throw new ArgumentNullException(nameof (lambdaComparer));
      if (lambdaHash == null)
        throw new ArgumentNullException(nameof (lambdaHash));
      this._lambdaComparer = lambdaComparer;
      this._lambdaHash = lambdaHash;
    }

    public bool Equals(T x, T y) => this._lambdaComparer(x, y);

    public int GetHashCode(T obj) => this._lambdaHash(obj);
  }
}
