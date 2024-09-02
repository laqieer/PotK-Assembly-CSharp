// Decompiled with JetBrains decompiler
// Type: SM.Appearance
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class Appearance : KeyCompare
  {
    public string master_player_id;
    public int lose_num;
    public int level;
    public int experience;
    public int draw_num;
    public int membership_capacity;
    public int experience_next;
    public string master_player_name;
    public string broadcast_message;
    public int current_emblem_id;
    public int win_num;
    public int ranking_no;
    public int membership_num;

    public Appearance()
    {
    }

    public Appearance(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.master_player_id = (string) json[nameof (master_player_id)];
      this.lose_num = (int) (long) json[nameof (lose_num)];
      this.level = (int) (long) json[nameof (level)];
      this.experience = (int) (long) json[nameof (experience)];
      this.draw_num = (int) (long) json[nameof (draw_num)];
      this.membership_capacity = (int) (long) json[nameof (membership_capacity)];
      this.experience_next = (int) (long) json[nameof (experience_next)];
      this.master_player_name = (string) json[nameof (master_player_name)];
      this.broadcast_message = (string) json[nameof (broadcast_message)];
      this.current_emblem_id = (int) (long) json[nameof (current_emblem_id)];
      this.win_num = (int) (long) json[nameof (win_num)];
      this.ranking_no = (int) (long) json[nameof (ranking_no)];
      this.membership_num = (int) (long) json[nameof (membership_num)];
    }
  }
}
