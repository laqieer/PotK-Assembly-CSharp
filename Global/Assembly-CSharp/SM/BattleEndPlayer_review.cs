// Decompiled with JetBrains decompiler
// Type: SM.BattleEndPlayer_review
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class BattleEndPlayer_review : KeyCompare
  {
    public string message;
    public string id;
    public string title;

    public BattleEndPlayer_review()
    {
    }

    public BattleEndPlayer_review(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.message = (string) json[nameof (message)];
      this.id = (string) json[nameof (id)];
      this.title = (string) json[nameof (title)];
    }
  }
}
