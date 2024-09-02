// Decompiled with JetBrains decompiler
// Type: BattleHealCharacterInfoInjured
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class BattleHealCharacterInfoInjured : BattleHealCharacterInfoBase
{
  [SerializeField]
  protected UILabel hpNumberAfter;
  [SerializeField]
  protected UILabel hpNumberBefore;
  [SerializeField]
  private UI2DSprite[] buffSprites;

  [DebuggerHidden]
  public override IEnumerator Init(BL.UnitPosition up, AttackStatus[] attacks)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleHealCharacterInfoInjured.\u003CInit\u003Ec__Iterator8F6()
    {
      up = up,
      attacks = attacks,
      \u003C\u0024\u003Eup = up,
      \u003C\u0024\u003Eattacks = attacks,
      \u003C\u003Ef__this = this
    };
  }

  public void setCurrentHP(int healHP)
  {
    BL.Unit unit = this.currentUnit.unit;
    int n = Mathf.Min(healHP + unit.hp, unit.parameter.Hp);
    this.setHPNumbers(n.ToString());
    this.hpBar.setValue(unit.hp, unit.parameter.Hp, false);
    this.consumeBar.setValue(n, unit.parameter.Hp, false);
  }

  private new void setHPNumbers(string hp) => this.hpNumberAfter.SetTextLocalize(hp);

  protected override ResourceObject maskResource() => Res.GUI._009_3_sozai.mask_Chara_R;
}
