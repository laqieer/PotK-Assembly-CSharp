﻿// Decompiled with JetBrains decompiler
// Type: GameCore.GameGlobalVariable`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace GameCore
{
  public class GameGlobalVariable<T>
  {
    private T value;

    public T Get() => this.value;

    public void Reset(T v) => this.value = v;

    public static GameGlobalVariable<T> New(params object[] args)
    {
      return new GameGlobalVariable<T>()
      {
        value = (T) Activator.CreateInstance(typeof (T), args)
      };
    }

    public static GameGlobalVariable<T> Null()
    {
      return new GameGlobalVariable<T>()
      {
        value = default (T)
      };
    }
  }
}
