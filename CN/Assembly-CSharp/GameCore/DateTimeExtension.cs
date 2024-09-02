// Decompiled with JetBrains decompiler
// Type: GameCore.DateTimeExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace GameCore
{
  public static class DateTimeExtension
  {
    public static string ToStringISO8601(this DateTime dt)
    {
      return dt.ToString("yyyy-MM-ddTHH:mm:ss.fffffffzzz");
    }
  }
}
