// Decompiled with JetBrains decompiler
// Type: Quest00214Hscroll
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
  [SerializeField]
  private UILabel apCost;
  public UISprite newSprite;
  public UISprite clearSprite;
  [SerializeField]
  private Transform StageNumbersParent_UnLock;
  [SerializeField]
  private Transform StageNumbersParent_Lock;
  public LongPressButton StageButton_UnLock;
  [SerializeField]
  private List<UISprite> StageNumbers;
  [SerializeField]
  private GameObject StageButton_Lock;
  [SerializeField]
  private float defaultScale = 1f;
  [SerializeField]
  private float changedScale = 0.9f;
  [SerializeField]
  private float SpaceValue = 1f;
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
    ((Component) this.StageBounas).gameObject.SetActive(false);
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
    ((Component) this.StageBounas).gameObject.SetActive(true);
    this.UnLock = true;
  }

  public void onSetValue()
  {
    this.defaultScale = 1f;
    this.changedScale = 0.9f;
    float cellWidth = ((Component) ((Component) this).transform.parent).GetComponent<UIGrid>().cellWidth;
    this.SpaceValue = (double) cellWidth > 0.0 ? cellWidth : this.SpaceValue;
  }

  private void WidgetGetInit()
  {
    this.ObjWidgets = new List<UIWidget>();
    if (!this.UnLock)
    {
      foreach (Transform transform in this.StageNumbersParent_Lock)
      {
        this.StageNumbers.Add(((Component) transform).GetComponent<UISprite>());
        this.ObjWidgets.Add(((Component) transform).GetComponent<UIWidget>());
      }
      this.ObjWidgets.Add(((Component) this.StageButton_Lock.transform).GetComponent<UIWidget>());
    }
    else
    {
      foreach (Transform transform in this.StageNumbersParent_UnLock)
      {
        this.StageNumbers.Add(((Component) transform).GetComponent<UISprite>());
        this.ObjWidgets.Add(((Component) transform).GetComponent<UIWidget>());
      }
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
    int center,
    EventDelegate.Callback onLongPressed)
  {
    this.WidgetGetInit();
    this.StageNumber = num;
    this.ID = StageData.ID;
    PlayerQuestSConverter stageData = ((IEnumerable<PlayerQuestSConverter>) charaque).FirstOrDefault<PlayerQuestSConverter>((Func<PlayerQuestSConverter, bool>) (x => x.questS.ID == StageData.ID));
    if (stageData != null)
    {
      EventDelegate.Set(this.StageButton_UnLock.onClick, (EventDelegate.Callback) (() =>
      {
        NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
        if (Object.op_Inequality((Object) instance, (Object) null))
          instance.playSE("SE_1002");
        this.StartCoroutine(this.PopupJudge(stageData));
      }));
      ((Component) this.newSprite).gameObject.SetActive(stageData.is_new);
      ((Component) this.clearSprite).gameObject.SetActive(stageData.is_clear);
      this.SetBonusRewardImage(stageData.clear_rewards);
    }
    this.InitValue(StageData, gridWidth, center);
    if (onLongPressed == null)
      return;
    EventDelegate.Set(this.StageButton_UnLock.onLongPress, onLongPressed);
  }

  private void SetBonusRewardImage(int[] clear_rewards)
  {
    if (clear_rewards == null || clear_rewards.Length <= 0 || !this.UnLock)
    {
      ((Component) this.StageBounas).gameObject.SetActive(false);
    }
    else
    {
      List<BattleStageClear> list = ((IEnumerable<int>) clear_rewards).Where<int>((Func<int, bool>) (x => MasterData.BattleStageClear.ContainsKey(x))).Select<int, BattleStageClear>((Func<int, BattleStageClear>) (x => MasterData.BattleStageClear[x])).ToList<BattleStageClear>();
      if (list.Count <= 0)
      {
        ((Component) this.StageBounas).gameObject.SetActive(false);
      }
      else
      {
        ((Component) this.StageBounas).gameObject.SetActive(true);
        UISpriteData uiSpriteData = (UISpriteData) null;
        UISprite component = ((Component) this.StageBounas).GetComponent<UISprite>();
        if (list.Count == 1)
        {
          string name = string.Format("slc_BonusIcon_{0}.png__GUI__002-14_sozai__002-14_sozai_prefab", (object) list[0].entity_type_CommonRewardType);
          uiSpriteData = component.atlas.GetSprite(name);
          if (uiSpriteData != null)
            component.spriteName = name;
        }
        if (uiSpriteData != null || list.Count <= 0)
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
    foreach (UISprite stageNumber in this.StageNumbers)
    {
      if (int.Parse(((Object) ((Component) stageNumber).gameObject).name.Substring(((Object) ((Component) stageNumber).gameObject).name.Length - 2)) == this.StageNumber)
        ((Component) stageNumber).gameObject.SetActive(true);
      else
        ((Component) stageNumber).gameObject.SetActive(false);
    }
    if (!this.UnLock)
      return;
    this.AP = StageData.lost_ap;
    this.apCost.SetTextLocalize(this.AP);
    if (((Component) this.clearSprite).gameObject.activeSelf)
      return;
    foreach (UIWidget objWidget in this.ObjWidgets)
      objWidget.color = Color.white;
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
    Color color = Color.Lerp(Color.white, Color.gray, changeValue);
    ((Component) this).transform.localScale = new Vector3(this.defaultScale - num, this.defaultScale - num, this.defaultScale);
    foreach (UIWidget objWidget in this.ObjWidgets)
      objWidget.color = !((Component) this.clearSprite).gameObject.activeSelf ? color : (!(((Object) objWidget).name == "slc_Clear") ? Color.Lerp(Color.white, Color.gray, 1f) : color);
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
      Color color = Color.Lerp(Color.white, Color.gray, 0.0f);
      foreach (UIWidget objWidget in this.ObjWidgets)
        objWidget.color = color;
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
    return (IEnumerator) new Quest00214Hscroll.\u003CPopupJudge\u003Ec__Iterator1EA()
    {
      StageData = StageData,
      \u003C\u0024\u003EStageData = StageData,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator noAP_Popup(System.Action questChangeScene)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00214Hscroll.\u003CnoAP_Popup\u003Ec__Iterator1EB()
    {
      questChangeScene = questChangeScene,
      \u003C\u0024\u003EquestChangeScene = questChangeScene
    };
  }

  [DebuggerHidden]
  private IEnumerator maxAPshortage_Popoup()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Quest00214Hscroll.\u003CmaxAPshortage_Popoup\u003Ec__Iterator1EC popoupCIterator1Ec = new Quest00214Hscroll.\u003CmaxAPshortage_Popoup\u003Ec__Iterator1EC();
    return (IEnumerator) popoupCIterator1Ec;
  }
}
