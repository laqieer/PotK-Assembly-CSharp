// Decompiled with JetBrains decompiler
// Type: Quest00229MenuParts
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
  protected GameObject DirRankNumSingle;
  [SerializeField]
  protected GameObject[] SlcRankNum;
  [SerializeField]
  protected GameObject DirRankNumDouble;
  [SerializeField]
  protected GameObject[] SlcRankNum1;
  [SerializeField]
  protected GameObject[] SlcRankNum10;
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
      this.DirRankNumSingle.SetActive(false);
      this.DirRankNumDouble.SetActive(false);
      if (data.rank > 99)
        return;
      if (data.rank > 9)
      {
        int num = data.rank <= 99 ? data.rank : 99;
        ((IEnumerable<GameObject>) this.SlcRankNum1).ToggleOnce(num % 10);
        ((IEnumerable<GameObject>) this.SlcRankNum10).ToggleOnce(num / 10);
        this.DirRankNumDouble.SetActive(true);
      }
      else
      {
        ((IEnumerable<GameObject>) this.SlcRankNum).ToggleOnce(data.rank);
        this.DirRankNumSingle.SetActive(true);
      }
    }
    else
      ((IEnumerable<GameObject>) this.DirObject).ToggleOnce(4);
  }
}
