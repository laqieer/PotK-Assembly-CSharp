// Decompiled with JetBrains decompiler
// Type: GameCore.Cond
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace GameCore
{
  public class Cond
  {
    public readonly string Operand;
    public readonly INode Left;
    public readonly INode Right;

    public Cond(string operand, INode left, INode right)
    {
      this.Operand = operand;
      this.Left = left;
      this.Right = right;
    }

    public bool Eval(Func<string, float> convert)
    {
      float num1 = this.Left.Eval(convert);
      float num2 = this.Right.Eval(convert);
      string operand = this.Operand;
      if (operand != null)
      {
        // ISSUE: reference to a compiler-generated field
        if (Cond.\u003C\u003Ef__switch\u0024map12 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Cond.\u003C\u003Ef__switch\u0024map12 = new Dictionary<string, int>(8)
          {
            {
              "=",
              0
            },
            {
              ">",
              1
            },
            {
              "<",
              2
            },
            {
              "==",
              3
            },
            {
              ">=",
              4
            },
            {
              "<=",
              5
            },
            {
              "!=",
              6
            },
            {
              "<>",
              7
            }
          };
        }
        int num3;
        // ISSUE: reference to a compiler-generated field
        if (Cond.\u003C\u003Ef__switch\u0024map12.TryGetValue(operand, out num3))
        {
          switch (num3)
          {
            case 0:
              return (double) num1 == (double) num2;
            case 1:
              return (double) num1 > (double) num2;
            case 2:
              return (double) num1 < (double) num2;
            case 3:
              return (double) num1 == (double) num2;
            case 4:
              return (double) num1 >= (double) num2;
            case 5:
              return (double) num1 <= (double) num2;
            case 6:
              return (double) num1 != (double) num2;
            case 7:
              return (double) num1 != (double) num2;
          }
        }
      }
      throw new FormatException(this.Operand);
    }
  }
}
