﻿// Decompiled with JetBrains decompiler
// Type: TextBlock
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

#nullable disable
public class TextBlock
{
  public string text = string.Empty;
  public TextBlock.Position pos = TextBlock.Position.BOTTOM;

  public enum Position
  {
    TOP,
    BOTTOM,
  }
}
