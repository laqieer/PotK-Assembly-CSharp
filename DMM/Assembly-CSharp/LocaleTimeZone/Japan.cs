// Decompiled with JetBrains decompiler
// Type: LocaleTimeZone.Japan
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace LocaleTimeZone
{
  public static class Japan
  {
    public static TimeZoneInfo CreateTimeZone() => TimeZoneInfo.CreateCustomTimeZone("Asia/Tokyo", new TimeSpan(9, 0, 0), "(UTC+09:00) 大阪、札幌、東京", "Asia/Tokyo");
  }
}
