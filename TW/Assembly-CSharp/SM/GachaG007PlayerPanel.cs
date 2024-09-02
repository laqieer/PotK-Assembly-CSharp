// Decompiled with JetBrains decompiler
// Type: SM.GachaG007PlayerPanel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class GachaG007PlayerPanel : KeyCompare
  {
    public int? reward_quantity;
    public string description;
    public int? reward_type_id;
    public bool is_opened;
    public int position;
    public bool highlight;
    public int? reward_id;

    public GachaG007PlayerPanel()
    {
    }

    public GachaG007PlayerPanel(Dictionary<string, object> json)
    {
      this._hasKey = false;
      int? nullable1;
      if (json[nameof (reward_quantity)] == null)
      {
        nullable1 = new int?();
      }
      else
      {
        long? nullable2 = (long?) json[nameof (reward_quantity)];
        nullable1 = !nullable2.HasValue ? new int?() : new int?((int) nullable2.Value);
      }
      this.reward_quantity = nullable1;
      this.description = (string) json[nameof (description)];
      int? nullable3;
      if (json[nameof (reward_type_id)] == null)
      {
        nullable3 = new int?();
      }
      else
      {
        long? nullable4 = (long?) json[nameof (reward_type_id)];
        nullable3 = !nullable4.HasValue ? new int?() : new int?((int) nullable4.Value);
      }
      this.reward_type_id = nullable3;
      this.is_opened = (bool) json[nameof (is_opened)];
      this.position = (int) (long) json[nameof (position)];
      this.highlight = (bool) json[nameof (highlight)];
      int? nullable5;
      if (json[nameof (reward_id)] == null)
      {
        nullable5 = new int?();
      }
      else
      {
        long? nullable6 = (long?) json[nameof (reward_id)];
        nullable5 = !nullable6.HasValue ? new int?() : new int?((int) nullable6.Value);
      }
      this.reward_id = nullable5;
    }
  }
}
