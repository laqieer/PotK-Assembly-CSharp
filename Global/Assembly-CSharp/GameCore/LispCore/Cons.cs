// Decompiled with JetBrains decompiler
// Type: GameCore.LispCore.Cons
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
namespace GameCore.LispCore
{
  [Serializable]
  public class Cons
  {
    public object car;
    public object cdr;

    public override string ToString()
    {
      string str = this.car != null ? this.car.ToString() : "nil";
      if (SExp.consp_(this.cdr))
        return "(" + str + " " + this.cdr.ToString().Substring(1);
      if (this.cdr == null)
        return "(" + str + ")";
      return "(" + str + " . " + this.cdr + ")";
    }
  }
}
