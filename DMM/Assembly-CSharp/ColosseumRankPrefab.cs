﻿// Decompiled with JetBrains decompiler
// Type: ColosseumRankPrefab
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class ColosseumRankPrefab : MonoBehaviour
{
  [SerializeField]
  private GameObject BoxObject;
  [SerializeField]
  private GameObject FinishObject;
  [SerializeField]
  private GameObject NextObject;
  [SerializeField]
  private UILabel textRankReward;
  [SerializeField]
  private UILabel textPoint;
  [SerializeField]
  private UILabel textRankName;
  [SerializeField]
  private UILabel textRewardName;
  [SerializeField]
  private UI2DSprite icon;
  [SerializeField]
  private UIButton rankDetailButton;
  private int nextPoint;
  private int fromPoint;
  private ColosseumRank rankInfo;
  private System.Action<ColosseumRank, int, int> rankDetailAction;
  private Color gray = new Color(0.5f, 0.5f, 0.5f);

  private void CreateUnknownItem(GameObject gearPrefab, Transform parent)
  {
    ItemIcon component = gearPrefab.Clone(parent).GetComponent<ItemIcon>();
    component.SetEmpty(true);
    component.gear.unknown.SetActive(true);
    component.BottomModeValue = ItemIcon.BottomMode.Nothing;
  }

  public void Reset(GameObject unknownObject)
  {
    this.BoxObject.SetActive(false);
    this.NextObject.SetActive(true);
    this.FinishObject.SetActive(false);
    this.textRankReward.SetTextLocalize(Consts.GetInstance().COLOSSEUM_RANK_PREFAB_RESET_01);
    this.textRankReward.color = this.gray;
    this.textRewardName.text = "";
    this.textRewardName.color = this.gray;
    this.textPoint.SetTextLocalize(Consts.GetInstance().COLOSSEUM_RANK_PREFAB_RESET_02);
    this.textRankName.SetTextLocalize(Consts.GetInstance().COLOSSEUM_RANK_PREFAB_RESET_03);
    this.textPoint.color = this.gray;
    this.textRankName.color = this.gray;
    this.icon.enabled = false;
    this.CreateUnknownItem(unknownObject, this.icon.transform);
    this.rankDetailAction = (System.Action<ColosseumRank, int, int>) null;
    this.rankDetailButton.isEnabled = false;
  }

  public IEnumerator Set(
    ColosseumRank rankInfo,
    bool select,
    int fromPoint,
    int nextPoint,
    GameObject gearObject,
    GameObject unitObject,
    GameObject umiqueObject,
    System.Action<ColosseumRank, int, int> rankDetailAction)
  {
    this.nextPoint = nextPoint;
    this.fromPoint = fromPoint;
    this.rankInfo = rankInfo;
    this.rankDetailAction = rankDetailAction;
    ColosseumRankReward reward = ((IEnumerable<ColosseumRankReward>) MasterData.ColosseumRankRewardList).FirstOrDefault<ColosseumRankReward>((Func<ColosseumRankReward, bool>) (x => x.rank_id == rankInfo.ID && x.reward_type != MasterDataTable.CommonRewardType.emblem && x.reward_type != MasterDataTable.CommonRewardType.battle_medal));
    this.BoxObject.SetActive(select);
    this.NextObject.SetActive(false);
    this.FinishObject.SetActive(!select);
    if (this.nextPoint > 0)
    {
      this.textRewardName.color = Color.white;
      this.textPoint.color = Color.white;
      this.textRankName.color = Color.white;
    }
    else
    {
      this.textRewardName.color = this.gray;
      this.textRankReward.color = this.gray;
      this.textPoint.color = this.gray;
      this.textRankName.color = this.gray;
    }
    if (reward != null)
    {
      this.icon.enabled = false;
      string rewardTitle = "";
      IEnumerator e;
      if (reward.reward_type == MasterDataTable.CommonRewardType.gear || reward.reward_type == MasterDataTable.CommonRewardType.material_gear || reward.reward_type == MasterDataTable.CommonRewardType.gear_body)
      {
        GearGear gear = MasterData.GearGear[reward.reward_id];
        rewardTitle = gear.name;
        if (gear.kind_GearKind == 9)
          rewardTitle = rewardTitle + "×" + (object) reward.reward_value;
        if (reward.reward_type == MasterDataTable.CommonRewardType.gear_body)
        {
          e = ColosseumUtility.CreateWeaponMaterialIcon(gearObject, gear, this.icon.transform, false);
          while (e.MoveNext())
            yield return e.Current;
          e = (IEnumerator) null;
        }
        else
        {
          e = ColosseumUtility.CreateGearIcon(gearObject, gear, this.icon.transform, false);
          while (e.MoveNext())
            yield return e.Current;
          e = (IEnumerator) null;
        }
      }
      else if (reward.reward_type == MasterDataTable.CommonRewardType.unit || reward.reward_type == MasterDataTable.CommonRewardType.material_unit)
      {
        UnitUnit unit = MasterData.UnitUnit[reward.reward_id];
        rewardTitle = unit.name;
        e = ColosseumUtility.CreateUnitIcon(unitObject, unit, this.icon.transform, false);
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
      }
      else if (reward.reward_type == MasterDataTable.CommonRewardType.common_ticket)
      {
        e = ColosseumUtility.CreateUniqueIcon(umiqueObject, this.icon.transform, reward.reward_type, reward.reward_id, 0, false);
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
        rewardTitle = CommonRewardType.GetRewardName(reward.reward_type, reward.reward_id);
      }
      else
      {
        e = ColosseumUtility.CreateUniqueIcon(umiqueObject, this.icon.transform, reward.reward_type, reward.reward_id, 0, false);
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
        rewardTitle = Consts.Format(Consts.GetInstance().MYPAGE_0017_STONE, (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) reward.reward_value
          }
        });
      }
      this.textRewardName.SetTextLocalize(rewardTitle);
      rewardTitle = (string) null;
    }
    else
    {
      this.textRankReward.SetTextLocalize("");
      this.textRewardName.gameObject.SetActive(false);
      this.icon.gameObject.SetActive(false);
      this.rankDetailButton.gameObject.SetActive(false);
      this.textPoint.gameObject.SetActive(false);
    }
    this.textPoint.SetTextLocalize(Consts.Format(Consts.GetInstance().COLOSSEUM_RANK_POINT, (IDictionary) new Hashtable()
    {
      {
        (object) "point",
        (object) fromPoint
      }
    }));
    this.textRankName.SetTextLocalize(rankInfo.name);
    this.rankDetailButton.isEnabled = true;
  }

  public void IbtnRankDetail() => this.rankDetailAction(this.rankInfo, this.fromPoint, this.nextPoint);
}
