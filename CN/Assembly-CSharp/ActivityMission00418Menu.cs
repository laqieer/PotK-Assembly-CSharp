// Decompiled with JetBrains decompiler
// Type: ActivityMission00418Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class ActivityMission00418Menu : BackButtonMenuBase
{
  [SerializeField]
  private UILabel titleLabel;
  [SerializeField]
  public UIGrid grid;
  [SerializeField]
  public UIScrollView scrollview;
  [SerializeField]
  public GameObject btnChangeR;
  [SerializeField]
  public GameObject btnChangeL;
  [SerializeField]
  public GameObject btnDetail;
  [SerializeField]
  public GameObject btnRecharge;
  [SerializeField]
  public GameObject btnBuy;
  [SerializeField]
  public GameObject btnBuyMonthCard;
  [SerializeField]
  public GameObject fundEffective;
  [SerializeField]
  private UILabel leftDayLabel;
  [SerializeField]
  public UISprite header_banner;
  [SerializeField]
  public GameObject scrollContainer;
  [SerializeField]
  public GameObject bgRoot;
  [SerializeField]
  public GameObject isHidGameObject;
  [SerializeField]
  public UIGrid bannerGrid;
  [SerializeField]
  public UIScrollView bannerScrollview;
  private Vector3 localBPosition;
  private Vector3 localSPosition;
  private Vector3 localBtnPosition;
  private Vector3 localBuyBtnPosition;
  private Vector3 localBuyMonthCardBtnPosition;
  private int localHeight;
  private GameObject scrollPrefab;
  private GameObject scrollPrefabNormal;
  private GameObject scrollPrefabHer;
  private GameObject scrollPrefabButton;
  private int HerId = 1004;
  private bool effective;
  private int fundNeed = 100;
  private BonusCount[] bonus;
  private ActivityTypeTable typeTable;
  private string picValueUrl = ".png__GUI__004-18_sozai__004-18_sozai_prefab";
  private string pic_value_2 = "_header";
  private string btnNormalSprite = "idle";
  private string btnSelectSprite = "pressed";
  private string btnRowLNormalSprite = "Arrow_L";
  private string btnRowLSelectSprite = "slc_arrow_left";
  private string btnRowRNormalSprite = "Arrow_R";
  private string btnRowRSelectSprite = "slc_arrow_right";
  private int activityCount;
  private int state;
  private int row = 3;
  private ActivityTotalTable[] activityList;
  private Dictionary<string, ActivityMission00418Panel.RewardViewModel> restructuringData = new Dictionary<string, ActivityMission00418Panel.RewardViewModel>();
  private Dictionary<string, ActivityBannerButton> buttonList = new Dictionary<string, ActivityBannerButton>();

  public int State
  {
    get => this.state;
    set
    {
      if (value == this.state)
        return;
      this.state = value;
      this.StartCoroutine(this.changeView());
    }
  }

  public override void onBackButton() => this.IbtnBack();

  public void detailed()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.detailedPopup());
  }

  [DebuggerHidden]
  private IEnumerator detailedPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ActivityMission00418Menu.\u003CdetailedPopup\u003Ec__Iterator299()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void purchase()
  {
    if (this.IsPushAndSet())
      return;
    if (this.typeTable.data > 0)
      this.fundNeed = this.typeTable.data;
    PopupManager.ShowYesNo(Consts.GetInstance().fund_title, string.Format(Consts.GetInstance().fund_content, (object) this.fundNeed), (System.Action) (() => { }), new System.Action(this.YesBtn), "showYesNo");
  }

  public void YesBtn()
  {
    if (SMManager.Get<Player>().CheckKiseki(this.fundNeed))
      this.StartCoroutine(this.IbtnBuyBack());
    else
      this.StartCoroutine(this.popup99931());
  }

  [DebuggerHidden]
  private IEnumerator popup99931()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    ActivityMission00418Menu.\u003Cpopup99931\u003Ec__Iterator29A popup99931CIterator29A = new ActivityMission00418Menu.\u003Cpopup99931\u003Ec__Iterator29A();
    return (IEnumerator) popup99931CIterator29A;
  }

  [DebuggerHidden]
  private IEnumerator IbtnBuyBack()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ActivityMission00418Menu.\u003CIbtnBuyBack\u003Ec__Iterator29B()
    {
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnBuyKiseki()
  {
    if (this.IsPushAndSet())
      return;
    this.GoToShop();
  }

  public void GoToShop()
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("shop007_1", true);
    this.StartCoroutine(PopupUtility.BuyKiseki());
  }

  [DebuggerHidden]
  private IEnumerator addCondition()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ActivityMission00418Menu.\u003CaddCondition\u003Ec__Iterator29C()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator setBackground()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ActivityMission00418Menu.\u003CsetBackground\u003Ec__Iterator29D()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Init()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ActivityMission00418Menu.\u003CInit\u003Ec__Iterator29E()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator changeView()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ActivityMission00418Menu.\u003CchangeView\u003Ec__Iterator29F()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void SetAnchor(UIRect.AnchorPoint ap, float relative, int absolute)
  {
    ap.absolute = absolute;
    ap.relative = relative;
  }

  private void changeRL()
  {
    foreach (KeyValuePair<string, ActivityBannerButton> button in this.buttonList)
    {
      string path = int.Parse(button.Key) != this.activityList[this.state].ID ? this.btnNormalSprite + this.picValueUrl : this.btnSelectSprite + this.picValueUrl;
      button.Value.changeSprite(path);
    }
  }

  [DebuggerHidden]
  private IEnumerator changePanel()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ActivityMission00418Menu.\u003CchangePanel\u003Ec__Iterator2A0()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void delectRestructuringData(string key)
  {
    foreach (KeyValuePair<string, ActivityMission00418Panel.RewardViewModel> keyValuePair in this.restructuringData)
    {
      if (keyValuePair.Value.Step_Id.ToString() == key)
        keyValuePair.Value.IsReceived = true;
    }
  }

  public void SortingData(MasterDataTable.ActivityReward activityData)
  {
    if (this.restructuringData.ContainsKey(activityData.step_id.ToString()))
    {
      this.restructuringData[activityData.step_id.ToString()].addReward(activityData.ID, activityData.reward_type_id_CommonRewardType, activityData.reward_id, activityData.reward_quantity, activityData.reward_title);
    }
    else
    {
      ActivityMission00418Panel.RewardViewModel rewardViewModel = new ActivityMission00418Panel.RewardViewModel(activityData.activity_id, activityData.step_id, activityData.activity_subtitle);
      rewardViewModel.addReward(activityData.ID, activityData.reward_type_id_CommonRewardType, activityData.reward_id, activityData.reward_quantity, activityData.reward_title);
      this.restructuringData.Add(activityData.step_id.ToString(), rewardViewModel);
    }
  }

  public void IbtnBack()
  {
    Singleton<NGSceneManager>.GetInstance().clearStack();
    Singleton<NGSceneManager>.GetInstance().destroyCurrentScene();
    Singleton<NGSceneManager>.GetInstance().changeScene("mypage");
  }

  [DebuggerHidden]
  private IEnumerator createPanel(GameObject prefab, ActivityMission00418Panel.RewardViewModel pdm)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ActivityMission00418Menu.\u003CcreatePanel\u003Ec__Iterator2A1()
    {
      prefab = prefab,
      pdm = pdm,
      \u003C\u0024\u003Eprefab = prefab,
      \u003C\u0024\u003Epdm = pdm,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator createBanner(ActivityTotalTable table, int listState)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ActivityMission00418Menu.\u003CcreateBanner\u003Ec__Iterator2A2()
    {
      table = table,
      listState = listState,
      \u003C\u0024\u003Etable = table,
      \u003C\u0024\u003ElistState = listState,
      \u003C\u003Ef__this = this
    };
  }
}
