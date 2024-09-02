// Decompiled with JetBrains decompiler
// Type: BattleHealCharacterInfoHealer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class BattleHealCharacterInfoHealer : BattleHealCharacterInfoBase
{
  [SerializeField]
  private GameObject selectCommand;
  [SerializeField]
  protected UI2DSprite iconGear;
  [SerializeField]
  private NGHorizontalScrollParts indicator;
  [SerializeField]
  protected UILabel TxtWeaponName;
  [SerializeField]
  protected UILabel TxtHealAmount;
  [SerializeField]
  private BattleHealCharacterInfoInjured mInjured;
  [SerializeField]
  private GameObject mDotContainer;
  private GameObject commandPrefab;
  private GameObject gearIconPrefab;
  protected AttackStatus[] magicBullets;
  [SerializeField]
  private Battle019_6_1_RecoveryButton recoveryButton;

  [DebuggerHidden]
  public override IEnumerator Init(BL.UnitPosition up, AttackStatus[] attacks)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleHealCharacterInfoHealer.\u003CInit\u003Ec__Iterator82A()
    {
      up = up,
      attacks = attacks,
      \u003C\u0024\u003Eup = up,
      \u003C\u0024\u003Eattacks = attacks,
      \u003C\u003Ef__this = this
    };
  }

  public void onItemChanged()
  {
    if (this.magicBullets == null || this.magicBullets.Length == 0)
      return;
    int selected = this.indicator.selected;
    if (selected < 0 || selected >= this.magicBullets.Length)
      Debug.LogError((object) ("bug, illegal indicator index=" + (object) selected));
    else
      this.setCurrentAttack(this.magicBullets[selected]);
  }

  protected void setCurrentAttack(AttackStatus attackStatus)
  {
    this.currentAttack = attackStatus;
    if (this.currentAttack == null)
    {
      ((Component) this.iconGear).gameObject.SetActive(false);
      this.TxtWeaponName.SetText("-");
      this.TxtHealAmount.SetText("-");
    }
    else
    {
      GearGear gear = this.currentUnit.unit.weapon.gear;
      ((Component) this.iconGear).gameObject.SetActive(true);
      this.TxtWeaponName.SetTextLocalize(this.currentUnit.unit.playerUnit.equippedGearName);
      this.TxtHealAmount.SetTextLocalize(this.currentAttack.heal_attack);
      if (Object.op_Inequality((Object) null, (Object) this.mInjured))
        this.mInjured.setCurrentHP(this.currentAttack.heal_attack);
    }
    this.recoveryButton.setAttackStatus(this.currentAttack, (BattleHealCharacterInfoBase) this);
    BL.Unit unit = this.currentUnit.unit;
    this.hpBar.setValue(unit.hp - this.currentAttack.magicBullet.cost, unit.parameter.Hp, false);
    this.setHPNumbers((unit.hp - this.currentAttack.magicBullet.cost).ToString().ToCharArray());
    this.consumeBar.setValue(unit.hp, unit.parameter.Hp, false);
  }

  protected override ResourceObject maskResource() => Res.GUI._009_3_sozai.mask_Chara_L;
}
