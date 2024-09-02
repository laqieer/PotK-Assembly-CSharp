// Decompiled with JetBrains decompiler
// Type: SM.GuildSignal
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections.Generic;
using UniLinq;

namespace SM
{
  [Serializable]
  public class GuildSignal : KeyCompare
  {
    public GuildEventChat[] chat_events;
    public GuildEventBase[] base_events;
    public GuildEventRelationship[] relationship_events;
    public GuildEventPlayership[] playership_events;
    public GuildEventPayload[] payload_events;
    public GuildEventGift[] gift_events;
    public GuildEvent[] guild_events;
    public GuildEventGvg[] gvg_events;
    public GuildEventEmblem[] emblem_events;
    public GuildEventReward[] reward_events;

    public GuildSignal Clone() => (GuildSignal) this.MemberwiseClone();

    public static GuildSignal Current => SMManager.Get<GuildSignal>();

    public bool existPlayershipEventType(GuildEventType eventType) => ((IEnumerable<GuildEventPlayership>) this.playership_events).Any<GuildEventPlayership>((Func<GuildEventPlayership, bool>) (x => x.target_player_id == Player.Current.id && x.event_type == eventType));

    public bool existPlayershipEventTypeWithGuildId(GuildEventType eventType) => PlayerAffiliation.Current != null && ((IEnumerable<GuildEventPlayership>) this.playership_events).Any<GuildEventPlayership>((Func<GuildEventPlayership, bool>) (x => x.guild_id == PlayerAffiliation.Current.guild_id && x.event_type == eventType));

    public bool existGuildEvent(GuildEventType eventType) => PlayerAffiliation.Current != null && ((IEnumerable<GuildEvent>) this.guild_events).Any<GuildEvent>((Func<GuildEvent, bool>) (x => x.guild_id == PlayerAffiliation.Current.guild_id && x.event_type == eventType));

    public bool existGuildEventRelationship(GuildEventType eventType) => ((IEnumerable<GuildEventRelationship>) this.relationship_events).Any<GuildEventRelationship>((Func<GuildEventRelationship, bool>) (x => x.event_type == eventType));

    public bool existRelationshipEventWithoutMyself(GuildEventType eventType) => ((IEnumerable<GuildEventRelationship>) this.relationship_events).Any<GuildEventRelationship>((Func<GuildEventRelationship, bool>) (x => x.from_player_id != Player.Current.id && x.event_type == eventType));

    public bool existChatEvent(GuildEventType eventType) => ((IEnumerable<GuildEventChat>) this.chat_events).Any<GuildEventChat>((Func<GuildEventChat, bool>) (x => x.guild_id == PlayerAffiliation.Current.guild_id && x.event_type == eventType));

    public bool existBaseEvent(GuildEventType eventType) => ((IEnumerable<GuildEventBase>) this.base_events).Any<GuildEventBase>((Func<GuildEventBase, bool>) (x => x.guild_id == PlayerAffiliation.Current.guild_id && x.event_type == eventType));

    public bool existPayloadEvent(GuildEventType eventType) => ((IEnumerable<GuildEventPayload>) this.payload_events).Any<GuildEventPayload>((Func<GuildEventPayload, bool>) (x => x.guild_id == PlayerAffiliation.Current.guild_id && x.event_type == eventType));

    public bool existGvgEvent(GuildEventType eventType) => ((IEnumerable<GuildEventGvg>) this.gvg_events).Any<GuildEventGvg>((Func<GuildEventGvg, bool>) (x => x.guild_id == PlayerAffiliation.Current.guild_id && x.event_type == eventType));

    public GuildEventGvg getCurrentGvgEvent(GuildEventType eventType) => ((IEnumerable<GuildEventGvg>) this.gvg_events).Last<GuildEventGvg>((Func<GuildEventGvg, bool>) (x => x.guild_id == PlayerAffiliation.Current.guild_id && x.event_type == eventType));

    public bool existNewTitle() => PlayerAffiliation.Current != null && ((IEnumerable<GuildEventEmblem>) this.emblem_events).Any<GuildEventEmblem>((Func<GuildEventEmblem, bool>) (x => x.guild_id == PlayerAffiliation.Current.guild_id && x.event_type == GuildEventType.assign_emblem));

    public bool existRoleChange()
    {
      int num1 = this.existRelationshipEventWithoutMyself(GuildEventType.change_master) ? 1 : 0;
      bool flag1 = this.existRelationshipEventWithoutMyself(GuildEventType.new_submaster);
      bool flag2 = this.existRelationshipEventWithoutMyself(GuildEventType.leave_submaster);
      int num2 = flag1 ? 1 : 0;
      return (num1 | num2 | (flag2 ? 1 : 0)) != 0;
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
      ((IEnumerable<GuildEventPlayership>) this.playership_events).Where<GuildEventPlayership>((Func<GuildEventPlayership, bool>) (x => x.event_type == GuildEventType.cancel_applicant)).ForEach<GuildEventPlayership>((System.Action<GuildEventPlayership>) (x => cancelIDs.Add(x.target_player_id)));
      ((IEnumerable<GuildEventPlayership>) this.playership_events).Where<GuildEventPlayership>((Func<GuildEventPlayership, bool>) (x => x.event_type == GuildEventType.new_applicant)).ForEach<GuildEventPlayership>((System.Action<GuildEventPlayership>) (x => applicantIDs.Add(x.target_player_id)));
      return applicantIDs.Except<string>((IEnumerable<string>) cancelIDs).Any<string>();
    }

    public bool existNewMember() => ((IEnumerable<GuildEventPlayership>) this.playership_events).Any<GuildEventPlayership>((Func<GuildEventPlayership, bool>) (x => x.event_type == GuildEventType.apply_applicant));

    public GuildSignal()
    {
    }

    public GuildSignal(Dictionary<string, object> json)
    {
      this._hasKey = false;
      List<GuildEventChat> guildEventChatList = new List<GuildEventChat>();
      foreach (object obj in (List<object>) json[nameof (chat_events)])
        guildEventChatList.Add(obj == null ? (GuildEventChat) null : new GuildEventChat((Dictionary<string, object>) obj));
      this.chat_events = guildEventChatList.ToArray();
      List<GuildEventBase> guildEventBaseList = new List<GuildEventBase>();
      foreach (object obj in (List<object>) json[nameof (base_events)])
        guildEventBaseList.Add(obj == null ? (GuildEventBase) null : new GuildEventBase((Dictionary<string, object>) obj));
      this.base_events = guildEventBaseList.ToArray();
      List<GuildEventRelationship> eventRelationshipList = new List<GuildEventRelationship>();
      foreach (object obj in (List<object>) json[nameof (relationship_events)])
        eventRelationshipList.Add(obj == null ? (GuildEventRelationship) null : new GuildEventRelationship((Dictionary<string, object>) obj));
      this.relationship_events = eventRelationshipList.ToArray();
      List<GuildEventPlayership> guildEventPlayershipList = new List<GuildEventPlayership>();
      foreach (object obj in (List<object>) json[nameof (playership_events)])
        guildEventPlayershipList.Add(obj == null ? (GuildEventPlayership) null : new GuildEventPlayership((Dictionary<string, object>) obj));
      this.playership_events = guildEventPlayershipList.ToArray();
      List<GuildEventPayload> guildEventPayloadList = new List<GuildEventPayload>();
      foreach (object obj in (List<object>) json[nameof (payload_events)])
        guildEventPayloadList.Add(obj == null ? (GuildEventPayload) null : new GuildEventPayload((Dictionary<string, object>) obj));
      this.payload_events = guildEventPayloadList.ToArray();
      List<GuildEventGift> guildEventGiftList = new List<GuildEventGift>();
      foreach (object obj in (List<object>) json[nameof (gift_events)])
        guildEventGiftList.Add(obj == null ? (GuildEventGift) null : new GuildEventGift((Dictionary<string, object>) obj));
      this.gift_events = guildEventGiftList.ToArray();
      List<GuildEvent> guildEventList = new List<GuildEvent>();
      foreach (object obj in (List<object>) json[nameof (guild_events)])
        guildEventList.Add(obj == null ? (GuildEvent) null : new GuildEvent((Dictionary<string, object>) obj));
      this.guild_events = guildEventList.ToArray();
      List<GuildEventGvg> guildEventGvgList = new List<GuildEventGvg>();
      foreach (object obj in (List<object>) json[nameof (gvg_events)])
        guildEventGvgList.Add(obj == null ? (GuildEventGvg) null : new GuildEventGvg((Dictionary<string, object>) obj));
      this.gvg_events = guildEventGvgList.ToArray();
      List<GuildEventEmblem> guildEventEmblemList = new List<GuildEventEmblem>();
      foreach (object obj in (List<object>) json[nameof (emblem_events)])
        guildEventEmblemList.Add(obj == null ? (GuildEventEmblem) null : new GuildEventEmblem((Dictionary<string, object>) obj));
      this.emblem_events = guildEventEmblemList.ToArray();
      List<GuildEventReward> guildEventRewardList = new List<GuildEventReward>();
      foreach (object obj in (List<object>) json[nameof (reward_events)])
        guildEventRewardList.Add(obj == null ? (GuildEventReward) null : new GuildEventReward((Dictionary<string, object>) obj));
      this.reward_events = guildEventRewardList.ToArray();
    }
  }
}
