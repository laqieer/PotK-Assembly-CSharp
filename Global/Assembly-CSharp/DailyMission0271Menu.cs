// Decompiled with JetBrains decompiler
// Type: DailyMission0271Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class DailyMission0271Menu : BackButtonMenuBase
{
  [SerializeField]
  protected GameObject DirMission;
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  protected UILabel TxtMessage;
  [SerializeField]
  protected GameObject SlcMissionLaevateinn;
  [SerializeField]
  protected GameObject SlcMissionMasamune;
  [SerializeField]
  protected GameObject[] DirMissionPanels;
  [SerializeField]
  protected GameObject backUnit;
  [SerializeField]
  protected GameObject backShadowUnit;
  [SerializeField]
  protected GameObject DirChooseUnit;
  [SerializeField]
  protected GameObject IbtnLaevateinn;
  [SerializeField]
  protected GameObject IbtnMasamune;
  private PlayerBingo playerBingo;
  private PlayerBingoPanel[] playerBingoPanels;
  private static int masamuneGroupId = 1;
  private static int levatainnGroupId = 2;
  private bool isEndEffect = true;
  private int completeRewardGroupID;
  private MasterDataTable.BingoRewardGroup _completeReward;

  public override void onBackButton() => this.IbtnBack();

  public MasterDataTable.BingoRewardGroup completeReward
  {
    get
    {
      if (this.completeRewardGroupID == 0)
        return (MasterDataTable.BingoRewardGroup) null;
      if (this._completeReward == null)
        this._completeReward = this.getRewardForGroup(this.completeRewardGroupID);
      return this._completeReward;
    }
  }

  public GameObject[] panelObjects
  {
    get
    {
      List<GameObject> gameObjectList = new List<GameObject>();
      foreach (GameObject dirMissionPanel in this.DirMissionPanels)
      {
        GameObject panel = dirMissionPanel.GetComponent<DailyMission0271PanelRoot>().panel;
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
        DailyMission0271Panel component = panelObject.GetComponent<DailyMission0271Panel>();
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
    return (IEnumerator) new DailyMission0271Menu.\u003CInit\u003Ec__Iterator5BE()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ChooseButton()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0271Menu.\u003CChooseButton\u003Ec__Iterator5BF()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void changeStateAllPanel(bool flg)
  {
    foreach (UIButton panelButton in this.panelButtons)
      panelButton.isEnabled = flg;
  }

  public void onMasamune()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.loadConfirmPopup(DailyMission0271Menu.masamuneGroupId, (System.Action) (() =>
    {
      this.setCompleteReward(this.IbtnMasamune, DailyMission0271Menu.masamuneGroupId);
      this.SlcMissionMasamune.SetActive(true);
    })));
  }

  public void onLaevateinn()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.loadConfirmPopup(DailyMission0271Menu.levatainnGroupId, (System.Action) (() =>
    {
      this.setCompleteReward(this.IbtnLaevateinn, DailyMission0271Menu.levatainnGroupId);
      this.SlcMissionLaevateinn.SetActive(true);
    })));
  }

  public void onDailyMission() => DailyMission0272Scene.ChangeScene0272(false);

  [DebuggerHidden]
  private IEnumerator loadConfirmPopup(int rewardGroupID, System.Action okCallback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0271Menu.\u003CloadConfirmPopup\u003Ec__Iterator5C0()
    {
      rewardGroupID = rewardGroupID,
      okCallback = okCallback,
      \u003C\u0024\u003ErewardGroupID = rewardGroupID,
      \u003C\u0024\u003EokCallback = okCallback,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnBack()
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
    this.completeRewardGroupID = groupId;
    this.StartCoroutine(this.playEffect(button));
    this.StartCoroutine(this.selectCompRewardAsync(groupId));
  }

  [DebuggerHidden]
  private IEnumerator selectCompRewardAsync(int groupId)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0271Menu.\u003CselectCompRewardAsync\u003Ec__Iterator5C1()
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
    return (IEnumerator) new DailyMission0271Menu.\u003CplayEffect\u003Ec__Iterator5C2()
    {
      go = go,
      \u003C\u0024\u003Ego = go,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator createBingoMission(PlayerBingoPanel[] panels)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0271Menu.\u003CcreateBingoMission\u003Ec__Iterator5C3()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator loadUnitBackground()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0271Menu.\u003CloadUnitBackground\u003Ec__Iterator5C4()
    {
      \u003C\u003Ef__this = this
    };
  }

  private MasterDataTable.BingoRewardGroup getRewardForGroup(int groupID)
  {
    MasterDataTable.BingoRewardGroup[] values = MasterData.BingoRewardGroup.Values;
    for (int index = 0; index < values.Length; ++index)
    {
      if (values[index].reward_group_id == groupID)
        return values[index];
    }
    return (MasterDataTable.BingoRewardGroup) null;
  }

  public void openChooseUnit() => this.DirChooseUnit.SetActive(true);
}
