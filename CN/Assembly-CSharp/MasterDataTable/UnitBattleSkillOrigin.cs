// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitBattleSkillOrigin
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

#nullable disable
namespace MasterDataTable
{
  public class UnitBattleSkillOrigin
  {
    public UnitBattleSkillOrigin(object origin, BattleskillSkill skill)
    {
      this.origin_ = origin;
      this.skill_ = skill;
    }

    public object origin_ { get; private set; }

    public BattleskillSkill skill_ { get; private set; }

    public bool IsOriginBasic => (object) this.origin_.GetType() == (object) typeof (UnitSkill);

    public UnitSkill Basic => this.origin_ as UnitSkill;

    public bool IsOriginLeaderBasic
    {
      get => (object) this.origin_.GetType() == (object) typeof (UnitLeaderSkill);
    }

    public UnitLeaderSkill LeaderBasic => this.origin_ as UnitLeaderSkill;

    public bool IsOriginCharacterQuest
    {
      get => (object) this.origin_.GetType() == (object) typeof (UnitSkillCharacterQuest);
    }

    public UnitSkillCharacterQuest CharacterQuest => this.origin_ as UnitSkillCharacterQuest;

    public bool IsOriginHarmonyQuest
    {
      get => (object) this.origin_.GetType() == (object) typeof (UnitSkillHarmonyQuest);
    }

    public UnitSkillHarmonyQuest HarmonyQuest => this.origin_ as UnitSkillHarmonyQuest;

    public bool IsOriginEvolution
    {
      get => (object) this.origin_.GetType() == (object) typeof (UnitSkillEvolution);
    }

    public UnitSkillEvolution Evolution => this.origin_ as UnitSkillEvolution;
  }
}
