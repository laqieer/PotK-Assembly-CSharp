// Decompiled with JetBrains decompiler
// Type: LevelupSkill
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
