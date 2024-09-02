// Decompiled with JetBrains decompiler
// Type: LevelupSkill
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;

#nullable disable
public class LevelupSkill
{
  public LevelupSkill(int beforeLevel, int afterLevel, BattleskillSkill skill)
  {
    this.beforeLevel = beforeLevel;
    this.afterLevel = afterLevel;
    this.skill = skill;
  }

  public int beforeLevel { get; set; }

  public int afterLevel { get; set; }

  public BattleskillSkill skill { get; set; }
}
