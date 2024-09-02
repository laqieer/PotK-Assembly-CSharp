// Decompiled with JetBrains decompiler
// Type: GameCore.Tree
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace GameCore
{
  public class Tree : INode
  {
    public readonly string Operand;
    public readonly INode Left;
    public readonly INode Right;

    public Tree(string operand, INode left, INode right)
    {
      this.Operand = operand;
      this.Left = left;
      this.Right = right;
    }

    public float Eval(Func<string, float> convert)
    {
      float num1 = this.Left.Eval(convert);
      float num2 = this.Right.Eval(convert);
      string operand = this.Operand;
      if (operand == "+")
        return num1 + num2;
      if (operand == "-")
        return num1 - num2;
      if (operand == "*")
        return num1 * num2;
      if (operand == "/")
        return num1 / num2;
      if (operand == "%")
        return num1 % num2;
      throw new FormatException(this.Operand);
    }
  }
}
