// Decompiled with JetBrains decompiler
// Type: LispParser
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore.LispCore;

#nullable disable
public class LispParser : IScriptParser
{
  private SExpReader reader;

  public LispParser(SExpReader r) => this.reader = r;

  public Cons parse(string text) => this.reader.parse(text, true) as Cons;
}
