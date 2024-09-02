// Decompiled with JetBrains decompiler
// Type: ScriptBlock
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore.LispCore;
using System.Collections.Generic;

#nullable disable
public class ScriptBlock
{
  public Cons script;

  public void add(string name, Cons args)
  {
    Cons cons = SExp.cons((object) SExp.cons((object) name, (object) args), (object) null);
    if (this.script == null)
      this.script = cons;
    else
      SExp.lastCons((object) this.script).cdr = (object) cons;
  }

  public void add(Cons body)
  {
    if (this.script == null)
      this.script = body;
    else
      SExp.lastCons((object) this.script).cdr = (object) body;
  }

  public void eval(Lisp engine)
  {
    engine.evalBody((object) this.script, (Dictionary<string, object>) null);
  }
}
