// Decompiled with JetBrains decompiler
// Type: SevenZip.CommandLineParser.CommandForm
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

#nullable disable
namespace SevenZip.CommandLineParser
{
  public class CommandForm
  {
    public string IDString = string.Empty;
    public bool PostStringMode;

    public CommandForm(string idString, bool postStringMode)
    {
      this.IDString = idString;
      this.PostStringMode = postStringMode;
    }
  }
}
