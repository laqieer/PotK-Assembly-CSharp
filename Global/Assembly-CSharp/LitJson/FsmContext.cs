// Decompiled with JetBrains decompiler
// Type: LitJson.FsmContext
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

#nullable disable
namespace LitJson
{
  internal class FsmContext
  {
    public bool Return;
    public int NextState;
    public Lexer L;
    public int StateStack;
  }
}
