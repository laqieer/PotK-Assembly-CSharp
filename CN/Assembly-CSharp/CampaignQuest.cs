﻿// Decompiled with JetBrains decompiler
// Type: CampaignQuest
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System;

#nullable disable
public static class CampaignQuest
{
  public static CampaignQuest.RankingEventTerm GetEvetnTerm(
    QuestScoreCampaignProgress campaign,
    DateTime serverTime)
  {
    return CampaignQuest.GetEvetnTerm(campaign.is_open, campaign.end_at, campaign.final_at, campaign.latest_end_at, serverTime);
  }

  public static CampaignQuest.RankingEventTerm GetEvetnTerm(
    QuestScoreBattleFinishContext campaign,
    DateTime serverTime)
  {
    return CampaignQuest.GetEvetnTerm(campaign.is_open, campaign.end_at, campaign.final_at, campaign.latest_end_at, serverTime);
  }

  private static CampaignQuest.RankingEventTerm GetEvetnTerm(
    bool isOpen,
    DateTime endAt,
    DateTime finalAt,
    DateTime latestEndAt,
    DateTime serverTime)
  {
    CampaignQuest.RankingEventTerm evetnTerm = CampaignQuest.RankingEventTerm.normal;
    if (isOpen && serverTime < endAt)
      evetnTerm = CampaignQuest.RankingEventTerm.normal;
    else if (!isOpen && serverTime < finalAt)
      evetnTerm = CampaignQuest.RankingEventTerm.aggregate;
    else if (!isOpen && serverTime < latestEndAt)
      evetnTerm = CampaignQuest.RankingEventTerm.receive;
    return evetnTerm;
  }

  public enum RankingEventTerm
  {
    normal,
    receive,
    aggregate,
  }
}
