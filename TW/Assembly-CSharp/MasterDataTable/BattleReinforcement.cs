﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleReinforcement
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class BattleReinforcement
  {
    public int ID;
    public string name;
    public int reinforcement_logic_BattleReinforcementLogic;
    public int arg1_value;
    public int arg2_value;

    public BattleVictoryAreaCondition[] area
    {
      get
      {
        return this.reinforcement_logic.Enum == BattleReinforcementLogicEnum.enemy_area_invasion || this.reinforcement_logic.Enum == BattleReinforcementLogicEnum.player_area_invasion ? ((IEnumerable<BattleVictoryAreaCondition>) MasterData.BattleVictoryAreaConditionList).Where<BattleVictoryAreaCondition>((Func<BattleVictoryAreaCondition, bool>) (x => x.group_id == this.arg1_value)).ToArray<BattleVictoryAreaCondition>() : (BattleVictoryAreaCondition[]) null;
      }
    }

    public bool isSpawnForBattle(BL.Unit attack, BL.Unit defence)
    {
      if (this.reinforcement_logic.Enum == BattleReinforcementLogicEnum.battle)
      {
        if (this.arg1_value == 0 || attack.playerUnit.is_enemy && attack.playerUnit.checkGroup(this.arg1_value))
          return true;
        return defence.playerUnit.is_enemy && defence.playerUnit.checkGroup(this.arg1_value);
      }
      if (this.reinforcement_logic.Enum == BattleReinforcementLogicEnum.player_attack)
      {
        if (defence.playerUnit.checkGroup(this.arg1_value))
          return true;
        return defence.playerUnit.is_enemy && this.arg1_value == 0;
      }
      if (this.reinforcement_logic.Enum != BattleReinforcementLogicEnum.enemy_attack)
        return false;
      if (attack.playerUnit.checkGroup(this.arg1_value))
        return true;
      return attack.playerUnit.is_enemy && this.arg1_value == 0;
    }

    public static BattleReinforcement Parse(MasterDataReader reader)
    {
      return new BattleReinforcement()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        reinforcement_logic_BattleReinforcementLogic = reader.ReadInt(),
        arg1_value = reader.ReadInt(),
        arg2_value = reader.ReadInt()
      };
    }

    public BattleReinforcementLogic reinforcement_logic
    {
      get
      {
        BattleReinforcementLogic reinforcementLogic;
        if (!MasterData.BattleReinforcementLogic.TryGetValue(this.reinforcement_logic_BattleReinforcementLogic, out reinforcementLogic))
          Debug.LogError((object) ("Key not Found: MasterData.BattleReinforcementLogic[" + (object) this.reinforcement_logic_BattleReinforcementLogic + "]"));
        return reinforcementLogic;
      }
    }
  }
}
