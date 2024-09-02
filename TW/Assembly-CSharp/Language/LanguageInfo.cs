// Decompiled with JetBrains decompiler
// Type: Language.LanguageInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace Language
{
  public class LanguageInfo : IEquatable<LanguageInfo>
  {
    public string Name;
    public static readonly LanguageInfo English = new LanguageInfo(nameof (English));

    public LanguageInfo()
    {
    }

    public LanguageInfo(string name) => this.Name = name;

    public bool Equals(LanguageInfo other) => other.Name == this.Name;
  }
}
