// Decompiled with JetBrains decompiler
// Type: GameCore.ColosseumBeforBonusParam
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

#nullable disable
namespace GameCore
{
  public class ColosseumBeforBonusParam
  {
    public int HP;
    public int attack;
    public int dexerityDisplay;
    public int criticalDisplay;
    public int attackCount;

    public ColosseumBeforBonusParam(AttackStatus status)
    {
      this.HP = status.duelParameter.attackerUnitParameter.Hp;
      this.attack = status.attack;
      this.dexerityDisplay = status.dexerityDisplay();
      this.criticalDisplay = status.criticalDisplay();
      this.attackCount = status.attackCount;
    }
  }
}
