// Decompiled with JetBrains decompiler
// Type: BattleBackButtonMenuBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public abstract class BattleBackButtonMenuBase : NGBattleMenuBase
{
  private void Update()
  {
    this.Update_Original();
    if (!this.bmStatus.IsBattleManagerCompleted())
      return;
    if (!Singleton<CommonRoot>.GetInstance().isInputBlock && Input.GetKeyUp((KeyCode) 27))
      this.onBackButton();
    this.Update_Battle();
  }

  public abstract void onBackButton();
}
