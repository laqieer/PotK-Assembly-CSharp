// Decompiled with JetBrains decompiler
// Type: GameCore.If
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
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

    public float Eval(Func<string, float> convert)
    {
      return this.Condition.Eval(convert) ? this.Left.Eval(convert) : this.Right.Eval(convert);
    }

    public INode getParam(Func<string, float> convert)
    {
      return this.Condition.Eval(convert) ? this.Left : this.Right;
    }
  }
}
