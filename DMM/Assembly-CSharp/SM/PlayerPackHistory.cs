﻿// Decompiled with JetBrains decompiler
// Type: SM.PlayerPackHistory
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

namespace SM
{
  [Serializable]
  public class PlayerPackHistory : KeyCompare
  {
    public int pack_id;
    public int id;

    public PlayerPackHistory()
    {
    }

    public PlayerPackHistory(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.pack_id = (int) (long) json[nameof (pack_id)];
      this.id = (int) (long) json[nameof (id)];
    }
  }
}
