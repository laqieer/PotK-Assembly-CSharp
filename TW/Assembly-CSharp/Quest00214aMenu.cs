// Decompiled with JetBrains decompiler
// Type: Quest00214aMenu
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
public class Quest00214aMenu : BackButtonMenuBase
{
  private const float AnimationTime = 0.3f;
  [SerializeField]
  protected UILabel TxtTitle;
  public NGHorizontalScrollParts indicator;
  public Quest00214DetailDisplay container;
  public Quest00214Menu menu;
  public UIScrollView ScrollView;
  public Transform Middle;
  public UIGrid grid;
  public GameObject mask;
  public GameObject release;
  public SpringPanel.OnFinished onFinished;
  public Texture2D maskTexture;
  private bool releaseConditionActiveFlag;
  private bool ButtonMove;
  private int QuestQuantity;
  private GameObject CenterObj;
  private List<PlayerQuestSConverter> QuestList = new List<PlayerQuestSConverter>();
  private List<Tuple<QuestSConverter, PlayerQuestSConverter>> tblEpisodeQuest_ = new List<Tuple<QuestSConverter, PlayerQuestSConverter>>();
  private List<QuestDisplayConditionConverter>[] tblDisplayConditions_ = new List<QuestDisplayConditionConverter>[0];
  private List<GameObject> StageObjects;
  private int startTweenCount;
  private Quest00214aMenu.Mode mode;
  [HideInInspector]
  public bool SceneStart;
  [HideInInspector]
  public List<UITweener> StartTweeners;
  [HideInInspector]
  public List<UITweener> EndTweeners;
  [HideInInspector]
  public List<UITweener> BothTweeners;
  private GameObject compareCenterObj;
  [SerializeField]
  private GameObject ButtonMission;
  [SerializeField]
  private GameObject Character;
  [SerializeField]
  private GameObject CharacterCombi;
  [SerializeField]
  private GameObject CharacterCombiTarget;
  [SerializeField]
  private GameObject CharacterTrioLeft;
  [SerializeField]
  private GameObject CharacterTrioCenter;
  [SerializeField]
  private GameObject CharacterTrioRight;
  [SerializeField]
  private NGxMaskSpriteWithScale SubBG;
  private GameObject unitIconPrefab;
  private GameObject releaseConditionPrefab;
  private UICenterOnChild ctrlCenter_;
  private QuestDetailManager detailManager_;
  private bool isChangedQuestDetail_;
  private bool isResetToneCondition_;

  private UICenterOnChild ctrlCenter
  {
    get
    {
      if (Object.op_Equality((Object) this.ctrlCenter_, (Object) null))
        this.ctrlCenter_ = ((Component) this.grid).GetComponent<UICenterOnChild>();
      return this.ctrlCenter_;
    }
  }

  private QuestDetailManager detailManager
  {
    get
    {
      if (this.detailManager_ == null)
        this.detailManager_ = new QuestDetailManager();
      return this.detailManager_;
    }
  }

  public virtual void IbtnBack() => Debug.Log((object) "click default event IbtnBack");

  protected override void Update()
  {
    if (!((Component) this).gameObject.activeSelf || !this.SceneStart || this.StageObjects == null || this.isChangedQuestDetail_)
      return;
    base.Update();
    bool flag1 = !this.ScrollView.isDragging && !this.ButtonMove;
    for (int index = 0; index < this.StageObjects.Count; ++index)
    {
      GameObject stageObject = this.StageObjects[index];
      Quest00214Hscroll component = stageObject.GetComponent<Quest00214Hscroll>();
      PlayerQuestSConverter playerQuestSconverter = this.tblEpisodeQuest_[index].Item2;
      bool flag2 = playerQuestSconverter != null && !playerQuestSconverter.is_clear;
      if (!flag1 || !flag2)
      {
        if ((double) Mathf.Abs(((Component) this.ScrollView).transform.localPosition.x + component.defaultPosition()) < (double) component.spaceValue())
          component.ChangeToneConditionJudge(Mathf.Abs(((Component) this.ScrollView).transform.localPosition.x) - Mathf.Abs(component.defaultPosition()));
        else
          component.ChangeToneConditionJudge(Mathf.Abs(((Component) this.ScrollView).transform.localPosition.x + component.defaultPosition()));
        if (flag2)
        {
          component.centerAnimation(false);
          component.NotTouch(true);
        }
      }
      else if (Object.op_Equality((Object) stageObject, (Object) this.ctrlCenter.centeredObject) && flag1)
      {
        component.centerAnimation(true);
        component.NotTouch(false);
      }
      else if (this.isResetToneCondition_)
      {
        if ((double) Mathf.Abs(((Component) this.ScrollView).transform.localPosition.x + component.defaultPosition()) < (double) component.spaceValue())
          component.ChangeToneConditionJudge(Mathf.Abs(((Component) this.ScrollView).transform.localPosition.x) - Mathf.Abs(component.defaultPosition()));
        else
          component.ChangeToneConditionJudge(Mathf.Abs(((Component) this.ScrollView).transform.localPosition.x + component.defaultPosition()));
      }
      if (Object.op_Equality((Object) stageObject, (Object) this.ctrlCenter.centeredObject) && Object.op_Inequality((Object) stageObject, (Object) this.compareCenterObj))
      {
        this.compareCenterObj = stageObject;
        QuestSConverter StageData = this.tblEpisodeQuest_[index].Item1;
        this.container.InitDetailDisplay(StageData, component.stageNumber());
        if (this.tblDisplayConditions_[index] == null)
          this.tblDisplayConditions_[index] = this.getDisplayConditionList(StageData.ID);
        this.StartCoroutine(this.InitReleases(this.unitIconPrefab, this.releaseConditionPrefab, this.tblDisplayConditions_[index]));
      }
    }
    this.isResetToneCondition_ = false;
    if (!this.ScrollView.isDragging && !this.ButtonMove)
      return;
    this.TweenStart(true);
  }

  public override void onBackButton()
  {
    if (this.startTweenCount > 0)
      return;
    this.Ending();
  }

  private List<QuestDisplayConditionConverter> getDisplayConditionList(int questId)
  {
    IEnumerable<QuestDisplayConditionConverter> source = this.mode != Quest00214aMenu.Mode.Character ? (this.mode != Quest00214aMenu.Mode.Harmony ? (IEnumerable<QuestDisplayConditionConverter>) null : ((IEnumerable<QuestHarmonyDisplayCondition>) MasterData.QuestHarmonyDisplayConditionList).Where<QuestHarmonyDisplayCondition>((Func<QuestHarmonyDisplayCondition, bool>) (q => q.quest_s_QuestHarmonyS == questId)).Select<QuestHarmonyDisplayCondition, QuestDisplayConditionConverter>((Func<QuestHarmonyDisplayCondition, QuestDisplayConditionConverter>) (q => new QuestDisplayConditionConverter(q)))) : ((IEnumerable<QuestCharacterDisplayCondition>) MasterData.QuestCharacterDisplayConditionList).Where<QuestCharacterDisplayCondition>((Func<QuestCharacterDisplayCondition, bool>) (q => q.quest_s_QuestCharacterS == questId)).Select<QuestCharacterDisplayCondition, QuestDisplayConditionConverter>((Func<QuestCharacterDisplayCondition, QuestDisplayConditionConverter>) (q => new QuestDisplayConditionConverter(q)));
    return source != null ? source.OrderBy<QuestDisplayConditionConverter, int>((Func<QuestDisplayConditionConverter, int>) (x => x.priority)).ToList<QuestDisplayConditionConverter>() : new List<QuestDisplayConditionConverter>();
  }

  private void CommonInit(GameObject iconPrefab, GameObject conditionPrefab)
  {
    this.indicator.SeEnable = false;
    ((Component) this).GetComponent<UIWidget>().alpha = 0.0f;
    this.unitIconPrefab = iconPrefab;
    this.releaseConditionPrefab = conditionPrefab;
  }

  [DebuggerHidden]
  private IEnumerator LoadCharacterSprite(int id, GameObject locationObject)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00214aMenu.\u003CLoadCharacterSprite\u003Ec__Iterator1F6()
    {
      locationObject = locationObject,
      id = id,
      \u003C\u0024\u003ElocationObject = locationObject,
      \u003C\u0024\u003Eid = id
    };
  }

  [DebuggerHidden]
  private IEnumerator LoadCharacterStorySprite(int id, GameObject locationObject)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00214aMenu.\u003CLoadCharacterStorySprite\u003Ec__Iterator1F7()
    {
      locationObject = locationObject,
      id = id,
      \u003C\u0024\u003ElocationObject = locationObject,
      \u003C\u0024\u003Eid = id,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator LoadMask()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00214aMenu.\u003CLoadMask\u003Ec__Iterator1F8()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void SetTween()
  {
    this.StartTweeners = new List<UITweener>();
    this.EndTweeners = new List<UITweener>();
    this.BothTweeners = new List<UITweener>();
    UITweener[] componentsInChildren = ((Component) this).GetComponentsInChildren<UITweener>();
    this.startTweenCount = 0;
    foreach (UITweener uiTweener in componentsInChildren)
    {
      if (uiTweener.tweenGroup == 22)
      {
        ++this.startTweenCount;
        this.StartTweeners.Add(uiTweener);
      }
      else if (uiTweener.tweenGroup == 33)
        this.EndTweeners.Add(uiTweener);
      else if (uiTweener.tweenGroup == 44)
        this.BothTweeners.Add(uiTweener);
    }
  }

  [DebuggerHidden]
  private IEnumerator SetBg(QuestSConverter questData, int index)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00214aMenu.\u003CSetBg\u003Ec__Iterator1F9()
    {
      questData = questData,
      index = index,
      \u003C\u0024\u003EquestData = questData,
      \u003C\u0024\u003Eindex = index,
      \u003C\u003Ef__this = this
    };
  }

  private void SetGrayQuestIcon(int questLength, GameObject character)
  {
    this.ctrlCenter.onFinished = (SpringPanel.OnFinished) (() => this.TweenStart(false));
    if (questLength != 0)
      return;
    ((Component) character.transform.GetChild(0)).GetComponent<UI2DSprite>().color = Color.Lerp(Color.white, Color.black, 0.5f);
  }

  [DebuggerHidden]
  public IEnumerator Init(
    int id,
    WebAPI.Response.QuestProgressCharacter apiResponse,
    GameObject iconPrefab,
    GameObject conditionPrefab)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00214aMenu.\u003CInit\u003Ec__Iterator1FA()
    {
      iconPrefab = iconPrefab,
      conditionPrefab = conditionPrefab,
      id = id,
      apiResponse = apiResponse,
      \u003C\u0024\u003EiconPrefab = iconPrefab,
      \u003C\u0024\u003EconditionPrefab = conditionPrefab,
      \u003C\u0024\u003Eid = id,
      \u003C\u0024\u003EapiResponse = apiResponse,
      \u003C\u003Ef__this = this
    };
  }

  public void InitTweenFinish() => this.indicator.SeEnable = true;

  [DebuggerHidden]
  public IEnumerator Init(
    int unitId,
    int[] targetUnitIds,
    WebAPI.Response.QuestProgressCharacter apiResponse,
    GameObject iconPrefab,
    GameObject conditionPrefab,
    bool isTrio)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00214aMenu.\u003CInit\u003Ec__Iterator1FB()
    {
      iconPrefab = iconPrefab,
      conditionPrefab = conditionPrefab,
      unitId = unitId,
      apiResponse = apiResponse,
      isTrio = isTrio,
      targetUnitIds = targetUnitIds,
      \u003C\u0024\u003EiconPrefab = iconPrefab,
      \u003C\u0024\u003EconditionPrefab = conditionPrefab,
      \u003C\u0024\u003EunitId = unitId,
      \u003C\u0024\u003EapiResponse = apiResponse,
      \u003C\u0024\u003EisTrio = isTrio,
      \u003C\u0024\u003EtargetUnitIds = targetUnitIds,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator InitReleases(
    GameObject iconPrefab,
    GameObject conditionPrefab,
    List<QuestDisplayConditionConverter> list)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00214aMenu.\u003CInitReleases\u003Ec__Iterator1FC()
    {
      list = list,
      iconPrefab = iconPrefab,
      conditionPrefab = conditionPrefab,
      \u003C\u0024\u003Elist = list,
      \u003C\u0024\u003EiconPrefab = iconPrefab,
      \u003C\u0024\u003EconditionPrefab = conditionPrefab,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator InitHscroll(int iCenter)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00214aMenu.\u003CInitHscroll\u003Ec__Iterator1FD()
    {
      iCenter = iCenter,
      \u003C\u0024\u003EiCenter = iCenter,
      \u003C\u003Ef__this = this
    };
  }

  private void initHscroll(
    Quest00214Hscroll hscroll,
    QuestSConverter StageData,
    PlayerQuestSConverter[] charaque,
    int num,
    float gridWidth,
    int center)
  {
    hscroll.Init(StageData, charaque, num, gridWidth, center, (EventDelegate.Callback) (() =>
    {
      if (this.IsPushAndSet())
        return;
      this.isChangedQuestDetail_ = true;
      Quest00221Scene.changeDetailScene(this.detailManager.getData(StageData.data_type != QuestSConverter.DataType.Character ? CommonQuestType.Harmony : CommonQuestType.Character, StageData.ID), true);
    }));
  }

  private void OnEnable()
  {
    if (!this.isChangedQuestDetail_)
      return;
    this.isChangedQuestDetail_ = false;
    this.ScrollView.Press(false);
  }

  public void Starting()
  {
    this.mask.SetActive(true);
    this.mask.GetComponent<TweenAlpha>().ResetToBeginning();
    this.mask.GetComponent<TweenAlpha>().PlayForward();
    ((Component) this).GetComponent<UIWidget>().alpha = 1f;
    this.StartTweeners.ForEach((Action<UITweener>) (x =>
    {
      x.SetOnFinished((EventDelegate.Callback) (() => --this.startTweenCount));
      x.ResetToBeginning();
      x.PlayForward();
    }));
    this.BothTweeners.ForEach((Action<UITweener>) (x =>
    {
      x.ResetToBeginning();
      x.PlayForward();
    }));
    this.IsPush = false;
  }

  public void Ending()
  {
    if (this.IsPushAndSet())
      return;
    this.mask.GetComponent<TweenAlpha>().ResetToBeginning();
    this.mask.GetComponent<TweenAlpha>().PlayReverse();
    this.EndTweeners.ForEach((Action<UITweener>) (x =>
    {
      x.ResetToBeginning();
      x.PlayForward();
    }));
    this.BothTweeners.ForEach((Action<UITweener>) (x =>
    {
      x.ResetToBeginning();
      x.PlayReverse();
    }));
    if (this.releaseConditionActiveFlag)
      this.ibtnReleaseCondition();
    this.menu.isSelect = false;
    this.Invoke("Disable", 0.3f);
    Singleton<PopupManager>.GetInstance().closeAll();
  }

  private void Disable()
  {
    this.mask.SetActive(false);
    ((Component) this).gameObject.SetActive(false);
    if (this.mode == Quest00214aMenu.Mode.Character)
    {
      this.menu.IconEnable = !this.menu.isSelect;
      this.menu.SetTxtTitle = Consts.GetInstance().QUEST_00214_CHARACTER_TITLE;
    }
    if (this.mode != Quest00214aMenu.Mode.Harmony)
      return;
    this.menu.CellEnable = !this.menu.isSelect;
    this.menu.SetTxtTitle = Consts.GetInstance().QUEST_00214_COMBI_TITLE;
  }

  public void ToneChangeStart() => this.SceneStart = true;

  public void changeScene(PlayerCharacterQuestS episode)
  {
    Quest00282Scene.changeScene(true, episode);
  }

  public void ibtnReleaseCondition()
  {
    this.releaseConditionActiveFlag = !this.releaseConditionActiveFlag;
    this.release.GetComponent<Quest00214ReleaseCondition>().StartTweenClick(this.releaseConditionActiveFlag);
  }

  public void TweenStart(bool flag)
  {
    if (this.ButtonMove != flag)
    {
      this.container.StartTween(flag);
      if (this.releaseConditionActiveFlag && this.release.activeSelf)
        this.release.GetComponent<Quest00214ReleaseCondition>().StartTween(flag);
    }
    this.ButtonMove = flag;
  }

  private enum Mode
  {
    Character,
    Harmony,
  }
}
