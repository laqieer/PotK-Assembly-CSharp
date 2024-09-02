// Decompiled with JetBrains decompiler
// Type: Battle02UIPlayerStatus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using UnityEngine;

#nullable disable
public class Battle02UIPlayerStatus : Battle02MenuBase
{
  [SerializeField]
  protected UI2DSprite link_Character;
  [SerializeField]
  protected UILabel txt_CharaName_18;
  [SerializeField]
  protected UILabel txt_Lv_22;
  [SerializeField]
  protected UILabel txt_HP_22;
  [SerializeField]
  protected UILabel txt_Combat_22;
  [SerializeField]
  protected UILabel txt_Job_22;
  [SerializeField]
  protected UILabel txt_Attack_22;
  [SerializeField]
  protected UILabel txt_Slay_22;
  [SerializeField]
  protected UILabel txt_Defence_22;
  [SerializeField]
  protected UILabel txt_Avoid_22;
  [SerializeField]
  protected UILabel txt_Hit_22;
  [SerializeField]
  protected UILabel txt_Mdefence_22;
  [SerializeField]
  protected UILabel txt_MOffence_22;
  [SerializeField]
  protected UILabel txt_Movement_22;
  [SerializeField]
  protected UILabel txt_Rangement_22;
  private Hashtable mHt;

  private void Awake() => this.mHt = new Hashtable();

  protected override void LateUpdate_Battle()
  {
    if (this.mHt.Count == 0)
      return;
    iTween.ColorUpdate(((Component) this.txt_HP_22).gameObject, this.mRed, 1f);
  }

  public override void UpdateData()
  {
    if (this.modified == null || !this.modified.isChangedOnce())
      return;
    BL.Unit beUnit = this.modified.value;
    this.CreateUnitSprite(this.link_Character);
    this.setText(this.txt_CharaName_18, beUnit.unit.name);
    this.setText(this.txt_Lv_22, beUnit.lv);
    if (beUnit.hp > beUnit.parameter.Hp / 10)
    {
      if (beUnit.parameter.HpIncr > 0)
        this.setText(this.txt_HP_22, beUnit.hp.ToString() + "/[00dc1e]" + (object) beUnit.parameter.Hp + "[-]");
      else if (beUnit.parameter.HpIncr < 0)
        this.setText(this.txt_HP_22, beUnit.hp.ToString() + "/[fa0000]" + (object) beUnit.parameter.Hp + "[-]");
      else
        this.setText(this.txt_HP_22, beUnit.hp.ToString() + "/" + (object) beUnit.parameter.Hp);
    }
    else
    {
      this.setText(this.txt_HP_22, beUnit.hp.ToString() + "/" + (object) beUnit.parameter.Hp);
      this.txt_HP_22.color = this.mRed;
      TweenColor.Begin(((Component) this.txt_HP_22).gameObject, 1f, new Color(0.5f, 0.0f, 0.0f)).style = UITweener.Style.Loop;
    }
    this.setText(this.txt_Job_22, beUnit.job.name);
    Judgement.BattleParameter battleParameter = Judgement.BattleParameter.FromBeUnit(beUnit);
    this.setColordText(this.txt_Combat_22, battleParameter.Combat, battleParameter.CombatIncr);
  }

  public override void onBackButton()
  {
  }
}
