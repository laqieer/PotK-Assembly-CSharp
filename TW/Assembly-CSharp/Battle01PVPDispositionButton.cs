﻿// Decompiled with JetBrains decompiler
// Type: Battle01PVPDispositionButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

#nullable disable
public class Battle01PVPDispositionButton : NGBattleMenuBase
{
  private bool isCompleted;

  public void onClick()
  {
    if (this.isCompleted)
      return;
    this.battleManager.gameEngine.locateUnitsCompleted();
    this.isCompleted = true;
  }
}
