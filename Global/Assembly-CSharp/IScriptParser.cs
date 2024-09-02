// Decompiled with JetBrains decompiler
// Type: IScriptParser
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore.LispCore;

#nullable disable
public interface IScriptParser
{
  Cons parse(string text);
}
