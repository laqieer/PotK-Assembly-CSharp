// Decompiled with JetBrains decompiler
// Type: I2.Loc.TermData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace I2.Loc
{
  [Serializable]
  public class TermData
  {
    public string Term = string.Empty;
    public eTermType TermType;
    public string Description = string.Empty;
    public string[] Languages = new string[0];
    public string[] Languages_Touch = new string[0];
    public byte[] Flags = new byte[0];

    public string GetTranslation(int idx)
    {
      return TermData.IsTouchType() ? (!string.IsNullOrEmpty(this.Languages_Touch[idx]) ? this.Languages_Touch[idx] : this.Languages[idx]) : (!string.IsNullOrEmpty(this.Languages[idx]) ? this.Languages[idx] : this.Languages_Touch[idx]);
    }

    public bool IsAutoTranslated(int idx, bool IsTouch)
    {
      return IsTouch ? ((int) this.Flags[idx] & 2) > 0 : ((int) this.Flags[idx] & 1) > 0;
    }

    public bool HasTouchTranslations()
    {
      int index = 0;
      for (int length = this.Languages_Touch.Length; index < length; ++index)
      {
        if (!string.IsNullOrEmpty(this.Languages_Touch[index]) && !string.IsNullOrEmpty(this.Languages[index]) && this.Languages_Touch[index] != this.Languages[index])
          return true;
      }
      return false;
    }

    public void Validate()
    {
      int newSize = Mathf.Max(this.Languages.Length, Mathf.Max(this.Languages_Touch.Length, this.Flags.Length));
      if (this.Languages.Length != newSize)
        Array.Resize<string>(ref this.Languages, newSize);
      if (this.Languages_Touch.Length != newSize)
        Array.Resize<string>(ref this.Languages_Touch, newSize);
      if (this.Flags.Length == newSize)
        return;
      Array.Resize<byte>(ref this.Flags, newSize);
    }

    public static bool IsTouchType() => true;

    public bool IsTerm(string name, bool allowCategoryMistmatch)
    {
      return !allowCategoryMistmatch ? name == this.Term : name == LanguageSource.GetKeyFromFullTerm(this.Term);
    }
  }
}
