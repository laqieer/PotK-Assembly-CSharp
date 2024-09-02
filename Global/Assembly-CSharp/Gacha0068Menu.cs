// Decompiled with JetBrains decompiler
// Type: Gacha0068Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Gacha0068Menu : BackButtonMenuBase
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
  protected UILabel TxtExpmax;
  [SerializeField]
  protected UILabel TxtFighting;
  [SerializeField]
  protected UILabel TxtHp;
  [SerializeField]
  protected UILabel TxtHpmax;
  [SerializeField]
  protected UILabel TxtJobname;
  [SerializeField]
  protected UILabel TxtMatk;
  [SerializeField]
  protected UILabel TxtMdef;
  [SerializeField]
  protected UILabel TxtCost;
  [SerializeField]
  protected UILabel TxtMovement;
  [SerializeField]
  protected UILabel TxtPrincesstype;
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  private UI2DSprite Character;
  [SerializeField]
  private Transform TopStarPos;
  [SerializeField]
  private Transform WeaponPos;
  [SerializeField]
  private Transform HimePos;
  [SerializeField]
  private GameObject NewIcon;
  [SerializeField]
  private GameObject Model;
  [SerializeField]
  private GameObject ModelPrefab;
  [SerializeField]
  private NGTweenGaugeScale EXPGauge;
  [SerializeField]
  private LimitBreakIcon LimitBreak;
  [SerializeField]
  private UIButton btnBack;
  private GameObject MyPrefab;
  private GearKindIcon WeaponIcon;
  [SerializeField]
  protected UI2DSprite rarityStarsIcon;
  private UnitTypeIcon HimeIcon;
  private PlayerUnit PlayerUnitData;
  private UI3DModel UIModel;

  public void IbtnGo() => ((Component) this).gameObject.SetActive(false);

  public virtual void IbtnBack()
  {
    if (((Component) this.btnBack).GetComponent<Collider>().enabled && ((Component) this.btnBack).gameObject.activeSelf)
    {
      Singleton<PopupManager>.GetInstance().onDismiss();
      this.backScene();
    }
    ((Component) this.btnBack).GetComponent<Collider>().enabled = false;
  }

  public override void onBackButton() => this.IbtnBack();

  public UIButton BackSceneButton => this.btnBack;

  [DebuggerHidden]
  public IEnumerator Set(PlayerUnit playerUnit, bool newFlag)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0068Menu.\u003CSet\u003Ec__Iterator394()
    {
      playerUnit = playerUnit,
      newFlag = newFlag,
      \u003C\u0024\u003EplayerUnit = playerUnit,
      \u003C\u0024\u003EnewFlag = newFlag,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator LateFitMask()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0068Menu.\u003CLateFitMask\u003Ec__Iterator395()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void SetStatus()
  {
    Judgement.NonBattleParameter nonBattleParameter = Judgement.NonBattleParameter.FromPlayerUnit(this.PlayerUnitData);
    string name1 = this.PlayerUnitData.unit.name;
    string name2 = this.PlayerUnitData.unit.job.name;
    string name3 = this.PlayerUnitData.unit_type.name;
    int maxLevel = this.PlayerUnitData.max_level;
    int level = this.PlayerUnitData.level;
    int hp1 = nonBattleParameter.Hp;
    int hp2 = nonBattleParameter.Hp;
    int cost = this.PlayerUnitData.unit.cost;
    int move = this.PlayerUnitData.move;
    int physicalAttack = nonBattleParameter.PhysicalAttack;
    int physicalDefense = nonBattleParameter.PhysicalDefense;
    int magicAttack = nonBattleParameter.MagicAttack;
    int magicDefense = nonBattleParameter.MagicDefense;
    int hit = nonBattleParameter.Hit;
    int critical = nonBattleParameter.Critical;
    int evasion = nonBattleParameter.Evasion;
    int combat = nonBattleParameter.Combat;
    this.SetText(this.TxtTitle, name1);
    this.SetText(this.TxtJobname, name2);
    this.SetText(this.TxtPrincesstype, name3);
    this.SetText(this.TxtExpmax, " /" + maxLevel.ToString());
    this.SetText(this.TxtExp, level.ToString());
    this.SetText(this.TxtHpmax, " /" + hp1.ToString());
    this.SetText(this.TxtHp, hp2.ToString());
    this.SetText(this.TxtCost, cost.ToString());
    this.SetText(this.TxtMovement, move.ToString());
    this.SetText(this.TxtAttack, physicalAttack.ToString());
    this.SetText(this.TxtDefense, physicalDefense.ToString());
    this.SetText(this.TxtMatk, magicAttack.ToString());
    this.SetText(this.TxtMdef, magicDefense.ToString());
    this.SetText(this.TxtDexterity, hit.ToString());
    this.SetText(this.TxtCritical, critical.ToString());
    this.SetText(this.TxtEvasion, evasion.ToString());
    this.SetText(this.TxtFighting, combat.ToString());
    this.EXPGauge.setValue(this.PlayerUnitData.total_exp - this.PlayerUnitData.exp, this.PlayerUnitData.total_exp + this.PlayerUnitData.exp_next);
  }

  private void SetNewIcon(bool flag) => this.NewIcon.SetActive(flag);

  private void SetText(UILabel label, string text) => label.SetTextLocalize(text.ToConverter());

  [DebuggerHidden]
  private IEnumerator SetRarityStar()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0068Menu.\u003CSetRarityStar\u003Ec__Iterator396()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetWeaponIcon()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0068Menu.\u003CSetWeaponIcon\u003Ec__Iterator397()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetHimeIcon()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0068Menu.\u003CSetHimeIcon\u003Ec__Iterator398()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetCharacterImage()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0068Menu.\u003CSetCharacterImage\u003Ec__Iterator399()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetCharacterModel()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0068Menu.\u003CSetCharacterModel\u003Ec__Iterator39A()
    {
      \u003C\u003Ef__this = this
    };
  }
}
