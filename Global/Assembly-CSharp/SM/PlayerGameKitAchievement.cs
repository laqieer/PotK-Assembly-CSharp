// Decompiled with JetBrains decompiler
// Type: SM.PlayerGameKitAchievement
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerGameKitAchievement : KeyCompare
  {
    public string achievement_id;
    public float progress;

    public PlayerGameKitAchievement()
    {
    }

    public PlayerGameKitAchievement(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.achievement_id = (string) json[nameof (achievement_id)];
      this.progress = (float) (double) json[nameof (progress)];
    }
  }
}
