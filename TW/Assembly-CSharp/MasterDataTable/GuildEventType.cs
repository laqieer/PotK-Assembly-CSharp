// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GuildEventType
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

#nullable disable
namespace MasterDataTable
{
  public enum GuildEventType
  {
    new_applicant = 1,
    apply_applicant = 2,
    cancel_applicant = 3,
    leave_membership = 4,
    assign_emblem = 5,
    change_current_emblem = 6,
    incoming_gift = 7,
    change_master = 8,
    new_submaster = 9,
    leave_submaster = 10, // 0x0000000A
    start_punitive_expedition = 11, // 0x0000000B
    receive__punitive_expedition_reward = 12, // 0x0000000C
    level_up = 13, // 0x0000000D
    base_rank_up = 14, // 0x0000000E
    post_new_chat = 15, // 0x0000000F
    change_map_info = 16, // 0x00000010
    gvg_entry = 17, // 0x00000011
    gvg_matched = 18, // 0x00000012
    gvg_started = 19, // 0x00000013
    gvg_finished = 20, // 0x00000014
    gvg_entry_expired = 21, // 0x00000015
    gvg_entry_cancel = 22, // 0x00000016
  }
}
