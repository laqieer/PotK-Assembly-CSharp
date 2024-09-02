// Decompiled with JetBrains decompiler
// Type: GameCore.TurnHp
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

#nullable disable
namespace GameCore
{
  public class TurnHp
  {
    public int attackerHp;
    public int defenderHp;
    public bool attackerIsDontAction;
    public bool defenderIsDontAction;
    public bool attackerIsDontEvasion;
    public bool defenderIsDontEvasion;
    public bool attackerIsDontUseSkill;
    public bool defenderIsDontUseSkill;
    public bool attackerCantOneMore;
    public bool defenderCantOneMore;

    public bool isDieAttackerOrDefender() => this.attackerHp <= 0 || this.defenderHp <= 0;
  }
}
