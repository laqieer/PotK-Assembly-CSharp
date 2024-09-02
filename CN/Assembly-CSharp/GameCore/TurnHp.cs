// Decompiled with JetBrains decompiler
// Type: GameCore.TurnHp
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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

    public bool isDieAttackerOrDefender() => this.attackerHp <= 0 || this.defenderHp <= 0;
  }
}
