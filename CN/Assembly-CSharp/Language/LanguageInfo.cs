// Decompiled with JetBrains decompiler
// Type: Language.LanguageInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
