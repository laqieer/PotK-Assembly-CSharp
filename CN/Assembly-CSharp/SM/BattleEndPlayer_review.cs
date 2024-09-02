// Decompiled with JetBrains decompiler
// Type: SM.BattleEndPlayer_review
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
