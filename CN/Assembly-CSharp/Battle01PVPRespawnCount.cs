// Decompiled with JetBrains decompiler
// Type: Battle01PVPRespawnCount
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Battle01PVPRespawnCount : NGBattleMenuBase
{
  [SerializeField]
  private UILabel countLabel;

  public void setCount(int n) => this.setText(this.countLabel, n.ToString() + string.Empty);
}
