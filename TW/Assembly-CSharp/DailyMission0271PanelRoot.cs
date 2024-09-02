// Decompiled with JetBrains decompiler
// Type: DailyMission0271PanelRoot
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
public class DailyMission0271PanelRoot : MonoBehaviour
{
  public GameObject panel;
  private DailyMission0271PanelRoot.DailyMissionView viewModel;
  private PlayerBingoPanel playerBingoPanel;
  public static bool isBreakPanel;
  public static bool isAnimationEnd;
  private DailyMission0271Menu _menu;
  private DailyMission0271MissionRoot missionRoot;

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
  public IEnumerator Init(
    PlayerBingoPanel pbp,
    DailyMission0271MissionRoot missionRoot,
    GameObject prefab)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0271PanelRoot.\u003CInit\u003Ec__Iterator6C9()
    {
      pbp = pbp,
      missionRoot = missionRoot,
      prefab = prefab,
      \u003C\u0024\u003Epbp = pbp,
      \u003C\u0024\u003EmissionRoot = missionRoot,
      \u003C\u0024\u003Eprefab = prefab,
      \u003C\u003Ef__this = this
    };
  }

  public void onPopup()
  {
    if (this.menu.IsPushAndSet())
      return;
    this.StartCoroutine(this.openDetailPopup());
  }

  public void onClear()
  {
    if (this.menu.IsPushAndSet())
      return;
    this.StartCoroutine(this.clearMission());
  }

  [DebuggerHidden]
  private IEnumerator openDetailPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0271PanelRoot.\u003CopenDetailPopup\u003Ec__Iterator6CA()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator clearMission()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0271PanelRoot.\u003CclearMission\u003Ec__Iterator6CB()
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
    public int? arg1;
    public bool isClear;
    public int bingo_id;
    public int panel_id;
    public int reward_id;

    public DailyMissionView(PlayerBingoPanel playerBingoPanel)
    {
      BingoMission bingoMission = MasterData.BingoMission[playerBingoPanel.bingo_panel_id];
      this.reward_id = bingoMission.reward_group_id;
      this.isClear = playerBingoPanel.is_open;
      this.bingo_id = playerBingoPanel.bingo_id;
      this.panel_id = playerBingoPanel.panel_id;
      this.name = bingoMission.name;
      this.detail = bingoMission.detail;
      this.progressText = Consts.Format(Consts.GetInstance().DAILY_MISSIOM_PROGRESS_FMT, (IDictionary) new Hashtable()
      {
        {
          (object) "count",
          (object) playerBingoPanel.count
        },
        {
          (object) "max",
          (object) bingoMission.clear_count
        }
      });
      this.scene = bingoMission.scene_name;
      this.arg1 = bingoMission.scene_arg;
    }

    public MasterDataTable.BingoRewardGroup[] rewards
    {
      get
      {
        return ((IEnumerable<MasterDataTable.BingoRewardGroup>) MasterData.BingoRewardGroupList).Where<MasterDataTable.BingoRewardGroup>((Func<MasterDataTable.BingoRewardGroup, bool>) (x => x.reward_group_id == this.reward_id)).ToArray<MasterDataTable.BingoRewardGroup>();
      }
    }
  }
}
