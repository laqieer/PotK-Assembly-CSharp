﻿// Decompiled with JetBrains decompiler
// Type: battle01718aMission
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class battle01718aMission : MonoBehaviour
{
  [SerializeField]
  private UILabel TxtGetName;
  [SerializeField]
  private UISprite SlcGet;
  [SerializeField]
  private UILabel TxtDescription;
  [SerializeField]
  private UISprite SlcUnAttainment;
  [SerializeField]
  private UISprite SlcAttainment;
  [SerializeField]
  private UISprite SlcStarUnAttainment;
  [SerializeField]
  private UISprite SlcStarAttainment;
  [SerializeField]
  private UISprite SlcDescriptionBase;
  [SerializeField]
  private GameObject LinkPrefab;
  [SerializeField]
  private Transform LinkParent;
  [SerializeField]
  private CreateIconObject UniqueIcon;

  [DebuggerHidden]
  public IEnumerator SetSprite(bool clearflag, QuestStoryMission story)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new battle01718aMission.\u003CSetSprite\u003Ec__Iterator684()
    {
      story = story,
      clearflag = clearflag,
      \u003C\u0024\u003Estory = story,
      \u003C\u0024\u003Eclearflag = clearflag,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetSprite(bool clearflag, QuestExtraMission extra)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new battle01718aMission.\u003CSetSprite\u003Ec__Iterator685()
    {
      extra = extra,
      clearflag = clearflag,
      \u003C\u0024\u003Eextra = extra,
      \u003C\u0024\u003Eclearflag = clearflag,
      \u003C\u003Ef__this = this
    };
  }

  public void SetValue(bool clearflag)
  {
    this.LinkPrefab = this.UniqueIcon.GetIcon();
    ((Component) this.SlcAttainment).gameObject.SetActive(clearflag);
    ((Component) this.SlcUnAttainment).gameObject.SetActive(!clearflag);
    ((Component) this.SlcStarAttainment).gameObject.SetActive(clearflag);
    ((Component) this.SlcStarUnAttainment).gameObject.SetActive(!clearflag);
    ((Component) this.SlcGet).gameObject.SetActive(false);
    if (((Component) this.SlcAttainment).gameObject.activeSelf)
    {
      Color spriteDisabledColor = Consts.GetInstance().UI_SPRITE_DISABLED_COLOR;
      ((Component) this.TxtDescription).GetComponent<UIWidget>().color = spriteDisabledColor;
      ((Component) this.SlcDescriptionBase).GetComponent<UIWidget>().color = spriteDisabledColor;
      this.LinkPrefab.GetComponent<UIWidget>().color = spriteDisabledColor;
    }
    if (!Object.op_Inequality((Object) this.LinkPrefab, (Object) null))
      return;
    this.LinkPrefab.transform.localScale = new Vector3(0.65f, 0.65f, 0.65f);
  }

  private string GetName(MasterDataTable.CommonRewardType reward, int entity_id)
  {
    try
    {
      switch (reward)
      {
        case MasterDataTable.CommonRewardType.unit:
          return MasterData.UnitUnit[entity_id].name;
        case MasterDataTable.CommonRewardType.supply:
          return MasterData.SupplySupply[entity_id].name;
        case MasterDataTable.CommonRewardType.gear:
          return MasterData.GearGear[entity_id].name;
        case MasterDataTable.CommonRewardType.money:
          return Consts.Lookup("UNIQUE_ICON_ZENY");
        case MasterDataTable.CommonRewardType.player_exp:
          return Consts.Lookup("UNIQUE_ICON_PLAYEREXP");
        case MasterDataTable.CommonRewardType.coin:
          return Consts.Lookup("UNIQUE_ICON_KISEKI");
        case MasterDataTable.CommonRewardType.recover:
          return Consts.Lookup("UNIQUE_ICON_APRECOVER");
        case MasterDataTable.CommonRewardType.max_unit:
          return Consts.Lookup("UNIQUE_ICON_MAXUNIT");
        case MasterDataTable.CommonRewardType.max_item:
          return Consts.Lookup("UNIQUE_ICON_MAXITEM");
        case MasterDataTable.CommonRewardType.medal:
          return Consts.Lookup("UNIQUE_ICON_MEDAL");
        case MasterDataTable.CommonRewardType.friend_point:
          return Consts.Lookup("UNIQUE_ICON_POINT");
        case MasterDataTable.CommonRewardType.emblem:
          return Consts.Lookup("UNIQUE_ICON_EMBLEM");
        case MasterDataTable.CommonRewardType.battle_medal:
          return Consts.Lookup("UNIQUE_ICON_BATTLE_MEDAL");
        case MasterDataTable.CommonRewardType.cp_recover:
          return Consts.Lookup("UNIQUE_ICON_CPRECOVER");
        case MasterDataTable.CommonRewardType.quest_key:
          return MasterData.QuestkeyQuestkey[entity_id].name;
        case MasterDataTable.CommonRewardType.gacha_ticket:
          return MasterData.GachaTicket[entity_id].name;
        case MasterDataTable.CommonRewardType.mp_recover:
          return Consts.Lookup("UNIQUE_ICON_MPRECOVER");
        default:
          return string.Empty;
      }
    }
    catch
    {
      Debug.LogWarning((object) (reward.ToString() + "ID:" + (object) entity_id + "が見つかりませんでした。"));
      return string.Empty;
    }
  }
}
