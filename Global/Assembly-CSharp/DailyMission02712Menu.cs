// Decompiled with JetBrains decompiler
// Type: DailyMission02712Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class DailyMission02712Menu : BackButtonMenuBase
{
  [Header("Missions panel")]
  [SerializeField]
  protected GameObject DirMission;
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  protected UI2DSprite LaevateinnSprite;
  [SerializeField]
  protected UI2DSprite MasamuneSprite;
  [SerializeField]
  protected UI2DSprite OtherMissionBanner;
  [SerializeField]
  [Header("Bingo panel")]
  protected GameObject[] DirMissionPanels;
  [SerializeField]
  protected GameObject backUnit;
  [SerializeField]
  protected GameObject backShadowUnit;
  [SerializeField]
  protected GameObject backButon;
  [Header("Choose unit panel")]
  [SerializeField]
  protected GameObject DirChooseUnit;
  [SerializeField]
  protected GameObject IbtnLaevateinn;
  [SerializeField]
  protected GameObject IbtnMasamune;
  private PlayerBingo2 playerBingo2;
  private PlayerBingo2Panel[] playerBingo2Panels;
  private int masamuneGroupId;
  private int levatainnGroupId;
  private bool isEndEffect = true;
  public Bingo2CompleteRewardEntity completeBingo2RewardGroup;

  public GameObject[] panelObjects
  {
    get
    {
      List<GameObject> gameObjectList = new List<GameObject>();
      foreach (GameObject dirMissionPanel in this.DirMissionPanels)
      {
        GameObject panel = dirMissionPanel.GetComponent<DailyMission02712PanelRoot>().panel;
        if (Object.op_Inequality((Object) panel, (Object) null))
          gameObjectList.Add(panel);
      }
      return gameObjectList.ToArray();
    }
  }

  public UIButton[] panelButtons
  {
    get
    {
      List<UIButton> uiButtonList = new List<UIButton>();
      foreach (GameObject panelObject in this.panelObjects)
      {
        DailyMission02712Panel component = panelObject.GetComponent<DailyMission02712Panel>();
        uiButtonList.Add(component.clearButton);
        uiButtonList.Add(component.popupButton);
      }
      return uiButtonList.ToArray();
    }
  }

  [DebuggerHidden]
  public IEnumerator Init()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission02712Menu.\u003CInit\u003Ec__Iterator5D0()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ChooseButton()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission02712Menu.\u003CChooseButton\u003Ec__Iterator5D1()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void activeBackButton() => this.backButon.SetActive(true);

  public void changeStateAllPanel(bool flg)
  {
    foreach (UIButton panelButton in this.panelButtons)
      panelButton.isEnabled = flg;
  }

  public void onMasamune()
  {
    this.StartCoroutine(this.loadConfirmPopup(this.masamuneGroupId, (System.Action) (() => this.setCompleteReward(this.IbtnMasamune, this.masamuneGroupId))));
  }

  public void onLaevateinn()
  {
    this.StartCoroutine(this.loadConfirmPopup(this.levatainnGroupId, (System.Action) (() => this.setCompleteReward(this.IbtnLaevateinn, this.levatainnGroupId))));
  }

  public void onNextMission() => this.onBackButton();

  [DebuggerHidden]
  private IEnumerator loadConfirmPopup(int rewardGroupID, System.Action okCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission02712Menu.\u003CloadConfirmPopup\u003Ec__Iterator5D2()
    {
      rewardGroupID = rewardGroupID,
      okCallback = okCallback,
      \u003C\u0024\u003ErewardGroupID = rewardGroupID,
      \u003C\u0024\u003EokCallback = okCallback,
      \u003C\u003Ef__this = this
    };
  }

  public override void onBackButton()
  {
    if (this.IsPushAndSet())
      return;
    this.backUnit.SetActive(true);
    this.backShadowUnit.SetActive(true);
    this.backScene();
  }

  public void effectEnd() => this.isEndEffect = true;

  private void setCompleteReward(GameObject button, int groupId)
  {
    this.completeBingo2RewardGroup = ((IEnumerable<PlayerBingo2Complete_reward_groups>) this.playerBingo2.complete_reward_groups).FirstOrDefault<PlayerBingo2Complete_reward_groups>((Func<PlayerBingo2Complete_reward_groups, bool>) (x => x._complete_reward_group == groupId)).complete_reward_entities[0].complete_reward_entity;
    this.StartCoroutine(this.playEffect(button));
    this.StartCoroutine(this.selectCompRewardAsync(groupId));
  }

  [DebuggerHidden]
  private IEnumerator selectCompRewardAsync(int groupId)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission02712Menu.\u003CselectCompRewardAsync\u003Ec__Iterator5D3()
    {
      groupId = groupId,
      \u003C\u0024\u003EgroupId = groupId,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator playEffect(GameObject go)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission02712Menu.\u003CplayEffect\u003Ec__Iterator5D4()
    {
      go = go,
      \u003C\u0024\u003Ego = go,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator createBingo2Mission(PlayerBingo2Panel[] panels)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission02712Menu.\u003CcreateBingo2Mission\u003Ec__Iterator5D5()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator loadUnitBackground()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission02712Menu.\u003CloadUnitBackground\u003Ec__Iterator5D6()
    {
      \u003C\u003Ef__this = this
    };
  }

  private PlayerBingo2Complete_reward_groups getRewardForGroup(int groupID)
  {
    PlayerBingo2Complete_reward_groups[] completeRewardGroups = this.playerBingo2.complete_reward_groups;
    for (int index = 0; index < completeRewardGroups.Length; ++index)
    {
      if (completeRewardGroups[index]._complete_reward_group == groupID)
        return completeRewardGroups[index];
    }
    return (PlayerBingo2Complete_reward_groups) null;
  }

  public class DailyMissionView
  {
    public string name;
    public string detail;
    public string progressText;
    public string scene;
    public bool isClear;
    public Bingo2RewardEntity reward;
    public int bingo_id;
    public int panel_id;
    public int reviewBingoID = 1;
    public int reviewPanelID = 9;
    public PlayerBingo2Panel playerBingo2Panel;
    private DailyMission02712Menu menu;

    public DailyMissionView(DailyMission02712Menu menu, PlayerBingo2Panel playerBingo2Panel)
    {
      this.menu = menu;
      this.playerBingo2Panel = playerBingo2Panel;
      Bingo2Panel panel = playerBingo2Panel.panel;
      this.isClear = playerBingo2Panel.can_receive;
      this.reward = playerBingo2Panel.reward_entities[0].reward_entity;
      this.bingo_id = 0;
      this.panel_id = playerBingo2Panel.panel.ID;
      this.name = panel.name;
      this.detail = panel.detail;
      this.progressText = Consts.Lookup("DAILY_MISSIOM_PROGRESS_FMT", (IDictionary) new Hashtable()
      {
        {
          (object) "count",
          (object) playerBingo2Panel.count
        },
        {
          (object) "max",
          (object) panel.count
        }
      });
      this.scene = panel.scene_name;
    }

    public Bingo2CompleteRewardEntity completeReward => this.menu.completeBingo2RewardGroup;

    public bool isReviewMission => false;

    public string rewardName
    {
      get
      {
        int reward_quantity = this.reward.reward_quantity.Value;
        int rewardTypeId = (int) this.reward.reward_type_id;
        int reward_id = 0;
        if (this.reward.reward_id.HasValue)
          reward_id = this.reward.reward_id.Value;
        return this.getRewardName(rewardTypeId, reward_id, reward_quantity);
      }
    }

    public string completeRewardName
    {
      get
      {
        return this.getRewardName((int) this.completeReward.reward_type_id, this.completeReward.reward_id.Value, this.completeReward.reward_quantity.Value);
      }
    }

    private string getRewardName(int reward_type_id, int reward_id, int reward_quantity)
    {
      string rewardName = string.Empty;
      switch (reward_type_id)
      {
        case 1:
          rewardName = Consts.Lookup("MYPAGE_0017_UNIT", (IDictionary) new Hashtable()
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
          rewardName = Consts.Lookup("MYPAGE_0017_SUPPLY", (IDictionary) new Hashtable()
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
          rewardName = Consts.Lookup("MYPAGE_0017_GEAR", (IDictionary) new Hashtable()
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
          rewardName = Consts.Lookup("MYPAGE_0017_ZENY", (IDictionary) new Hashtable()
          {
            {
              (object) "Count",
              (object) reward_quantity
            }
          });
          break;
        case 6:
          rewardName = Consts.Lookup("MYPAGE_0017_EXP", (IDictionary) new Hashtable()
          {
            {
              (object) "Count",
              (object) reward_quantity
            }
          });
          break;
        case 10:
          rewardName = Consts.Lookup("MYPAGE_0017_STONE", (IDictionary) new Hashtable()
          {
            {
              (object) "Count",
              (object) reward_quantity
            }
          });
          break;
        case 14:
          rewardName = Consts.Lookup("MYPAGE_0017_MEDAL", (IDictionary) new Hashtable()
          {
            {
              (object) "Count",
              (object) reward_quantity
            }
          });
          break;
        case 15:
          rewardName = Consts.Lookup("MYPAGE_0017_POINT", (IDictionary) new Hashtable()
          {
            {
              (object) "Count",
              (object) reward_quantity
            }
          });
          break;
        case 17:
          rewardName = Consts.Lookup("MYPAGE_0017_BATTLE_MEDAL", (IDictionary) new Hashtable()
          {
            {
              (object) "Count",
              (object) reward_quantity
            }
          });
          break;
        case 19:
          rewardName = Consts.Lookup("MYPAGE_0017_KEY", (IDictionary) new Hashtable()
          {
            {
              (object) "Name",
              (object) MasterData.QuestkeyQuestkey[reward_id].name
            },
            {
              (object) "Count",
              (object) reward_quantity
            }
          });
          break;
        case 20:
          string str = string.Empty;
          if (MasterData.GachaTicket.ContainsKey(reward_id))
            str = MasterData.GachaTicket[reward_id].name;
          rewardName = Consts.Lookup("MYPAGE_0017_GACHATICKET_NAME", (IDictionary) new Hashtable()
          {
            {
              (object) "Name",
              (object) str
            },
            {
              (object) "Count",
              (object) reward_quantity
            }
          });
          break;
      }
      return rewardName;
    }
  }
}
