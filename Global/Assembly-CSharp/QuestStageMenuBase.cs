// Decompiled with JetBrains decompiler
// Type: QuestStageMenuBase
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
public class QuestStageMenuBase : BackButtonMenuBase
{
  [SerializeField]
  private Quest0022MissionComplete complete;
  [SerializeField]
  protected UIButton btnBack;
  [SerializeField]
  private GameObject MissionAchievement;
  [SerializeField]
  private GameObject[] MissionAchievementStar;
  [SerializeField]
  private GameObject ButtonMission;
  [SerializeField]
  private GameObject ButtonMaterial;
  [SerializeField]
  private UIWidget Character;
  [SerializeField]
  private NGxMaskSpriteWithScale SubBG;
  [SerializeField]
  private bool MissionActiveFlag;
  [SerializeField]
  private bool MaterialActiveFlag;
  [SerializeField]
  protected int PassData;
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  protected GameObject Container;
  [HideInInspector]
  public bool ButtonMove;
  [HideInInspector]
  public bool SceneStart;
  [HideInInspector]
  protected bool isFirstTime;
  private GameObject missionWindow;
  private GameObject materialWindow;
  private GameObject EntryInfo;
  protected List<QuestConverterData> StageDataS;
  protected QuestStageEntryInfo EntryInfoScript;
  protected bool hardmode;
  public NGHorizontalScrollParts indicator;
  public Quest0022DetailDisplay container;
  public UIScrollView ScrollView;
  public List<GameObject> hscrollButtons;
  public Transform Middle;
  public Transform dirMission;
  public UIGrid grid;
  public GameObject nowCenterObj;
  public int initCenter;
  public SpringPanel.OnFinished onFinished;
  public List<TweenAlpha> startAllalphatween;
  public List<TweenPosition> startAllpostween;

  protected void UpdateButton()
  {
    this.HscrollButtonsAction();
    if (!this.ScrollView.isDragging && !this.ButtonMove)
      return;
    this.StartCoroutine(this.isDragTweenStart(true));
  }

  public void HscrollButtonsAction()
  {
    foreach (GameObject hscrollButton in this.hscrollButtons)
    {
      this.HscrollButtonTween(hscrollButton);
      this.HscrollButtonCenterChange(hscrollButton);
    }
  }

  private void HscrollButtonTween(GameObject targetButton)
  {
    if (this.ScrollView.isDragging || this.ButtonMove || Object.op_Inequality((Object) targetButton, (Object) this.nowCenterObj))
    {
      Quest0022Hscroll component = targetButton.GetComponent<Quest0022Hscroll>();
      if ((double) Mathf.Abs(((Component) this.ScrollView).transform.localPosition.x + component.defaultPosition()) < (double) component.spaceValue())
        component.ChangeToneConditionJudge(Mathf.Abs(((Component) this.ScrollView).transform.localPosition.x) - Mathf.Abs(component.defaultPosition()));
      else
        component.ChangeToneConditionJudge(Mathf.Abs(((Component) this.ScrollView).transform.localPosition.x + component.defaultPosition()));
    }
    else
      this.CenterAnimation();
  }

  private void HscrollButtonCenterChange(GameObject targetButton)
  {
    if (this.isFirstTime || Object.op_Equality((Object) this.nowCenterObj, (Object) ((Component) ((Component) this.grid).transform).GetComponent<UICenterOnChild>().centeredObject) || !Object.op_Equality((Object) targetButton, (Object) ((Component) ((Component) this.grid).transform).GetComponent<UICenterOnChild>().centeredObject))
      return;
    this.CenterObjectAction(targetButton);
  }

  public List<QuestConverterData> Convert(PlayerStoryQuestS[] s)
  {
    List<QuestConverterData> questConverterDataList = new List<QuestConverterData>();
    foreach (PlayerStoryQuestS story in s)
      questConverterDataList.Add(new QuestConverterData(story));
    return questConverterDataList;
  }

  public List<QuestConverterData> Convert(PlayerExtraQuestS[] e, bool? isOpen)
  {
    List<QuestConverterData> questConverterDataList = new List<QuestConverterData>();
    foreach (PlayerExtraQuestS extra in e)
    {
      QuestConverterData questConverterData = new QuestConverterData(extra);
      if (isOpen.HasValue)
        questConverterData.canPlay = isOpen.Value && questConverterData.canPlay;
      questConverterDataList.Add(questConverterData);
    }
    return questConverterDataList;
  }

  [DebuggerHidden]
  public IEnumerator InitStoryQuest(PlayerStoryQuestS[] StoryDataS, int L, int M, bool hard)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new QuestStageMenuBase.\u003CInitStoryQuest\u003Ec__Iterator1D8()
    {
      StoryDataS = StoryDataS,
      L = L,
      M = M,
      hard = hard,
      \u003C\u0024\u003EStoryDataS = StoryDataS,
      \u003C\u0024\u003EL = L,
      \u003C\u0024\u003EM = M,
      \u003C\u0024\u003Ehard = hard,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator InitExtraQuest(PlayerExtraQuestS[] ExtraDataS, int L, int M, bool? isOpen = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new QuestStageMenuBase.\u003CInitExtraQuest\u003Ec__Iterator1D9()
    {
      ExtraDataS = ExtraDataS,
      isOpen = isOpen,
      L = L,
      M = M,
      \u003C\u0024\u003EExtraDataS = ExtraDataS,
      \u003C\u0024\u003EisOpen = isOpen,
      \u003C\u0024\u003EL = L,
      \u003C\u0024\u003EM = M,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Init(List<QuestConverterData> StageDataS, int L, int M, bool hard)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new QuestStageMenuBase.\u003CInit\u003Ec__Iterator1DA()
    {
      StageDataS = StageDataS,
      L = L,
      M = M,
      hard = hard,
      \u003C\u0024\u003EStageDataS = StageDataS,
      \u003C\u0024\u003EL = L,
      \u003C\u0024\u003EM = M,
      \u003C\u0024\u003Ehard = hard,
      \u003C\u003Ef__this = this
    };
  }

  public void InitVal(List<QuestConverterData> qclistS, int L, int M, bool hard)
  {
    this.hardmode = hard;
    this.ButtonMove = false;
    this.PassData = L;
    this.initCenter = qclistS.Count - 1 >= 0 ? qclistS.Count - 1 : 0;
    this.MissionActiveFlag = false;
    this.MaterialActiveFlag = false;
    QuestStoryMissionReward storyMissionReward = QuestStoryMissionReward.Get(M);
    if (Object.op_Inequality((Object) this.MissionAchievement, (Object) null))
      this.MissionAchievement.SetActive(storyMissionReward != null);
    this.TxtTitle.SetTextLocalize(qclistS[0].title_M);
    this.hscrollButtons = new List<GameObject>();
    this.missionWindow = (GameObject) null;
    this.materialWindow = (GameObject) null;
  }

  [DebuggerHidden]
  public IEnumerator UnitCreate()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new QuestStageMenuBase.\u003CUnitCreate\u003Ec__Iterator1DB()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator subBackGroundCrate(QuestConverterData quest)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new QuestStageMenuBase.\u003CsubBackGroundCrate\u003Ec__Iterator1DC()
    {
      quest = quest,
      \u003C\u0024\u003Equest = quest,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator MissionWindowCreate(bool eventquest)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new QuestStageMenuBase.\u003CMissionWindowCreate\u003Ec__Iterator1DD()
    {
      eventquest = eventquest,
      \u003C\u0024\u003Eeventquest = eventquest,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator MaterialWindowCreate()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new QuestStageMenuBase.\u003CMaterialWindowCreate\u003Ec__Iterator1DE()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator InitHscroll()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new QuestStageMenuBase.\u003CInitHscroll\u003Ec__Iterator1DF()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void setMissionData()
  {
    bool flag = this.StageDataS[0].type == CommonQuestType.Extra;
    if (!flag)
    {
      this.setMissionData(MasterData.QuestStoryMissionList, ((IEnumerable<PlayerMissionHistory>) SMManager.Get<PlayerMissionHistory[]>()).Where<PlayerMissionHistory>((Func<PlayerMissionHistory, bool>) (x => x.story_category == 1)).ToArray<PlayerMissionHistory>());
    }
    else
    {
      if (!flag)
        return;
      this.setMissionData(MasterData.QuestExtraMissionList, ((IEnumerable<PlayerMissionHistory>) SMManager.Get<PlayerMissionHistory[]>()).Where<PlayerMissionHistory>((Func<PlayerMissionHistory, bool>) (x => x.story_category == 3)).ToArray<PlayerMissionHistory>());
    }
  }

  public void setMissionData(QuestStoryMission[] missionData, PlayerMissionHistory[] hists)
  {
    for (int i = 0; i < this.StageDataS.Count; ++i)
    {
      Quest0022Hscroll component = this.hscrollButtons[i].GetComponent<Quest0022Hscroll>();
      component.missionList = new List<bool>();
      List<bool> missionList = component.missionList;
      QuestStoryMission[] array = ((IEnumerable<QuestStoryMission>) missionData).Where<QuestStoryMission>((Func<QuestStoryMission, bool>) (x => this.StageDataS[i].id_S == x.quest_s_QuestStoryS)).ToArray<QuestStoryMission>();
      int length = array.Length;
      int num = 0;
      if (length > 0)
      {
        for (int index = 0; index < array.Length; ++index)
        {
          missionList.Add(((IEnumerable<PlayerMissionHistory>) hists).Select<PlayerMissionHistory, int>((Func<PlayerMissionHistory, int>) (y => y.mission_id)).Contains<int>(array[index].ID));
          if (missionList[index])
            ++num;
        }
      }
      component.MissionNum = length;
      component.MissionClearNum = num;
    }
  }

  public void setMissionData(QuestExtraMission[] missionData, PlayerMissionHistory[] hists)
  {
    for (int i = 0; i < this.StageDataS.Count; ++i)
    {
      Quest0022Hscroll component = this.hscrollButtons[i].GetComponent<Quest0022Hscroll>();
      component.missionList = new List<bool>();
      List<bool> missionList = component.missionList;
      QuestExtraMission[] array = ((IEnumerable<QuestExtraMission>) missionData).Where<QuestExtraMission>((Func<QuestExtraMission, bool>) (x => this.StageDataS[i].id_S == x.quest_s_QuestExtraS)).ToArray<QuestExtraMission>();
      int length = array.Length;
      int num = 0;
      if (length > 0)
      {
        for (int index = 0; index < array.Length; ++index)
        {
          missionList.Add(((IEnumerable<PlayerMissionHistory>) hists).Select<PlayerMissionHistory, int>((Func<PlayerMissionHistory, int>) (y => y.mission_id)).Contains<int>(array[index].ID));
          if (missionList[index])
            ++num;
        }
      }
      component.MissionNum = length;
      component.MissionClearNum = num;
    }
  }

  public void CenterObjectAction(GameObject targetButton)
  {
    Quest0022Hscroll component = targetButton.GetComponent<Quest0022Hscroll>();
    this.hscrollButtons.ForEach((Action<GameObject>) (x => x.GetComponent<Quest0022Hscroll>().NotTouch(true)));
    component.NotTouch(false);
    if (Object.op_Inequality((Object) targetButton, (Object) this.nowCenterObj))
    {
      this.nowCenterObj = targetButton;
      bool flag = this.nowCenterObj.GetComponent<Quest0022Hscroll>().MissionNum > 0;
      this.ButtonMission.SetActive(flag);
      if (Object.op_Inequality((Object) this.missionWindow, (Object) null))
        this.missionWindow.SetActive(flag);
      ((IEnumerable<GameObject>) this.MissionAchievementStar).ForEach<GameObject>((Action<GameObject>) (x => x.SetActive(false)));
      if (flag)
      {
        List<bool> missionList = this.nowCenterObj.GetComponent<Quest0022Hscroll>().missionList;
        if (missionList.Count <= 0)
          return;
        this.MissionAchievementStar[missionList.Count - 1].SetActive(true);
        this.MissionAchievementStar[missionList.Count - 1].GetComponent<Quest0022MissionStar>().setStar(missionList);
      }
      QuestScoreCampaignProgress[] source = SMManager.Get<QuestScoreCampaignProgress[]>();
      foreach (QuestConverterData questConverterData in this.StageDataS)
      {
        QuestConverterData stageDataS = questConverterData;
        QuestScoreCampaignProgress qscp = (QuestScoreCampaignProgress) null;
        if (source != null && source.Length > 0)
          qscp = ((IEnumerable<QuestScoreCampaignProgress>) source).FirstOrDefault<QuestScoreCampaignProgress>((Func<QuestScoreCampaignProgress, bool>) (x => x.quest_extra_l == stageDataS.id_L));
        if (component.id() == stageDataS.id_S)
          this.container.InitDetailDisplay(stageDataS, component.stageNumber(), qscp);
      }
      if (!flag)
        this.ButtonMaterial.SetActive(((IEnumerable<QuestCommonDrop>) MasterData.QuestCommonDropList).Where<QuestCommonDrop>((Func<QuestCommonDrop, bool>) (x => x.quest_s_id == this.nowCenterObj.GetComponent<Quest0022Hscroll>().id())).ToList<QuestCommonDrop>().Count > 0);
      else
        this.ButtonMaterial.SetActive(false);
    }
    this.SetTextLimitation(component.id());
  }

  protected virtual void SetTextLimitation(int s_id) => this.EntryInfoScript.IsDisplay = false;

  public void startMaterialSet() => this.StartCoroutine(this.ibtnMaterial());

  [DebuggerHidden]
  private IEnumerator ibtnMaterial()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new QuestStageMenuBase.\u003CibtnMaterial\u003Ec__Iterator1E0()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void startMissionSet() => this.StartCoroutine(this.ibtnMission());

  [DebuggerHidden]
  private IEnumerator ibtnMission()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new QuestStageMenuBase.\u003CibtnMission\u003Ec__Iterator1E1()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void ibtRankingEventReward()
  {
    QuestScoreCampaignProgress campaignProgress = ((IEnumerable<QuestScoreCampaignProgress>) SMManager.Get<QuestScoreCampaignProgress[]>()).FirstOrDefault<QuestScoreCampaignProgress>((Func<QuestScoreCampaignProgress, bool>) (x => x.quest_extra_l == this.StageDataS[0].id_L));
    QuestScoreCampaignProgressScore_achivement_rewards achivement_reward = ((IEnumerable<QuestScoreCampaignProgressScore_achivement_rewards>) campaignProgress.score_achivement_rewards).FirstOrDefault<QuestScoreCampaignProgressScore_achivement_rewards>((Func<QuestScoreCampaignProgressScore_achivement_rewards, bool>) (x => x.quest_extra_m == this.StageDataS[0].id_M));
    QuestExtraM questExtraM;
    if (achivement_reward == null || !MasterData.QuestExtraM.TryGetValue(achivement_reward.quest_extra_m, out questExtraM))
      return;
    int questMscoreFromMid = campaignProgress.GetQuestMScoreFromMID(questExtraM.ID);
    Quest002272Scene.ChangeScene(true, achivement_reward, campaignProgress.player.score_achivement_reward_cleared, questExtraM.name, questMscoreFromMid);
  }

  [DebuggerHidden]
  public IEnumerator isDragTweenStart(bool flag)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new QuestStageMenuBase.\u003CisDragTweenStart\u003Ec__Iterator1E2()
    {
      flag = flag,
      \u003C\u0024\u003Eflag = flag,
      \u003C\u003Ef__this = this
    };
  }

  public void CenterAnimation()
  {
    GameObject target = this.nowCenterObj;
    target.GetComponent<Quest0022Hscroll>().centerAnimation(true);
    this.hscrollButtons.ForEach((Action<GameObject>) (x =>
    {
      if (!Object.op_Inequality((Object) x, (Object) target))
        return;
      x.GetComponent<Quest0022Hscroll>().centerAnimation(false);
    }));
  }

  public void tweenSettingDefault()
  {
    this.startAllpostween.ForEach((Action<TweenPosition>) (x => x.tweenGroup = Math.Abs(x.tweenGroup)));
    this.startAllalphatween.ForEach((Action<TweenAlpha>) (x => x.tweenGroup = Math.Abs(x.tweenGroup)));
  }

  public void tweenSettingNoAnim()
  {
    this.startAllpostween.ForEach((Action<TweenPosition>) (x =>
    {
      if (x.tweenGroup != 11 && x.tweenGroup != 12)
        return;
      x.tweenGroup = -Math.Abs(x.tweenGroup);
      ((Component) x).gameObject.transform.localPosition = x.to;
    }));
    this.startAllalphatween.ForEach((Action<TweenAlpha>) (x =>
    {
      if (x.tweenGroup != 11 && x.tweenGroup != 12)
        return;
      x.tweenGroup = -Math.Abs(x.tweenGroup);
      ((Component) x).GetComponent<UIWidget>().alpha = x.to;
    }));
  }

  public virtual void IbtnBack() => this.backScene();

  public override void onBackButton() => this.IbtnBack();

  public virtual void onEndScene()
  {
    if (Object.op_Inequality((Object) this.missionWindow, (Object) null))
      Object.Destroy((Object) this.missionWindow);
    if (!Object.op_Inequality((Object) this.materialWindow, (Object) null))
      return;
    Object.Destroy((Object) this.materialWindow);
  }
}
