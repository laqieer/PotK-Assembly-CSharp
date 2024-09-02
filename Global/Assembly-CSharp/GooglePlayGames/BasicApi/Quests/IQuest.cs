// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.BasicApi.Quests.IQuest
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
namespace GooglePlayGames.BasicApi.Quests
{
  public interface IQuest
  {
    string Id { get; }

    string Name { get; }

    string Description { get; }

    string BannerUrl { get; }

    string IconUrl { get; }

    DateTime StartTime { get; }

    DateTime ExpirationTime { get; }

    DateTime? AcceptedTime { get; }

    IQuestMilestone Milestone { get; }

    QuestState State { get; }
  }
}
