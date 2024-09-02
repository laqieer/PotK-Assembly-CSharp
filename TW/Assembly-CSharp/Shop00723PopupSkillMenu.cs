// Decompiled with JetBrains decompiler
// Type: Shop00723PopupSkillMenu
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
public class Shop00723PopupSkillMenu : BackButtonMenuBase
{
  private const int SINGLE_SKILLCHANGE = 1;
  private const int NUM_INITIALIZED = 1;
  private const int NUM_NO_HSCROLL = 1;
  [SerializeField]
  private GameObject mainView_;
  [SerializeField]
  private ScrollViewSpecifyBounds mainScroll_;
  [SerializeField]
  private UICenterOnChild uiCentering_;
  [SerializeField]
  private Shop00723PopupSkillContainer container_;
  [SerializeField]
  private UIDragScrollView hdragScrollView_;
  [SerializeField]
  private GameObject arrowLeft_;
  [SerializeField]
  private GameObject arrowRight_;
  private Shop00723Menu menu_;
  private UnitTicketUnitSample sample_;
  private bool isStarted_;
  private bool isDelayInitialize_ = true;
  private Shop00723PopupSkillMenu.UnitTree unitTree_;
  private List<Shop00723PopupSkillMenu.UnitTree> listUnit_;
  private GameObject[] hscrollItems_;
  private int current_;
  private GameObject currentItem_;
  private GameObject pageTrigger_;

  private Shop00723PopupSkillMenu.UnitTree makeUnitTree(int id)
  {
    List<int> listId = new List<int>();
    return this.makeUnitTree(0, id, (Shop00723PopupSkillMenu.UnitTree) null, listId);
  }

  private Shop00723PopupSkillMenu.UnitTree makeUnitTree(
    int nest,
    int id,
    Shop00723PopupSkillMenu.UnitTree parent,
    List<int> listId)
  {
    UnitUnit unit;
    if (!MasterData.UnitUnit.TryGetValue(id, out unit))
      return (Shop00723PopupSkillMenu.UnitTree) null;
    Shop00723PopupSkillMenu.UnitTree ret = new Shop00723PopupSkillMenu.UnitTree(nest, unit, parent);
    if (listId.Contains(id))
      return ret;
    listId.Add(id);
    UnitEvolutionPattern[] evolutionPattern = unit.EvolutionPattern;
    if (((IEnumerable<UnitEvolutionPattern>) evolutionPattern).Any<UnitEvolutionPattern>())
    {
      ++nest;
      ret.setChilds(((IEnumerable<UnitEvolutionPattern>) evolutionPattern).Where<UnitEvolutionPattern>((Func<UnitEvolutionPattern, bool>) (u => this.isNormalUnit(u.target_unit_UnitUnit))).Select<UnitEvolutionPattern, Shop00723PopupSkillMenu.UnitTree>((Func<UnitEvolutionPattern, Shop00723PopupSkillMenu.UnitTree>) (eu => this.makeUnitTree(nest, eu.target_unit_UnitUnit, ret, listId))).Where<Shop00723PopupSkillMenu.UnitTree>((Func<Shop00723PopupSkillMenu.UnitTree, bool>) (tr => tr != null)).ToArray<Shop00723PopupSkillMenu.UnitTree>());
    }
    return ret;
  }

  private bool isNormalUnit(int id)
  {
    UnitUnit unitUnit;
    return MasterData.UnitUnit.TryGetValue(id, out unitUnit) && unitUnit.IsNormalUnit;
  }

  private List<Shop00723PopupSkillMenu.UnitTree> unitTreeToList(Shop00723PopupSkillMenu.UnitTree ut)
  {
    List<Shop00723PopupSkillMenu.UnitTree> unitTreeList = new List<Shop00723PopupSkillMenu.UnitTree>();
    this.unitTreeToList(unitTreeList, ut);
    return unitTreeList.OrderBy<Shop00723PopupSkillMenu.UnitTree, int>((Func<Shop00723PopupSkillMenu.UnitTree, int>) (u => u.nest_)).ToList<Shop00723PopupSkillMenu.UnitTree>();
  }

  private void unitTreeToList(
    List<Shop00723PopupSkillMenu.UnitTree> unitList,
    Shop00723PopupSkillMenu.UnitTree ut)
  {
    unitList.Add(ut);
    if (ut.childs_ == null || ut.childs_.Length <= 0)
      return;
    foreach (Shop00723PopupSkillMenu.UnitTree child in ut.childs_)
      this.unitTreeToList(unitList, child);
  }

  private void setSubName(List<Shop00723PopupSkillMenu.UnitTree> units)
  {
    int nest = 0;
    while (true)
    {
      List<Shop00723PopupSkillMenu.UnitTree> list = units.Where<Shop00723PopupSkillMenu.UnitTree>((Func<Shop00723PopupSkillMenu.UnitTree, bool>) (u => u.nest_ == nest)).ToList<Shop00723PopupSkillMenu.UnitTree>();
      if (list.Count != 0)
      {
        if (list.Count > 1)
        {
          char ch = 'a';
          foreach (Shop00723PopupSkillMenu.UnitTree unitTree in list)
            unitTree.setSubName(string.Format("{0}", (object) ch++));
        }
        ++nest;
      }
      else
        break;
    }
  }

  public void initialize(Shop00723Menu menu, UnitTicketUnitSample unitSample)
  {
    ((Component) this).GetComponent<UIRect>().alpha = 0.0f;
    this.isStarted_ = false;
    this.isDelayInitialize_ = true;
    this.menu_ = menu;
    this.sample_ = unitSample;
    this.unitTree_ = this.makeUnitTree(this.sample_.unitUnit_UnitUnit);
    this.listUnit_ = this.unitTreeToList(this.unitTree_);
    this.setSubName(this.listUnit_);
    this.current_ = 0;
    this.currentItem_ = (GameObject) null;
    ((Behaviour) this.mainScroll_).enabled = false;
    this.setActiveArrow();
  }

  [DebuggerHidden]
  private IEnumerator Start()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00723PopupSkillMenu.\u003CStart\u003Ec__Iterator4BD()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void OnDestroy()
  {
    if (!this.isDelayInitialize_)
      return;
    this.StopCoroutine("coInitializeDelay");
  }

  [DebuggerHidden]
  private IEnumerator coInitializeDelay()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00723PopupSkillMenu.\u003CcoInitializeDelay\u003Ec__Iterator4BE()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator coInitUnit(GameObject goList, Shop00723PopupSkillMenu.UnitTree utree)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00723PopupSkillMenu.\u003CcoInitUnit\u003Ec__Iterator4BF()
    {
      goList = goList,
      utree = utree,
      \u003C\u0024\u003EgoList = goList,
      \u003C\u0024\u003Eutree = utree,
      \u003C\u003Ef__this = this
    };
  }

  protected override void Update()
  {
    base.Update();
    if (this.isDelayInitialize_)
      return;
    GameObject centeredObject = this.uiCentering_.centeredObject;
    if (Object.op_Inequality((Object) this.pageTrigger_, (Object) centeredObject))
    {
      this.playPageSE();
      this.pageTrigger_ = centeredObject;
    }
    if (Object.op_Equality((Object) this.currentItem_, (Object) centeredObject))
      return;
    SpringPanel component = ((Component) this.mainScroll_).GetComponent<SpringPanel>();
    if (Object.op_Inequality((Object) component, (Object) null) && ((Behaviour) component).enabled)
      return;
    this.currentItem_ = centeredObject;
    for (int index = 0; index < this.hscrollItems_.Length; ++index)
    {
      if (Object.op_Equality((Object) this.hscrollItems_[index], (Object) centeredObject))
      {
        this.current_ = index;
        break;
      }
    }
    this.updateArrow(this.current_);
  }

  private void playPageSE()
  {
    NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
    if (!Object.op_Inequality((Object) instance, (Object) null))
      return;
    instance.playSE("SE_1005");
  }

  public override void onBackButton() => this.onClickClose();

  public void onClickClose()
  {
    if (!this.isStarted_ || this.IsPushAndSet())
      return;
    this.menu_.onClosedSkill();
    Singleton<PopupManager>.GetInstance().dismiss();
  }

  public void onClickedLeft()
  {
    if (this.hscrollItems_ == null)
      return;
    int index = this.current_ - 1;
    if (index < 0)
      return;
    this.uiCentering_.CenterOn(this.hscrollItems_[index].transform);
    this.setActiveArrow();
  }

  public void onClickedRight()
  {
    if (this.hscrollItems_ == null)
      return;
    int index = this.current_ + 1;
    if (index >= this.hscrollItems_.Length)
      return;
    this.uiCentering_.CenterOn(this.hscrollItems_[index].transform);
    this.setActiveArrow();
  }

  private void updateArrow(int index)
  {
    this.setActiveArrow(index - 1 >= 0, index + 1 < this.listUnit_.Count);
  }

  private void setActiveArrow(bool activeLeft = false, bool activeRight = false)
  {
    this.setActiveArrow(this.arrowLeft_, activeLeft);
    this.setActiveArrow(this.arrowRight_, activeRight);
  }

  private void setActiveArrow(GameObject go, bool isactive)
  {
    go.GetComponent<UIButton>().isEnabled = isactive;
  }

  private class UnitTree
  {
    public UnitTree(int nest, UnitUnit unit, Shop00723PopupSkillMenu.UnitTree parent)
    {
      this.nest_ = nest;
      this.unit_ = unit;
      this.parent_ = parent;
    }

    public int nest_ { get; private set; }

    public string subName_ { get; private set; }

    public UnitUnit unit_ { get; private set; }

    public Shop00723PopupSkillMenu.UnitTree parent_ { get; private set; }

    public Shop00723PopupSkillMenu.UnitTree[] childs_ { get; private set; }

    public void setChilds(Shop00723PopupSkillMenu.UnitTree[] childs) => this.childs_ = childs;

    public void setSubName(string sub) => this.subName_ = sub;
  }
}
