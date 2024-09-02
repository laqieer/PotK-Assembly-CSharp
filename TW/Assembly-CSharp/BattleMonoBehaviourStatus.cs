// Decompiled with JetBrains decompiler
// Type: BattleMonoBehaviourStatus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

#nullable disable
public class BattleMonoBehaviourStatus
{
  public bool StartCompleted;
  public bool IsBattleManagerInitializeCompleted;

  public bool IsBattleManagerInitialized()
  {
    if (this.IsBattleManagerInitializeCompleted)
      return true;
    return Singleton<NGBattleManager>.GetInstance().initialized && (this.IsBattleManagerInitializeCompleted = true);
  }

  public bool IsBattleManagerCompleted()
  {
    return this.IsBattleManagerInitializeCompleted && this.StartCompleted;
  }
}
