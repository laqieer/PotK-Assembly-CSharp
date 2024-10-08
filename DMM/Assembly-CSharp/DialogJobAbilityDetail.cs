﻿// Decompiled with JetBrains decompiler
// Type: DialogJobAbilityDetail
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System.Collections;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class DialogJobAbilityDetail : BackButtonMenuBase
{
  [SerializeField]
  private GameObject objDialog_;
  [SerializeField]
  private Transform lnkGenre1_;
  [SerializeField]
  private Transform lnkGenre2_;
  [SerializeField]
  private UILabel txtName_;
  [SerializeField]
  private UILabel txtDescription_;
  [SerializeField]
  private GameObject bgGenres_;
  [SerializeField]
  private GameObject dirLevel_;
  [SerializeField]
  private GameObject slcLevel_;
  [SerializeField]
  private GameObject slcLevelMax_;
  [SerializeField]
  private UILabel txtLevel_;
  [SerializeField]
  private UILabel txtLevelMax_;
  [SerializeField]
  private UITweener[] effectsOpen_End_;
  private SkillGenreIcon iconGenre1_;
  private SkillGenreIcon iconGenre2_;
  private BattleskillGenre? genre1_;
  private BattleskillGenre? genre2_;
  private string name_;
  private string description_;
  private bool isShow_;
  private Queue<DialogJobAbilityDetail.CommandUnit> request_ = new Queue<DialogJobAbilityDetail.CommandUnit>(1);

  public bool isAutoClose { get; set; }

  public void adjustDepth(GameObject goParent, int offset = 1)
  {
    UIPanel component1 = this.GetComponent<UIPanel>();
    if ((Object) component1 == (Object) null)
      return;
    UIWidget component2 = goParent.GetComponent<UIWidget>();
    if ((Object) component2 != (Object) null)
    {
      component1.depth += component2.depth + offset;
    }
    else
    {
      UIPanel component3 = goParent.GetComponent<UIPanel>();
      if (!((Object) component3 != (Object) null))
        return;
      component1.depth += component3.depth + offset;
    }
  }

  public void show(PlayerUnitJob_abilities jobAbility)
  {
    JobCharacteristics master = jobAbility?.master;
    if (master == null)
      return;
    this.show(master.skill, jobAbility.level);
  }

  public void show(PlayerUnitSkills s = null) => this.show(s?.skill, s != null ? s.level : -1);

  public void show(BattleskillSkill s, int lvl)
  {
    if (s != null)
      this.setData(s, lvl);
    if (this.enabled && this.isShow_)
      return;
    Singleton<NGSoundManager>.GetInstance().playSE("SE_1006");
    this.enabled = true;
    this.isShow_ = true;
    this.objDialog_.SetActive(true);
    foreach (UITweener uiTweener in this.effectsOpen_End_)
    {
      uiTweener.enabled = true;
      uiTweener.onFinished.Clear();
      uiTweener.PlayForward();
    }
  }

  public void hide()
  {
    if (!this.isShow_)
      return;
    this.isShow_ = false;
    if (this.enabled && this.effectsOpen_End_.Length != 0)
    {
      int finishCount = 0;
      EventDelegate.Callback del = (EventDelegate.Callback) (() =>
      {
        if (++finishCount < this.effectsOpen_End_.Length)
          return;
        this.objDialog_.SetActive(false);
        this.enabled = false;
      });
      foreach (UITweener uiTweener in this.effectsOpen_End_)
      {
        uiTweener.onFinished.Clear();
        uiTweener.AddOnFinished(del);
        uiTweener.PlayReverse();
      }
    }
    else
    {
      this.objDialog_.SetActive(false);
      this.enabled = false;
    }
    this.request_.Clear();
  }

  private GameObject createIcon(GameObject prefab, Transform trans)
  {
    GameObject gameObject = prefab.Clone(trans);
    UI2DSprite componentInChildren = gameObject.GetComponentInChildren<UI2DSprite>();
    UIWidget component = trans.GetComponent<UIWidget>();
    if (!((Object) componentInChildren != (Object) null))
      return gameObject;
    if ((Object) component != (Object) null)
    {
      Vector2 localSize = component.localSize;
      componentInChildren.SetDimensions((int) localSize.x, (int) localSize.y);
      componentInChildren.depth += component.depth;
      return gameObject;
    }
    componentInChildren.depth += 150;
    return gameObject;
  }

  protected override void Update()
  {
    if (!this.isShow_)
      return;
    base.Update();
    if (this.isAutoClose && (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || (Input.GetMouseButtonDown(2) || (double) Input.GetAxis("Mouse ScrollWheel") != 0.0)))
      this.hide();
    if (!this.request_.Any<DialogJobAbilityDetail.CommandUnit>())
      return;
    this.StartCoroutine("flushData");
  }

  private IEnumerator flushData()
  {
    DialogJobAbilityDetail jobAbilityDetail1 = this;
    if (jobAbilityDetail1.request_.Any<DialogJobAbilityDetail.CommandUnit>())
    {
      DialogJobAbilityDetail.CommandUnit commandUnit = jobAbilityDetail1.request_.Dequeue();
      jobAbilityDetail1.description_ = commandUnit.skill?.description ?? string.Empty;
      jobAbilityDetail1.name_ = commandUnit.skill?.name ?? string.Empty;
      jobAbilityDetail1.genre1_ = (BattleskillGenre?) commandUnit.skill?.genre1;
      jobAbilityDetail1.genre2_ = (BattleskillGenre?) commandUnit.skill?.genre2;
      DialogJobAbilityDetail jobAbilityDetail2 = jobAbilityDetail1;
      int level = commandUnit.level;
      BattleskillSkill skill = commandUnit.skill;
      int lv_upper = skill != null ? skill.upper_level : 0;
      jobAbilityDetail2.setLevel(level, lv_upper);
      jobAbilityDetail1.txtName_.SetTextLocalize(jobAbilityDetail1.name_);
      jobAbilityDetail1.txtDescription_.SetTextLocalize(jobAbilityDetail1.description_);
      if ((Object) jobAbilityDetail1.iconGenre1_ == (Object) null && (Object) jobAbilityDetail1.iconGenre2_ == (Object) null)
      {
        Future<GameObject> skillTargetPrefabF = Res.Icons.SkillGenreIcon.Load<GameObject>();
        IEnumerator e = skillTargetPrefabF.Wait();
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
        GameObject result = skillTargetPrefabF.Result;
        jobAbilityDetail1.iconGenre1_ = jobAbilityDetail1.createIcon(result, jobAbilityDetail1.lnkGenre1_).GetComponent<SkillGenreIcon>();
        jobAbilityDetail1.iconGenre2_ = jobAbilityDetail1.createIcon(result, jobAbilityDetail1.lnkGenre2_).GetComponent<SkillGenreIcon>();
        skillTargetPrefabF = (Future<GameObject>) null;
      }
      jobAbilityDetail1.iconGenre1_.Init(jobAbilityDetail1.genre1_);
      jobAbilityDetail1.iconGenre2_.Init(jobAbilityDetail1.genre2_);
    }
  }

  public void setData(BattleskillSkill skill, int level = 0)
  {
    this.request_.Clear();
    this.request_.Enqueue(new DialogJobAbilityDetail.CommandUnit(skill, level));
  }

  private void setLevel(int lv, int lv_upper)
  {
    string str = lv < 0 || lv_upper < 1 ? "-" : lv.ToString();
    string text = lv_upper < 1 ? "-" : lv_upper.ToString();
    if (lv < 0 && lv_upper > 0)
    {
      this.slcLevel_.SetActive(false);
      if ((Object) this.slcLevelMax_ != (Object) null)
        this.slcLevelMax_.SetActive(true);
      this.txtLevel_.gameObject.SetActive(false);
      if (!((Object) this.txtLevelMax_ != (Object) null))
        return;
      this.txtLevelMax_.gameObject.SetActive(true);
      this.txtLevelMax_.SetText(text);
    }
    else
    {
      this.slcLevel_.SetActive(true);
      if ((Object) this.slcLevelMax_ != (Object) null)
        this.slcLevelMax_.SetActive(false);
      this.txtLevel_.gameObject.SetActive(true);
      if ((Object) this.txtLevelMax_ != (Object) null)
        this.txtLevelMax_.gameObject.SetActive(false);
      this.txtLevel_.SetText(str + "/" + text);
    }
  }

  public void setEnabledLevel(bool flag) => this.dirLevel_.SetActive(flag);

  public void setEnabledGenres(bool flag)
  {
    this.bgGenres_.SetActive(flag);
    this.lnkGenre1_.gameObject.SetActive(flag);
    this.lnkGenre2_.gameObject.SetActive(flag);
  }

  public override void onBackButton()
  {
    if (!this.isAutoClose || this.IsPushAndSet())
      return;
    this.hide();
  }

  private class CommandUnit
  {
    public BattleskillSkill skill { get; private set; }

    public int level { get; private set; }

    public CommandUnit(BattleskillSkill s, int lvl)
    {
      this.skill = s;
      this.level = lvl;
    }
  }
}
