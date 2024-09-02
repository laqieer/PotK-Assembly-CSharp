// Decompiled with JetBrains decompiler
// Type: Age
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
