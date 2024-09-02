// Decompiled with JetBrains decompiler
// Type: Quest00229MenuParts
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class Quest00229MenuParts : MonoBehaviour
{
  private const int RANK_3 = 2;
  private const int RANK_4 = 3;
  private const int RANK_OTHER = 4;
  private const int RANK_9 = 9;
  private const int RANK_99 = 99;
  [SerializeField]
  protected GameObject[] DirObject;
  [SerializeField]
  private UILabel RankNumberLabel;
  private int index;

  public GameObject GetTextDir() => this.DirObject[this.index];

  public void Init(QuestScoreRankingPlayer data)
  {
    if (data != null)
    {
      this.index = data.rank - 1 >= 3 ? 3 : data.rank - 1;
      ((IEnumerable<GameObject>) this.DirObject).ToggleOnce(this.index);
      if (this.index <= 2)
        return;
      this.RankNumberLabel.SetText(data.rank.ToString());
    }
    else
      ((IEnumerable<GameObject>) this.DirObject).ToggleOnce(4);
  }
}
