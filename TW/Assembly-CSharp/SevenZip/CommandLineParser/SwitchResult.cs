// Decompiled with JetBrains decompiler
// Type: SevenZip.CommandLineParser.SwitchResult
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
