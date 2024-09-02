// Decompiled with JetBrains decompiler
// Type: Battle02UIPlayerStatusEtc
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

#nullable disable
public class Battle02UIPlayerStatusEtc : Battle02MenuBase
{
  [SerializeField]
  protected UI2DSprite link_Character;
  [SerializeField]
  protected UILabel txt_CharaName_18;
  [SerializeField]
  protected UILabel txt_Lv_22;
  [SerializeField]
  protected UILabel txt_Strength;
  [SerializeField]
  protected UILabel txt_Mana;
  [SerializeField]
  protected UILabel txt_Stability;
  [SerializeField]
  protected UILabel txt_Spirit;
  [SerializeField]
  protected UILabel txt_Agility;
  [SerializeField]
  protected UILabel txt_Technology;
  [SerializeField]
  protected UILabel txt_Luck;
  [SerializeField]
  protected UILabel txt_bd_Strength;
  [SerializeField]
  protected UILabel txt_bd_Mana;
  [SerializeField]
  protected UILabel txt_bd_Stability;
  [SerializeField]
  protected UILabel txt_bd_Spirit;
  [SerializeField]
  protected UILabel txt_bd_Agility;
  [SerializeField]
  protected UILabel txt_bd_Technology;
  [SerializeField]
  protected UILabel txt_bd_Luck;

  protected override void LateUpdate_Battle()
  {
  }

  public override void UpdateData()
  {
    if (this.modified == null || !this.modified.isChangedOnce())
      return;
    BL.Unit unit = this.modified.value;
    this.setText(this.txt_CharaName_18, unit.unit.name);
    this.CreateUnitSprite(this.link_Character);
    Judgement.BattleParameter parameter = unit.parameter;
    this.setParentText(this.txt_Strength, parameter.Strength);
    this.setParentText(this.txt_Mana, parameter.Intelligence);
    this.setParentText(this.txt_Stability, parameter.Vitality);
    this.setParentText(this.txt_Spirit, parameter.Mind);
    this.setParentText(this.txt_Agility, parameter.Agility);
    this.setParentText(this.txt_Technology, parameter.Dexterity);
    this.setParentText(this.txt_Luck, parameter.Luck);
    this.setBDText(this.txt_bd_Strength, parameter.StrengthIncr);
    this.setBDText(this.txt_bd_Mana, parameter.IntelligenceIncr);
    this.setBDText(this.txt_bd_Stability, parameter.VitalityIncr);
    this.setBDText(this.txt_bd_Spirit, parameter.MindIncr);
    this.setBDText(this.txt_bd_Agility, parameter.AgilityIncr);
    this.setBDText(this.txt_bd_Technology, parameter.DexterityIncr);
    this.setBDText(this.txt_bd_Luck, parameter.LuckIncr);
  }

  public override void onBackButton()
  {
  }
}
