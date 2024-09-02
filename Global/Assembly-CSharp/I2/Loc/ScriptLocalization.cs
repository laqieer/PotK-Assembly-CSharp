// Decompiled with JetBrains decompiler
// Type: I2.Loc.ScriptLocalization
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

#nullable disable
namespace I2.Loc
{
  public static class ScriptLocalization
  {
    public static string Get(string Term) => ScriptLocalization.Get(Term, false, 0);

    public static string Get(string Term, bool FixForRTL)
    {
      return ScriptLocalization.Get(Term, FixForRTL, 0);
    }

    public static string Get(string Term, bool FixForRTL, int maxLineLengthForRTL)
    {
      return LocalizationManager.GetTermTranslation(Term, FixForRTL, maxLineLengthForRTL);
    }
  }
}
