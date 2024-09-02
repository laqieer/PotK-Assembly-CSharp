// Decompiled with JetBrains decompiler
// Type: ActivityMission00418Panel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class ActivityMission00418Panel : MonoBehaviour
{
  [SerializeField]
  private GameObject iconObject;
  [SerializeField]
  private UILabel missionText;
  [SerializeField]
  private GameObject slcClear;
  [SerializeField]
  private GameObject slcReceive;
  [SerializeField]
  private GameObject slcAlreadyReceived;
  [SerializeField]
  private GameObject herObject;
  [SerializeField]
  private UIButton button;
  private ActivityMission00418Panel.RewardViewModel rewardModel;
  private bool isClear;
  private bool isReceived;
  private BackButtonMenuBase _baseMenu;

  [DebuggerHidden]
  public IEnumerator Init(
    ActivityMission00418Panel.RewardViewModel pdm,
    BackButtonMenuBase baseMenu)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ActivityMission00418Panel.\u003CInit\u003Ec__Iterator2DE()
    {
      baseMenu = baseMenu,
      pdm = pdm,
      \u003C\u0024\u003EbaseMenu = baseMenu,
      \u003C\u0024\u003Epdm = pdm,
      \u003C\u003Ef__this = this
    };
  }

  public ActivityMission00418Panel.RewardViewModel RewardModel
  {
    get => this.rewardModel;
    set
    {
      this.rewardModel = value;
      this.isClear = value.IsClear();
      this.isReceived = value.IsReceived;
    }
  }

  public BackButtonMenuBase BaseMenu
  {
    get => this._baseMenu;
    set => this._baseMenu = value;
  }

  public void ChangeClearState()
  {
    this.isClear = true;
    this.slcClear.SetActive(true);
    this.slcReceive.SetActive(true);
  }

  [DebuggerHidden]
  private IEnumerator receiveReward()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ActivityMission00418Panel.\u003CreceiveReward\u003Ec__Iterator2DF()
    {
      \u003C\u003Ef__this = this
    };
  }

  public class ActivityReward
  {
    private int reward_type;
    private int reward_param;
    private string reward_name;
    private int reward_num;
    private int id;

    public ActivityReward(int id, int type, int param, int num, string name)
    {
      this.id = id;
      this.reward_type = type;
      this.reward_param = param;
      this.reward_name = name;
      this.reward_num = num;
    }

    public int Reward_type => this.reward_type;

    public int Reward_param => this.reward_param;

    public string Reward_name => this.reward_name;

    public int Reward_num => this.reward_num;

    public void addNum(int num) => this.reward_num += num;

    public bool IsCoin => this.reward_type == 10;

    public int ID => this.id;
  }

  public class ActivityCondition
  {
    private int id;
    private int condition_type;
    private int data;
    private bool isClear;

    public ActivityCondition(int id, int condition_type, int data)
    {
      this.id = id;
      this.condition_type = condition_type;
      this.data = data;
    }

    public int Id => this.id;

    public int Condition_Type => this.condition_type;

    public int Data => this.data;

    public bool IsClear
    {
      get => this.isClear;
      set => this.isClear = value;
    }
  }

  public class RewardViewModel
  {
    private int activity_id;
    private int step_id;
    private List<ActivityMission00418Panel.ActivityReward> reward;
    private string display_txt;
    private List<ActivityMission00418Panel.ActivityCondition> condition;
    private bool isReceived;
    private int uiType;

    public RewardViewModel(int activity_id, int step_id, string display_txt)
    {
      this.reward = new List<ActivityMission00418Panel.ActivityReward>();
      this.condition = new List<ActivityMission00418Panel.ActivityCondition>();
      this.activity_id = activity_id;
      this.step_id = step_id;
      this.display_txt = display_txt;
    }

    public int Activity_Id => this.activity_id;

    public int Step_Id => this.step_id;

    public string Display_Txt => this.display_txt;

    public bool IsReceived
    {
      get => this.isReceived;
      set => this.isReceived = value;
    }

    public int UiType
    {
      get => this.uiType;
      set => this.uiType = value;
    }

    [DebuggerHidden]
    public IEnumerator LoadThumb(GameObject go, GameObject parentGo)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new ActivityMission00418Panel.RewardViewModel.\u003CLoadThumb\u003Ec__Iterator2E0()
      {
        go = go,
        parentGo = parentGo,
        \u003C\u0024\u003Ego = go,
        \u003C\u0024\u003EparentGo = parentGo,
        \u003C\u003Ef__this = this
      };
    }

    public void addReward(int id, int type, int param, int num, string name)
    {
      this.reward.Add(new ActivityMission00418Panel.ActivityReward(id, type, param, num, name));
    }

    public bool IsClear()
    {
      foreach (ActivityMission00418Panel.ActivityCondition activityCondition in this.condition)
      {
        if (!activityCondition.IsClear)
          return false;
      }
      return true;
    }

    public List<ActivityMission00418Panel.ActivityReward> Reward => this.reward;

    public void addCondition(int id, int type, int data)
    {
      this.condition.Add(new ActivityMission00418Panel.ActivityCondition(id, type, data));
    }

    public List<ActivityMission00418Panel.ActivityCondition> Condition => this.condition;
  }
}
