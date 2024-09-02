// Decompiled with JetBrains decompiler
// Type: Battle02UIPlayerStatusBattle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using UnityEngine;

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
    BL.Unit unit1 = this.modified.value;
    this.CreateUnitSprite(this.link_Character);
    UILabel txtCharaNameIb = this.txt_CharaName_ib;
    UnitUnit unit2 = unit1.unit;
    SkillMetamorphosis metamorphosis = unit1.metamorphosis;
    int metamor_id = metamorphosis != null ? metamorphosis.metamorphosis_id : 0;
    string name = unit2.getName(metamor_id);
    this.setText(txtCharaNameIb, name);
    Judgement.BattleParameter battleParameter = Judgement.BattleParameter.FromBeUnit((BL.ISkillEffectListUnit) unit1);
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
