﻿// Decompiled with JetBrains decompiler
// Type: SM.QuestKeyGate
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class QuestKeyGate : KeyCompare
  {
    public string title;
    public int quest_key_id;
    public int id;
    public int consume_quantity;
    public string time;

    public QuestKeyGate()
    {
    }

    public QuestKeyGate(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.title = (string) json[nameof (title)];
      this.quest_key_id = (int) (long) json[nameof (quest_key_id)];
      this.id = (int) (long) json[nameof (id)];
      this.consume_quantity = (int) (long) json[nameof (consume_quantity)];
      this.time = json[nameof (time)] != null ? (string) json[nameof (time)] : (string) null;
    }
  }
}
