﻿// Decompiled with JetBrains decompiler
// Type: ColosseumNewRankName
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using UnityEngine;

#nullable disable
public class ColosseumNewRankName : MonoBehaviour
{
  private Colosseum02346Menu menu;
  [SerializeField]
  private UILabel TxtNewRankName;
  [SerializeField]
  private UILabel TxtRankDown;
  [SerializeField]
  private UILabel TxtRankStay;
  [SerializeField]
  private UILabel TxtRankUp;

  public void Init(Colosseum02346Menu menu, RankUpInfo rankup, int nowBattleType)
  {
    this.menu = menu;
    this.TxtNewRankName.SetText(Consts.Lookup("COLOSSEUM_002346_RANK_CHANGE", (IDictionary) new Hashtable()
    {
      {
        (object) "name",
        (object) ColosseumUtility.GetRankName(rankup.after_rank_pt)
      }
    }));
    if (rankup.rank_change == 0)
    {
      ((Component) this.TxtRankStay).gameObject.SetActive(true);
      if (nowBattleType == 1)
      {
        this.TxtRankStay.SetText(Consts.Lookup("COLOSSEUM_002346_RANK_UP_BATTLE_STAY"));
      }
      else
      {
        if (nowBattleType != 2)
          return;
        this.TxtRankStay.SetText(Consts.Lookup("COLOSSEUM_002346_RANK_DOWN_BATTLE_STAY"));
      }
    }
    else if (rankup.rank_change == 1)
    {
      ((Component) this.TxtRankUp).gameObject.SetActive(true);
    }
    else
    {
      if (rankup.rank_change != 2)
        return;
      ((Component) this.TxtRankDown).gameObject.SetActive(true);
    }
  }

  public void Touch() => this.menu.EndRankBattlePopupEffect();
}
