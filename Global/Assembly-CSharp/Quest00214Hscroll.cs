// Decompiled with JetBrains decompiler
// Type: Quest00214Hscroll
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Quest00214Hscroll : MonoBehaviour
{
  public GameObject LockGO;
  public GameObject UnLockGO;
  [SerializeField]
  private UILabel apCost;
  public UISprite newSprite;
  public UISprite clearSprite;
  [SerializeField]
  private Transform StageNumbersParent_UnLock;
  [SerializeField]
  private Transform StageNumbersParent_Lock;
  [SerializeField]
  private List<UILabel> tweenColorLabels;
  public UIButton StageButton_UnLock;
  [SerializeField]
  private List<UILabel> StageNumbers;
  [SerializeField]
  private GameObject StageButton_Lock;
  [SerializeField]
  private float defaultScale;
  [SerializeField]
  private float changedScale;
  [SerializeField]
  private float SpaceValue;
  [SerializeField]
  private List<UIWidget> ObjWidgets;
  public GameObject Mask;
  [SerializeField]
  private int StageNumber;
  [SerializeField]
  private int ID;
  [SerializeField]
  private int AP;
  [SerializeField]
  private UISprite StageBounas;
  private bool anim;
  private bool UnLock;

  public bool isUnLock() => this.UnLock;

  public float defaultPosition() => ((Component) this).transform.localPosition.x;

  public float spaceValue() => this.SpaceValue;

  public int id() => this.ID;

  public int stageNumber() => this.StageNumber;

  public void LockCondition()
  {
    ((Component) this.StageNumbersParent_UnLock).gameObject.SetActive(false);
    ((Component) this.StageButton_UnLock).gameObject.SetActive(false);
    ((Component) this.apCost).gameObject.SetActive(false);
    ((Component) this.newSprite).gameObject.SetActive(false);
    ((Component) this.clearSprite).gameObject.SetActive(false);
    ((Component) this.StageNumbersParent_Lock).gameObject.SetActive(true);
    this.StageButton_Lock.SetActive(true);
    this.LockGO.SetActive(true);
    this.UnLockGO.SetActive(false);
    this.UnLock = false;
  }

  public void UnLockCondition()
  {
    ((Component) this.StageNumbersParent_UnLock).gameObject.SetActive(true);
    ((Component) this.StageButton_UnLock).gameObject.SetActive(true);
    ((Component) this.apCost).gameObject.SetActive(true);
    ((Component) this.clearSprite).gameObject.SetActive(true);
    ((Component) this.StageNumbersParent_Lock).gameObject.SetActive(false);
    this.StageButton_Lock.SetActive(false);
    ((Component) this.newSprite).gameObject.SetActive(false);
    this.LockGO.SetActive(false);
    this.UnLockGO.SetActive(true);
    this.UnLock = true;
  }

  private void Awake() => this.ObjWidgets = new List<UIWidget>();

  public void onSetValue()
  {
    this.defaultScale = 1f;
    this.changedScale = 0.9f;
    this.SpaceValue = ((Component) ((Component) this).transform.parent).GetComponent<UIGrid>().cellWidth;
  }

  private void WidgetGetInit()
  {
    this.ObjWidgets.Clear();
    if (!this.UnLock)
    {
      foreach (Component component in this.StageNumbersParent_Lock)
        this.ObjWidgets.Add(component.GetComponent<UIWidget>());
      this.ObjWidgets.Add(((Component) this.StageButton_Lock.transform).GetComponent<UIWidget>());
    }
    else
    {
      foreach (Component component in this.StageNumbersParent_UnLock)
        this.ObjWidgets.Add(component.GetComponent<UIWidget>());
      this.ObjWidgets.Add(((Component) ((Component) this.StageButton_UnLock).transform).GetComponent<UIWidget>());
    }
    this.ObjWidgets.Add(((Component) ((Component) this.apCost).transform).GetComponent<UIWidget>());
    this.ObjWidgets.Add(((Component) ((Component) this.newSprite).transform).GetComponent<UIWidget>());
    this.ObjWidgets.Add(((Component) ((Component) this.clearSprite).transform).GetComponent<UIWidget>());
  }

  public void Init(
    QuestSConverter StageData,
    PlayerQuestSConverter[] charaque,
    int num,
    float gridWidth,
    int center)
  {
    this.WidgetGetInit();
    this.StageNumber = num;
    this.ID = StageData.ID;
    if (((IEnumerable<PlayerQuestSConverter>) charaque).Select<PlayerQuestSConverter, int>((Func<PlayerQuestSConverter, int>) (x => x.questS.ID)).Contains<int>(StageData.ID))
    {
      PlayerQuestSConverter stageData = ((IEnumerable<PlayerQuestSConverter>) charaque).Where<PlayerQuestSConverter>((Func<PlayerQuestSConverter, bool>) (x => x.questS.ID == StageData.ID)).First<PlayerQuestSConverter>();
      EventDelegate.Set(this.StageButton_UnLock.onClick, (EventDelegate.Callback) (() =>
      {
        NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
        if (Object.op_Inequality((Object) instance, (Object) null))
          instance.playSE("SE_1002");
        this.StartCoroutine(this.PopupJudge(stageData));
      }));
      ((Component) this.newSprite).gameObject.SetActive(stageData.is_new);
      ((Component) this.clearSprite).gameObject.SetActive(stageData.is_clear);
      this.SetBonusRewardImage(StageData.has_reward, stageData.is_clear);
    }
    this.InitValue(StageData, gridWidth, center);
  }

  private void SetBonusRewardImage(int? has_reward, bool is_clear)
  {
    if (!has_reward.HasValue || !has_reward.HasValue || !this.UnLock)
    {
      ((Component) this.StageBounas).gameObject.SetActive(false);
    }
    else
    {
      List<BattleStageClear> list = ((IEnumerable<BattleStageClear>) MasterData.BattleStageClearList).Where<BattleStageClear>((Func<BattleStageClear, bool>) (x => x.reward_group_id == has_reward.GetValueOrDefault() && has_reward.HasValue)).ToList<BattleStageClear>();
      List<BattleStageClear> battleStageClearList = !is_clear ? list : list.Where<BattleStageClear>((Func<BattleStageClear, bool>) (x => x.only_first == 0)).ToList<BattleStageClear>();
      if (battleStageClearList.Count <= 0)
      {
        ((Component) this.StageBounas).gameObject.SetActive(false);
      }
      else
      {
        ((Component) this.StageBounas).gameObject.SetActive(true);
        UISpriteData uiSpriteData = (UISpriteData) null;
        UISprite component = ((Component) this.StageBounas).GetComponent<UISprite>();
        if (battleStageClearList.Count == 1)
        {
          string name = string.Format("slc_BonusIcon_{0}.png__GUI__002-14_sozai__002-14_sozai_prefab", (object) battleStageClearList[0].entity_type_CommonRewardType);
          uiSpriteData = component.atlas.GetSprite(name);
          if (uiSpriteData != null)
            component.spriteName = name;
        }
        if (uiSpriteData != null || battleStageClearList.Count <= 0)
          return;
        string str = "slc_BonusIcon_Other.png__GUI__002-14_sozai__002-14_sozai_prefab";
        component.spriteName = str;
      }
    }
  }

  public void InitValue(QuestSConverter StageData, float gridWidth, int centernum)
  {
    ((Component) this).GetComponent<TweenPosition>().from.x = (float) ((this.StageNumber - centernum - 1) * 139);
    ((Component) this).GetComponent<TweenPosition>().to.x = (float) ((this.StageNumber - centernum - 1) * 139);
    foreach (UILabel stageNumber in this.StageNumbers)
      stageNumber.SetText(this.StageNumber.ToString());
    if (!this.UnLock)
      return;
    this.AP = StageData.lost_ap;
    this.apCost.SetTextLocalize(this.AP);
    if (((Component) this.clearSprite).gameObject.activeSelf)
      return;
    foreach (UIWidget objWidget in this.ObjWidgets)
    {
      if (objWidget is UILabel)
        objWidget.color = Consts.GetInstance().UI_LABEL_NORMAL_COLOR;
      else if (objWidget is UISprite)
        objWidget.color = Consts.GetInstance().UI_SPRITE_NORMAL_COLOR;
    }
  }

  public void ChangeToneConditionJudge(float variationValue)
  {
    float changeValue = Mathf.Abs(variationValue) / this.SpaceValue;
    if ((double) changeValue >= 1.0)
      this.ChangeToneCondition(1f);
    else if ((double) changeValue <= 0.0)
      this.ChangeToneCondition(0.0f);
    else
      this.ChangeToneCondition(changeValue);
  }

  private void ChangeToneCondition(float changeValue)
  {
    float num = (this.defaultScale - this.changedScale) * changeValue;
    Color color = Color.Lerp(Consts.GetInstance().UI_SPRITE_NORMAL_COLOR, Consts.GetInstance().UI_SPRITE_DISABLED_COLOR, changeValue);
    Color changeLabelColorValue = Color.Lerp(Consts.GetInstance().UI_LABEL_NORMAL_COLOR, Consts.GetInstance().UI_LABEL_DISABLED_COLOR, changeValue);
    ((Component) this).transform.localScale = new Vector3(this.defaultScale - num, this.defaultScale - num, this.defaultScale);
    foreach (UIWidget objWidget in this.ObjWidgets)
      objWidget.color = !((Component) this.clearSprite).gameObject.activeSelf ? color : (!(((Object) objWidget).name == "slc_Clear") ? Consts.GetInstance().UI_SPRITE_DISABLED_COLOR : color);
    this.StageNumbers.ForEach((Action<UILabel>) (label => label.color = changeLabelColorValue));
    this.tweenColorLabels.ForEach((Action<UILabel>) (label => label.color = changeLabelColorValue));
  }

  public void NotTouch(bool judge)
  {
    this.Mask.SetActive(judge);
    ((Behaviour) this.StageButton_UnLock).enabled = !judge;
  }

  public void centerAnimation(bool flag)
  {
    if (this.anim != flag && flag)
    {
      Color spriteNormalColor = Consts.GetInstance().UI_SPRITE_NORMAL_COLOR;
      Color changeLabelColorValue = Consts.GetInstance().UI_LABEL_NORMAL_COLOR;
      foreach (UIWidget objWidget in this.ObjWidgets)
        objWidget.color = spriteNormalColor;
      this.StageNumbers.ForEach((Action<UILabel>) (label => label.color = changeLabelColorValue));
      this.tweenColorLabels.ForEach((Action<UILabel>) (label => label.color = changeLabelColorValue));
      ((Behaviour) ((Component) this).GetComponent<TweenScale>()).enabled = true;
      ((Component) this).GetComponent<TweenScale>().PlayForward();
    }
    else if (!flag)
      ((Behaviour) ((Component) this).GetComponent<TweenScale>()).enabled = false;
    this.anim = flag;
  }

  [DebuggerHidden]
  public IEnumerator PopupJudge(PlayerQuestSConverter StageData)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00214Hscroll.\u003CPopupJudge\u003Ec__Iterator184()
    {
      StageData = StageData,
      \u003C\u0024\u003EStageData = StageData,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator noAP_Popup()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Quest00214Hscroll.\u003CnoAP_Popup\u003Ec__Iterator185 popupCIterator185 = new Quest00214Hscroll.\u003CnoAP_Popup\u003Ec__Iterator185();
    return (IEnumerator) popupCIterator185;
  }

  [DebuggerHidden]
  private IEnumerator maxAPshortage_Popoup()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Quest00214Hscroll.\u003CmaxAPshortage_Popoup\u003Ec__Iterator186 popoupCIterator186 = new Quest00214Hscroll.\u003CmaxAPshortage_Popoup\u003Ec__Iterator186();
    return (IEnumerator) popoupCIterator186;
  }
}
