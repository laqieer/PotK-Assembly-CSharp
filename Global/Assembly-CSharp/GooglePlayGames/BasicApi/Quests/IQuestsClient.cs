// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.BasicApi.Quests.IQuestsClient
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace GooglePlayGames.BasicApi.Quests
{
  public interface IQuestsClient
  {
    void Fetch(DataSource source, string questId, Action<ResponseStatus, IQuest> callback);

    void FetchMatchingState(
      DataSource source,
      QuestFetchFlags flags,
      Action<ResponseStatus, List<IQuest>> callback);

    void ShowAllQuestsUI(
      Action<QuestUiResult, IQuest, IQuestMilestone> callback);

    void ShowSpecificQuestUI(
      IQuest quest,
      Action<QuestUiResult, IQuest, IQuestMilestone> callback);

    void Accept(IQuest quest, Action<QuestAcceptStatus, IQuest> callback);

    void ClaimMilestone(
      IQuestMilestone milestone,
      Action<QuestClaimMilestoneStatus, IQuest, IQuestMilestone> callback);
  }
}
