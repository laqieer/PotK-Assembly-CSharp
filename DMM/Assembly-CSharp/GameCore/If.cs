﻿// Decompiled with JetBrains decompiler
// Type: GameCore.If
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace GameCore
{
  public class If : INode, IParam<INode>
  {
    public readonly Cond Condition;
    public readonly INode Left;
    public readonly INode Right;

    public If(Cond condition, INode left, INode right)
    {
      this.Condition = condition;
      this.Left = left;
      this.Right = right;
    }

    public float Eval(Func<string, float> convert) => !this.Condition.Eval(convert) ? this.Right.Eval(convert) : this.Left.Eval(convert);

    public INode getParam(Func<string, float> convert) => !this.Condition.Eval(convert) ? this.Right : this.Left;
  }
}
