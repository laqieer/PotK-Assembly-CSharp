// Decompiled with JetBrains decompiler
// Type: BattleUI04Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class BattleUI04Menu : BattleBackButtonMenuBase
{
  [SerializeField]
  private BattlePrepareCharacterInfoPlayer player;
  [SerializeField]
  private BattlePrepareCharacterInfoEnemy enemy;
  [SerializeField]
  private NGHorizontalScrollParts indicator;
  [SerializeField]
  private UIButton attackButton;
  private bool seEnable;
  private bool isInitialize;
  private AttackStatus[] attackStatus;
  private int backSkillCursor;
  private bool isComplited;

  [DebuggerHidden]
  public IEnumerator Init(BL.UnitPosition attack, BL.UnitPosition defense)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI04Menu.\u003CInit\u003Ec__Iterator960()
    {
      attack = attack,
      defense = defense,
      \u003C\u0024\u003Eattack = attack,
      \u003C\u0024\u003Edefense = defense,
      \u003C\u003Ef__this = this
    };
  }

  protected override void Update_Battle()
  {
    if (!this.isInitialize || this.indicator.selected == -1 || this.backSkillCursor == this.indicator.selected)
      return;
    this.player.setCurrentAttack(this.player.getAttackStatus(this.indicator.selected));
    this.backSkillCursor = this.indicator.selected;
  }

  public override void onBackButton()
  {
    if (this.isComplited)
      return;
    this.backScene();
    this.isComplited = true;
  }

  public void onAttackButton()
  {
    if (this.isComplited)
      return;
    if (Singleton<TutorialRoot>.GetInstance().IsFirstBattle())
      UserEvent.SendEvent((MonoBehaviour) Singleton<TutorialRoot>.GetInstance(), "Directed_attack");
    else if (Singleton<TutorialRoot>.GetInstance().IsSceondBattle())
      UserEvent.SendEvent((MonoBehaviour) Singleton<TutorialRoot>.GetInstance(), "Boot_attack");
    BL.UnitPosition current1 = this.player.getCurrent();
    BL.UnitPosition current2 = this.enemy.getCurrent();
    AttackStatus currentAttack = this.player.getCurrentAttack();
    if (currentAttack == null)
      return;
    if (!this.battleManager.useGameEngine)
    {
      this.battleManager.startDuel(BattleFuncs.calcDuel(currentAttack, current1, current2));
    }
    else
    {
      int currentAttackIndex = this.player.getCurrentAttackIndex();
      this.battleManager.gameEngine.moveUnitWithAttack(current1, current2, currentAttack.isHeal, currentAttackIndex);
    }
    this.isComplited = true;
  }

  public void onEndScene()
  {
    this.eraseWithTween();
    this.seEnable = false;
    this.indicator.SeEnable = false;
    this.isComplited = false;
  }

  [DebuggerHidden]
  private IEnumerator WaitScrollSe()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI04Menu.\u003CWaitScrollSe\u003Ec__Iterator961()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void eraseWithTween()
  {
    if (!Object.op_Inequality((Object) null, (Object) this.indicator))
      return;
    ((Component) this.indicator).gameObject.GetComponent<TweenAlpha>().PlayReverse();
  }
}
