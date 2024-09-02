// Decompiled with JetBrains decompiler
// Type: Serial0144Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Serial0144Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtDescription01;
  [SerializeField]
  protected UILabel TxtDescription02;
  [SerializeField]
  protected UILabel TxtPopuptitle;
  [SerializeField]
  protected UILabel TxtREADME;
  [SerializeField]
  private UI2DSprite LinkBugu;
  private Future<GameObject> prefabF;
  private GameObject prefab;
  private GameObject obj;

  public override void onBackButton() => this.IbtnPopupOk();

  public void IbtnPopupOk()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().dismiss();
  }

  [DebuggerHidden]
  public IEnumerator setData(WebAPI.Response.SerialRegister sr)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Serial0144Menu.\u003CsetData\u003Ec__Iterator4D1()
    {
      sr = sr,
      \u003C\u0024\u003Esr = sr,
      \u003C\u003Ef__this = this
    };
  }

  public string GetName(WebAPI.Response.SerialRegister sr)
  {
    MasterDataTable.CommonRewardType rewardTypeId = (MasterDataTable.CommonRewardType) sr.rewards[0].reward_type_id;
    int rewardId = sr.rewards[0].reward_id;
    try
    {
      switch (rewardTypeId)
      {
        case MasterDataTable.CommonRewardType.unit:
          return MasterData.UnitUnit[rewardId].name;
        case MasterDataTable.CommonRewardType.supply:
          return MasterData.SupplySupply[rewardId].name;
        case MasterDataTable.CommonRewardType.gear:
          return MasterData.GearGear[rewardId].name;
        case MasterDataTable.CommonRewardType.money:
          return Consts.Lookup("UNIQUE_ICON_ZENY_NUM", (IDictionary) new Hashtable()
          {
            {
              (object) "num",
              (object) sr.rewards[0].reward_quantity
            }
          });
        case MasterDataTable.CommonRewardType.coin:
          return Consts.Lookup("UNIQUE_ICON_KISEKI_NUM", (IDictionary) new Hashtable()
          {
            {
              (object) "num",
              (object) sr.rewards[0].reward_quantity
            }
          });
        case MasterDataTable.CommonRewardType.medal:
          return Consts.Lookup("UNIQUE_ICON_MEDAL_NUM", (IDictionary) new Hashtable()
          {
            {
              (object) "num",
              (object) sr.rewards[0].reward_quantity
            }
          });
        case MasterDataTable.CommonRewardType.friend_point:
          return Consts.Lookup("UNIQUE_ICON_POINT_NUM", (IDictionary) new Hashtable()
          {
            {
              (object) "num",
              (object) sr.rewards[0].reward_quantity
            }
          });
        case MasterDataTable.CommonRewardType.battle_medal:
          return Consts.Lookup("UNIQUE_ICON_BATTLE_MEDAL_NUM", (IDictionary) new Hashtable()
          {
            {
              (object) "num",
              (object) sr.rewards[0].reward_quantity
            }
          });
        case MasterDataTable.CommonRewardType.quest_key:
          return Consts.Lookup("UNIQUE_ICON_KEY_NUM", (IDictionary) new Hashtable()
          {
            {
              (object) "name",
              (object) MasterData.QuestkeyQuestkey[rewardId].name
            },
            {
              (object) "num",
              (object) sr.rewards[0].reward_quantity
            }
          });
        case MasterDataTable.CommonRewardType.gacha_ticket:
          return Consts.Lookup("UNIQUE_ICON_TICKET_NUM", (IDictionary) new Hashtable()
          {
            {
              (object) "name",
              (object) MasterData.GachaTicket[rewardId].name
            },
            {
              (object) "num",
              (object) sr.rewards[0].reward_quantity
            }
          });
        default:
          return string.Empty;
      }
    }
    catch
    {
      Debug.LogWarning((object) (rewardTypeId.ToString() + "ID" + (object) rewardId + "が見つからなかった："));
      return string.Empty;
    }
  }
}
