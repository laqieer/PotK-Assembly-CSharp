// Decompiled with JetBrains decompiler
// Type: SM.UnlockQuest
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class UnlockQuest : KeyCompare
  {
    public int quest_s_id;
    public int quest_type;

    public UnlockQuest()
    {
    }

    public UnlockQuest(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.quest_s_id = (int) (long) json[nameof (quest_s_id)];
      this.quest_type = (int) (long) json[nameof (quest_type)];
    }
  }
}
