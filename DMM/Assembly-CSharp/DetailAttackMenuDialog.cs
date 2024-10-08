﻿// Decompiled with JetBrains decompiler
// Type: DetailAttackMenuDialog
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetailAttackMenuDialog : BackButtonMenuBase
{
  private bool isShow;
  [SerializeField]
  private Transform skillTargetParent1;
  [SerializeField]
  private Transform skillTargetParent2;
  private BattleskillSkill displaySkill;
  [SerializeField]
  private Transform attackClassParent;
  [SerializeField]
  private AttackClassIcon attackClassIcon;
  [SerializeField]
  private Transform attackAttributeParent;
  private GearKind weaponKind;
  private GearAttackClassification attackClass;
  [SerializeField]
  private BattleskillGenre? skillTargetID1;
  [SerializeField]
  private BattleskillGenre? skillTargetID2;
  private string skillName;
  private string skillDesc;
  private string skillCategoryInfo;
  [SerializeField]
  private UILabel label_SkillName;
  [SerializeField]
  private UILabel label_SkillDesc;
  [SerializeField]
  private GameObject dir_range;
  [SerializeField]
  private UILabel txtRangeDistance;
  [SerializeField]
  private UISprite bgSprite;
  private GameObject skillTgtIcon1;
  private GameObject skillTgtIcon2;
  private CommonElementIcon elementIcon;
  private BattleSkillIcon skillIcon;

  private new void Update()
  {
    if (!this.isShow || !Input.GetMouseButtonDown(0) && !Input.GetMouseButtonDown(1) && (!Input.GetMouseButtonDown(2) && (double) Input.GetAxis("Mouse ScrollWheel") == 0.0))
      return;
    this.Hide();
  }

  public void Hide()
  {
    if (!this.isShow)
      return;
    this.isShow = false;
    UITweener[] tweens = this.gameObject.GetComponentsInChildren<UITweener>();
    if (tweens.Length == 0)
      return;
    int finishCount = 0;
    EventDelegate.Callback onFinish = (EventDelegate.Callback) (() =>
    {
      if (++finishCount < tweens.Length)
        return;
      this.gameObject.SetActive(false);
    });
    ((IEnumerable<UITweener>) tweens).ForEach<UITweener>((System.Action<UITweener>) (c =>
    {
      c.onFinished.Clear();
      c.AddOnFinished(onFinish);
      c.PlayReverse();
    }));
  }

  private GameObject createIcon(GameObject prefab, Transform trans)
  {
    GameObject gameObject = prefab.Clone(trans);
    UI2DSprite componentInChildren1 = gameObject.GetComponentInChildren<UI2DSprite>();
    BoxCollider componentInChildren2 = trans.GetComponentInChildren<BoxCollider>();
    if (!((UnityEngine.Object) componentInChildren1 != (UnityEngine.Object) null))
      return gameObject;
    componentInChildren1.SetDimensions((int) componentInChildren2.size.x, (int) componentInChildren2.size.y);
    componentInChildren1.depth += 150;
    return gameObject;
  }

  public void Show(bool fromJobMenu = false)
  {
    if (this.isShow)
      return;
    this.isShow = true;
    this.StopCoroutine("setIcons");
    this.StartCoroutine(this.setIcons(fromJobMenu));
    ((IEnumerable<UITweener>) this.gameObject.GetComponentsInChildren<UITweener>()).ForEach<UITweener>((System.Action<UITweener>) (c =>
    {
      c.enabled = true;
      c.onFinished.Clear();
      c.PlayForward();
    }));
  }

  private IEnumerator setIcons(bool fromJobMenu)
  {
    this.label_SkillName.SetText(this.skillName);
    this.label_SkillDesc.SetText(this.skillDesc);
    if ((UnityEngine.Object) this.bgSprite != (UnityEngine.Object) null && Singleton<NGGameDataManager>.GetInstance().IsSea)
    {
      if (string.IsNullOrEmpty(this.skillCategoryInfo))
      {
        this.bgSprite.spriteName = "slc_popup_base_b.png__GUI__unit_detail_sea__unit_detail_sea_prefab";
        this.bgSprite.height = 173;
      }
      else
      {
        this.bgSprite.spriteName = "slc_popup_base_c.png__GUI__unit_detail_sea__unit_detail_sea_prefab";
        this.bgSprite.height = 238;
      }
    }
    this.attackAttributeParent.gameObject.SetActive(true);
    Future<GameObject> commonElementPrefabF;
    IEnumerator e;
    if ((UnityEngine.Object) this.elementIcon == (UnityEngine.Object) null)
    {
      commonElementPrefabF = Res.Icons.CommonElementIcon.Load<GameObject>();
      e = commonElementPrefabF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      this.elementIcon = this.createIcon(commonElementPrefabF.Result, this.attackAttributeParent).GetComponent<CommonElementIcon>();
      commonElementPrefabF = (Future<GameObject>) null;
    }
    this.elementIcon.Init(this.displaySkill.element);
    this.attackClassParent.gameObject.SetActive(true);
    this.attackClassIcon.Initialize(this.attackClass);
    if (!fromJobMenu)
    {
      if ((UnityEngine.Object) this.skillTgtIcon1 == (UnityEngine.Object) null && (UnityEngine.Object) this.skillTgtIcon2 == (UnityEngine.Object) null)
      {
        commonElementPrefabF = Res.Icons.SkillGenreIcon.Load<GameObject>();
        e = commonElementPrefabF.Wait();
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
        GameObject result = commonElementPrefabF.Result;
        this.skillTgtIcon1 = this.createIcon(result, this.skillTargetParent1);
        this.skillTgtIcon2 = this.createIcon(result, this.skillTargetParent2);
        commonElementPrefabF = (Future<GameObject>) null;
      }
      this.skillTgtIcon1.GetComponent<SkillGenreIcon>().Init(this.skillTargetID1);
      this.skillTgtIcon2.GetComponent<SkillGenreIcon>().Init(this.skillTargetID2);
    }
    else
    {
      this.dir_range.SetActive(true);
      this.txtRangeDistance.SetTextLocalize(this.displaySkill.min_range.ToString() + "-" + (object) this.displaySkill.max_range);
    }
  }

  public void setSkillProperty(bool flg)
  {
    this.skillTargetParent1.gameObject.SetActive(flg);
    this.skillTargetParent2.gameObject.SetActive(flg);
  }

  public void setData(
    BattleskillSkill skill,
    string addDescription,
    GearAttackClassification attackClass)
  {
    this.displaySkill = skill;
    this.skillDesc = skill.description;
    this.skillName = skill.name;
    string str = Consts.Format(Consts.GetInstance().popup_004_ExtraSkill_affection_condition_category, (IDictionary) new Hashtable()
    {
      {
        (object) "condition",
        (object) AwakeSkillCategory.GetEquipableText(skill.awake_skill_category_id)
      }
    });
    this.skillCategoryInfo = !string.IsNullOrEmpty(addDescription) ? str + addDescription : "";
    this.skillTargetID1 = skill.genre1;
    this.skillTargetID2 = skill.genre2;
    this.attackClass = attackClass;
  }

  public override void onBackButton()
  {
    if (this.IsPushAndSet())
      return;
    this.Hide();
  }
}
