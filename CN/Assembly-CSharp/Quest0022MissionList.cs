// Decompiled with JetBrains decompiler
// Type: Quest0022MissionList
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest0022MissionList : MonoBehaviour
{
  [SerializeField]
  private UILabel TxtGetName;
  [SerializeField]
  private UISprite SlcGet;
  [SerializeField]
  private UISprite SlcAttainment;
  [SerializeField]
  private UISprite SlcNonAttainment;
  [SerializeField]
  private UISprite StarAttainment;
  [SerializeField]
  private UISprite StarNonAttainment;
  [SerializeField]
  private UISprite StarEffect;
  [SerializeField]
  private UILabel TxtDescription;
  [SerializeField]
  private UISprite SlcDescriptionBase;
  [SerializeField]
  private GameObject LinkPrefab;
  [SerializeField]
  private Transform LinkParent;
  [SerializeField]
  private UniqueIconsSetStory UniqueIcon;
  [SerializeField]
  private UI2DSprite SlcLinkEffect;
  [HideInInspector]
  public string MissionName;

  public bool IsClear { get; private set; }

  public GameObject Animation { get; set; }

  protected MasterDataTable.CommonRewardType RewardType { get; private set; }

  protected int RewardId { get; private set; }

  protected int RewardQuantity { get; private set; }

  [DebuggerHidden]
  public IEnumerator SetValue(QuestStoryMission story, bool clearFlag)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0022MissionList.\u003CSetValue\u003Ec__Iterator224()
    {
      story = story,
      clearFlag = clearFlag,
      \u003C\u0024\u003Estory = story,
      \u003C\u0024\u003EclearFlag = clearFlag,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetValue(QuestExtraMission extra, bool clearFlag)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0022MissionList.\u003CSetValue\u003Ec__Iterator225()
    {
      extra = extra,
      clearFlag = clearFlag,
      \u003C\u0024\u003Eextra = extra,
      \u003C\u0024\u003EclearFlag = clearFlag,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetValue(
    string missionName,
    bool clearFlag,
    MasterDataTable.CommonRewardType rewardType,
    int rewardId,
    int quantity,
    bool battleFlag = false)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0022MissionList.\u003CSetValue\u003Ec__Iterator226()
    {
      missionName = missionName,
      battleFlag = battleFlag,
      rewardType = rewardType,
      rewardId = rewardId,
      quantity = quantity,
      clearFlag = clearFlag,
      \u003C\u0024\u003EmissionName = missionName,
      \u003C\u0024\u003EbattleFlag = battleFlag,
      \u003C\u0024\u003ErewardType = rewardType,
      \u003C\u0024\u003ErewardId = rewardId,
      \u003C\u0024\u003Equantity = quantity,
      \u003C\u0024\u003EclearFlag = clearFlag,
      \u003C\u003Ef__this = this
    };
  }

  public void InitEffects()
  {
    if (!this.IsClear)
      return;
    this.LinkPrefab.GetComponent<UIWidget>().color = Color.white;
    ((Component) this.SlcAttainment).gameObject.SetActive(false);
    ((Component) this.StarAttainment).gameObject.SetActive(false);
  }

  public void ResultNowGet()
  {
    ((Component) this.SlcGet).gameObject.SetActive(true);
    ((Component) this.SlcAttainment).gameObject.SetActive(true);
    ((Component) this.StarAttainment).gameObject.SetActive(true);
    ((Component) this.StarEffect).gameObject.SetActive(true);
    ((IEnumerable<UITweener>) ((Component) this.StarAttainment).GetComponents<UITweener>()).ForEach<UITweener>((Action<UITweener>) (x =>
    {
      x.ResetToBeginning();
      x.PlayForward();
    }));
    UITweener component = ((Component) this.StarEffect).GetComponent<UITweener>();
    component.ResetToBeginning();
    component.PlayForward();
    ((IEnumerable<UITweener>) ((Component) this.SlcAttainment).GetComponents<UITweener>()).ForEach<UITweener>((Action<UITweener>) (x =>
    {
      x.ResetToBeginning();
      x.PlayForward();
    }));
    ((Component) this.SlcLinkEffect).gameObject.SetActive(true);
    ((IEnumerable<UITweener>) ((Component) this.SlcLinkEffect).GetComponents<UITweener>()).ForEach<UITweener>((Action<UITweener>) (x =>
    {
      x.ResetToBeginning();
      x.PlayForward();
    }));
    if (!Object.op_Inequality((Object) this.Animation, (Object) null))
      return;
    this.Animation.SetActive(true);
  }

  protected string GetName() => this.GetName(this.RewardType, this.RewardId);

  private string GetName(MasterDataTable.CommonRewardType reward, int entity_id)
  {
    Consts instance = Consts.GetInstance();
    try
    {
      switch (reward)
      {
        case MasterDataTable.CommonRewardType.unit:
        case MasterDataTable.CommonRewardType.material_unit:
          return MasterData.UnitUnit[entity_id].name;
        case MasterDataTable.CommonRewardType.supply:
          return MasterData.SupplySupply[entity_id].name;
        case MasterDataTable.CommonRewardType.gear:
          return MasterData.GearGear[entity_id].name;
        case MasterDataTable.CommonRewardType.money:
          return instance.UNIQUE_ICON_ZENY;
        case MasterDataTable.CommonRewardType.player_exp:
          return instance.UNIQUE_ICON_EXP;
        case MasterDataTable.CommonRewardType.unit_exp:
          return instance.UNIQUE_ICON_UNITEXT_LONG;
        case MasterDataTable.CommonRewardType.coin:
          return instance.UNIQUE_ICON_KISEKI;
        case MasterDataTable.CommonRewardType.recover:
          return instance.UNIQUE_ICON_APRECOVER;
        case MasterDataTable.CommonRewardType.max_unit:
          return instance.UNIQUE_ICON_MAXUNIT;
        case MasterDataTable.CommonRewardType.max_item:
          return instance.UNIQUE_ICON_MAXITEM;
        case MasterDataTable.CommonRewardType.medal:
          return instance.UNIQUE_ICON_MEDAL;
        case MasterDataTable.CommonRewardType.friend_point:
          return instance.UNIQUE_ICON_POINT;
        case MasterDataTable.CommonRewardType.emblem:
          return instance.UNIQUE_ICON_EMBLEM;
        case MasterDataTable.CommonRewardType.battle_medal:
          return instance.UNIQUE_ICON_BATTLE_MEDAL;
        case MasterDataTable.CommonRewardType.cp_recover:
          return instance.UNIQUE_ICON_CPRECOVER;
        case MasterDataTable.CommonRewardType.quest_key:
          return MasterData.QuestkeyQuestkey[entity_id].name;
        case MasterDataTable.CommonRewardType.gacha_ticket:
          return MasterData.GachaTicket[entity_id].name;
        case MasterDataTable.CommonRewardType.mp_recover:
          return instance.UNIQUE_ICON_MPRECOVER;
        default:
          return string.Empty;
      }
    }
    catch
    {
      Debug.LogWarning((object) (reward.ToString() + "ID:" + (object) entity_id + "未找到。"));
      return string.Empty;
    }
  }
}
