// Decompiled with JetBrains decompiler
// Type: GameCore.LispCore.Cons
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
