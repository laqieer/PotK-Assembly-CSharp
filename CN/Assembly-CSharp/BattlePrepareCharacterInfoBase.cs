// Decompiled with JetBrains decompiler
// Type: BattlePrepareCharacterInfoBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class BattlePrepareCharacterInfoBase : NGBattleMenuBase
{
  [SerializeField]
  protected UILabel TxtAttack;
  [SerializeField]
  protected UILabel TxtCharaname_element;
  [SerializeField]
  protected GameObject ElementIconParent;
  [SerializeField]
  protected UILabel TxtCritical;
  [SerializeField]
  protected UILabel TxtDexterity;
  [SerializeField]
  protected GameObject[] hpNumber;
  [SerializeField]
  protected UILabel TxtWeaponName;
  [SerializeField]
  protected Transform ImageParent;
  [SerializeField]
  protected int depth;
  [SerializeField]
  protected UI2DSprite iconGear;
  [SerializeField]
  protected GameObject upCompatibility;
  [SerializeField]
  protected GameObject downCompatibility;
  [SerializeField]
  protected NGTweenGaugeScale hpBar;
  [SerializeField]
  protected UILabel TxtConsume;
  [SerializeField]
  protected GameObject[] attackCount;
  protected AttackStatus[] attacks = new AttackStatus[0];
  protected AttackStatus[] magicBullets = new AttackStatus[0];
  private BL.UnitPosition currentUnit;
  private AttackStatus currentAttack;
  private GameObject gearIconPrefab;
  private GameObject elementIconPrefab;
  private CommonElementIcon elementIcon;

  [DebuggerHidden]
  public virtual IEnumerator Init(BL.UnitPosition up, AttackStatus[] attacks_)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattlePrepareCharacterInfoBase.\u003CInit\u003Ec__Iterator88E()
    {
      up = up,
      attacks_ = attacks_,
      \u003C\u0024\u003Eup = up,
      \u003C\u0024\u003Eattacks_ = attacks_,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetElementalIcon(BL.Unit unit, float elementAttackRate)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattlePrepareCharacterInfoBase.\u003CSetElementalIcon\u003Ec__Iterator88F()
    {
      unit = unit,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u003Ef__this = this
    };
  }

  private void setHPNumbers(char[] chp)
  {
    foreach (GameObject gameObject in this.hpNumber)
      gameObject.GetComponentInChildren<BattleUI04SetHP>().notDisplay();
    int index = 0;
    foreach (char ch in ((IEnumerable<char>) chp).Reverse<char>())
    {
      this.hpNumber[index].GetComponentInChildren<BattleUI04SetHP>().setValue(int.Parse(ch.ToString()));
      ++index;
    }
  }

  public BL.UnitPosition getCurrent() => this.currentUnit;

  public AttackStatus getCurrentAttack() => this.currentAttack;

  public int getCurrentAttackIndex()
  {
    return ((IEnumerable<AttackStatus>) this.attacks).FirstIndexOrNull<AttackStatus>((Func<AttackStatus, bool>) (x => x == this.currentAttack)).Value;
  }

  public AttackStatus getAttackStatus(int index)
  {
    return this.magicBullets != null && this.magicBullets.Length > 0 ? this.magicBullets[index] : this.attacks[index];
  }

  public void setCurrentAttack(AttackStatus attackStatus)
  {
    this.currentAttack = attackStatus;
    this.attackCount[0].SetActive(false);
    this.attackCount[1].SetActive(false);
    this.attackCount[2].SetActive(false);
    this.TxtWeaponName.SetTextLocalize(this.currentUnit.unit.playerUnit.equippedGearName);
    ((Component) this.iconGear).gameObject.SetActive(true);
    if (this.currentAttack == null)
    {
      this.TxtAttack.SetText("-");
      this.TxtCritical.SetText("-");
      this.TxtDexterity.SetText("-");
    }
    else
    {
      this.TxtAttack.SetTextLocalize(this.currentAttack.attack);
      this.TxtCritical.SetTextLocalize(this.currentAttack.criticalDisplay().ToString() + "%");
      this.TxtDexterity.SetTextLocalize(this.currentAttack.dexerityDisplay().ToString() + "%");
      this.setAttackCount(this.currentAttack.attackCount);
    }
  }

  private void setAttackCount(int count)
  {
    int num = count - 2;
    int index;
    switch (count)
    {
      case 2:
        index = 0;
        break;
      case 3:
        index = 1;
        break;
      case 4:
        index = 2;
        break;
      default:
        index = -1;
        break;
    }
    if (index < 0)
      return;
    this.attackCount[index].SetActive(true);
  }

  protected virtual ResourceObject maskResource()
  {
    Debug.LogError((object) "no implements");
    return (ResourceObject) null;
  }

  public void SetCompatibility(PlayerUnit opponent)
  {
    Tuple<int, int> gearKindIncr = this.currentUnit.unit.playerUnit.GetGearKindIncr(opponent);
    if (gearKindIncr.Item1 > 0 || gearKindIncr.Item2 > 0)
    {
      this.upCompatibility.SetActive(true);
    }
    else
    {
      if (gearKindIncr.Item1 >= 0 && gearKindIncr.Item2 >= 0)
        return;
      this.downCompatibility.SetActive(true);
    }
  }
}
