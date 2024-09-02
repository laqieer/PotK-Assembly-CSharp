// Decompiled with JetBrains decompiler
// Type: DailyMission0272Panel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class DailyMission0272Panel : MonoBehaviour
{
  [SerializeField]
  private GameObject iconObject;
  [SerializeField]
  private UILabel missionText;
  [SerializeField]
  private UILabel progressText;
  [SerializeField]
  private GameObject slcClear;
  [SerializeField]
  private GameObject slcReceive;
  [SerializeField]
  private GameObject dirGague;
  [SerializeField]
  private GameObject gagueBar;
  private PlayerDailyMissionAchievement playerDailyMission;
  private DailyMission0272Panel.RewardViewModel rewardModel;
  private bool isClear;
  private UISprite gagueSprite;
  private DailyMission mission;
  private int originGuageWidth;
  private BackButtonMenuBase _baseMenu;

  [DebuggerHidden]
  public IEnumerator Init(PlayerDailyMissionAchievement pdm, BackButtonMenuBase baseMenu)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0272Panel.\u003CInit\u003Ec__Iterator5E2()
    {
      pdm = pdm,
      baseMenu = baseMenu,
      \u003C\u0024\u003Epdm = pdm,
      \u003C\u0024\u003EbaseMenu = baseMenu,
      \u003C\u003Ef__this = this
    };
  }

  public void ChangeClearState()
  {
    this.isClear = true;
    this.slcClear.SetActive(true);
    this.slcReceive.SetActive(true);
    this.mission = MasterData.DailyMission[this.playerDailyMission.mission_id];
    this.SetGague(this.mission, this.mission.num);
  }

  public void SetGague(DailyMission mission, int count)
  {
    this.missionText.SetTextLocalize(mission.name);
    this.progressText.SetTextLocalize(Consts.Lookup("DAILY_MISSIOM_PROGRESS_FMT", (IDictionary) new Hashtable()
    {
      {
        (object) nameof (count),
        (object) count
      },
      {
        (object) "max",
        (object) mission.num
      }
    }));
    this.gagueSprite.SetDimensions((int) ((double) this.originGuageWidth * ((double) count / (double) mission.num)), this.gagueSprite.height);
  }

  public void onPanelButton()
  {
    if (this._baseMenu.IsPushAndSet())
      return;
    if (this.isClear)
      this.StartCoroutine(this.receiveReward());
    else
      this.StartCoroutine(this.openPopup0273());
  }

  [DebuggerHidden]
  private IEnumerator receiveReward()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0272Panel.\u003CreceiveReward\u003Ec__Iterator5E3()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator openPopup0273()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0272Panel.\u003CopenPopup0273\u003Ec__Iterator5E4()
    {
      \u003C\u003Ef__this = this
    };
  }

  public class RewardViewModel
  {
    private int id;
    private int typeId;
    private int quantity;
    private string message;
    private UniqueIcons _icon;
    private string _name;

    public RewardViewModel(DailyMissionReward reward)
    {
      this.id = reward.reward_id;
      this.typeId = reward.reward_type_id;
      this.quantity = reward.reward_quantity;
      this.message = reward.reward_message;
    }

    public string Name
    {
      get
      {
        if (this._name == null)
          this._name = this.getRewardName();
        return this._name;
      }
    }

    public bool IsCoin => this.typeId == 10;

    public string RewardMessage => this.message;

    [DebuggerHidden]
    public IEnumerator LoadThumb(GameObject go)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new DailyMission0272Panel.RewardViewModel.\u003CLoadThumb\u003Ec__Iterator5E5()
      {
        go = go,
        \u003C\u0024\u003Ego = go,
        \u003C\u003Ef__this = this
      };
    }

    private string getRewardName()
    {
      string empty = string.Empty;
      switch (this.typeId)
      {
        case 1:
          return Consts.Lookup("MYPAGE_0017_UNIT", (IDictionary) new Hashtable()
          {
            {
              (object) "Name",
              (object) MasterData.UnitUnit[this.id].name
            },
            {
              (object) "Count",
              (object) this.quantity
            }
          });
        case 2:
          return Consts.Lookup("MYPAGE_0017_SUPPLY", (IDictionary) new Hashtable()
          {
            {
              (object) "Name",
              (object) MasterData.SupplySupply[this.id].name
            },
            {
              (object) "Count",
              (object) this.quantity
            }
          });
        case 3:
          return Consts.Lookup("MYPAGE_0017_GEAR", (IDictionary) new Hashtable()
          {
            {
              (object) "Name",
              (object) MasterData.GearGear[this.id].name
            },
            {
              (object) "Count",
              (object) this.quantity
            }
          });
        case 4:
          return Consts.Lookup("MYPAGE_0017_ZENY", (IDictionary) new Hashtable()
          {
            {
              (object) "Count",
              (object) this.quantity
            }
          });
        case 6:
          return Consts.Lookup("MYPAGE_0017_EXP", (IDictionary) new Hashtable()
          {
            {
              (object) "Count",
              (object) this.quantity
            }
          });
        case 10:
          return Consts.Lookup("MYPAGE_0017_STONE", (IDictionary) new Hashtable()
          {
            {
              (object) "Count",
              (object) this.quantity
            }
          });
        case 14:
          return Consts.Lookup("MYPAGE_0017_MEDAL", (IDictionary) new Hashtable()
          {
            {
              (object) "Count",
              (object) this.quantity
            }
          });
        case 15:
          return Consts.Lookup("MYPAGE_0017_POINT", (IDictionary) new Hashtable()
          {
            {
              (object) "Count",
              (object) this.quantity
            }
          });
        case 17:
          return Consts.Lookup("MYPAGE_0017_BATTLE_MEDAL", (IDictionary) new Hashtable()
          {
            {
              (object) "Count",
              (object) this.quantity
            }
          });
        case 19:
          return Consts.Lookup("DAILY_MISSIOM_REWARD_KEY", (IDictionary) new Hashtable()
          {
            {
              (object) "Name",
              (object) MasterData.QuestkeyQuestkey[this.id].name
            },
            {
              (object) "Count",
              (object) this.quantity
            }
          });
        case 20:
          string str = string.Empty;
          if (MasterData.GachaTicket.ContainsKey(this.id))
            str = MasterData.GachaTicket[this.id].name;
          return Consts.Lookup("MYPAGE_0017_GACHATICKET_NAME", (IDictionary) new Hashtable()
          {
            {
              (object) "Name",
              (object) str
            },
            {
              (object) "Count",
              (object) this.quantity
            }
          });
        default:
          return this.message;
      }
    }
  }
}
