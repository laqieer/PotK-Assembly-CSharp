// Decompiled with JetBrains decompiler
// Type: Battle01TipEventWindow
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class Battle01TipEventWindow : NGBattleMenuBase
{
  [SerializeField]
  private Battle01TipEventBase unit_exp;
  [SerializeField]
  private Battle01TipEventBase hp;
  [SerializeField]
  private Battle01TipEventBase gear;
  [SerializeField]
  private Battle01TipEventBase supply;
  [SerializeField]
  private Battle01TipEventBase medal;
  [SerializeField]
  private Battle01TipEventBase money;
  [SerializeField]
  private Battle01TipEventBase player_exp;
  [SerializeField]
  private Battle01TipEventBase skill_exp;
  [SerializeField]
  private Battle01TipEventBase unit_unit;
  [SerializeField]
  private Battle01TipEventBase battleMedal;

  public void open(BL.DropData e, BL.Unit unit)
  {
    Singleton<NGBattleManager>.GetInstance().isBattleEnable = false;
    Singleton<CommonRoot>.GetInstance().isTouchBlock = true;
    foreach (KeyValuePair<MasterDataTable.CommonRewardType, Battle01TipEventBase> keyValuePair in new Dictionary<MasterDataTable.CommonRewardType, Battle01TipEventBase>()
    {
      {
        MasterDataTable.CommonRewardType.unit_exp,
        this.unit_exp
      },
      {
        MasterDataTable.CommonRewardType.gear,
        this.gear
      },
      {
        MasterDataTable.CommonRewardType.material_gear,
        this.gear
      },
      {
        MasterDataTable.CommonRewardType.supply,
        this.supply
      },
      {
        MasterDataTable.CommonRewardType.medal,
        this.medal
      },
      {
        MasterDataTable.CommonRewardType.money,
        this.money
      },
      {
        MasterDataTable.CommonRewardType.player_exp,
        this.player_exp
      },
      {
        MasterDataTable.CommonRewardType.gear_experience_point,
        this.skill_exp
      },
      {
        MasterDataTable.CommonRewardType.unit,
        this.unit_unit
      },
      {
        MasterDataTable.CommonRewardType.material_unit,
        this.unit_unit
      },
      {
        MasterDataTable.CommonRewardType.battle_medal,
        this.battleMedal
      }
    })
    {
      if (keyValuePair.Key == e.reward.Type)
      {
        keyValuePair.Value.setData(e, unit);
        ((Component) keyValuePair.Value).gameObject.SetActive(true);
      }
      else
        ((Component) keyValuePair.Value).gameObject.SetActive(false);
    }
    ((Component) this).GetComponent<NGTweenParts>().isActive = true;
  }

  public void dismiss()
  {
    ((Component) this).GetComponent<NGTweenParts>().isActive = false;
    this.battleManager.isBattleEnable = true;
    Singleton<CommonRoot>.GetInstance().isTouchBlock = false;
  }
}
