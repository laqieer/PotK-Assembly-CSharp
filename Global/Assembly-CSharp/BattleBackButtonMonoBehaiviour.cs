// Decompiled with JetBrains decompiler
// Type: BattleBackButtonMonoBehaiviour
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public abstract class BattleBackButtonMonoBehaiviour : BattleMonoBehaviour
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
