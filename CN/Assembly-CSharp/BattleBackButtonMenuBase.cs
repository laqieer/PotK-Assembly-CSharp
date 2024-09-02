// Decompiled with JetBrains decompiler
// Type: BattleBackButtonMenuBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
