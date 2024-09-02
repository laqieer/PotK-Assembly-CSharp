// Decompiled with JetBrains decompiler
// Type: SeaTalkMissionItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class SeaTalkMissionItem : MonoBehaviour
{
  [SerializeField]
  private UILabel releaseConditions;
  [SerializeField]
  private GameObject mask;
  [SerializeField]
  private UILabel missionName;
  [SerializeField]
  private UILabel missonClearCount;
  [SerializeField]
  private UILabel missionTotalCount;
  [SerializeField]
  private List<Transform> rewardIconParents;
  [SerializeField]
  private GameObject recipeName;
  [SerializeField]
  private UILabel recipeNameLabel;
  [SerializeField]
  private UIButton button;
  [SerializeField]
  private GameObject noCompButton;
  [SerializeField]
  private GameObject receiveButton;
  [SerializeField]
  private GameObject receivedButton;
  private TalkUnitInfo talkUnitInfo;
  private PlayerCallMission playerCallMission;
  private CallMission callMission;
  private bool isOnReceive;

  public IEnumerator Init(
    TalkUnitInfo talkUnitInfo,
    PlayerCallMission playerCallMission,
    CallMission callMission,
    List<PlayerCallMission> playerCallMissions)
  {
    this.talkUnitInfo = talkUnitInfo;
    this.playerCallMission = playerCallMission;
    this.callMission = callMission;
    if (playerCallMission.mission_status == 1)
    {
      this.mask.SetActive(true);
      this.releaseConditions.gameObject.SetActive(true);
      List<string> stringList = new List<string>();
      foreach (int num in ((IEnumerable<string>) callMission.prerequisite_mission_id.Split(',')).Select<string, int>((Func<string, int>) (x => int.Parse(x))))
      {
        int mission_id = num;
        string circleNumber = this.GetCircleNumber(playerCallMissions.First<PlayerCallMission>((Func<PlayerCallMission, bool>) (x => x.mission_id == mission_id)).sequentialNumber);
        stringList.Add(circleNumber);
      }
      this.releaseConditions.text = "ミッション" + string.Join("・", (IEnumerable<string>) stringList) + "クリアで解放";
    }
    else if (playerCallMission.mission_status == 4)
    {
      this.mask.SetActive(true);
      this.releaseConditions.gameObject.SetActive(false);
    }
    else
    {
      this.mask.SetActive(false);
      this.releaseConditions.gameObject.SetActive(false);
    }
    string missonName = this.GetMissonName();
    this.missionName.text = this.GetCircleNumber(playerCallMission.sequentialNumber) + missonName;
    this.missonClearCount.text = playerCallMission.count.ToString();
    this.missionTotalCount.text = string.Format("/{0}", (object) callMission.number_times);
    yield return (object) this.CreateRewardIcons();
    switch (playerCallMission.mission_status)
    {
      case 1:
      case 2:
        this.noCompButton.SetActive(true);
        this.receiveButton.SetActive(false);
        this.receivedButton.SetActive(false);
        this.noCompButton.GetComponent<UISprite>().color = this.button.disabledColor;
        this.button.EnableImmediately(false);
        break;
      case 3:
        this.noCompButton.SetActive(false);
        this.receiveButton.SetActive(true);
        this.receivedButton.SetActive(false);
        break;
      case 4:
        this.noCompButton.SetActive(false);
        this.receiveButton.SetActive(false);
        this.receivedButton.SetActive(true);
        this.receivedButton.GetComponent<UISprite>().color = this.button.disabledColor;
        this.button.EnableImmediately(false);
        break;
    }
  }

  private string GetCircleNumber(int i)
  {
    switch (i)
    {
      case 1:
        return "\x2460";
      case 2:
        return "\x2461";
      case 3:
        return "\x2462";
      case 4:
        return "\x2463";
      case 5:
        return "\x2464";
      case 6:
        return "\x2465";
      case 7:
        return "\x2466";
      case 8:
        return "\x2467";
      case 9:
        return "\x2468";
      case 10:
        return "\x2469";
      default:
        return "";
    }
  }

  private string GetMissonName()
  {
    switch (this.callMission.mission_type_id)
    {
      case 1:
        string[] strArray = this.callMission.item_category_id.Split(',');
        if (strArray.Length <= 1)
        {
          CallItemCategory callItemCategory = (CallItemCategory) int.Parse(strArray[0]);
          if (this.callMission.number_times <= 1)
          {
            switch (callItemCategory)
            {
              case CallItemCategory.Country:
                return "おねだりの「" + this.talkUnitInfo.countryGear.name + "」を贈る";
              case CallItemCategory.RareMaterial:
                return "おねだりの「" + this.talkUnitInfo.rareMaterialGear.name + "」を贈る";
              case CallItemCategory.ElementalStone:
                return "おねだりの「" + this.talkUnitInfo.elementStoneGear.name + "」を贈る";
              case CallItemCategory.Powder:
                return "おねだりの「" + this.talkUnitInfo.elementPowderGear.name + "」を贈る";
              case CallItemCategory.Jewelry:
                return "おねだりの「" + this.talkUnitInfo.elementJewelryGear.name + "」を贈る";
              case CallItemCategory.Flower:
                return "おねだりの「" + this.talkUnitInfo.elementFlowerGear.name + "」を贈る";
              case CallItemCategory.RareGift:
                return "おねだりの「" + this.talkUnitInfo.rarePresentGear.name + "」を贈る";
              default:
                Debug.LogError((object) string.Format("想定していないcategoryです {0}", (object) callItemCategory));
                break;
            }
          }
          else
          {
            switch (callItemCategory)
            {
              case CallItemCategory.Country:
                return string.Format("おねだりの「{0}」を{1}回贈る", (object) this.talkUnitInfo.countryGear.name, (object) this.callMission.number_times);
              case CallItemCategory.RareMaterial:
                return string.Format("おねだりの「{0}」を{1}回贈る", (object) this.talkUnitInfo.rareMaterialGear.name, (object) this.callMission.number_times);
              case CallItemCategory.ElementalStone:
                return string.Format("おねだりの「{0}」を{1}回贈る", (object) this.talkUnitInfo.elementStoneGear.name, (object) this.callMission.number_times);
              case CallItemCategory.Powder:
                return string.Format("おねだりの「{0}」を{1}回贈る", (object) this.talkUnitInfo.elementPowderGear.name, (object) this.callMission.number_times);
              case CallItemCategory.Jewelry:
                return string.Format("おねだりの「{0}」を{1}回贈る", (object) this.talkUnitInfo.elementJewelryGear.name, (object) this.callMission.number_times);
              case CallItemCategory.Flower:
                return string.Format("おねだりの「{0}」を{1}回贈る", (object) this.talkUnitInfo.elementFlowerGear.name, (object) this.callMission.number_times);
              case CallItemCategory.RareGift:
                return string.Format("おねだりの「{0}」を{1}回贈る", (object) this.talkUnitInfo.rarePresentGear.name, (object) this.callMission.number_times);
              default:
                Debug.LogError((object) string.Format("想定していないcategoryです {0}", (object) callItemCategory));
                break;
            }
          }
        }
        else
          return this.callMission.number_times <= 1 ? "おねだりでアイテムを贈る" : string.Format("おねだりでアイテムを{0}回贈る", (object) this.callMission.number_times);
        break;
      case 2:
        return this.callMission.number_times <= 1 ? "デートのおねだりを叶える" : string.Format("デートのおねだりを{0}回叶える", (object) this.callMission.number_times);
      case 3:
        return "おねだりの「" + this.talkUnitInfo.callCharacter.blue_date_place + "」デートで最高の選択をする";
      case 4:
        return "おねだりの「" + this.talkUnitInfo.seaDateSpotSettings.date_name + "」デートで最高の選択をする";
      default:
        Debug.LogError((object) string.Format("想定していないSeaTalkMissionTypeです {0}", (object) (SeaTalkMissionType) this.callMission.mission_type_id));
        break;
    }
    return "";
  }

  private IEnumerator CreateRewardIcons()
  {
    for (int i = 0; i < this.playerCallMission.rewards.Length; ++i)
    {
      PlayerCallMissionReward playerCallMissionReward = this.playerCallMission.rewards[i];
      if (playerCallMissionReward.reward_type_id.Value == 40)
        yield return (object) this.CreateRewardIconCommonTicket(this.rewardIconParents[i], playerCallMissionReward);
      else if (playerCallMissionReward.is_recipe)
      {
        yield return (object) this.CreateRewardIconRecipe(this.rewardIconParents[i], playerCallMissionReward);
        this.recipeName.SetActive(true);
        this.recipeName.transform.localPosition = new Vector3(this.rewardIconParents[i + 1].transform.localPosition.x - 70f, this.rewardIconParents[i + 1].transform.localPosition.y, this.rewardIconParents[i + 1].transform.localPosition.z);
        this.recipeNameLabel.text = ((IEnumerable<CallGiftRecipe>) MasterData.CallGiftRecipeList).First<CallGiftRecipe>((Func<CallGiftRecipe, bool>) (x => x.success_gear_id_GearGear == playerCallMissionReward.reward_id.Value)).success_gear_id.name + "\nのレシピ";
      }
      else
        Debug.LogError((object) string.Format("想定していない報酬タイプです {0}", (object) (MasterDataTable.CommonRewardType) playerCallMissionReward.reward_type_id.Value));
    }
  }

  public IEnumerator CreateRewardIconRecipe(
    Transform parent,
    PlayerCallMissionReward playerCallMissionReward)
  {
    Future<GameObject> f = new ResourceObject("Prefabs/sea030_PledgeMission/sea_icon_common").Load<GameObject>();
    IEnumerator e = f.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    yield return (object) f.Result.Clone(parent).GetComponent<SeaTalkCommonItemIcon>().Init();
  }

  public IEnumerator CreateRewardIconCommonTicket(
    Transform parent,
    PlayerCallMissionReward playerCallMissionReward)
  {
    Future<GameObject> f = Res.Icons.UniqueIconPrefab.Load<GameObject>();
    IEnumerator e = f.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    yield return (object) f.Result.Clone(parent).GetComponent<UniqueIcons>().SetCommonTicket(playerCallMissionReward.reward_id.Value, playerCallMissionReward.reward_quantity.Value);
  }

  public void OnReceive() => this.StartCoroutine(this.IOnReceive());

  private IEnumerator IOnReceive()
  {
    SeaTalkMissionItem seaTalkMissionItem = this;
    if (!seaTalkMissionItem.isOnReceive)
    {
      seaTalkMissionItem.isOnReceive = true;
      Future<WebAPI.Response.SeaTalkReceive> api = WebAPI.SeaTalkReceive(seaTalkMissionItem.playerCallMission.player_mission_id, seaTalkMissionItem.talkUnitInfo.unit.same_character_id, (System.Action<WebAPI.Response.UserError>) (e =>
      {
        WebAPI.DefaultUserErrorCallback(e);
        MypageScene.ChangeSceneOnError();
      }));
      IEnumerator e1 = api.Wait();
      while (e1.MoveNext())
        yield return e1.Current;
      e1 = (IEnumerator) null;
      WebAPI.Response.SeaTalkReceive response = api.Result;
      if (response.rewards.Length != 0)
      {
        SeaTalkMessageMenu.SeaTalkPartnerRefresh();
        Future<GameObject> f = new ResourceObject("Prefabs/sea030_PledgeMission/popup_pledgeMission_Reward").Load<GameObject>();
        e1 = f.Wait();
        while (e1.MoveNext())
          yield return e1.Current;
        e1 = (IEnumerator) null;
        GameObject result = f.Result;
        yield return (object) Singleton<PopupManager>.GetInstance().open(result).GetComponent<SeaTalkMissionRewardReceive>().Init(seaTalkMissionItem, response);
      }
    }
  }
}
