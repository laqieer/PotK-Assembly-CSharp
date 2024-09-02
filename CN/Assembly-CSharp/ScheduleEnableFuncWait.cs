// Decompiled with JetBrains decompiler
// Type: ScheduleEnableFuncWait
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
