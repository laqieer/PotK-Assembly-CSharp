// Decompiled with JetBrains decompiler
// Type: GameCore.ColosseumBeforBonusParam
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
