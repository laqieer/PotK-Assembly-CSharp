﻿// Decompiled with JetBrains decompiler
// Type: SM.PlayerGameKit2AchievementResult
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

namespace SM
{
  [Serializable]
  public class PlayerGameKit2AchievementResult : KeyCompare
  {
    public string achievement_id;
    public float progress;

    public PlayerGameKit2AchievementResult()
    {
    }

    public PlayerGameKit2AchievementResult(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.achievement_id = (string) json[nameof (achievement_id)];
      this.progress = (float) (double) json[nameof (progress)];
    }
  }
}
