// Decompiled with JetBrains decompiler
// Type: BattleHealCharacterInfoBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class BattleHealCharacterInfoBase : NGBattleMenuBase
{
  [SerializeField]
  protected UILabel TxtCharaname;
  [SerializeField]
  protected GameObject[] hpNumber;
  [SerializeField]
  protected Transform ImageParent;
  [SerializeField]
  protected int depth;
  [SerializeField]
  protected NGTweenGaugeScale hpBar;
  [SerializeField]
  protected NGTweenGaugeScale consumeBar;
  protected AttackStatus[] attacks;
  protected BL.UnitPosition currentUnit;
  protected AttackStatus currentAttack;

  [DebuggerHidden]
  public virtual IEnumerator Init(BL.UnitPosition up, AttackStatus[] attacks_)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleHealCharacterInfoBase.\u003CInit\u003Ec__Iterator829()
    {
      up = up,
      attacks_ = attacks_,
      \u003C\u0024\u003Eup = up,
      \u003C\u0024\u003Eattacks_ = attacks_,
      \u003C\u003Ef__this = this
    };
  }

  public void setHPNumbers(char[] chp)
  {
    int index = 0;
    foreach (GameObject gameObject in this.hpNumber)
      gameObject.GetComponentInChildren<BattleUI04SetHP>().notDisplay();
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

  protected virtual ResourceObject maskResource() => (ResourceObject) null;
}
