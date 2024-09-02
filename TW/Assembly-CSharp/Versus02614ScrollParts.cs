// Decompiled with JetBrains decompiler
// Type: Versus02614ScrollParts
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class Versus02614ScrollParts : MonoBehaviour
{
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
  [SerializeField]
  protected GameObject[] slcTotalWin;
  [SerializeField]
  protected GameObject[] slcWin;
  private int index;
  private readonly int TOP3 = 2;
  private readonly int ONE_COLUMN_LIMIT = 9;
  private readonly int DOUBLE_DIGIT_LIMIT = 99;

  public GameObject GetTextDir() => this.DirObject[this.index];

  public void Init(PvPRankingPlayer data)
  {
    if (data != null)
    {
      this.index = data.ranking - 1 > this.TOP3 ? this.TOP3 + 1 : data.ranking - 1;
      ((IEnumerable<GameObject>) this.DirObject).ToggleOnce(this.index);
      ((IEnumerable<GameObject>) this.slcTotalWin).ToggleOnce(this.index);
      ((IEnumerable<GameObject>) this.slcWin).ToggleOnce(-1);
      if (this.index <= this.TOP3)
        return;
      this.DirRankNumSingle.SetActive(false);
      this.DirRankNumDouble.SetActive(false);
      if (data.ranking > this.DOUBLE_DIGIT_LIMIT)
        return;
      if (data.ranking > this.ONE_COLUMN_LIMIT)
      {
        int ranking = data.ranking;
        ((IEnumerable<GameObject>) this.SlcRankNum1).ToggleOnce(ranking % 10);
        ((IEnumerable<GameObject>) this.SlcRankNum10).ToggleOnce(ranking / 10);
        this.DirRankNumDouble.SetActive(true);
      }
      else
      {
        ((IEnumerable<GameObject>) this.SlcRankNum).ToggleOnce(data.ranking);
        this.DirRankNumSingle.SetActive(true);
      }
    }
    else
      ((IEnumerable<GameObject>) this.DirObject).ToggleOnce(4);
  }
}
