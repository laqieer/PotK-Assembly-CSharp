// Decompiled with JetBrains decompiler
// Type: SM.GuildSignal
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
namespace SM
{
  [Serializable]
  public class GuildSignal : KeyCompare
  {
    public GuildEventRelationship[] relationship_events;
    public GuildEventPlayership[] playership_events;
    public GuildEventGift[] gift_events;
    public GuildEvent[] guild_events;
    public GuildEventEmblem[] emblem_events;
    public GuildEventReward[] reward_events;

    public GuildSignal()
    {
    }

    public GuildSignal(Dictionary<string, object> json)
    {
      this._hasKey = false;
      List<GuildEventRelationship> eventRelationshipList = new List<GuildEventRelationship>();
      foreach (object json1 in (List<object>) json[nameof (relationship_events)])
        eventRelationshipList.Add(json1 != null ? new GuildEventRelationship((Dictionary<string, object>) json1) : (GuildEventRelationship) null);
      this.relationship_events = eventRelationshipList.ToArray();
      List<GuildEventPlayership> guildEventPlayershipList = new List<GuildEventPlayership>();
      foreach (object json2 in (List<object>) json[nameof (playership_events)])
        guildEventPlayershipList.Add(json2 != null ? new GuildEventPlayership((Dictionary<string, object>) json2) : (GuildEventPlayership) null);
      this.playership_events = guildEventPlayershipList.ToArray();
      List<GuildEventGift> guildEventGiftList = new List<GuildEventGift>();
      foreach (object json3 in (List<object>) json[nameof (gift_events)])
        guildEventGiftList.Add(json3 != null ? new GuildEventGift((Dictionary<string, object>) json3) : (GuildEventGift) null);
      this.gift_events = guildEventGiftList.ToArray();
      List<GuildEvent> guildEventList = new List<GuildEvent>();
      foreach (object json4 in (List<object>) json[nameof (guild_events)])
        guildEventList.Add(json4 != null ? new GuildEvent((Dictionary<string, object>) json4) : (GuildEvent) null);
      this.guild_events = guildEventList.ToArray();
      List<GuildEventEmblem> guildEventEmblemList = new List<GuildEventEmblem>();
      foreach (object json5 in (List<object>) json[nameof (emblem_events)])
        guildEventEmblemList.Add(json5 != null ? new GuildEventEmblem((Dictionary<string, object>) json5) : (GuildEventEmblem) null);
      this.emblem_events = guildEventEmblemList.ToArray();
      List<GuildEventReward> guildEventRewardList = new List<GuildEventReward>();
      foreach (object json6 in (List<object>) json[nameof (reward_events)])
        guildEventRewardList.Add(json6 != null ? new GuildEventReward((Dictionary<string, object>) json6) : (GuildEventReward) null);
      this.reward_events = guildEventRewardList.ToArray();
    }

    public GuildSignal Clone() => (GuildSignal) this.MemberwiseClone();

    public static GuildSignal Current => SMManager.Get<GuildSignal>();

    public bool existPlayershipEventType(GuildEventType eventType)
    {
      return ((IEnumerable<GuildEventPlayership>) this.playership_events).Any<GuildEventPlayership>((Func<GuildEventPlayership, bool>) (x => x.target_player_id == Player.Current.id && x.event_type == eventType));
    }

    public bool existPlayershipEventTypeWithGuildId(GuildEventType eventType)
    {
      return PlayerAffiliation.Current != null && ((IEnumerable<GuildEventPlayership>) this.playership_events).Any<GuildEventPlayership>((Func<GuildEventPlayership, bool>) (x => x.guild_id == PlayerAffiliation.Current.guild_id && x.event_type == eventType));
    }

    public bool existGuildEvent(GuildEventType eventType)
    {
      return PlayerAffiliation.Current != null && ((IEnumerable<GuildEvent>) this.guild_events).Any<GuildEvent>((Func<GuildEvent, bool>) (x => x.guild_id == PlayerAffiliation.Current.guild_id && x.event_type == eventType));
    }

    public bool existGuildEventRelationship(GuildEventType eventType)
    {
      return ((IEnumerable<GuildEventRelationship>) this.relationship_events).Any<GuildEventRelationship>((Func<GuildEventRelationship, bool>) (x => x.event_type == eventType));
    }

    public bool existRelationshipEventWithoutMyself(GuildEventType eventType)
    {
      return ((IEnumerable<GuildEventRelationship>) this.relationship_events).Any<GuildEventRelationship>((Func<GuildEventRelationship, bool>) (x => x.from_player_id != Player.Current.id && x.event_type == eventType));
    }

    public bool existNewTitle()
    {
      return PlayerAffiliation.Current != null && ((IEnumerable<GuildEventEmblem>) this.emblem_events).Any<GuildEventEmblem>((Func<GuildEventEmblem, bool>) (x => x.guild_id == PlayerAffiliation.Current.guild_id && x.event_type == GuildEventType.assign_emblem));
    }

    public bool existRoleChange()
    {
      bool flag1 = this.existRelationshipEventWithoutMyself(GuildEventType.change_master);
      bool flag2 = this.existRelationshipEventWithoutMyself(GuildEventType.new_submaster);
      bool flag3 = this.existRelationshipEventWithoutMyself(GuildEventType.leave_submaster);
      return flag1 || flag2 || flag3;
    }

    public void removePlayershipEvent(GuildEventType eventType)
    {
      List<GuildEventPlayership> list = ((IEnumerable<GuildEventPlayership>) this.playership_events).ToList<GuildEventPlayership>();
      list.RemoveAll((Predicate<GuildEventPlayership>) (x => x.event_type == eventType));
      this.playership_events = list.ToArray();
    }

    public void removeRelationshipEvent(GuildEventType eventType)
    {
      List<GuildEventRelationship> list = ((IEnumerable<GuildEventRelationship>) this.relationship_events).ToList<GuildEventRelationship>();
      list.RemoveAll((Predicate<GuildEventRelationship>) (x => x.event_type == eventType));
      this.relationship_events = list.ToArray();
    }

    public bool existNewApplicant()
    {
      if (!((IEnumerable<GuildEventPlayership>) this.playership_events).Any<GuildEventPlayership>((Func<GuildEventPlayership, bool>) (x => x.event_type == GuildEventType.new_applicant)))
        return false;
      if (!((IEnumerable<GuildEventPlayership>) this.playership_events).Any<GuildEventPlayership>((Func<GuildEventPlayership, bool>) (x => x.event_type == GuildEventType.cancel_applicant)))
        return true;
      List<string> cancelIDs = new List<string>();
      List<string> applicantIDs = new List<string>();
      ((IEnumerable<GuildEventPlayership>) this.playership_events).Where<GuildEventPlayership>((Func<GuildEventPlayership, bool>) (x => x.event_type == GuildEventType.cancel_applicant)).ForEach<GuildEventPlayership>((Action<GuildEventPlayership>) (x => cancelIDs.Add(x.target_player_id)));
      ((IEnumerable<GuildEventPlayership>) this.playership_events).Where<GuildEventPlayership>((Func<GuildEventPlayership, bool>) (x => x.event_type == GuildEventType.new_applicant)).ForEach<GuildEventPlayership>((Action<GuildEventPlayership>) (x => applicantIDs.Add(x.target_player_id)));
      return applicantIDs.Except<string>((IEnumerable<string>) cancelIDs).Count<string>() > 0;
    }

    public bool existNewMember()
    {
      return ((IEnumerable<GuildEventPlayership>) this.playership_events).Any<GuildEventPlayership>((Func<GuildEventPlayership, bool>) (x => x.event_type == GuildEventType.apply_applicant));
    }
  }
}
