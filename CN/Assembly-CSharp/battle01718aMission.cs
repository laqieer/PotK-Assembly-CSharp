// Decompiled with JetBrains decompiler
// Type: battle01718aMission
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new battle01718aMission.\u003CSetSprite\u003Ec__Iterator7CA()
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
    return (IEnumerator) new battle01718aMission.\u003CSetSprite\u003Ec__Iterator7CB()
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
      Color color = Color.Lerp(Color.white, Color.gray, 1f);
      ((Component) this.TxtDescription).GetComponent<UIWidget>().color = color;
      ((Component) this.SlcDescriptionBase).GetComponent<UIWidget>().color = color;
      this.LinkPrefab.GetComponent<UIWidget>().color = color;
    }
    if (!Object.op_Inequality((Object) this.LinkPrefab, (Object) null))
      return;
    this.LinkPrefab.transform.localScale = new Vector3(0.65f, 0.65f, 0.65f);
  }

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
