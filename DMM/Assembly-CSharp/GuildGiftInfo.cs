﻿// Decompiled with JetBrains decompiler
// Type: GuildGiftInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using SM;
using System;

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
