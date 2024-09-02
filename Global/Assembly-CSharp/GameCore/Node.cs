// Decompiled with JetBrains decompiler
// Type: GameCore.Node
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
namespace GameCore
{
  public class Node : INode
  {
    public readonly string Text;
    public readonly float Value;
    public readonly bool isFloat;

    public Node(string text)
    {
      this.Text = text;
      this.isFloat = float.TryParse(text, out this.Value);
    }

    public float Eval(Func<string, float> convert)
    {
      return this.isFloat ? this.Value : convert(this.Text);
    }
  }
}
