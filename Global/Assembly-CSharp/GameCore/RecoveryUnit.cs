// Decompiled with JetBrains decompiler
// Type: GameCore.RecoveryUnit
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
