// Decompiled with JetBrains decompiler
// Type: Battle01PVPDispositionButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

#nullable disable
public class Battle01PVPDispositionButton : NGBattleMenuBase
{
  private bool isCompleted;

  public void onClick()
  {
    if (this.isCompleted)
      return;
    Singleton<PVPManager>.GetInstance().locateUnitsCompleted();
    this.isCompleted = true;
  }
}
