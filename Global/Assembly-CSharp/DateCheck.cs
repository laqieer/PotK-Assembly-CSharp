// Decompiled with JetBrains decompiler
// Type: DateCheck
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
public static class DateCheck
{
  public static bool YearCheck(string y)
  {
    int result;
    return y.Length >= 1 && int.TryParse(y, out result) && result >= 1900 && result < DateTime.Now.Year;
  }

  public static bool MonthCheck(string m)
  {
    int result;
    return m.Length >= 1 && int.TryParse(m, out result) && result > 0 && result <= 12;
  }
}
