// Decompiled with JetBrains decompiler
// Type: BattleMonoBehaviourStatus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
