// Decompiled with JetBrains decompiler
// Type: Unit00441Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Unit00441Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtAttackLeft;
  [SerializeField]
  protected UILabel TxtMagicAttackLeft;
  [SerializeField]
  protected UILabel TxtDefenseLeft;
  [SerializeField]
  protected UILabel TxtMagicDefenseLeft;
  [SerializeField]
  protected UILabel TxtDexterityLeft;
  [SerializeField]
  protected UILabel TxtCriticalLeft;
  [SerializeField]
  protected UILabel TxtEvasionLeft;
  [SerializeField]
  protected UILabel TxtWaitLeft;
  [SerializeField]
  protected UILabel TxtRangeMinLeft;
  [SerializeField]
  protected UILabel TxtRangeMaxLeft;
  [SerializeField]
  protected UILabel TxtRangeLeft;
  [SerializeField]
  protected UILabel TxtAttackRight;
  [SerializeField]
  protected UILabel TxtMagicAttackRight;
  [SerializeField]
  protected UILabel TxtDefenseRight;
  [SerializeField]
  protected UILabel TxtMagicDefenseRight;
  [SerializeField]
  protected UILabel TxtDexterityRight;
  [SerializeField]
  protected UILabel TxtCriticalRight;
  [SerializeField]
  protected UILabel TxtEvasionRight;
  [SerializeField]
  protected UILabel TxtWaitRight;
  [SerializeField]
  protected UILabel TxtRangeMinRight;
  [SerializeField]
  protected UILabel TxtRangeMaxRight;
  [SerializeField]
  protected UILabel TxtRangeRight;
  [SerializeField]
  private Popup00441AddEffect StatusGaugeHp;
  [SerializeField]
  private Popup00441AddEffect StatusGaugeAttack;
  [SerializeField]
  private Popup00441AddEffect StatusGaugeMagicAttack;
  [SerializeField]
  private Popup00441AddEffect StatusGaugeDefense;
  [SerializeField]
  private Popup00441AddEffect StatusGaugeMental;
  [SerializeField]
  private Popup00441AddEffect StatusGaugeSpeed;
  [SerializeField]
  private Popup00441AddEffect StatusGaugeTechnique;
  [SerializeField]
  private Popup00441AddEffect StatusGaugeLucky;
  [SerializeField]
  protected GameObject BeforeGear;
  [SerializeField]
  protected GameObject AfterGear;
  [SerializeField]
  protected GameObject BeforeSkill_One_Base;
  [SerializeField]
  protected UIWidget[] BeforeSkill_One;
  [SerializeField]
  protected UIButton[] BeforeSkill_One_Button;
  [SerializeField]
  protected GameObject AfterSkill_One_Base;
  [SerializeField]
  protected UIWidget[] AfterSkill_One;
  [SerializeField]
  protected UIButton[] AfterSkill_One_Button;
  [SerializeField]
  protected GameObject BeforeSkill_Two_Base;
  [SerializeField]
  protected UIWidget[] BeforeSkill_Two;
  [SerializeField]
  protected UIButton[] BeforeSkill_Two_Button;
  [SerializeField]
  protected GameObject AfterSkill_Two_Base;
  [SerializeField]
  protected UIWidget[] AfterSkill_Two;
  [SerializeField]
  protected UIButton[] AfterSkill_Two_Button;
  private PlayerUnit basePlayerUnit;
  private PlayerItem afterGearItem;
  private int changeUnitID;
  private int changeGearIndex;
  private bool isEarthMode;
  [SerializeField]
  private GameObject SkillDialog;
  [SerializeField]
  private GameObject floatingSkillDialog;
  private Action<GearGearSkill> showSkillDialog;

  private Color GetStrColor(int before, int after)
  {
    Color white = Color.white;
    if (before < after)
    {
      // ISSUE: explicit constructor call
      ((Color) ref white).\u002Ector(0.0f, 0.8627451f, 0.117647059f);
    }
    else if (before > after)
    {
      // ISSUE: explicit constructor call
      ((Color) ref white).\u002Ector(0.980392158f, 0.0f, 0.0f);
    }
    return white;
  }

  private IEnumerator setTexture(Future<Sprite> src, UI2DSprite to)
  {
    return src.Then<Sprite>((Func<Sprite, Sprite>) (sprite =>
    {
      Sprite sprite1 = sprite;
      to.sprite2D = sprite1;
      return sprite1;
    })).Wait();
  }

  protected void SetSkillDialogEvent(UIButton button, GearGearSkill skill_data)
  {
    if (this.showSkillDialog == null)
    {
      Battle0171111Event[] componentsInChildren = this.SkillDialog.Clone(this.floatingSkillDialog.transform).GetComponentsInChildren<Battle0171111Event>(true);
      Battle0171111Event dialog = componentsInChildren.Length <= 0 ? (Battle0171111Event) null : componentsInChildren[0];
      if (Object.op_Equality((Object) dialog, (Object) null))
        return;
      ((Component) ((Component) dialog).transform.parent).gameObject.SetActive(false);
      this.showSkillDialog = (Action<GearGearSkill>) (skill =>
      {
        dialog.setData(skill.skill);
        dialog.setSkillLv(skill.skill_level, skill.skill.upper_level);
        dialog.Show();
      });
    }
    EventDelegate.Set(button.onClick, (EventDelegate.Callback) (() => this.showSkillDialog(skill_data)));
  }

  [DebuggerHidden]
  public IEnumerator SetGear(
    int removeUnitID,
    PlayerUnit baseUnit,
    PlayerItem beforeGear,
    PlayerItem afterGear,
    GameObject beforeGearIcon,
    GameObject afterGearIcon,
    GameObject[] beforeSkillIcons,
    GameObject[] afterSkillIcons,
    int index,
    bool isEarth = false)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00441Menu.\u003CSetGear\u003Ec__Iterator2D1()
    {
      isEarth = isEarth,
      removeUnitID = removeUnitID,
      index = index,
      baseUnit = baseUnit,
      afterGear = afterGear,
      beforeGear = beforeGear,
      beforeGearIcon = beforeGearIcon,
      beforeSkillIcons = beforeSkillIcons,
      afterGearIcon = afterGearIcon,
      afterSkillIcons = afterSkillIcons,
      \u003C\u0024\u003EisEarth = isEarth,
      \u003C\u0024\u003EremoveUnitID = removeUnitID,
      \u003C\u0024\u003Eindex = index,
      \u003C\u0024\u003EbaseUnit = baseUnit,
      \u003C\u0024\u003EafterGear = afterGear,
      \u003C\u0024\u003EbeforeGear = beforeGear,
      \u003C\u0024\u003EbeforeGearIcon = beforeGearIcon,
      \u003C\u0024\u003EbeforeSkillIcons = beforeSkillIcons,
      \u003C\u0024\u003EafterGearIcon = afterGearIcon,
      \u003C\u0024\u003EafterSkillIcons = afterSkillIcons,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();

  public void IbtnPopupDecide()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.Equip());
  }

  [DebuggerHidden]
  private IEnumerator Equip()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00441Menu.\u003CEquip\u003Ec__Iterator2D2()
    {
      \u003C\u003Ef__this = this
    };
  }
}
