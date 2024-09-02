// Decompiled with JetBrains decompiler
// Type: ScheduleEnableWait
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

#nullable disable
public class ScheduleEnableWait : Schedule
{
  private float wait;

  public ScheduleEnableWait(float wait)
  {
    this.wait = wait;
    this.isSetBattleEnable = true;
    this.isBattleEnable = false;
  }

  public override bool completedp() => (double) this.deltaTime > (double) this.wait;
}
