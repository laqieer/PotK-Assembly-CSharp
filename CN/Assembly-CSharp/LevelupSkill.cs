// Decompiled with JetBrains decompiler
// Type: LevelupSkill
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
