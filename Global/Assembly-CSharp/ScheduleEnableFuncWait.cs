// Decompiled with JetBrains decompiler
// Type: ScheduleEnableFuncWait
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
