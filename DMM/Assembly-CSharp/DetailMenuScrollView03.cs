// Decompiled with JetBrains decompiler
// Type: DetailMenuScrollView03
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetailMenuScrollView03 : DetailMenuScrollViewBase
{
  [SerializeField]
  private GameObject floatingSkillDialog;
  [SerializeField]
  protected UILabel txt_WeaponName;
  [SerializeField]
  protected UILabel txt_WeaponRange;
  [SerializeField]
  protected UI2DSprite dyn_WeaponType;
  [SerializeField]
  protected UI2DSprite dyn_WeaponSpType01;
  [SerializeField]
  protected UI2DSprite dyn_WeaponSpType02;
  [SerializeField]
  protected UILabel txt_SecondWeaponName;
  [SerializeField]
  protected UILabel txt_SecondWeaponRange;
  [SerializeField]
  protected UI2DSprite dyn_SecondWeaponType;
  [SerializeField]
  protected UI2DSprite dyn_SecondWeaponSpType01;
  [SerializeField]
  protected UI2DSprite dyn_SecondWeaponSpType02;
  [SerializeField]
  protected UILabel[] txt_MagicNames;
  [SerializeField]
  protected UILabel[] txt_MagicRanges;
  [SerializeField]
  protected UI2DSprite[] dyn_MagicElementTypes;
  [SerializeField]
  protected UI2DSprite[] dyn_MagicSpTypes01;
  [SerializeField]
  protected UI2DSprite[] dyn_MagicSpTypes02;
  private UIButton[] magicButtons;
  private System.Action<BattleskillSkill> showSkillDialog;
  private System.Action<int, int> showSkillLevel;
  [SerializeField]
  private DetailMenu menu;
  private Battle0171111Event floatingSkillDialogObject;
  private GameObject gearKindIconObject;
  private GameObject secondGearKindIconObject;
  private GameObject[] magicElemmentObject;
  [SerializeField]
  protected TweenAlpha tweenAlphaFirstWeapon;
  [SerializeField]
  protected TweenAlpha tweenAlphaSecondWeapon;

  private void Awake() => this.magicElemmentObject = new GameObject[this.txt_MagicNames.Length];

  public override bool Init(PlayerUnit playerUnit, PlayerUnit baseUnit)
  {
    GearGear equippedGearOrInitial = playerUnit.equippedGearOrInitial;
    this.gameObject.SetActive(true);
    this.txt_WeaponName.SetTextLocalize(playerUnit.equippedGearName);
    this.txt_WeaponRange.SetTextLocalize(equippedGearOrInitial.min_range.ToString() + "-" + (object) equippedGearOrInitial.max_range);
    if (playerUnit.equippedGear2 != (PlayerItem) null)
    {
      GearGear gear = playerUnit.equippedGear2.gear;
      this.txt_SecondWeaponName.SetTextLocalize(playerUnit.equippedGearName2);
      this.txt_SecondWeaponRange.SetTextLocalize(gear.min_range.ToString() + "-" + (object) gear.max_range);
    }
    this.SetGearNameAnimation(playerUnit);
    return true;
  }

  public override IEnumerator initAsync(
    PlayerUnit playerUnit,
    bool limitMode,
    bool isMaterial,
    GameObject[] prefabs)
  {
    GearGear gearGear1 = (GearGear) null;
    CommonElement element1 = CommonElement.none;
    GearGear gearGear2;
    CommonElement element2;
    if (playerUnit.equippedGear != (PlayerItem) null)
    {
      gearGear2 = playerUnit.equippedGear.gear;
      element2 = playerUnit.equippedGear.GetElement();
    }
    else
    {
      gearGear2 = playerUnit.initial_gear;
      element2 = playerUnit.initial_gear.GetElement();
    }
    if (playerUnit.equippedGear2 != (PlayerItem) null)
    {
      gearGear1 = playerUnit.equippedGear2.gear;
      element1 = playerUnit.equippedGear2.GetElement();
    }
    PlayerUnitSkills[] skills = playerUnit.skills;
    this.showSkillDialog = (System.Action<BattleskillSkill>) null;
    this.showSkillLevel = (System.Action<int, int>) null;
    if (this.showSkillDialog == null)
    {
      if ((UnityEngine.Object) this.floatingSkillDialogObject == (UnityEngine.Object) null)
        this.floatingSkillDialogObject = prefabs[0].Clone(this.floatingSkillDialog.transform).GetComponentInChildren<Battle0171111Event>();
      this.floatingSkillDialogObject.transform.parent.gameObject.SetActive(false);
      this.showSkillDialog = (System.Action<BattleskillSkill>) (skill =>
      {
        this.floatingSkillDialogObject.setData(skill);
        this.floatingSkillDialogObject.Show();
      });
      this.showSkillLevel = (System.Action<int, int>) ((lv, upper) => this.floatingSkillDialogObject.setSkillLv(lv, upper));
    }
    if ((UnityEngine.Object) this.gearKindIconObject == (UnityEngine.Object) null)
    {
      this.gearKindIconObject = prefabs[1].Clone(this.dyn_WeaponType.transform);
      this.gearKindIconObject.GetComponent<UI2DSprite>().depth = this.dyn_WeaponType.depth + 1;
    }
    this.gearKindIconObject.GetComponent<GearKindIcon>().Init(gearGear2.kind, element2);
    if (playerUnit.equippedGear2 != (PlayerItem) null)
    {
      if ((UnityEngine.Object) this.secondGearKindIconObject == (UnityEngine.Object) null)
      {
        this.secondGearKindIconObject = prefabs[1].Clone(this.dyn_SecondWeaponType.transform);
        this.secondGearKindIconObject.GetComponent<UI2DSprite>().depth = this.dyn_SecondWeaponType.depth + 1;
      }
      this.secondGearKindIconObject.GetComponent<GearKindIcon>().Init(gearGear1.kind, element1);
    }
    this.txt_WeaponRange.SetTextLocalize(string.Format("{0}-{1}", (object) gearGear2.min_range, (object) gearGear2.max_range));
    SPAtkTypeIcon component1 = prefabs[3].GetComponent<SPAtkTypeIcon>();
    this.dyn_WeaponSpType01.gameObject.SetActive(false);
    this.dyn_WeaponSpType02.gameObject.SetActive(false);
    UnitFamily[] specialAttackTargets1 = gearGear2.SpecialAttackTargets;
    if (specialAttackTargets1.Length != 0)
    {
      component1.InitKindId(specialAttackTargets1[0]);
      this.dyn_WeaponSpType01.gameObject.SetActive(true);
      this.dyn_WeaponSpType01.sprite2D = component1.iconSprite.sprite2D;
    }
    if (specialAttackTargets1.Length > 1)
    {
      component1.InitKindId(specialAttackTargets1[1]);
      this.dyn_WeaponSpType02.gameObject.SetActive(true);
      this.dyn_WeaponSpType02.sprite2D = component1.iconSprite.sprite2D;
    }
    if (playerUnit.equippedGear2 != (PlayerItem) null)
    {
      this.txt_SecondWeaponRange.SetTextLocalize(string.Format("{0}-{1}", (object) gearGear1.min_range, (object) gearGear1.max_range));
      SPAtkTypeIcon component2 = prefabs[3].GetComponent<SPAtkTypeIcon>();
      this.dyn_SecondWeaponSpType01.gameObject.SetActive(false);
      this.dyn_SecondWeaponSpType02.gameObject.SetActive(false);
      UnitFamily[] specialAttackTargets2 = gearGear2.SpecialAttackTargets;
      if (specialAttackTargets2.Length != 0)
      {
        component2.InitKindId(specialAttackTargets2[0]);
        this.dyn_SecondWeaponSpType01.gameObject.SetActive(true);
        this.dyn_SecondWeaponSpType02.sprite2D = component2.iconSprite.sprite2D;
      }
      if (specialAttackTargets2.Length > 1)
      {
        component2.InitKindId(specialAttackTargets2[1]);
        this.dyn_SecondWeaponSpType01.gameObject.SetActive(true);
        this.dyn_SecondWeaponSpType02.sprite2D = component2.iconSprite.sprite2D;
      }
    }
    UIButton component3 = this.dyn_WeaponType.transform.parent.gameObject.GetComponent<UIButton>();
    component3.tweenTarget = (GameObject) null;
    component3.onClick.Clear();
    if (gearGear2.skills.Length != 0)
    {
      GearGearSkill targetSkill = gearGear2.skills[0];
      EventDelegate.Add(component3.onClick, (EventDelegate.Callback) (() =>
      {
        this.showSkillDialog(targetSkill.skill);
        this.showSkillLevel(targetSkill.skill_level, targetSkill.skill.upper_level);
      }));
    }
    if (playerUnit.equippedGear2 != (PlayerItem) null)
    {
      UIButton component2 = this.dyn_SecondWeaponType.transform.parent.gameObject.GetComponent<UIButton>();
      component2.tweenTarget = (GameObject) null;
      component2.onClick.Clear();
      if (gearGear1.skills.Length != 0)
      {
        GearGearSkill targetSkill = gearGear1.skills[0];
        EventDelegate.Add(component2.onClick, (EventDelegate.Callback) (() =>
        {
          this.showSkillDialog(targetSkill.skill);
          this.showSkillLevel(targetSkill.skill_level, targetSkill.skill.upper_level);
        }));
      }
    }
    if (this.magicButtons != null)
      ((IEnumerable<UIButton>) this.magicButtons).ForEach<UIButton>((System.Action<UIButton>) (x =>
      {
        if (!((UnityEngine.Object) x != (UnityEngine.Object) null))
          return;
        x.onClick.Clear();
      }));
    this.magicButtons = new UIButton[this.txt_MagicNames.Length];
    int i = 0;
    foreach (GameObject gameObject in this.magicElemmentObject)
    {
      if ((UnityEngine.Object) gameObject != (UnityEngine.Object) null)
        gameObject.SetActive(false);
    }
    ((IEnumerable<PlayerUnitSkills>) skills).ForEach<PlayerUnitSkills>((System.Action<PlayerUnitSkills>) (magic =>
    {
      if (magic.skill.skill_type != BattleskillSkillType.magic)
        return;
      if (i < this.txt_MagicNames.Length)
      {
        this.txt_MagicNames[i].SetTextLocalize(magic.skill.name);
        this.txt_MagicRanges[i].SetTextLocalize(magic.skill.min_range.ToString() + "-" + (object) magic.skill.max_range);
        this.txt_MagicRanges[i].gameObject.SetActive(true);
        this.dyn_MagicElementTypes[i].gameObject.SetActive(true);
        if ((UnityEngine.Object) this.magicElemmentObject[i] == (UnityEngine.Object) null)
          this.magicElemmentObject[i] = this.createIcon(prefabs[2], this.dyn_MagicElementTypes[i].transform);
        this.magicElemmentObject[i].SetActive(true);
        this.magicElemmentObject[i].GetComponent<CommonElementIcon>().Init(magic.skill.element);
        this.dyn_MagicSpTypes01[i].gameObject.SetActive(true);
        this.dyn_MagicSpTypes02[i].gameObject.SetActive(true);
        this.magicButtons[i] = this.txt_MagicNames[i].transform.parent.gameObject.GetComponent<UIButton>();
        EventDelegate.Add(this.magicButtons[i].onClick, (EventDelegate.Callback) (() =>
        {
          this.showSkillDialog(magic.skill);
          this.showSkillLevel(0, 0);
        }));
      }
      ++i;
    }));
    for (; i < this.txt_MagicNames.Length; ++i)
    {
      this.txt_MagicNames[i].SetTextLocalize("-");
      this.txt_MagicRanges[i].gameObject.SetActive(false);
      this.dyn_MagicElementTypes[i].gameObject.SetActive(false);
      this.dyn_MagicSpTypes01[i].gameObject.SetActive(false);
      this.dyn_MagicSpTypes02[i].gameObject.SetActive(false);
    }
    yield break;
  }

  private GameObject createIcon(GameObject prefab, Transform trans)
  {
    trans.Clear();
    GameObject gameObject = prefab.Clone(trans);
    UI2DSprite componentInChildren1 = gameObject.GetComponentInChildren<UI2DSprite>();
    BoxCollider componentInChildren2 = trans.GetComponentInChildren<BoxCollider>();
    UI2DSprite componentInChildren3 = trans.GetComponentInChildren<UI2DSprite>();
    componentInChildren1.SetDimensions((int) componentInChildren2.size.x, (int) componentInChildren2.size.y);
    componentInChildren1.depth = componentInChildren3.depth + 1;
    return gameObject;
  }

  private void SetGearNameAnimation(PlayerUnit pu)
  {
    if ((UnityEngine.Object) this.tweenAlphaFirstWeapon == (UnityEngine.Object) null || (UnityEngine.Object) this.tweenAlphaSecondWeapon == (UnityEngine.Object) null)
      return;
    PlayerItem equippedGear = pu.equippedGear;
    PlayerItem equippedGear2 = pu.equippedGear2;
    this.tweenAlphaFirstWeapon.gameObject.SetActive(true);
    this.tweenAlphaSecondWeapon.gameObject.SetActive(equippedGear2 != (PlayerItem) null);
    this.tweenAlphaFirstWeapon.enabled = false;
    this.tweenAlphaSecondWeapon.enabled = false;
    if (equippedGear != (PlayerItem) null && equippedGear2 != (PlayerItem) null)
    {
      this.tweenAlphaFirstWeapon.ResetToBeginning();
      this.tweenAlphaSecondWeapon.ResetToBeginning();
      this.tweenAlphaFirstWeapon.PlayForward();
      this.tweenAlphaSecondWeapon.PlayForward();
    }
    else if (pu.unit.awake_unit_flag)
    {
      if (equippedGear == (PlayerItem) null && equippedGear2 != (PlayerItem) null)
      {
        this.tweenAlphaFirstWeapon.gameObject.SetActive(false);
        this.tweenAlphaSecondWeapon.GetComponent<UIWidget>().alpha = 1f;
      }
      else
      {
        if (!(equippedGear != (PlayerItem) null) || !(equippedGear2 == (PlayerItem) null))
          return;
        this.tweenAlphaSecondWeapon.gameObject.SetActive(false);
        this.tweenAlphaFirstWeapon.GetComponent<UIWidget>().alpha = 1f;
      }
    }
    else
    {
      this.tweenAlphaFirstWeapon.GetComponent<UIWidget>().alpha = 1f;
      this.tweenAlphaSecondWeapon.GetComponent<UIWidget>().alpha = 0.0f;
    }
  }

  private void StartWeaponNameAnim()
  {
    this.tweenAlphaFirstWeapon.PlayForward();
    this.tweenAlphaSecondWeapon.PlayForward();
  }
}
