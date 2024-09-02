// Decompiled with JetBrains decompiler
// Type: Age
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
public static class Age
{
  public static int GetAge(DateTime birthday)
  {
    DateTime dateTime = birthday;
    DateTime now = DateTime.Now;
    int age = now.Year - dateTime.Year;
    if (new DateTime(now.Year, dateTime.Month, dateTime.Day) > now)
      --age;
    return age;
  }
}
