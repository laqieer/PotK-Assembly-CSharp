// Decompiled with JetBrains decompiler
// Type: SevenZip.CommandLineParser.SwitchForm
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

#nullable disable
namespace SevenZip.CommandLineParser
{
  public class SwitchForm
  {
    public string IDString;
    public SwitchType Type;
    public bool Multi;
    public int MinLen;
    public int MaxLen;
    public string PostCharSet;

    public SwitchForm(
      string idString,
      SwitchType type,
      bool multi,
      int minLen,
      int maxLen,
      string postCharSet)
    {
      this.IDString = idString;
      this.Type = type;
      this.Multi = multi;
      this.MinLen = minLen;
      this.MaxLen = maxLen;
      this.PostCharSet = postCharSet;
    }

    public SwitchForm(string idString, SwitchType type, bool multi, int minLen)
      : this(idString, type, multi, minLen, 0, string.Empty)
    {
    }

    public SwitchForm(string idString, SwitchType type, bool multi)
      : this(idString, type, multi, 0)
    {
    }
  }
}
