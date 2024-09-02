// Decompiled with JetBrains decompiler
// Type: Unit00443indicator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Unit00443indicator : MonoBehaviour
{
  private const int GEAR_GUN = 5;
  private const int GEAR_WAND = 6;
  [SerializeField]
  protected UILabel TxtAttack;
  [SerializeField]
  protected UILabel TxtCritical;
  [SerializeField]
  protected UILabel TxtDefense;
  [SerializeField]
  protected UILabel TxtDexterity;
  [SerializeField]
  protected UILabel TxtEvasion;
  [SerializeField]
  protected UILabel TxtExp;
  [SerializeField]
  protected UILabel TxtMagicAttack;
  [SerializeField]
  protected UILabel TxtMagicDefense;
  [SerializeField]
  protected UILabel TxtRange;
  [SerializeField]
  protected UILabel TxtWait;
  [SerializeField]
  protected UILabel TxtWeapontype;
  [SerializeField]
  protected UISprite SlcGauge;
  [SerializeField]
  public GearKindIcon Weapon;
  [SerializeField]
  public SPAtkTypeIcon WeaponSpAttack01;
  [SerializeField]
  public SPAtkTypeIcon WeaponSpAttack02;
  [SerializeField]
  protected GameObject SkillOne_Root;
  [SerializeField]
  protected UIWidget[] SkillOne_Object;
  [SerializeField]
  protected UIButton[] SkillOne_Buttons;
  [SerializeField]
  protected GameObject SkillTwo_Root;
  [SerializeField]
  protected UIWidget[] SkillTwo_Object;
  [SerializeField]
  protected UIButton[] SkillTwo_Buttons;
  [SerializeField]
  protected GameObject SkillArrow_Object;
  private GameObject WeaponSkillPrefab;
  private GameObject SkillDialog;
  [SerializeField]
  private GameObject floatingSkillDialog;
  private Action<GearGearSkill, bool> showSkillDialog;

  [DebuggerHidden]
  public IEnumerator InitSkillDialog()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00443indicator.\u003CInitSkillDialog\u003Ec__Iterator274()
    {
      \u003C\u003Ef__this = this
    };
  }

  public virtual void Init(GearGear gear)
  {
    this.SetParam(gear);
    this.SetSkillDeteilEvent(gear);
    this.SetSpecialAttack(gear);
    this.Weapon.Init(gear.kind_GearKind, gear.GetElement());
  }

  public void Init(PlayerItem targetGear)
  {
    Judgement.GearParameter gearParam = Judgement.GearParameter.FromPlayerGear(targetGear);
    this.SetParam(targetGear.gear, gearParam, targetGear.gear_level, targetGear.gear_level_limit);
    this.SetSkillDeteilEvent(targetGear);
    this.SetSpecialAttack(targetGear.gear);
    this.Weapon.Init(targetGear.gear.kind_GearKind, targetGear.GetElement());
    float num = (float) this.SlcGauge.width * ((float) targetGear.gear_exp / (float) (targetGear.gear_exp_next + targetGear.gear_exp));
    if ((double) num == 0.0)
    {
      ((Component) this.SlcGauge).gameObject.SetActive(false);
    }
    else
    {
      ((Component) this.SlcGauge).gameObject.SetActive(true);
      this.SlcGauge.width = (int) num;
    }
  }

  protected void SetParam(
    GearGear gear,
    Judgement.GearParameter gearParam = null,
    int gear_level = 1,
    int gear_level_limit = 5)
  {
    if (gearParam == null)
      gearParam = new Judgement.GearParameter();
    if (gear.kind_GearKind != 5 && gear.kind_GearKind != 6)
    {
      this.SetParam(this.TxtAttack, gear.power, gearParam.Power);
      this.TxtMagicAttack.SetTextLocalize(0);
    }
    else
    {
      this.TxtAttack.SetTextLocalize(0);
      this.SetParam(this.TxtMagicAttack, gear.power, gearParam.Power);
    }
    this.SetParam(this.TxtCritical, gear.critical, gearParam.Critical);
    this.SetParam(this.TxtDexterity, gear.hit, gearParam.Dexterity);
    this.SetParam(this.TxtDefense, gear.physical_defense, gearParam.PhysicalDefense);
    this.SetParam(this.TxtMagicDefense, gear.magic_defense, gearParam.MagicDefense);
    this.SetParam(this.TxtEvasion, gear.evasion, gearParam.Evasion);
    this.TxtRange.SetTextLocalize(gear.min_range.ToString() + "-" + gear.max_range.ToString());
    this.TxtWait.SetTextLocalize(gear.weight);
    if (Object.op_Inequality((Object) this.TxtExp, (Object) null))
      this.TxtExp.SetTextLocalize(Consts.Lookup("BUGU_0059_RANK", (IDictionary) new Hashtable()
      {
        {
          (object) "now",
          (object) gear_level
        },
        {
          (object) "max",
          (object) gear_level_limit
        }
      }));
    this.TxtWeapontype.SetText(gear.kind.name);
  }

  private void SetParam(UILabel label, int baseParam, int rankParam)
  {
    if (baseParam < rankParam)
    {
      label.SetTextLocalize(rankParam);
      label.color = Color.green;
    }
    else
      label.SetTextLocalize(baseParam);
  }

  protected void SetSkillDialog(UIButton button, GearGearSkill skill_data, bool isRelease)
  {
    if (this.showSkillDialog == null)
    {
      Battle0171111Event dialog = this.SkillDialog.Clone(this.floatingSkillDialog.transform).GetComponentInChildren<Battle0171111Event>();
      ((Component) ((Component) dialog).transform.parent).gameObject.SetActive(false);
      this.showSkillDialog = (Action<GearGearSkill, bool>) ((skill, release) =>
      {
        dialog.setData(skill.skill);
        if (release)
          dialog.setSkillLv(skill.skill_level, skill.skill.upper_level);
        else
          dialog.setSkillLv(0, skill.skill.upper_level);
        dialog.Show();
      });
    }
    EventDelegate.Set(button.onClick, (EventDelegate.Callback) (() => this.showSkillDialog(skill_data, isRelease)));
  }

  protected void SetSkillDeteilEvent(GearGear gear)
  {
    UIWidget[] uiWidgetArray = this.SkillOne_Object;
    UIButton[] uiButtonArray = this.SkillOne_Buttons;
    this.SkillOne_Root.SetActive(true);
    this.SkillTwo_Root.SetActive(false);
    if (gear.rememberSkills.Count <= 0)
      return;
    bool flag1 = gear.rememberSkills.Count > 1;
    bool flag2 = gear.rememberSkills[0].Count > 1;
    if (flag1 || flag2)
    {
      uiWidgetArray = this.SkillTwo_Object;
      uiButtonArray = this.SkillTwo_Buttons;
      this.SkillOne_Root.SetActive(false);
      this.SkillTwo_Root.SetActive(true);
    }
    if (flag1)
    {
      for (int index = 0; index < gear.rememberSkills.Count && uiWidgetArray.Length >= index; ++index)
      {
        BattleSkillIcon component = this.WeaponSkillPrefab.Clone(((Component) uiWidgetArray[index]).transform).GetComponent<BattleSkillIcon>();
        component.SetDepth(uiWidgetArray[index].depth + 1);
        component.EnableNeedRankIcon(gear.rememberSkills[index][0].release_rank);
        this.StartCoroutine(component.Init(gear.rememberSkills[index][0].skill));
        this.SetSkillDialog(uiButtonArray[index], gear.rememberSkills[index][0], false);
      }
    }
    else
    {
      for (int index = 0; index < gear.rememberSkills[0].Count && uiWidgetArray.Length >= index; ++index)
      {
        GameObject gameObject = this.WeaponSkillPrefab.Clone(((Component) uiWidgetArray[index]).transform);
        BattleSkillIcon component = gameObject.GetComponent<BattleSkillIcon>();
        component.SetDepth(uiWidgetArray[index].depth + 1);
        component.EnableNeedRankIcon(gear.rememberSkills[0][index].release_rank);
        this.StartCoroutine(gameObject.GetComponent<BattleSkillIcon>().Init(gear.rememberSkills[0][index].skill));
        this.SetSkillDialog(uiButtonArray[index], gear.rememberSkills[0][index], false);
      }
    }
    this.SkillArrow_Object.SetActive(flag2);
  }

  protected void SetSkillDeteilEvent(PlayerItem gear)
  {
    UIWidget[] uiWidgetArray = this.SkillOne_Object;
    UIButton[] uiButtonArray = this.SkillOne_Buttons;
    this.SkillOne_Root.SetActive(true);
    this.SkillTwo_Root.SetActive(false);
    GearGear gear1 = gear.gear;
    if (gear1.rememberSkills.Count <= 0)
      return;
    GearGearSkill[] skills = gear.skills;
    bool flag1 = gear1.rememberSkills.Count > skills.Length;
    bool flag2 = !flag1 && gear1.rememberSkills[0].Count > 0 && !gear1.rememberSkills[0].All<GearGearSkill>((Func<GearGearSkill, bool>) (x => x.isReleased(gear)));
    if ((flag1 || flag2 || gear.skills.Length > 1) && (gear1.rememberSkills.Count > 1 || gear1.rememberSkills.Count == 1 && gear1.rememberSkills[0].Count > 1))
    {
      uiWidgetArray = this.SkillTwo_Object;
      uiButtonArray = this.SkillTwo_Buttons;
      this.SkillOne_Root.SetActive(false);
      this.SkillTwo_Root.SetActive(true);
    }
    if (flag1)
    {
      for (int index = 0; index < gear1.rememberSkills.Count && uiWidgetArray.Length > index; ++index)
      {
        BattleSkillIcon component = this.WeaponSkillPrefab.Clone(((Component) uiWidgetArray[index]).transform).GetComponent<BattleSkillIcon>();
        component.SetDepth(uiWidgetArray[index].depth + 1);
        component.EnableNeedRankIcon(gear1.rememberSkills[index][0].release_rank);
        this.StartCoroutine(component.Init(gear1.rememberSkills[index][0].skill));
        this.SetSkillDialog(uiButtonArray[index], gear1.rememberSkills[index][0], gear1.rememberSkills[index][0].isReleased(gear));
      }
    }
    else if (flag2)
    {
      for (int index = 0; index < gear1.rememberSkills[0].Count && uiWidgetArray.Length > index; ++index)
      {
        BattleSkillIcon component = this.WeaponSkillPrefab.Clone(((Component) uiWidgetArray[index]).transform).GetComponent<BattleSkillIcon>();
        component.EnableNeedRankIcon(gear1.rememberSkills[0][index].release_rank);
        component.SetDepth(uiWidgetArray[index].depth + 1);
        this.StartCoroutine(component.Init(gear1.rememberSkills[0][index].skill));
        this.SetSkillDialog(uiButtonArray[index], gear1.rememberSkills[0][index], gear1.rememberSkills[0][index].isReleased(gear));
      }
    }
    else
    {
      for (int index = 0; index < gear.skills.Length && uiWidgetArray.Length > index; ++index)
      {
        BattleSkillIcon component = this.WeaponSkillPrefab.Clone(((Component) uiWidgetArray[index]).transform).GetComponent<BattleSkillIcon>();
        component.SetDepth(uiWidgetArray[index].depth + 1);
        this.StartCoroutine(component.Init(gear.skills[index].skill));
        this.SetSkillDialog(uiButtonArray[index], gear.skills[index], true);
      }
    }
    this.SkillArrow_Object.SetActive(flag2);
  }

  protected void SetSpecialAttack(GearGear gear)
  {
    UnitFamily[] specialAttackTargets = gear.SpecialAttackTargets;
    if (specialAttackTargets.Length >= 1)
    {
      this.WeaponSpAttack01.InitKindId(specialAttackTargets[0]);
      if (specialAttackTargets.Length != 2)
        return;
      this.WeaponSpAttack02.InitKindId(specialAttackTargets[1]);
    }
    else
    {
      this.WeaponSpAttack01.InitKindNone();
      this.WeaponSpAttack02.InitKindNone();
    }
  }

  private void SetSpecialAttackText(GearGear gear)
  {
    UnitFamily[] specialAttackTargets = gear.SpecialAttackTargets;
    if (specialAttackTargets.Length >= 1)
    {
      this.WeaponSpAttack01.InitKindId(specialAttackTargets[0]);
      if (specialAttackTargets.Length != 2)
        return;
      this.WeaponSpAttack02.InitKindId(specialAttackTargets[1]);
    }
    else
    {
      this.WeaponSpAttack01.InitKindNone();
      this.WeaponSpAttack02.InitKindNone();
    }
  }
}
