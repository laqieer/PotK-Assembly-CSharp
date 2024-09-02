// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.BasicApi.Quests.QuestFetchFlags
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
namespace GooglePlayGames.BasicApi.Quests
{
  [Flags]
  public enum QuestFetchFlags
  {
    Upcoming = 1,
    Open = 2,
    Accepted = 4,
    Completed = 8,
    CompletedNotClaimed = 16, // 0x00000010
    Expired = 32, // 0x00000020
    EndingSoon = 64, // 0x00000040
    Failed = 128, // 0x00000080
    All = -1, // 0xFFFFFFFF
  }
}
