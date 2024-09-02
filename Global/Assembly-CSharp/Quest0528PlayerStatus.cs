// Decompiled with JetBrains decompiler
// Type: Quest0528PlayerStatus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest0528PlayerStatus : MonoBehaviour
{
  public NGTweenGaugeScale hpGauge;
  [SerializeField]
  protected SelectParts statusBase;
  [SerializeField]
  protected UIWidget character;
  [SerializeField]
  protected UIWidget weapon;
  [SerializeField]
  protected UILabel txt_CharacterName;
  [SerializeField]
  protected UILabel txt_Lv;
  [SerializeField]
  protected UILabel txt_Fighting;
  [SerializeField]
  protected UILabel txt_Hp;
  [SerializeField]
  protected UILabel txt_Hpmax;
  [SerializeField]
  protected UILabel txt_Jobname;
  [SerializeField]
  protected UILabel txt_Movement;
  [SerializeField]
  protected UILabel txt_Attack;
  [SerializeField]
  protected UILabel txt_Critical;
  [SerializeField]
  protected UILabel txt_Defense;
  [SerializeField]
  protected UILabel txt_Dexterity;
  [SerializeField]
  protected UILabel txt_Evasion;
  [SerializeField]
  protected UILabel txt_Matk;
  [SerializeField]
  protected UILabel txt_Mdef;
  [SerializeField]
  protected UIWidget[] dyn_Ailments;
  [SerializeField]
  protected UIButton[] btn_Ailments;
  private PlayerUnit mUnit;
  private BL.ForceID forceID;
  private UnitIcon unitIcon;
  private GearKindIcon gearIcon;
  private List<BattleSkillIcon> skillIcons;
  private GameObject popupInfoPrefab;
  private Color mGreen = new Color(0.0f, 0.863f, 0.118f);
  private Color mRed = new Color(0.98f, 0.0f, 0.0f);
  private Color mOrigin = new Color(1f, 1f, 1f);

  [DebuggerHidden]
  public IEnumerator Init(
    GameObject normalPrefab,
    GameObject gearKindPrefab,
    GameObject statusDetail,
    GameObject battleSkillIconPrefab,
    GameObject skillDetailDialogPrefab,
    Quest0528Menu.FieldUnitInfo unitInfo)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0528PlayerStatus.\u003CInit\u003Ec__Iterator604()
    {
      statusDetail = statusDetail,
      normalPrefab = normalPrefab,
      gearKindPrefab = gearKindPrefab,
      battleSkillIconPrefab = battleSkillIconPrefab,
      unitInfo = unitInfo,
      \u003C\u0024\u003EstatusDetail = statusDetail,
      \u003C\u0024\u003EnormalPrefab = normalPrefab,
      \u003C\u0024\u003EgearKindPrefab = gearKindPrefab,
      \u003C\u0024\u003EbattleSkillIconPrefab = battleSkillIconPrefab,
      \u003C\u0024\u003EunitInfo = unitInfo,
      \u003C\u003Ef__this = this
    };
  }

  private void CreateUnitIcon(GameObject normalPrefab)
  {
    ((Component) this.character).gameObject.transform.Clear();
    this.unitIcon = normalPrefab.CloneAndGetComponent<UnitIcon>(((Component) this.character).gameObject.transform);
    NGUITools.AdjustDepth(((Component) this.unitIcon).gameObject, this.character.depth);
    this.unitIcon.isViewBackObject = false;
  }

  private void CreateGearKindIcon(GameObject gearKindPrefab)
  {
    ((Component) this.weapon).gameObject.transform.Clear();
    this.gearIcon = gearKindPrefab.CloneAndGetComponent<GearKindIcon>(((Component) this.weapon).gameObject.transform);
    NGUITools.AdjustDepth(((Component) this.gearIcon).gameObject, this.weapon.depth);
    this.gearIcon.SetBasedOnHeight(this.weapon.height);
  }

  private void CreateBattleSkillIcon(GameObject battleSkillIconPrefab)
  {
    this.skillIcons = new List<BattleSkillIcon>();
    foreach (UIWidget dynAilment in this.dyn_Ailments)
    {
      ((Component) dynAilment).gameObject.transform.Clear();
      BattleSkillIcon component = battleSkillIconPrefab.CloneAndGetComponent<BattleSkillIcon>(((Component) dynAilment).gameObject.transform);
      component.SetDepth(dynAilment.depth);
      this.skillIcons.Add(component);
      ((Component) component).gameObject.SetActive(false);
    }
  }

  [DebuggerHidden]
  private IEnumerator doSetIcon(PlayerUnit unit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0528PlayerStatus.\u003CdoSetIcon\u003Ec__Iterator605()
    {
      unit = unit,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator doSetAilmentIcon(int index, BattleskillSkill skill, int? remainTurn)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0528PlayerStatus.\u003CdoSetAilmentIcon\u003Ec__Iterator606()
    {
      skill = skill,
      index = index,
      \u003C\u0024\u003Eskill = skill,
      \u003C\u0024\u003Eindex = index,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetUnitInfo(PlayerUnit unit, int unitType)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0528PlayerStatus.\u003CSetUnitInfo\u003Ec__Iterator607()
    {
      unit = unit,
      unitType = unitType,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u0024\u003EunitType = unitType,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ShowDetailStatusPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0528PlayerStatus.\u003CShowDetailStatusPopup\u003Ec__Iterator608()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onButtonInfo() => this.StartCoroutine(this.ShowDetailStatusPopup());

  private void setColordText(UILabel label, int v, int bd, string before_string = "")
  {
    label.SetTextLocalize(before_string + (object) v);
    if (bd > 0)
      label.color = this.mGreen;
    else if (bd < 0)
      label.color = this.mRed;
    else
      label.color = this.mOrigin;
  }

  private void setColordText_BeforeStringNoColorChange(
    UILabel label,
    int v,
    int bd,
    string before_string = "")
  {
    label.color = this.mOrigin;
    string str = v.ToString();
    string text = bd <= 0 ? (bd >= 0 ? before_string + str : before_string + "[fa0000]" + str + "[-]") : before_string + "[00dc1e]" + str + "[-]";
    label.SetTextLocalize(text);
  }
}
