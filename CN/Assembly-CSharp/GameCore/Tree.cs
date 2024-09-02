// Decompiled with JetBrains decompiler
// Type: GameCore.Tree
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
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
      if (operand != null)
      {
        // ISSUE: reference to a compiler-generated field
        if (Tree.\u003C\u003Ef__switch\u0024map11 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Tree.\u003C\u003Ef__switch\u0024map11 = new Dictionary<string, int>(5)
          {
            {
              "+",
              0
            },
            {
              "-",
              1
            },
            {
              "*",
              2
            },
            {
              "/",
              3
            },
            {
              "%",
              4
            }
          };
        }
        int num3;
        // ISSUE: reference to a compiler-generated field
        if (Tree.\u003C\u003Ef__switch\u0024map11.TryGetValue(operand, out num3))
        {
          switch (num3)
          {
            case 0:
              return num1 + num2;
            case 1:
              return num1 - num2;
            case 2:
              return num1 * num2;
            case 3:
              return num1 / num2;
            case 4:
              return num1 % num2;
          }
        }
      }
      throw new FormatException(this.Operand);
    }
  }
}
