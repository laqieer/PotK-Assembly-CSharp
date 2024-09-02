// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleStageEnemyAttackMethod
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class BattleStageEnemyAttackMethod
  {
    public int ID;
    public int stage_enemy_unit_BattleStageEnemy;
    public int skill_BattleskillSkill;
    public int kind_GearKind;
    public string motion_key;

    public static BattleStageEnemyAttackMethod Parse(
      MasterDataReader reader)
    {
      return new BattleStageEnemyAttackMethod()
      {
        ID = reader.ReadInt(),
        stage_enemy_unit_BattleStageEnemy = reader.ReadInt(),
        skill_BattleskillSkill = reader.ReadInt(),
        kind_GearKind = reader.ReadInt(),
        motion_key = reader.ReadString(true)
      };
    }

    public BattleStageEnemy stage_enemy_unit
    {
      get
      {
        BattleStageEnemy battleStageEnemy;
        if (!MasterData.BattleStageEnemy.TryGetValue(this.stage_enemy_unit_BattleStageEnemy, out battleStageEnemy))
          Debug.LogError((object) ("Key not Found: MasterData.BattleStageEnemy[" + (object) this.stage_enemy_unit_BattleStageEnemy + "]"));
        return battleStageEnemy;
      }
    }

    public BattleskillSkill skill
    {
      get
      {
        BattleskillSkill battleskillSkill;
        if (!MasterData.BattleskillSkill.TryGetValue(this.skill_BattleskillSkill, out battleskillSkill))
          Debug.LogError((object) ("Key not Found: MasterData.BattleskillSkill[" + (object) this.skill_BattleskillSkill + "]"));
        return battleskillSkill;
      }
    }

    public GearKind kind
    {
      get
      {
        GearKind gearKind;
        if (!MasterData.GearKind.TryGetValue(this.kind_GearKind, out gearKind))
          Debug.LogError((object) ("Key not Found: MasterData.GearKind[" + (object) this.kind_GearKind + "]"));
        return gearKind;
      }
    }

    public IAttackMethod CreateInterface() => (IAttackMethod) new BattleStageEnemyAttackMethod.EnemyAttackMethod(this);

    private class EnemyAttackMethod : IAttackMethod
    {
      private BattleStageEnemyAttackMethod original_;

      public override object original => (object) this.original_;

      public override GearKind kind { get; protected set; }

      public override BattleskillSkill skill { get; protected set; }

      public override string motionKey => this.original_.motion_key;

      public EnemyAttackMethod(BattleStageEnemyAttackMethod v)
      {
        this.original_ = v;
        this.kind = v.kind;
        this.skill = v.skill;
      }
    }
  }
}
