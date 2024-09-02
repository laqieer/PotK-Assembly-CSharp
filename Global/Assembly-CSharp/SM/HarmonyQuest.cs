// Decompiled with JetBrains decompiler
// Type: SM.HarmonyQuest
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class HarmonyQuest : KeyCompare
  {
    public int quest_m_id;
    public bool is_disable;
    public bool is_playable;

    public HarmonyQuest()
    {
    }

    public HarmonyQuest(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.quest_m_id = (int) (long) json[nameof (quest_m_id)];
      this.is_disable = (bool) json[nameof (is_disable)];
      this.is_playable = (bool) json[nameof (is_playable)];
    }
  }
}
