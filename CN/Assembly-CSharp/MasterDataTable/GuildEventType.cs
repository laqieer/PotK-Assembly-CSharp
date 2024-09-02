// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GuildEventType
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
  }
}
