// Decompiled with JetBrains decompiler
// Type: WithNumber
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class WithNumber : MonoBehaviour
{
  public Collider boxCollider;
  public UIButton button;
  public Transform trans;
  public UIDragScrollView scrollView;
  private WithNumberInfo wni;
  public Transform dir_type;
  public UI2DSprite slc_character;
  public GameObject slc_usilhoutte;
  public GameObject slc_esilhoutte;
  public GameObject slc_unknown;
  public GameObject slc_background;
  public GameObject slc_gearbackground;
  public GameObject slc_customGearbackground;
  public GameObject slc_onlyGearbackground;
  public GameObject gearKindIconPrefab;
  public GearKindIcon gearKindIcon;
  public GameObject slc_num;
  public UILabel txt_num;
  public GameObject slc_hatena;
  public Transform zukanTransform;
  public System.Action pressEvent;

  public WithNumberInfo withNumberInfo
  {
    get => this.wni;
    set => this.wni = value;
  }

  public virtual void pressButton()
  {
    if (this.pressEvent == null)
      return;
    this.pressEvent();
  }

  [DebuggerHidden]
  public IEnumerator CreateIcon()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WithNumber.\u003CCreateIcon\u003Ec__IteratorA9D()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void CreateType(GearKind gearKind, CommonElement element)
  {
    this.NumberPosition(gearKind);
    if (Object.op_Equality((Object) this.gearKindIcon, (Object) null))
      this.gearKindIcon = this.gearKindIconPrefab.Clone(this.dir_type).GetComponent<GearKindIcon>();
    this.gearKindIcon.Init(gearKind, element);
    if (!(this.withNumberInfo.icon.withNumberInfo.unitData.History == new DateTime()))
      return;
    this.gearKindIcon.None();
  }

  public void NumberPosition(GearKind gearKind)
  {
    bool flag = true;
    if (gearKind.Enum == GearKindEnum.smith)
      flag = false;
    if (this.withNumberInfo.icon.withNumberInfo.unitData.Unit != null && this.withNumberInfo.icon.withNumberInfo.unitData.Unit.character.category == UnitCategory.enemy)
      flag = false;
    if (flag)
    {
      this.zukanTransform.localPosition = new Vector3(0.0f, this.zukanTransform.localPosition.y, 0.0f);
    }
    else
    {
      ((Component) this.gearKindIcon).gameObject.SetActive(false);
      this.zukanTransform.localPosition = new Vector3(-12f, this.zukanTransform.localPosition.y, 0.0f);
    }
  }

  private void SetStatus(WithNumber.ZUKAN_STATUS status)
  {
    this.withNumberInfo.icon.withNumberInfo.buttonOn = false;
    ((Behaviour) this.button).enabled = false;
    int num = 0;
    switch (status)
    {
      case WithNumber.ZUKAN_STATUS.NOT_UNKNOWN:
        this.slc_usilhoutte.SetActive(false);
        this.slc_esilhoutte.SetActive(false);
        this.slc_unknown.SetActive(false);
        this.slc_background.SetActive(true);
        ((Component) this.slc_character).gameObject.SetActive(true);
        this.withNumberInfo.icon.withNumberInfo.buttonOn = true;
        num = this.withNumberInfo.icon.withNumberInfo.unitData.Unit.history_group_number % 1000;
        ((Behaviour) this.button).enabled = true;
        break;
      case WithNumber.ZUKAN_STATUS.G_NOT_UNKNOWN:
        this.slc_unknown.SetActive(false);
        this.slc_gearbackground.SetActive(false);
        this.slc_customGearbackground.SetActive(false);
        this.slc_onlyGearbackground.SetActive(false);
        if (this.withNumberInfo.icon.withNumberInfo.unitData.Gear.hasSpecificationOfEquipmentUnits)
          this.slc_onlyGearbackground.SetActive(true);
        else if (this.withNumberInfo.icon.withNumberInfo.unitData.Gear.customize_flag == 0)
          this.slc_gearbackground.SetActive(true);
        else if (this.withNumberInfo.icon.withNumberInfo.unitData.Gear.customize_flag == 1)
          this.slc_customGearbackground.SetActive(true);
        ((Component) this.slc_character).gameObject.SetActive(true);
        this.withNumberInfo.icon.withNumberInfo.buttonOn = true;
        num = this.withNumberInfo.icon.withNumberInfo.unitData.Gear.history_group_number % 1000;
        ((Behaviour) this.button).enabled = true;
        break;
      case WithNumber.ZUKAN_STATUS.U_UNKNOWN:
        this.slc_usilhoutte.SetActive(true);
        this.slc_esilhoutte.SetActive(false);
        this.slc_unknown.SetActive(true);
        this.slc_background.SetActive(false);
        ((Component) this.slc_character).gameObject.SetActive(false);
        num = this.withNumberInfo.icon.withNumberInfo.unitData.Unit.history_group_number % 1000;
        break;
      case WithNumber.ZUKAN_STATUS.E_UNKNOWN:
        this.slc_usilhoutte.SetActive(false);
        this.slc_esilhoutte.SetActive(true);
        this.slc_unknown.SetActive(false);
        this.slc_background.SetActive(false);
        ((Component) this.slc_character).gameObject.SetActive(false);
        num = this.withNumberInfo.icon.withNumberInfo.unitData.Unit.history_group_number % 1000;
        break;
      case WithNumber.ZUKAN_STATUS.G_UNKNOWN:
        this.slc_gearbackground.SetActive(true);
        this.slc_customGearbackground.SetActive(false);
        this.slc_onlyGearbackground.SetActive(false);
        this.slc_unknown.SetActive(true);
        ((Component) this.slc_character).gameObject.SetActive(false);
        num = this.withNumberInfo.icon.withNumberInfo.unitData.Gear.history_group_number % 1000;
        break;
      default:
        this.slc_usilhoutte.SetActive(true);
        this.slc_esilhoutte.SetActive(false);
        this.slc_unknown.SetActive(true);
        this.slc_background.SetActive(false);
        ((Component) this.slc_character).gameObject.SetActive(false);
        break;
    }
    this.slc_num.SetActive(true);
    ((Component) this.txt_num).gameObject.SetActive(true);
    this.txt_num.SetTextLocalize(num.ToString().PadLeft(3, '0'));
    this.slc_hatena.SetActive(false);
  }

  public void SetPressEvent(System.Action evt) => this.pressEvent = evt;

  public void Reset()
  {
  }

  public enum ZUKAN_STATUS
  {
    NOT_UNKNOWN,
    G_NOT_UNKNOWN,
    U_UNKNOWN,
    E_UNKNOWN,
    G_UNKNOWN,
  }
}
