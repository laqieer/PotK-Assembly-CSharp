// Decompiled with JetBrains decompiler
// Type: Popup02344dMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Popup02344dMenu : NGMenuBase
{
  protected System.Action onCallback;
  [SerializeField]
  private UI2DSprite TitleImg;
  [SerializeField]
  private UILabel TxtDescription1;
  [SerializeField]
  private UILabel TxtDescription2;
  [SerializeField]
  private GameObject link_Icon;

  protected string GetRewardName(int reward_type_id, int reward_id, int reward_quantity)
  {
    string rewardName = string.Empty;
    int num = reward_type_id;
    switch (num)
    {
      case 1:
        rewardName = Consts.Format(Consts.GetInstance().MYPAGE_0017_UNIT, (IDictionary) new Hashtable()
        {
          {
            (object) "Name",
            (object) MasterData.UnitUnit[reward_id].name
          },
          {
            (object) "Count",
            (object) reward_quantity
          }
        });
        break;
      case 2:
        rewardName = Consts.Format(Consts.GetInstance().MYPAGE_0017_SUPPLY, (IDictionary) new Hashtable()
        {
          {
            (object) "Name",
            (object) MasterData.SupplySupply[reward_id].name
          },
          {
            (object) "Count",
            (object) reward_quantity
          }
        });
        break;
      case 3:
        rewardName = Consts.Format(Consts.GetInstance().MYPAGE_0017_GEAR, (IDictionary) new Hashtable()
        {
          {
            (object) "Name",
            (object) MasterData.GearGear[reward_id].name
          },
          {
            (object) "Count",
            (object) reward_quantity
          }
        });
        break;
      case 4:
        rewardName = Consts.Format(Consts.GetInstance().MYPAGE_0017_ZENY, (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) reward_quantity
          }
        });
        break;
      case 6:
        rewardName = Consts.Format(Consts.GetInstance().MYPAGE_0017_EXP, (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) reward_quantity
          }
        });
        break;
      case 7:
        rewardName = Consts.Format(Consts.GetInstance().MYPAGE_0017_UNITEXP, (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) reward_quantity
          }
        });
        break;
      case 10:
        rewardName = Consts.Format(Consts.GetInstance().MYPAGE_0017_STONE, (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) reward_quantity
          }
        });
        break;
      case 14:
        rewardName = Consts.Format(Consts.GetInstance().MYPAGE_0017_MEDAL, (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) reward_quantity
          }
        });
        break;
      case 15:
        rewardName = Consts.Format(Consts.GetInstance().MYPAGE_0017_POINT, (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) reward_quantity
          }
        });
        break;
      case 17:
        rewardName = Consts.Format(Consts.GetInstance().MYPAGE_0017_BATTLE_MEDAL, (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) reward_quantity
          }
        });
        break;
      default:
        if (num == 24)
          goto case 1;
        else
          break;
    }
    return rewardName;
  }

  [DebuggerHidden]
  public IEnumerator Init(RankUpInfoRank_up_rewards[] rewards)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup02344dMenu.\u003CInit\u003Ec__Iterator94A()
    {
      rewards = rewards,
      \u003C\u0024\u003Erewards = rewards,
      \u003C\u003Ef__this = this
    };
  }

  public void SetCallback(System.Action callback) => this.onCallback = callback;

  public virtual void IbtnOK()
  {
    if (this.onCallback != null)
      this.onCallback();
    Singleton<PopupManager>.GetInstance().onDismiss();
  }
}
