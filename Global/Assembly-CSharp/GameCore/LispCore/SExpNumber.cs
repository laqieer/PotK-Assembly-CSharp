// Decompiled with JetBrains decompiler
// Type: GameCore.LispCore.SExpNumber
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace GameCore.LispCore
{
  [Serializable]
  public class SExpNumber
  {
    private Dictionary<Decimal, Decimal?> numberDic;

    public SExpNumber(Dictionary<Decimal, Decimal?> dic)
    {
      if (dic == null)
        this.numberDic = new Dictionary<Decimal, Decimal?>();
      else
        this.numberDic = dic;
    }

    public Decimal? numberObject(Decimal d)
    {
      if (!this.numberDic.ContainsKey(d))
        this.numberDic[d] = new Decimal?(d);
      return this.numberDic[d];
    }

    public Decimal? numberObject(float f) => this.numberObject((Decimal) f);

    public Decimal? numberObject(int i) => this.numberObject((Decimal) i);
  }
}
