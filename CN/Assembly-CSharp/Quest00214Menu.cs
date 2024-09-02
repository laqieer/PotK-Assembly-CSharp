// Decompiled with JetBrains decompiler
// Type: Quest00214Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest00214Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  private NGxScroll ScrollContainerChara;
  [SerializeField]
  private NGxScroll ScrollContainerCombi;
  [SerializeField]
  private GameObject ibtnCombi;
  [SerializeField]
  private GameObject ibtnChara;
  [SerializeField]
  private UIButton CombiButton;
  [SerializeField]
  private UIButton CharaButton;
  public Quest00214aMenu CharaQuest;
  private List<UnitIcon> allUnitIcons = new List<UnitIcon>();
  private List<Quest00214DirCombi> allQuestCombiCells = new List<Quest00214DirCombi>();
  private List<Quest00214DirTrio> allQuestTrioCells = new List<Quest00214DirTrio>();
  private PlayerCharacterQuestS[] AllCharaQuest;
  public bool onMask;
  public bool isSelect;
  private WebAPI.Response.QuestProgressCharacter apiResponse;
  private WebAPI.Response.QuestProgressHarmony apiResponsHarmony;
  private GameObject unitIconPrefab;
  private GameObject releaseConditionPrefab;
  private GameObject dirCombiPrefab;
  private GameObject dirTrioPrefab;

  public virtual void VScrollBar() => Debug.Log((object) "click default event VScrollBar");

  public virtual void Foreground() => Debug.Log((object) "click default event Foreground");

  public void InitCombiQuestButton() => this.ibtnCombi.SetActive(false);

  [DebuggerHidden]
  public IEnumerator InitCharacterQuestButton(int? unitId = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00214Menu.\u003CInitCharacterQuestButton\u003Ec__Iterator1C1()
    {
      unitId = unitId,
      \u003C\u0024\u003EunitId = unitId,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator instanciateUnitIcon(
    GameObject prefab,
    bool isOpen,
    bool isNew,
    UnitUnit unit,
    Action<UnitIcon> callback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00214Menu.\u003CinstanciateUnitIcon\u003Ec__Iterator1C2()
    {
      prefab = prefab,
      unit = unit,
      isOpen = isOpen,
      isNew = isNew,
      callback = callback,
      \u003C\u0024\u003Eprefab = prefab,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u0024\u003EisOpen = isOpen,
      \u003C\u0024\u003EisNew = isNew,
      \u003C\u0024\u003Ecallback = callback,
      \u003C\u003Ef__this = this
    };
  }

  private void Select(int unitId)
  {
    this.isSelect = true;
    this.IconEnable = !this.isSelect;
    ((Component) this.CharaQuest).gameObject.SetActive(true);
    this.StartCoroutine(this.CharaQuest.Init(unitId, this.apiResponse, this.unitIconPrefab, this.releaseConditionPrefab));
  }

  private void SelectHarmony(int unitId, int targetUnitId)
  {
    this.isSelect = true;
    this.CellEnable = false;
    ((Component) this.CharaQuest).gameObject.SetActive(true);
    int[] targetUnitIds = new int[1]{ targetUnitId };
    this.StartCoroutine(this.CharaQuest.Init(unitId, targetUnitIds, this.apiResponse, this.unitIconPrefab, this.releaseConditionPrefab, false));
  }

  private void SelectHarmony(int unitId, int[] targetUnitIds)
  {
    this.isSelect = true;
    this.CellEnable = false;
    ((Component) this.CharaQuest).gameObject.SetActive(true);
    this.StartCoroutine(this.CharaQuest.Init(unitId, targetUnitIds, this.apiResponse, this.unitIconPrefab, this.releaseConditionPrefab, true));
  }

  public bool IconEnable
  {
    set
    {
      this.allUnitIcons.ForEach((Action<UnitIcon>) (x => ((Collider) x.buttonBoxCollider).enabled = value));
      ((Behaviour) this.CombiButton).enabled = value;
    }
  }

  public bool CellEnable
  {
    set
    {
      this.allQuestCombiCells.ForEach((Action<Quest00214DirCombi>) (x => ((Collider) x.buttonBoxCollider).enabled = value));
      this.allQuestTrioCells.ForEach((Action<Quest00214DirTrio>) (x => ((Collider) x.buttonBoxCollider).enabled = value));
      ((Behaviour) this.CharaButton).enabled = value;
    }
  }

  public string SetTxtTitle
  {
    set => this.TxtTitle.SetTextLocalize(value);
  }

  public void IbtnCombi()
  {
    this.ChangeIbtnChara();
    this.SetTxtTitle = Consts.GetInstance().QUEST_00214_COMBI_TITLE;
    ((Component) this.ScrollContainerCombi).gameObject.SetActive(true);
    ((Component) this.ScrollContainerChara).gameObject.SetActive(false);
  }

  public void IbtnChara()
  {
    this.ChangeIbtnCombi();
    this.SetTxtTitle = Consts.GetInstance().QUEST_00214_CHARACTER_TITLE;
    ((Component) this.ScrollContainerCombi).gameObject.SetActive(false);
    ((Component) this.ScrollContainerChara).gameObject.SetActive(true);
  }

  public void ChangeIbtnCombi()
  {
    this.ibtnCombi.SetActive(false);
    this.ibtnChara.SetActive(false);
  }

  public void ChangeIbtnChara()
  {
    this.ibtnCombi.SetActive(false);
    this.ibtnChara.SetActive(false);
  }

  public override void onBackButton()
  {
    if (this.isSelect || this.IsPushAndSet())
      return;
    MypageScene.ChangeScene(false);
  }
}
