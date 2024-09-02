// Decompiled with JetBrains decompiler
// Type: GuildGiftInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System;

#nullable disable
[Serializable]
public class GuildGiftInfo
{
  public GuildGiftScrollParts scroll;

  public GuildMemberGift gift { get; set; }

  public GuildGiftInfo TempCopy()
  {
    GuildGiftInfo guildGiftInfo = (GuildGiftInfo) this.MemberwiseClone();
    guildGiftInfo.scroll = (GuildGiftScrollParts) null;
    return guildGiftInfo;
  }
}
