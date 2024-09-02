// Decompiled with JetBrains decompiler
// Type: Popup017192Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Popup017192Menu : NGBattleMenuBase
{
  public void IbtnYes()
  {
    this.env.core.isAutoBattle.value = false;
    this.battleManager.popupDismiss();
  }

  public void IbtnNo() => this.battleManager.popupDismiss();

  private void Update()
  {
    if (Singleton<CommonRoot>.GetInstance().isInputBlock || !Input.GetKeyUp((KeyCode) 27))
      return;
    this.IbtnNo();
  }
}
