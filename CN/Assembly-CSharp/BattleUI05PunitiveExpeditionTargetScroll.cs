﻿// Decompiled with JetBrains decompiler
// Type: BattleUI05PunitiveExpeditionTargetScroll
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
public class BattleUI05PunitiveExpeditionTargetScroll : MonoBehaviour
{
  [SerializeField]
  private UILabel txtPoint;
  [SerializeField]
  private UILabel txtHuntingTarget;
  [SerializeField]
  private GameObject slcBonus;

  public void Init(EventBattleFinishDestroy_enemys info)
  {
    KeyValuePair<int, UnitUnit> keyValuePair = MasterData.UnitUnit.Where<KeyValuePair<int, UnitUnit>>((Func<KeyValuePair<int, UnitUnit>, bool>) (x => x.Value.ID == info.unit_id)).FirstOrDefault<KeyValuePair<int, UnitUnit>>();
    ((Component) this.txtPoint).gameObject.SetActive(true);
    ((Component) this.txtHuntingTarget).gameObject.SetActive(true);
    this.txtPoint.SetTextLocalize(Consts.Format(Consts.GetInstance().RESULT_RANKING_MENU_POINT, (IDictionary) new Hashtable()
    {
      {
        (object) "point",
        (object) info.point
      }
    }));
    this.txtHuntingTarget.SetTextLocalize(Consts.Format(Consts.GetInstance().BATTLE_UI_05_PUNITIVE_EXPDEITION_TAEGET_COUNT, (IDictionary) new Hashtable()
    {
      {
        (object) "name",
        (object) keyValuePair.Value.name
      },
      {
        (object) "count",
        (object) info.destroy_count
      }
    }));
    this.slcBonus.SetActive(false);
  }

  public void Init(int bonusScore)
  {
    ((Component) this.txtPoint).gameObject.SetActive(true);
    ((Component) this.txtHuntingTarget).gameObject.SetActive(false);
    this.txtPoint.SetTextLocalize(Consts.Format(Consts.GetInstance().RESULT_RANKING_MENU_POINT, (IDictionary) new Hashtable()
    {
      {
        (object) "point",
        (object) bonusScore
      }
    }));
    this.slcBonus.SetActive(true);
  }
}
