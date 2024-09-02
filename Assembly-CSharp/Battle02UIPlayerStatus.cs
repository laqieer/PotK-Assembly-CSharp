// Decompiled with JetBrains decompiler
// Type: Battle02UIPlayerStatus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using UnityEngine;

public class Battle02UIPlayerStatus : Battle02MenuBase
{
  [SerializeField]
  protected UI2DSprite link_Character;
  [SerializeField]
  protected UILabel txt_CharaName_18;
  [SerializeField]
  protected UILabel txt_Job_22;
  [SerializeField]
  protected UILabel txt_Lv_22;
  [SerializeField]
  protected UILabel txt_HP_22;
  [SerializeField]
  protected UILabel txt_HP_Max_22;
  [SerializeField]
  protected UILabel txt_Combat_22;

  public override void UpdateData()
  {
    if (this.modified == null || !this.modified.isChangedOnce())
      return;
    BL.Unit unit1 = this.modified.value;
    this.CreateUnitSprite(this.link_Character);
    UILabel txtCharaName18 = this.txt_CharaName_18;
    UnitUnit unit2 = unit1.unit;
    SkillMetamorphosis metamorphosis = unit1.metamorphosis;
    int metamor_id = metamorphosis != null ? metamorphosis.metamorphosis_id : 0;
    string name = unit2.getName(metamor_id);
    this.setText(txtCharaName18, name);
    this.setText(this.txt_Job_22, unit1.job.name);
    this.setText(this.txt_Lv_22, unit1.lv);
    this.setText(this.txt_HP_22, unit1.hp);
    if (unit1.hp <= unit1.parameter.Hp / 10)
    {
      this.txt_HP_22.color = this.mRed;
      TweenColor.Begin(this.txt_HP_22.gameObject, 1f, new Color(0.5f, 0.0f, 0.0f)).style = UITweener.Style.Loop;
    }
    if (unit1.parameter.HpIncr > 0)
      this.setText(this.txt_HP_Max_22, "[00dc1e]" + (object) unit1.parameter.Hp + "[-]");
    else if (unit1.parameter.HpIncr < 0)
      this.setText(this.txt_HP_Max_22, "[fa0000]" + (object) unit1.parameter.Hp + "[-]");
    else
      this.setText(this.txt_HP_Max_22, unit1.parameter.Hp);
    Judgement.BattleParameter battleParameter = Judgement.BattleParameter.FromBeUnit((BL.ISkillEffectListUnit) unit1);
    this.setColordText(this.txt_Combat_22, battleParameter.Combat, battleParameter.CombatIncr);
  }

  public override void onBackButton()
  {
  }
}
