﻿// Decompiled with JetBrains decompiler
// Type: SM.ChallengeEndUnlock_messages
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

namespace SM
{
  [Serializable]
  public class ChallengeEndUnlock_messages : KeyCompare
  {
    public string message;
    public string title;

    public ChallengeEndUnlock_messages()
    {
    }

    public ChallengeEndUnlock_messages(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.message = (string) json[nameof (message)];
      this.title = (string) json[nameof (title)];
    }
  }
}
