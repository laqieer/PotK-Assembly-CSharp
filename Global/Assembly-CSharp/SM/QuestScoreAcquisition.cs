// Decompiled with JetBrains decompiler
// Type: SM.QuestScoreAcquisition
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class QuestScoreAcquisition : KeyCompare
  {
    public int score;
    public string description;
    public int id;

    public QuestScoreAcquisition()
    {
    }

    public QuestScoreAcquisition(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.score = (int) (long) json[nameof (score)];
      this.description = (string) json[nameof (description)];
      this.id = (int) (long) json[nameof (id)];
    }
  }
}
