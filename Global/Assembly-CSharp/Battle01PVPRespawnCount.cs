// Decompiled with JetBrains decompiler
// Type: Battle01PVPRespawnCount
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Battle01PVPRespawnCount : NGBattleMenuBase
{
  [SerializeField]
  private UILabel countLabel;

  public void setCount(int n) => this.setText(this.countLabel, n.ToString() + string.Empty);
}
