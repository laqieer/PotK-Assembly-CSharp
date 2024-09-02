// Decompiled with JetBrains decompiler
// Type: MasterDataTable.AttackMethod
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class AttackMethod
  {
    public int ID;
    public int unit_UnitUnit;
    public int job_UnitJob;
    public int skill_BattleskillSkill;
    public int kind_GearKind;
    public string motion_key;

    public static AttackMethod Parse(MasterDataReader reader) => new AttackMethod()
    {
      ID = reader.ReadInt(),
      unit_UnitUnit = reader.ReadInt(),
      job_UnitJob = reader.ReadInt(),
      skill_BattleskillSkill = reader.ReadInt(),
      kind_GearKind = reader.ReadInt(),
      motion_key = reader.ReadString(true)
    };

    public UnitUnit unit
    {
      get
      {
        UnitUnit unitUnit;
        if (!MasterData.UnitUnit.TryGetValue(this.unit_UnitUnit, out unitUnit))
          Debug.LogError((object) ("Key not Found: MasterData.UnitUnit[" + (object) this.unit_UnitUnit + "]"));
        return unitUnit;
      }
    }

    public UnitJob job
    {
      get
      {
        UnitJob unitJob;
        if (!MasterData.UnitJob.TryGetValue(this.job_UnitJob, out unitJob))
          Debug.LogError((object) ("Key not Found: MasterData.UnitJob[" + (object) this.job_UnitJob + "]"));
        return unitJob;
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

    public IAttackMethod CreateInterface() => (IAttackMethod) new AttackMethod.MasterAttackMethod(this);

    private class MasterAttackMethod : IAttackMethod
    {
      private AttackMethod original_;

      public override object original => (object) this.original_;

      public override GearKind kind { get; protected set; }

      public override BattleskillSkill skill { get; protected set; }

      public override string motionKey => this.original_.motion_key;

      public MasterAttackMethod(AttackMethod v)
      {
        this.original_ = v;
        this.kind = v.kind;
        this.skill = v.skill;
      }
    }
  }
}
