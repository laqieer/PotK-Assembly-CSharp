// Decompiled with JetBrains decompiler
// Type: GameCore.LispCore.SExpString
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace GameCore.LispCore
{
  [Serializable]
  public class SExpString
  {
    public string strValue;

    public SExpString(char[] s) => this.strValue = new string(s);

    public SExpString(string s) => this.strValue = s;

    public override string ToString() => "\"" + this.strValue + "\"";

    public override bool Equals(object obj) => obj != null && obj is SExpString sexpString && sexpString.strValue == this.strValue;

    public bool Equals(SExpString s) => s != null && s.strValue == this.strValue;

    public override int GetHashCode() => this.strValue.GetHashCode();
  }
}
