// Decompiled with JetBrains decompiler
// Type: Age
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
