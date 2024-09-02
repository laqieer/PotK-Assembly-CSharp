// Decompiled with JetBrains decompiler
// Type: GameCore.LongExtention
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

#nullable disable
namespace GameCore
{
  public static class LongExtention
  {
    public static string ToLocalizeNumberText(this long number)
    {
      return LocalizationPreset.Instance.EnableLocalization ? number.ToString().ToHankaku() : number.ToString().ToZenkaku();
    }
  }
}
