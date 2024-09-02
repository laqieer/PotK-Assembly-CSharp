// Decompiled with JetBrains decompiler
// Type: GameCore.RecoveryUnit
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

#nullable disable
namespace GameCore
{
  public class RecoveryUnit
  {
    public int unitPositionId;
    public int row;
    public int column;
    public bool completed;
    public int hp;
    public int respawnCount;
    public RecoverySkill[] skillList;
    public RecoverySkillEffect[] skillEffectList;
    public int[] deadTurn;
    public RecoverySkillEffectParam[] skillFixEffectParams;
    public RecoverySkillEffectParam[] skillRatioEffectParams;
    public RecoverySkillEffect[] removedBaseSkillEffects;
    public RecoverySkillEffectParam[] removedFixEffectParams;
    public RecoverySkillEffectParam[] removedRatioEffectParams;
  }
}
