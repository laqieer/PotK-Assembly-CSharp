// Decompiled with JetBrains decompiler
// Type: SM.UserAchievements
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class UserAchievements : KeyCompare
  {
    public int achievement_id;
    public int value;
    public bool unlocked;

    public UserAchievements()
    {
    }

    public UserAchievements(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.achievement_id = (int) (long) json[nameof (achievement_id)];
      this.value = (int) (long) json[nameof (value)];
      this.unlocked = (bool) json[nameof (unlocked)];
    }
  }
}
