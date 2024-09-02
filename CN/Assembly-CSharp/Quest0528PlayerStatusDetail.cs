// Decompiled with JetBrains decompiler
// Type: Quest0528PlayerStatusDetail
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest0528PlayerStatusDetail : BackButtonMenuBase
{
  private const int WEAPON_SKILL_ICON_ID = 8;
  private const int WEAPON_ELEMENT_ICON_ID = 0;
  private const string MAGIC_BULLET_NONE_NAME = "-";
  private static Dictionary<PlayerUnit, Sprite> spriteCache = new Dictionary<PlayerUnit, Sprite>();
  [SerializeField]
  protected NGTweenGaugeScale hpGauge;
  [SerializeField]
  protected GameObject[] dir_ForceHeader;
  [SerializeField]
  protected NGxMaskSprite link_CharacterMask;
  [SerializeField]
  protected Transform characterTransform;
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
  protected UILabel txt_Fighting;
  [SerializeField]
  protected UILabel txt_Matk;
  [SerializeField]
  protected UILabel txt_Mdef;
  [SerializeField]
  protected UILabel txt_Movement;
  [SerializeField]
  protected UILabel txt_Agility;
  [SerializeField]
  protected UILabel txt_Luck;
  [SerializeField]
  protected UILabel txt_Magic;
  [SerializeField]
  protected UILabel txt_Power;
  [SerializeField]
  protected UILabel txt_Stability;
  [SerializeField]
  protected UILabel txt_Spirit;
  [SerializeField]
  protected UILabel txt_Technique;
  [SerializeField]
  protected UILabel txt_CharacterName;
  [SerializeField]
  protected UILabel txt_Lv;
  [SerializeField]
  protected UILabel txt_Hp;
  [SerializeField]
  protected UILabel txt_Hpmax;
  [SerializeField]
  protected UILabel txt_Jobname;
  [SerializeField]
  protected Transform weaponGearKindIconParent;
  [SerializeField]
  protected Transform shieldGearKindIconParent;
  [SerializeField]
  protected Transform weaponEquipKindIconParent;
  [SerializeField]
  protected Transform[] skillTypeIconParent;
  [SerializeField]
  protected Transform[] elementTypeIconParent;
  [SerializeField]
  protected UILabel[] txt_Magic_name;
  [SerializeField]
  protected UILabel[] txt_Magic_range;
  [SerializeField]
  protected Transform[] spaTypeIconParent1;
  [SerializeField]
  protected Transform[] spaTypeIconParent2;
  [SerializeField]
  protected Transform gearProfiencyIconParentW;
  [SerializeField]
  protected Transform gearProfiencyIconParentS;
  [SerializeField]
  protected GameObject backGround;
  [SerializeField]
  protected GameObject LeaderSkillBtn;
  [SerializeField]
  protected GameObject SkillDialogRoot;
  [SerializeField]
  protected UISprite[] SkillIconBase;
  private GameObject gearKindIcon01;
  private GameObject gearKindIcon02;
  private GameObject weaponEquipIcon;
  private GameObject weaponSkillIcon;
  private GameObject skillDialog;
  private GameObject gearProfiencyIconW;
  private GameObject gearProfiencyIconS;
  private GameObject[] elementTypeIcon = new GameObject[5];
  private GameObject[] spaTypeIcon1 = new GameObject[5];
  private GameObject[] spaTypeIcon2 = new GameObject[5];
  private GameObject[] skillTypeIcon = new GameObject[10];
  private GameObject skillTypeIconPrefab;
  private GameObject skillDialogPrefab;
  private GameObject gearProfiencyIconPrefab;
  private GameObject elementTypeIconPrefab;
  private GameObject spaTypeIconPrefab;
  private GameObject gearKindIconPrefab;
  private List<PlayerUnitSkills> dispSkills;
  private List<PlayerUnitSkills> dispMagicBullets;
  private PlayerItem dispWeapon;
  private PlayerUnitLeader_skills dispLeaderSkill;

  public static void ClearCache() => Quest0528PlayerStatusDetail.spriteCache.Clear();

  [DebuggerHidden]
  public static IEnumerator LoadIcon(PlayerUnit v)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0528PlayerStatusDetail.\u003CLoadIcon\u003Ec__Iterator74F()
    {
      v = v,
      \u003C\u0024\u003Ev = v
    };
  }

  [DebuggerHidden]
  public IEnumerator ResourcePreLoad()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0528PlayerStatusDetail.\u003CResourcePreLoad\u003Ec__Iterator750()
    {
      \u003C\u003Ef__this = this
    };
  }

  private GameObject CreateIcon(GameObject prefab, Transform trans)
  {
    trans.Clear();
    GameObject icon = prefab.Clone(trans);
    UI2DSprite componentInChildren1 = icon.GetComponentInChildren<UI2DSprite>();
    UI2DSprite componentInChildren2 = ((Component) trans).GetComponentInChildren<UI2DSprite>();
    componentInChildren1.SetDimensions(componentInChildren2.width, componentInChildren2.height);
    componentInChildren1.depth = this.backGround.GetComponentInChildren<UISprite>().depth + 100;
    return icon;
  }

  [DebuggerHidden]
  private IEnumerator CreateMaskdCharacter(PlayerUnit v)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0528PlayerStatusDetail.\u003CCreateMaskdCharacter\u003Ec__Iterator751()
    {
      v = v,
      \u003C\u0024\u003Ev = v,
      \u003C\u003Ef__this = this
    };
  }

  private void SetSkillIconBaseSprite()
  {
    foreach (UISprite uiSprite in this.SkillIconBase)
      uiSprite.spriteName = "slc_skill_icon_base_unit_zero_60_62.png__GUI__common__common_prefab";
  }

  [DebuggerHidden]
  public IEnumerator Init(PlayerUnit unit, BL.ForceID forceID)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0528PlayerStatusDetail.\u003CInit\u003Ec__Iterator752()
    {
      unit = unit,
      forceID = forceID,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u0024\u003EforceID = forceID,
      \u003C\u003Ef__this = this
    };
  }

  public void OnButtonSkillProc(int idx)
  {
    if (Object.op_Equality((Object) this.skillTypeIcon[idx], (Object) null) || Object.op_Equality((Object) this.skillDialog, (Object) null))
      return;
    this.skillDialog.SetActive(true);
    Battle0171111Event componentInChildren = this.skillDialog.GetComponentInChildren<Battle0171111Event>();
    if (!Object.op_Inequality((Object) null, (Object) componentInChildren))
      return;
    componentInChildren.setSkillProperty(true);
    componentInChildren.setData(this.dispSkills[idx].skill);
    componentInChildren.setSkillLv(this.dispSkills[idx].level, this.dispSkills[idx].skill.upper_level);
    componentInChildren.Show();
  }

  public void onButtonSkill1() => this.OnButtonSkillProc(0);

  public void onButtonSkill2() => this.OnButtonSkillProc(1);

  public void onButtonSkill3() => this.OnButtonSkillProc(2);

  public void onButtonSkill4() => this.OnButtonSkillProc(3);

  public void onButtonSkill5() => this.OnButtonSkillProc(4);

  public void onButtonSkill6() => this.OnButtonSkillProc(5);

  public void onButtonSkill7() => this.OnButtonSkillProc(6);

  public void onButtonSkill8() => this.OnButtonSkillProc(7);

  public void onButtonSkillLeader()
  {
    if (this.dispLeaderSkill == null || Object.op_Equality((Object) this.skillDialog, (Object) null))
      return;
    this.skillDialog.SetActive(true);
    Battle0171111Event componentInChildren = this.skillDialog.GetComponentInChildren<Battle0171111Event>();
    if (!Object.op_Inequality((Object) null, (Object) componentInChildren))
      return;
    componentInChildren.setSkillProperty(false);
    componentInChildren.setData(this.dispLeaderSkill.skill);
    componentInChildren.setSkillLv(this.dispLeaderSkill.level, this.dispLeaderSkill.skill.upper_level);
    componentInChildren.Show();
  }

  public void onButtonSkillw(int id)
  {
    if (Object.op_Equality((Object) this.skillTypeIcon[8 + id], (Object) null) || Object.op_Equality((Object) this.skillDialog, (Object) null))
      return;
    this.skillDialog.SetActive(true);
    Battle0171111Event componentInChildren = this.skillDialog.GetComponentInChildren<Battle0171111Event>();
    if (!Object.op_Inequality((Object) null, (Object) componentInChildren))
      return;
    componentInChildren.setSkillProperty(true);
    componentInChildren.setData(this.dispWeapon.skills[id].skill);
    componentInChildren.setSkillLv(this.dispWeapon.skills[id].skill_level, this.dispWeapon.skills[id].skill.upper_level);
    componentInChildren.Show();
  }

  public void onButtonSkillw1() => this.onButtonSkillw(0);

  public void onButtonSkillw2() => this.onButtonSkillw(1);

  private void DispMagicBulletDetailDialog(int index)
  {
    if (index - 1 < 0 || this.dispMagicBullets.Count < index || Object.op_Equality((Object) this.skillDialog, (Object) null))
      return;
    this.skillDialog.SetActive(true);
    Battle0171111Event componentInChildren = this.skillDialog.GetComponentInChildren<Battle0171111Event>();
    if (!Object.op_Inequality((Object) null, (Object) componentInChildren))
      return;
    componentInChildren.setData(this.dispMagicBullets[index - 1].skill);
    componentInChildren.setSkillLv(this.dispMagicBullets[index - 1].level, this.dispMagicBullets[index - 1].skill.upper_level);
    componentInChildren.Show();
  }

  public void onButtonMB1() => this.DispMagicBulletDetailDialog(1);

  public void onButtonMB2() => this.DispMagicBulletDetailDialog(2);

  public void onButtonMB3() => this.DispMagicBulletDetailDialog(3);

  public void onButtonMB4() => this.DispMagicBulletDetailDialog(4);

  public void onClose() => Singleton<PopupManager>.GetInstance().onDismiss();

  public override void onBackButton() => this.onClose();
}
