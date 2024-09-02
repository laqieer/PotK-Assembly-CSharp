// Decompiled with JetBrains decompiler
// Type: GuildGiftInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
