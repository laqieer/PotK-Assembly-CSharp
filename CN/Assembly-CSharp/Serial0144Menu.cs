// Decompiled with JetBrains decompiler
// Type: Serial0144Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
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
    return (IEnumerator) new Serial0144Menu.\u003CsetData\u003Ec__Iterator575()
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
      MasterDataTable.CommonRewardType commonRewardType = rewardTypeId;
      switch (commonRewardType)
      {
        case MasterDataTable.CommonRewardType.medal:
          return Consts.Format(Consts.GetInstance().UNIQUE_ICON_MEDAL_NUM, (IDictionary) new Hashtable()
          {
            {
              (object) "num",
              (object) sr.rewards[0].reward_quantity
            }
          });
        case MasterDataTable.CommonRewardType.friend_point:
          return Consts.Format(Consts.GetInstance().UNIQUE_ICON_POINT_NUM, (IDictionary) new Hashtable()
          {
            {
              (object) "num",
              (object) sr.rewards[0].reward_quantity
            }
          });
        case MasterDataTable.CommonRewardType.battle_medal:
          return Consts.Format(Consts.GetInstance().UNIQUE_ICON_BATTLE_MEDAL_NUM, (IDictionary) new Hashtable()
          {
            {
              (object) "num",
              (object) sr.rewards[0].reward_quantity
            }
          });
        case MasterDataTable.CommonRewardType.quest_key:
          QuestkeyQuestkey questkeyQuestkey = MasterData.QuestkeyQuestkey[rewardId];
          return Consts.Format(Consts.GetInstance().UNIQUE_ICON_KEY_NUM, (IDictionary) new Hashtable()
          {
            {
              (object) "name",
              (object) questkeyQuestkey.name
            },
            {
              (object) "num",
              (object) sr.rewards[0].reward_quantity
            }
          });
        case MasterDataTable.CommonRewardType.gacha_ticket:
          MasterDataTable.GachaTicket gachaTicket = MasterData.GachaTicket[rewardId];
          return Consts.Format(Consts.GetInstance().UNIQUE_ICON_TICKET_NUM, (IDictionary) new Hashtable()
          {
            {
              (object) "name",
              (object) gachaTicket.name
            },
            {
              (object) "num",
              (object) sr.rewards[0].reward_quantity
            }
          });
        case MasterDataTable.CommonRewardType.material_unit:
label_3:
          return MasterData.UnitUnit[rewardId].name;
        default:
          switch (commonRewardType - 1)
          {
            case (MasterDataTable.CommonRewardType) 0:
              goto label_3;
            case MasterDataTable.CommonRewardType.unit:
              return MasterData.SupplySupply[rewardId].name;
            case MasterDataTable.CommonRewardType.supply:
              return MasterData.GearGear[rewardId].name;
            case MasterDataTable.CommonRewardType.gear:
              return Consts.Format(Consts.GetInstance().UNIQUE_ICON_ZENY_NUM, (IDictionary) new Hashtable()
              {
                {
                  (object) "num",
                  (object) sr.rewards[0].reward_quantity
                }
              });
            case MasterDataTable.CommonRewardType.gear_training_point:
              return Consts.Format(Consts.GetInstance().UNIQUE_ICON_KISEKI_NUM, (IDictionary) new Hashtable()
              {
                {
                  (object) "num",
                  (object) sr.rewards[0].reward_quantity
                }
              });
            default:
              return string.Empty;
          }
      }
    }
    catch
    {
      Debug.LogWarning((object) (rewardTypeId.ToString() + "ID" + (object) rewardId + "が見つからなかった："));
      return string.Empty;
    }
  }
}
