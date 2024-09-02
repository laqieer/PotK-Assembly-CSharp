// Decompiled with JetBrains decompiler
// Type: GameCore.Node
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
