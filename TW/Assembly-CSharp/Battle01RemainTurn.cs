// Decompiled with JetBrains decompiler
// Type: Battle01RemainTurn
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Battle01RemainTurn : NGBattleMenuBase
{
  private BL.BattleModified<BL.PhaseState> stateModified;
  private BL.BattleModified<BL.Condition> conditionModified;
  [SerializeField]
  private UILabel txt_turn;
  [SerializeField]
  private UILabel txt_3turn;
  [SerializeField]
  private UILabel txt_3turn_survive;
  [SerializeField]
  private GameObject effect;
  [SerializeField]
  private GameObject effect_3turn;
  [SerializeField]
  private GameObject effect_3turn_survive;
  [SerializeField]
  private int redLimit = 3;
  private int turn;
  private Color survive_color = new Color(0.0f, 1f, 1f);

  private int remainTurn()
  {
    if (this.env.core.condition.isTurn)
      return this.env.core.condition.turn - this.env.core.phaseState.turnCount;
    return this.env.core.condition.isElapsedTurn ? Mathf.Max(0, this.env.core.condition.elapsedTurn - this.env.core.phaseState.turnCount) : 0;
  }

  private void setTurn(int rt)
  {
    if (rt > this.redLimit)
    {
      this.effect.SetActive(true);
      this.effect_3turn.SetActive(false);
      this.effect_3turn_survive.SetActive(false);
      this.txt_turn.color = Color.white;
    }
    else if (this.env.core.condition.isElapsedTurn)
    {
      this.effect.SetActive(false);
      this.effect_3turn.SetActive(false);
      this.effect_3turn_survive.SetActive(true);
      this.txt_turn.color = this.survive_color;
      ((Behaviour) ((Component) this.txt_turn).GetComponent<UITweener>()).enabled = true;
    }
    else
    {
      this.effect.SetActive(false);
      this.effect_3turn.SetActive(true);
      this.effect_3turn_survive.SetActive(false);
      this.txt_turn.color = Color.red;
      ((Behaviour) ((Component) this.txt_turn).GetComponent<UITweener>()).enabled = true;
    }
    this.setText(this.txt_turn, rt);
    this.setText(this.txt_3turn, rt);
    this.setText(this.txt_3turn_survive, rt);
    this.turn = rt;
  }

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01RemainTurn.\u003CStart_Battle\u003Ec__Iterator921()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected override void Update_Battle()
  {
    if (this.conditionModified.isChangedOnce())
    {
      this.turn = this.remainTurn();
      this.setTurn(this.turn);
    }
    if (!this.stateModified.isChangedOnce())
      return;
    int rt = this.remainTurn();
    if (rt == this.turn)
      return;
    this.setTurn(rt);
    this.turn = rt;
  }
}
