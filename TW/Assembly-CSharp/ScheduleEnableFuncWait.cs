// Decompiled with JetBrains decompiler
// Type: ScheduleEnableFuncWait
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
public class ScheduleEnableFuncWait : Schedule
{
  private Func<bool> waitF;

  public ScheduleEnableFuncWait(Func<bool> waitF)
  {
    this.waitF = waitF;
    this.isSetBattleEnable = true;
    this.isBattleEnable = false;
  }

  public override bool completedp() => this.waitF();
}
