// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.BasicApi.Quests.IQuestMilestone
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

#nullable disable
namespace GooglePlayGames.BasicApi.Quests
{
  public interface IQuestMilestone
  {
    string Id { get; }

    string EventId { get; }

    string QuestId { get; }

    ulong CurrentCount { get; }

    ulong TargetCount { get; }

    byte[] CompletionRewardData { get; }

    MilestoneState State { get; }
  }
}
