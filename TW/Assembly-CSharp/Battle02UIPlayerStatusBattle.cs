// Decompiled with JetBrains decompiler
// Type: Battle02UIPlayerStatusBattle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

#nullable disable
public class Battle02UIPlayerStatusBattle : Battle02MenuBase
{
  [SerializeField]
  protected UI2DSprite link_Character;
  [SerializeField]
  protected UILabel txt_CharaName_ib;
  [SerializeField]
  protected UILabel txt_Lv_ib;
  [SerializeField]
  protected UILabel txt_Attack_ib;
  [SerializeField]
  protected UILabel txt_Slay_ib;
  [SerializeField]
  protected UILabel txt_Defence_ib;
  [SerializeField]
  protected UILabel txt_Avoid_ib;
  [SerializeField]
  protected UILabel txt_Hit_ib;
  [SerializeField]
  protected UILabel txt_Mdefence_ib;
  [SerializeField]
  protected UILabel txt_MOffence_ib;
  [SerializeField]
  protected UILabel txt_bd_Attack_ib;
  [SerializeField]
  protected UILabel txt_bd_Slay_ib;
  [SerializeField]
  protected UILabel txt_bd_Defence_ib;
  [SerializeField]
  protected UILabel txt_bd_Avoid_ib;
  [SerializeField]
  protected UILabel txt_bd_Hit_ib;
  [SerializeField]
  protected UILabel txt_bd_Mdefence_ib;
  [SerializeField]
  protected UILabel txt_bd_MOffence_ib;

  protected override void LateUpdate_Battle()
  {
  }

  public override void UpdateData()
  {
    if (this.modified == null || !this.modified.isChangedOnce())
      return;
    BL.Unit beUnit = this.modified.value;
    this.CreateUnitSprite(this.link_Character);
    this.setText(this.txt_CharaName_ib, beUnit.unit.name);
    Judgement.BattleParameter battleParameter = Judgement.BattleParameter.FromBeUnit(beUnit);
    this.setParentText(this.txt_Attack_ib, battleParameter.PhysicalAttack);
    this.setParentText(this.txt_Slay_ib, battleParameter.Critical);
    this.setParentText(this.txt_Defence_ib, battleParameter.PhysicalDefense);
    this.setParentText(this.txt_Avoid_ib, battleParameter.Evasion);
    this.setParentText(this.txt_Hit_ib, battleParameter.Hit);
    this.setParentText(this.txt_Mdefence_ib, battleParameter.MagicDefense);
    this.setParentText(this.txt_MOffence_ib, battleParameter.MagicAttack);
    this.setBDText(this.txt_bd_Attack_ib, battleParameter.PhysicalAttackIncr);
    this.setBDText(this.txt_bd_Slay_ib, battleParameter.CriticalIncr);
    this.setBDText(this.txt_bd_Defence_ib, battleParameter.PhysicalDefenseIncr);
    this.setBDText(this.txt_bd_Avoid_ib, battleParameter.EvasionIncr);
    this.setBDText(this.txt_bd_Hit_ib, battleParameter.HitIncr);
    this.setBDText(this.txt_bd_Mdefence_ib, battleParameter.MagicDefenseIncr);
    this.setBDText(this.txt_bd_MOffence_ib, battleParameter.MagicAttackIncr);
  }

  public override void onBackButton()
  {
  }
}
