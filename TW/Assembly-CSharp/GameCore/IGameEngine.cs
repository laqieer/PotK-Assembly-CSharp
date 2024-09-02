// Decompiled with JetBrains decompiler
// Type: GameCore.IGameEngine
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
namespace GameCore
{
  public interface IGameEngine
  {
    bool isDisposition { get; }

    bool isWaitAction { get; }

    int endPoint { get; }

    string playerName { get; }

    string enemyName { get; }

    int playerEmblem { get; }

    int enemyEmblem { get; }

    BL.StructValue<int> remainTurn { get; }

    BL.StructValue<int> timeLimit { get; }

    BL.StructValue<int> playerPoint { get; }

    BL.StructValue<int> enemyPoint { get; }

    BL.StructValue<bool> isPlayerWipedOut { get; }

    BL.StructValue<bool> isEnemyWipedOut { get; }

    HashSet<BL.Panel> formationPanel { get; }

    void startMain();

    void locateUnitsCompleted();

    void turnInitializeCompleted();

    void actionUnitCompleted();

    void wipedOutCompleted();

    void moveUnit(BL.UnitPosition up);

    void moveUnitWithAttack(
      BL.UnitPosition attack,
      BL.UnitPosition defense,
      bool isHeal,
      int attackStatusIndex);

    void moveUnitWithAttack(BL.Unit attack, BL.Unit defense, bool isHeal, int attackStatusIndex);

    void moveUnitWithSkill(BL.Unit unit, BL.Skill skill, List<BL.Unit> targets);

    void readyComplited();
  }
}
