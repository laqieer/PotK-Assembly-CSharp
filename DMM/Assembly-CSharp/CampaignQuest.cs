﻿// Decompiled with JetBrains decompiler
// Type: CampaignQuest
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using SM;
using System;

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
    CampaignQuest.RankingEventTerm rankingEventTerm = CampaignQuest.RankingEventTerm.normal;
    if (isOpen && serverTime < endAt)
      rankingEventTerm = CampaignQuest.RankingEventTerm.normal;
    else if (!isOpen && serverTime < finalAt)
      rankingEventTerm = CampaignQuest.RankingEventTerm.aggregate;
    else if (!isOpen && serverTime < latestEndAt)
      rankingEventTerm = CampaignQuest.RankingEventTerm.receive;
    return rankingEventTerm;
  }

  public enum RankingEventTerm
  {
    normal,
    receive,
    aggregate,
  }
}
