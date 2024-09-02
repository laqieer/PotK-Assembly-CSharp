// Decompiled with JetBrains decompiler
// Type: SevenZip.CommandLineParser.SwitchResult
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;

#nullable disable
namespace SevenZip.CommandLineParser
{
  public class SwitchResult
  {
    public bool ThereIs;
    public bool WithMinus;
    public ArrayList PostStrings = new ArrayList();
    public int PostCharIndex;

    public SwitchResult() => this.ThereIs = false;
  }
}
