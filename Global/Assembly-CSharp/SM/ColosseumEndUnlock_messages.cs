// Decompiled with JetBrains decompiler
// Type: SM.ColosseumEndUnlock_messages
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class ColosseumEndUnlock_messages : KeyCompare
  {
    public string message;
    public string title;

    public ColosseumEndUnlock_messages()
    {
    }

    public ColosseumEndUnlock_messages(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.message = (string) json[nameof (message)];
      this.title = (string) json[nameof (title)];
    }
  }
}
