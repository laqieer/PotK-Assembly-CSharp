// Decompiled with JetBrains decompiler
// Type: GameCore.RecoveryUnit
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
  }
}
