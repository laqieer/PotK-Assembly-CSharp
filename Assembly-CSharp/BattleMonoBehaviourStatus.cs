// Decompiled with JetBrains decompiler
// Type: BattleMonoBehaviourStatus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

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

  public bool IsBattleManagerCompleted() => this.IsBattleManagerInitializeCompleted && this.StartCompleted;
}
