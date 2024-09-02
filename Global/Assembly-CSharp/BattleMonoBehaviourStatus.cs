// Decompiled with JetBrains decompiler
// Type: BattleMonoBehaviourStatus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
