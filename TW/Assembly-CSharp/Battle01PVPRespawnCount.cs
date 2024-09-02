// Decompiled with JetBrains decompiler
// Type: Battle01PVPRespawnCount
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Battle01PVPRespawnCount : NGBattleMenuBase
{
  [SerializeField]
  private UILabel countLabel;

  public void setCount(int n) => this.setText(this.countLabel, n.ToString() + string.Empty);
}
