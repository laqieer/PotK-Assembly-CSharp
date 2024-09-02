// Decompiled with JetBrains decompiler
// Type: GameCore.If
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
