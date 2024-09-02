// Decompiled with JetBrains decompiler
// Type: GameCore.DuelColosseumResult
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using SM;

#nullable disable
namespace GameCore
{
  public class DuelColosseumResult
  {
    public const int DRAW = 0;
    public const int PLAYER_WIN = 1;
    public const int OPPONENT_WIN = 2;
    public bool isPlayerFirstAttacker;
    public BL.Unit player;
    public PlayerItem playerEq;
    public ColosseumBeforBonusParam playerBeforeBonusParam;
    public AttackStatus playerAttackStatus;
    public AttackStatus colosseumNewPAS;
    public Bonus[] playerActiveBonus;
    public IntimateDuelSupport playerDuelSupport;
    public BL.Unit opponent;
    public PlayerItem opponentEq;
    public ColosseumBeforBonusParam opponentBeforeBonusParam;
    public AttackStatus opponentAttackStatus;
    public AttackStatus colosseumNewOAS;
    public Bonus[] opponentActiveBonus;
    public IntimateDuelSupport opponentDuelSupport;
    public BL.DuelTurn[] turns;
    public int playerDamage;
    public int playerFromDamage;
    public bool isDiePlayer;
    public int opponentDamage;
    public int opponentFromDamage;
    public bool isDieOpponent;

    public int judgment
    {
      get
      {
        if (this.isDiePlayer != this.isDieOpponent)
        {
          if (this.isDiePlayer)
            return 2;
          if (this.isDieOpponent)
            return 1;
        }
        return 0;
      }
    }

    public int firstAttackerDamage
    {
      get => this.isPlayerFirstAttacker ? this.playerDamage : this.opponentDamage;
      set
      {
        if (this.isPlayerFirstAttacker)
          this.playerDamage = value;
        else
          this.opponentDamage = value;
      }
    }

    public int firstAttackerFromDamage
    {
      get => this.isPlayerFirstAttacker ? this.playerFromDamage : this.opponentFromDamage;
      set
      {
        if (this.isPlayerFirstAttacker)
          this.playerFromDamage = value;
        else
          this.opponentFromDamage = value;
      }
    }

    public bool isDieFirstAttacker
    {
      get => this.isPlayerFirstAttacker ? this.isDiePlayer : this.isDieOpponent;
      set
      {
        if (this.isPlayerFirstAttacker)
          this.isDiePlayer = value;
        else
          this.isDieOpponent = value;
      }
    }

    public int secondAttackerDamage
    {
      get => !this.isPlayerFirstAttacker ? this.playerDamage : this.opponentDamage;
      set
      {
        if (!this.isPlayerFirstAttacker)
          this.playerDamage = value;
        else
          this.opponentDamage = value;
      }
    }

    public int secondAttackerFromDamage
    {
      get => !this.isPlayerFirstAttacker ? this.playerFromDamage : this.opponentFromDamage;
      set
      {
        if (!this.isPlayerFirstAttacker)
          this.playerFromDamage = value;
        else
          this.opponentFromDamage = value;
      }
    }

    public bool isDieSecondAttacker
    {
      get => !this.isPlayerFirstAttacker ? this.isDiePlayer : this.isDieOpponent;
      set
      {
        if (!this.isPlayerFirstAttacker)
          this.isDiePlayer = value;
        else
          this.isDieOpponent = value;
      }
    }
  }
}
