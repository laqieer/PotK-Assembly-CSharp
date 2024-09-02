// Decompiled with JetBrains decompiler
// Type: GameCore.LispCore.SExpString
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace GameCore.LispCore
{
  [Serializable]
  public class SExpString
  {
    public string strValue;

    public SExpString(char[] s) => this.strValue = new string(s);

    public SExpString(string s) => this.strValue = s;

    public override string ToString() => "\"" + this.strValue + "\"";

    public override bool Equals(object obj)
    {
      return obj != null && obj is SExpString sexpString && sexpString.strValue == this.strValue;
    }

    public bool Equals(SExpString s) => s != null && s.strValue == this.strValue;

    public override int GetHashCode() => this.strValue.GetHashCode();
  }
}
