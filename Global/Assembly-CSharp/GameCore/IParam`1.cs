﻿// Decompiled with JetBrains decompiler
// Type: GameCore.IParam`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
namespace GameCore
{
  public interface IParam<T>
  {
    T getParam(Func<string, float> convert);
  }
}
