// Decompiled with JetBrains decompiler
// Type: DailyMission0271PanelRoot
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class DailyMission0271PanelRoot : MonoBehaviour
{
  public GameObject panel;
  private DailyMission0271PanelRoot.DailyMissionView viewModel;
  private PlayerBingoPanel playerBingoPanel;
  public static bool isBreakPanel;
  public static bool isAnimationEnd;
  private DailyMission0271Menu _menu;
  private BackButtonMenuBase _baseMenu;

  private DailyMission0271Menu menu
  {
    get
    {
      if (Object.op_Equality((Object) this._menu, (Object) null))
        this._menu = ((Component) ((Component) this).gameObject.transform.root).GetComponent<DailyMission0271Menu>();
      return this._menu;
    }
  }

  [DebuggerHidden]
  public IEnumerator Init(PlayerBingoPanel pbp, BackButtonMenuBase baseMenu)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0271PanelRoot.\u003CInit\u003Ec__Iterator67A()
    {
      pbp = pbp,
      baseMenu = baseMenu,
      \u003C\u0024\u003Epbp = pbp,
      \u003C\u0024\u003EbaseMenu = baseMenu,
      \u003C\u003Ef__this = this
    };
  }

  public void onPopup()
  {
    if (this._baseMenu.IsPushAndSet())
      return;
    this.StartCoroutine(this.openDetailPopup());
  }

  public void onClear()
  {
    if (this._baseMenu.IsPushAndSet())
      return;
    this.StartCoroutine(this.clearMission());
  }

  [DebuggerHidden]
  private IEnumerator openDetailPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0271PanelRoot.\u003CopenDetailPopup\u003Ec__Iterator67B()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator clearMission()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0271PanelRoot.\u003CclearMission\u003Ec__Iterator67C()
    {
      \u003C\u003Ef__this = this
    };
  }

  public class DailyMissionView
  {
    public string name;
    public string detail;
    public string progressText;
    public string scene;
    public bool isClear;
    public SM.BingoRewardGroup reward;
    public MasterDataTable.BingoRewardGroup completeReward;
    public int bingo_id;
    public int panel_id;
    public int reviewBingoID = 1;
    public int reviewPanelID = 9;

    public DailyMissionView(PlayerBingoPanel playerBingoPanel, MasterDataTable.BingoRewardGroup cr)
    {
      this.completeReward = cr;
      MasterDataTable.BingoPanel bingoPanel = MasterData.BingoPanel[playerBingoPanel.bingo_panel_id];
      this.isClear = playerBingoPanel.is_open;
      this.reward = playerBingoPanel.rewards[0];
      this.bingo_id = playerBingoPanel.bingo_id;
      this.panel_id = playerBingoPanel.panel_id;
      this.name = bingoPanel.name;
      this.detail = bingoPanel.detail;
      this.progressText = Consts.Format(Consts.GetInstance().DAILY_MISSIOM_PROGRESS_FMT, (IDictionary) new Hashtable()
      {
        {
          (object) "count",
          (object) playerBingoPanel.count
        },
        {
          (object) "max",
          (object) bingoPanel.clear_count
        }
      });
      this.scene = bingoPanel.scene_name;
    }

    public bool isReviewMission
    {
      get => this.bingo_id == this.reviewBingoID && this.panel_id == this.reviewPanelID;
    }

    public string rewardName
    {
      get
      {
        return CommonRewardType.GetRewardName((MasterDataTable.CommonRewardType) this.reward.reward_type_id, this.reward.reward_id, this.reward.reward_quantity);
      }
    }

    public string completeRewardName
    {
      get
      {
        return CommonRewardType.GetRewardName(this.completeReward.reward_type_id, this.completeReward.reward_id, this.completeReward.reward_quantity);
      }
    }
  }
}
