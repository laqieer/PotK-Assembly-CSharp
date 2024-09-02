// Decompiled with JetBrains decompiler
// Type: GameCore.EnumerableWrapper
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
namespace GameCore
{
  public static class EnumerableWrapper
  {
    public static EnumerableWrapper<T> Create<T>(IEnumerable<T> e) => new EnumerableWrapper<T>(e);
  }
}
