// Decompiled with JetBrains decompiler
// Type: GVGSetting
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
[Serializable]
public class GVGSetting
{
  public float point_leader_factor;
  public float point_no_leader_factor;
  public float point_cost_factor;
  public float point_rarity_factor;
  public float point_base_factor;
  public float respawn_base_factor;
  public float respawn_rarity_factor;
  public float respawn_cost_factor;
  public float turns_factor;
  public int turns;
  public int point;
  public int timeLimit;

  public GVGSetting()
  {
    this.point_leader_factor = this.point_no_leader_factor = this.point_cost_factor = this.point_rarity_factor = this.point_base_factor = this.respawn_base_factor = this.respawn_rarity_factor = this.respawn_cost_factor = this.turns_factor = 1f;
    this.turns = 10;
    this.point = 50;
    this.timeLimit = 20;
  }
}
