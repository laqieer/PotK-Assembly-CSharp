// Decompiled with JetBrains decompiler
// Type: Gacha00611Menu
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
using UniLinq;
using UnityEngine;

#nullable disable
public class Gacha00611Menu : EquipmentDetailMenuBase
{
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
  protected UILabel TxtNextExp;
  [SerializeField]
  protected UILabel TxtMagicAttack;
  [SerializeField]
  protected UILabel TxtMagicDefense;
  [SerializeField]
  protected UILabel TxtRange;
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  protected UILabel TxtWait;
  [SerializeField]
  protected UILabel TxtWeapontype;
  [SerializeField]
  public GearKindIcon Weapon;
  [SerializeField]
  public SPAtkTypeIcon WeaponSpAttack01;
  [SerializeField]
  public SPAtkTypeIcon WeaponSpAttack02;
  [SerializeField]
  protected UI2DSprite DynWeaponIll;
  [SerializeField]
  protected Transform DynWeaponModel;
  [SerializeField]
  protected GameObject NewIcon;
  [SerializeField]
  protected UISprite SlcGauge;
  [SerializeField]
  private Transform TopStarPos;
  [SerializeField]
  private GameObject charaThum;
  [SerializeField]
  private UIButton btnBack;
  [SerializeField]
  private GameObject DirAddStauts;
  [SerializeField]
  public GameObject SkillArrowObject;
  [SerializeField]
  public GameObject WeaponSkillOneRoot;
  [SerializeField]
  public UIButton[] WeaponSkillButtonOne;
  [SerializeField]
  public BattleSkillIcon[] WeaponSkillOne;
  [SerializeField]
  public GameObject WeaponSkillTwoRoot;
  [SerializeField]
  public UIButton[] WeaponSkillButtonTwo;
  [SerializeField]
  public BattleSkillIcon[] WeaponSkillTwo;
  public GameObject unitPrefab;
  public GameObject SkillDialog;
  [SerializeField]
  public UI2DSprite rarityStarsIcon;
  [SerializeField]
  private GameObject floatingSkillDialog;
  private Action<GearGearSkill, bool> showSkillDialog;
  [SerializeField]
  private GameObject rankUpObject;
  [SerializeField]
  private GameObject maxRankUpObject;
  private Unit004431Menu.Param sendParam = new Unit004431Menu.Param();
  private bool isRankup;
  private bool isMaxRankup;
  private int maxWidth;
  private Decimal startGauge;
  private Decimal addGauge;
  private int base_gear_level;
  private PlayerItem target;
  private List<GearGearSkill> evoSkill;
  private List<GearGearSkill> addSkill;
  private GameObject skillGetPrefab;
  private static readonly string COLOR_TAG_GREEN = "[00ff00]{0}[-]";
  private static readonly string COLOR_TAG_RED = "[ff0000]{0}[-]";
  private static readonly string COLOR_TAG_YELLOW = "[ffff00]{0}[-]";

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    if (((Component) this.btnBack).GetComponent<Collider>().enabled)
      this.backScene();
    ((Component) this.btnBack).GetComponent<Collider>().enabled = false;
  }

  public UIButton BackSceneButton => this.btnBack;

  [DebuggerHidden]
  public IEnumerator Initialize(
    PlayerItem TargetInfo,
    bool NewFlag,
    bool select = true,
    PlayerItem baseInfo = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha00611Menu.\u003CInitialize\u003Ec__Iterator3D2()
    {
      TargetInfo = TargetInfo,
      select = select,
      baseInfo = baseInfo,
      NewFlag = NewFlag,
      \u003C\u0024\u003ETargetInfo = TargetInfo,
      \u003C\u0024\u003Eselect = select,
      \u003C\u0024\u003EbaseInfo = baseInfo,
      \u003C\u0024\u003ENewFlag = NewFlag,
      \u003C\u003Ef__this = this
    };
  }

  private void SetParameter(UILabel label, int param, int up)
  {
    if (up > 0)
      label.SetTextLocalize(Gacha00611Menu.COLOR_TAG_YELLOW.F((object) param));
    else if (up < 0)
      label.SetTextLocalize(Gacha00611Menu.COLOR_TAG_RED.F((object) param));
    else
      label.SetTextLocalize(param);
  }

  public void StartAnime() => this.StartCoroutine("Play");

  public void StopAnime() => this.StopCoroutine("Play");

  [DebuggerHidden]
  private IEnumerator Play()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha00611Menu.\u003CPlay\u003Ec__Iterator3D3()
    {
      \u003C\u003Ef__this = this
    };
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

  protected void SetSkillDeteilEvent(PlayerItem gear)
  {
    BattleSkillIcon[] battleSkillIconArray = this.WeaponSkillOne;
    UIButton[] uiButtonArray = this.WeaponSkillButtonOne;
    this.WeaponSkillOneRoot.SetActive(true);
    this.WeaponSkillTwoRoot.SetActive(false);
    GearGear gear1 = gear.gear;
    if (gear1.rememberSkills.Count <= 0)
      return;
    GearGearSkill[] skills = gear.skills;
    bool flag1 = gear1.rememberSkills.Count > skills.Length;
    bool flag2 = !flag1 && gear1.rememberSkills[0].Count > 0 && !gear1.rememberSkills[0].All<GearGearSkill>((Func<GearGearSkill, bool>) (x => x.isReleased(gear)));
    if ((flag1 || flag2 || gear1.skills.Length > 1) && (gear1.rememberSkills.Count > 1 || gear1.rememberSkills.Count == 1 && gear1.rememberSkills[0].Count > 1))
    {
      battleSkillIconArray = this.WeaponSkillTwo;
      uiButtonArray = this.WeaponSkillButtonTwo;
      this.WeaponSkillOneRoot.SetActive(false);
      this.WeaponSkillTwoRoot.SetActive(true);
    }
    if (flag1)
    {
      for (int index = 0; index < gear1.rememberSkills.Count && battleSkillIconArray.Length >= index; ++index)
      {
        BattleSkillIcon battleSkillIcon = battleSkillIconArray[index];
        if (gear1.rememberSkills[index][0].release_rank > gear.gear_level)
          battleSkillIcon.EnableNeedRankIcon(gear1.rememberSkills[index][0].release_rank);
        else
          battleSkillIcon.EnableNeedRankIcon(0);
        this.StartCoroutine(battleSkillIcon.Init(gear1.rememberSkills[index][0].skill));
        this.SetSkillDialog(uiButtonArray[index], gear1.rememberSkills[index][0], gear1.rememberSkills[index][0].isReleased(gear));
      }
    }
    else if (flag2)
    {
      for (int index = 0; index < gear1.rememberSkills[0].Count && battleSkillIconArray.Length >= index; ++index)
      {
        BattleSkillIcon battleSkillIcon = battleSkillIconArray[index];
        if (gear1.rememberSkills[0][index].release_rank > gear.gear_level)
          battleSkillIcon.EnableNeedRankIcon(gear1.rememberSkills[0][index].release_rank);
        else
          battleSkillIcon.EnableNeedRankIcon(0);
        this.StartCoroutine(battleSkillIcon.Init(gear1.rememberSkills[0][index].skill));
        this.SetSkillDialog(uiButtonArray[index], gear1.rememberSkills[0][index], gear1.rememberSkills[0][index].isReleased(gear));
      }
    }
    else
    {
      for (int index = 0; index < gear.skills.Length && battleSkillIconArray.Length >= index; ++index)
      {
        this.StartCoroutine(battleSkillIconArray[index].Init(gear.skills[index].skill));
        this.SetSkillDialog(uiButtonArray[index], gear.skills[index], true);
      }
    }
    this.SkillArrowObject.SetActive(flag2);
  }

  public void changeScene() => this.backScene();

  public void choiceUnitChangeScene() => Unit00468Scene.changeScene004431(true, this.sendParam);

  public override void onBackButton() => this.IbtnBack();
}
