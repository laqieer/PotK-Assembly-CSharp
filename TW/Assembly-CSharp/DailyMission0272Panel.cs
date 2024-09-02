// Decompiled with JetBrains decompiler
// Type: DailyMission0272Panel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
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
  private DailyMission0272Menu _baseMenu;

  [DebuggerHidden]
  public IEnumerator Init(PlayerDailyMissionAchievement pdm, DailyMission0272Menu baseMenu)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0272Panel.\u003CInit\u003Ec__Iterator6D7()
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
    this.progressText.SetTextLocalize(Consts.Format(Consts.GetInstance().DAILY_MISSIOM_PROGRESS_FMT, (IDictionary) new Hashtable()
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
      ((MonoBehaviour) this._baseMenu).StartCoroutine(this.receiveReward());
    else
      ((MonoBehaviour) this._baseMenu).StartCoroutine(this.openPopup0273());
  }

  [DebuggerHidden]
  private IEnumerator receiveReward()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0272Panel.\u003CreceiveReward\u003Ec__Iterator6D8()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator openPopup0273()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0272Panel.\u003CopenPopup0273\u003Ec__Iterator6D9()
    {
      \u003C\u003Ef__this = this
    };
  }

  public class RewardViewModel
  {
    public int id;
    public int typeId;
    public int quantity;
    private string message;
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
          this._name = !Enum.IsDefined(typeof (MasterDataTable.CommonRewardType), (object) this.typeId) ? this.message : CommonRewardType.GetRewardName((MasterDataTable.CommonRewardType) this.typeId, this.id, this.quantity);
        return this._name;
      }
    }

    public bool IsCoin => this.typeId == 10;

    public string RewardMessage => this.message;

    [DebuggerHidden]
    public IEnumerator LoadThumb(GameObject go)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new DailyMission0272Panel.RewardViewModel.\u003CLoadThumb\u003Ec__Iterator6DA()
      {
        go = go,
        \u003C\u0024\u003Ego = go,
        \u003C\u003Ef__this = this
      };
    }
  }
}
