// Decompiled with JetBrains decompiler
// Type: SM.BattleEndUnlock_messages
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class BattleEndUnlock_messages : KeyCompare
  {
    public string message;
    public string title;

    public BattleEndUnlock_messages()
    {
    }

    public BattleEndUnlock_messages(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.message = (string) json[nameof (message)];
      this.title = (string) json[nameof (title)];
    }
  }
}
