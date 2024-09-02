// Decompiled with JetBrains decompiler
// Type: SM.EnemyDetailInfoQuest_infos
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class EnemyDetailInfoQuest_infos : KeyCompare
  {
    public int? quest_m_id;
    public int? quest_type_id;
    public string enemy_text;
    public bool is_play;
    public int min_point;
    public int order;
    public int? quest_s_id;

    public EnemyDetailInfoQuest_infos()
    {
    }

    public EnemyDetailInfoQuest_infos(Dictionary<string, object> json)
    {
      this._hasKey = false;
      int? nullable1;
      if (json[nameof (quest_m_id)] == null)
      {
        nullable1 = new int?();
      }
      else
      {
        long? nullable2 = (long?) json[nameof (quest_m_id)];
        nullable1 = !nullable2.HasValue ? new int?() : new int?((int) nullable2.Value);
      }
      this.quest_m_id = nullable1;
      int? nullable3;
      if (json[nameof (quest_type_id)] == null)
      {
        nullable3 = new int?();
      }
      else
      {
        long? nullable4 = (long?) json[nameof (quest_type_id)];
        nullable3 = !nullable4.HasValue ? new int?() : new int?((int) nullable4.Value);
      }
      this.quest_type_id = nullable3;
      this.enemy_text = (string) json[nameof (enemy_text)];
      this.is_play = (bool) json[nameof (is_play)];
      this.min_point = (int) (long) json[nameof (min_point)];
      this.order = (int) (long) json[nameof (order)];
      int? nullable5;
      if (json[nameof (quest_s_id)] == null)
      {
        nullable5 = new int?();
      }
      else
      {
        long? nullable6 = (long?) json[nameof (quest_s_id)];
        nullable5 = !nullable6.HasValue ? new int?() : new int?((int) nullable6.Value);
      }
      this.quest_s_id = nullable5;
    }
  }
}
